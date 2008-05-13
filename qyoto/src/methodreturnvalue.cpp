#include "methodreturnvalue.h"
#include "qyoto.h"

MethodReturnValue::MethodReturnValue(Smoke *smoke, Smoke::Index method, Smoke::Stack stack, Smoke::StackItem * retval) :
	_smoke(smoke), _method(method), _retval(retval), _stack(stack)
{
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
}

void
MethodReturnValue::unsupported()
{
	qFatal("Cannot handle '%s' as return-type of %s::%s",
	       type().name(),
	       strcmp(_smoke->className(method().classId), "QGlobalSpace") == 0 ? "" : _smoke->className(method().classId),
	       _smoke->methodNames[method().name] );
}

void
MethodReturnValue::next() {}
