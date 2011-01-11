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

class LCDRange : QWidget {

	private QSlider slider;
	private QLabel label;

	public LCDRange(QWidget parent) : base(parent) {
		init();
	}

	public LCDRange(string text, QWidget parent) : base(parent) {
		init();
		setText(text);
	}

	private void init() {
		QLCDNumber lcd = new QLCDNumber(2);
		lcd.segmentStyle = QLCDNumber.SegmentStyle.Filled;

		slider = new QSlider(Qt.Orientation.Horizontal);
		slider.SetRange(0, 99);
		slider.Value = 0;
		label = new QLabel();
		label.Alignment = (int) (Qt.AlignmentFlag.AlignHCenter | Qt.AlignmentFlag.AlignTop);

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

	public string text() {
		return label.Text;
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

	public void setText(string text) {
		label.Text = text;
	}

	protected new ILCDRangeSignals Emit {
		get {
			return (ILCDRangeSignals) Q_EMIT;
		}
	}
}

interface ILCDRangeSignals : IQWidgetSignals {
	[Q_SIGNAL]
	void valueChanged(int newValue);
}
