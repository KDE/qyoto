/***************************************************************************
                        kimono.cpp  -  description
                             -------------------
    begin                : Mon Sep 10 2007
    copyright            : (C) 2007 by Arno Rehn
    email                : arno@arnorehn.de
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#ifndef _GNU_SOURCE
#define _GNU_SOURCE
#endif

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <smoke/qtcore_smoke.h>
#include <smoke/kdecore_smoke.h>
#include <smoke/kdeui_smoke.h>
#include <smoke/kparts_smoke.h>
#include <smoke/kio_smoke.h>
#include <smoke/knewstuff2_smoke.h>
#include <smoke/knewstuff3_smoke.h>
#include <smoke/kfile_smoke.h>
#include <smoke/kutils_smoke.h>

#include <QMimeData>
#include <QStringList>

#include <KPluginFactory>
#include <KUrl>

const char *
resolve_classname_KDE(smokeqyoto_object * o)
{
	if (Smoke::isDerivedFrom(o->smoke->classes[o->classId].className, "QObject")) {
		if (strcmp(o->smoke->classes[o->classId].className, "KParts::ReadOnlyPart") == 0)
			return "KParts.ReadOnlyPartInternal";
		if (strcmp(o->smoke->classes[o->classId].className, "KParts::ReadWritePart") == 0)
			return "KParts.ReadWritePartInternal";
	}
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceKDE(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler KDE_handlers[];

extern "C" {

typedef bool (*GetNextDictionaryEntryFn)(void** key, void** value);

Q_DECL_EXPORT void
KUrlListPopulateMimeData(NoArgs getNextItem, void* mimeData,
	GetNextDictionaryEntryFn getNextDictionaryEntry, uint flags)
{
	QMimeData* md = (QMimeData*) ((smokeqyoto_object*) (*GetSmokeObject)(mimeData))->ptr;
	(*FreeGCHandle)(mimeData);
	KUrl::List list;
	for (void* handle = (*getNextItem)(); handle; handle = (*getNextItem)()) {
		list.append(*(KUrl*) ((smokeqyoto_object*) (*GetSmokeObject)(mimeData))->ptr);
		(*FreeGCHandle)(handle);
	}
	QMap<QString, QString> map;
	for (void *key = 0, *value = 0; getNextDictionaryEntry(&key, &value); ) {
		QString k = QString::fromUtf8((char*) (*IntPtrToCharStar)(key));
		QString v = QString::fromUtf8((char*) (*IntPtrToCharStar)(value));
		map.insert(k, v);
		(*FreeGCHandle)(key);
		(*FreeGCHandle)(value);
	}
	list.populateMimeData(md, map, (KUrl::MimeDataFlags) flags);
}

Q_DECL_EXPORT void
KUrlListMimeDataTypes(FromIntPtr addfn)
{
	foreach(QString str, KUrl::List::mimeDataTypes())
		(*addfn)((*IntPtrFromQString)(&str));
}

Q_DECL_EXPORT bool
KUrlListCanDecode(void* mimeData)
{
	QMimeData* md = (QMimeData*) ((smokeqyoto_object*) (*GetSmokeObject)(mimeData))->ptr;
	(*FreeGCHandle)(mimeData);
	return KUrl::List::canDecode(md);
}

Q_DECL_EXPORT void
KUrlListFromMimeData(FromIntPtr addfn, void* mimeData, GetNextDictionaryEntryFn getNextDictionaryEntry)
{
	QMimeData* md = (QMimeData*) ((smokeqyoto_object*) (*GetSmokeObject)(mimeData))->ptr;
	(*FreeGCHandle)(mimeData);
	QMap<QString, QString> map;
	for (void *key = 0, *value = 0; getNextDictionaryEntry(&key, &value); ) {
		QString k = QString::fromUtf8((char*) (*IntPtrToCharStar)(key));
		QString v = QString::fromUtf8((char*) (*IntPtrToCharStar)(value));
		map.insert(k, v);
		(*FreeGCHandle)(key);
		(*FreeGCHandle)(value);
	}
	Smoke::Index id = kdecore_Smoke->idClass("KUrl").index;
	foreach(KUrl url, KUrl::List::fromMimeData(md, (map.size() > 0)? &map : 0)) {
		smokeqyoto_object *o = alloc_smokeqyoto_object(true, kdecore_Smoke, id, new KUrl(url));
		(*addfn)((*CreateInstance)("Kimono.KUrl", o));
	}
}

class KPluginFactory_Create_Caller : public KPluginFactory
{
public:
	QObject *call_create(const char *iface, QWidget *parentWidget,
	                     QObject *parent, const QVariantList &args,
	                     const QString &keyword)
	{
		return create(iface, parentWidget, parent, args, keyword);
	}
};

Q_DECL_EXPORT void*
KPluginFactory_Create(void *self, const char *classname, void *parentWidget, void *parent, void **args, int numArgs, const char *keyword)
{
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(self);
	(*FreeGCHandle)(self);
	KPluginFactory_Create_Caller *factory = (KPluginFactory_Create_Caller*) o->ptr;
	
	QWidget *pw = 0;
	if (parentWidget) {
		o = (smokeqyoto_object*) (*GetSmokeObject)(parentWidget);
		(*FreeGCHandle)(parentWidget);
		pw = (QWidget*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QWidget").index);
	}
	
	QObject *p = 0;
	if (parent) {
		o = (smokeqyoto_object*) (*GetSmokeObject)(parent);
		(*FreeGCHandle)(parent);
		p = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
	}
	
	QVariantList list;
	for (int i = 0; i < numArgs; i++) {
		o = (smokeqyoto_object*) (*GetSmokeObject)(args[i]);
		(*FreeGCHandle)(args[i]);
		list << *((QVariant*) o->ptr);
	}
	
	QObject *ret = factory->call_create(classname, pw, p, list, keyword);
	smokeqyoto_object *obj = alloc_smokeqyoto_object(false, qtcore_Smoke, qtcore_Smoke->idClass("QObject").index, ret);
	const char *name = qyoto_resolve_classname(obj);
	return (*CreateInstance)(name, obj);
}

#define INIT_BINDING(module) \
    static QHash<int,char *> module##_classname; \
    for (int i = 1; i <= module##_Smoke->numClasses; i++) { \
        QByteArray name(module##_Smoke->classes[i].className); \
        name.replace("::", "."); \
        if (    !name.startsWith("KParts") \
                && !name.startsWith("Sonnet") \
                && !name.startsWith("KIO") \
                && !name.startsWith("KWallet") \
                && !name.startsWith("KNS") ) \
        { \
            name = prefix + name; \
        } \
        module##_classname.insert(i, strdup(name.constData())); \
    } \
    static Qyoto::Binding module##_binding = Qyoto::Binding(module##_Smoke, &module##_classname); \
    QyotoModule module = { "Kimono_" #module, resolve_classname_KDE, IsContainedInstanceKDE, &module##_binding }; \
    qyoto_modules[module##_Smoke] = module;

Q_DECL_EXPORT void
Init_kimono()
{
	init_kdecore_Smoke();
	init_kdeui_Smoke();
	init_kparts_Smoke();
	init_kio_Smoke();
	init_knewstuff2_Smoke();
	init_knewstuff3_Smoke();
	init_kfile_Smoke();
	init_kutils_Smoke();
	
	QByteArray prefix("Kimono.");
	
    INIT_BINDING(kdecore)
    INIT_BINDING(kdeui)
    INIT_BINDING(kparts)
    INIT_BINDING(kio)
    INIT_BINDING(knewstuff2)
    INIT_BINDING(knewstuff3)
    INIT_BINDING(kfile)
    INIT_BINDING(kutils)

    qyoto_install_handlers(KDE_handlers);
}

}
