/***************************************************************************
                          nepomukhandlers.cpp  -  Nepomuk specific marshallers
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

#include <nepomuk/class.h>
#include <nepomuk/property.h>
#include <nepomuk/resource.h>
#include <nepomuk/tag.h>
#include <nepomuk/variant.h>

DEF_VALUELIST_MARSHALLER( NepomukResourceList, QList<Nepomuk::Resource>, Nepomuk::Resource )
DEF_VALUELIST_MARSHALLER( NepomukTagList, QList<Nepomuk::Tag>, Nepomuk::Tag )
DEF_VALUELIST_MARSHALLER( NepomukTypesClassList, QList<Nepomuk::Types::Class>, Nepomuk::Types::Class )
DEF_VALUELIST_MARSHALLER( NepomukTypesPropertyList, QList<Nepomuk::Types::Property>, Nepomuk::Types::Property )

TypeHandler Nepomuk_handlers[] = {
    { "QList<Nepomuk::Resource>", marshall_NepomukResourceList },
    { "QList<Nepomuk::Resource>&", marshall_NepomukResourceList },
    { "QList<Nepomuk::Tag>", marshall_NepomukTagList },
    { "QList<Nepomuk::Tag>&", marshall_NepomukTagList },
    { "QList<Nepomuk::Types::Class>", marshall_NepomukTypesClassList },
    { "QList<Nepomuk::Types::Class>&", marshall_NepomukTypesClassList },
    { "QList<Nepomuk::Types::Property>", marshall_NepomukTypesPropertyList },
    { "QList<Nepomuk::Types::Property>&", marshall_NepomukTypesPropertyList },
//    { "QHash<QUrl,Nepomuk::Variant>", marshall_QHashQUrlNepomukVariant },
    { 0, 0 }
};

