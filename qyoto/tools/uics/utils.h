/****************************************************************************
**
** Copyright (C) 1992-2006 Trolltech ASA. All rights reserved.
**
** This file is part of the tools applications of the Qt Toolkit.
**
** Licensees holding valid Qt Preview licenses may use this file in
** accordance with the Qt Preview License Agreement provided with the
** Software.
**
** See http://www.trolltech.com/pricing.html or email sales@trolltech.com for
** information about Qt Commercial License Agreements.
**
** Contact info@trolltech.com if any conditions of this licensing are
** not clear to you.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
****************************************************************************/

#ifndef UTILS_H
#define UTILS_H

#include "ui4.h"
#include <QString>
#include <QList>
#include <QHash>

inline bool toBool(const QString &str)
{ return str.toLower() == QLatin1String("true"); }

inline QString toString(const DomString *str)
{ return str ? str->text() : QString(); }

inline QString fixString(const QString &str, const QString &indent)
{
    QString cursegment;
    QStringList result;
    const QChar *utf16 = str.unicode();

    for (int i = 0; !utf16[i].isNull(); ++i) {
        if (utf16[i] >= 0x80) {
            cursegment += QLatin1String("\\u") + QString().sprintf("%04hx", utf16[i].unicode());
        } else {
            switch(utf16[i].toLatin1()) {
            case '\\':
                cursegment += QLatin1String("\\\\"); break;
            case '\"':
                cursegment += QLatin1String("\\\""); break;
            case '\r':
                break;
            case '\n':
                cursegment += QLatin1String("\\n\" +\n\""); break;
            default:
                cursegment += utf16[i];
            }
        }
        
        if (cursegment.length() > 1024) {
            result << cursegment;
            cursegment.clear();
        }
    }

    if (!cursegment.isEmpty())
        result << cursegment;

    QString joinstr = QLatin1String("\"\n") + indent + indent + QLatin1Char('\"');
    return QLatin1String("\"") + result.join(joinstr) + QLatin1String("\"");
}

inline QHash<QString, DomProperty *> propertyMap(const QList<DomProperty *> &properties)
{
    QHash<QString, DomProperty *> map;

    for (int i=0; i<properties.size(); ++i) {
        DomProperty *p = properties.at(i);
        map.insert(p->attributeName(), p);
    }

    return map;
}

inline QStringList unique(const QStringList &lst)
{
    QHash<QString, bool> h;
    for (int i=0; i<lst.size(); ++i)
        h.insert(lst.at(i), true);
    return h.keys();
}

#endif // UTILS_H
