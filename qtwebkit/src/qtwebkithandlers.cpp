/***************************************************************************
                          qtwebkithandlers.cpp  -  QtWebKit specific marshallers
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

#include <qyoto.h>
#include <smokeqyoto.h>
#include <marshall_macros.h>

#include <QtWebKit/qwebframe.h>
#include <QtWebKit/qwebhistory.h>

DEF_LIST_MARSHALLER( QWebFrameList, QList<QWebFrame*>, QWebFrame )
DEF_VALUELIST_MARSHALLER( QWebHistoryItemList, QList<QWebHistoryItem>, QWebHistoryItem )

TypeHandler QtWebKit_handlers[] = {
    { "QList<QWebFrame*>", marshall_QWebFrameList },
    { "QList<QWebHistoryItem>", marshall_QWebHistoryItemList },
    { 0, 0 }
};
