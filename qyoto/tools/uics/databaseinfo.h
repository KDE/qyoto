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

#ifndef DATABASEINFO_H
#define DATABASEINFO_H

#include "treewalker.h"
#include <QStringList>
#include <QMap>

class Driver;

class DatabaseInfo : public TreeWalker
{
public:
    DatabaseInfo(Driver *driver);

    void acceptUI(DomUI *node);
    void acceptWidget(DomWidget *node);

    inline QStringList connections() const
    { return m_connections; }

    inline QStringList cursors(const QString &connection) const
    { return m_cursors.value(connection); }

    inline QStringList fields(const QString &connection) const
    { return m_fields.value(connection); }

private:
    Driver *driver;
    QStringList m_connections;
    QMap<QString, QStringList> m_cursors;
    QMap<QString, QStringList> m_fields;
};

#endif // DATABASEINFO_H
