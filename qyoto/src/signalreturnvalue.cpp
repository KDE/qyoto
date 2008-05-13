#include "signalreturnvalue.h"
#include "qyoto.h"

SignalReturnValue::SignalReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType)
{
	_result = result;
	_replyType = replyType;
	_stack = new Smoke::StackItem[1];
	smokeStackFromQtStack(_stack, o, 1, _replyType);
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
}

void
SignalReturnValue::unsupported()
{
	qFatal("Cannot handle '%s' as signal reply-type", type().name());
}

void
SignalReturnValue::next() {}

SignalReturnValue::~SignalReturnValue()
{
	delete[] _stack;
}
