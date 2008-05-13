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

#include "emitsignal.h"

#include "qyoto.h"
#include "signalreturnvalue.h"

EmitSignal::EmitSignal(QObject *qobj, int id, int items, MocArgument * args, Smoke::StackItem *sp) :
	_qobj(qobj), _id(id), _args(args), _sp(sp), _items(items),
	_cur(-1), _called(false)
{
	_stack = new Smoke::StackItem[_items];
}

EmitSignal::~EmitSignal() {
	delete[] _stack;
	delete[] _args;
}

void
EmitSignal::unsupported()
{
	qFatal("Cannot handle '%s' as signal argument", type().name());
}

void
EmitSignal::emitSignal() {
	if (_called) return;
	_called = true;

	void** o = new void*[_items + 1];
	smokeStackToQtStack(_stack, o + 1, _items, _args + 1);
	_qobj->metaObject()->activate(_qobj, _id, o);

	if (_args[0].argType != xmoc_void)
		SignalReturnValue r(o, _sp, _args);

	delete[] o;
}

void
EmitSignal::next() {
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
