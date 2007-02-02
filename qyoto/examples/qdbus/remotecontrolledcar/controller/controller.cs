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

public class Controller : QWidget {
    
    private Ui.Controller ui;
    private QDBusInterface car;

    public Controller() : this((QWidget) null) {}

    public Controller(QWidget parent) : base(parent)
    {
        ui = new Ui.Controller();
        ui.SetupUi(this);
	    car = new QDBusInterface("com.trolltech.CarExample", "/Car", 
                                 "com.trolltech.Examples.CarInterface",
	                             QDBusConnection.SessionBus(), this);
        StartTimer(1000);
    }
    
    protected override void TimerEvent(QTimerEvent e)
    {
        if (car.IsValid())
            ui.label.Text = "connected";
        else
            ui.label.Text = "disconnected";
    }
    
    [Q_SLOT]
    public void on_accelerate_clicked()
    {
        car.Call("accelerate");
    }
    
    [Q_SLOT]
    public void on_decelerate_clicked()
    {
        car.Call("decelerate");
    }
    
    [Q_SLOT]
    public void on_left_clicked()
    {
        car.Call("turnLeft");
    }
    
    [Q_SLOT]
    public void on_right_clicked()
    {
        car.Call("turnRight");
    }
}
