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

/* Adaptor class for interface com.trolltech.Examples.CarInterface
*/

[Q_CLASSINFO("D-Bus Interface", "com.trolltech.Examples.CarInterface")]
public class CarAdaptor : QObject {
/*
        Q_CLASSINFO("D-Bus Introspection", ""
    "  <interface name=\"com.trolltech.Examples.CarInterface\" >\n"
    "    <method name=\"accelerate\" />\n"
    "    <method name=\"decelerate\" />\n"
    "    <method name=\"turnLeft\" />\n"
    "    <method name=\"turnRight\" />\n"
    "    <signal name=\"crashed\" />\n"
    "  </interface>\n"
            "")
*/
    
    private Car car;

    public CarAdaptor(Car mycar) : base()
    {
        car = mycar;
	    StartTimer(1000 / 33);
    }
    
    [Q_SLOT]
    public int accelerate()
    {
        // handle method call com.trolltech.Examples.CarInterface.accelerate
        return car.accelerate();
    }
    
    [Q_SLOT]
    public void decelerate()
    {
        // handle method call com.trolltech.Examples.CarInterface.decelerate
        car.decelerate();
    }
    
    [Q_SLOT]
    public void turnLeft()
    {
        // handle method call com.trolltech.Examples.CarInterface.turnLeft
        car.turnLeft();
    }
    
    [Q_SLOT]
    public void turnRight()
    {
        // handle method call com.trolltech.Examples.CarInterface.turnRight
        car.turnRight();
    }
    
    protected override void TimerEvent(QTimerEvent e)
    {
        car.TimerEvent(e);
    }

    protected new ICarAdaptorSignals Emit {
        get {
            return (ICarAdaptorSignals) Q_EMIT;
        }
    }
}

public interface ICarAdaptorSignals : IQObjectSignals {
    [Q_SIGNAL]
    void Crashed();
}

