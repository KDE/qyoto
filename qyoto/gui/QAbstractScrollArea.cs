//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    using System.Collections.Generic;
    [SmokeClass("QAbstractScrollArea")]
    public abstract class QAbstractScrollArea : QFrame {
        protected QAbstractScrollArea(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QAbstractScrollArea), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QAbstractScrollArea() {
            staticInterceptor = new SmokeInvocation(typeof(QAbstractScrollArea), null);
        }
        [Q_PROPERTY("Qt::ScrollBarPolicy", "verticalScrollBarPolicy")]
        public Qt.ScrollBarPolicy VerticalScrollBarPolicy {
            get { return (Qt.ScrollBarPolicy) interceptor.Invoke("verticalScrollBarPolicy", "verticalScrollBarPolicy()", typeof(Qt.ScrollBarPolicy)); }
            set { interceptor.Invoke("setVerticalScrollBarPolicy$", "setVerticalScrollBarPolicy(Qt::ScrollBarPolicy)", typeof(void), typeof(Qt.ScrollBarPolicy), value); }
        }
        [Q_PROPERTY("Qt::ScrollBarPolicy", "horizontalScrollBarPolicy")]
        public Qt.ScrollBarPolicy HorizontalScrollBarPolicy {
            get { return (Qt.ScrollBarPolicy) interceptor.Invoke("horizontalScrollBarPolicy", "horizontalScrollBarPolicy()", typeof(Qt.ScrollBarPolicy)); }
            set { interceptor.Invoke("setHorizontalScrollBarPolicy$", "setHorizontalScrollBarPolicy(Qt::ScrollBarPolicy)", typeof(void), typeof(Qt.ScrollBarPolicy), value); }
        }
        // QAbstractScrollArea* QAbstractScrollArea(QAbstractScrollAreaPrivate& arg1,QWidget* arg2); >>>> NOT CONVERTED
        // QAbstractScrollArea* QAbstractScrollArea(QAbstractScrollAreaPrivate& arg1); >>>> NOT CONVERTED
        public QAbstractScrollArea(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QAbstractScrollArea#", "QAbstractScrollArea(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public QAbstractScrollArea() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QAbstractScrollArea", "QAbstractScrollArea()", typeof(void));
        }
        public QScrollBar VerticalScrollBar() {
            return (QScrollBar) interceptor.Invoke("verticalScrollBar", "verticalScrollBar() const", typeof(QScrollBar));
        }
        public void SetVerticalScrollBar(QScrollBar scrollbar) {
            interceptor.Invoke("setVerticalScrollBar#", "setVerticalScrollBar(QScrollBar*)", typeof(void), typeof(QScrollBar), scrollbar);
        }
        public QScrollBar HorizontalScrollBar() {
            return (QScrollBar) interceptor.Invoke("horizontalScrollBar", "horizontalScrollBar() const", typeof(QScrollBar));
        }
        public void SetHorizontalScrollBar(QScrollBar scrollbar) {
            interceptor.Invoke("setHorizontalScrollBar#", "setHorizontalScrollBar(QScrollBar*)", typeof(void), typeof(QScrollBar), scrollbar);
        }
        public QWidget CornerWidget() {
            return (QWidget) interceptor.Invoke("cornerWidget", "cornerWidget() const", typeof(QWidget));
        }
        public void SetCornerWidget(QWidget widget) {
            interceptor.Invoke("setCornerWidget#", "setCornerWidget(QWidget*)", typeof(void), typeof(QWidget), widget);
        }
        public void AddScrollBarWidget(QWidget widget, uint alignment) {
            interceptor.Invoke("addScrollBarWidget#$", "addScrollBarWidget(QWidget*, Qt::Alignment)", typeof(void), typeof(QWidget), widget, typeof(uint), alignment);
        }
        public List<QWidget> ScrollBarWidgets(uint alignment) {
            return (List<QWidget>) interceptor.Invoke("scrollBarWidgets$", "scrollBarWidgets(Qt::Alignment)", typeof(List<QWidget>), typeof(uint), alignment);
        }
        public QWidget Viewport() {
            return (QWidget) interceptor.Invoke("viewport", "viewport() const", typeof(QWidget));
        }
        public void SetViewport(QWidget widget) {
            interceptor.Invoke("setViewport#", "setViewport(QWidget*)", typeof(void), typeof(QWidget), widget);
        }
        public QSize MaximumViewportSize() {
            return (QSize) interceptor.Invoke("maximumViewportSize", "maximumViewportSize() const", typeof(QSize));
        }
        [SmokeMethod("minimumSizeHint() const")]
        public override QSize MinimumSizeHint() {
            return (QSize) interceptor.Invoke("minimumSizeHint", "minimumSizeHint() const", typeof(QSize));
        }
        [SmokeMethod("sizeHint() const")]
        public override QSize SizeHint() {
            return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
        }
        protected void SetViewportMargins(int left, int top, int right, int bottom) {
            interceptor.Invoke("setViewportMargins$$$$", "setViewportMargins(int, int, int, int)", typeof(void), typeof(int), left, typeof(int), top, typeof(int), right, typeof(int), bottom);
        }
        protected void SetViewportMargins(QMargins margins) {
            interceptor.Invoke("setViewportMargins#", "setViewportMargins(const QMargins&)", typeof(void), typeof(QMargins), margins);
        }
        [SmokeMethod("event(QEvent*)")]
        protected override bool Event(QEvent arg1) {
            return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
        }
        [SmokeMethod("viewportEvent(QEvent*)")]
        protected virtual bool ViewportEvent(QEvent arg1) {
            return (bool) interceptor.Invoke("viewportEvent#", "viewportEvent(QEvent*)", typeof(bool), typeof(QEvent), arg1);
        }
        [SmokeMethod("resizeEvent(QResizeEvent*)")]
        protected override void ResizeEvent(QResizeEvent arg1) {
            interceptor.Invoke("resizeEvent#", "resizeEvent(QResizeEvent*)", typeof(void), typeof(QResizeEvent), arg1);
        }
        [SmokeMethod("paintEvent(QPaintEvent*)")]
        protected override void PaintEvent(QPaintEvent arg1) {
            interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), arg1);
        }
        [SmokeMethod("mousePressEvent(QMouseEvent*)")]
        protected override void MousePressEvent(QMouseEvent arg1) {
            interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
        }
        [SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
        protected override void MouseReleaseEvent(QMouseEvent arg1) {
            interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
        }
        [SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
        protected override void MouseDoubleClickEvent(QMouseEvent arg1) {
            interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
        }
        [SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
        protected override void MouseMoveEvent(QMouseEvent arg1) {
            interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
        }
        [SmokeMethod("wheelEvent(QWheelEvent*)")]
        protected override void WheelEvent(QWheelEvent arg1) {
            interceptor.Invoke("wheelEvent#", "wheelEvent(QWheelEvent*)", typeof(void), typeof(QWheelEvent), arg1);
        }
        [SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
        protected override void ContextMenuEvent(QContextMenuEvent arg1) {
            interceptor.Invoke("contextMenuEvent#", "contextMenuEvent(QContextMenuEvent*)", typeof(void), typeof(QContextMenuEvent), arg1);
        }
        [SmokeMethod("dragEnterEvent(QDragEnterEvent*)")]
        protected override void DragEnterEvent(QDragEnterEvent arg1) {
            interceptor.Invoke("dragEnterEvent#", "dragEnterEvent(QDragEnterEvent*)", typeof(void), typeof(QDragEnterEvent), arg1);
        }
        [SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
        protected override void DragMoveEvent(QDragMoveEvent arg1) {
            interceptor.Invoke("dragMoveEvent#", "dragMoveEvent(QDragMoveEvent*)", typeof(void), typeof(QDragMoveEvent), arg1);
        }
        [SmokeMethod("dragLeaveEvent(QDragLeaveEvent*)")]
        protected override void DragLeaveEvent(QDragLeaveEvent arg1) {
            interceptor.Invoke("dragLeaveEvent#", "dragLeaveEvent(QDragLeaveEvent*)", typeof(void), typeof(QDragLeaveEvent), arg1);
        }
        [SmokeMethod("dropEvent(QDropEvent*)")]
        protected override void DropEvent(QDropEvent arg1) {
            interceptor.Invoke("dropEvent#", "dropEvent(QDropEvent*)", typeof(void), typeof(QDropEvent), arg1);
        }
        [SmokeMethod("keyPressEvent(QKeyEvent*)")]
        protected override void KeyPressEvent(QKeyEvent arg1) {
            interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
        }
        [SmokeMethod("scrollContentsBy(int, int)")]
        protected virtual void ScrollContentsBy(int dx, int dy) {
            interceptor.Invoke("scrollContentsBy$$", "scrollContentsBy(int, int)", typeof(void), typeof(int), dx, typeof(int), dy);
        }
        [Q_SLOT("void setupViewport(QWidget*)")]
        protected void SetupViewport(QWidget viewport) {
            interceptor.Invoke("setupViewport#", "setupViewport(QWidget*)", typeof(void), typeof(QWidget), viewport);
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQAbstractScrollAreaSignals Emit {
            get { return (IQAbstractScrollAreaSignals) Q_EMIT; }
        }
    }

    public interface IQAbstractScrollAreaSignals : IQFrameSignals {
    }
}
