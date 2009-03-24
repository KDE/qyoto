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

#ifndef EMIT_SIGNAL_H
#define EMIT_SIGNAL_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

class QObject;

namespace Qyoto {

class Q_DECL_EXPORT EmitSignal : public Marshall {
private:
	QObject *_qobj;
	int _id;
	QList<MocArgument*> _args;
	Smoke::StackItem * _sp;
	int _items;
	int _cur;
	Smoke::Stack _stack;
	bool _called;
public:
	EmitSignal(QObject *qobj, int id, int items, QList<MocArgument*> args, Smoke::StackItem *sp);

	~EmitSignal();

	inline const MocArgument &arg() { return *_args[_cur + 1]; }
	inline SmokeType type() { return arg().st; }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return _stack[_cur]; }
	inline Smoke::StackItem &var() { return _sp[_cur + 1]; }

	void unsupported();

	inline Smoke *smoke() { return type().smoke(); }

	void emitSignal();

	void next();

	inline bool cleanup() { return true; }
};

}

#endif // EMIT_SIGNAL_H
