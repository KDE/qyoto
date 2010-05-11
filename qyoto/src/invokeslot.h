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

#ifndef INVOKE_SLOT_H
#define INVOKE_SLOT_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

namespace Qyoto {

class Q_DECL_EXPORT InvokeSlot : public Marshall {
private:
	void * _obj;
	const char * _slotname;
	int _items;
	QList<MocArgument*> _args;
	void **_o;
	int _cur;
	bool _called;
	Smoke::StackItem *_sp;
	Smoke::Stack _stack;
public:
	InvokeSlot(void * obj, const char * slotname, QList<MocArgument*> args, void** o);

	~InvokeSlot();

	inline const MocArgument &arg() { return *_args[_cur + 1]; }
	inline SmokeType type() { return arg().st; }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[_cur]; }
	inline Smoke::StackItem &var() { return _sp[_cur]; }
	inline Smoke *smoke() { return type().smoke(); }

	inline bool cleanup() { return true; }
	void unsupported();
	void copyArguments();
	void invokeSlot();
	void next();
};

}

#endif // INVOKE_SLOT_H
