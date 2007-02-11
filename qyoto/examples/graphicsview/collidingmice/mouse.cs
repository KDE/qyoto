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
    
public class MouseTimer : QObject {
    private Mouse mouse;

    public MouseTimer(Mouse mouse) : base((QObject) null)
    {
        this.mouse = mouse;
        StartTimer(1000 / 33);
    }

    protected override void TimerEvent(QTimerEvent e) {
        mouse.TimerEvent(e);
    }
}

public class Mouse : QGraphicsItem {
    private double angle;
    private double speed;
    private double mouseEyeDirection;
    private QColor color;
    private MouseTimer timer;

    private static double Pi = 3.14159265358979323846264338327950288419717;
    private static double TwoPi = 2.0 * Pi;
    private static Random RandomClass = null;
    
    private static double NormalizeAngle(double angle)
    {
        while (angle < 0)
            angle += TwoPi;
        while (angle > TwoPi)
            angle -= TwoPi;
        return angle;
    }
    
    public Mouse() : base()
    {
        speed = 0;
        mouseEyeDirection = 0;
        RandomClass = new Random();
        color = new QColor(RandomClass.Next(255), RandomClass.Next(255), RandomClass.Next(255));
        timer = new MouseTimer(this);
        Rotate(RandomClass.Next(360 * 16));
    }
    
    public QRectF BoundingRect()
    {
        double adjust = 0.5;
        return new QRectF(-20 - adjust, -22 - adjust,
                      40 + adjust, 83 + adjust);
    }
    
    public QPainterPath Shape()
    {
        QPainterPath path = new QPainterPath();
        path.AddRect(-10, -20, 20, 40);
        return path;
    }
    
    public void Paint(QPainter painter, QStyleOptionGraphicsItem option, QWidget widget)
    {
        // Body
        painter.SetBrush(new QBrush(color));
        painter.DrawEllipse(-10, -20, 20, 40);
    
        // Eyes
        painter.SetBrush(new QBrush(Qt.GlobalColor.white));
        painter.DrawEllipse(-10, -17, 8, 8);
        painter.DrawEllipse(2, -17, 8, 8);
    
        // Nose
        painter.SetBrush(new QBrush(Qt.GlobalColor.black));
        painter.DrawEllipse(new QRectF(-2, -22, 4, 4));
    
        // Pupils
        painter.DrawEllipse(new QRectF(-8.0 + mouseEyeDirection, -17, 4, 4));
        painter.DrawEllipse(new QRectF(4.0 + mouseEyeDirection, -17, 4, 4));
    
        // Ears
        painter.SetBrush(new QBrush(Scene().CollidingItems(this).Count == 0 ? Qt.GlobalColor.darkYellow : Qt.GlobalColor.red));
        painter.DrawEllipse(-17, -12, 16, 16);
        painter.DrawEllipse(1, -12, 16, 16);
    
        // Tail
        QPainterPath path = new QPainterPath(new QPointF(0, 20));
        path.CubicTo(-5, 22, -5, 22, 0, 25);
        path.CubicTo(5, 27, 5, 32, 0, 30);
        path.CubicTo(-5, 32, -5, 42, 0, 35);
        painter.SetBrush(Qt.BrushStyle.NoBrush);
        painter.DrawPath(path);
    }
    
    public void TimerEvent(QTimerEvent e)
    {
        // Don't move too far away
        QLineF lineToCenter = new QLineF(new QPointF(0, 0), MapFromScene(0, 0));
        if (lineToCenter.Length() > 150) {
            double angleToCenter = Math.Acos(lineToCenter.Dx() / lineToCenter.Length());
            if (lineToCenter.Dy() < 0)
                angleToCenter = TwoPi - angleToCenter;
            angleToCenter = NormalizeAngle((Pi - angleToCenter) + Pi / 2);
    
            if (angleToCenter < Pi && angleToCenter > Pi / 4) {
                // Rotate left
                angle += (angle < -Pi / 2) ? 0.25 : -0.25;
            } else if (angleToCenter >= Pi && angleToCenter < (Pi + Pi / 2 + Pi / 4)) {
                // Rotate right
                angle += (angle < Pi / 2) ? 0.25 : -0.25;
            }
        } else if (Math.Sin(angle) < 0) {
            angle += 0.25;
        } else if (Math.Sin(angle) > 0) {
            angle -= 0.25;
        }
    
        // Try not to crash with any other mice
        List<QPointF> list = new List<QPointF>();
        list.Add(MapToScene(0, 0));
        list.Add(MapToScene(-30, -50));
        list.Add(MapToScene(30, -50));
        List<QGraphicsItem> dangerMice = Scene().Items(new QPolygonF(list));
        foreach (QGraphicsItem item in dangerMice) {
            if (item == this)
                continue;
            
            QLineF lineToMouse = new QLineF(new QPointF(0, 0), MapFromItem(item, 0, 0));
            double angleToMouse = Math.Acos(lineToMouse.Dx() / lineToMouse.Length());
            if (lineToMouse.Length() == 0) {
                angleToMouse = 0;
            }

            if (lineToMouse.Dy() < 0)
                angleToMouse = TwoPi - angleToMouse;
            angleToMouse = NormalizeAngle((Pi - angleToMouse) + Pi / 2);
    
            if (angleToMouse >= 0 && angleToMouse < Pi / 2) {
                // Rotate right
                angle += 0.5;
            } else if (angleToMouse <= TwoPi && angleToMouse > (TwoPi - Pi / 2)) {
                // Rotate left
                angle -= 0.5;
            }
        }
    
        // Add some random movement
        if (dangerMice.Count > 1 && (RandomClass.Next(10)) == 0) {
            if (RandomClass.Next(1) == 1)
                angle += (RandomClass.Next(100)) / 500.0;
            else
                angle -= (RandomClass.Next(100)) / 500.0;
        }
    
        speed += (-50 + RandomClass.Next(100)) / 100.0;
    
        double dx = Math.Sin(angle) * 10;
        mouseEyeDirection = (Math.Abs(dx / 5) < 1) ? 0 : dx / 5;
    
        Rotate(dx);
        SetPos(MapToParent(0, -(3 + Math.Sin(speed) * 3)));
    }
}
