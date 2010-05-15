/***************************************************************************
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

#include "methodcall.h"
#include "qyoto.h"
#include "callbacks.h"
#include "methodreturnvalue.h"

namespace Qyoto {

MethodCall::MethodCall(Smoke *smoke, Smoke::Index method, void * target, Smoke::Stack sp, int items) :
	_cur(-1), _smoke(smoke), _method(method), _target(target), _o(0), _sp(sp), _items(items), _called(false)
{
	if (!isConstructor() && !isStatic()) {
		_o = (smokeqyoto_object*) (*GetSmokeObject)(_target);
		if (_o != 0 && _o->ptr != 0) {
			if (	isDestructor() 
					&& (!_o->allocated || IsContainedInstance(_o)
					    || _o->smoke->isDerivedFrom(_o->smoke->className(_o->classId), "QCoreApplication")) )
			{
				_called = true;
			}
		} else {
			// not a constructor, not static, pointer invalid -> object already destroyed
			_called = true;
		}
	}

	_args = _smoke->argumentList + _smoke->methods[_method].args;
	_items = _smoke->methods[_method].numArgs;
	numItems = items;
	_stack = new Smoke::StackItem[items + 1];
	_retval = _sp;
}

MethodCall::~MethodCall() { delete[] _stack; }

void MethodCall::unsupported()
{
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

void MethodCall::callMethod()
{
	if (_called) return;
	_called = true;
	Smoke::ClassFn fn = _smoke->classes[method().classId].classFn;
	void *ptr = 0;

	if (_o != 0 && _o->ptr != 0) {
		const Smoke::Class &cl = _smoke->classes[method().classId];

		ptr = _o->smoke->cast(	_o->ptr,
								_o->classId,
								_o->smoke->idClass(cl.className, true).index );
	}
	_items = -1;
	
	/*
	 * special case the QApplication/QCoreApplication constructor call
	 * the int reference has to stay valid all the time, so create an additional pointer here
	 */
	if (isConstructor() && (   strcmp(_smoke->methodNames[method().name], "QApplication") == 0
				|| strcmp(_smoke->methodNames[method().name], "QCoreApplication") == 0)) {
		int* i = new int(_sp[1].s_int);
		_stack[1].s_voidp = i;
	}
	
	(*fn)(method().method, ptr, _stack);
	
	if (isConstructor()) {
		Smoke::StackItem _s[2];
		_s[1].s_class = qyoto_modules[_smoke].binding;
		fn(0, _stack[0].s_voidp, _s);
		_o = alloc_smokeqyoto_object(true, _smoke, method().classId, _stack[0].s_voidp);
		(*SetSmokeObject)(_target, _o);
		mapPointer(_target, _o, _o->classId, 0);
	} else if (isDestructor()) {
		void *check = (*GetSmokeObject)(_target);
		if (check) {
			unmapPointer(_o, _o->classId, 0);
			(*SetSmokeObject)(_target, 0);
			free_smokeqyoto_object(_o);
		}
	} else {
		Qyoto::MethodReturnValue r(_smoke, _method, _stack, _retval);
	}
}

void MethodCall::next()
{
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

}
