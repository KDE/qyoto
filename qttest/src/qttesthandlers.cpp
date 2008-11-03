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

DEF_VALUELIST_MARSHALLER( QTestAccessibilityEventList, QList<QTestAccessibilityEvent>, QTestAccessibilityEvent )

TypeHandler QtTest_handlers[] = {
    { "QList<QTestAccessibilityEvent>", marshall_QTestAccessibilityEventList },
    { 0, 0 }
};
