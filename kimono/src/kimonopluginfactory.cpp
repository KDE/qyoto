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

#include <QCoreApplication>
#include <QObject>
#include <QString>
#include <QFileInfo>
#include <QDir>
#include <QVariant>

#include <KStandardDirs>
#include <KPluginFactory>
#include <KIO/SlaveBase>

#include <kde_file.h>
#include <kdebug.h>

#include <qyoto.h>
#include <callbacks.h>

#include <smoke.h>
#include <smoke/qtcore_smoke.h>
#include <smoke/qtgui_smoke.h>

#include <mono/jit/jit.h>
#include <mono/metadata/assembly.h>
#include <mono/metadata/debug-helpers.h>
#include <mono/metadata/mono-config.h>

#include <stdlib.h>
#include <stdio.h>

class QWidget;

class KimonoPluginFactory : public KPluginFactory
{
	Q_OBJECT
public:
	KimonoPluginFactory();
	virtual ~KimonoPluginFactory();
	
	void initQyotoRuntime();
	
	MonoDomain* initJit(const QString& path);
	MonoAssembly* getAssembly(const QString& path);
	MonoImage* getImage(MonoAssembly* assembly);
	MonoMethod* findMethod(MonoClass* klass, const QString& name);
	MonoObject* createInstance(MonoClass* klass);
	guint32 pinObject(MonoObject* obj);
	
	static QByteArray camelize(QByteArray name);
	static QList<const char*> assemblyGetClasses(const char* path);

protected:
	virtual QObject* create(const char *iface, QWidget *parentWidget,
	                        QObject *parent, const QVariantList &args,
	                        const QString &keyword);

private slots:
	void cleanup();

public:
	static MonoDomain* domain;

private:
	QHash<QString, MonoAssembly*> assemblies;
	QHash<MonoAssembly*, MonoImage*> images;
	
	MonoAssembly* qyotoAssembly;
	MonoImage* qyotoImage;
	MonoMethod* initRuntimeMethod;
	
	QList<MonoObject*> objects;
	QList<guint32> handles;
};
K_EXPORT_PLUGIN(KimonoPluginFactory)

MonoDomain* KimonoPluginFactory::domain;

KimonoPluginFactory::KimonoPluginFactory()
	: qyotoAssembly(0), qyotoImage(0), initRuntimeMethod(0)
{
	connect(QCoreApplication::instance(), SIGNAL(destroyed()), this, SLOT(cleanup()));
}

KimonoPluginFactory::~KimonoPluginFactory()
{
}

void
KimonoPluginFactory::cleanup()
{
// 	printf("(kimonopluginfactory.cpp:%d) calling mono_jit_cleanup(%p)\n", __LINE__, domain);
	mono_jit_cleanup(domain);
}

QByteArray
KimonoPluginFactory::camelize(QByteArray name)
{
    // Convert foo_bar_baz to FooBarBaz
    QByteArray camelCaseName = name.left(1).toUpper();
    for (int i = 1; i < name.size(); i++) {
        if (name[i] == '_' || name[i] == '-') {
            i++;
            if (i < name.size()) {
                 camelCaseName += name.mid(i, 1).toUpper();
            }
        } else {
             camelCaseName += name[i];
        }
    }

    return camelCaseName;
}

QList<const char*>
KimonoPluginFactory::assemblyGetClasses(const char* path)
{
	static MonoImage* corlib = mono_get_corlib();
	static MonoMethodDesc* assemblyLoadFromDesc = mono_method_desc_new("System.Reflection.Assembly:LoadFrom(string)", true);
	static MonoMethod* assemblyLoadFrom = mono_method_desc_search_in_image(assemblyLoadFromDesc, corlib);
	
	void* args[1];
	args[0] = mono_string_new(domain, path);
	MonoObject* assembly = mono_runtime_invoke(assemblyLoadFrom, NULL, args, NULL);
	
	static MonoMethodDesc* assemblyGetTypesDesc = mono_method_desc_new("System.Reflection.Assembly:GetTypes()", true);
	static MonoMethod* assemblyGetTypes = mono_method_desc_search_in_image(assemblyGetTypesDesc, corlib);
	
	MonoArray* types = (MonoArray*) mono_runtime_invoke(assemblyGetTypes, assembly, NULL, NULL);
	
	static MonoClass* type = mono_class_from_name(corlib, "System", "MonoType");
	static MonoProperty* typeFullName = mono_class_get_property_from_name(type, "FullName");
	
	QList<const char*> ret;
	for (unsigned int i = 0; i < mono_array_length(types); i++) {
		MonoObject* obj = mono_array_get(types, MonoObject*, i);
		ret << mono_string_to_utf8((MonoString*) mono_property_get_value(typeFullName, obj, NULL, NULL));
	}
	
	return ret;
}

void
KimonoPluginFactory::initQyotoRuntime()
{
	// open the assembly 'qt-dotnet', look for Qyoto.SmokeInvocation.InitRuntime() and call it
	// it seems that there's now way to call static c'tors explicitly, hence the extra method
	if (!initRuntimeMethod) {
		qyotoAssembly = mono_domain_assembly_open(domain, "qt-dotnet");
		qyotoImage = mono_assembly_get_image(qyotoAssembly);
		MonoMethodDesc* desc = mono_method_desc_new("Qyoto.SmokeInvocation:InitRuntime()", true);
		MonoClass* klass = mono_class_from_name(qyotoImage, "Qyoto", "SmokeInvocation");
		initRuntimeMethod = mono_method_desc_search_in_class(desc, klass);
	}
	mono_runtime_invoke(initRuntimeMethod, NULL, NULL, NULL);
}

MonoDomain*
KimonoPluginFactory::initJit(const QString& path)
{
	if (!domain) {
		if ((domain = mono_get_root_domain())) {
			kWarning() << "reusing existing MonoDomain" << domain;
			return domain;
		}
		// initialize the JIT
		domain = mono_jit_init((const char*) path.toLatin1());
		mono_config_parse(NULL);
// 		printf("(kimonopluginfactory.cpp:%d) new domain (ptr: %p)\n", __LINE__, domain);
	}
	return domain;
}

MonoAssembly*
KimonoPluginFactory::getAssembly(const QString& path)
{
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
	return assembly;
}

MonoImage*
KimonoPluginFactory::getImage(MonoAssembly* assembly)
{
	MonoImage* image;
	if (images.contains(assembly)) {
		image = images[assembly];
	} else {
		image = mono_assembly_get_image(assembly);
		images[assembly] = image;
	}
	return image;
}

MonoMethod*
KimonoPluginFactory::findMethod(MonoClass* klass, const QString& name)
{
	MonoMethod *m = 0; gpointer iter = 0;
	static QByteArray ba;
	while ((m = mono_class_get_methods(klass, &iter))) {
		ba.clear();
		ba += mono_method_get_name(m) + QByteArray("(");
		MonoMethodSignature *sig = mono_method_signature(m);
		MonoType *t = 0; gpointer iter2 = 0;
		bool first = true;
		while ((t = mono_signature_get_params(sig, &iter2))) {
			if (!first) ba += ",";
			ba += mono_type_get_name(t);
			first = false;
		}
		ba += ")";
		if (ba == name) return m;
	}
	return 0;
}

MonoObject*
KimonoPluginFactory::createInstance(MonoClass* klass)
{
	// create an instance of the class
	MonoObject* object = mono_object_new(domain, klass);
	if (!object) return 0;
	objects << object;
	return object;
}

guint32
KimonoPluginFactory::pinObject(MonoObject* obj)
{
	guint32 handle = mono_gchandle_new(obj, true);
	handles << handle;
	return handle;
}

QObject*
KimonoPluginFactory::create(const char *iface, QWidget *parentWidget,
	                       QObject *parent, const QVariantList &args,
	                       const QString &keyword)
{
	kWarning() << "KimonoPluginFactory::create() iface:" << iface << "keyword:" << keyword;

	// find the assembly
	QString path = KStandardDirs::locate("data", keyword);

	if (path.isEmpty()) {
		kWarning() << "Couldn't find" << keyword;
		return 0;
	}

	initJit(path);

	MonoAssembly* assembly = getAssembly(path);
	if (!assembly) return 0;
	
	MonoImage* image = getImage(assembly);
	if (!image) return 0;

	// a path in the form Foo/Bar.dll results in the class Bar in the namespace Foo
	QFileInfo file(path);
	QByteArray nameSpace = KimonoPluginFactory::camelize(QFile::encodeName(file.dir().dirName()));
	QByteArray className = KimonoPluginFactory::camelize(file.baseName().toLatin1());
	MonoClass* klass = mono_class_from_name(image, nameSpace, className);

	if (klass) kWarning() << "Found class" << nameSpace + "." + className;

	MonoMethod* ctor = 0;
	bool withParentWidget = false;
	if (klass) {
		// we want the Foo.Bar:.ctor(QObject, List<QVariant>)
		QByteArray methodName = nameSpace + "." + className + ":.ctor(Qyoto.QObject,System.Collections.Generic.List`1)";
		MonoMethodDesc* desc = mono_method_desc_new(methodName, true);
		ctor = mono_method_desc_search_in_class(desc, klass);
		if (!ctor) {
			methodName = nameSpace + "." + className + ":.ctor(Qyoto.QWidget,Qyoto.QObject,System.Collections.Generic.List`1)";
			desc = mono_method_desc_new(methodName, true);
			ctor = mono_method_desc_search_in_class(desc, klass);
			withParentWidget = true;
		}
	} else {
		Smoke::ModuleIndex mi = Smoke::classMap[iface];
		QString ifacestr;
		if (mi.smoke) {
			ifacestr = qyoto_modules[mi.smoke].binding->className(mi.index);
		} else {
			ifacestr = iface;
			if (ifacestr.contains("::")) {
				ifacestr.replace("::", ".");
			} else if (ifacestr.startsWith('Q')) {
				ifacestr.prepend('Q');
			} else if (ifacestr.startsWith('K')) {
				ifacestr.prepend('K');
			}
		}
		kWarning() << "searching for iface" << ifacestr;
		foreach(QByteArray name, assemblyGetClasses((const char*) path.toLatin1())) {
			nameSpace = name.left(name.lastIndexOf("."));
			className = name.right(name.size() - name.lastIndexOf(".") - 1);
			klass = mono_class_from_name(image, nameSpace, className);
			MonoClass* p = klass;
			kWarning() << "classname" << name << "p:" << p;
			do {
				if (ifacestr != mono_type_get_name(mono_class_get_type(p)))
					continue;
				ctor = findMethod(klass, ".ctor(Qyoto.QObject,System.Collections.Generic.List<Qyoto.QVariant>)");
				if (ctor) break;
				ctor = findMethod(klass, ".ctor(Qyoto.QWidget,Qyoto.QObject,System.Collections.Generic.List<Qyoto.QVariant>)");
				if (ctor) { withParentWidget = true; break; }
			} while ((p = mono_class_get_parent(p)));
			if (ctor) break;
		}
	}

	if (!ctor) {
		kWarning() << "Didn't find a matching constructor in the classes of the assembly";
		return 0;
	}
	
	MonoObject* object = createInstance(klass);
	if (!object) { 
		kWarning() << "Failed to create instance of class" << nameSpace + "." + className;
		return 0;
	}
	
	// initialize the Qyoto runtime
	initQyotoRuntime();
	
	void* pwobj = 0;
	if (parentWidget && withParentWidget) {
		// wrap the parent widget
		smokeqyoto_object* pwo = alloc_smokeqyoto_object(false, qtgui_Smoke, qtgui_Smoke->idClass("QWidget").index, parentWidget);
		pwobj = (*CreateInstance)("Qyoto.QWidget", pwo);
	}
	
	// wrap the parent QObject
	smokeqyoto_object* po = alloc_smokeqyoto_object(false, qtcore_Smoke, qtcore_Smoke->idClass("QObject").index, parent);
	void* pobj = (*CreateInstance)("Qyoto.QObject", po);
	
	// wrap the args in a List<QVariant> 
	void* list = (*ConstructList)("Qyoto.QVariant");
	foreach(QVariant v, args) {
		smokeqyoto_object* vo = alloc_smokeqyoto_object(true, qtcore_Smoke,
			qtcore_Smoke->idClass("QVariant").index, new QVariant(v));
		void* vobj = (*CreateInstance)("Qyoto.QVariant", vo);
		(*AddIntPtrToList)(list, vobj);
		(*FreeGCHandle)(vobj);
	}
	
	// set up the parameters and call the constructor
	void* a[ withParentWidget? 3 : 2 ];
	int id = 0;
	if (withParentWidget) {
		a[id] = mono_gchandle_get_target((guint32) (qint64) pwobj);
		id++;
	}
	a[id] = mono_gchandle_get_target((guint32) (qint64) pobj);
	id++;
	a[id] = mono_gchandle_get_target((guint32) (qint64) list);
	mono_runtime_invoke(ctor, object, a, NULL);
	if (pwobj) (*FreeGCHandle)(pwobj);
	(*FreeGCHandle)(pobj);
	(*FreeGCHandle)(list);
	
	// get a handle to the object and pin it, so it won't be collected
	guint32 handle = pinObject(object);
	
	// return the newly created QObject
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)((void*) handle);
	if (o) {
		QObject* qobject = reinterpret_cast<QObject*>(o->ptr);
		qobject->setParent(parent);
		return qobject;
	} else
		return 0;
}

extern "C" { Q_DECL_EXPORT int kdemain(int argc, char** argv); }

int kdemain(int argc, char** argv)
{
	if (argc != 4) {
		printf("USAGE: kimonopluginfactory protocol pool_sock app_sock");
		return -1;
	}

	KComponentData("kimonopluginfactory");

	KimonoPluginFactory factory;

	QByteArray protocol(argv[1]);
	QByteArray pool_sock(argv[2]);
	QByteArray app_sock(argv[3]);

	// find the assembly
	QString keyword("kio_");
	keyword.append(protocol);
	keyword.append("/main.dll");
	QString path = KStandardDirs::locate("data", keyword);

	if (path.isEmpty()) {
		kWarning() << "Couldn't find" << keyword;
		return -1;
	}

	factory.initJit(path);

	MonoAssembly* assembly = factory.getAssembly(path);
	if (!assembly) return -1;
	
	MonoImage* image = factory.getImage(assembly);
	if (!image) return -1;

	MonoMethod* ctor = 0;
	MonoClass* klass = 0;
	QByteArray iface("KIO.SlaveBase");
	QByteArray nameSpace, className;
	foreach(QByteArray name, factory.assemblyGetClasses((const char*) path.toLatin1())) {
		nameSpace = name.left(name.lastIndexOf("."));
		className = name.right(name.size() - name.lastIndexOf(".") - 1);
		klass = mono_class_from_name(image, nameSpace, className);
		MonoClass* p = klass;
		do {
			if (iface != mono_type_get_name(mono_class_get_type(p)))
				continue;
			QByteArray methodName = nameSpace + "." + className + ":.ctor(Qyoto.QByteArray,Qyoto.QByteArray,Qyoto.QByteArray)";
			MonoMethodDesc* desc = mono_method_desc_new(methodName, true);
			ctor = mono_method_desc_search_in_class(desc, klass);
			if (ctor) break;
		} while ((p = mono_class_get_parent(p)));
		if (ctor) break;
	}

	if (!ctor || !klass) {
		kWarning() << "FATAL: Didn't find a class implementing KIO.SlaveBase or with a matching constructor.";
		return -1;
	}

	MonoObject* object = factory.createInstance(klass);
	if (!object) { 
		kWarning() << "Failed to create instance of class" << nameSpace + "." + className;
		return -1;
	}

	factory.initQyotoRuntime();

	smokeqyoto_object* sqo_p = alloc_smokeqyoto_object(false, qtcore_Smoke, qtcore_Smoke->idClass("QByteArray").index, &protocol);
	void* p = (*CreateInstance)("Qyoto.QByteArray", sqo_p);
	
	smokeqyoto_object* sqo_ps = alloc_smokeqyoto_object(false, qtcore_Smoke, qtcore_Smoke->idClass("QByteArray").index, &pool_sock);
	void* ps = (*CreateInstance)("Qyoto.QByteArray", sqo_ps);
	
	smokeqyoto_object* sqo_as = alloc_smokeqyoto_object(false, qtcore_Smoke, qtcore_Smoke->idClass("QByteArray").index, &app_sock);
	void* as = (*CreateInstance)("Qyoto.QByteArray", sqo_as);
	
	void* a[3];
	a[0] = mono_gchandle_get_target((guint32) (qint64) p);
	a[1] = mono_gchandle_get_target((guint32) (qint64) ps);
	a[2] = mono_gchandle_get_target((guint32) (qint64) as);
#ifdef SIGXCPU
	void(*before)(int) = KDE_signal(SIGXCPU, SIG_IGN);
	KDE_signal(SIGXCPU, before);
#endif
	mono_runtime_invoke(ctor, object, a, NULL);
#ifdef SIGXCPU
	KDE_signal(SIGXCPU, before);
#endif
	(*FreeGCHandle)(p);
	(*FreeGCHandle)(ps);
	(*FreeGCHandle)(as);
	
	guint32 handle = factory.pinObject(object);
	
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)((void*) handle);
	if (o) {
		KIO::SlaveBase *slave = (KIO::SlaveBase*) o->ptr;
		slave->dispatchLoop();
		delete slave;
		return 0;
	} else
		return -1;
}

#include <kimonopluginfactory.moc>
