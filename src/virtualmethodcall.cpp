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

#include "virtualmethodcall.h"
#include "qyoto.h"
#include "callbacks.h"
#include "virtualmethodreturnvalue.h"

namespace Qyoto {

VirtualMethodCall::VirtualMethodCall(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, void *obj, void *overridenMethod) :
	_smoke(smoke), _method(meth), _stack(stack), _obj(obj),
	 _overridenMethod(overridenMethod), _cur(-1), _sp(0), _called(false) 
{
	_sp = new Smoke::StackItem[method().numArgs + 1];
	_args = _smoke->argumentList + method().args;
}

VirtualMethodCall::~VirtualMethodCall() {
	delete[] _sp;
	(*FreeGCHandle)(_obj);
	(*FreeGCHandle)(_overridenMethod);
}

void
VirtualMethodCall::unsupported() {
	qFatal("Cannot handle '%s' as argument of virtual method %s::%s",
	        type().name(),
	        _smoke->className(method().classId),
	        _smoke->methodNames[method().name] );
}

void
VirtualMethodCall::callMethod() {
	if (_called) return;
	_called = true;
	
	(*InvokeMethod)(_obj, _overridenMethod, _sp);
	Smoke::StackItem * _retval = _sp;
	VirtualMethodReturnValue r(_smoke, _method, _stack, _retval);
}

void
VirtualMethodCall::next() {
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

}
