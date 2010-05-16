/***************************************************************************
                       qdbus_interop.cpp  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale <Richard_Dale@tipitina.demon.co.uk>
                           (C) 2009 by Arno Rehn <arno@arnorehn.de>
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#include <QDBusReply>
#include <QDBusVariant>

#include "qyoto.h"
#include "callbacks.h"

extern "C" {

Q_DECL_EXPORT void
qyoto_qdbus_reply_fill(void *msg, void *error, void *variant)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(msg);
    QDBusMessage *dbusmsg = (QDBusMessage*) o->ptr;
    (*FreeGCHandle)(msg);

    o = (smokeqyoto_object*) (*GetSmokeObject)(error);
    QDBusError *dbuserror = (QDBusError*) o->ptr;
    (*FreeGCHandle)(error);

    o = (smokeqyoto_object*) (*GetSmokeObject)(variant);
    QVariant *v = (QVariant*) o->ptr;
    (*FreeGCHandle)(variant);

    qDBusReplyFill(*dbusmsg, *dbuserror, *v);

    // extract the QVariant from the QDBusVariant here
    if (v->userType() == qMetaTypeId<QDBusVariant>()) {
        *v = qvariant_cast<QDBusVariant>(*v).variant();
    }
}

}
