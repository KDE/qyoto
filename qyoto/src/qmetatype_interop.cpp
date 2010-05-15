/***************************************************************************
                       qmetatype_interop.cpp  -  description
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

#include <stdio.h>

#include <QByteArray>
#include <QMetaType>

extern "C" {

Q_DECL_EXPORT void
DestroyObject(const char *className, void *ptr)
{
    if (!ptr) return;
    QByteArray klassName(className);
    QByteArray dtor = "~" + klassName;
    QByteArray sig = dtor + "()";
    Smoke::ModuleIndex mi = FindMethodId(klassName.data(), dtor.data(), sig.data());
    if (!mi.smoke) {
        printf("can't destroy %p, missing method: %s\n", ptr, sig.constData());
        return;
    }
    const Smoke::Method &method = mi.smoke->methods[mi.index];
    const Smoke::Class &klass = mi.smoke->classes[method.classId];
    (*klass.classFn)(method.method, ptr, 0);
}

Q_DECL_EXPORT void*
CreateObject(char *className, void *other)
{
    QByteArray klassName(className);
    Smoke::ModuleIndex mi;
    Smoke::StackItem stack[2];

    if (other) {
        QByteArray ctor = klassName + "#";
        QByteArray signature = klassName + "(const " + klassName + "&)";
        mi = FindMethodId(className, ctor.data(), signature.data());
        if (!mi.smoke) {
            printf("can't create copy of %p, missing method: %s\n", other, signature.data());
            return 0;
        }
        stack[1].s_voidp = other;
    } else {
        QByteArray signature = klassName + "()";
        mi = FindMethodId(className, klassName.data(), signature.data());
        if (!mi.smoke) {
            printf("can't create object, missing method: %s\n", signature.data());
            return 0;
        }
    }

    const Smoke::Method &method = mi.smoke->methods[mi.index];
    const Smoke::Class &klass = mi.smoke->classes[method.classId];
    (*klass.classFn)(method.method, 0, stack);
    // set the binding
    stack[1].s_voidp = qyoto_modules[mi.smoke].binding;
    (*klass.classFn)(0, stack[0].s_voidp, stack);
    return stack[0].s_voidp;
}

Q_DECL_EXPORT int
QMetaTypeRegisterType(const char *name, QMetaType::Destructor destructor, QMetaType::Constructor constructor)
{
    return QMetaType::registerType(name, destructor, constructor);
}

}
