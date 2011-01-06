/***************************************************************************
                        qscintilla.cpp  -  description
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
#include <qsci_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_Qsci(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceQsci(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern "C" {

extern Q_DECL_EXPORT void Init_qscintilla();

static Qyoto::Binding binding;

void
Init_qscintilla()
{
	init_qsci_Smoke();
	QString prefix("QScintilla.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= qsci_Smoke->numClasses; i++) {
		className = prefix + qsci_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	binding = Qyoto::Binding(qsci_Smoke, &classNames);
	QyotoModule module = { "QScintilla2", resolve_classname_Qsci, IsContainedInstanceQsci, &binding };
	qyoto_modules.insert(qsci_Smoke, module);
}

}
