/***************************************************************************
                          nepomuk.cpp  -  Nepomuk ruby extension
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
#include <smoke/qt_smoke.h>
#include <smoke/nepomuk_smoke.h>

QHash<int, char*> classNames;

const char *
resolve_classname_nepomuk(smokeqyoto_object * o)
{
	return o->smoke->binding->className(o->classId);
}

bool
IsContainedInstanceNepomuk(smokeqyoto_object* /*o*/)
{
	// all cases are handled in the qyoto module
	return false;
}

extern TypeHandler Nepomuk_handlers[];

extern "C" {

extern Q_DECL_EXPORT void Init_nepomuk();

void
Init_nepomuk()
{
	init_nepomuk_Smoke();
	nepomuk_Smoke->binding = new QyotoSmokeBinding(nepomuk_Smoke, &classNames);
	QString prefix("Qyoto.");
	QString className;
	QByteArray classStringName;
	
	for (int i = 1; i <= nepomuk_Smoke->numClasses; i++) {
		className = prefix + nepomuk_Smoke->classes[i].className;
		classStringName = className.toLatin1();
		classNames.insert(i, strdup(classStringName.constData()));
	}
	
	QyotoModule module = { "Nepomuk", resolve_classname_nepomuk, IsContainedInstanceNepomuk };
	qyoto_modules.insert(nepomuk_Smoke, module);

    install_handlers(Nepomuk_handlers);
}

}
