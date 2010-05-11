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

#ifndef VIRTUAL_METHOD_CALL_H
#define VIRTUAL_METHOD_CALL_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

namespace Qyoto {

class Q_DECL_EXPORT VirtualMethodCall : public Marshall {
private:
	Smoke *_smoke;
	Smoke::Index _method;
	Smoke::Stack _stack;
	void * _obj;
	void * _overridenMethod;
	int _cur;
	Smoke::Index *_args;
	Smoke::Stack _sp;
	bool _called;
public:
	VirtualMethodCall(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, void * obj, void * overridenMethod);

	~VirtualMethodCall();

	inline SmokeType type() { return SmokeType(_smoke, _args[_cur]); }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[_cur + 1]; }
	inline Smoke::StackItem &var() { return _sp[_cur + 1]; }
	inline const Smoke::Method &method() { return _smoke->methods[_method]; }
	inline Smoke *smoke() { return _smoke; }
	inline bool cleanup() { return true; }

	void unsupported();
	void callMethod();
	void next();
};

}

#endif // VIRTUAL_METHOD_CALL_H
