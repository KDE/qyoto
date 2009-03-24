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

#ifndef METHOD_RETURN_VALUE_H
#define METHOD_RETURN_VALUE_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

namespace Qyoto {

class Q_DECL_EXPORT MethodReturnValue : public Marshall {
private:
	Smoke *_smoke;
	Smoke::Index _method;
	Smoke::StackItem * _retval;
	Smoke::Stack _stack;
public:
	MethodReturnValue(Smoke *smoke, Smoke::Index method, Smoke::Stack stack, Smoke::StackItem * retval);

	inline const Smoke::Method &method() { return _smoke->methods[_method]; }
	inline SmokeType type() { return SmokeType(_smoke, method().ret); }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[0]; }
	inline Smoke::StackItem &var() { return *_retval; }
	inline Smoke *smoke() { return _smoke; }
	inline bool cleanup() { return false; }

	void unsupported();
	void next();
};

}

#endif // METHOD_RETURN_VALUE_H
