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

#include "emitsignal.h"

#include "qyoto.h"
#include "signalreturnvalue.h"

namespace Qyoto {

EmitSignal::EmitSignal(QObject *qobj, int id, int items, QList<MocArgument*> args, Smoke::StackItem *sp) :
	_qobj(qobj), _id(id), _args(args), _sp(sp),
	_cur(-1), _called(false)
{
	_items = args.count();
	_stack = new Smoke::StackItem[_items];
}

EmitSignal::~EmitSignal() {
	delete[] _stack;
	foreach (MocArgument * arg, _args) {
		delete arg;
	}
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

	void** o = new void*[_items];
	smokeStackToQtStack(_stack, o + 1, 1, _items, _args);
	_qobj->metaObject()->activate(_qobj, _id, o);

	if (_args[0]->argType != xmoc_void) {
		SignalReturnValue r(o, _sp, _args);
	}

	delete[] o;
}

void
EmitSignal::next() {
	int oldcur = _cur;
	_cur++;

	while(!_called && _cur < _items - 1) {
		Marshall::HandlerFn fn = getMarshallFn(type());
		(*fn)(this);
		_cur++;
	}

	emitSignal();
	_cur = oldcur;
}

}
