#include "slotreturnvalue.h"
#include "qyoto.h"

SlotReturnValue::SlotReturnValue(void ** o, Smoke::StackItem * result, MocArgument * replyType)
{
	_result = result;
	_replyType = replyType;
	_stack = new Smoke::StackItem[1]; 
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
	// Save any address in zeroth element of the arrary of 'void*'s passed to 
	// qt_metacall()
	void * ptr = o[0];
	smokeStackToQtStack(_stack, o, 1, _replyType);

	// Only if the zeroth element of the arrary of 'void*'s passed to qt_metacall()
	// contains an address, is the return value of the slot needed.
	if (ptr != 0) {
		*(void**)ptr = *(void**)(o[0]);
	}
}

void
SlotReturnValue::unsupported() 
{
	qFatal("Cannot handle '%s' as slot reply-type", type().name());
}

void
SlotReturnValue::next() {}

SlotReturnValue::~SlotReturnValue() {
	delete[] _stack;
}
