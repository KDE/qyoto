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
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#ifndef QYOTO_H
#define QYOTO_H

#include <qglobal.h>
#include <QHash>

#include "marshall.h"

#ifdef QYOTOSHARED_BUILDING
	#define QYOTO_EXPORT Q_DECL_EXPORT
#else
	#define QYOTO_EXPORT Q_DECL_IMPORT
#endif

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
typedef void * (*CreateQPairFn)(void*, void*);

extern QYOTO_EXPORT QHash<Smoke*, QyotoModule> qyoto_modules;

extern QYOTO_EXPORT int do_debug; // evil

extern QYOTO_EXPORT Marshall::HandlerFn getMarshallFn(const SmokeType &type);

extern QYOTO_EXPORT smokeqyoto_object* alloc_smokeqyoto_object(bool allocated, Smoke* smoke, int classId, void* ptr);

extern QYOTO_EXPORT void free_smokeqyoto_object(smokeqyoto_object* o);

extern QYOTO_EXPORT void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);
extern QYOTO_EXPORT void unmapPointer(smokeqyoto_object *, Smoke::Index, void *);

extern QYOTO_EXPORT bool IsContainedInstance(smokeqyoto_object *o);
extern QYOTO_EXPORT const char* qyoto_resolve_classname(smokeqyoto_object * o);

extern QYOTO_EXPORT void smokeStackToQtStack(Smoke::Stack stack, void ** o, int start, int end, QList<MocArgument*> args);
extern QYOTO_EXPORT void smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int start, int end, QList<MocArgument*> args);

extern QYOTO_EXPORT void qyoto_install_handlers(TypeHandler *h);

extern QYOTO_EXPORT FromIntPtr FreeGCHandle;
extern QYOTO_EXPORT CreateInstanceFn CreateInstance;
extern QYOTO_EXPORT GetInstanceFn GetInstance;
extern QYOTO_EXPORT GetIntPtr GetSmokeObject;

extern QYOTO_EXPORT SetIntPtr SetSmokeObject;

extern QYOTO_EXPORT SetIntPtr AddGlobalRef;
extern QYOTO_EXPORT SetIntPtr RemoveGlobalRef;

extern QYOTO_EXPORT MapPointerFn MapPointer;
extern QYOTO_EXPORT FromIntPtr UnmapPointer;

extern QYOTO_EXPORT OverridenMethodFn OverridenMethod;
extern QYOTO_EXPORT InvokeMethodFn InvokeMethod;
extern QYOTO_EXPORT InvokeCustomSlotFn InvokeCustomSlot;

extern QYOTO_EXPORT OverridenMethodFn GetProperty;
extern QYOTO_EXPORT SetPropertyFn SetProperty;

extern QYOTO_EXPORT SetIntPtr InvokeDelegate;
extern QYOTO_EXPORT FromIntPtr TryDispose;

extern QYOTO_EXPORT QList<MocArgument*> GetMocArguments(Smoke* smoke, const char * typeName, QList<QByteArray> methodTypes);
extern QYOTO_EXPORT int qt_metacall(void* obj, int _c, int _id, void* _o);

extern "C" {
extern QYOTO_EXPORT QMetaObject* parent_meta_object(void* obj);
extern QYOTO_EXPORT bool application_terminated;

extern Q_DECL_EXPORT void SetDebug(int channel);
extern Q_DECL_EXPORT int DebugChannel();

extern Q_DECL_EXPORT void SetApplicationTerminated();

extern QYOTO_EXPORT GetIntPtr ListToPointerList;
extern QYOTO_EXPORT CreateListFn ConstructList;
extern QYOTO_EXPORT SetIntPtr AddIntPtrToList;

extern QYOTO_EXPORT ConstructDict ConstructDictionary;
extern QYOTO_EXPORT DictToHash DictionaryToQHash;
extern QYOTO_EXPORT DictToMap DictionaryToQMap;
extern QYOTO_EXPORT const ushort *StringFromQString(void *ptr);
extern QYOTO_EXPORT InvokeMethodFn AddObjectObjectToDictionary;

extern QYOTO_EXPORT GetIntPtr IntPtrToCharStarStar;
extern QYOTO_EXPORT GetCharStarFromIntPtr IntPtrToCharStar;
extern QYOTO_EXPORT GetIntPtrFromCharStar IntPtrFromCharStar;
extern QYOTO_EXPORT GetIntPtr IntPtrToQString;
extern QYOTO_EXPORT GetIntPtr IntPtrFromQString;
extern QYOTO_EXPORT GetIntPtr StringBuilderToQString;
extern QYOTO_EXPORT SetIntPtrFromCharStar StringBuilderFromQString;
extern QYOTO_EXPORT GetIntPtr StringListToQStringList;
extern QYOTO_EXPORT GetIntPtr ListIntToQListInt;
extern QYOTO_EXPORT GetIntPtr ListUIntToQListQRgb;
extern QYOTO_EXPORT GetIntPtr ListWizardButtonToQListWizardButton;
extern QYOTO_EXPORT AddInt AddIntToListInt;
extern QYOTO_EXPORT AddUInt AddUIntToListUInt;
extern QYOTO_EXPORT AddIntObject AddIntObjectToDictionary;

extern QYOTO_EXPORT GetIntPtr QPairGetFirst;
extern QYOTO_EXPORT GetIntPtr QPairGetSecond;
extern QYOTO_EXPORT CreateQPairFn CreateQPair;

extern QYOTO_EXPORT SetIntPtr UnboxToStackItem;
extern QYOTO_EXPORT CreateInstanceFn BoxFromStackItem;

extern QYOTO_EXPORT GetIntPtr GenericPointerGetIntPtr;
extern QYOTO_EXPORT CreateInstanceFn CreateGenericPointer;
}

#endif
