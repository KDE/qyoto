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
#include <smoke/ktexteditor_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_ktexteditor(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceKTextEditor(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler KTextEditor_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_ktexteditor();

static Qyoto::Binding binding;

void
Init_ktexteditor()
{
	init_ktexteditor_Smoke();
	
	for (int i = 1; i <= ktexteditor_Smoke->numClasses; i++) {
		QByteArray name(ktexteditor_Smoke->classes[i].className);
		name.replace("::", ".");
		classNames.insert(i, strdup(name.constData()));
	}
	
	binding = Qyoto::Binding(ktexteditor_Smoke, &classNames);
	QyotoModule module = { "KTextEditor", resolve_classname_ktexteditor, IsContainedInstanceKTextEditor, &binding };
	qyoto_modules[ktexteditor_Smoke] = module;

    qyoto_install_handlers(KTextEditor_handlers);
}

}
