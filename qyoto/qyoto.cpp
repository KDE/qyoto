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

#include <QtGui/qapplication.h>
#include <QtCore/qstring.h>
#include <QtCore/qhash.h>
#include <QtCore/qobject.h>
#include <QtCore/qbytearray.h>
#include <QtCore/qregexp.h>
#include <QtCore/qstringlist.h>
#include <QMetaMethod>

#include <QtGui/qmainwindow.h>

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
// #define DEBUG

extern Smoke *qt_Smoke;
extern void init_qt_Smoke();

#ifdef DEBUG
int do_debug = qtdb_gc;
#else
int do_debug = qtdb_none;
#endif

FromIntPtr FreeGCHandle;

static GetIntPtr GetSmokeObject;
static SetIntPtr SetSmokeObject;

static SetIntPtr MapPointer;
static FromIntPtr UnmapPointer;
static GetIntPtr GetPointerObject;

static OverridenMethodFn OverridenMethod;
static InvokeMethodFn InvokeMethod;
static CreateInstanceFn CreateInstance;
static InvokeCustomSlotFn InvokeCustomSlot;
static IsSmokeClassFn IsSmokeClass;

// Maps from a classname in the form Qt::Widget to an int id
QHash<int,char *> classname;

extern "C" {
extern void * set_obj_info(const char * className, smokeqyoto_object * o);
};

extern void smokeStackToQtStack(Smoke::Stack stack, void ** o, int items, MocArgument* args);
extern void smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int items, MocArgument* args);

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);
extern "C" int qt_metacall(void* obj, int _c, int _id, void* _o);

extern TypeHandler Qt_handlers[];
void install_handlers(TypeHandler *);

void
smokeStackToQtStack(Smoke::Stack stack, void ** o, int items, MocArgument* args)
{
	for (int i = 0; i < items; i++) {
		Smoke::StackItem *si = stack + i;
		//printf("si->s_int: %d, i: %d\n", si->s_int, i);
		switch(args[i].argType) {
		case xmoc_bool:
			o[i] = &si->s_bool;
			break;
		case xmoc_int:
			o[i] = &si->s_int;
			break;
		case xmoc_double:
			o[i] = &si->s_double;
			break;
		case xmoc_charstar:
			o[i] = &si->s_voidp;
			break;
		case xmoc_QString:
			o[i] = si->s_voidp;
			break;
		default:
		{
			const SmokeType &t = args[i].st;
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
					printf("Unknown enumeration %s\n", t.name());
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
			o[i] = p;
		}
		}
	}
}

void
smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int items, MocArgument* args)
{
	for (int i = 0; i < items; i++) {
		void *o = _o[i];
		switch(args[i].argType) {
		case xmoc_bool:
		stack[i].s_bool = *(bool*)o;
		break;
		case xmoc_int:
		stack[i].s_int = *(int*)o;
		break;
		case xmoc_double:
		stack[i].s_double = *(double*)o;
		break;
		case xmoc_charstar:
		stack[i].s_voidp = o;
		break;
		case xmoc_QString:
		stack[i].s_voidp = o;
		break;
		default:	// case xmoc_ptr:
		{
			const SmokeType &t = args[i].st;
			void *p = o;
			switch(t.elem()) {
			case Smoke::t_bool:
			stack[i].s_bool = **(bool**)o;
			break;
			case Smoke::t_char:
			stack[i].s_char = **(char**)o;
			break;
			case Smoke::t_uchar:
			stack[i].s_uchar = **(unsigned char**)o;
			break;
			case Smoke::t_short:
			stack[i].s_short = **(short**)p;
			break;
			case Smoke::t_ushort:
			stack[i].s_ushort = **(unsigned short**)p;
			break;
			case Smoke::t_int:
			stack[i].s_int = **(int**)p;
			break;
			case Smoke::t_uint:
			stack[i].s_uint = **(unsigned int**)p;
			break;
			case Smoke::t_long:
			stack[i].s_long = **(long**)p;
			break;
			case Smoke::t_ulong:
			stack[i].s_ulong = **(unsigned long**)p;
			break;
			case Smoke::t_float:
			stack[i].s_float = **(float**)p;
			break;
			case Smoke::t_double:
			stack[i].s_double = **(double**)p;
			break;
			case Smoke::t_enum:
			{
				Smoke::EnumFn fn = SmokeClass(t).enumFn();
				if (!fn) {
					printf("Unknown enumeration %s\n", t.name());
					stack[i].s_enum = **(int**)p;
					break;
				}
				Smoke::Index id = t.typeId();
				(*fn)(Smoke::EnumToLong, id, p, stack[i].s_enum);
			}
			break;
			case Smoke::t_class:
			case Smoke::t_voidp:
				if (strchr(t.name(), '*') != 0) {
					stack[i].s_voidp = *(void **)p;
				} else {
					stack[i].s_voidp = p;
				}
			break;
			}
		}
		}
	}
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
			qWarning("unmapPointer (%s*)%p -> %p", className, ptr, obj_ptr);
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
			qWarning("mapPointer (%s*)%p -> %p", className, ptr, (void*)obj);
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
	void * obj = (*CreateInstance)(className);
	(*SetSmokeObject)(obj, o);
	return obj;
}

Marshall::HandlerFn getMarshallFn(const SmokeType &type);

class VirtualMethodReturnValue : public Marshall {
    Smoke *_smoke;
    Smoke::Index _method;
    Smoke::Stack _stack;
    SmokeType _st;
    Smoke::StackItem * _retval;
public:
    const Smoke::Method &method() { return _smoke->methods[_method]; }
    SmokeType type() { return _st; }
    Marshall::Action action() { return Marshall::FromObject; }
    Smoke::StackItem &item() { return _stack[0]; }
    Smoke::StackItem &var() {
    	return *_retval;
    }

	void unsupported() {
		qFatal(	"Cannot handle '%s' as return-type of virtual method %s::%s",
				type().name(),
				_smoke->className(method().classId),
				_smoke->methodNames[method().name] );
    }

    Smoke *smoke() { return _smoke; }
    void next() {}
    bool cleanup() { return false; }

    VirtualMethodReturnValue(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, Smoke::StackItem * retval) :
    _smoke(smoke), _method(meth), _stack(stack), _retval(retval) {
	_st.set(_smoke, method().ret);
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
   }
};

class VirtualMethodCall : public Marshall {
    Smoke *_smoke;
    Smoke::Index _method;
    Smoke::Stack _stack;
    void * _obj;
	void * _overridenMethod;
    int _cur;
    Smoke::Index *_args;
    Smoke::Stack _sp;
    bool _called;

public:
    SmokeType type() { return SmokeType(_smoke, _args[_cur]); }
    Marshall::Action action() { return Marshall::ToObject; }
    Smoke::StackItem &item() { return _stack[_cur + 1]; }

	Smoke::StackItem &var() {
		return _sp[_cur];
    }

	const Smoke::Method &method() { return _smoke->methods[_method]; }

    void unsupported() {
		qFatal(	"Cannot handle '%s' as argument of virtual method %s::%s",
				type().name(),
				_smoke->className(method().classId),
				_smoke->methodNames[method().name] );
    }
    Smoke *smoke() { return _smoke; }

	void callMethod() {
		if (_called) return;
		_called = true;
	
		(*InvokeMethod)(_obj, _overridenMethod, _sp);
		Smoke::StackItem * _retval = _sp;
		VirtualMethodReturnValue r(_smoke, _method, _stack, _retval);
    }

	void next() {
		int oldcur = _cur;
		_cur++;
		while(!_called && _cur < method().numArgs) {
			Marshall::HandlerFn fn = getMarshallFn(type());
			(*fn)(this);
			_cur++;
		}
		callMethod();
		_cur = oldcur;
    }

    bool cleanup() { return false; }   // is this right?

	VirtualMethodCall(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, void * obj, void * overridenMethod) :
		_smoke(smoke), _method(meth), _stack(stack), _obj(obj), _overridenMethod(overridenMethod), _cur(-1), _sp(0), _called(false) {
		_sp = new Smoke::StackItem[method().numArgs];
		_args = _smoke->argumentList + method().args;
    }

    ~VirtualMethodCall() {
		free(_sp);
		(*FreeGCHandle)(_overridenMethod);
    }
};

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
		qFatal(	"Cannot handle '%s' as return-type of %s::%s",
				type().name(),
				strcmp(_smoke->className(method().classId), "QGlobalSpace") == 0 ? "" : _smoke->className(method().classId),
				_smoke->methodNames[method().name] );
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
		(*FreeGCHandle)(_target);
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
		if (_cur < 0) return *_retval;
		return _sp[_cur + 1];
    }

    inline const Smoke::Method &method() {
    	return _smoke->methods[_method];
    }

    void unsupported() {
    	if (strcmp(_smoke->className(method().classId), "QGlobalSpace") == 0) {
			qFatal("Cannot handle '%s' as argument to %s",
				type().name(),
				_smoke->methodNames[method().name]);
		} else {
			qFatal("Cannot handle '%s' as argument to %s::%s",
				type().name(),
				_smoke->className(method().classId),
				_smoke->methodNames[method().name]);
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

		// A constructor
		if (strcmp(_smoke->methodNames[method().name], _smoke->className(method().classId)) == 0) {
			smokeqyoto_object  * o = alloc_smokeqyoto_object(true, _smoke, method().classId, _stack[0].s_voidp);
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
/*
	Converts a C++ value returned by a signal invocation to a C# 
	reply type
*/
class SignalReturnValue : public Marshall {
    MocArgument *	_replyType;
    Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SignalReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType) 
	{
		_result = result;
		_replyType = replyType;
		_stack = new Smoke::StackItem[1];
		smokeStackFromQtStack(_stack, o, 1, _replyType);
		Marshall::HandlerFn fn = getMarshallFn(type());
		(*fn)(this);
    }

    SmokeType type() { 
		return _replyType[0].st; 
	}
    Marshall::Action action() { return Marshall::ToObject; }
    Smoke::StackItem &item() { return _stack[0]; }
    Smoke::StackItem &var() {
    	return *_result;
    }
	
	void unsupported() 
	{
		qFatal("Cannot handle '%s' as signal reply-type", type().name());
    }
	Smoke *smoke() { return type().smoke(); }
    
	void next() {}
    
	bool cleanup() { return false; }
	
	~SignalReturnValue() {
		delete[] _stack;
	}
};

class EmitSignal : public Marshall {
    QObject *_qobj;
    int _id;
    MocArgument *_args;
    Smoke::StackItem * _sp;
    int _items;
    int _cur;
    Smoke::Stack _stack;
    bool _called;
public:
    EmitSignal(QObject *qobj, int id, int items, MocArgument * args, Smoke::StackItem *sp) :
    _qobj(qobj), _id(id), _sp(sp), _items(items), _args(args),
    _cur(-1), _called(false)
    {
	_stack = new Smoke::StackItem[_items];
    }
	~EmitSignal() {
		delete[] _stack;
		delete[] _args;
	}
    const MocArgument &arg() { return _args[_cur + 1]; }
    SmokeType type() { return arg().st; }
    Marshall::Action action() { return Marshall::FromObject; }
    Smoke::StackItem &item() { return _stack[_cur]; }
    Smoke::StackItem & var() { return _sp[_cur + 1]; }
    void unsupported() {
		qFatal("Cannot handle '%s' as signal argument", type().name());
    }
    Smoke *smoke() { return type().smoke(); }
    void emitSignal() {
	if(_called) return;
	_called = true;

	void** o = new void*[_items + 1];
	smokeStackToQtStack(_stack, o + 1, _items, _args + 1);
  	_qobj->metaObject()->activate(_qobj, _id, o);

	if (_args[0].argType != xmoc_void) {
		SignalReturnValue r(o, _sp, _args);
	}

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

class SlotReturnValue : public Marshall {
    MocArgument *	_replyType;
    Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SlotReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType) 
	{
		_result = result;
		_replyType = replyType;
		_stack = new Smoke::StackItem[1]; 
		Marshall::HandlerFn fn = getMarshallFn(type());
		(*fn)(this);
		// Save any address in zeroth element of the arrary of 'void*'s passed to 
		// qt_metacall()
		void * ptr = o[0];
		smokeStackToQtStack(_stack, o, 1, _replyType);
			printf("SlotReturnValue o[0]: %p\n", o[0]);

		// Only if the zeroth element of the arrary of 'void*'s passed to qt_metacall()
		// contains an address, is the return value of the slot needed.
		if (ptr != 0) {
			*(void**)ptr = *(void**)(o[0]);
		}
    }

    SmokeType type() { 
		return _replyType[0].st; 
	}
    Marshall::Action action() { return Marshall::FromObject; }
    Smoke::StackItem &item() { return _stack[0]; }
    Smoke::StackItem &var() {
    	return *_result;
    }
	
	void unsupported() 
	{
		printf("Cannot handle '%s' as slot reply-type", type().name());
    }
	Smoke *smoke() { return type().smoke(); }
    
	void next() {}
    
	bool cleanup() { return false; }
	
	~SlotReturnValue() {
		delete[] _stack;
	}
};

class InvokeSlot : public Marshall {
    void * _obj;
    const char * _slotname;
    int _items;
    MocArgument *_args;
    MocArgument * _mocret;
    void **_o;
    int _cur;
    bool _called;
    Smoke::StackItem *_sp;
    Smoke::Stack _stack;
public:
    const MocArgument &arg() { return _args[_cur + 1]; }
    SmokeType type() { return arg().st; }
    Marshall::Action action() { return Marshall::ToObject; }
    Smoke::StackItem &item() { return _stack[_cur]; }
    Smoke::StackItem & var() { return _sp[_cur]; }
    Smoke *smoke() { return type().smoke(); }
    bool cleanup() { return false; }
	void unsupported() {
		qFatal("Cannot handle '%s' as slot argument\n", type().name());
	}
	void copyArguments() {
		smokeStackFromQtStack(_stack, _o + 1, _items, _args + 1);
	}
	void invokeSlot() {
		if (_called) return;
		_called = true;
		Smoke::StackItem* ret = new Smoke::StackItem[1];
		(*InvokeCustomSlot)(_obj, _slotname, _sp, ret);
		
		if (_mocret[0].argType != xmoc_void) {
// #ifdef DEBUG
			printf("CREATE SlotReturnValue()\n");
// #endif
			SlotReturnValue r(_o, ret, _mocret);
		}
	}

	void next() {
		int oldcur = _cur;
		_cur++;

		while (!_called && _cur < _items) {
			Marshall::HandlerFn fn = getMarshallFn(type());
			(*fn)(this);
			_cur++;
		}

		invokeSlot();
		_cur = oldcur;
	}

    InvokeSlot(void * obj, const char * slotname, int items, MocArgument * args, void** o) :
    _obj(obj), _slotname(slotname), _items(items), _args(args), _o(o), _cur(-1), _called(false)
    {
		_sp = new Smoke::StackItem[_items];
		_stack = new Smoke::StackItem[_items];
		_mocret = args;
		copyArguments();
    }

	~InvokeSlot() {
		delete[] _stack;
		delete[] _sp;
// 		(*FreeGCHandle)(_obj);
	}
};

class QyotoSmokeBinding : public SmokeBinding {
public:
    QyotoSmokeBinding(Smoke *s) : SmokeBinding(s) {}

	void deleted(Smoke::Index classId, void *ptr) {
		void * obj = getPointerObject(ptr);
		smokeqyoto_object *o = value_obj_info(obj);
	
		if(do_debug & qtdb_gc) {
			qWarning("%p->~%s()", ptr, smoke->className(classId));
		}
	
		if(!o || !o->ptr) {
			return;
		}
		unmapPointer(o, o->classId, 0);
		o->ptr = 0;
    }

	bool callMethod(Smoke::Index method, void *ptr, Smoke::Stack args, bool /*isAbstract*/) {
		Smoke::Method & meth = smoke->methods[method];
		QByteArray signature(smoke->methodNames[meth.name]);
		signature += "(";

		for (int i = 0; i < meth.numArgs; i++) {
			if (i != 0) signature += ", ";
			signature += smoke->types[smoke->argumentList[meth.args + i]].name;
		}

		signature += ")";
		if (meth.flags & Smoke::mf_const) {
			signature += " const";
		}

		if (do_debug & qtdb_virtual) {
			qWarning(	"virtual %p->%s::%s called", 
						ptr,
						smoke->classes[smoke->methods[method].classId].className,
						(const char *) signature );
		}

		void * obj = getPointerObject(ptr);
		smokeqyoto_object *o = value_obj_info(obj);

		if (!o) {
			if( do_debug & qtdb_virtual ) {  // if not in global destruction
				qWarning("Cannot find object for virtual method %p -> %p", ptr, obj);
			}

			return false;
		}
		
		if (strcmp(signature, "qt_metacall(QMetaObject::Call, int, void**)") == 0) {
			QMetaObject::Call _c = (QMetaObject::Call)args[1].s_int;
			int _id = args[2].s_int;
			void** _o = (void**)args[3].s_voidp;
			
			args[0].s_int = qt_metacall(obj, _c, _id, _o);
			return true;
		}
		
		void * overridenMethod = (*OverridenMethod)(obj, (const char *) signature);
		if (overridenMethod == 0) {
			return false;
		}

		VirtualMethodCall c(smoke, method, args, obj, overridenMethod);
		c.next();
		return true;
	}

    char *className(Smoke::Index classId) {
		return classname.value((int) classId);
    }
};

extern "C" {

int 
FindMethodId(char * classname, char * mungedname, char * signature) 
{
// printf("FindMethodId(classname: %s mungedname: %s signature: %s)\n", classname, mungedname, signature);
	Smoke::Index meth = qt_Smoke->findMethod(classname, mungedname);
#ifdef DEBUG
	if (do_debug & qtdb_calls) qWarning("DAMNIT on %s::%s => %d", classname, mungedname, meth);
#endif
	if (meth == 0) {
    	meth = qt_Smoke->findMethod("QGlobalSpace", mungedname);
#ifdef DEBUG
		if (do_debug & qtdb_calls) qWarning("DAMNIT on QGlobalSpace::%s => %d", mungedname, meth);
#endif
	}
	
    if (meth == 0) {
    	return -1;
		// empty list
	} else if(meth > 0) {
		Smoke::Index i = qt_Smoke->methodMaps[meth].method;
		if (i == 0) {		// shouldn't happen
	    	return -1;
		} else if (i > 0) {	// single match
	    	Smoke::Method &methodRef = qt_Smoke->methods[i];
			if ((methodRef.flags & Smoke::mf_internal) == 0) {
				return i;
			}
		} else {		// multiple match
	    	int ambiguousId = -i;		// turn into ambiguousMethodList index
			while (qt_Smoke->ambiguousMethodList[ambiguousId] != 0) {
				Smoke::Method &methodRef = qt_Smoke->methods[qt_Smoke->ambiguousMethodList[ambiguousId]];
				if ((methodRef.flags & Smoke::mf_internal) == 0) {
static QByteArray * currentSignature = 0;
					if (currentSignature == 0) {
						currentSignature = new QByteArray("");
					}
		
					*currentSignature = "(";
		
					for (int i = 0; i < methodRef.numArgs; i++) {
						if (i != 0) *currentSignature += ", ";
						*currentSignature += qt_Smoke->types[qt_Smoke->argumentList[methodRef.args + i]].name;
					}
		
					*currentSignature += ")";
					if (methodRef.flags & Smoke::mf_const) {
						*currentSignature += " const";
					}
		
#ifdef DEBUG
					printf(	"\t\tIn FindAmbiguousMethodId(%d, %s) => %d (%s)\n", 
							ambiguousId,
							signature,
							qt_Smoke->ambiguousMethodList[ambiguousId],
							(const char *) *currentSignature );
#endif
		
					if (*currentSignature == signature) {
						return qt_Smoke->ambiguousMethodList[ambiguousId];
					}
				}
				ambiguousId++;
			}
		}
	}
	
	return -1;
}

int 
MethodFromMap(int meth) 
{
	return qt_Smoke->methodMaps[meth].method;
}

void *
QVariantValue(char * typeName, void * variant)
{
#ifdef DEBUG
	printf("ENTER QVariantValue(typeName: %s variant: 0x%8.8x)\n", typeName, variant);
#endif
	smokeqyoto_object *o = value_obj_info(variant);
	void * value = QMetaType::construct(	QMetaType::type(typeName), 
											(void *) ((QVariant *)o->ptr)->constData() );
	int id = o->smoke->idClass(typeName);
	smokeqyoto_object  * vo = alloc_smokeqyoto_object(true, o->smoke, id, (void *) value);
	(*FreeGCHandle)(variant);
	return set_obj_info((QString("Qyoto.") + typeName).toLatin1(), vo);
}

void *
QVariantFromValue(int type, void * value)
{
#ifdef DEBUG
	printf("ENTER QVariantFromValue(type: %d value: 0x%8.8x)\n", type, value);
#endif
	smokeqyoto_object *o = value_obj_info(value);
	QVariant * v = new QVariant(type, o->ptr);
	int id = o->smoke->idClass("QVariant");
	smokeqyoto_object  * vo = alloc_smokeqyoto_object(true, o->smoke, id, (void *) v);
	(*FreeGCHandle)(value);
	return set_obj_info("Qyoto.QVariant", vo);
}

void 
InstallFreeGCHandle(FromIntPtr callback)
{
	FreeGCHandle = callback;
}

void 
InstallGetSmokeObject(GetIntPtr callback)
{
	GetSmokeObject = callback;
}

void 
InstallSetSmokeObject(SetIntPtr callback)
{
	SetSmokeObject = callback;
}

void 
InstallMapPointer(SetIntPtr callback)
{
	MapPointer = callback;
}

void 
InstallUnmapPointer(FromIntPtr callback)
{
	UnmapPointer = callback;
}

void 
InstallGetPointerObject(GetIntPtr callback)
{
	GetPointerObject = callback;
}

void 
InstallOverridenMethod(OverridenMethodFn callback)
{
	OverridenMethod = callback;
}

void 
InstallInvokeMethod(InvokeMethodFn callback)
{
	InvokeMethod = callback;
}

void 
InstallCreateInstance(CreateInstanceFn callback)
{
	CreateInstance = callback;
}

void
InstallInvokeCustomSlot(InvokeCustomSlotFn callback)
{
	InvokeCustomSlot = callback;
}

void
InstallIsSmokeClass(IsSmokeClassFn callback)
{
	IsSmokeClass = callback;
}

void
CallSmokeMethod(int methodId, void * obj, Smoke::StackItem * sp, int items)
{
#ifdef DEBUG
	printf("ENTER CallSmokeMethod(methodId: %d target: 0x%8.8x items: %d)\n", methodId, obj, items);
#endif

	MethodCall c(qt_Smoke, methodId, obj, sp, items);
	c.next();

#ifdef DEBUG
	printf("LEAVE CallSmokeMethod()\n");
#endif

	return;
}

static bool
setMocType(MocArgument *arg, int idx, const char * name_value, const char * static_type)
{
	QByteArray name(name_value);
	Smoke::Index typeId = 0;

	if (strcmp(static_type, "ptr") == 0) {
		arg[idx].argType = xmoc_ptr;
		typeId = qt_Smoke->idType((const char *) name);
		if (typeId == 0 && !name.contains('*')) {
			name += "&";
			typeId = qt_Smoke->idType((const char *) name);
		}
	} else if (strcmp(static_type, "bool") == 0) {
		arg[idx].argType = xmoc_bool;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "int") == 0) {
		arg[idx].argType = xmoc_int;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "double") == 0) {
		arg[idx].argType = xmoc_double;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "char*") == 0) {
		arg[idx].argType = xmoc_charstar;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "QString") == 0) {
		arg[idx].argType = xmoc_QString;
		name += "*";
		typeId = qt_Smoke->idType((const char *) name);
	}
	
	if (typeId == 0) {
#ifdef DEBUG
		printf("In setMocType(): no typeId %s\n", name_value);
#endif
		return false;
	}

	arg[idx].st.set(qt_Smoke, typeId);
	return true;
}

MocArgument *
GetMocArgumentsNumber(QString replyType, QString member, int& number) 
{
	QRegExp rx1("^.*\\((.*)\\)$");
	QRegExp rx2("^(bool|int|double|char\\*|QString)&?$");
	int match = rx1.indexIn(member);
	if (match == -1) {
		return 0;
	}

	if (replyType.isEmpty()) {
		replyType = "void";
	}
	QStringList args(replyType);

	QString argStr = rx1.cap(1);

    if (!argStr.isEmpty()) {
		args << argStr.split(",");
	}

	number = args.size() - 1;

	MocArgument * mocargs = new MocArgument[args.size()];
	int i = 0;
	for (	QStringList::Iterator it = args.begin(); 
			it != args.end(); 
			++it, i++ ) 
	{
		QString a = (*it);

		if (a == "void" || a == "" || a == " ") {
			mocargs[i].argType = xmoc_void;
		} else {
			a.replace(QRegExp("^const\\s+"), "");
			a = (rx2.indexIn(a) == -1) ? "ptr" : rx2.cap(1);

			QByteArray name = (*it).toLatin1();
			QByteArray static_type = a.toLatin1();
			bool valid = setMocType(mocargs, i, name.constData(), static_type.constData());
		}
    }

	return mocargs;
}

MocArgument *
GetMocArguments(QString type, QString member) {
	int tmp;
	return GetMocArgumentsNumber(type, member, tmp);
}

bool
SignalEmit(char * signature, char * type, void * obj, Smoke::StackItem * sp, int items)
{
	smokeqyoto_object *o = value_obj_info(obj);
    QObject *qobj = (QObject*)o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject"));
    
	if (qobj->signalsBlocked()) {
		return false;
	}

	QString sig(signature);
	QString replyType(type);

	MocArgument * args = GetMocArguments(replyType, sig);

	const QMetaObject* meta = qobj->metaObject();
	const char* signatureStr = sig.toLatin1();
	int i;
	for (i = 0; i < meta->methodCount(); i++) {
		QMetaMethod m = meta->method(i);
		if (m.methodType() == QMetaMethod::Signal &&
			strcmp(m.signature(), signatureStr) == 0)
			break;
	}
	
    Smoke::StackItem * result;
	EmitSignal signal(qobj, i, items, args, sp);
	signal.next();

	return true;
}

QMetaObject* parent_meta_object(void* obj) {
#ifdef DEBUG
printf("In make_metaObject()\n");
#endif
	smokeqyoto_object* o = value_obj_info(obj);
	Smoke::Index nameId = o->smoke->idMethodName("metaObject");
	Smoke::Index meth = o->smoke->findMethod(o->classId, nameId);
	if (meth <= 0) {
		// Should never happen..
		return 0;
	}

	Smoke::Method &methodId = o->smoke->methods[o->smoke->methodMaps[meth].method];
	Smoke::ClassFn fn = o->smoke->classes[methodId.classId].classFn;
	Smoke::StackItem i[1];
	(*fn)(methodId.method, o->ptr, i);
	return (QMetaObject*) i[0].s_voidp;
}

void* make_metaObject(void* obj, const char* stringdata, int stringdata_count, const uint* data, int data_count) {
	QMetaObject* parent = parent_meta_object(obj);

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

	printf(
	"\n // classinfo: key, value\n"
	"      %d,    %d\n",
	data[10], data[11]);

	int s = 12;
	bool signal_headings = true;
	bool slot_headings = true;

	for (uint j = 0; j < data[4]; j++) {
		if (signal_headings && (data[s + (j * 5) + 4] & 0x04)) {
			printf("\n // signals: signature, parameters, type, tag, flags\n");
			signal_headings = false;
		} 

		if (slot_headings && (data[s + (j * 5) + 4] & 0x08)) {
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
	smokeqyoto_object  * m = alloc_smokeqyoto_object(	true, 
														qt_Smoke, 
														qt_Smoke->idClass("QMetaObject"), 
														meta );
	
	// create wrapper C# instance
	return set_obj_info("Qyoto.QMetaObject", m);
}


int qt_metacall(void* obj, int _c, int _id, void* _o) {
	// get obj metaobject with a virtual call
	smokeqyoto_object* o = value_obj_info(obj);
    QObject *qobj = (QObject*)o->ptr;
	const QMetaObject *metaobject = qobj->metaObject();
	
	// get method count and offset
	int count = metaobject->methodCount();
	int offset = metaobject->methodOffset();

	// if id < offset call base version
	if (_id < offset || (*IsSmokeClass)(obj)) {
		// Assume the target slot is a C++ one
		Smoke::Index nameId = o->smoke->idMethodName("qt_metacall$$?");
		Smoke::Index meth = o->smoke->findMethod(o->classId, nameId);
		if(meth > 0) {
			Smoke::Method &m = o->smoke->methods[o->smoke->methodMaps[meth].method];
			Smoke::ClassFn fn = o->smoke->classes[m.classId].classFn;
			Smoke::StackItem i[4];
			i[1].s_enum = _c;
			i[2].s_int = _id;
			i[3].s_voidp = _o;
			(*fn)(m.method, o->ptr, i);
			return i[0].s_int;
		}

		// Should never happen..
		qFatal("Cannot find %s::qt_metacall() method\n", 
			o->smoke->classes[o->classId].className );
	}

	// return immediately if _c != QMetaObject::InvokeMetaMethod
    if (_c != QMetaObject::InvokeMetaMethod) {
		return _id;
	}

	// retrieve method signature from id
	QMetaMethod method = metaobject->method(_id);
	QString name(method.signature());
	QString type(method.typeName());
	
	if (method.methodType() == QMetaMethod::Signal) {
		metaobject->activate(qobj, _id, (void**) _o);
		return _id - (count - offset);
	}

	int items;
	MocArgument* mocArgs = GetMocArgumentsNumber(type, name, items);
	
	// invoke slot
	InvokeSlot slot(obj, method.signature(), items, mocArgs, (void**)_o);
	slot.next();
	
	delete mocArgs;
	return _id - count;
}

void
Init_qyoto()
{
    init_qt_Smoke();
    qt_Smoke->binding = new QyotoSmokeBinding(qt_Smoke);
    install_handlers(Qt_handlers);
    QString classPrefix("Qyoto.");
    QString className;
    QByteArray classStringName;

    for (int i = 1; i <= qt_Smoke->numClasses; i++) {
        className = classPrefix + qt_Smoke->classes[i].className;
//  printf("classname: %s id: %d\n", className.latin1(), i);
        classStringName = className.toLatin1();
        classname.insert(i, strdup(classStringName.constData()));
    }
}

void
DeleteQApp() {
	delete qApp;
}

}

