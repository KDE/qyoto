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

class CannonField : QWidget {
	int currentAngle;
	int currentForce;
	
	int timerCount;
	QTimer autoShootTimer;
	float shootAngle;
	float shootForce;

    QPoint target;

	public CannonField(QWidget parent) : base(parent) {
		currentAngle = 45;
		currentForce = 0;
		timerCount = 0;
		autoShootTimer = new QTimer(this);
		Connect(autoShootTimer, SIGNAL("timeout()"), this, SLOT("moveShot()"));
		shootAngle = 0;
		shootForce = 0;
		target = new QPoint(0, 0);
		Palette = new QPalette(new QColor(250, 250, 200));
		AutoFillBackground = true;
		newTarget();
	}

	[Q_SLOT]
	public void setAngle(int angle) {
		if (angle < 5)
			angle = 5;
		if (angle > 70)
			angle = 70;
		if (currentAngle == angle)
			return;
		currentAngle = angle;
		Update(cannonRect());
		Emit.angleChanged(currentAngle);
	}

	[Q_SLOT]
	public void setForce(int force) {
		if (force < 0)
			force = 0;
		if (currentForce == force)
			return;
		currentForce = force;
		Emit.forceChanged(currentForce);
	}

	[Q_SLOT]
	public void shoot() {
		if (autoShootTimer.IsActive())
			return;
		timerCount = 0;
		shootAngle = currentAngle;
		shootForce = currentForce;
		autoShootTimer.Start(5);
	}

	private static bool firstTime = true;
	private Random RandomClass = null;

	[Q_SLOT]
	public void newTarget() {
		if (firstTime) {
			firstTime = false;
			QTime midnight = new QTime(0, 0, 0);
//			srand(midnight.SecsTo(QTime.CurrentTime()));
			RandomClass = new Random();
		}

 		target = new QPoint(200 + RandomClass.Next(190), 10 + RandomClass.Next(255));
		Update();
	}

	[Q_SLOT]
	private void moveShot() {
		QRegion region = new QRegion(shotRect());
		timerCount++;

		QRect shotR = shotRect();

		if (shotR.Intersects(targetRect())) {
			autoShootTimer.Stop();
			Emit.hit();
		} else if (shotR.X() > Width() || shotR.Y() > Height()) {
			autoShootTimer.Stop();
			Emit.missed();
		} else {
			region = region.Unite(new QRegion(shotR));
		}

		Update(region);
	}

	protected override void PaintEvent(QPaintEvent arg1) {
		QPainter painter = new QPainter(this);

		paintCannon(painter);
		if (autoShootTimer.IsActive())
			paintShot(painter);
		paintTarget(painter);
	}

	private void paintShot(QPainter painter) {
		painter.Begin(this);
		painter.SetPen(Qt.PenStyle.NoPen);
		painter.SetBrush(new QBrush(Qt.GlobalColor.black));
		painter.DrawRect(shotRect());
		painter.End(); // should not be necessary
	}

	private void paintTarget(QPainter painter) {
		painter.Begin(this);
		painter.SetPen(new QColor(Qt.GlobalColor.black));
		painter.SetBrush(new QBrush(Qt.GlobalColor.red));
		painter.DrawRect(targetRect());
		painter.End(); // should not be necessary
	}

	public QRect barrelRect = new QRect(30, -5, 20, 10);

	private void paintCannon(QPainter painter) {
		painter.Begin(this); // should not be necessary
		painter.SetPen(Qt.PenStyle.NoPen);
		painter.SetBrush(new QBrush(Qt.GlobalColor.blue));
		
		painter.Save();
		painter.Translate(0, Height());
		painter.DrawPie(new QRect(-35, -35, 70, 70), 0, 90 * 16);
		painter.Rotate(-currentAngle);
		painter.DrawRect(barrelRect);
		painter.Restore();
		painter.End(); // should not be necessary
	}

	private QRect cannonRect() {
		QRect result = new QRect(0, 0, 50, 50);
		result.MoveBottomLeft(Rect.BottomLeft());
		return result;
	}
	private QRect shotRect() {
		const double gravity = 4;
		
		double time = timerCount / 20.0;
		double velocity = shootForce;
		double radians = shootAngle * 3.14159265 / 180;
		
		double velx = velocity * Math.Cos(radians);
		double vely = velocity * Math.Sin(radians);
		double x0 = (barrelRect.Right() + 5) * Math.Cos(radians);
		double y0 = (barrelRect.Right() + 5) * Math.Sin(radians);
		double x = x0 + velx * time;
		double y = y0 + vely * time - 0.5 * gravity * time * time;
		
		QRect result = new QRect(0, 0, 6, 6);
		result.MoveCenter(new QPoint((int) Math.Round(x), Height() - 1 - (int) Math.Round(y)));
		return result;
	}


	private QRect targetRect() {
		QRect result = new QRect(0, 0, 20, 10);
		result.MoveCenter(new QPoint(target.X(), Height() - 1 - target.Y()));
		return result;
	}

	protected new ICannonFieldSignals Emit {
		get {
			return (ICannonFieldSignals) Q_EMIT;
		}
	}
	
	public int angle() { return currentAngle; }
	public int force() { return currentForce; }
}

interface ICannonFieldSignals : IQWidgetSignals {
	[Q_SIGNAL]
	void hit();
	[Q_SIGNAL]
	void missed();
	[Q_SIGNAL]
	void angleChanged(int newAngle);
	[Q_SIGNAL]
	void forceChanged(int newForce);
}
