/***************************************************************************
                       qobject_interop.cpp  -  description
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
#include "smokeqyoto.h"

#include "delegateinvocation.h"
#include "invokeslot.h"

#include <smoke/qtcore_smoke.h>

#include <stdio.h>

#include <QByteArray>
#include <QHash>
#include <QObject>
#include <QRegExp>

typedef QHash<QObject*, QHash<QByteArray, QHash<void*, DelegateInvocation*> > > QObjectDelegateMap;
Q_GLOBAL_STATIC(QObjectDelegateMap, delegateConnections)

extern "C" {

Q_DECL_EXPORT bool
ConnectDelegate(void* obj, const char* signal, void* delegate, void* handle)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    QObject *qobject = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
    (*FreeGCHandle)(obj);
    DelegateInvocation *invocation = new DelegateInvocation(qobject, signal, delegate, handle, o);
    if (invocation->isValid()) {
        (*delegateConnections())[qobject][signal][delegate] = invocation;
        return true;
    }
    return false;
}

Q_DECL_EXPORT bool
DisconnectDelegate(void* obj, const char* signal, void* delegate)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    QObject *qobject = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
    (*FreeGCHandle)(obj);
    QHash<void*, DelegateInvocation*> &connections = (*delegateConnections())[qobject][signal];
    if (connections.contains(delegate)) {
        delete connections[delegate];
        connections.remove(delegate);
        return true;
    }
    printf("DisconnectDelegate: %s::%s is not connected to delegate %p\n",
           qobject->metaObject()->className(), signal, delegate);
    return false;
}

/* Adapted from the internal function qt_qFindChildren() in qobject.cpp */
static void
cs_qFindChildren_helper(const QObject *parent, const QString &name, const QRegExp *re,
                         const QMetaObject &mo, QList<void*> *list)
{
    if (!parent || !list)
        return;

    const QObjectList &children = parent->children();
    QObject *obj;

    for (int i = 0; i < children.size(); ++i) {
        obj = children.at(i);
        if (mo.cast(obj)) {
            if (re) {
                if (re->indexIn(obj->objectName()) != -1)
                    list->append((*GetInstance)(obj, true));
            } else {
                if (name.isNull() || obj->objectName() == name)
                    list->append((*GetInstance)(obj, true));
            }
        }
        cs_qFindChildren_helper(obj, name, re, mo, list);
    }
}

/* Should mimic Qt4's QObject::findChildren method with this syntax:
     obj.findChildren(Qt::Widget, "Optional Widget Name")
*/
Q_DECL_EXPORT void
FindQObjectChildren(void* parent, const char *childClassName, void* childMetaObject, void* regexp, char* childName, FromIntPtr addFn)
{
    smokeqyoto_object *o;
    o = (smokeqyoto_object*) (*GetSmokeObject)(parent);
    QObject* p = (QObject*) o->ptr;

    QMetaObject *mo = 0;
    if (childMetaObject != 0) {
        o = (smokeqyoto_object*) (*GetSmokeObject)(childMetaObject);
        mo = (QMetaObject*) o->ptr;
        (*FreeGCHandle)(childMetaObject);
    } else {
        mo = get_meta_object(childClassName);
    }

    QRegExp* re = 0;
    if (regexp) {
        o = (smokeqyoto_object*) (*GetSmokeObject)(regexp);
        re = (QRegExp*) o->ptr;
        (*FreeGCHandle)(regexp);
    }

    QList<void*> *list = new QList<void*>();

    cs_qFindChildren_helper(p, QString::fromUtf8(childName), re, *mo, list);

    for(int i = 0; i < list->size(); ++i) {
        (*addFn)(list->at(i));
    }
    (*FreeGCHandle)(parent);
}

/* Adapted from the internal function qt_qFindChild() in qobject.cpp */
static void *
cs_qFindChild_helper(QObject* parent, const QString &name, const QMetaObject &mo)
{
    const QObjectList &children = parent->children();
    QObject* obj;
    void* monoObject;

    int i;
    for (i = 0; i < children.size(); ++i) {
        obj = children.at(i);
        if (mo.cast(obj) && (name.isNull() || obj->objectName() == name)) {
            monoObject = (*GetInstance)(obj, true);
            return monoObject;
        }
    }
    for (i = 0; i < children.size(); ++i) {
        monoObject = cs_qFindChild_helper(children.at(i), name, mo);
        if (monoObject)
            return monoObject;
    }
    return 0;
}

Q_DECL_EXPORT void *
FindQObjectChild(void* parent, const char* childClassName, void* childMetaObject, char * childName)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(parent);
    QObject *p = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject", true).index);
    (*FreeGCHandle)(parent);

    QMetaObject *mo = 0;
    if (childMetaObject != 0) {
        o = (smokeqyoto_object*) (*GetSmokeObject)(childMetaObject);
        mo = (QMetaObject*) o->ptr;
        (*FreeGCHandle)(childMetaObject);
    } else {
        mo = get_meta_object(childClassName);
    }

    return cs_qFindChild_helper(p, childName, *mo);
}

Q_DECL_EXPORT void*
qyoto_qt_metacast(void* obj, char* target)
{
    smokeqyoto_object* o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    (*FreeGCHandle)(obj);
    QObject* qobj = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
    void* ret = qobj->qt_metacast(target);
    if (!ret) return 0;
    void* instance = (*GetInstance)(ret, true);
    if (instance) {
#ifdef DEBUG
        printf("qyoto_qt_metacast: found instance, returning 0x%8.8x\n", instance);
#endif
        return instance;
    }
    Smoke::ModuleIndex mi = Smoke::classMap[target];
    smokeqyoto_object* to = alloc_smokeqyoto_object(false, mi.smoke, mi.index, ret);
    instance = (*CreateInstance)(qyoto_resolve_classname(to), to);
    mapPointer(instance, to, to->classId, 0);
#ifdef DEBUG
    printf("qyoto_qt_metacast: created new instance of type %s (%p)\n", target, to->ptr);
#endif
    return instance;
}

Q_DECL_EXPORT void*
qyoto_make_metaObject(const char* parentClassName, void* parentMeta, const char* stringdata, int stringdata_count,
                const uint* data, int data_count)
{
    QMetaObject* parent = 0;

    if (parentMeta == 0) {
        // The parent class is a Smoke class, so call metaObject() on the
        // instance to get it via a smoke library call
        parent = get_meta_object(parentClassName);
    } else {
        // The parent class is a custom C# class whose metaObject
        // was constructed at runtime
        smokeqyoto_object* o = (smokeqyoto_object*) (*GetSmokeObject)(parentMeta);
        parent = (QMetaObject *) o->ptr;
        (*FreeGCHandle)(parentMeta);
    }

    char* my_stringdata = new char[stringdata_count];
    memcpy(my_stringdata, stringdata, stringdata_count * sizeof(char));

    uint* my_data = new uint[data_count];
    memcpy(my_data, data, data_count * sizeof(uint));

    // create a QMetaObject on the stack
    QMetaObject tmp = {{
        parent,
        my_stringdata,
        my_data,
        0
    }};

    // copy it to the heap
    QMetaObject* meta = new QMetaObject;
    *meta = tmp;

#ifdef DEBUG
    printf("make_metaObject() superdata: %p %s\n", meta->d.superdata, parent->className());

    printf(
    " // content:\n"
    "       %d,       // revision\n"
    "       %d,       // classname\n"
    "       %d,   %d, // classinfo\n"
    "       %d,   %d, // methods\n"
    "       %d,   %d, // properties\n"
    "       %d,   %d, // enums/sets\n",
    data[0], data[1], data[2], data[3],
    data[4], data[5], data[6], data[7], data[8], data[9]);

    int s = data[3];

    if (data[2] > 0) {
        printf("\n // classinfo: key, value\n");
        for (uint j = 0; j < data[2]; j++) {
            printf("      %d,    %d\n", data[s + (j * 2)], data[s + (j * 2) + 1]);
        }
    }

    s = data[5];
    bool signal_headings = true;
    bool slot_headings = true;

    for (uint j = 0; j < data[4]; j++) {
        if (signal_headings && (data[s + (j * 5) + 4] & 0x04) != 0) {
            printf("\n // signals: signature, parameters, type, tag, flags\n");
            signal_headings = false;
        }

        if (slot_headings && (data[s + (j * 5) + 4] & 0x08) != 0) {
            printf("\n // slots: signature, parameters, type, tag, flags\n");
            slot_headings = false;
        }

        printf("      %d,   %d,   %d,   %d, 0x%2.2x\n",
            data[s + (j * 5)], data[s + (j * 5) + 1], data[s + (j * 5) + 2],
            data[s + (j * 5) + 3], data[s + (j * 5) + 4]);
    }

    s += (data[4] * 5);
    for (uint j = 0; j < data[6]; j++) {
        printf("\n // properties: name, type, flags\n");
        printf("      %d,   %d,   0x%8.8x\n",
            data[s + (j * 3)], data[s + (j * 3) + 1], data[s + (j * 3) + 2]);
    }

    s += (data[6] * 3);
    for (int i = s; i < data_count; i++) {
        printf("\n       %d        // eod\n", data[i]);
    }

    printf("\nqt_meta_stringdata:\n    \"");

    int strlength = 0;
    for (int j = 0; j < stringdata_count; j++) {
        strlength++;
        if (meta->d.stringdata[j] == 0) {
            printf("\\0");
            if (strlength > 40) {
                printf("\"\n    \"");
                strlength = 0;
            }
        } else {
            printf("%c", meta->d.stringdata[j]);
        }
    }
    printf("\"\n");
#endif

    // create smoke object
    smokeqyoto_object  * m = alloc_smokeqyoto_object(   true,
                                                        qtcore_Smoke,
                                                        qtcore_Smoke->idClass("QMetaObject").index,
                                                        meta );

    // create wrapper C# instance
    return (*CreateInstance)("Qyoto.QMetaObject", m);
}

}

int qyoto_qt_metacall(void* obj, int _c, int _id, void* _o) {
    smokeqyoto_object* o = (smokeqyoto_object*) (*GetSmokeObject)(obj);

    Smoke::ModuleIndex nameId = o->smoke->findMethodName(o->smoke->className(o->classId), "qt_metacall$$?");
    Smoke::ModuleIndex classId(o->smoke, o->classId);
    Smoke::ModuleIndex meth = nameId.smoke->findMethod(classId, nameId);
    if(meth.index > 0) {
        Smoke::Method &m = meth.smoke->methods[meth.smoke->methodMaps[meth.index].method];
        Smoke::ClassFn fn = meth.smoke->classes[m.classId].classFn;
        Smoke::StackItem i[4];
        i[1].s_enum = _c;
        i[2].s_int = _id;
        i[3].s_voidp = _o;
        (*fn)(m.method, o->ptr, i);

        int ret = i[0].s_int;
        if (ret < 0)
            return ret;
    } else {
        // Should never happen..
        qFatal("Cannot find %s::qt_metacall() method\n",
            o->smoke->classes[o->classId].className );
    }

    QObject *qobj = (QObject*)o->ptr;
    // get obj metaobject with a virtual call
    const QMetaObject *metaobject = qobj->metaObject();

    // get method/property count
    int count = 0;
    if (_c == QMetaObject::InvokeMetaMethod) {
        count = metaobject->methodCount();
    } else {
        count = metaobject->propertyCount();
    }

    if (_c == QMetaObject::InvokeMetaMethod) {
        // retrieve method signature from id
        QMetaMethod method = metaobject->method(_id);
        QString name(method.signature());
        QString type(method.typeName());

        if (method.methodType() == QMetaMethod::Signal) {
            metaobject->activate(qobj, _id, (void**) _o);
            return _id - count;
        }

        QList<MocArgument*> mocArgs = GetMocArguments(o->smoke, method.typeName(), method.parameterTypes());

        // invoke slot
        Qyoto::InvokeSlot slot(obj, method.signature(), mocArgs, (void**)_o);
        slot.next();
    } else if (_c == QMetaObject::ReadProperty) {
        QMetaProperty property = metaobject->property(_id);
        void* variant = (*GetProperty)(obj, property.name());
        smokeqyoto_object* sqo = (smokeqyoto_object*) (*GetSmokeObject)(variant);
        ((void**)_o)[0] = sqo->ptr;
    } else if (_c == QMetaObject::WriteProperty) {
        QMetaProperty property = metaobject->property(_id);
        smokeqyoto_object* sqo = alloc_smokeqyoto_object(false, qtcore_Smoke,
                                                         qtcore_Smoke->idClass("QVariant").index,
                                                         ((void**)_o)[0]);
        void* variant = (*CreateInstance)("Qyoto.QVariant", sqo);
        (*SetProperty)(obj, property.name(), variant);
    }
    return _id - count;
}
