/***************************************************************************
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale
    email                : Richard_Dale@tipitina.demon.co.uk
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

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
