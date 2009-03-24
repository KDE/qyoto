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

#ifndef SIGNAL_RETURN_VALUE_H
#define SIGNAL_RETURN_VALUE_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

namespace Qyoto {

/*
	Converts a C++ value returned by a signal invocation to a C# 
	reply type
*/
class Q_DECL_EXPORT SignalReturnValue : public Marshall {
private:
	QList<MocArgument*> _replyType;
	Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SignalReturnValue(void ** o, Smoke::StackItem * result, QList<MocArgument*> replyType);

	~SignalReturnValue();

	inline SmokeType type() { return _replyType[0]->st; }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[0]; }
	inline Smoke::StackItem &var() { return *_result; }
	inline Smoke *smoke() { return type().smoke(); }
	inline bool cleanup() { return false; }
	
	void unsupported();
	void next();
};

}

#endif // SIGNAL_RETURN_VALUE_H
