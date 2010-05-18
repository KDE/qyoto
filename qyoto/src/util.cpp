/***************************************************************************
                          util.cpp  -  description
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

#include "qyoto.h"
#include "qyoto_p.h"
#include "smokeqyoto.h"

#include <QRegExp>

#include <stdlib.h>
#include <stdio.h>

#include <smoke/qtcore_smoke.h>

#ifdef DEBUG
int do_debug = qtdb_gc;
#else
int do_debug = qtdb_none;
#endif

// modules
QHash<Smoke*, QyotoModule> qyoto_modules;
bool application_terminated = false;

extern "C" {

Q_DECL_EXPORT void
SetApplicationTerminated()
{
    application_terminated = true;
}

Q_DECL_EXPORT void
SetDebug(int channel)
{
    do_debug = channel;
}

Q_DECL_EXPORT int
DebugChannel()
{
    return do_debug;
}

}

const char *
qyoto_resolve_classname(smokeqyoto_object * o)
{
    if (o->smoke->isDerivedFrom(o->smoke->classes[o->classId].className, "QObject")) {
        QObject * qobject = (QObject *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
        const QMetaObject * meta = qobject->metaObject();

        while (meta != 0) {
            Smoke::ModuleIndex mi = Smoke::classMap[meta->className()];
            o->smoke = mi.smoke;
            o->classId = mi.index;
            if (o->smoke != 0) {
                if (o->classId != 0) {
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractItemModel") == 0)
                        return "Qyoto.QItemModel";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractButton") == 0)
                        return "Qyoto.QAbstractButtonInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractProxyModel") == 0)
                        return "Qyoto.QAbstractProxyModelInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractItemDelegate") == 0)
                        return "Qyoto.QAbstractItemDelegateInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractItemView") == 0)
                        return "Qyoto.QAbstractItemViewInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractListModel") == 0)
                        return "Qyoto.QAbstractListModelInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QAbstractTextDocumentLayout") == 0)
                        return "Qyoto.QAbstractTextDocumentLayoutInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QLayout") == 0)
                        return "Qyoto.QLayoutInternal";
                    if (strcmp(o->smoke->classes[o->classId].className, "QNetworkReply") == 0)
                        return "Qyoto.QNetworkReplyInternal";
                    return qyoto_modules[o->smoke].binding->className(o->classId);
                }
            }

            meta = meta->superClass();
        }
    }

    if (o->smoke->classes[o->classId].external) {
        Smoke::ModuleIndex mi = o->smoke->findClass(o->smoke->className(o->classId));
        o->smoke = mi.smoke;
        o->classId = mi.index;
        return qyoto_modules.value(mi.smoke).resolve_classname(o);
    }
    return qyoto_modules.value(o->smoke).resolve_classname(o);
}

bool
IsContainedInstance(smokeqyoto_object *o)
{
    QHash<Smoke*, QyotoModule>::const_iterator i;
    for (i = qyoto_modules.constBegin(); i != qyoto_modules.constEnd(); ++i) {
        if (i.value().IsContainedInstance(o))
            return true;
    }
    return false;
}

smokeqyoto_object *
alloc_smokeqyoto_object(bool allocated, Smoke * smoke, int classId, void * ptr)
{
    smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
    o->classId = classId;
    o->smoke = smoke;
    o->ptr = ptr;
    o->allocated = allocated;
    return o;
}

void
free_smokeqyoto_object(smokeqyoto_object * o)
{
    free(o);
    return;
}

// Store pointer in a Hashtable : "pointer_to_Qt_object" => weak ref to associated C# object
// Recurse to store it also as casted to its parent classes.
void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);

    if (ptr != lastptr) {
        lastptr = ptr;
        if (do_debug & qtdb_gc) {
            const char *className = o->smoke->classes[o->classId].className;
            printf( "mapPointer (%s*)%p -> %p global ref: %s\n",
                        className,
                        ptr,
                        (void*)obj,
                        IsContainedInstance(o) ? "true" : "false" );
            fflush(stdout);
        }
        (*MapPointer)(ptr, obj, IsContainedInstance(o));
    }

    for (Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents; *i; i++) {
        mapPointer(obj, o, *i, lastptr);
    }

    return;
}

void unmapPointer(smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);

    if (ptr != lastptr) {
        lastptr = ptr;
        (*UnmapPointer)(ptr);
    }

    for (Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents; *i; i++) {
        unmapPointer(o, *i, lastptr);
    }
}

QList<MocArgument*>
GetMocArguments(Smoke* smoke, const char * typeName, QList<QByteArray> methodTypes)
{
    static QRegExp rx("^(bool|int|uint|long|ulong|double|char\\*|QString)&?$");

    methodTypes.prepend(QByteArray(typeName));
    QList<MocArgument*> result;

    foreach (QByteArray name, methodTypes) {
        MocArgument *arg = new MocArgument;
        Smoke::Index typeId = 0;
        if (name.isEmpty() || name == "void") {
            arg->argType = xmoc_void;
            result.append(arg);
        } else {
            name.replace("const ", "");
            QString staticType = (rx.indexIn(name) != -1 ? rx.cap(1) : "ptr");
            if (staticType == "ptr") {
                arg->argType = xmoc_ptr;
                QByteArray targetType = name;
                typeId = smoke->idType(targetType.constData());
                if (typeId == 0 && !name.contains('*')) {
                    if (!name.contains("&")) {
                        targetType += "&";
                    }
                    typeId = smoke->idType(targetType.constData());

                    if (typeId == 0) {
                        targetType.prepend("const ");
                        typeId = smoke->idType(targetType.constData());
                    }
                }
            } else if (staticType == "bool") {
                arg->argType = xmoc_bool;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "int") {
                arg->argType = xmoc_int;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "uint") {
                arg->argType = xmoc_uint;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "long") {
                arg->argType = xmoc_long;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "ulong") {
                arg->argType = xmoc_ulong;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "double") {
                arg->argType = xmoc_double;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "char*") {
                arg->argType = xmoc_charstar;
                typeId = smoke->idType(name.constData());
            } else if (staticType == "QString") {
                arg->argType = xmoc_QString;
                name += "&";
                typeId = smoke->idType(name.constData());
                if (typeId == 0) {
                    name.prepend("const ");
                    typeId = smoke->idType(name.constData());
                }
            }

            if (typeId == 0) {
                qFatal("Cannot handle '%s' as slot argument", name.constData());
                return result;
            }

            arg->st.set(smoke, typeId);
            result.append(arg);
        }
    }

    return result;
}

QMetaObject* get_meta_object(const char* classname) {
    Smoke::ModuleIndex classId = Smoke::findClass(classname);
    Smoke::ModuleIndex nameId = classId.smoke->idMethodName("staticMetaObject");
    Smoke::ModuleIndex meth = classId.smoke->findMethod(classId, nameId);
    if (meth.index <= 0) {
        // Should never happen..
    }

    Smoke::Method &methodId = meth.smoke->methods[meth.smoke->methodMaps[meth.index].method];
    Smoke::ClassFn fn = meth.smoke->classes[methodId.classId].classFn;
    Smoke::StackItem i[1];
    (*fn)(methodId.method, 0, i);
    return (QMetaObject*) i[0].s_voidp;
}

static bool
matches_arg(Smoke *smoke, Smoke::Index meth, Smoke::Index argidx, const char *argtype)
{
    Smoke::Index *arg = smoke->argumentList + smoke->methods[meth].args + argidx;
    SmokeType type = SmokeType(smoke, *arg);
    return (type.name() && qstrcmp(type.name(), argtype) == 0);
}

void *
construct_copy(smokeqyoto_object *o)
{
    const char *className = o->smoke->className(o->classId);
    int classNameLen = strlen(className);

    // copy constructor signature
    QByteArray ccSig(className);
    int pos = ccSig.lastIndexOf("::");
    if (pos != -1) {
        ccSig = ccSig.mid(pos + strlen("::"));
    }
    ccSig.append("#");

    Smoke::ModuleIndex ccId = o->smoke->findMethodName(className, ccSig);

    char *ccArg = new char[classNameLen + 8];
    sprintf(ccArg, "const %s&", className);

    Smoke::ModuleIndex classId(o->smoke, o->classId);
    Smoke::ModuleIndex ccMeth = o->smoke->findMethod(classId, ccId);

    if(!ccMeth.index) {
    return 0;
    }
    Smoke::Index method = ccMeth.smoke->methodMaps[ccMeth.index].method;
    if(method > 0) {
    // Make sure it's a copy constructor
    if(!matches_arg(ccMeth.smoke, method, 0, ccArg)) {
            delete[] ccArg;
        return 0;
        }
        delete[] ccArg;
        ccMeth.index = method;
    } else {
        // ambiguous method, pick the copy constructor
    Smoke::Index i = -method;
    while(o->smoke->ambiguousMethodList[i]) {
        if(matches_arg(ccMeth.smoke, ccMeth.smoke->ambiguousMethodList[i], 0, ccArg))
        break;
            i++;
    }
        delete[] ccArg;
    ccMeth.index = ccMeth.smoke->ambiguousMethodList[i];
    if(!ccMeth.index)
        return 0;
    }

    // Okay, ccMeth is the copy constructor. Time to call it.
    Smoke::StackItem args[2];
    args[0].s_voidp = 0;
    args[1].s_voidp = o->ptr;
    Smoke::ClassFn fn = o->smoke->classes[o->classId].classFn;
    (*fn)(o->smoke->methods[ccMeth.index].method, 0, args);

    // Initialize the binding for the new instance
    Smoke::StackItem s[2];
    s[1].s_voidp = qyoto_modules[o->smoke].binding;
    (*fn)(0, args[0].s_voidp, s);

    return args[0].s_voidp;
}

void
smokeStackToQtStack(Smoke::Stack stack, void ** o, int start, int end, QList<MocArgument*> args)
{
    for (int i = start, j = 0; i < end; i++, j++) {
        Smoke::StackItem *si = stack + j;
        switch(args[i]->argType) {
        case xmoc_bool:
            o[j] = &si->s_bool;
            break;
        case xmoc_int:
            o[j] = &si->s_int;
            break;
        case xmoc_uint:
            o[j] = &si->s_uint;
            break;
        case xmoc_long:
            o[j] = &si->s_long;
            break;
        case xmoc_ulong:
            o[j] = &si->s_ulong;
            break;
        case xmoc_double:
            o[j] = &si->s_double;
            break;
        case xmoc_charstar:
            o[j] = &si->s_voidp;
            break;
        case xmoc_QString:
            o[j] = si->s_voidp;
            break;
        default:
        {
            const SmokeType &t = args[i]->st;
            void *p;
            switch(t.elem()) {
            case Smoke::t_bool:
                p = &si->s_bool;
                break;
            case Smoke::t_char:
                p = &si->s_char;
                break;
            case Smoke::t_uchar:
                p = &si->s_uchar;
                break;
            case Smoke::t_short:
                p = &si->s_short;
                break;
            case Smoke::t_ushort:
                p = &si->s_ushort;
                break;
            case Smoke::t_int:
                p = &si->s_int;
                break;
            case Smoke::t_uint:
                p = &si->s_uint;
                break;
            case Smoke::t_long:
                p = &si->s_long;
                break;
            case Smoke::t_ulong:
                p = &si->s_ulong;
                break;
            case Smoke::t_float:
                p = &si->s_float;
                break;
            case Smoke::t_double:
                p = &si->s_double;
                break;
            case Smoke::t_enum:
            {
                // allocate a new enum value
                Smoke::EnumFn fn = SmokeClass(t).enumFn();
                if (!fn) {
                    qWarning("Unknown enumeration %s\n", t.name());
                    p = new int((int)si->s_enum);
                    break;
                }
                Smoke::Index id = t.typeId();
                (*fn)(Smoke::EnumNew, id, p, si->s_enum);
                (*fn)(Smoke::EnumFromLong, id, p, si->s_enum);
                // FIXME: MEMORY LEAK
                break;
            }
            case Smoke::t_class:
            case Smoke::t_voidp:
                if (strchr(t.name(), '*') != 0) {
                    p = &si->s_voidp;
                } else {
                    p = si->s_voidp;
                }
                break;
            default:
                p = 0;
                break;
            }
            o[j] = p;
        }
        }
    }
}

void
smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int start, int end, QList<MocArgument*> args)
{
    for (int i = start, j = 0; i < end; i++, j++) {
        void *o = _o[j];
        switch(args[i]->argType) {
        case xmoc_bool:
            stack[j].s_bool = *(bool*)o;
            break;
        case xmoc_int:
            stack[j].s_int = *(int*)o;
            break;
        case xmoc_uint:
            stack[j].s_uint = *(uint*)o;
            break;
        case xmoc_long:
            stack[j].s_long = *(long*)o;
            break;
        case xmoc_ulong:
            stack[j].s_ulong = *(ulong*)o;
            break;
        case xmoc_double:
            stack[j].s_double = *(double*)o;
            break;
        case xmoc_charstar:
            stack[j].s_voidp = o;
            break;
        case xmoc_QString:
            stack[j].s_voidp = o;
            break;
        default:    // case xmoc_ptr:
        {
            const SmokeType &t = args[i]->st;
            switch(t.elem()) {
            case Smoke::t_bool:
            stack[j].s_bool = *(bool*)o;
            break;
            case Smoke::t_char:
            stack[j].s_char = *(char*)o;
            break;
            case Smoke::t_uchar:
            stack[j].s_uchar = *(unsigned char*)o;
            break;
            case Smoke::t_short:
            stack[j].s_short = *(short*)o;
            break;
            case Smoke::t_ushort:
            stack[j].s_ushort = *(unsigned short*)o;
            break;
            case Smoke::t_int:
            stack[j].s_int = *(int*)o;
            break;
            case Smoke::t_uint:
            stack[j].s_uint = *(unsigned int*)o;
            break;
            case Smoke::t_long:
            stack[j].s_long = *(long*)o;
            break;
            case Smoke::t_ulong:
            stack[j].s_ulong = *(unsigned long*)o;
            break;
            case Smoke::t_float:
            stack[j].s_float = *(float*)o;
            break;
            case Smoke::t_double:
            stack[j].s_double = *(double*)o;
            break;
            case Smoke::t_enum:
            {
                Smoke::EnumFn fn = SmokeClass(t).enumFn();
                if (!fn) {
                    qWarning("Unknown enumeration %s\n", t.name());
                    stack[j].s_enum = *(int*)o;
                    break;
                }
                Smoke::Index id = t.typeId();
                (*fn)(Smoke::EnumToLong, id, o, stack[j].s_enum);
            }
            break;
            case Smoke::t_class:
            case Smoke::t_voidp:
                if (strchr(t.name(), '*') != 0) {
                    stack[j].s_voidp = *(void **)o;
                } else {
                    stack[j].s_voidp = o;
                }
            break;
            }
        }
        }
    }
}
