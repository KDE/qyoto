//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    /// <remarks> See <see cref="IQAbstractButtonSignals"></see> for signals emitted by QAbstractButton
    /// </remarks>
    [SmokeClass("QAbstractButton")]
    public abstract class QAbstractButton : QWidget {
        protected QAbstractButton(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QAbstractButton), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QAbstractButton() {
            staticInterceptor = new SmokeInvocation(typeof(QAbstractButton), null);
        }
        [Q_PROPERTY("QString", "text")]
        public string Text {
            get { return (string) interceptor.Invoke("text", "text()", typeof(string)); }
            set { interceptor.Invoke("setText$", "setText(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("QIcon", "icon")]
        public QIcon icon {
            get { return (QIcon) interceptor.Invoke("icon", "icon()", typeof(QIcon)); }
            set { interceptor.Invoke("setIcon#", "setIcon(QIcon)", typeof(void), typeof(QIcon), value); }
        }
        [Q_PROPERTY("QSize", "iconSize")]
        public QSize IconSize {
            get { return (QSize) interceptor.Invoke("iconSize", "iconSize()", typeof(QSize)); }
            set { interceptor.Invoke("setIconSize#", "setIconSize(QSize)", typeof(void), typeof(QSize), value); }
        }
        [Q_PROPERTY("QKeySequence", "shortcut")]
        public QKeySequence Shortcut {
            get { return (QKeySequence) interceptor.Invoke("shortcut", "shortcut()", typeof(QKeySequence)); }
            set { interceptor.Invoke("setShortcut#", "setShortcut(QKeySequence)", typeof(void), typeof(QKeySequence), value); }
        }
        [Q_PROPERTY("bool", "checkable")]
        public bool Checkable {
            get { return (bool) interceptor.Invoke("isCheckable", "isCheckable()", typeof(bool)); }
            set { interceptor.Invoke("setCheckable$", "setCheckable(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("bool", "checked")]
        public bool Checked {
            get { return (bool) interceptor.Invoke("isChecked", "isChecked()", typeof(bool)); }
            set { interceptor.Invoke("setChecked$", "setChecked(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("bool", "autoRepeat")]
        public bool AutoRepeat {
            get { return (bool) interceptor.Invoke("autoRepeat", "autoRepeat()", typeof(bool)); }
            set { interceptor.Invoke("setAutoRepeat$", "setAutoRepeat(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("bool", "autoExclusive")]
        public bool AutoExclusive {
            get { return (bool) interceptor.Invoke("autoExclusive", "autoExclusive()", typeof(bool)); }
            set { interceptor.Invoke("setAutoExclusive$", "setAutoExclusive(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("int", "autoRepeatDelay")]
        public int AutoRepeatDelay {
            get { return (int) interceptor.Invoke("autoRepeatDelay", "autoRepeatDelay()", typeof(int)); }
            set { interceptor.Invoke("setAutoRepeatDelay$", "setAutoRepeatDelay(int)", typeof(void), typeof(int), value); }
        }
        [Q_PROPERTY("int", "autoRepeatInterval")]
        public int AutoRepeatInterval {
            get { return (int) interceptor.Invoke("autoRepeatInterval", "autoRepeatInterval()", typeof(int)); }
            set { interceptor.Invoke("setAutoRepeatInterval$", "setAutoRepeatInterval(int)", typeof(void), typeof(int), value); }
        }
        [Q_PROPERTY("bool", "down")]
        public bool Down {
            get { return (bool) interceptor.Invoke("isDown", "isDown()", typeof(bool)); }
            set { interceptor.Invoke("setDown$", "setDown(bool)", typeof(void), typeof(bool), value); }
        }
        // QAbstractButton* QAbstractButton(QAbstractButtonPrivate& arg1,QWidget* arg2); >>>> NOT CONVERTED
        // QAbstractButton* QAbstractButton(QAbstractButtonPrivate& arg1); >>>> NOT CONVERTED
        public QAbstractButton(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QAbstractButton#", "QAbstractButton(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public QAbstractButton() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QAbstractButton", "QAbstractButton()", typeof(void));
        }
        public QButtonGroup Group() {
            return (QButtonGroup) interceptor.Invoke("group", "group() const", typeof(QButtonGroup));
        }
        [Q_SLOT("void setIconSize(QSize)")]
        public void SetIconSize(QSize size) {
            interceptor.Invoke("setIconSize#", "setIconSize(const QSize&)", typeof(void), typeof(QSize), size);
        }
        [Q_SLOT("void animateClick(int)")]
        public void AnimateClick(int msec) {
            interceptor.Invoke("animateClick$", "animateClick(int)", typeof(void), typeof(int), msec);
        }
        [Q_SLOT("void animateClick()")]
        public void AnimateClick() {
            interceptor.Invoke("animateClick", "animateClick()", typeof(void));
        }
        [Q_SLOT("void click()")]
        public void Click() {
            interceptor.Invoke("click", "click()", typeof(void));
        }
        [Q_SLOT("void toggle()")]
        public void Toggle() {
            interceptor.Invoke("toggle", "toggle()", typeof(void));
        }
        [Q_SLOT("void setChecked(bool)")]
        public void SetChecked(bool arg1) {
            interceptor.Invoke("setChecked$", "setChecked(bool)", typeof(void), typeof(bool), arg1);
        }
        [SmokeMethod("paintEvent(QPaintEvent*)")]
        protected new abstract void PaintEvent(QPaintEvent e);
        [SmokeMethod("hitButton(const QPoint&) const")]
        protected virtual bool HitButton(QPoint pos) {
            return (bool) interceptor.Invoke("hitButton#", "hitButton(const QPoint&) const", typeof(bool), typeof(QPoint), pos);
        }
        [SmokeMethod("checkStateSet()")]
        protected virtual void CheckStateSet() {
            interceptor.Invoke("checkStateSet", "checkStateSet()", typeof(void));
        }
        [SmokeMethod("nextCheckState()")]
        protected virtual void NextCheckState() {
            interceptor.Invoke("nextCheckState", "nextCheckState()", typeof(void));
        }
        [SmokeMethod("event(QEvent*)")]
        protected override bool Event(QEvent e) {
            return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), e);
        }
        [SmokeMethod("keyPressEvent(QKeyEvent*)")]
        protected override void KeyPressEvent(QKeyEvent e) {
            interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), e);
        }
        [SmokeMethod("keyReleaseEvent(QKeyEvent*)")]
        protected override void KeyReleaseEvent(QKeyEvent e) {
            interceptor.Invoke("keyReleaseEvent#", "keyReleaseEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), e);
        }
        [SmokeMethod("mousePressEvent(QMouseEvent*)")]
        protected override void MousePressEvent(QMouseEvent e) {
            interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), e);
        }
        [SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
        protected override void MouseReleaseEvent(QMouseEvent e) {
            interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), e);
        }
        [SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
        protected override void MouseMoveEvent(QMouseEvent e) {
            interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), e);
        }
        [SmokeMethod("focusInEvent(QFocusEvent*)")]
        protected override void FocusInEvent(QFocusEvent e) {
            interceptor.Invoke("focusInEvent#", "focusInEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), e);
        }
        [SmokeMethod("focusOutEvent(QFocusEvent*)")]
        protected override void FocusOutEvent(QFocusEvent e) {
            interceptor.Invoke("focusOutEvent#", "focusOutEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), e);
        }
        [SmokeMethod("changeEvent(QEvent*)")]
        protected override void ChangeEvent(QEvent e) {
            interceptor.Invoke("changeEvent#", "changeEvent(QEvent*)", typeof(void), typeof(QEvent), e);
        }
        [SmokeMethod("timerEvent(QTimerEvent*)")]
        protected override void TimerEvent(QTimerEvent e) {
            interceptor.Invoke("timerEvent#", "timerEvent(QTimerEvent*)", typeof(void), typeof(QTimerEvent), e);
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQAbstractButtonSignals Emit {
            get { return (IQAbstractButtonSignals) Q_EMIT; }
        }
    }

    public interface IQAbstractButtonSignals : IQWidgetSignals {
        [Q_SIGNAL("void pressed()")]
        void Pressed();
        [Q_SIGNAL("void released()")]
        void Released();
        [Q_SIGNAL("void clicked(bool)")]
        void Clicked(bool arg1);
        [Q_SIGNAL("void clicked()")]
        void Clicked();
        [Q_SIGNAL("void toggled(bool)")]
        void Toggled(bool arg1);
    }
}
