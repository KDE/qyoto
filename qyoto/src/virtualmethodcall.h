#ifndef VIRTUAL_METHOD_CALL_H
#define VIRTUAL_METHOD_CALL_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

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
	inline bool cleanup() { return false; }   // is this right?

	void unsupported();
	void callMethod();
	void next();
};

#endif // VIRTUAL_METHOD_CALL_H
