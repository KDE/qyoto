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

#include "writeproperty.h"
#include "qyoto.h"
#include <qt_smoke.h>

WriteProperty::WriteProperty(void* obj, const char* propertyName, void** o)
{
	smokeqyoto_object* sqo = alloc_smokeqyoto_object(false, qt_Smoke, qt_Smoke->idClass("QVariant").index, o[0]);
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
}
