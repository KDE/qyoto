#ifndef SLOT_RETURN_VALUE_H
#define SLOT_RETURN_VALUE_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

class Q_DECL_EXPORT SlotReturnValue : public Marshall {
private:
	MocArgument * _replyType;
	Smoke::Stack _stack;
	Smoke::StackItem * _result;
public:
	SlotReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType);

	~SlotReturnValue();

	SmokeType type() { return _replyType[0].st; }
	Marshall::Action action() { return Marshall::FromObject; }
	Smoke::StackItem &item() { return _stack[0]; }
	Smoke::StackItem &var() { return *_result; }
	Smoke *smoke() { return type().smoke(); }
	bool cleanup() { return false; }

	void unsupported();
	void next();
};

#endif // SLOT_RETURN_VALUE_H
