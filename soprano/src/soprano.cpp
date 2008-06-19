/***************************************************************************
                        soprano.cpp  -  description
                             -------------------
    begin                : Mon Sep 10 2007
    copyright            : (C) 2007 by Arno Rehn
    email                : arno@arnorehn.de
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#ifndef _GNU_SOURCE
#define _GNU_SOURCE
#endif

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <smoke/qt_smoke.h>
#include <smoke/soprano_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_Soprano(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceSoprano(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler Soprano_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_soprano();

void
Init_soprano()
{
	init_soprano_Smoke();
	soprano_Smoke->binding = new QyotoSmokeBinding(soprano_Smoke, &classNames);
	
	for (int i = 1; i <= soprano_Smoke->numClasses; i++) {
		QByteArray name(soprano_Smoke->classes[i].className);
		name.replace("::", ".");
		classNames.insert(i, strdup(name.constData()));
	}
	
	QyotoModule module = { "Soprano", resolve_classname_Soprano, IsContainedInstanceSoprano };
	qyoto_modules[soprano_Smoke] = module;

    install_handlers(Soprano_handlers);
}

}
