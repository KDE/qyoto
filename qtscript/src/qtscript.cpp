/***************************************************************************
                          qtscript.cpp  -  QtScript ruby extension
                             -------------------
    begin                : 13-07-2008
    copyright            : (C) 2008 by Richard Dale
    email                : richard.j.dale@gmail.com
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <smoke/qt_smoke.h>
#include <smoke/qtscript_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_qtscript(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceQtScript(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern "C" {

extern Q_DECL_EXPORT void Init_qtscript();

void
Init_qtscript()
{
	init_qtscript_Smoke();
	qtscript_Smoke->binding = new QyotoSmokeBinding(qtscript_Smoke, &classNames);
	QString prefix("QtScript.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qtscript_Smoke->numClasses; i++) {
		className = prefix + qtscript_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "QtScript", resolve_classname_qtscript, IsContainedInstanceQtScript };
	qyoto_modules.insert(qtscript_Smoke, module);
}

}
