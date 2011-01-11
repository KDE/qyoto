#ifndef QYOTO_P_H
#define QYOTO_P_H

#include "callbacks.h"

extern int qyoto_qt_metacall(void* obj, int _c, int _id, void* _o);

// private callbacks - the public API exposes them as mapPointer() and unmapPointer()
extern MapPointerFn MapPointer;
extern FromIntPtr UnmapPointer;

extern GetIntPtr ListIntToQListInt;
extern GetIntPtr ListUIntToQListQRgb;
extern GetIntPtr ListWizardButtonToQListWizardButton;
extern AddInt AddIntToListInt;
extern AddUInt AddUIntToListUInt;
extern AddIntObject AddIntObjectToDictionary;

#endif
