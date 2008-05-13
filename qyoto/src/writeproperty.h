#ifndef WRITE_PROPERTY_H
#define WRITE_PROPERTY_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

class Q_DECL_EXPORT WriteProperty : public Marshall {
private:
	SmokeType* _type;
	Smoke::StackItem* _stack;
	Smoke::StackItem* _result;
public:
	WriteProperty(void* obj, const char* propertyName, void** o);

	~WriteProperty();

	inline SmokeType type() { return *_type; }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return *_stack; }
	inline Smoke::StackItem &var() { return *_result; }
	inline Smoke *smoke() { return type().smoke(); }
	inline bool cleanup() { return false; }

	void unsupported();
	void next();
};

#endif // WRITE_PROPERTY_H
