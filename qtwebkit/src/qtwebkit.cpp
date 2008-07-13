/***************************************************************************
                          qtwebkit.cpp  -  QtWebKit ruby extension
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
#include <smoke/qtwebkit_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_qtwebkit(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceQtWebKit(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler QtWebKit_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_qtwebkit();

void
Init_qtwebkit()
{
	init_qtwebkit_Smoke();
	qtwebkit_Smoke->binding = new QyotoSmokeBinding(qtwebkit_Smoke, &classNames);
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qtwebkit_Smoke->numClasses; i++) {
		className = prefix + qtwebkit_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "QtWebKit", resolve_classname_qtwebkit, IsContainedInstanceQtWebKit };
	qyoto_modules.insert(qtwebkit_Smoke, module);

    install_handlers(QtWebKit_handlers);
}

}
