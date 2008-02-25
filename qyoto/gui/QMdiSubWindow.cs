//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	/// <remarks> See <see cref="IQMdiSubWindowSignals"></see> for signals emitted by QMdiSubWindow
	/// </remarks>

	[SmokeClass("QMdiSubWindow")]
	public class QMdiSubWindow : QWidget, IDisposable {
 		protected QMdiSubWindow(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QMdiSubWindow), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QMdiSubWindow() {
			staticInterceptor = new SmokeInvocation(typeof(QMdiSubWindow), null);
		}
		public enum SubWindowOption {
			AllowOutsideAreaHorizontally = 0x1,
			AllowOutsideAreaVertically = 0x2,
			RubberBandResize = 0x4,
			RubberBandMove = 0x8,
		}
		[Q_PROPERTY("int", "keyboardSingleStep")]
		public int KeyboardSingleStep {
			get { return (int) interceptor.Invoke("keyboardSingleStep", "keyboardSingleStep()", typeof(int)); }
			set { interceptor.Invoke("setKeyboardSingleStep$", "setKeyboardSingleStep(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("int", "keyboardPageStep")]
		public int KeyboardPageStep {
			get { return (int) interceptor.Invoke("keyboardPageStep", "keyboardPageStep()", typeof(int)); }
			set { interceptor.Invoke("setKeyboardPageStep$", "setKeyboardPageStep(int)", typeof(void), typeof(int), value); }
		}
		public QMdiSubWindow(QWidget parent, uint flags) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QMdiSubWindow#$", "QMdiSubWindow(QWidget*, Qt::WindowFlags)", typeof(void), typeof(QWidget), parent, typeof(uint), flags);
		}
		public QMdiSubWindow(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QMdiSubWindow#", "QMdiSubWindow(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public QMdiSubWindow() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QMdiSubWindow", "QMdiSubWindow()", typeof(void));
		}
		[SmokeMethod("sizeHint() const")]
		public override QSize SizeHint() {
			return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
		}
		[SmokeMethod("minimumSizeHint() const")]
		public override QSize MinimumSizeHint() {
			return (QSize) interceptor.Invoke("minimumSizeHint", "minimumSizeHint() const", typeof(QSize));
		}
		public void SetWidget(QWidget widget) {
			interceptor.Invoke("setWidget#", "setWidget(QWidget*)", typeof(void), typeof(QWidget), widget);
		}
		public QWidget Widget() {
			return (QWidget) interceptor.Invoke("widget", "widget() const", typeof(QWidget));
		}
		public QWidget MaximizedButtonsWidget() {
			return (QWidget) interceptor.Invoke("maximizedButtonsWidget", "maximizedButtonsWidget() const", typeof(QWidget));
		}
		public QWidget MaximizedSystemMenuIconWidget() {
			return (QWidget) interceptor.Invoke("maximizedSystemMenuIconWidget", "maximizedSystemMenuIconWidget() const", typeof(QWidget));
		}
		public bool IsShaded() {
			return (bool) interceptor.Invoke("isShaded", "isShaded() const", typeof(bool));
		}
		public void SetOption(QMdiSubWindow.SubWindowOption option, bool on) {
			interceptor.Invoke("setOption$$", "setOption(QMdiSubWindow::SubWindowOption, bool)", typeof(void), typeof(QMdiSubWindow.SubWindowOption), option, typeof(bool), on);
		}
		public void SetOption(QMdiSubWindow.SubWindowOption option) {
			interceptor.Invoke("setOption$", "setOption(QMdiSubWindow::SubWindowOption)", typeof(void), typeof(QMdiSubWindow.SubWindowOption), option);
		}
		public bool TestOption(QMdiSubWindow.SubWindowOption arg1) {
			return (bool) interceptor.Invoke("testOption$", "testOption(QMdiSubWindow::SubWindowOption) const", typeof(bool), typeof(QMdiSubWindow.SubWindowOption), arg1);
		}
		public void SetSystemMenu(QMenu systemMenu) {
			interceptor.Invoke("setSystemMenu#", "setSystemMenu(QMenu*)", typeof(void), typeof(QMenu), systemMenu);
		}
		public QMenu SystemMenu() {
			return (QMenu) interceptor.Invoke("systemMenu", "systemMenu() const", typeof(QMenu));
		}
		public QMdiArea MdiArea() {
			return (QMdiArea) interceptor.Invoke("mdiArea", "mdiArea() const", typeof(QMdiArea));
		}
		[Q_SLOT("void showSystemMenu()")]
		public void ShowSystemMenu() {
			interceptor.Invoke("showSystemMenu", "showSystemMenu()", typeof(void));
		}
		[Q_SLOT("void showShaded()")]
		public void ShowShaded() {
			interceptor.Invoke("showShaded", "showShaded()", typeof(void));
		}
		[SmokeMethod("eventFilter(QObject*, QEvent*)")]
		protected new virtual bool EventFilter(QObject arg1, QEvent arg2) {
			return (bool) interceptor.Invoke("eventFilter##", "eventFilter(QObject*, QEvent*)", typeof(bool), typeof(QObject), arg1, typeof(QEvent), arg2);
		}
		[SmokeMethod("event(QEvent*)")]
		protected override bool Event(QEvent arg1) {
			return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
		}
		[SmokeMethod("showEvent(QShowEvent*)")]
		protected override void ShowEvent(QShowEvent showEvent) {
			interceptor.Invoke("showEvent#", "showEvent(QShowEvent*)", typeof(void), typeof(QShowEvent), showEvent);
		}
		[SmokeMethod("hideEvent(QHideEvent*)")]
		protected override void HideEvent(QHideEvent hideEvent) {
			interceptor.Invoke("hideEvent#", "hideEvent(QHideEvent*)", typeof(void), typeof(QHideEvent), hideEvent);
		}
		[SmokeMethod("changeEvent(QEvent*)")]
		protected override void ChangeEvent(QEvent changeEvent) {
			interceptor.Invoke("changeEvent#", "changeEvent(QEvent*)", typeof(void), typeof(QEvent), changeEvent);
		}
		[SmokeMethod("closeEvent(QCloseEvent*)")]
		protected override void CloseEvent(QCloseEvent closeEvent) {
			interceptor.Invoke("closeEvent#", "closeEvent(QCloseEvent*)", typeof(void), typeof(QCloseEvent), closeEvent);
		}
		[SmokeMethod("leaveEvent(QEvent*)")]
		protected override void LeaveEvent(QEvent leaveEvent) {
			interceptor.Invoke("leaveEvent#", "leaveEvent(QEvent*)", typeof(void), typeof(QEvent), leaveEvent);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected override void ResizeEvent(QResizeEvent resizeEvent) {
			interceptor.Invoke("resizeEvent#", "resizeEvent(QResizeEvent*)", typeof(void), typeof(QResizeEvent), resizeEvent);
		}
		[SmokeMethod("timerEvent(QTimerEvent*)")]
		protected override void TimerEvent(QTimerEvent timerEvent) {
			interceptor.Invoke("timerEvent#", "timerEvent(QTimerEvent*)", typeof(void), typeof(QTimerEvent), timerEvent);
		}
		[SmokeMethod("moveEvent(QMoveEvent*)")]
		protected override void MoveEvent(QMoveEvent moveEvent) {
			interceptor.Invoke("moveEvent#", "moveEvent(QMoveEvent*)", typeof(void), typeof(QMoveEvent), moveEvent);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected override void PaintEvent(QPaintEvent paintEvent) {
			interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), paintEvent);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected override void MousePressEvent(QMouseEvent mouseEvent) {
			interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), mouseEvent);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected override void MouseDoubleClickEvent(QMouseEvent mouseEvent) {
			interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), mouseEvent);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected override void MouseReleaseEvent(QMouseEvent mouseEvent) {
			interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), mouseEvent);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected override void MouseMoveEvent(QMouseEvent mouseEvent) {
			interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), mouseEvent);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected override void KeyPressEvent(QKeyEvent keyEvent) {
			interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), keyEvent);
		}
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected override void ContextMenuEvent(QContextMenuEvent contextMenuEvent) {
			interceptor.Invoke("contextMenuEvent#", "contextMenuEvent(QContextMenuEvent*)", typeof(void), typeof(QContextMenuEvent), contextMenuEvent);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected override void FocusInEvent(QFocusEvent focusInEvent) {
			interceptor.Invoke("focusInEvent#", "focusInEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), focusInEvent);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected override void FocusOutEvent(QFocusEvent focusOutEvent) {
			interceptor.Invoke("focusOutEvent#", "focusOutEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), focusOutEvent);
		}
		[SmokeMethod("childEvent(QChildEvent*)")]
		protected override void ChildEvent(QChildEvent childEvent) {
			interceptor.Invoke("childEvent#", "childEvent(QChildEvent*)", typeof(void), typeof(QChildEvent), childEvent);
		}
		~QMdiSubWindow() {
			interceptor.Invoke("~QMdiSubWindow", "~QMdiSubWindow()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QMdiSubWindow", "~QMdiSubWindow()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQMdiSubWindowSignals Emit {
			get { return (IQMdiSubWindowSignals) Q_EMIT; }
		}
	}

	public interface IQMdiSubWindowSignals : IQWidgetSignals {
		[Q_SIGNAL("void windowStateChanged(Qt::WindowStates, Qt::WindowStates)")]
		void WindowStateChanged(uint oldState, uint newState);
		[Q_SIGNAL("void aboutToActivate()")]
		void AboutToActivate();
	}
}
