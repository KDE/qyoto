//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    /// <remarks> See <see cref="IQSplashScreenSignals"></see> for signals emitted by QSplashScreen
    /// </remarks>
    [SmokeClass("QSplashScreen")]
    public class QSplashScreen : QWidget, IDisposable {
        protected QSplashScreen(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QSplashScreen), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QSplashScreen() {
            staticInterceptor = new SmokeInvocation(typeof(QSplashScreen), null);
        }
        public QSplashScreen(QPixmap pixmap, uint f) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen#$", "QSplashScreen(const QPixmap&, Qt::WindowFlags)", typeof(void), typeof(QPixmap), pixmap, typeof(uint), f);
        }
        public QSplashScreen(QPixmap pixmap) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen#", "QSplashScreen(const QPixmap&)", typeof(void), typeof(QPixmap), pixmap);
        }
        public QSplashScreen() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen", "QSplashScreen()", typeof(void));
        }
        public QSplashScreen(QWidget parent, QPixmap pixmap, uint f) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen##$", "QSplashScreen(QWidget*, const QPixmap&, Qt::WindowFlags)", typeof(void), typeof(QWidget), parent, typeof(QPixmap), pixmap, typeof(uint), f);
        }
        public QSplashScreen(QWidget parent, QPixmap pixmap) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen##", "QSplashScreen(QWidget*, const QPixmap&)", typeof(void), typeof(QWidget), parent, typeof(QPixmap), pixmap);
        }
        public QSplashScreen(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSplashScreen#", "QSplashScreen(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public void SetPixmap(QPixmap pixmap) {
            interceptor.Invoke("setPixmap#", "setPixmap(const QPixmap&)", typeof(void), typeof(QPixmap), pixmap);
        }
        public QPixmap Pixmap() {
            return (QPixmap) interceptor.Invoke("pixmap", "pixmap() const", typeof(QPixmap));
        }
        public void Finish(QWidget w) {
            interceptor.Invoke("finish#", "finish(QWidget*)", typeof(void), typeof(QWidget), w);
        }
        public new void Repaint() {
            interceptor.Invoke("repaint", "repaint()", typeof(void));
        }
        [Q_SLOT("void showMessage(QString, int, QColor)")]
        public void ShowMessage(string message, int alignment, QColor color) {
            interceptor.Invoke("showMessage$$#", "showMessage(const QString&, int, const QColor&)", typeof(void), typeof(string), message, typeof(int), alignment, typeof(QColor), color);
        }
        [Q_SLOT("void showMessage(QString, int)")]
        public void ShowMessage(string message, int alignment) {
            interceptor.Invoke("showMessage$$", "showMessage(const QString&, int)", typeof(void), typeof(string), message, typeof(int), alignment);
        }
        [Q_SLOT("void showMessage(QString)")]
        public void ShowMessage(string message) {
            interceptor.Invoke("showMessage$", "showMessage(const QString&)", typeof(void), typeof(string), message);
        }
        [Q_SLOT("void clearMessage()")]
        public void ClearMessage() {
            interceptor.Invoke("clearMessage", "clearMessage()", typeof(void));
        }
        [SmokeMethod("event(QEvent*)")]
        protected override bool Event(QEvent e) {
            return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), e);
        }
        [SmokeMethod("drawContents(QPainter*)")]
        protected virtual void DrawContents(QPainter painter) {
            interceptor.Invoke("drawContents#", "drawContents(QPainter*)", typeof(void), typeof(QPainter), painter);
        }
        [SmokeMethod("mousePressEvent(QMouseEvent*)")]
        protected override void MousePressEvent(QMouseEvent arg1) {
            interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
        }
        ~QSplashScreen() {
            interceptor.Invoke("~QSplashScreen", "~QSplashScreen()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QSplashScreen", "~QSplashScreen()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQSplashScreenSignals Emit {
            get { return (IQSplashScreenSignals) Q_EMIT; }
        }
    }

    public interface IQSplashScreenSignals : IQWidgetSignals {
        [Q_SIGNAL("void messageChanged(QString)")]
        void MessageChanged(string message);
    }
}