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

#include <stdlib.h>
#include <stdio.h>

class QWidget;

class KimonoPluginFactory : public KPluginFactory
{
public:
	KimonoPluginFactory();
	virtual ~KimonoPluginFactory();

protected:
	virtual QObject* create(const char *iface, QWidget *parentWidget,
	                        QObject *parent, const QVariantList &args,
	                        const QString &keyword);

private:
	void initQyotoRuntime();
	
	QHash<QString, MonoAssembly*> assemblies;
	QHash<MonoAssembly*, MonoImage*> images;
	
	MonoAssembly* qyotoAssembly;
	MonoImage* qyotoImage;
	
	QList<MonoObject*> objects;
	QList<guint32> handles;
	
	bool qyotoInitialized;
};
K_EXPORT_PLUGIN(KimonoPluginFactory)

// Make this one global to be accessible from atexitfn().
MonoDomain* domain = 0;

// This seems to be the only way, since calling mono_jit_cleanup()
// from the destructor of KimonoPluginFactory makes mono crash.
void atexitfn()
{
// 	printf("(kimonopluginfactory.cpp:%d) calling mono_jit_cleanup(%p)\n", __LINE__, domain);
	mono_jit_cleanup(domain);
}

KimonoPluginFactory::KimonoPluginFactory()
	: qyotoAssembly(0), qyotoImage(0), qyotoInitialized(false)
{
}

KimonoPluginFactory::~KimonoPluginFactory()
{
}

void
KimonoPluginFactory::initQyotoRuntime()
{
	if (qyotoInitialized)
		return;

	// open the assembly 'qt-dotnet', look for Qyoto.SmokeInvocation.InitRuntime() and call it
	// it seems that there's now way to call static c'tors explicitly, hence the extra method
	qyotoAssembly = mono_domain_assembly_open(domain, "qt-dotnet");
	qyotoImage = mono_assembly_get_image(qyotoAssembly);
	MonoMethodDesc* desc = mono_method_desc_new("Qyoto.SmokeInvocation:InitRuntime()", true);
	MonoClass* klass = mono_class_from_name(qyotoImage, "Qyoto", "SmokeInvocation");
	MonoMethod* meth = mono_method_desc_search_in_class(desc, klass);
	mono_runtime_invoke(meth, NULL, NULL, NULL);
	
	qyotoInitialized = true;
}

QObject*
KimonoPluginFactory::create(const char *iface, QWidget *parentWidget,
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

	// initialize the JIT
	if (!domain) {
		domain = mono_jit_init((const char*) path.toLatin1());
// 		printf("(kimonopluginfactory.cpp:%d) new domain (ptr: %p)\n", __LINE__, domain);
		atexit(atexitfn);
	}
	
	MonoAssembly* assembly;
	if (assemblies.contains(path)) {
		assembly = assemblies[path];
	} else {
		assembly = mono_domain_assembly_open(domain, (const char*) path.toLatin1());
		if (!assembly) {
			kWarning() << "Couldn't open assembly" << path;
			return 0;
		}
		assemblies[path] = assembly;
	}

	MonoImage* image;
	if (images.contains(assembly)) {
		image = images[assembly];
	} else {
		image = mono_assembly_get_image(assembly);
		images[assembly] = image;
	}

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
	MonoObject* object = mono_object_new(domain, klass);
	
	if (!object) {
		kWarning() << "Failed to create instance of class" << nameSpace + "." + className;
		return 0;
	}
	
	objects << object;
	
	// initialize the Qyoto runtime
	initQyotoRuntime();
	
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
	guint32 handle = mono_gchandle_new(object, true);
	handles << handle;
	
	// return the newly created QObject
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)((void*) handle);
	if (o) {
		QObject* qobject = reinterpret_cast<QObject*>(o->ptr);
		qobject->setParent(parent);
		return qobject;
	} else
		return 0;
}
