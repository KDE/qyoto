/***************************************************************************
                          callbacks.h  -  description
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

#ifndef CALLBACKS_H
#define CALLBACKS_H

#include "qyoto.h"

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

extern QYOTO_EXPORT FromIntPtr FreeGCHandle;
extern QYOTO_EXPORT CreateInstanceFn CreateInstance;
extern QYOTO_EXPORT GetInstanceFn GetInstance;
extern QYOTO_EXPORT GetIntPtr GetSmokeObject;

extern QYOTO_EXPORT SetIntPtr SetSmokeObject;

extern QYOTO_EXPORT SetIntPtr AddGlobalRef;
extern QYOTO_EXPORT SetIntPtr RemoveGlobalRef;

extern QYOTO_EXPORT OverridenMethodFn OverridenMethod;
extern QYOTO_EXPORT InvokeMethodFn InvokeMethod;
extern QYOTO_EXPORT InvokeCustomSlotFn InvokeCustomSlot;

extern QYOTO_EXPORT OverridenMethodFn GetProperty;
extern QYOTO_EXPORT SetPropertyFn SetProperty;

extern QYOTO_EXPORT SetIntPtr InvokeDelegate;
extern QYOTO_EXPORT FromIntPtr TryDispose;

extern QYOTO_EXPORT GetIntPtr IntPtrToCharStarStar;
extern QYOTO_EXPORT GetCharStarFromIntPtr IntPtrToCharStar;
extern QYOTO_EXPORT GetIntPtrFromCharStar IntPtrFromCharStar;
extern QYOTO_EXPORT const ushort *StringFromQString(QString* str);
extern QYOTO_EXPORT QString *StringFromQString(const ushort *str);
extern QYOTO_EXPORT GetIntPtr IntPtrToQString;
extern QYOTO_EXPORT GetIntPtr IntPtrFromQString;
extern QYOTO_EXPORT GetIntPtr StringBuilderToQString;
extern QYOTO_EXPORT SetIntPtrFromCharStar StringBuilderFromQString;
extern QYOTO_EXPORT GetIntPtr StringListToQStringList;

extern QYOTO_EXPORT GetIntPtr ListToPointerList;
extern QYOTO_EXPORT CreateListFn ConstructList;
extern QYOTO_EXPORT SetIntPtr AddIntPtrToList;

extern QYOTO_EXPORT ConstructDict ConstructDictionary;
extern QYOTO_EXPORT DictToHash DictionaryToQHash;
extern QYOTO_EXPORT DictToMap DictionaryToQMap;
extern QYOTO_EXPORT InvokeMethodFn AddObjectObjectToDictionary;

extern QYOTO_EXPORT GetIntPtr QPairGetFirst;
extern QYOTO_EXPORT GetIntPtr QPairGetSecond;
extern QYOTO_EXPORT CreateQPairFn CreateQPair;

extern QYOTO_EXPORT SetIntPtr UnboxToStackItem;
extern QYOTO_EXPORT CreateInstanceFn BoxFromStackItem;

extern QYOTO_EXPORT GetIntPtr GenericPointerGetIntPtr;
extern QYOTO_EXPORT CreateInstanceFn CreateGenericPointer;

#endif
