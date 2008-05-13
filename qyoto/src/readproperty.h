#ifndef READ_PROPERTY_H
#define READ_PROPERTY_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

class Q_DECL_EXPORT ReadProperty : public Marshall {
private:
	SmokeType* _type;
	Smoke::StackItem* _stack;
	Smoke::StackItem* _result;
public:
	ReadProperty(void* obj, const char* propertyName, void** o);
	~ReadProperty();

	inline SmokeType type() { return *_type; }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return *_stack; }
	inline Smoke::StackItem &var() { return *_result; }
	inline Smoke *smoke() { return type().smoke(); }
	inline bool cleanup() { return false; }
	
	void unsupported();
	void next();
};


#endif // READ_PROPERTY_H
