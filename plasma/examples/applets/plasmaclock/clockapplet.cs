using System;
using System.Collections.Generic;

using Qyoto;
using Kimono;
using Plasma;

public class ClockApplet : PlasmaScripting.Applet {
    Ui.timezonesConfig ui = new Ui.timezonesConfig();
    Plasma.Dialog calendarDialog = null;
    KDatePicker calendar = null;
    QGraphicsView view = null;
    string timezone = "local";
    QPoint clicked = new QPoint();
    List<string> m_timeZones = new List<string>();

    public ClockApplet(AppletScript a) : base(a) {
    }
    
    Plasma.Extender extender;
    public override void Init() {
        extender = new Plasma.Extender(this);
        Containment().Corona().AddOffscreenWidget(extender);
    }

    public string CurrentTimezone {
        get { return timezone; }
        set { timezone = value; }
    }
    
    public bool IsLocalTimezone {
        get { return LocalTimezone == CurrentTimezone; }
    }

    public static string LocalTimezone {
        get { return "Local"; }
    }

    protected override void MousePressEvent(QGraphicsSceneMouseEvent e) {
        if (e.Buttons() == (uint) Qt.MouseButton.LeftButton) {
            clicked = ScenePos().ToPoint();
            e.Accepted = true;
            return;
        }

        base.MousePressEvent(e);
    }
    
    protected override void MouseReleaseEvent(QGraphicsSceneMouseEvent e) {
        if ((clicked - ScenePos().ToPoint()).ManhattanLength() < KGlobalSettings.DndEventDelay()) {
            ShowCalendar(e);
        }
    }
    
    public override void CreateConfigurationInterface(KConfigDialog parent) {
        CreateClockConfigurationInterface(parent);

        QWidget widget = new QWidget();
        ui.SetupUi(widget);

        parent.AddPage(widget, KDE.I18n("Time Zones"), Icon());

        ui.localTimeZone.Checked = IsLocalTimezone;
        ui.timeZones.SetSelected(CurrentTimezone, true);
        ui.timeZones.Enabled = !IsLocalTimezone;

        parent.SetButtons( (uint) (KDialog.ButtonCode.Ok | KDialog.ButtonCode.Cancel | KDialog.ButtonCode.Apply) );
        Connect(parent, SIGNAL("applyClicked()"), this, SLOT("ConfigAccepted()"));
        Connect(parent, SIGNAL("okClicked()"), this, SLOT("ConfigAccepted()"));
    }
    
    protected virtual void CreateClockConfigurationInterface(KConfigDialog parent) {
    }
    
    protected virtual void ClockConfigAccepted() {
    }
    
    protected virtual void ChangeEngineTimezone(string oldTimezone, string newTimezone) {
    }
    
    QGraphicsProxyWidget proxy;
    public override void InitExtenderItem(ExtenderItem item) {
        calendar = new KDatePicker();
        calendar.MinimumSize = calendar.SizeHint();
        proxy = new QGraphicsProxyWidget(this);
        proxy.SetWidget(calendar);
        item.Widget = proxy;
        item.Title = KDE.Ki18n("Calendar").ToString();
    }

    [Q_SLOT]
    protected void SetCurrentTimezone(string tz) {
        CurrentTimezone = tz;
    }
    
    Plasma.ExtenderItem eItem;
    [Q_SLOT]
    protected void ShowCalendar(QGraphicsSceneMouseEvent e) {
        if (calendarDialog == null) {
            if (Extender() == null) {
                // in case the subclass didn't call the parent init() properly
                this.Init();
            }

            if (calendar == null) {
                eItem = new Plasma.ExtenderItem(Extender());
                eItem.Name = "calendar";
                InitExtenderItem(eItem);
            }

            calendarDialog = new Plasma.Dialog();
            calendarDialog.WindowFlags = (uint) Qt.WindowType.Popup;
            calendarDialog.SetGraphicsWidget(Extender());
        }

        if (calendarDialog.IsVisible()) {
            calendarDialog.Hide();
        } else {
            //kDebug();
            Dictionary<string, QVariant> data = DataEngine("time").Query(CurrentTimezone);
            calendar.Date = data["Date"].ToDate();
            calendarDialog.Pos = PopupPosition(calendarDialog.SizeHint());
            calendarDialog.Show();
        }
    }
    
    [Q_SLOT]
    protected void ConfigAccepted() {
        KConfigGroup cg = Config();

        m_timeZones = ui.timeZones.Selection();
        cg.WriteEntry("timeZones", m_timeZones);

        string newTimezone = LocalTimezone;

        if (!ui.localTimeZone.Checked && m_timeZones.Count != 0) {
            newTimezone = m_timeZones[0];
        }

        ChangeEngineTimezone(CurrentTimezone, newTimezone);

        SetCurrentTimezone(newTimezone);
        cg.WriteEntry("currentTimezone", newTimezone);

        ClockConfigAccepted();

        ConstraintsEvent((uint) Plasma.Constraint.SizeConstraint);
        Update();
        Emit.ConfigNeedsSaving();
    }
    
    [Q_SLOT]
    protected void AdjustView() {
        if (view != null && Extender() != null) {
            view.SceneRect = Extender().MapToScene(Extender().BoundingRect()).BoundingRect();
            view.Size = Extender().Size.ToSize();
        }
    }

    private void UpdateToolTipContent() {
        //QString timeString = KGlobal::locale()->formatTime(d->time, d->showSeconds);
        //TODO port to TOOLTIP manager
        /*Plasma::ToolTipData tipData;

        tipData.mainText = "";//d->time.toString(timeString);
        tipData.subText = "";//d->date.toString();
        //tipData.image = d->toolTipIcon;

        setToolTip(tipData);*/
    }
}
