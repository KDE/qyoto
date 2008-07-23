/***************************************************************************
                          akonadihandlers.cpp  -  Akonadi specific marshallers
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

#include <qyoto.h>
#include <smokeqyoto.h>
#include <marshall_macros.h>

#include <QModelIndex>

#include <akonadi/agentinstance.h>
#include <akonadi/agenttype.h>
#include <akonadi/attribute.h>
#include <akonadi/collection.h>
#include <akonadi/item.h>

DEF_LIST_MARSHALLER( AkonadiAttributeList, QList<Akonadi::Attribute*>, Akonadi::Attribute )

DEF_VALUELIST_MARSHALLER( AkonadiAgentInstanceList, QList<Akonadi::AgentInstance>, Akonadi::AgentInstance )
DEF_VALUELIST_MARSHALLER( AkonadiAgentTypeList, QList<Akonadi::AgentType>, Akonadi::AgentType )
DEF_VALUELIST_MARSHALLER( AkonadiCollectionList, QList<Akonadi::Collection>, Akonadi::Collection )
DEF_VALUELIST_MARSHALLER( AkonadiItemList, QList<Akonadi::Item>, Akonadi::Item )

TypeHandler Akonadi_handlers[] = {
    { "QList<Akonadi::AgentInstance>", marshall_AkonadiAgentInstanceList },
    { "QList<Akonadi::AgentType>", marshall_AkonadiAgentTypeList },
    { "QList<Akonadi::Attribute*>", marshall_AkonadiAttributeList },
    { "QList<Akonadi::Collection>", marshall_AkonadiCollectionList },
    { "QList<Akonadi::Collection>&", marshall_AkonadiCollectionList },
    { "QList<Akonadi::Item>", marshall_AkonadiItemList },
    { "QList<Akonadi::Item>&", marshall_AkonadiItemList },
    { 0, 0 }
};
