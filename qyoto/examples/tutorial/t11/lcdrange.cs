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

class LCDRange : QWidget {
	
	private QSlider slider;
	
	public LCDRange(QWidget parent) : base(parent) {
		QLCDNumber lcd = new QLCDNumber(2);
		lcd.segmentStyle = QLCDNumber.SegmentStyle.Filled;
		
		slider = new QSlider(Qt.Orientation.Horizontal);
		slider.SetRange(0, 99);
		slider.Value = 0;
		
		Connect(slider, SIGNAL("valueChanged(int)"),
			lcd, SLOT("display(int)"));
		Connect(slider, SIGNAL("valueChanged(int)"),
			this, SIGNAL("valueChanged(int)"));
		
		QVBoxLayout layout = new QVBoxLayout();
		layout.AddWidget(lcd);
		layout.AddWidget(slider);
		SetLayout(layout);
		
		SetFocusProxy(slider);
	}
	
	public int value() {
		return slider.Value;
	}
	
	[Q_SLOT]
	public void setValue(int value)
	{
		slider.Value = value;
	}
	
	[Q_SLOT]
	public void setRange(int minValue, int maxValue) {
		if (minValue < 0 || maxValue > 99 || minValue > maxValue) {
			Console.WriteLine("LCDRange.setRange({0}, {1})\n\tRange must be 0..99\n\tand minValue must not be greater than maxValue",
				minValue, maxValue);
			return;
		}
		slider.SetRange(minValue, maxValue);
	}

	protected new ILCDRangeSignals Emit() {
		return (ILCDRangeSignals) Q_EMIT;
	}
}

interface ILCDRangeSignals : IQWidgetSignals {
	[Q_SIGNAL("valueChanged(int)")]
	void valueChanged(int newValue);
}