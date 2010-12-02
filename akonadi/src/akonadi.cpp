/***************************************************************************
                          akonadi.cpp  -  Akonadi ruby extension
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
#include <smoke/kde/akonadi_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_akonadi(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceAkonadi(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler Akonadi_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_akonadi();

static Qyoto::Binding binding;

void
Init_akonadi()
{
	init_akonadi_Smoke();
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= akonadi_Smoke->numClasses; i++) {
		className = prefix + akonadi_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	binding = Qyoto::Binding(akonadi_Smoke, &classNames);
	QyotoModule module = { "Akonadi", resolve_classname_akonadi, IsContainedInstanceAkonadi, &binding };
	qyoto_modules.insert(akonadi_Smoke, module);

    qyoto_install_handlers(Akonadi_handlers);
}

}
