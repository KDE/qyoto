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
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <smoke/qtscript_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_qtscript(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceQtScript(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler QtScript_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_qtscript();

static Qyoto::Binding binding;

void
Init_qtscript()
{
	init_qtscript_Smoke();
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qtscript_Smoke->numClasses; i++) {
		className = prefix + qtscript_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	binding = Qyoto::Binding(qtscript_Smoke, &classNames);
	QyotoModule module = { "QtScript", resolve_classname_qtscript, IsContainedInstanceQtScript, &binding };
	qyoto_modules.insert(qtscript_Smoke, module);

    qyoto_install_handlers(QtScript_handlers);
}

}
