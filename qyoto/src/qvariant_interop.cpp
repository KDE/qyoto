/***************************************************************************
                       qvariant_interop.cpp  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale <Richard_Dale@tipitina.demon.co.uk>
                           (C) 2009 by Arno Rehn <arno@arnorehn.de>
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#include "qyoto.h"
#include "callbacks.h"

#include <smoke/qtcore_smoke.h>

#include <QMetaType>
#include <QVariant>

extern "C" {

Q_DECL_EXPORT void *
QVariantValue(char * typeName, void * variant)
{
#ifdef DEBUG
    printf("ENTER QVariantValue(typeName: %s variant: 0x%8.8x)\n", typeName, variant);
#endif
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(variant);
    (*FreeGCHandle)(variant);
    QVariant *v = (QVariant*) o->ptr;
    int type = QMetaType::type(typeName);
    void *value = 0;
    if (v->canConvert((QVariant::Type) type)) {
        v->convert((QVariant::Type) type);
        value = QMetaType::construct(type, v->constData());
    } else {
        value = QMetaType::construct(type, 0);
    }

    if (qstrcmp(typeName, "QDBusVariant") == 0) {
        Smoke::ModuleIndex id = o->smoke->findClass("QVariant");
        smokeqyoto_object  * vo = alloc_smokeqyoto_object(true, id.smoke, id.index, value);
        return (*CreateInstance)("Qyoto.QDBusVariant", vo);
    }

    Smoke::ModuleIndex id = o->smoke->findClass(typeName);
    if (!id.smoke) return value;  // class not found in smoke, so it's probably just a GCHandle
    smokeqyoto_object  * vo = alloc_smokeqyoto_object(true, id.smoke, id.index, value);
    return (*CreateInstance)(qyoto_resolve_classname(vo), vo);
}

Q_DECL_EXPORT void *
QVariantFromValue(int type, void * value)
{
#ifdef DEBUG
    printf("ENTER QVariantFromValue(type: %d value: 0x%8.8x)\n", type, value);
#endif
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(value);
    if (o) (*FreeGCHandle)(value);
    QVariant * v = new QVariant(type, o? o->ptr : value);
    Smoke::ModuleIndex id = qtcore_Smoke->findClass("QVariant");
    smokeqyoto_object  * vo = alloc_smokeqyoto_object(true, id.smoke, id.index, (void *) v);
    return (*CreateInstance)("Qyoto.QVariant", vo);
}

}
