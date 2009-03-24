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

#include <phonon/effect.h>
#include <phonon/effectparameter.h>
#include <phonon/mediasource.h>
#include <phonon/path.h>

DEF_LIST_MARSHALLER( PhononEffectList, QList<Phonon::Effect*>, Phonon::Effect )

DEF_VALUELIST_MARSHALLER( PhononEffectParametersList, QList<Phonon::EffectParameter>, Phonon::EffectParameter )
DEF_VALUELIST_MARSHALLER( PhononMediaSourceList, QList<Phonon::MediaSource>, Phonon::MediaSource )
DEF_VALUELIST_MARSHALLER( PhononPathList, QList<Phonon::Path>, Phonon::Path )

TypeHandler Phonon_handlers[] = {
    { "QList<Phonon::Effect*>", marshall_PhononEffectList },
    { "QList<Phonon::Effect*>&", marshall_PhononEffectList },
    { "QList<Phonon::EffectParameter>", marshall_PhononEffectParametersList },
    { "QList<Phonon::EffectParameter>&", marshall_PhononEffectParametersList },
    { "QList<Phonon::MediaSource>", marshall_PhononMediaSourceList },
    { "QList<Phonon::MediaSource>&", marshall_PhononMediaSourceList },
// TODO: marshallers
//    { "QList<Phonon::ObjectDescription<Phonon::AudioChannelType> >", },
//    { "QList<Phonon::ObjectDescription<Phonon::SubtitleType> >", },
    { "QList<Phonon::Path>", marshall_PhononPathList },
    { "QList<Phonon::Path>&", marshall_PhononPathList },
// TODO: marshallers
//    { "QList<QExplicitlySharedDataPointer<Phonon::ObjectDescriptionData> >"
    { 0, 0 }
};
