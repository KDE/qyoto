//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    using System.Collections.Generic;
    /// <remarks> See <see cref="IQDialogButtonBoxSignals"></see> for signals emitted by QDialogButtonBox
    /// </remarks>
    [SmokeClass("QDialogButtonBox")]
    public class QDialogButtonBox : QWidget, IDisposable {
        protected QDialogButtonBox(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QDialogButtonBox), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QDialogButtonBox() {
            staticInterceptor = new SmokeInvocation(typeof(QDialogButtonBox), null);
        }
        public enum ButtonRole {
            InvalidRole = -1,
            AcceptRole = 0,
            RejectRole = 1,
            DestructiveRole = 2,
            ActionRole = 3,
            HelpRole = 4,
            YesRole = 5,
            NoRole = 6,
            ResetRole = 7,
            ApplyRole = 8,
            NRoles = 9,
        }
        public enum StandardButton {
            NoButton = 0x00000000,
            Ok = 0x00000400,
            Save = 0x00000800,
            SaveAll = 0x00001000,
            Open = 0x00002000,
            Yes = 0x00004000,
            YesToAll = 0x00008000,
            No = 0x00010000,
            NoToAll = 0x00020000,
            Abort = 0x00040000,
            Retry = 0x00080000,
            Ignore = 0x00100000,
            Close = 0x00200000,
            Cancel = 0x00400000,
            Discard = 0x00800000,
            Help = 0x01000000,
            Apply = 0x02000000,
            Reset = 0x04000000,
            RestoreDefaults = 0x08000000,
            FirstButton = Ok,
            LastButton = RestoreDefaults,
        }
        public enum ButtonLayout {
            WinLayout = 0,
            MacLayout = 1,
            KdeLayout = 2,
            GnomeLayout = 3,
        }
        [Q_PROPERTY("Qt::Orientation", "orientation")]
        public new Qt.Orientation Orientation {
            get { return (Qt.Orientation) interceptor.Invoke("orientation", "orientation()", typeof(Qt.Orientation)); }
            set { interceptor.Invoke("setOrientation$", "setOrientation(Qt::Orientation)", typeof(void), typeof(Qt.Orientation), value); }
        }
        [Q_PROPERTY("QDialogButtonBox::StandardButtons", "standardButtons")]
        public uint StandardButtons {
            get { return (uint) interceptor.Invoke("standardButtons", "standardButtons()", typeof(uint)); }
            set { interceptor.Invoke("setStandardButtons$", "setStandardButtons(QDialogButtonBox::StandardButtons)", typeof(void), typeof(uint), value); }
        }
        [Q_PROPERTY("bool", "centerButtons")]
        public bool CenterButtons {
            get { return (bool) interceptor.Invoke("centerButtons", "centerButtons()", typeof(bool)); }
            set { interceptor.Invoke("setCenterButtons$", "setCenterButtons(bool)", typeof(void), typeof(bool), value); }
        }
        public QDialogButtonBox(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox#", "QDialogButtonBox(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public QDialogButtonBox() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox", "QDialogButtonBox()", typeof(void));
        }
        public QDialogButtonBox(Qt.Orientation orientation, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox$#", "QDialogButtonBox(Qt::Orientation, QWidget*)", typeof(void), typeof(Qt.Orientation), orientation, typeof(QWidget), parent);
        }
        public QDialogButtonBox(Qt.Orientation orientation) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox$", "QDialogButtonBox(Qt::Orientation)", typeof(void), typeof(Qt.Orientation), orientation);
        }
        public QDialogButtonBox(uint buttons, Qt.Orientation orientation, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox$$#", "QDialogButtonBox(QDialogButtonBox::StandardButtons, Qt::Orientation, QWidget*)", typeof(void), typeof(uint), buttons, typeof(Qt.Orientation), orientation, typeof(QWidget), parent);
        }
        public QDialogButtonBox(uint buttons, Qt.Orientation orientation) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox$$", "QDialogButtonBox(QDialogButtonBox::StandardButtons, Qt::Orientation)", typeof(void), typeof(uint), buttons, typeof(Qt.Orientation), orientation);
        }
        public QDialogButtonBox(uint buttons) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDialogButtonBox$", "QDialogButtonBox(QDialogButtonBox::StandardButtons)", typeof(void), typeof(uint), buttons);
        }
        public void AddButton(QAbstractButton button, QDialogButtonBox.ButtonRole role) {
            interceptor.Invoke("addButton#$", "addButton(QAbstractButton*, QDialogButtonBox::ButtonRole)", typeof(void), typeof(QAbstractButton), button, typeof(QDialogButtonBox.ButtonRole), role);
        }
        public QPushButton AddButton(string text, QDialogButtonBox.ButtonRole role) {
            return (QPushButton) interceptor.Invoke("addButton$$", "addButton(const QString&, QDialogButtonBox::ButtonRole)", typeof(QPushButton), typeof(string), text, typeof(QDialogButtonBox.ButtonRole), role);
        }
        public QPushButton AddButton(QDialogButtonBox.StandardButton button) {
            return (QPushButton) interceptor.Invoke("addButton$", "addButton(QDialogButtonBox::StandardButton)", typeof(QPushButton), typeof(QDialogButtonBox.StandardButton), button);
        }
        public void RemoveButton(QAbstractButton button) {
            interceptor.Invoke("removeButton#", "removeButton(QAbstractButton*)", typeof(void), typeof(QAbstractButton), button);
        }
        public void Clear() {
            interceptor.Invoke("clear", "clear()", typeof(void));
        }
        public List<QAbstractButton> Buttons() {
            return (List<QAbstractButton>) interceptor.Invoke("buttons", "buttons() const", typeof(List<QAbstractButton>));
        }
        public QDialogButtonBox.ButtonRole buttonRole(QAbstractButton button) {
            return (QDialogButtonBox.ButtonRole) interceptor.Invoke("buttonRole#", "buttonRole(QAbstractButton*) const", typeof(QDialogButtonBox.ButtonRole), typeof(QAbstractButton), button);
        }
        public QDialogButtonBox.StandardButton standardButton(QAbstractButton button) {
            return (QDialogButtonBox.StandardButton) interceptor.Invoke("standardButton#", "standardButton(QAbstractButton*) const", typeof(QDialogButtonBox.StandardButton), typeof(QAbstractButton), button);
        }
        public QPushButton Button(QDialogButtonBox.StandardButton which) {
            return (QPushButton) interceptor.Invoke("button$", "button(QDialogButtonBox::StandardButton) const", typeof(QPushButton), typeof(QDialogButtonBox.StandardButton), which);
        }
        [SmokeMethod("changeEvent(QEvent*)")]
        protected override void ChangeEvent(QEvent arg1) {
            interceptor.Invoke("changeEvent#", "changeEvent(QEvent*)", typeof(void), typeof(QEvent), arg1);
        }
        [SmokeMethod("event(QEvent*)")]
        protected override bool Event(QEvent arg1) {
            return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
        }
        ~QDialogButtonBox() {
            interceptor.Invoke("~QDialogButtonBox", "~QDialogButtonBox()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QDialogButtonBox", "~QDialogButtonBox()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQDialogButtonBoxSignals Emit {
            get { return (IQDialogButtonBoxSignals) Q_EMIT; }
        }
    }

    public interface IQDialogButtonBoxSignals : IQWidgetSignals {
        [Q_SIGNAL("void clicked(QAbstractButton*)")]
        void Clicked(QAbstractButton button);
        [Q_SIGNAL("void accepted()")]
        void Accepted();
        [Q_SIGNAL("void helpRequested()")]
        void HelpRequested();
        [Q_SIGNAL("void rejected()")]
        void Rejected();
    }
}
