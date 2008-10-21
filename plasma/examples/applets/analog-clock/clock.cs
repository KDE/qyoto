using System;
using System.Collections.Generic;

using Qyoto;
using Kimono;
using Plasma;

public class Clock : ClockApplet, IDisposable {
    bool m_showTimeString = false;
    bool m_showSecondHand = false;
    bool m_fancyHands = false;
    Plasma.Svg m_theme;
    QTime m_time = new QTime();
    QTime m_lastTimeSeen = new QTime();
    QTimer m_secondHandUpdateTimer = null;
    int m_animationStart = 0;
    /// Designer Config file
    Ui.clockConfig ui = new Ui.clockConfig();

    public static object reference = null;

    public Clock(AppletScript parent) : base(parent) {
        KGlobal.Locale().InsertCatalog("libplasmaclock");

        HasConfigurationInterface = true;
        Resize(125, 125);
        SetAspectRatioMode(Plasma.AspectRatioMode.Square);

        m_theme = new Plasma.Svg(this);
        m_theme.ImagePath = "widgets/clock";
        m_theme.MultipleImages = false;
        m_theme.Resize(Size);
        reference = this;
    }

    public override void Init() {
        base.Init();

        KConfigGroup cg = Config();
        m_showTimeString = cg.ReadEntry("showTimeString", false);
        m_showSecondHand = cg.ReadEntry("showSecondHand", false);
        m_fancyHands = cg.ReadEntry("fancyHands", false);
        SetCurrentTimezone(cg.ReadEntry("timezone", LocalTimezone));

        ConnectToEngine();
    }

    public override void PaintInterface(QPainter p, QStyleOptionGraphicsItem option, QRect rect) {
        QRectF tempRect = new QRectF(0, 0, 0, 0);

        QSizeF boundSize = Geometry.Size();
        QSize elementSize = new QSize();

        p.SetRenderHint(QPainter.RenderHint.SmoothPixmapTransform);

        double minutes = 6.0 * m_time.Minute() - 180;
        double hours = 30.0 * m_time.Hour() - 180 +
                            ((m_time.Minute() / 59.0) * 30.0);

        m_theme.Paint(p, rect, "ClockFace");

        
        //optionally paint the time string
        if (m_showTimeString) {
            string time;
            QFontMetrics fm = new QFontMetrics(QApplication.Font());
            const int margin = 4;

            if (m_showSecondHand) {
                //FIXME: temporary time output
                time = m_time.ToString();
            } else {
                time = m_time.ToString("hh:mm");
            }

            QRect textRect = new QRect((rect.Width()/2 - fm.Width(time) / 2),((rect.Height()/2) - fm.XHeight()*4),
                fm.Width(time), fm.XHeight());

            p.SetPen(Qt.PenStyle.NoPen);
            QColor background = Plasma.Theme.DefaultTheme().Color(Plasma.Theme.ColorRole.BackgroundColor);
            background.SetAlphaF(0.5);
            p.SetBrush(background);

            p.SetRenderHint(QPainter.RenderHint.Antialiasing, true);
            p.DrawPath(Plasma.PaintUtils.Global.RoundedRectangle(textRect.Adjusted(-margin, -margin, margin, margin), margin));
            p.SetRenderHint(QPainter.RenderHint.Antialiasing, false);

            p.SetPen(Plasma.Theme.DefaultTheme().Color(Plasma.Theme.ColorRole.TextColor));
            
            p.DrawText(textRect.BottomLeft(), time);
        }


        //Make sure we paint the second hand on top of the others
        double seconds = 0;
        if (m_showSecondHand) {
            const double anglePerSec = 6;
            seconds = anglePerSec * m_time.Second() - 180;

            if (m_fancyHands) {
                if (m_secondHandUpdateTimer == null) {
                    m_secondHandUpdateTimer = new QTimer(this);
                    Connect(m_secondHandUpdateTimer, SIGNAL("timeout()"), this, SLOT("moveSecondHand()"));
                }

                if (!m_secondHandUpdateTimer.Active) {
                    //kDebug() << "starting second hand movement";
                    m_secondHandUpdateTimer.Start(50);
                    m_animationStart = QTime.CurrentTime().Msec();
                } else {
                    const int runTime = 500;
                    const double m = 1; // Mass
                    const double b = 1; // Drag coefficient
                    const double k = 1.5; // Spring constant
                    const double PI = 3.141592653589793; // the universe is irrational
                    const double gamma = b / (2 * m); // Dampening constant
                    double omega0 = Math.Sqrt(k / m);
                    double omega1 = Math.Sqrt(omega0 * omega0 - gamma * gamma);
                    double elapsed = QTime.CurrentTime().Msec() - m_animationStart;
                    double t = (4 * PI) * (elapsed / runTime);
                    double val = 1 + Math.Exp(-gamma * t) * - Math.Cos(omega1 * t);

                    if (elapsed > runTime) {
                        m_secondHandUpdateTimer.Stop();
                    } else {
                        seconds += -anglePerSec + (anglePerSec * val);
                    }
                }
            }
        }

        if (m_theme.HasElement("HourHandShadow")) {
            p.Translate(1,3);

            DrawHand(p, hours, "HourHandShadow");
            DrawHand(p, minutes, "MinuteHandShadow");

            if (m_showSecondHand) {
                DrawHand(p, seconds, "SecondHandShadow");
            }

            p.Translate(-1,-3);
        }
        
        DrawHand(p, hours, "HourHand");
        DrawHand(p, minutes, "MinuteHand");
        if (m_showSecondHand) {
            DrawHand(p, seconds, "SecondHand");
        }

        p.Save();
        elementSize = m_theme.ElementSize("HandCenterScrew");
        tempRect.SetSize(elementSize);
        p.Translate(boundSize.Width() / 2 - elementSize.Width() / 2, boundSize.Height() / 2 - elementSize.Height() / 2);
        m_theme.Paint(p, tempRect, "HandCenterScrew");
        p.Restore();

        m_theme.Paint(p, rect, "Glass");
    }
    
    public void SetPath(string path) {
    }
    
    public override void ConstraintsEvent(uint constraints) {
        if ((constraints & (uint) Plasma.Constraint.FormFactorConstraint) > 0) {
            SetBackgroundHints((uint) Applet.BackgroundHint.NoBackground);
        }

        if ((constraints & (uint) Plasma.Constraint.SizeConstraint) > 0) {
            m_theme.Resize(Size);
        }
    }
    
    protected override QPainterPath Shape() {
        if (m_theme.HasElement("hint-square-clock")) {
            return base.Shape();
        }

        QPainterPath path = new QPainterPath();
        // we adjust by 2px all around to allow for smoothing the jaggies
        // if the ellipse is too small, we'll get a nastily jagged edge around the clock
        path.AddEllipse(BoundingRect().Adjusted(-2, -2, 2, 2));
        return path;
    }

    [Q_SLOT("void dataUpdated(QString,Plasma::DataEngine::Data)")]
    public void DataUpdated(string name, Dictionary<string, QVariant> data) {
        m_time = data["Time"].ToTime();

        if (m_time.Minute() == m_lastTimeSeen.Minute() &&
            m_time.Second() == m_lastTimeSeen.Second()) {
            // avoid unnecessary repaints
            return;
        }

        if (m_secondHandUpdateTimer != null) {
            m_secondHandUpdateTimer.Stop();
        }

        m_lastTimeSeen = m_time;
        Update();
    }

    protected override void CreateClockConfigurationInterface(KConfigDialog parent) {
        //TODO: Make the size settable
        QWidget widget = new QWidget();
        ui.SetupUi(widget);
        parent.AddPage(widget, KDE.Ki18n("General").ToString(), Icon());

        ui.showTimeStringCheckBox.Checked = m_showTimeString;
        ui.showSecondHandCheckBox.Checked = m_showSecondHand;
    }
    
    protected override void ChangeEngineTimezone(string oldTimezone, string newTimezone) {
        DataEngine("time").DisconnectSource(oldTimezone, this);
        Plasma.DataEngine timeEngine = DataEngine("time");
        if (m_showSecondHand) {
            timeEngine.ConnectSource(newTimezone, this, 500);
        } else {
            timeEngine.ConnectSource(newTimezone, this, 6000, Plasma.IntervalAlignment.AlignToMinute);
        }
    }

    [Q_SLOT]
    protected override void ClockConfigAccepted() {
        KConfigGroup cg = Config();
        m_showTimeString = ui.showTimeStringCheckBox.Checked;
        m_showSecondHand = ui.showSecondHandCheckBox.Checked;

        cg.WriteEntry("showTimeString", m_showTimeString);
        cg.WriteEntry("showSecondHand", m_showSecondHand);
        Update();

        DataEngine("time").DisconnectSource(CurrentTimezone, this);
        ConnectToEngine();

        //TODO: why we don't call updateConstraints()?
        ConstraintsEvent((uint) Plasma.Constraint.AllConstraints);
        Emit.ConfigNeedsSaving();
    }
    
    [Q_SLOT]
    protected void MoveSecondHand() {
        Update();
    }

    private void DrawHand(QPainter p, double rotation, string handName) {
        p.Save();
        QSizeF boundSize = BoundingRect().Size();
        QRectF elementRect = m_theme.ElementRect(handName);

        p.Translate(boundSize.Width() / 2, boundSize.Height() / 2);
        p.Rotate(rotation);
        p.Translate(-elementRect.Width() / 2, -(m_theme.ElementRect("clockFace").Center().Y() - elementRect.Top()) );
        m_theme.Paint(p, new QRectF(new QPointF(0, 0), elementRect.Size()), handName);
    
        p.Restore();
    }
    
    private void ConnectToEngine() {
        Plasma.DataEngine timeEngine = DataEngine("time");
        if (m_showSecondHand) {
            timeEngine.ConnectSource(CurrentTimezone, this, 500);
        } else {
            timeEngine.ConnectSource(CurrentTimezone, this, 6000, Plasma.IntervalAlignment.AlignToMinute);
        }
    }
}
