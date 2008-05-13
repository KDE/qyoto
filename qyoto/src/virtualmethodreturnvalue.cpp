#include "virtualmethodreturnvalue.h"
#include "qyoto.h"

VirtualMethodReturnValue::VirtualMethodReturnValue(Smoke *smoke, Smoke::Index meth, Smoke::Stack stack, Smoke::StackItem * retval) :
	_smoke(smoke), _method(meth), _stack(stack), _retval(retval) 
{
	_st.set(_smoke, method().ret);
	Marshall::HandlerFn fn = getMarshallFn(type());
	(*fn)(this);
}

void
VirtualMethodReturnValue::unsupported()
{
	qFatal("Cannot handle '%s' as return-type of virtual method %s::%s",
	        type().name(),
	        _smoke->className(method().classId),
	        _smoke->methodNames[method().name] );
}

void
VirtualMethodReturnValue::next() {}
