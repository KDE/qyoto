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

#ifndef METHOD_CALL_H
#define METHOD_CALL_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

struct smokeqyoto_object;

namespace Qyoto {

class Q_DECL_EXPORT MethodCall : public Marshall {
private:
	int _cur;
	Smoke *_smoke;
	Smoke::Stack _stack;
	Smoke::Index _method;
	Smoke::Index *_args;
	void * _target;
	smokeqyoto_object * _o;
	Smoke::Stack _sp;
	int _items;
	int numItems;
	Smoke::StackItem * _retval;
	bool _called;
public:
	MethodCall(Smoke *smoke, Smoke::Index method, void * target, Smoke::Stack sp, int items);
	~MethodCall();

	inline SmokeType type() { return SmokeType(_smoke, _args[_cur]); }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return _stack[_cur + 1]; }
	inline Smoke::StackItem &var() {
		if (_cur < 0) return *_retval;
		return _sp[_cur + 1];
	}
	inline const Smoke::Method &method() { return _smoke->methods[_method]; }
	inline Smoke *smoke() { return _smoke; }
	inline bool cleanup() { return true; }

	inline bool isConstructor() { return method().flags & Smoke::mf_ctor; }
	inline bool isDestructor() { return method().flags & Smoke::mf_dtor; }
	inline bool isStatic() { return method().flags & Smoke::mf_static; }

	void unsupported();

	void callMethod();
	void next();
};

}

#endif // METHOD_CALL_H
