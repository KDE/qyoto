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

void unmapPointer(smokeqyoto_object *, Smoke::Index, void *);
bool IsContainedInstance(smokeqyoto_object *o);

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
typedef void * (*ConstructDict)(const char*, const char*);
typedef void (*SetPropertyFn)(void *, const char*, void *);

extern FromIntPtr FreeGCHandle;
extern CreateInstanceFn CreateInstance;
extern GetInstanceFn GetInstance;
extern GetIntPtr GetSmokeObject;

extern "C" {
extern Q_DECL_EXPORT void InstallFreeGCHandle(FromIntPtr callback);
extern Q_DECL_EXPORT void InstallGetSmokeObject(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallSetSmokeObject(SetIntPtr callback);
extern Q_DECL_EXPORT void InstallMapPointer(MapPointerFn callback);
extern Q_DECL_EXPORT void InstallUnmapPointer(FromIntPtr callback);
extern Q_DECL_EXPORT void InstallGetInstance(GetInstanceFn callback);
extern Q_DECL_EXPORT void InstallOverridenMethod(OverridenMethodFn callback);
extern Q_DECL_EXPORT void InstallInvokeMethod(InvokeMethodFn callback);
extern Q_DECL_EXPORT void InstallCreateInstance(CreateInstanceFn callback);
extern Q_DECL_EXPORT void InstallInvokeCustomSlot(InvokeCustomSlotFn callback);
extern Q_DECL_EXPORT void InstallGetProperty(OverridenMethodFn callback);
extern Q_DECL_EXPORT void InstallSetProperty(SetPropertyFn callback);

extern Q_DECL_EXPORT void SetDebug(int channel);
extern Q_DECL_EXPORT int DebugChannel();
extern Q_DECL_EXPORT int FindMethodId(char * classname, char * mungedname, char * signature); 

extern Q_DECL_EXPORT void FindQObjectChildren(void * parent, void * regexp, char* childName, FromIntPtr addFn);
extern Q_DECL_EXPORT void * FindQObjectChild(void * parent, char * childName);

extern Q_DECL_EXPORT void * QVariantValue(char * typeName, void * variant);
extern Q_DECL_EXPORT void * QVariantFromValue(int type, void * value);

extern Q_DECL_EXPORT void * ModelIndexInternalPointer(void *obj);
extern Q_DECL_EXPORT void * AbstractItemModelCreateIndex(void * obj, int row, int column, void *ptr);
extern Q_DECL_EXPORT void * QAbstractItemModelParent(void * obj, void * modelIndex);
extern Q_DECL_EXPORT int QAbstractItemModelColumnCount(void * obj, void * modelIndex);
extern Q_DECL_EXPORT int QAbstractItemModelRowCount(void * obj, void * modelIndex);
extern Q_DECL_EXPORT void * QAbstractItemModelData(void * obj, void * modelIndex, int role);
extern Q_DECL_EXPORT void * QAbstractItemModelIndex(void * obj, int row, int column, void * modelIndex);
extern Q_DECL_EXPORT void * QAbstractProxyModelMapFromSource(void * obj, void * sourceIndex);
extern Q_DECL_EXPORT void * QAbstractProxyModelMapToSource(void * obj, void * proxyIndex);
extern Q_DECL_EXPORT void * QAbstractProxyModelMapToSource(void * obj, void * proxyIndex);
extern Q_DECL_EXPORT void * QAbstractProxyModelMapToSource(void * obj, void * proxyIndex);
extern Q_DECL_EXPORT void * QAbstractItemViewIndexAt(void * obj, void * point);
extern Q_DECL_EXPORT void QAbstractItemViewScrollTo(void * obj, void * index, int hint);
extern Q_DECL_EXPORT void * QAbstractItemViewVisualRect(void * obj, void * index);
extern Q_DECL_EXPORT void * QAbstractTextDocumentLayoutBlockBoundingRect(void * obj, void * block);
extern Q_DECL_EXPORT void * QAbstractTextDocumentLayoutDocumentSize(void * obj);
extern Q_DECL_EXPORT void * QAbstractTextDocumentLayoutFrameBoundingRect(void * obj, void * frame);
extern Q_DECL_EXPORT int QAbstractTextDocumentLayoutHitTest(void * obj, void * point, int accuracy);
extern Q_DECL_EXPORT int QAbstractTextDocumentLayoutPageCount(void * obj);

extern Q_DECL_EXPORT bool QyotoRegisterResourceData(int flag, const unsigned char * s, const unsigned char *n, const unsigned char *d);
extern Q_DECL_EXPORT bool QyotoUnregisterResourceData(int flag, const unsigned char * s, const unsigned char *n, const unsigned char *d);

extern Q_DECL_EXPORT void SetApplicationTerminated();
extern Q_DECL_EXPORT int QyotoHash(void * obj);
extern Q_DECL_EXPORT void CallSmokeMethod(int methodId, void * obj, Smoke::StackItem * sp, int items, bool refArgs);
extern Q_DECL_EXPORT bool SignalEmit(char * signature, char * type, void * obj, Smoke::StackItem * sp, int items);
extern Q_DECL_EXPORT void * make_metaObject(	void * obj, void * parentMeta, 
						const char* stringdata, int stringdata_count, 
						const uint* data, int data_count );
extern Q_DECL_EXPORT void Init_qyoto();

extern Q_DECL_EXPORT void InstallIntPtrToCharStarStar(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallIntPtrToCharStar(GetCharStarFromIntPtr callback);
extern Q_DECL_EXPORT void InstallIntPtrFromCharStar(GetIntPtrFromCharStar callback);
extern Q_DECL_EXPORT void InstallIntPtrToQString(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallIntPtrFromQString(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallStringBuilderToQString(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallStringBuilderFromQString(SetIntPtrFromCharStar callback);
extern Q_DECL_EXPORT void InstallStringListToQStringList(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallListToPointerList(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallListIntToQListInt(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallConstructList(CreateListFn callback);
extern Q_DECL_EXPORT void InstallAddIntPtrToList(SetIntPtr callback);
extern Q_DECL_EXPORT void InstallAddIntToListInt(AddInt callback);
extern Q_DECL_EXPORT void InstallConstructDictionary(ConstructDict callback);
extern Q_DECL_EXPORT void InstallAddObjectObjectToDictionary(InvokeMethodFn callback);
extern Q_DECL_EXPORT void InstallAddIntObjectToDictionary(AddIntObject callback);
extern Q_DECL_EXPORT void InstallDictionaryToQMap(DictToMap callback);
extern Q_DECL_EXPORT void InstallListUIntToQListQRgb(GetIntPtr callback);
extern Q_DECL_EXPORT void InstallAddUIntToListUInt(AddUInt callback);

extern Q_DECL_EXPORT void * ConstructPointerList();
extern Q_DECL_EXPORT void AddObjectToPointerList(void * ptr, void * obj);
extern Q_DECL_EXPORT void * ConstructQListInt();
extern Q_DECL_EXPORT void AddIntToQList(void * ptr, int i);
extern Q_DECL_EXPORT void * ConstructQMap(int type);
extern Q_DECL_EXPORT void AddIntQVariantToQMap(void * ptr, int i, void * qv);
extern Q_DECL_EXPORT void AddQStringQStringToQMap(void * ptr, char* str1, char* str2);
extern Q_DECL_EXPORT void AddQStringQVariantToQMap(void * ptr, char* str, void * qv);

extern Q_DECL_EXPORT void * StringArrayToCharStarStar(int length, char ** strArray);
extern Q_DECL_EXPORT void * StringToQString(char *str);
extern Q_DECL_EXPORT char * StringFromQString(void *ptr);
extern Q_DECL_EXPORT void * StringArrayToQStringList(int length, char ** strArray);

};

#endif
