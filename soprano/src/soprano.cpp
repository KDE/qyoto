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
resolve_classname_Soprano(Smoke* smoke, int classId, void* /*ptr*/)
{
	return smoke->binding->className(classId);
}

bool
IsContainedInstanceSoprano(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern "C" {

extern Q_DECL_EXPORT void Init_soprano();

void
Init_soprano()
{
	init_soprano_Smoke();
	soprano_Smoke->binding = new QyotoSmokeBinding(soprano_Smoke, &classNames);
	QString prefix("Soprano.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= soprano_Smoke->numClasses; i++) {
		className = prefix + soprano_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "Soprano", resolve_classname_Soprano, IsContainedInstanceSoprano };
	qyoto_modules[soprano_Smoke] = module;
}

}
