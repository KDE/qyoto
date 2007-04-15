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
    bool gameEnded;
    bool barrelPressed;

    public CannonField() : this((QWidget) null) {}

    public CannonField(QWidget parent) : base(parent) {
        currentAngle = 45;
        currentForce = 0;
        timerCount = 0;
        autoShootTimer = new QTimer(this);
        Connect(autoShootTimer, SIGNAL("timeout()"), this, SLOT("MoveShot()"));
        shootAngle = 0;
        shootForce = 0;
        target = new QPoint(0, 0);
        gameEnded = false;
        barrelPressed = false;
        Palette = new QPalette(new QColor(250, 250, 200));
        AutoFillBackground = true;
        NewTarget();
    }

    [Q_SLOT]
    public void SetAngle(int angle) {
        if (angle < 5)
            angle = 5;
        if (angle > 70)
            angle = 70;
        if (currentAngle == angle)
            return;
        currentAngle = angle;
        Update(CannonRect());
        Emit.AngleChanged(currentAngle);
    }

    [Q_SLOT]
    public void SetForce(int force) {
        if (force < 0)
            force = 0;
        if (currentForce == force)
            return;
        currentForce = force;
        Emit.ForceChanged(currentForce);
    }

    [Q_SLOT]
    public void Shoot() {
        if (IsShooting)
            return;
        timerCount = 0;
        shootAngle = currentAngle;
        shootForce = currentForce;
        autoShootTimer.Start(25);
        Emit.CanShoot(false);
    }

    private static bool firstTime = true;
    private static Random random = null;

    [Q_SLOT]
    public void NewTarget() {
        if (firstTime) {
            firstTime = false;
            random = new Random();
        }

        target = new QPoint(200 + random.Next(190), 10 + random.Next(255));
        Update();
    }

    [Q_SLOT]
    public void SetGameOver() {
        if (gameEnded)
            return;
        if (IsShooting)
            autoShootTimer.Stop();
        gameEnded = true;
        Update();
    }

    [Q_SLOT]
    public void RestartGame() {
        if (IsShooting)
            autoShootTimer.Stop();
        gameEnded = false;
        Update();
        Emit.CanShoot(true);
    }

    [Q_SLOT]
    private void MoveShot() {
        QRegion region = new QRegion(ShotRect());
        timerCount++;

        QRect shotR = ShotRect();

        if (shotR.Intersects(TargetRect())) {
            autoShootTimer.Stop();
            Emit.Hit();
            Emit.CanShoot(true);
        } else if (shotR.X() > Width() || shotR.Y() > Height()
                   || shotR.Intersects(BarrierRect())) {
            autoShootTimer.Stop();
            Emit.Missed();
            Emit.CanShoot(true);
        } else {
            region = region.Unite(shotR);
        }

        Update(region);
    }

    protected override void MousePressEvent(QMouseEvent e) {
        if (e.Button() != Qt.MouseButton.LeftButton)
            return;
        if (BarrelHit(e.Pos()))
            barrelPressed = true;
    }

    protected override void MouseMoveEvent(QMouseEvent e) {
        if (!barrelPressed)
            return;
        QPoint pos = e.Pos();
        if (pos.X() <= 0)
            pos.SetX(1);
        if (pos.Y() >= Height())
            pos.SetY(Height() - 1);
        double rad = Math.Atan(((double)Rect.Bottom() - pos.Y()) / pos.X());
        SetAngle((int) Math.Round(rad * 180 / 3.14159265));
    }

    protected override void MouseReleaseEvent(QMouseEvent e) {
        if (e.Button() == Qt.MouseButton.LeftButton)
            barrelPressed = false;
    }

    protected override void PaintEvent(QPaintEvent arg1) {
        QPainter painter = new QPainter(this);

        if (gameEnded) {
            painter.SetPen(Qt.GlobalColor.black);
            painter.SetFont(new QFont("Courier", 48, (int) QFont.Weight.Bold));
            painter.DrawText(Rect, (int) Qt.AlignmentFlag.AlignCenter, Tr("Game Over"));
        }

        PaintCannon(painter);
        PaintBarrier(painter);
        if (IsShooting)
            PaintShot(painter);
        if (!gameEnded)
            PaintTarget(painter);

        painter.End();
    }

    private void PaintShot(QPainter painter) {
        painter.SetPen(Qt.PenStyle.NoPen);
        painter.SetBrush(Qt.GlobalColor.black);
        painter.DrawRect(ShotRect());
    }

    private void PaintTarget(QPainter painter) {
        painter.SetPen(Qt.GlobalColor.black);
        painter.SetBrush(Qt.GlobalColor.red);
        painter.DrawRect(TargetRect());
    }

    private void PaintBarrier(QPainter painter) {
        painter.SetPen(Qt.GlobalColor.black);
        painter.SetBrush(Qt.GlobalColor.yellow);
        painter.DrawRect(BarrierRect());
    }

    public QRect barrelRect = new QRect(30, -5, 20, 10);

    private void PaintCannon(QPainter painter) {
        painter.SetPen(Qt.PenStyle.NoPen);
        painter.SetBrush(Qt.GlobalColor.blue);
        
        painter.Save();
        painter.Translate(0, Height());
        painter.DrawPie(new QRect(-35, -35, 70, 70), 0, 90 * 16);
        painter.Rotate(-currentAngle);
        painter.DrawRect(barrelRect);
        painter.Restore();
    }

    private QRect CannonRect() {
        QRect result = new QRect(0, 0, 50, 50);
        result.MoveBottomLeft(Rect.BottomLeft());
        return result;
    }

    private QRect ShotRect() {
        const double gravity = 4;
        
        double time = timerCount / 4.0;
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

    private QRect TargetRect() {
        QRect result = new QRect(0, 0, 20, 10);
        result.MoveCenter(new QPoint(target.X(), Height() - 1 - target.Y()));
        return result;
    }

    private QRect BarrierRect() {
        return new QRect(145, Height() - 100, 15, 99);
    }

    private bool BarrelHit(QPoint pos) {
        QMatrix matrix = new QMatrix();
        matrix.Translate(0, Height());
        matrix.Rotate(-currentAngle);
        matrix = matrix.Inverted();
        return barrelRect.Contains(matrix.Map(pos));

    }

    public override QSize SizeHint() {
        return new QSize(400, 300);
    }

    public bool IsShooting {
        get { return autoShootTimer.Active; }
    }
    
    public int Angle { get { return currentAngle; } }
    public int Force { get { return currentForce; } }
    public bool GameOver { get { return gameEnded; } }

    protected new ICannonFieldSignals Emit {
        get { return (ICannonFieldSignals) Q_EMIT; }
    }
}

interface ICannonFieldSignals : IQWidgetSignals {
    [Q_SIGNAL]
    void Hit();

    [Q_SIGNAL]
    void Missed();

    [Q_SIGNAL]
    void AngleChanged(int newAngle);

    [Q_SIGNAL]
    void ForceChanged(int newForce);

    [Q_SIGNAL]
    void CanShoot(bool can);
}
