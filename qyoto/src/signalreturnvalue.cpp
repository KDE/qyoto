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

#include "signalreturnvalue.h"
#include "qyoto.h"

namespace Qyoto {

SignalReturnValue::SignalReturnValue(void ** o, Smoke::StackItem * result, QList<MocArgument*> replyType)
{
	_result = result;
	_replyType = replyType;
	_stack = new Smoke::StackItem[1];
	smokeStackFromQtStack(_stack, o, 0, 1, _replyType);
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
}

void
SignalReturnValue::unsupported()
{
	qFatal("Cannot handle '%s' as signal reply-type", type().name());
}

void
SignalReturnValue::next() {}

SignalReturnValue::~SignalReturnValue()
{
	delete[] _stack;
}

}
