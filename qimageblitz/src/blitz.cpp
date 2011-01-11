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
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#include <stdio.h>

#include <qyoto.h>
#include <qyotosmokebinding.h>

#include <smoke.h>
#include <qimageblitz_smoke.h>

static QHash<int, char*> classNames;

const char *
resolve_classname_qimageblitz(smokeqyoto_object * o)
{
	return qyoto_modules[o->smoke].binding->className(o->classId);
}

bool
IsContainedInstanceQImageBlitz(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern "C" {

extern Q_DECL_EXPORT void Init_blitz();

static Qyoto::Binding binding;

void
Init_blitz()
{
	init_qimageblitz_Smoke();
	
	for (int i = 1; i <= qimageblitz_Smoke->numClasses; i++) {
		QByteArray name(qimageblitz_Smoke->classes[i].className);
		name.replace("::", ".");
		classNames.insert(i, strdup(name.constData()));
	}
	
	binding = Qyoto::Binding(qimageblitz_Smoke, &classNames);
	QyotoModule module = { "QImageBlitz", resolve_classname_qimageblitz, IsContainedInstanceQImageBlitz, &binding };
	qyoto_modules.insert(qimageblitz_Smoke, module);
}

}
