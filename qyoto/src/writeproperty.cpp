#include "writeproperty.h"
#include "qyoto.h"
#include <qt_smoke.h>

WriteProperty::WriteProperty(void* obj, const char* propertyName, void** o)
{
	_stack = new Smoke::StackItem;
	_result = new Smoke::StackItem;
	
	_stack->s_voidp = o[0];
	
	smokeqyoto_object* sqo = alloc_smokeqyoto_object(false, qt_Smoke, qt_Smoke->idClass("QVariant").index, _stack->s_voidp);
	void* variant = (*CreateInstance)("Qyoto.QVariant", sqo);
	
	// Set the C# property value
	(*SetProperty)(obj, propertyName, variant);
}

void
WriteProperty::unsupported()
{
	qFatal("Cannot handle '%s' as property", type().name());
}

void
WriteProperty::next() {}

WriteProperty::~WriteProperty() {
// 	delete _stack;
}
