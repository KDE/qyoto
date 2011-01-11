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

class MyWidget : QWidget {
	public MyWidget(QWidget parent) : base(parent) {
		QPushButton quit = new QPushButton("&Quit");
		quit.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);
		
		Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
		
		LCDRange angle = new LCDRange(null);
		angle.setRange(5, 70);
		
		LCDRange force = new LCDRange(null);
		force.setRange(10, 50);
		
		CannonField cannonField = new CannonField(null);
		
		Connect(angle, SIGNAL("valueChanged(int)"),
			cannonField, SLOT("setAngle(int)"));
		Connect(cannonField, SIGNAL("angleChanged(int)"),
			angle, SLOT("setValue(int)"));
		
		Connect(force, SIGNAL("valueChanged(int)"),
			cannonField, SLOT("setForce(int)"));
		Connect(cannonField, SIGNAL("forceChanged(int)"),
			force, SLOT("setValue(int)"));
		
		QPushButton shoot = new QPushButton("&Shoot");
		shoot.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);
		
		Connect(shoot, SIGNAL("clicked()"), cannonField, SLOT("shoot()"));
		
		QHBoxLayout topLayout = new QHBoxLayout();
		topLayout.AddWidget(shoot);
		topLayout.AddStretch(1);
		
		QVBoxLayout leftLayout = new QVBoxLayout();
		leftLayout.AddWidget(angle);
		leftLayout.AddWidget(force);
		
		QGridLayout gridLayout = new QGridLayout();
		gridLayout.AddWidget(quit, 0, 0);
		gridLayout.AddLayout(topLayout, 0, 1);
		gridLayout.AddLayout(leftLayout, 1, 0);
		gridLayout.AddWidget(cannonField, 1, 1, 2, 1);
		gridLayout.SetColumnStretch(1, 10);
		SetLayout(gridLayout);
		
		angle.setValue(60);
		force.setValue(25);
		angle.SetFocus();
	}
}

class MainClass {
	public static int Main(string[] args) {
		new QApplication(args);
		MyWidget widget = new MyWidget(null);
		widget.SetGeometry(100, 100, 500, 355);
		widget.Show();
		return QApplication.Exec();
	}
}