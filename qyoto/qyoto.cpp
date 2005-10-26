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
#include <qhash.h>

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

typedef void* (*GetIntPtr)(GCHandle);
typedef void (*SetIntPtr)(GCHandle, void *);
typedef void (*RemoveIntPtr)(void *);

static GetIntPtr GetSmokeObject;
static SetIntPtr SetSmokeObject;

static SetIntPtr MapPointer;
static RemoveIntPtr UnmapPointer;
static GetIntPtr GetPointerObject;

// Maps from a classname in the form Qt::Widget to an int id
QHash<int, QString> classname;

extern "C" {
extern GCHandle set_obj_info(const char * className, smokeqyoto_object * o);
};

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(GCHandle obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);

extern TypeHandler Qt_handlers[];
void install_handlers(TypeHandler *);

smokeqyoto_object *value_obj_info(GCHandle qyoto_value) {  // ptr on success, null on fail
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

GCHandle getPointerObject(void *ptr) {
	return (*GetPointerObject)(ptr);
}

void unmapPointer(smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);
    if(ptr != lastptr) {
	lastptr = ptr;
	if (getPointerObject(ptr) != 0) {
		GCHandle obj_ptr = getPointerObject(ptr);
		
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

void mapPointer(GCHandle obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
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

GCHandle
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
    Smoke::StackItem & _retval;
    Smoke::Stack _stack;
public:
    MethodReturnValue(Smoke *smoke, Smoke::Index method, Smoke::Stack stack, Smoke::StackItem & retval) :
    _smoke(smoke), _method(method), _retval(retval), _stack(stack) {
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
    }

    const Smoke::Method &method() { return _smoke->methods[_method]; }
    SmokeType type() { return SmokeType(_smoke, method().ret); }
    Marshall::Action action() { return Marshall::ToObject; }
    Smoke::StackItem &item() { return _stack[0]; }
    Smoke::StackItem &var() {
    	return _retval;
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
	GCHandle _target;
	GCHandle _current_object;
	Smoke::Index _current_object_class;
    Smoke::Stack _sp;
    int _items;
    Smoke::StackItem _retval;
    bool _called;
public:
    MethodCall(Smoke *smoke, Smoke::Index method, GCHandle target, Smoke::Stack sp, int items) :
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
//	_retval = 0;
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
	if(_cur < 0) return _retval;
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
	if(_called) return;
	_called = true;
	Smoke::ClassFn fn = _smoke->classes[method().classId].classFn;
	void *ptr = _smoke->cast(_current_object, _current_object_class, method().classId);
	_items = -1;
	(*fn)(method().method, ptr, _stack);
	MethodReturnValue r(_smoke, _method, _stack, _retval);
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

class QyotoSmokeBinding : public SmokeBinding {
public:
    QyotoSmokeBinding(Smoke *s) : SmokeBinding(s) {}

    void deleted(Smoke::Index classId, void *ptr) {
	GCHandle obj = getPointerObject(ptr);
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
	GCHandle obj = getPointerObject(ptr);
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
		return (char *) (const char *) classname.value((int) classId).toLatin1();
    }
};

extern "C" {

int 
FindMethodId(char * classname, char * methodname) 
{
    Smoke::Index meth = qt_Smoke->findMethod(classname, methodname);
	printf("\t\tIn FindMethodId %s::%s => %d\n", classname, methodname, meth);
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
		printf("\t\tIn FindAmbiguousMethodId(%d) => %d\n", ambiguousId, qt_Smoke->ambiguousMethodList[ambiguousId]);
		return qt_Smoke->ambiguousMethodList[ambiguousId];
	}
	
	return -1;
}

void AddGetSmokeObject(GetIntPtr callback)
{
	printf("In AddGetSmokeObject 0x%8.8x\n", callback);
	GetSmokeObject = callback;
}

void AddSetSmokeObject(SetIntPtr callback)
{
	printf("In AddSetSmokeObject 0x%8.8x\n", callback);
	SetSmokeObject = callback;
}

void AddMapPointer(SetIntPtr callback)
{
	printf("In AddMapPointer 0x%8.8x\n", callback);
	MapPointer = callback;
}

void AddUnmapPointer(RemoveIntPtr callback)
{
	printf("In AddUnmapPointer 0x%8.8x\n", callback);
	UnmapPointer = callback;
}

void AddGetPointerObject(GetIntPtr callback)
{
	printf("In AddGetPointerObject 0x%8.8x\n", callback);
	GetPointerObject = callback;
}

void
CallMethod(int methodId, GCHandle obj, Smoke::StackItem * sp, int items)
{
	printf("In CallMethod methodId: %d target: 0x%8.8x items: %d\n", methodId, obj, items);
	printf("In CallMethod %d\n", sp[1].s_int);
	
	smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
	o->smoke = 0;
	o->classId = 123;
	o->ptr = 0;
	o->allocated = false;
	(*SetSmokeObject)(obj, o);

	smokeqyoto_object * optr = (smokeqyoto_object *) (*GetSmokeObject)(obj);
	if (optr != 0) {
		printf("In CallMethod classId: %d\n", optr->classId);
	}
	
	sp[0].s_int = 999;
	return;
}

void
Init_qyoto()
{
    init_qt_Smoke();
	qt_Smoke->binding = new QyotoSmokeBinding(qt_Smoke);
    install_handlers(Qt_handlers);
}

}

