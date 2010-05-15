/***************************************************************************
                   callbacks.cpp  -  callbacks into .NET/Mono
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

#include "callbacks.h"
#include "qyoto_p.h"

FromIntPtr FreeGCHandle;
CreateInstanceFn CreateInstance;
GetInstanceFn GetInstance;
GetIntPtr GetSmokeObject;

SetIntPtr SetSmokeObject;

SetIntPtr AddGlobalRef;
SetIntPtr RemoveGlobalRef;

MapPointerFn MapPointer;
FromIntPtr UnmapPointer;

OverridenMethodFn OverridenMethod;
InvokeMethodFn InvokeMethod;
InvokeCustomSlotFn InvokeCustomSlot;

OverridenMethodFn GetProperty;
SetPropertyFn SetProperty;

SetIntPtr InvokeDelegate;
FromIntPtr TryDispose;

GetIntPtr ListToPointerList;
CreateListFn ConstructList;
SetIntPtr AddIntPtrToList;
ConstructDict ConstructDictionary;
DictToMap DictionaryToQMap;
DictToHash DictionaryToQHash;
InvokeMethodFn AddObjectObjectToDictionary;

GetIntPtr IntPtrToCharStarStar;
GetCharStarFromIntPtr IntPtrToCharStar;
GetIntPtrFromCharStar IntPtrFromCharStar;
GetIntPtr IntPtrToQString;
GetIntPtr IntPtrFromQString;
GetIntPtr StringBuilderToQString;
SetIntPtrFromCharStar StringBuilderFromQString;
GetIntPtr StringListToQStringList;
GetIntPtr ListIntToQListInt;
GetIntPtr ListUIntToQListQRgb;
GetIntPtr ListWizardButtonToQListWizardButton;
AddInt AddIntToListInt;
AddUInt AddUIntToListUInt;
AddIntObject AddIntObjectToDictionary;

GetIntPtr QPairGetFirst;
GetIntPtr QPairGetSecond;
CreateQPairFn CreateQPair;

SetIntPtr UnboxToStackItem;
CreateInstanceFn BoxFromStackItem;

GetIntPtr GenericPointerGetIntPtr;
CreateInstanceFn CreateGenericPointer;

extern "C" {
Q_DECL_EXPORT void InstallIntPtrToCharStarStar(GetIntPtr callback)
{
    IntPtrToCharStarStar = callback;
}

Q_DECL_EXPORT void InstallIntPtrToCharStar(GetCharStarFromIntPtr callback)
{
    IntPtrToCharStar = callback;
}

Q_DECL_EXPORT void InstallIntPtrFromCharStar(GetIntPtrFromCharStar callback)
{
    IntPtrFromCharStar = callback;
}

Q_DECL_EXPORT void InstallIntPtrToQString(GetIntPtr callback)
{
    IntPtrToQString = callback;
}

Q_DECL_EXPORT void InstallIntPtrFromQString(GetIntPtr callback)
{
    IntPtrFromQString = callback;
}

Q_DECL_EXPORT void InstallStringBuilderToQString(GetIntPtr callback)
{
    StringBuilderToQString = callback;
}

Q_DECL_EXPORT void InstallStringBuilderFromQString(SetIntPtrFromCharStar callback)
{
    StringBuilderFromQString = callback;
}

Q_DECL_EXPORT void InstallStringListToQStringList(GetIntPtr callback)
{
    StringListToQStringList = callback;
}

Q_DECL_EXPORT void InstallListToPointerList(GetIntPtr callback)
{
    ListToPointerList = callback;
}

Q_DECL_EXPORT void InstallListIntToQListInt(GetIntPtr callback)
{
    ListIntToQListInt = callback;
}

Q_DECL_EXPORT void InstallConstructList(CreateListFn callback)
{
    ConstructList = callback;
}

Q_DECL_EXPORT void InstallAddIntPtrToList(SetIntPtr callback)
{
    AddIntPtrToList = callback;
}

Q_DECL_EXPORT void InstallAddIntToListInt(AddInt callback)
{
    AddIntToListInt = callback;
}

Q_DECL_EXPORT void InstallConstructDictionary(ConstructDict callback)
{
    ConstructDictionary = callback;
}

Q_DECL_EXPORT void InstallAddObjectObjectToDictionary(InvokeMethodFn callback)
{
    AddObjectObjectToDictionary = callback;
}

Q_DECL_EXPORT void InstallAddIntObjectToDictionary(AddIntObject callback)
{
    AddIntObjectToDictionary = callback;
}

Q_DECL_EXPORT void InstallDictionaryToQHash(DictToHash callback)
{
    DictionaryToQHash = callback;
}

Q_DECL_EXPORT void InstallDictionaryToQMap(DictToMap callback)
{
    DictionaryToQMap = callback;
}

Q_DECL_EXPORT void InstallListUIntToQListQRgb(GetIntPtr callback)
{
    ListUIntToQListQRgb = callback;
}

Q_DECL_EXPORT void InstallAddUIntToListUInt(AddUInt callback)
{
    AddUIntToListUInt = callback;
}

Q_DECL_EXPORT void InstallListWizardButtonToQListWizardButton(GetIntPtr callback)
{
    ListWizardButtonToQListWizardButton = callback;
}

Q_DECL_EXPORT void InstallGenericPointerGetIntPtr(GetIntPtr callback)
{
    GenericPointerGetIntPtr = callback;
}

Q_DECL_EXPORT void InstallCreateGenericPointer(CreateInstanceFn callback)
{
    CreateGenericPointer = callback;
}

Q_DECL_EXPORT void InstallQPairGetFirst(GetIntPtr callback)
{
    QPairGetFirst = callback;
}

Q_DECL_EXPORT void InstallQPairGetSecond(GetIntPtr callback)
{
    QPairGetSecond = callback;
}

Q_DECL_EXPORT void InstallCreateQPair(CreateQPairFn callback)
{
    CreateQPair = callback;
}

Q_DECL_EXPORT void InstallUnboxToStackItem(SetIntPtr callback)
{
    UnboxToStackItem = callback;
}

Q_DECL_EXPORT void InstallBoxFromStackItem (CreateInstanceFn callback)
{
    BoxFromStackItem = callback;
}

Q_DECL_EXPORT void
InstallTryDispose(FromIntPtr callback)
{
    TryDispose = callback;
}

Q_DECL_EXPORT void
InstallInvokeDelegate(SetIntPtr callback)
{
    InvokeDelegate = callback;
}

Q_DECL_EXPORT void
InstallFreeGCHandle(FromIntPtr callback)
{
    FreeGCHandle = callback;
}

Q_DECL_EXPORT void
InstallGetSmokeObject(GetIntPtr callback)
{
    GetSmokeObject = callback;
}

Q_DECL_EXPORT void
InstallSetSmokeObject(SetIntPtr callback)
{
    SetSmokeObject = callback;
}

Q_DECL_EXPORT void
InstallAddGlobalRef(SetIntPtr callback)
{
    AddGlobalRef = callback;
}

Q_DECL_EXPORT void
InstallRemoveGlobalRef(SetIntPtr callback)
{
    RemoveGlobalRef = callback;
}

Q_DECL_EXPORT void
InstallMapPointer(MapPointerFn callback)
{
    MapPointer = callback;
}

Q_DECL_EXPORT void
InstallUnmapPointer(FromIntPtr callback)
{
    UnmapPointer = callback;
}

Q_DECL_EXPORT void
InstallGetInstance(GetInstanceFn callback)
{
    GetInstance = callback;
}

Q_DECL_EXPORT void
InstallOverridenMethod(OverridenMethodFn callback)
{
    OverridenMethod = callback;
}

Q_DECL_EXPORT void
InstallInvokeMethod(InvokeMethodFn callback)
{
    InvokeMethod = callback;
}

Q_DECL_EXPORT void
InstallCreateInstance(CreateInstanceFn callback)
{
    CreateInstance = callback;
}

Q_DECL_EXPORT void
InstallInvokeCustomSlot(InvokeCustomSlotFn callback)
{
    InvokeCustomSlot = callback;
}

Q_DECL_EXPORT void
InstallGetProperty(OverridenMethodFn callback)
{
    GetProperty = callback;
}

Q_DECL_EXPORT void
InstallSetProperty(SetPropertyFn callback)
{
    SetProperty = callback;
}

}
