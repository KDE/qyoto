/***************************************************************************
                          qyoto.h  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale
    email                : Richard_Dale@tipitina.demon.co.uk
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#ifndef QYOTO_H
#define QYOTO_H

#include <qglobal.h>
#include <QHash>

#include "marshall.h"

class SmokeBinding;

struct MocArgument;

struct smokeqyoto_object {
    void *ptr;
    bool allocated;
    Smoke *smoke;
    int classId;
};

struct TypeHandler {
    const char *name;
    Marshall::HandlerFn fn;
};

typedef const char* (*resolveClassNameFn)(smokeqyoto_object * o);
typedef bool (*IsContainedInstanceFn)(smokeqyoto_object *o);

struct QyotoModule {
    const char *name;
    resolveClassNameFn resolve_classname;
    IsContainedInstanceFn IsContainedInstance;
    SmokeBinding* binding;
};

// keep this enum in sync with Qyoto.cs

enum QtDebugChannel {
    qtdb_none = 0x00,
    qtdb_ambiguous = 0x01,
    qtdb_transparent_proxy = 0x02,
    qtdb_calls = 0x04,
    qtdb_gc = 0x08,
    qtdb_virtual = 0x10,
    qtdb_verbose = 0x20
};

typedef void * GCHandle;

typedef void * (*NoArgs)();
typedef void * (*GetIntPtr)(void *);
typedef void (*SetIntPtr)(void *, void *);
typedef void (*FromIntPtr)(void *);
typedef void * (*GetIntPtrFromCharStar)(char *);
typedef void (*SetIntPtrFromCharStar)(void *, const char *);
typedef char* (*GetCharStarFromIntPtr)(void *);
typedef void (*MapPointerFn)(void *, void *, bool);
typedef void * (*OverridenMethodFn)(void *, const char *);
typedef void (*InvokeMethodFn)(void *, void *, void *);
typedef void * (*CreateListFn)(const char *);
typedef void * (*CreateInstanceFn)(const char *, void *);
typedef void * (*GetInstanceFn)(void *, bool);
typedef void (*InvokeCustomSlotFn)(void *, const char*, void *, void *);
typedef void (*AddInt)(void *, int);
typedef void (*AddUInt)(void *, uint);
typedef void (*AddIntObject)(void *, int, void *);
typedef void * (*DictToMap)(void *, int);
typedef void * (*DictToHash)(void *, int);
typedef void * (*ConstructDict)(const char*, const char*);
typedef void (*SetPropertyFn)(void *, const char*, void *);

extern Q_DECL_EXPORT QHash<Smoke*, QyotoModule> qyoto_modules;

extern Q_DECL_EXPORT int do_debug; // evil

extern Q_DECL_EXPORT Marshall::HandlerFn getMarshallFn(const SmokeType &type);

extern Q_DECL_EXPORT smokeqyoto_object* alloc_smokeqyoto_object(bool allocated, Smoke* smoke, int classId, void* ptr);

extern Q_DECL_EXPORT void free_smokeqyoto_object(smokeqyoto_object* o);

extern Q_DECL_EXPORT void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);
extern Q_DECL_EXPORT void unmapPointer(smokeqyoto_object *, Smoke::Index, void *);

extern Q_DECL_EXPORT bool IsContainedInstance(smokeqyoto_object *o);
extern Q_DECL_EXPORT const char* qyoto_resolve_classname(smokeqyoto_object * o);

extern Q_DECL_EXPORT void smokeStackToQtStack(Smoke::Stack stack, void ** o, int start, int end, QList<MocArgument*> args);
extern Q_DECL_EXPORT void smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int start, int end, QList<MocArgument*> args);

extern Q_DECL_EXPORT void qyoto_install_handlers(TypeHandler *h);

extern Q_DECL_EXPORT FromIntPtr FreeGCHandle;
extern Q_DECL_EXPORT CreateInstanceFn CreateInstance;
extern Q_DECL_EXPORT GetInstanceFn GetInstance;
extern Q_DECL_EXPORT GetIntPtr GetSmokeObject;

extern Q_DECL_EXPORT SetIntPtr SetSmokeObject;

extern Q_DECL_EXPORT SetIntPtr AddGlobalRef;
extern Q_DECL_EXPORT SetIntPtr RemoveGlobalRef;

extern Q_DECL_EXPORT MapPointerFn MapPointer;
extern Q_DECL_EXPORT FromIntPtr UnmapPointer;

extern Q_DECL_EXPORT OverridenMethodFn OverridenMethod;
extern Q_DECL_EXPORT InvokeMethodFn InvokeMethod;
extern Q_DECL_EXPORT InvokeCustomSlotFn InvokeCustomSlot;

extern Q_DECL_EXPORT OverridenMethodFn GetProperty;
extern Q_DECL_EXPORT SetPropertyFn SetProperty;

extern Q_DECL_EXPORT SetIntPtr InvokeDelegate;

extern "C" {
extern Q_DECL_EXPORT QMetaObject* parent_meta_object(void* obj);
extern Q_DECL_EXPORT QList<MocArgument*> GetMocArguments(Smoke* smoke, const char * typeName, QList<QByteArray> methodTypes);
extern Q_DECL_EXPORT bool application_terminated;

extern Q_DECL_EXPORT void SetDebug(int channel);
extern Q_DECL_EXPORT int DebugChannel();

extern Q_DECL_EXPORT void SetApplicationTerminated();
extern Q_DECL_EXPORT int qt_metacall(void* obj, int _c, int _id, void* _o);

extern GetIntPtr ListToPointerList;
extern CreateListFn ConstructList;
extern SetIntPtr AddIntPtrToList;

extern ConstructDict ConstructDictionary;
extern DictToHash DictionaryToQHash;
extern DictToMap DictionaryToQMap;
extern char *StringFromQString(void *ptr);
extern InvokeMethodFn AddObjectObjectToDictionary;

extern Q_DECL_EXPORT GetIntPtr IntPtrToCharStarStar;
extern Q_DECL_EXPORT GetCharStarFromIntPtr IntPtrToCharStar;
extern Q_DECL_EXPORT GetIntPtrFromCharStar IntPtrFromCharStar;
extern Q_DECL_EXPORT GetIntPtr IntPtrToQString;
extern Q_DECL_EXPORT GetIntPtr IntPtrFromQString;
extern Q_DECL_EXPORT GetIntPtr StringBuilderToQString;
extern Q_DECL_EXPORT SetIntPtrFromCharStar StringBuilderFromQString;
extern Q_DECL_EXPORT GetIntPtr StringListToQStringList;
extern Q_DECL_EXPORT GetIntPtr ListIntToQListInt;
extern Q_DECL_EXPORT GetIntPtr ListUIntToQListQRgb;
extern Q_DECL_EXPORT GetIntPtr ListWizardButtonToQListWizardButton;
extern Q_DECL_EXPORT AddInt AddIntToListInt;
extern Q_DECL_EXPORT AddUInt AddUIntToListUInt;
extern Q_DECL_EXPORT AddIntObject AddIntObjectToDictionary;
}

#endif
