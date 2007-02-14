/****************************************************************************
**
** Copyright (C) 2005-2006 Trolltech ASA. All rights reserved.
**
** This file is part of the example classes of the Qt Toolkit.
**
** This file may be used under the terms of the GNU General Public
** License version 2.0 as published by the Free Software Foundation
** and appearing in the file LICENSE.GPL included in the packaging of
** this file.  Please review the following information to ensure GNU
** General Public Licensing requirements will be met:
** http://www.trolltech.com/products/qt/opensource.html
**
** If you are unsure which license is appropriate for your use, please
** review the following information:
** http://www.trolltech.com/products/qt/licensing.html or contact the
** sales department at sales@trolltech.com.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
****************************************************************************/

using Qyoto;
using System;

class GameBoard : QWidget {

    private QLCDNumber hits;
    private QLCDNumber shotsLeft;
    private CannonField cannonField;

    public GameBoard() : this((QWidget) null) {}

    public GameBoard(QWidget parent) : base(parent) {
        QPushButton quit = new QPushButton("&Quit");
        quit.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

        Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
        
        LCDRange angle = new LCDRange(Tr("ANGLE"));
        angle.SetRange(5, 70);

        LCDRange force = new LCDRange(Tr("FORCE"));
        force.SetRange(10, 50);

        QFrame cannonBox = new QFrame();
        cannonBox.SetFrameStyle((int) QFrame.Shape.WinPanel | (int) QFrame.Shadow.Sunken);

        cannonField = new CannonField();

        Connect(angle, SIGNAL("ValueChanged(int)"),
            cannonField, SLOT("SetAngle(int)"));
        Connect(cannonField, SIGNAL("AngleChanged(int)"),
            angle, SLOT("SetValue(int)"));
        
        Connect(force, SIGNAL("ValueChanged(int)"),
            cannonField, SLOT("SetForce(int)"));
        Connect(cannonField, SIGNAL("ForceChanged(int)"),
            force, SLOT("SetValue(int)"));

        Connect(cannonField, SIGNAL("Hit()"),
            this, SLOT("Hit()"));
        Connect(cannonField, SIGNAL("Missed()"),
            this, SLOT("Missed()"));

        QPushButton shoot = new QPushButton("&Shoot");
        shoot.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

        Connect(shoot, SIGNAL("clicked()"),
            this, SLOT("Fire()"));
        Connect(cannonField, SIGNAL("CanShoot(bool)"),
            shoot, SLOT("setEnabled(bool)"));

        QPushButton restart = new QPushButton(Tr("&New Game"));
        restart.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

        Connect(restart, SIGNAL("clicked()"), this, SLOT("NewGame()"));

        hits = new QLCDNumber(2);
        hits.segmentStyle = QLCDNumber.SegmentStyle.Filled;

        shotsLeft = new QLCDNumber(2);
        shotsLeft.segmentStyle = QLCDNumber.SegmentStyle.Filled;

        QLabel hitsLabel = new QLabel(Tr("HITS"));
        QLabel shotsLeftLabel = new QLabel(Tr("SHOTS LEFT"));

        new QShortcut(new QKeySequence((int) Qt.Key.Key_Enter), this, SLOT("Fire()"));
        new QShortcut(new QKeySequence((int) Qt.Key.Key_Return), this, SLOT("Fire()"));
        new QShortcut(new QKeySequence((int) Qt.Modifier.CTRL + (int) Qt.Key.Key_Q), this, SLOT("close()"));

        QHBoxLayout topLayout = new QHBoxLayout();
        topLayout.AddWidget(shoot);
        topLayout.AddWidget(hits);
        topLayout.AddWidget(hitsLabel);
        topLayout.AddWidget(shotsLeft);
        topLayout.AddWidget(shotsLeftLabel);
        topLayout.AddStretch(1);
        topLayout.AddWidget(restart);

        QVBoxLayout leftLayout = new QVBoxLayout();
        leftLayout.AddWidget(angle);
        leftLayout.AddWidget(force);

        QVBoxLayout cannonLayout = new QVBoxLayout();
        cannonLayout.AddWidget(cannonField);
        cannonBox.SetLayout(cannonLayout);

        QGridLayout gridLayout = new QGridLayout();
        gridLayout.AddWidget(quit, 0, 0);
        gridLayout.AddLayout(topLayout, 0, 1);
        gridLayout.AddLayout(leftLayout, 1, 0);
        gridLayout.AddWidget(cannonBox, 1, 1, 2, 1);
        gridLayout.SetColumnStretch(1, 10);
        SetLayout(gridLayout);

        angle.SetValue(60);
        force.SetValue(25);
        angle.SetFocus();

        NewGame();
    }

    [Q_SLOT]
    protected void Fire() {
        if (cannonField.GameOver() || cannonField.IsShooting())
            return;
        shotsLeft.Display(shotsLeft.IntValue - 1);
        cannonField.Shoot();
    }

    [Q_SLOT]
    protected void Hit() {
        hits.Display(hits.IntValue + 1);
        if (shotsLeft.IntValue == 0)
            cannonField.SetGameOver();
        else
            cannonField.NewTarget();
    }

    [Q_SLOT]
    protected void Missed() {
        if (shotsLeft.IntValue == 0)
            cannonField.SetGameOver();
    }

    [Q_SLOT]
    protected void NewGame() {
        shotsLeft.Display(15);
        hits.Display(0);
        cannonField.RestartGame();
        cannonField.NewTarget();
    }
}