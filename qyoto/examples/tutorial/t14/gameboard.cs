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
		angle.setRange(5, 70);

		LCDRange force = new LCDRange(Tr("FORCE"));
		force.setRange(10, 50);

		QFrame cannonBox = new QFrame();
		cannonBox.SetFrameStyle((int) (QFrame.Shape.WinPanel | QFrame.Shadow.Sunken));

		cannonField = new CannonField();

		Connect(angle, SIGNAL("valueChanged(int)"),
			cannonField, SLOT("setAngle(int)"));
		Connect(cannonField, SIGNAL("angleChanged(int)"),
			angle, SLOT("setValue(int)"));
		
		Connect(force, SIGNAL("valueChanged(int)"),
			cannonField, SLOT("setForce(int)"));
		Connect(cannonField, SIGNAL("forceChanged(int)"),
			force, SLOT("setValue(int)"));

		Connect(cannonField, SIGNAL("hit()"),
			this, SLOT("hit()"));
		Connect(cannonField, SIGNAL("missed()"),
			this, SLOT("missed()"));

		QPushButton shoot = new QPushButton("&Shoot");
		shoot.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

		Connect(shoot, SIGNAL("clicked()"),
			this, SLOT("fire()"));
		Connect(cannonField, SIGNAL("canShoot(bool)"),
			shoot, SLOT("setEnabled(bool)"));

		QPushButton restart = new QPushButton(Tr("&New Game"));
		restart.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

		Connect(restart, SIGNAL("clicked()"), this, SLOT("newGame()"));

		hits = new QLCDNumber(2);
		hits.segmentStyle = QLCDNumber.SegmentStyle.Filled;

		shotsLeft = new QLCDNumber(2);
		shotsLeft.segmentStyle = QLCDNumber.SegmentStyle.Filled;

		QLabel hitsLabel = new QLabel(Tr("HITS"));
		QLabel shotsLeftLabel = new QLabel(Tr("SHOTS LEFT"));

		new QShortcut(new QKeySequence((int) Qt.Key.Key_Enter), this, SLOT("fire()"));
		new QShortcut(new QKeySequence((int) Qt.Key.Key_Return), this, SLOT("fire()"));
		new QShortcut(new QKeySequence((int) Qt.Key.Key_Control + (int) Qt.Key.Key_Q), this, SLOT("close()"));

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

		angle.setValue(60);
		force.setValue(25);
		angle.SetFocus();

		newGame();
	}

	[Q_SLOT]
	protected void fire() {
		if (cannonField.gameOver() || cannonField.isShooting())
			return;
		shotsLeft.Display(shotsLeft.IntValue - 1);
		cannonField.shoot();
	}

	[Q_SLOT]
	protected void hit() {
		hits.Display(hits.IntValue + 1);
		if (shotsLeft.IntValue == 0)
			cannonField.setGameOver();
		else
			cannonField.newTarget();
	}

	[Q_SLOT]
	protected void missed() {
		if (shotsLeft.IntValue == 0)
			cannonField.setGameOver();
	}

	[Q_SLOT]
	protected void newGame() {
		shotsLeft.Display(15);
		hits.Display(0);
		cannonField.restartGame();
		cannonField.newTarget();
	}
}