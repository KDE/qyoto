/***************************************************************************
                          qttesthandlers.cpp  -  QtTest specific marshallers
                             -------------------
    begin                : 02-11-2008
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

#include <qyoto.h>
#include <smokeqyoto.h>
#include <marshall_macros.h>

#include <QtTest/qtestaccessible.h>

#ifndef QT_NO_ACCESSIBILITY
DEF_VALUELIST_MARSHALLER( QTestAccessibilityEventList, QList<QTestAccessibilityEvent>, QTestAccessibilityEvent )
#endif

TypeHandler QtTest_handlers[] = {
#ifndef QT_NO_ACCESSIBILITY
    { "QList<QTestAccessibilityEvent>", marshall_QTestAccessibilityEventList },
#endif
    { 0, 0 }
};
