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

public class Car : QGraphicsItem {
        
    private QBrush color;
    private double wheelsAngle; // used when applying rotation
    private double speed; // delta movement along the body axis
    
    static double Pi = 3.14159265358979323846264338327950288419717;
    
    public override QRectF BoundingRect()
    {
        return new QRectF(-35, -81, 70, 115);
    }
    
    public Car() : base()
    {
        color = new QBrush(Qt.GlobalColor.green);
        wheelsAngle = 0;
        speed = 0;
        SetFlag(QGraphicsItem.GraphicsItemFlag.ItemIsMovable, true);
        SetFlag(QGraphicsItem.GraphicsItemFlag.ItemIsFocusable, true);
    }
    
    public int accelerate()
    {
        if (speed < 10)
            ++speed;
        Console.WriteLine("accelerate about to return 5\n");
        return 5;
    }
    
    public void decelerate()
    {
        if (speed > -10)
            --speed;
    }
    
    public void turnLeft()
    {
        if (wheelsAngle > -30)
            wheelsAngle -= 5;
    }
    
    public void turnRight()
    {
        if (wheelsAngle < 30)
           wheelsAngle += 5;
    }
    
    public override void Paint(QPainter painter, QStyleOptionGraphicsItem option, QWidget widget)
    {
        painter.SetBrush(new QBrush(Qt.GlobalColor.gray));
        painter.DrawRect(-20, -58, 40, 2); // front axel
        painter.DrawRect(-20, 7, 40, 2); // rear axel
    
        painter.SetBrush(color);
        painter.DrawRect(-25, -79, 50, 10); // front wing
    
        painter.DrawEllipse(-25, -48, 50, 20); // side pods
        painter.DrawRect(-25, -38, 50, 35); // side pods
        painter.DrawRect(-5, 9, 10, 10); // back pod
    
        painter.DrawEllipse(-10, -81, 20, 100); // main body
    
        painter.DrawRect(-17, 19, 34, 15); // rear wing
    
        painter.SetBrush(new QBrush(Qt.GlobalColor.black));
        painter.DrawPie(-5, -51, 10, 15, 0, 180 * 16);
        painter.DrawRect(-5, -44, 10, 10); // cocpit
    
        painter.Save();
        painter.Translate(-20, -58);
        painter.Rotate(wheelsAngle);
        painter.DrawRect(-10, -7, 10, 15); // front left
        painter.Restore();
    
        painter.Save();
        painter.Translate(20, -58);
        painter.Rotate(wheelsAngle);
        painter.DrawRect(0, -7, 10, 15); // front left
        painter.Restore();
    
        painter.DrawRect(-30, 0, 12, 17); // rear left
        painter.DrawRect(19, 0, 12, 17);  // rear right
    }
    
    public void TimerEvent(QTimerEvent e)
    {
        double axelDistance = 54;
        double wheelsAngleRads = (wheelsAngle * Pi) / 180;
        double turnDistance = Math.Cos(wheelsAngleRads) * axelDistance * 2;
        double turnRateRads = wheelsAngleRads / turnDistance;  // rough estimate
        double turnRate = (turnRateRads * 180) / Pi;
        double rotation = speed * turnRate;
        
        Rotate(rotation);
        Translate(0, -speed);
        Update();
    }
}
