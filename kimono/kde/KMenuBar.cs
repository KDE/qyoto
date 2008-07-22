//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  %KDE Style-able menubar.
    ///  This is required since QMenuBar is currently not handled by
    ///  QStyle.
    /// </remarks>        <author> Daniel "Mosfet" Duley.
    ///  </author>
    ///         <short>    %KDE Style-able menubar.</short>
    [SmokeClass("KMenuBar")]
    public class KMenuBar : QMenuBar, IDisposable {
        protected KMenuBar(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KMenuBar), this);
        }
        [Q_PROPERTY("bool", "topLevelMenu")]
        public bool TopLevelMenu {
            get { return (bool) interceptor.Invoke("isTopLevelMenu", "isTopLevelMenu()", typeof(bool)); }
            set { interceptor.Invoke("setTopLevelMenu$", "setTopLevelMenu(bool)", typeof(void), typeof(bool), value); }
        }
        public KMenuBar(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KMenuBar#", "KMenuBar(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public KMenuBar() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KMenuBar", "KMenuBar()", typeof(void));
        }
        [SmokeMethod("setGeometry(const QRect&)")]
        public virtual void SetGeometry(QRect r) {
            interceptor.Invoke("setGeometry#", "setGeometry(const QRect&)", typeof(void), typeof(QRect), r);
        }
        [SmokeMethod("setGeometry(int, int, int, int)")]
        public virtual void SetGeometry(int x, int y, int w, int h) {
            interceptor.Invoke("setGeometry$$$$", "setGeometry(int, int, int, int)", typeof(void), typeof(int), x, typeof(int), y, typeof(int), w, typeof(int), h);
        }
        [SmokeMethod("resize(int, int)")]
        public virtual void Resize(int w, int h) {
            interceptor.Invoke("resize$$", "resize(int, int)", typeof(void), typeof(int), w, typeof(int), h);
        }
        public void Resize(QSize s) {
            interceptor.Invoke("resize#", "resize(const QSize&)", typeof(void), typeof(QSize), s);
        }
        [SmokeMethod("setFrameStyle(int)")]
        public virtual void SetFrameStyle(int arg1) {
            interceptor.Invoke("setFrameStyle$", "setFrameStyle(int)", typeof(void), typeof(int), arg1);
        }
        [SmokeMethod("setLineWidth(int)")]
        public virtual void SetLineWidth(int arg1) {
            interceptor.Invoke("setLineWidth$", "setLineWidth(int)", typeof(void), typeof(int), arg1);
        }
        [SmokeMethod("setMargin(int)")]
        public virtual void SetMargin(int arg1) {
            interceptor.Invoke("setMargin$", "setMargin(int)", typeof(void), typeof(int), arg1);
        }
        [SmokeMethod("sizeHint() const")]
        public override QSize SizeHint() {
            return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
        }
        [SmokeMethod("resizeEvent(QResizeEvent*)")]
        protected override void ResizeEvent(QResizeEvent arg1) {
            interceptor.Invoke("resizeEvent#", "resizeEvent(QResizeEvent*)", typeof(void), typeof(QResizeEvent), arg1);
        }
        [SmokeMethod("eventFilter(QObject*, QEvent*)")]
        protected override bool EventFilter(QObject arg1, QEvent arg2) {
            return (bool) interceptor.Invoke("eventFilter##", "eventFilter(QObject*, QEvent*)", typeof(bool), typeof(QObject), arg1, typeof(QEvent), arg2);
        }
        [SmokeMethod("closeEvent(QCloseEvent*)")]
        protected override void CloseEvent(QCloseEvent arg1) {
            interceptor.Invoke("closeEvent#", "closeEvent(QCloseEvent*)", typeof(void), typeof(QCloseEvent), arg1);
        }
        [SmokeMethod("paintEvent(QPaintEvent*)")]
        protected override void PaintEvent(QPaintEvent arg1) {
            interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), arg1);
        }
        [Q_SLOT("void slotReadConfig()")]
        protected void SlotReadConfig() {
            interceptor.Invoke("slotReadConfig", "slotReadConfig()", typeof(void));
        }
        ~KMenuBar() {
            interceptor.Invoke("~KMenuBar", "~KMenuBar()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KMenuBar", "~KMenuBar()", typeof(void));
        }
        protected new IKMenuBarSignals Emit {
            get { return (IKMenuBarSignals) Q_EMIT; }
        }
    }

    public interface IKMenuBarSignals : IQMenuBarSignals {
    }
}
