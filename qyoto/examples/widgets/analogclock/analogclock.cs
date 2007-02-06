/****************************************************************************
 **
 ** Copyright (C) 1992-2006 Trolltech ASA. All rights reserved.
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
 ** Translated to C#/Qyoto by Richard Dale
 **
 ****************************************************************************/

using Qyoto;
using System;
using System.Collections.Generic;

public class AnalogClock : QWidget {
	
	public AnalogClock() : this((QWidget) null) {}

	public AnalogClock(QWidget parent) : base(parent)
	{
	    QTimer timer = new QTimer(this);
	    Connect(timer, SIGNAL("timeout()"), this, SLOT("update()"));
	    timer.Start(1000);
	
	    WindowTitle = Tr("Analog Clock");
	    Resize(200, 200);
	}

	private static List<QPoint> hourHand = new List<QPoint>();
	private static List<QPoint> minuteHand = new List<QPoint>();

	static AnalogClock() {
	    hourHand.Add(new QPoint(7, 8));
	    hourHand.Add(new QPoint(-7, 8));
	    hourHand.Add(new QPoint(0, -40));

	    minuteHand.Add(new QPoint(7, 8));
	    minuteHand.Add(new QPoint(-7, 8));
	    minuteHand.Add(new QPoint(0, -70));
	}

	protected override void PaintEvent(QPaintEvent e)
	{	
	    QColor hourColor = new QColor(127, 0, 127);
	    QColor minuteColor = new QColor(0, 127, 127, 191);
	
	    int side = QMin(Width(), Height());
	    QTime time = QTime.CurrentTime();
	
	    QPainter painter = new QPainter(this);
	    painter.SetRenderHint(QPainter.RenderHint.Antialiasing);
	    painter.Translate(Width() / 2, Height() / 2);
	    painter.Scale(side / 200.0, side / 200.0);
	
	    painter.SetPen(Qt.PenStyle.NoPen);
	    painter.SetBrush(new QBrush(hourColor));
	
	    painter.Save();
	    painter.Rotate(30.0 * ((time.Hour() + time.Minute() / 60.0)));
	    painter.DrawConvexPolygon(new QPolygon(hourHand));
	    painter.Restore();
	
	    painter.SetPen(hourColor);
	
	    for (int i = 0; i < 12; ++i) {
	        painter.DrawLine(88, 0, 96, 0);
	        painter.Rotate(30.0);
	    }
	
	    painter.SetPen(Qt.PenStyle.NoPen);
	    painter.SetBrush(new QBrush(minuteColor));
	
	    painter.Save();
	    painter.Rotate(6.0 * (time.Minute() + time.Second() / 60.0));
	    painter.DrawConvexPolygon(new QPolygon(minuteHand));
	    painter.Restore();
	
	    painter.SetPen(minuteColor);
	
	    for (int j = 0; j < 60; ++j) {
	        if ((j % 5) != 0)
	            painter.DrawLine(92, 0, 96, 0);
	        painter.Rotate(6.0);
	    }

		painter.End();
	}
}
