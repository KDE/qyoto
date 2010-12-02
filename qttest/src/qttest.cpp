/***************************************************************************
                          qttest.cpp  -  QtTest ruby extension
                             -------------------
    begin                : 02-11-2008
    copyright            : (C) 2008 by Richard Dale
    email                : richard.j.dale@gmail.com
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <smoke/qt/qttest_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_qttest(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceQtTest(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler QtTest_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_qttest();

static Qyoto::Binding binding;

void
Init_qttest()
{
	init_qttest_Smoke();
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qttest_Smoke->numClasses; i++) {
		className = prefix + qttest_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	binding = Qyoto::Binding(qttest_Smoke, &classNames);
	QyotoModule module = { "QtTest", resolve_classname_qttest, IsContainedInstanceQtTest, &binding };
	qyoto_modules.insert(qttest_Smoke, module);

	qyoto_install_handlers(QtTest_handlers);
}

}
