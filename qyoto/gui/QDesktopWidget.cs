//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQDesktopWidgetSignals"></see> for signals emitted by QDesktopWidget
	[SmokeClass("QDesktopWidget")]
	public class QDesktopWidget : QWidget, IDisposable {
 		protected QDesktopWidget(Type dummy) : base((Type) null) {}
		interface IQDesktopWidgetProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDesktopWidget), this);
			_interceptor = (QDesktopWidget) realProxy.GetTransparentProxy();
		}
		private QDesktopWidget ProxyQDesktopWidget() {
			return (QDesktopWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDesktopWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDesktopWidgetProxy), null);
			_staticInterceptor = (IQDesktopWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQDesktopWidgetProxy StaticQDesktopWidget() {
			return (IQDesktopWidgetProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QDesktopWidget() : this((Type) null) {
			CreateProxy();
			NewQDesktopWidget();
		}
		[SmokeMethod("QDesktopWidget", "()", "")]
		private void NewQDesktopWidget() {
			ProxyQDesktopWidget().NewQDesktopWidget();
		}
		[SmokeMethod("isVirtualDesktop", "() const", "")]
		public bool IsVirtualDesktop() {
			return ProxyQDesktopWidget().IsVirtualDesktop();
		}
		[SmokeMethod("numScreens", "() const", "")]
		public int NumScreens() {
			return ProxyQDesktopWidget().NumScreens();
		}
		[SmokeMethod("primaryScreen", "() const", "")]
		public int PrimaryScreen() {
			return ProxyQDesktopWidget().PrimaryScreen();
		}
		[SmokeMethod("screenNumber", "(const QWidget*) const", "#")]
		public int ScreenNumber(QWidget widget) {
			return ProxyQDesktopWidget().ScreenNumber(widget);
		}
		[SmokeMethod("screenNumber", "() const", "")]
		public int ScreenNumber() {
			return ProxyQDesktopWidget().ScreenNumber();
		}
		[SmokeMethod("screenNumber", "(const QPoint&) const", "#")]
		public int ScreenNumber(QPoint arg1) {
			return ProxyQDesktopWidget().ScreenNumber(arg1);
		}
		[SmokeMethod("screen", "(int)", "$")]
		public QWidget Screen(int screen) {
			return ProxyQDesktopWidget().Screen(screen);
		}
		[SmokeMethod("screen", "()", "")]
		public QWidget Screen() {
			return ProxyQDesktopWidget().Screen();
		}
		[SmokeMethod("screenGeometry", "(int) const", "$")]
		public QRect ScreenGeometry(int screen) {
			return ProxyQDesktopWidget().ScreenGeometry(screen);
		}
		[SmokeMethod("screenGeometry", "() const", "")]
		public QRect ScreenGeometry() {
			return ProxyQDesktopWidget().ScreenGeometry();
		}
		[SmokeMethod("screenGeometry", "(const QWidget*) const", "#")]
		public QRect ScreenGeometry(QWidget widget) {
			return ProxyQDesktopWidget().ScreenGeometry(widget);
		}
		[SmokeMethod("screenGeometry", "(const QPoint&) const", "#")]
		public QRect ScreenGeometry(QPoint point) {
			return ProxyQDesktopWidget().ScreenGeometry(point);
		}
		[SmokeMethod("availableGeometry", "(int) const", "$")]
		public QRect AvailableGeometry(int screen) {
			return ProxyQDesktopWidget().AvailableGeometry(screen);
		}
		[SmokeMethod("availableGeometry", "() const", "")]
		public QRect AvailableGeometry() {
			return ProxyQDesktopWidget().AvailableGeometry();
		}
		[SmokeMethod("availableGeometry", "(const QWidget*) const", "#")]
		public QRect AvailableGeometry(QWidget widget) {
			return ProxyQDesktopWidget().AvailableGeometry(widget);
		}
		[SmokeMethod("availableGeometry", "(const QPoint&) const", "#")]
		public QRect AvailableGeometry(QPoint point) {
			return ProxyQDesktopWidget().AvailableGeometry(point);
		}
		public static new string Tr(string s, string c) {
			return StaticQDesktopWidget().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQDesktopWidget().Tr(s);
		}
		[SmokeMethod("resizeEvent", "(QResizeEvent*)", "#")]
		protected new void ResizeEvent(QResizeEvent e) {
			ProxyQDesktopWidget().ResizeEvent(e);
		}
		~QDesktopWidget() {
			DisposeQDesktopWidget();
		}
		public new void Dispose() {
			DisposeQDesktopWidget();
		}
		[SmokeMethod("~QDesktopWidget", "()", "")]
		private void DisposeQDesktopWidget() {
			ProxyQDesktopWidget().DisposeQDesktopWidget();
		}
		protected new IQDesktopWidgetSignals Emit {
			get {
				return (IQDesktopWidgetSignals) Q_EMIT;
			}
		}
	}

	public interface IQDesktopWidgetSignals : IQWidgetSignals {
		[Q_SIGNAL("void resized(int)")]
		void Resized(int arg1);
		[Q_SIGNAL("void workAreaResized(int)")]
		void WorkAreaResized(int arg1);
	}
}
