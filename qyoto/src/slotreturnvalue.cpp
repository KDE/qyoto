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

#include <QtDBus>

#include "slotreturnvalue.h"
#include "qyoto.h"

namespace Qyoto {

SlotReturnValue::SlotReturnValue(void ** o, Smoke::StackItem * result, QList<MocArgument*> replyType)
{
	_result = result;
	_replyType = replyType;
	_stack = new Smoke::StackItem[1]; 
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
	
	QByteArray t(type().name());
	t.replace("const ", "");
	t.replace("&", "");
	if (t == "QDBusVariant") {
		*reinterpret_cast<QDBusVariant*>(o[0]) = *(QDBusVariant*) _stack[0].s_class;
	} else {
		// Save any address in zeroth element of the arrary of 'void*'s passed to 
		// qt_metacall()
		void * ptr = o[0];
		smokeStackToQtStack(_stack, o, 0, 1, _replyType);
		// Only if the zeroth element of the array of 'void*'s passed to qt_metacall()
		// contains an address, is the return value of the slot needed.
		if (ptr != 0) {
			*(void**)ptr = *(void**)(o[0]);
		}
	}
}

void
SlotReturnValue::unsupported() 
{
	qFatal("Cannot handle '%s' as slot reply-type", type().name());
}

void
SlotReturnValue::next() {}

SlotReturnValue::~SlotReturnValue() {
	delete[] _stack;
}

}
