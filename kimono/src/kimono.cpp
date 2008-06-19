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
#include <smoke/kde_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_KDE(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceKDE(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler KDE_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_kimono();

void
Init_kimono()
{
	init_kde_Smoke();
	kde_Smoke->binding = new QyotoSmokeBinding(kde_Smoke, &classNames);
	QByteArray prefix("Kimono.");
	
	for (int i = 1; i <= kde_Smoke->numClasses; i++) {
		QByteArray name(kde_Smoke->classes[i].className);
		name.replace("::", ".");
		if (	!name.startsWith("KParts") 
				&& !name.startsWith("Sonnet")
				&& !name.startsWith("KIO")
				&& !name.startsWith("KWallet")
				&& !name.startsWith("KNS") ) 
		{
			name = prefix + name;
		}

		classNames.insert(i, strdup(name.constData()));
	}
	
	QyotoModule module = { "Kimono", resolve_classname_KDE, IsContainedInstanceKDE };
	qyoto_modules[kde_Smoke] = module;

    install_handlers(KDE_handlers);
}

}
