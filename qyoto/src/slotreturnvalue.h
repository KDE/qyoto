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

#ifndef SLOT_RETURN_VALUE_H
#define SLOT_RETURN_VALUE_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

namespace Qyoto {

class Q_DECL_EXPORT SlotReturnValue : public Marshall {
private:
	QList<MocArgument*> _replyType;
	Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SlotReturnValue(void ** o, Smoke::StackItem * result, QList<MocArgument*> replyType);

	~SlotReturnValue();

	SmokeType type() { return _replyType[0]->st; }
	Marshall::Action action() { return Marshall::FromObject; }
	Smoke::StackItem &item() { return _stack[0]; }
	Smoke::StackItem &var() { return *_result; }
	Smoke *smoke() { return type().smoke(); }
	bool cleanup() { return false; }

	void unsupported();
	void next();
};

}

#endif // SLOT_RETURN_VALUE_H
