#ifndef VIRTUAL_METHOD_RETURN_VALUE_H
#define VIRTUAL_METHOD_RETURN_VALUE_H

#include <smoke.h>
#include "smokeqyoto.h"
#include "marshall.h"

class Q_DECL_EXPORT VirtualMethodReturnValue : public Marshall {
private:
	Smoke *_smoke;
	Smoke::Index _method;
	Smoke::Stack _stack;
	SmokeType _st;
	Smoke::StackItem * _retval;
public:
	VirtualMethodReturnValue(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, Smoke::StackItem * retval);

	inline const Smoke::Method &method() { return _smoke->methods[_method]; }
	inline SmokeType type() { return _st; }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return _stack[0]; }
	inline Smoke::StackItem &var() { return *_retval; }
	inline Smoke *smoke() { return _smoke; }
	inline bool cleanup() { return false; }

	void unsupported();
	void next();
};

#endif // VIRTUAL_METHOD_RETURN_VALUE_H
