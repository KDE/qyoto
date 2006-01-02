/***************************************************************************
                          qyoto.cpp  -  description
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

#ifndef _GNU_SOURCE
#define _GNU_SOURCE
#endif
#include <stdio.h>

#include <qstring.h>
#include <qptrdict.h>
#include <qintdict.h>
#include <qregexp.h>
#include <qstrlist.h>
#include <qmetaobject.h>
#include <private/qucomextra_p.h>
#include <qsignalslotimp.h>

#undef DEBUG
#ifndef __USE_POSIX
#define __USE_POSIX
#endif
#ifndef __USE_XOPEN
#define __USE_XOPEN
#endif
#ifdef _BOOL
#define HAS_BOOL
#endif                                                          

#ifndef QT_VERSION_STR
#define QT_VERSION_STR "Unknown"
#endif

#include "marshall.h"
#include "qyoto.h"
#include "smokeqyoto.h"
#include "smoke.h"

#define QYOTO_VERSION "0.0.1"

extern Smoke *qt_Smoke;
extern void init_qt_Smoke();

#ifdef DEBUG
int do_debug = qtdb_gc;
#else
int do_debug = qtdb_none;
#endif

static GetIntPtr GetSmokeObject;
static SetIntPtr SetSmokeObject;

static SetIntPtr MapPointer;
static RemoveIntPtr UnmapPointer;
static GetIntPtr GetPointerObject;

// Maps from a classname in the form Qt::Widget to an int id
QIntDict<char> classname(2179);

extern "C" {
extern void * set_obj_info(const char * className, smokeqyoto_object * o);
};

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);

extern TypeHandler Qt_handlers[];
void install_handlers(TypeHandler *);

smokeqyoto_object *value_obj_info(void * qyoto_value) {  // ptr on success, null on fail
    smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(qyoto_value);
    return o;
}

bool isDerivedFrom(Smoke *smoke, Smoke::Index classId, Smoke::Index baseId) {
    if(classId == baseId)
	return true;
    for(Smoke::Index *p = smoke->inheritanceList + smoke->classes[classId].parents;
	*p;
	p++) {
	if(isDerivedFrom(smoke, *p, baseId))
	    return true;
    }
    return false;
}

bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName) {
    if(!smoke || !className || !baseClassName)
	return false;
    Smoke::Index idClass = smoke->idClass(className);
    Smoke::Index idBase = smoke->idClass(baseClassName);
    return isDerivedFrom(smoke, idClass, idBase);
}

void * getPointerObject(void *ptr) {
	return (*GetPointerObject)(ptr);
}

void unmapPointer(smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);
    if(ptr != lastptr) {
	lastptr = ptr;
	if (getPointerObject(ptr) != 0) {
		void * obj_ptr = getPointerObject(ptr);
		
		if (do_debug & qtdb_gc) {
			const char *className = o->smoke->classes[o->classId].className;
			printf("unmapPointer (%s*)%p -> %p", className, ptr, obj_ptr);
		}
	    
		(*UnmapPointer)(ptr);
	}
    }
    for(Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents;
	*i;
	i++) {
	unmapPointer(o, *i, lastptr);
    }
}

// Store pointer in a Hashtable : "pointer_to_Qt_object" => weak ref to associated C# object
// Recurse to store it also as casted to its parent classes.

void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);
	
    if (ptr != lastptr) {
		lastptr = ptr;
		if (do_debug & qtdb_gc) {
			const char *className = o->smoke->classes[o->classId].className;
			printf("mapPointer (%s*)%p -> %p", className, ptr, (void*)obj);
		}
		(*MapPointer)(ptr, obj);
    }
	
    for(Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents;
	*i;
	i++) {
	mapPointer(obj, o, *i, lastptr);
    }
	
	return;
}

void *
set_obj_info(const char * className, smokeqyoto_object * o)
{
//    VALUE klass = rb_funcall(qt_internal_module,
//			     rb_intern("find_class"),
//			     1,
//			     rb_str_new2(className) );
//    VALUE obj = Data_Wrap_Struct(klass, smokeruby_mark, smokeruby_free, (void *) o);
    return 0;
}

Marshall::HandlerFn getMarshallFn(const SmokeType &type);

class MethodReturnValue : public Marshall {
    Smoke *_smoke;
    Smoke::Index _method;
    Smoke::StackItem * _retval;
    Smoke::Stack _stack;
public:
	MethodReturnValue(Smoke *smoke, Smoke::Index method, Smoke::Stack stack, Smoke::StackItem * retval) :
		_smoke(smoke), _method(method), _retval(retval), _stack(stack) {
		Marshall::HandlerFn fn = getMarshallFn(type());
		(*fn)(this);
    }

    const Smoke::Method &method() { return _smoke->methods[_method]; }
    SmokeType type() { return SmokeType(_smoke, method().ret); }
    Marshall::Action action() { return Marshall::ToObject; }
    Smoke::StackItem &item() { return _stack[0]; }
    Smoke::StackItem &var() {
    	return *_retval;
    }
    void unsupported() {
//	rb_raise(rb_eArgError, "Cannot handle '%s' as return-type of %s::%s",
//		type().name(),
//		strcmp(_smoke->className(method().classId), "QGlobalSpace") == 0 ? "" : _smoke->className(method().classId),
//		_smoke->methodNames[method().name]);
    }
    Smoke *smoke() { return _smoke; }
    void next() {}
    bool cleanup() { return false; }
};

class MethodCall : public Marshall {
    int _cur;
    Smoke *_smoke;
    Smoke::Stack _stack;
    Smoke::Index _method;
    Smoke::Index *_args;
	void * _target;
	void * _current_object;
	Smoke::Index _current_object_class;
    Smoke::Stack _sp;
    int _items;
    Smoke::StackItem * _retval;
    bool _called;
public:
    MethodCall(Smoke *smoke, Smoke::Index method, void * target, Smoke::Stack sp, int items) :
	_cur(-1), _smoke(smoke), _method(method), _target(target), _current_object(0), _sp(sp), _items(items), _called(false)
    {
	if (_target != 0) {
	    smokeqyoto_object *o = value_obj_info(_target);
		if (o && o->ptr) {
		    _current_object = o->ptr;
		    _current_object_class = o->classId;
		}
	}
	
	_args = _smoke->argumentList + _smoke->methods[_method].args;
	_items = _smoke->methods[_method].numArgs;
	_stack = new Smoke::StackItem[items + 1];
	_retval = _sp;
    }

    ~MethodCall() {
	delete[] _stack;
    }

    SmokeType type() {
    	return SmokeType(_smoke, _args[_cur]);
    }

    Marshall::Action action() {
    	return Marshall::FromObject;
    }
    Smoke::StackItem &item() {
    	return _stack[_cur + 1];
    }

    Smoke::StackItem &var() {
	if(_cur < 0) return *_retval;
	return _sp[_cur + 1];
    }

    inline const Smoke::Method &method() {
    	return _smoke->methods[_method];
    }

    void unsupported() {
    	if (strcmp(_smoke->className(method().classId), "QGlobalSpace") == 0) {
//			rb_raise(rb_eArgError, "Cannot handle '%s' as argument to %s",
//				type().name(),
//				_smoke->methodNames[method().name]);
		} else {
//			rb_raise(rb_eArgError, "Cannot handle '%s' as argument to %s::%s",
//				type().name(),
//				_smoke->className(method().classId),
//				_smoke->methodNames[method().name]);
		}
    }

    Smoke *smoke() {
    	return _smoke;
    }

	inline void callMethod() {
		if (_called) return;
		_called = true;
		Smoke::ClassFn fn = _smoke->classes[method().classId].classFn;
		void *ptr = _smoke->cast(_current_object, _current_object_class, method().classId);
		_items = -1;
		(*fn)(method().method, ptr, _stack);
		MethodReturnValue r(_smoke, _method, _stack, _retval);

		if (strcmp(_smoke->methodNames[method().name], _smoke->className(method().classId)) == 0) {
			smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
			o->smoke = _smoke;
			o->classId = method().classId;
			o->ptr = _stack[0].s_voidp;
			o->allocated = true;
			(*SetSmokeObject)(_target, o);
		    mapPointer(_target, o, o->classId, 0);
		}

    }

    void next() {
	int oldcur = _cur;
	_cur++;

	while(!_called && _cur < _items) {
	    Marshall::HandlerFn fn = getMarshallFn(type());
	    (*fn)(this);
	    _cur++;
	}
	callMethod();
	_cur = oldcur;
    }

    bool cleanup() {
    	return true;
    }
};

class UnencapsulatedQObject : public QObject {
public:
    QConnectionList *public_receivers(int signal) const { return receivers(signal); }
    void public_activate_signal(QConnectionList *clist, QUObject *o) { activate_signal(clist, o); }
};

class EmitSignal : public Marshall {
    UnencapsulatedQObject *_qobj;
    int _id;
    MocArgument *_args;
    Smoke::StackItem * _sp;
    int _items;
    int _cur;
    Smoke::Stack _stack;
    bool _called;
public:
    EmitSignal(QObject *qobj, int id, int items, MocArgument * args, Smoke::StackItem *sp) :
    _qobj((UnencapsulatedQObject*)qobj), _id(id), _sp(sp), _items(items), _args(args),
    _cur(-1), _called(false)
    {
//	_items = NUM2INT(rb_ary_entry(args, 0));
//	Data_Get_Struct(rb_ary_entry(args, 1), MocArgument, _args);
	_stack = new Smoke::StackItem[_items];
    }
	~EmitSignal() {
		delete[] _stack;
		delete[] _args;
	}
    const MocArgument &arg() { return _args[_cur]; }
    SmokeType type() { return arg().st; }
    Marshall::Action action() { return Marshall::FromObject; }
    Smoke::StackItem &item() { return _stack[_cur]; }
    Smoke::StackItem & var() { return _sp[_cur]; }
    void unsupported() {
//	rb_raise(rb_eArgError, "Cannot handle '%s' as signal argument", type().name());
    }
    Smoke *smoke() { return type().smoke(); }
    void emitSignal() {
	if(_called) return;
	_called = true;

	QConnectionList *clist = _qobj->public_receivers(_id);
	if(!clist) return;

	QUObject *o = new QUObject[_items + 1];
	for(int i = 0; i < _items; i++) {
	    QUObject *po = o + i + 1;
	    Smoke::StackItem *si = _stack + i;
	    switch(_args[i].argType) {
	      case xmoc_bool:
		static_QUType_bool.set(po, si->s_bool);
		break;
	      case xmoc_int:
		static_QUType_int.set(po, si->s_int);
		break;
	      case xmoc_double:
		static_QUType_double.set(po, si->s_double);
		break;
	      case xmoc_charstar:
		static_QUType_charstar.set(po, (char*)si->s_voidp);
		break;
	      case xmoc_QString:
		static_QUType_QString.set(po, *(QString*)si->s_voidp);
		break;
	      default:
		{
		    const SmokeType &t = _args[i].st;
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
			    if(!fn) {
//				rb_warning("Unknown enumeration %s\n", t.name());
				p = new int((int)si->s_enum);
				break;
			    }
			    Smoke::Index id = t.typeId();
			    (*fn)(Smoke::EnumNew, id, p, si->s_enum);
			    (*fn)(Smoke::EnumFromLong, id, p, si->s_enum);
			    // FIXME: MEMORY LEAK
			}
			break;
		      case Smoke::t_class:
		      case Smoke::t_voidp:
			p = si->s_voidp;
			break;
		      default:
			p = 0;
			break;
		    }
		    static_QUType_ptr.set(po, p);
		}
	    }
	}

	_qobj->public_activate_signal(clist, o);
        delete[] o;
    }
    void next() {
	int oldcur = _cur;
	_cur++;

	while(!_called && _cur < _items) {
	    Marshall::HandlerFn fn = getMarshallFn(type());
	    (*fn)(this);
	    _cur++;
	}

	emitSignal();
	_cur = oldcur;
    }
    bool cleanup() { return true; }
};

class QyotoSmokeBinding : public SmokeBinding {
public:
    QyotoSmokeBinding(Smoke *s) : SmokeBinding(s) {}

    void deleted(Smoke::Index classId, void *ptr) {
	void * obj = getPointerObject(ptr);
	smokeqyoto_object *o = value_obj_info(obj);
	if(do_debug & qtdb_gc) {
	    printf("%p->~%s()", ptr, smoke->className(classId));
	}
	if(!o || !o->ptr) {
	    return;
	}
	unmapPointer(o, o->classId, 0);
	o->ptr = 0;
    }

    bool callMethod(Smoke::Index method, void *ptr, Smoke::Stack args, bool /*isAbstract*/) {
		// Always fail for now..
		return false;

	void * obj = getPointerObject(ptr);
	smokeqyoto_object *o = value_obj_info(obj);
	if(do_debug & qtdb_virtual) 
	    printf("virtual %p->%s::%s() called", ptr,
		    smoke->classes[smoke->methods[method].classId].className,
		    smoke->methodNames[smoke->methods[method].name]
		    );

	if(!o) {
	    if( do_debug & qtdb_virtual )   // if not in global destruction
		printf("Cannot find object for virtual method %p -> %p", ptr, obj);
	    return false;
	}

	const char *methodName = smoke->methodNames[smoke->methods[method].name];
//	if (rb_respond_to(obj, rb_intern(methodName)) == 0) {
//	    return false;
//	}

//	VirtualMethodCall c(smoke, method, args, obj);
//	c.next();
	return true;
    }

    char *className(Smoke::Index classId) {
		return classname.find((int) classId);
    }
};

extern "C" {

int 
FindMethodId(char * classname, char * methodname) 
{
	Smoke::Index meth = qt_Smoke->findMethod(classname, methodname);
#ifdef DEBUG
	printf("\t\tIn FindMethodId %s::%s => %d\n", classname, methodname, meth);
#endif
	return meth;
}

int 
MethodFromMap(int meth) 
{
	return qt_Smoke->methodMaps[meth].method;
}

int 
FindAmbiguousMethodId(int ambiguousId) 
{
	if (qt_Smoke->ambiguousMethodList[ambiguousId] == 0) {
		return 0;
	}
	
	Smoke::Method &methodRef = qt_Smoke->methods[qt_Smoke->ambiguousMethodList[ambiguousId]];
	if ((methodRef.flags & Smoke::mf_internal) == 0) {
#ifdef DEBUG
		printf("\t\tIn FindAmbiguousMethodId(%d) => %d\n", ambiguousId, qt_Smoke->ambiguousMethodList[ambiguousId]);
#endif
		return qt_Smoke->ambiguousMethodList[ambiguousId];
	}
	
	return -1;
}

void AddGetSmokeObject(GetIntPtr callback)
{
	GetSmokeObject = callback;
}

void AddSetSmokeObject(SetIntPtr callback)
{
	SetSmokeObject = callback;
}

void AddMapPointer(SetIntPtr callback)
{
	MapPointer = callback;
}

void AddUnmapPointer(RemoveIntPtr callback)
{
	UnmapPointer = callback;
}

void AddGetPointerObject(GetIntPtr callback)
{
	GetPointerObject = callback;
}

void
CallMethod(int methodId, void * obj, Smoke::StackItem * sp, int items)
{
#ifdef DEBUG
	printf("ENTER CallMethod(methodId: %d target: 0x%8.8x items: %d)\n", methodId, obj, items);
#endif

	MethodCall c(qt_Smoke, methodId, obj, sp, items);
	c.next();

#ifdef DEBUG
	printf("LEAVE CallMethod()\n");
#endif

	return;
}

static bool
setMocType(MocArgument *arg, int idx, const char * name, const char * static_type)
{
    Smoke::Index typeId = qt_Smoke->idType(name);
    if(!typeId) return false;
    arg[idx].st.set(qt_Smoke, typeId);
    if(strcmp(static_type, "ptr") == 0)
	arg[idx].argType = xmoc_ptr;
    else if(strcmp(static_type, "bool") == 0)
	arg[idx].argType = xmoc_bool;
    else if(strcmp(static_type, "int") == 0)
	arg[idx].argType = xmoc_int;
    else if(strcmp(static_type, "double") == 0)
	arg[idx].argType = xmoc_double;
    else if(strcmp(static_type, "char*") == 0)
	arg[idx].argType = xmoc_charstar;
    else if(strcmp(static_type, "QString") == 0)
	arg[idx].argType = xmoc_QString;
    return true;
}

static MocArgument *
getMocArguments(QString member) 
{
	QRegExp rx1("^.*\\((.*)\\)$");
	QRegExp rx2("^(bool|int|double|char\\*|QString)&?$");
	int match = rx1.search(member);
	if (match == -1) {
		return 0;
	}

	QString argStr = rx1.cap(1);
//	printf("argStr: %s\n", argStr.latin1());
	QStringList args = QStringList::split(",", argStr);
	MocArgument * mocargs = new MocArgument[args.size() + 1];
	int i = 0;
	for ( QStringList::Iterator it = args.begin(); it != args.end(); ++it ) {
		QString a = (*it).replace(QRegExp("^const\\s+"), "");
		a = (rx2.search(a) == -1) ? "ptr" : rx2.cap(1);
//		printf("a: %s\n", a.latin1());
		bool valid = setMocType(mocargs, i, (*it).latin1(), a.latin1());
		i++;
    }

	return mocargs;
}

bool
SignalEmit(char * signature, void * obj, Smoke::StackItem * sp, int items)
{
#ifdef DEBUG
	printf("ENTER SignalEmit(signature: %s target: 0x%8.8x items: %d)\n", signature, obj, items);
#endif

	QString sig(signature);
	sig.replace(QRegExp("^void "), "");
	smokeqyoto_object *o = value_obj_info(obj);
    QObject *qobj = (QObject*)o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject"));
    
	if (qobj->signalsBlocked()) {
		return false;
	}

	MocArgument * args = getMocArguments(sig);
	QStrList signalNames = qobj->metaObject()->signalNames(true);

    char * signalStr = 0;
	int index = 0;
    for ( signalStr = signalNames.first(); signalStr != 0; signalStr = signalNames.next() ) {
		if (strcmp(signalStr, sig.latin1()) == 0) {
			break;
		}
		index++;
	}

//	printf("signal id: %d\n", index);

    EmitSignal signal(qobj, index, items, args, sp);
    signal.next();
#ifdef DEBUG
	printf("LEAVE SignalEmit()\n");
#endif

	return true;
}

void
Init_qyoto()
{
	init_qt_Smoke();
	qt_Smoke->binding = new QyotoSmokeBinding(qt_Smoke);
	install_handlers(Qt_handlers);
}

}

