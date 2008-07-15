/***************************************************************************
                          qtuitools.cpp  -  QtUiTools ruby extension
                             -------------------
    begin                : 14-07-2008
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
#include <smoke/qtuitools_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_qtuitools(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceQtUiTools(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler QtUiTools_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_qtuitools();

void
Init_qtuitools()
{
	init_qtuitools_Smoke();
	qtuitools_Smoke->binding = new QyotoSmokeBinding(qtuitools_Smoke, &classNames);
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qtuitools_Smoke->numClasses; i++) {
		className = prefix + qtuitools_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "QtUiTools", resolve_classname_qtuitools, IsContainedInstanceQtUiTools };
	qyoto_modules.insert(qtuitools_Smoke, module);

    install_handlers(QtUiTools_handlers);
}

}
