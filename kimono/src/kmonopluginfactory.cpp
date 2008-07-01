/***************************************************************************
 *   Copyright (C) 2008 by Arno Rehn <arno@arnorehn.de>                    *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA .        *
 ***************************************************************************/

#include <QObject>
#include <QString>
#include <QFileInfo>
#include <QDir>
#include <QVariant>

#include <KStandardDirs>
#include <KPluginFactory>

#include <kdebug.h>

#include <qyoto.h>

#include <smoke.h>
#include <smoke/qt_smoke.h>

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>

class QWidget;

class KMonoPluginFactory : public KPluginFactory
{
public:
	KMonoPluginFactory();
	virtual ~KMonoPluginFactory();

protected:
	virtual QObject* create(const char *iface, QWidget *parentWidget,
	                        QObject *parent, const QVariantList &args,
	                        const QString &keyword);

private:
	void InitQyotoRuntime();

	MonoDomain* domain;
	MonoAssembly* assembly;
	MonoObject* object;
	guint32 handle;
};
K_EXPORT_PLUGIN(KMonoPluginFactory)

KMonoPluginFactory::KMonoPluginFactory()
	: domain(0), assembly(0), object(0), handle(0)
{
}

KMonoPluginFactory::~KMonoPluginFactory()
{
	mono_gchandle_free(handle);
	// FIXME: this should actually work
	/*if (domain)
		mono_jit_cleanup(domain);*/
}

void
KMonoPluginFactory::InitQyotoRuntime()
{
	// open the assembly 'qt-dotnet', look for Qyoto.SmokeInvocation.InitRuntime() and call it
	// it seems that there's now way to call static c'tors explicitly, hence the extra method
	MonoAssembly* qyotoAssembly = mono_domain_assembly_open(domain, "qt-dotnet");
	MonoImage* qyotoImage = mono_assembly_get_image(qyotoAssembly);
	MonoMethodDesc* desc = mono_method_desc_new("Qyoto.SmokeInvocation:InitRuntime()", true);
	MonoClass* klass = mono_class_from_name(qyotoImage, "Qyoto", "SmokeInvocation");
	MonoMethod* meth = mono_method_desc_search_in_class(desc, klass);
	mono_runtime_invoke(meth, NULL, NULL, NULL);
}

QObject*
KMonoPluginFactory::create(const char *iface, QWidget *parentWidget,
	                       QObject *parent, const QVariantList &args,
	                       const QString &keyword)
{
	Q_UNUSED(iface);
	Q_UNUSED(parentWidget);

	// find the assembly
	QString path = KStandardDirs::locate("data", keyword);

	if (path.isEmpty()) {
		kWarning() << "Couldn't find" << keyword;
		return 0;
	}

	// initialize the JIT and open the assembly
	domain = mono_jit_init((const char*) path.toLatin1());
	assembly = mono_domain_assembly_open(domain, (const char*) path.toLatin1());

	if (!assembly) {
		kWarning() << "Couldn't open assembly" << path;
		return 0;
	}

	MonoImage* image = mono_assembly_get_image(assembly);

	// a path in the form Foo/Bar.dll results in the class Bar in the namespace Foo
	QFileInfo file(path);
	QString nameSpace = file.dir().dirName();
	QString className = file.completeBaseName();
	MonoClass* klass = mono_class_from_name(image, (const char*) nameSpace.toLatin1(), (const char*) className.toLatin1());

	// we want the Foo.Bar:.ctor(QObject, List<QVariant>)
	QString methodName = nameSpace + "." + className + ":.ctor(Qyoto.QObject,System.Collections.Generic.List`1)";
	MonoMethodDesc* desc = mono_method_desc_new((const char*) methodName.toLatin1(), true);
	
	MonoMethod* ctor = mono_method_desc_search_in_class(desc, klass);
	
	if (!ctor) {
		kWarning() << "Didn't find method" << methodName << "in class" << nameSpace + "." + className;
		return 0;
	}
	
	// create an instance of the class
	object = mono_object_new(domain, klass);
	
	if (!object) {
		kWarning() << "Failed to create instance of class" << nameSpace + "." + className;
		return 0;
	}
	
	// initialize the Qyoto runtime
	InitQyotoRuntime();
	
	// wrap the parent QObject
	smokeqyoto_object* po = alloc_smokeqyoto_object(false, qt_Smoke, qt_Smoke->idClass("QObject").index, parent);
	void* pobj = (*CreateInstance)("Qyoto.QObject", po);
	
	// wrap the args in a List<QVariant> 
	void* list = (*ConstructList)("Qyoto.QVariant");
	foreach(QVariant v, args) {
		smokeqyoto_object* vo = alloc_smokeqyoto_object(true, qt_Smoke,
			qt_Smoke->idClass("QVariant").index, new QVariant(v));
		void* vobj = (*CreateInstance)("Qyoto.QVariant", vo);
		(*AddIntPtrToList)(list, vobj);
		(*FreeGCHandle)(vobj);
	}
	
	// set up the parameters and call the constructor
	void* a[2];
	a[0] = mono_gchandle_get_target((guint32) (qint64) pobj);
	a[1] = mono_gchandle_get_target((guint32) (qint64) list);
	mono_runtime_invoke(ctor, object, a, NULL);
	(*FreeGCHandle)(pobj);
	(*FreeGCHandle)(list);
	
	// get a handle to the object and pin it, so it won't be collected
	handle = mono_gchandle_new(object, true);
	
	// return the newly created QObject
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)((void*) handle);
	QObject* qobject = reinterpret_cast<QObject*>(o->ptr);
	qobject->setParent(parent);
	return qobject;
}
