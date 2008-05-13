/***************************************************************************
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

#include "invokeslot.h"

#include "qyoto.h"
#include "slotreturnvalue.h"

InvokeSlot::InvokeSlot(void * obj, const char * slotname, int items, MocArgument * args, void** o) :
	_obj(obj), _slotname(slotname), _items(items), _args(args), _o(o), _cur(-1), _called(false)
{
	_sp = new Smoke::StackItem[_items];
	_stack = new Smoke::StackItem[_items];
	_mocret = args;
	copyArguments();
}

void
InvokeSlot::unsupported()
{
	qFatal("Cannot handle '%s' as slot argument\n", type().name());
}

void
InvokeSlot::copyArguments()
{
	smokeStackFromQtStack(_stack, _o + 1, _items, _args + 1);
}

void
InvokeSlot::invokeSlot()
{
	if (_called) return;
	_called = true;
	Smoke::StackItem* ret = new Smoke::StackItem[1];
	(*InvokeCustomSlot)(_obj, _slotname, _sp, ret);
	
	if (_mocret[0].argType != xmoc_void) {
		SlotReturnValue r(_o, ret, _mocret);
	}
	delete[] ret;
}

void
InvokeSlot::next()
{
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

InvokeSlot::~InvokeSlot() {
	delete[] _stack;
	delete[] _sp;
	delete[] _args;
}
