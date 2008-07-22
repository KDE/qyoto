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

#include <akonadi/agentinstance.h>
#include <akonadi/agentinstancecreatejob.h>
#include <akonadi/agentinstancemodel.h>
#include <akonadi/agentinstanceview.h>
#include <akonadi/agentinstancewidget.h>
#include <akonadi/agenttype.h>
#include <akonadi/agenttypemodel.h>
#include <akonadi/agenttypeview.h>
#include <akonadi/agenttypewidget.h>
#include <akonadi/attribute.h>
#include <akonadi/attributefactory.h>
#include <akonadi/collection.h>
#include <akonadi/collectioncombobox.h>
#include <akonadi/collectioncopyjob.h>
#include <akonadi/collectioncreatejob.h>
#include <akonadi/collectiondeletejob.h>
#include <akonadi/collectiondisplayattribute.h>
#include <akonadi/collectionfetchjob.h>
#include <akonadi/collectionfilterproxymodel.h>
#include <akonadi/collectionmodel.h>
#include <akonadi/collectionmodifyjob.h>
#include <akonadi/collectionpathresolver.h>
#include <akonadi/collectionpropertiesdialog.h>
#include <akonadi/collectionpropertiespage.h>
#include <akonadi/collectionstatistics.h>
#include <akonadi/collectionstatisticsdelegate.h>
#include <akonadi/collectionstatisticsjob.h>
#include <akonadi/collectionstatisticsmodel.h>
#include <akonadi/collectionview.h>
#include <akonadi/item.h>
#include <akonadi/itemcopyjob.h>
#include <akonadi/itemcreatejob.h>
#include <akonadi/itemdeletejob.h>
#include <akonadi/itemdetailsview.h>
#include <akonadi/itemfetchjob.h>
#include <akonadi/itemfetchscope.h>
#include <akonadi/itemmodel.h>
#include <akonadi/itemmodifyjob.h>
#include <akonadi/itemmonitor.h>
#include <akonadi/itemmovejob.h>
#include <akonadi/itemserializerplugin.h>
#include <akonadi/itemsync.h>
#include <akonadi/itemview.h>
#include <akonadi/kmime/messagethreadingattribute.h>

DEF_LIST_MARSHALLER( AkonadiAttributeList, QList<Akonadi::Attribute*>, Akonadi::Attribute )
DEF_VALUELIST_MARSHALLER( AkonadiAgentInstanceList, QList<Akonadi::AgentInstance>, Akonadi::AgentInstance )
DEF_VALUELIST_MARSHALLER( AkonadiAgentTypeList, QList<Akonadi::AgentType>, Akonadi::AgentType )
DEF_VALUELIST_MARSHALLER( AkonadiCollectionList, QList<Akonadi::Collection>, Akonadi::Collection )
DEF_VALUELIST_MARSHALLER( AkonadiItemList, QList<Akonadi::Item>, Akonadi::Item )
DEF_VALUELIST_MARSHALLER( QModelIndexList, QList<QModelIndex>, QModelIndex )

TypeHandler Akonadi_handlers[] = {
    { "QList<Akonadi::AgentInstance>", marshall_AkonadiAgentInstanceList },
    { "QList<Akonadi::AgentType>", marshall_AkonadiAgentTypeList },
    { "QList<Akonadi::Attribute*>", marshall_AkonadiAttributeList },
    { "QList<Akonadi::Collection>", marshall_AkonadiCollectionList },
    { "QList<Akonadi::Collection>&", marshall_AkonadiCollectionList },
    { "QList<Akonadi::Item>", marshall_AkonadiItemList },
    { "QList<Akonadi::Item>&", marshall_AkonadiItemList },
    { "QList<QModelIndex>", marshall_QModelIndexList },
    { "QList<QModelIndex>&", marshall_QModelIndexList },
    { 0, 0 }
};
