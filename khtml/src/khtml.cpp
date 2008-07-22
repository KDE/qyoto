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

static QHash<int, char*> classNames;

const char *
resolve_classname_khtml(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
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

static Qyoto::Binding binding;

void
Init_khtml()
{
	init_khtml_Smoke();
	QByteArray prefix("Kimono.");
	
	for (int i = 1; i <= khtml_Smoke->numClasses; i++) {
		QByteArray name(khtml_Smoke->classes[i].className);
		name.replace("::", ".");
		if (!name.startsWith("KParts") && !name.startsWith("DOM")) {
			name = prefix + name;
		}

		classNames.insert(i, strdup(name.constData()));
	}
	
	binding = Qyoto::Binding(khtml_Smoke, &classNames);
	QyotoModule module = { "KHTML", resolve_classname_khtml, IsContainedInstanceKHTML, &binding };
	qyoto_modules[khtml_Smoke] = module;

    qyoto_install_handlers(KHTML_handlers);
}

}
