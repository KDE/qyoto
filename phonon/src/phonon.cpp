/***************************************************************************
                          qtwebkit.cpp  -  QtWebKit ruby extension
                             -------------------
    begin                : 14-07-2008
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
#include <phonon_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_phonon(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstancePhonon(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler Phonon_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_phonon();

static Qyoto::Binding binding;

void
Init_phonon()
{
	init_phonon_Smoke();
	
	for (int i = 1; i <= phonon_Smoke->numClasses; i++) {
		QByteArray name(phonon_Smoke->classes[i].className);
		name.replace("::", ".");
		classNames.insert(i, strdup(name.constData()));
	}
	
	binding = Qyoto::Binding(phonon_Smoke, &classNames);
	QyotoModule module = { "Phonon", resolve_classname_phonon, IsContainedInstancePhonon, &binding };
	qyoto_modules.insert(phonon_Smoke, module);

    qyoto_install_handlers(Phonon_handlers);
}

}
