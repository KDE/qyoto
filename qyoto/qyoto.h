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

#include "marshall.h"

struct smokeqyoto_object {
    bool allocated;
    Smoke *smoke;
    int classId;
    void *ptr;
};

extern smokeqyoto_object * alloc_smokeqyoto_object(	bool allocated, 
													Smoke * smoke, 
													int classId, 
													void * ptr );

extern void free_smokeqyoto_object(smokeqyoto_object * o);

struct TypeHandler {
    const char *name;
    Marshall::HandlerFn fn;
};

extern int do_debug;   // evil

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

void unmapPointer(smokeqyoto_object *, Smoke::Index, void*);
smokeqyoto_object *value_obj_info(void * value);
void * getPointerObject(void *ptr);
bool IsInstanceContained(smokeqyoto_object *o);

typedef void* (*NoArgs)();
typedef void* (*GetIntPtr)(void *);
typedef void (*SetIntPtr)(void *, void *);
typedef void (*FromIntPtr)(void *);
typedef void* (*GetIntPtrFromCharStar)(char *);
typedef void (*SetIntPtrFromCharStar)(void*, const char *);
typedef char* (*GetCharStarFromIntPtr)(void *);
typedef void (*MapPointerFn)(void *, void *, bool);
typedef void* (*OverridenMethodFn)(void *, const char *);
typedef void (*InvokeMethodFn)(void *, void *, void *);
typedef void* (*CreateInstanceFn)(const char *);
typedef void (*InvokeCustomSlotFn)(void*, const char*, void*, void*);
typedef bool (*IsSmokeClassFn)(void*);
typedef void (*AddInt)(void*, int);
typedef void (*AddIntObject)(void*, int, void*);
typedef void* (*DictToMap)(void*, int);
typedef void* (*ConstructDict)(const char* type1, const char* type2);

extern FromIntPtr FreeGCHandle;

#endif
