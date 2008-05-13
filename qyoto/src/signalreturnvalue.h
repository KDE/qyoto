#ifndef SIGNAL_RETURN_VALUE_H
#define SIGNAL_RETURN_VALUE_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

/*
	Converts a C++ value returned by a signal invocation to a C# 
	reply type
*/
class Q_DECL_EXPORT SignalReturnValue : public Marshall {
private:
	MocArgument * _replyType;
	Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SignalReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType);

	~SignalReturnValue();

	inline SmokeType type() { return _replyType[0].st; }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[0]; }
	inline Smoke::StackItem &var() { return *_result; }
	inline Smoke *smoke() { return type().smoke(); }
	inline bool cleanup() { return false; }
	
	void unsupported();
	void next();
};


#endif // SIGNAL_RETURN_VALUE_H
