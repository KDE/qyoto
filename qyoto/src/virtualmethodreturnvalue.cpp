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

#include "virtualmethodreturnvalue.h"
#include "qyoto.h"

namespace Qyoto {

VirtualMethodReturnValue::VirtualMethodReturnValue(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, Smoke::StackItem * retval) :
	_smoke(smoke), _method(meth), _stack(stack), _retval(retval) 
{
	_st.set(_smoke, method().ret);
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
}

void
VirtualMethodReturnValue::unsupported()
{
	qFatal("Cannot handle '%s' as return-type of virtual method %s::%s",
	        type().name(),
	        _smoke->className(method().classId),
	        _smoke->methodNames[method().name] );
}

void
VirtualMethodReturnValue::next() {}

}
