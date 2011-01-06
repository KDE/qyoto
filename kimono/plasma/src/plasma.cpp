/***************************************************************************
                        plasma.cpp  -  description
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
#include <plasma_smoke.h>

static QHash<int, char*> plasmaClassNames;

const char *
resolve_classname_Plasma(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstancePlasma(smokeqyoto_object* o)
{
	// plasma extenders are always contained instances
	if (strcmp(o->smoke->className(o->classId), "Plasma::Extender") == 0)
		return true;
	return false;
}

extern TypeHandler Plasma_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_plasma();

static Qyoto::Binding binding;

void
Init_plasma()
{
	init_plasma_Smoke();
	
	for (int i = 1; i <= plasma_Smoke->numClasses; i++) {
		QByteArray name(plasma_Smoke->classes[i].className);
		name.replace("::", ".");
		plasmaClassNames.insert(i, strdup(name.constData()));
	}
	
	binding = Qyoto::Binding(plasma_Smoke, &plasmaClassNames);
	QyotoModule module = { "Plasma", resolve_classname_Plasma, IsContainedInstancePlasma, &binding };
	qyoto_modules[plasma_Smoke] = module;

    qyoto_install_handlers(Plasma_handlers);
}

}
