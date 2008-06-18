/***************************************************************************
                        khtml.cpp  -  description
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
#include <smoke/khtml_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_khtml(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceKHTML(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler KHTML_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_khtml();

void
Init_khtml()
{
	init_khtml_Smoke();
	khtml_Smoke->binding = new QyotoSmokeBinding(khtml_Smoke, &classNames);
	QString prefix("KHTML.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= khtml_Smoke->numClasses; i++) {
		className = prefix + khtml_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "KHTML", resolve_classname_khtml, IsContainedInstanceKHTML };
	qyoto_modules[khtml_Smoke] = module;

    install_handlers(KHTML_handlers);
}

}
