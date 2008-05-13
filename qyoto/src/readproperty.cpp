#include "readproperty.h"
#include "qyoto.h"

ReadProperty::ReadProperty(void* obj, const char* propertyName, void** o)
{
// 	_type = new SmokeType(qt_Smoke, qt_Smoke->idType("QVariant"));
// 	_stack = new Smoke::StackItem;
// 	_result = new Smoke::StackItem;
	
	// Get the C# property value
	void* variant = (*GetProperty)(obj, propertyName);
// 	_stack->s_voidp = variant;
	
	// FIXME
	// doesn't work, Mono throws 'System.ArgumentException: GCHandle value belongs to a different domain'
	// anyway, it's faster the way it's done now than with all the marshalling stuff
// 	Marshall::HandlerFn fn = getMarshallFn(type());
// 	(*fn)(this);
	
	// put the marshalled value into the void* array of qt_metacall()
	smokeqyoto_object* sqo = (smokeqyoto_object*) (*GetSmokeObject)(variant);
	o[0] = sqo->ptr; // _result->s_voidp;
}

void
ReadProperty::unsupported()
{
	qFatal("Cannot handle '%s' as property", type().name());
}

void
ReadProperty::next() {}

ReadProperty::~ReadProperty()
{
// 	delete _stack;
}
