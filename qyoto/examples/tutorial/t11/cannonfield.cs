/****************************************************************************
**
** Copyright (C) 2005-2006 Trolltech ASA. All rights reserved.
**
** This file is part of the example classes of the Qt Toolkit.
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

using Qyoto;
using System;

class CannonField : QWidget {
	int currentAngle;
	int currentForce;
	
	int timerCount;
	QTimer autoShootTimer;
	float shootAngle;
	float shootForce;
	
	QPainter painter = new QPainter(); // should be new QPainter(this) and be put in PaintEvent()
	
	public CannonField(QWidget parent) : base(parent) {
		currentAngle = 45;
		currentForce = 0;
		timerCount = 0;
		autoShootTimer = new QTimer(this);
		Connect(autoShootTimer, SIGNAL("timeout()"), this, SLOT("moveShot()"));
		shootAngle = 0;
		shootForce = 0;
		Palette = new QPalette(new QColor(250, 250, 200));
		AutoFillBackground = true;
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
		Update();
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

	[Q_SLOT]
	private void moveShot() {
		QRegion region = new QRegion(shotRect());
		timerCount++;
		
		QRect shotR = shotRect();
		
		if (shotR.X() > Width() || shotR.Y() > Height()) {
			autoShootTimer.Stop();
		} else {
			region = region.Unite(new QRegion(shotR));
		}
		Update(region);
	}

	protected override void PaintEvent(QPaintEvent arg1) {
		paintCannon(painter);
		if (autoShootTimer.IsActive())
			paintShot(painter);
	}

	private void paintShot(QPainter painter) {
		painter.Begin(this); // should not be necessary
		painter.SetPen(Qt.PenStyle.NoPen);
		painter.SetBrush(new QBrush(Qt.GlobalColor.black));
		painter.DrawRect(shotRect());
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
	void angleChanged(int newAngle);
	[Q_SIGNAL]
	void forceChanged(int newForce);
}
