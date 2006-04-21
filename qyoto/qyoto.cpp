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

#include <QtCore/qstring.h>
#include <QtCore/qhash.h>
#include <QtCore/qobject.h>
#include <QtCore/qbytearray.h>
#include <QtCore/qregexp.h>
#include <QtCore/qstringlist.h>

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

FromIntPtr FreeGCHandle;

static GetIntPtr GetSmokeObject;
static SetIntPtr SetSmokeObject;

static SetIntPtr MapPointer;
static FromIntPtr UnmapPointer;
static GetIntPtr GetPointerObject;

static OverridenMethodFn OverridenMethod;
static InvokeMethodFn InvokeMethod;
static CreateInstanceFn CreateInstance;

// Maps from a classname in the form Qt::Widget to an int id
QHash<int,char *> classname;

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
//	void * obj = (*CreateInstance)(className);
//	(*SetSmokeObject)(obj, o);
//	return obj;
	return 0;
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
/*
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
		qFatal("Cannot handle '%s' as signal argument", type().name());
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

class InvokeSlot : public Marshall {
    void * _obj;
    char * _slotname;
    int _items;
    MocArgument *_args;
    QUObject *_o;
    int _cur;
    bool _called;
    Smoke::StackItem *_sp;
    Smoke::Stack _stack;
public:
    const MocArgument &arg() { return _args[_cur]; }
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
	for (int i = 0; i < _items; i++) {
		QUObject *o = _o + i + 1;
		switch(_args[i].argType) {
		case xmoc_bool:
			_stack[i].s_bool = static_QUType_bool.get(o);
			break;
		case xmoc_int:
			_stack[i].s_int = static_QUType_int.get(o);
			break;
		case xmoc_double:
			_stack[i].s_double = static_QUType_double.get(o);
			break;
		case xmoc_charstar:
			_stack[i].s_voidp = static_QUType_charstar.get(o);
			break;
		case xmoc_QString:
			_stack[i].s_voidp = &static_QUType_QString.get(o);
			break;
		default:	// case xmoc_ptr:
		{
			const SmokeType &t = _args[i].st;
			void *p = static_QUType_ptr.get(o);
			switch(t.elem()) {
			case Smoke::t_bool:
				_stack[i].s_bool = *(bool*)p;
				break;
			case Smoke::t_char:
				_stack[i].s_char = *(char*)p;
				break;
			case Smoke::t_uchar:
				_stack[i].s_uchar = *(unsigned char*)p;
				break;
			case Smoke::t_short:
				_stack[i].s_short = *(short*)p;
				break;
			case Smoke::t_ushort:
				_stack[i].s_ushort = *(unsigned short*)p;
				break;
			case Smoke::t_int:
				_stack[i].s_int = *(int*)p;
				break;
			case Smoke::t_uint:
				_stack[i].s_uint = *(unsigned int*)p;
				break;
			case Smoke::t_long:
				_stack[i].s_long = *(long*)p;
				break;
			case Smoke::t_ulong:
				_stack[i].s_ulong = *(unsigned long*)p;
				break;
			case Smoke::t_float:
				_stack[i].s_float = *(float*)p;
				break;
			case Smoke::t_double:
				_stack[i].s_double = *(double*)p;
				break;
			case Smoke::t_enum:
			{
				Smoke::EnumFn fn = SmokeClass(t).enumFn();
			    if (!fn) {
					qFatal("Unknown enumeration %s\n", t.name());
					_stack[i].s_enum = *(int*)p;
					break;
			    }
			    Smoke::Index id = t.typeId();
			    (*fn)(Smoke::EnumToLong, id, p, _stack[i].s_enum);
			}
			break;
			case Smoke::t_class:
			case Smoke::t_voidp:
				_stack[i].s_voidp = p;
				break;
		    }
		}
	}
	}
	}
	void invokeSlot() {
		if (_called) return;
		_called = true;
//		(void) rb_funcall2(_obj, _slotname, _items, _sp);
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

    InvokeSlot(void * obj, char * slotname, int items, MocArgument * args, QUObject *o) :
    _obj(obj), _slotname(slotname), _items(items), _args(args), _o(o), _cur(-1), _called(false)
    {
		_sp = new Smoke::StackItem[_items];
		_stack = new Smoke::StackItem[_items];
		copyArguments();
    }

	~InvokeSlot() {
		delete[] _stack;
		delete[] _sp;
		(*FreeGCHandle)(_obj);
	}
};
*/
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

void 
AddFreeGCHandle(FromIntPtr callback)
{
	FreeGCHandle = callback;
}

void 
AddGetSmokeObject(GetIntPtr callback)
{
	GetSmokeObject = callback;
}

void 
AddSetSmokeObject(SetIntPtr callback)
{
	SetSmokeObject = callback;
}

void 
AddMapPointer(SetIntPtr callback)
{
	MapPointer = callback;
}

void 
AddUnmapPointer(FromIntPtr callback)
{
	UnmapPointer = callback;
}

void 
AddGetPointerObject(GetIntPtr callback)
{
	GetPointerObject = callback;
}

void 
AddOverridenMethod(OverridenMethodFn callback)
{
	OverridenMethod = callback;
}

void 
AddInvokeMethod(InvokeMethodFn callback)
{
	InvokeMethod = callback;
}

void 
AddCreateInstance(CreateInstanceFn callback)
{
	CreateInstance = callback;
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

MocArgument *
GetMocArguments(QString member) 
{
	QRegExp rx1("^.*\\((.*)\\)$");
	QRegExp rx2("^(bool|int|double|char\\*|QString)&?$");
	int match = rx1.indexIn(member);
	if (match == -1) {
		return 0;
	}

	QString argStr = rx1.cap(1);
//	printf("argStr: %s\n", argStr.latin1());
	QStringList args = argStr.split(",");
	MocArgument * mocargs = new MocArgument[args.size() + 1];
	int i = 0;
	for (QStringList::Iterator it = args.begin(); it != args.end(); ++it) {
		QString a = (*it);
		a.replace(QRegExp("^const\\s+"), "");
		a = (rx2.indexIn(a) == -1) ? "ptr" : rx2.cap(1);
//		printf("arg: %s a: %s\n", (*it).latin1(), a.latin1());
                QByteArray name = (*it).toLatin1();
                QByteArray static_type = a.toLatin1();
		bool valid = setMocType(mocargs, i, name.constData(), static_type.constData());
		i++;
    }

	return mocargs;
}
/*
bool
SignalEmit(char * signature, void * obj, Smoke::StackItem * sp, int items)
{
#ifdef DEBUG
	printf("ENTER SignalEmit(signature: %s target: 0x%8.8x items: %d)\n", signature, obj, items);
#endif

	smokeqyoto_object *o = value_obj_info(obj);
    QObject *qobj = (QObject*)o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject"));
    
	if (qobj->signalsBlocked()) {
		return false;
	}

	QString sig(signature);
	sig.replace(QRegExp("^void "), "");
	MocArgument * args = GetMocArguments(sig);
	QStrList signalNames = qobj->metaObject()->signalNames(true);

    char * signalStr = 0;
	const char * signatureStr = sig.latin1();
	int index;

    for (	signalStr = signalNames.first(), index = 0; 
			signalStr != 0; 
			signalStr = signalNames.next(), index++ ) 
	{
		if (strcmp(signalStr, signatureStr) == 0) {
			break;
		}
	}

//	printf("signal id: %d\n", index);

    EmitSignal signal(qobj, index, items, args, sp);
    signal.next();
#ifdef DEBUG
	printf("LEAVE SignalEmit()\n");
#endif

	return true;
}

static QUParameter *
make_QUParameter(char * name, char * type, int inout)
{
    QUParameter *p = new QUParameter;
    p->name = new char[strlen(name) + 1];
    strcpy((char*)p->name, name);
    if(strcmp(type, "bool") == 0)
	p->type = &static_QUType_bool;
    else if(strcmp(type, "int") == 0)
	p->type = &static_QUType_int;
    else if(strcmp(type, "double") == 0)
	p->type = &static_QUType_double;
    else if(strcmp(type, "char*") == 0 || strcmp(type, "const char*") == 0)
	p->type = &static_QUType_charstar;
    else if(strcmp(type, "QString") == 0 || strcmp(type, "QString&") == 0 ||
	    strcmp(type, "const QString") == 0 || strcmp(type, "const QString&") == 0)
	p->type = &static_QUType_QString;
    else
	p->type = &static_QUType_ptr;
    // Lacking support for several types. Evil.
    p->inOut = inout;
    p->typeExtra = 0;
//    return Data_Wrap_Struct(rb_cObject, 0, 0, p);
    return p;
}

static QMetaData *
make_QMetaData(char * name, void * method)
{
    QMetaData *m = new QMetaData;		// will be deleted
    m->name = new char[strlen(name) + 1];
    strcpy((char*)m->name, name);
//    Data_Get_Struct(method, QUMethod, m->method);
    m->access = QMetaData::Public;
//    return Data_Wrap_Struct(rb_cObject, 0, 0, m);
    return m;
}

static QUMethod *
make_QUMethod(char * name, int count, QUParameter * p)
{
	QUMethod *m = new QUMethod;			// permanent memory allocation
	m->name = new char[strlen(name) + 1];	// this too
	strcpy((char*)m->name, name);
	m->parameters = 0;
	m->count = count;

	if (m->count > 0) {
		m->parameters = new QUParameter[m->count];
		for (long i = 0; i < m->count; i++) {
//	    VALUE param = rb_ary_entry(params, i);
//	    QUParameter *p = 0;
//	    Data_Get_Struct(param, QUParameter, p);
			((QUParameter *) m->parameters)[i] = *p;
			delete p;
			p++;
		}
	}
//    return Data_Wrap_Struct(rb_cObject, 0, 0, m);
	return m;
}

static QMetaData *
make_QMetaData_tbl(long count, QMetaData * old)
{
//    long count = RARRAY(list)->len;
	QMetaData *m = new QMetaData[count];

	for (long i = 0; i < count; i++) {
//	VALUE item = rb_ary_entry(list, i);

//	QMetaData *old = 0;
//	Data_Get_Struct(item, QMetaData, old);
		m[i] = *old;
		delete old;
		old++;
	}

//    return Data_Wrap_Struct(rb_cObject, 0, 0, m);
    return m;
}

static void *
make_metaObject(char * className, QMetaObject* parent, QMetaData * slot_tbl, int slot_count, QMetaData * signal_tbl, int signal_count)
{
	QMetaObject *meta = QMetaObject::new_metaobject(
	className, parent,
	(const QMetaData*)slot_tbl, slot_count,	// slots
	(const QMetaData*)signal_tbl, signal_count,	// signals
	0, 0,	// properties
	0, 0,	// enums
	0, 0);

    smokeqyoto_object * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
    o->smoke = qt_Smoke;
    o->classId = qt_Smoke->idClass("QMetaObject");
    o->ptr = meta;
    o->allocated = true;

//    return Data_Wrap_Struct(qt_qmetaobject_class, smokeruby_mark, smokeruby_free, o);
	return set_obj_info("QMetaObject", o);
}
*/
void
Init_qyoto()
{
    init_qt_Smoke();
    qt_Smoke->binding = new QyotoSmokeBinding(qt_Smoke);
    install_handlers(Qt_handlers);
    QString classPrefix("Qt.");
    QString className;
    QByteArray classStringName;

    for (int i = 1; i <= qt_Smoke->numClasses; i++) {
        className = classPrefix + qt_Smoke->classes[i].className;
//  printf("classname: %s id: %d\n", className.latin1(), i);
        classStringName = className.toLatin1();
        classname.insert(i, strdup(classStringName.constData()));
    }
}

}

