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

#ifndef CSWRITEINCLUDES_H
#define CSWRITEINCLUDES_H

#include "treewalker.h"
#include <QMap>
#include <QString>

class QTextStream;
class Driver;
class Uic;

struct Option;

namespace CS {

struct WriteIncludes : public TreeWalker
{
    WriteIncludes(Uic *uic);

    void acceptUI(DomUI *node);
    void acceptWidget(DomWidget *node);
    void acceptLayout(DomLayout *node);
    void acceptSpacer(DomSpacer *node);

//
// custom widgets
//
    void acceptCustomWidgets(DomCustomWidgets *node);
    void acceptCustomWidget(DomCustomWidget *node);

//
// include hints
//
    void acceptIncludes(DomIncludes *node);
    void acceptInclude(DomInclude *node);

private:
    void add(const QString &className);

private:
    Uic *uic;
    Driver *driver;
    QTextStream &output;
    const Option &option;

    QMap<QString, bool> m_includes;
    QMap<QString, bool> m_customWidgets;
    QMap<QString, QString> m_classToHeader;
    QMap<QString, QString> m_oldHeaderToNewHeader;
};

} // namespace CPP

#endif // CSWRITEINCLUDES_H
