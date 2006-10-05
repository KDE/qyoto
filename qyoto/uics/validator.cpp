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

#include "validator.h"
#include "driver.h"
#include "ui4.h"
#include "uic.h"

#include <QTextStream>

Validator::Validator(Uic *uic)
    : driver(uic->driver()), output(uic->output()), option(uic->option())
{
    this->uic = uic;
}

void Validator::acceptUI(DomUI *node)
{
    TreeWalker::acceptUI(node);
}

void Validator::acceptWidget(DomWidget *node)
{
    (void) driver->findOrInsertWidget(node);

    TreeWalker::acceptWidget(node);
}

void Validator::acceptLayoutItem(DomLayoutItem *node)
{
    (void) driver->findOrInsertLayoutItem(node);

    TreeWalker::acceptLayoutItem(node);
}

void Validator::acceptLayout(DomLayout *node)
{
    (void) driver->findOrInsertLayout(node);

    TreeWalker::acceptLayout(node);
}

void Validator::acceptActionGroup(DomActionGroup *node)
{
    (void) driver->findOrInsertActionGroup(node);

    TreeWalker::acceptActionGroup(node);
}

void Validator::acceptAction(DomAction *node)
{
    (void) driver->findOrInsertAction(node);

    TreeWalker::acceptAction(node);
}
