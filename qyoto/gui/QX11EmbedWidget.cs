//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQX11EmbedWidgetSignals"></see> for signals emitted by QX11EmbedWidget
	[SmokeClass("QX11EmbedWidget")]
	public class QX11EmbedWidget : QWidget, IDisposable {
 		protected QX11EmbedWidget(Type dummy) : base((Type) null) {}
		interface IQX11EmbedWidgetProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QX11EmbedWidget), this);
			_interceptor = (QX11EmbedWidget) realProxy.GetTransparentProxy();
		}
		private QX11EmbedWidget ProxyQX11EmbedWidget() {
			return (QX11EmbedWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QX11EmbedWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQX11EmbedWidgetProxy), null);
			_staticInterceptor = (IQX11EmbedWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQX11EmbedWidgetProxy StaticQX11EmbedWidget() {
			return (IQX11EmbedWidgetProxy) _staticInterceptor;
		}

		public enum Error {
			Unknown = 0,
			Internal = 1,
			InvalidWindowID = 2,
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QX11EmbedWidget(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQX11EmbedWidget(parent);
		}
		[SmokeMethod("QX11EmbedWidget", "(QWidget*)", "#")]
		private void NewQX11EmbedWidget(QWidget parent) {
			ProxyQX11EmbedWidget().NewQX11EmbedWidget(parent);
		}
		public QX11EmbedWidget() : this((Type) null) {
			CreateProxy();
			NewQX11EmbedWidget();
		}
		[SmokeMethod("QX11EmbedWidget", "()", "")]
		private void NewQX11EmbedWidget() {
			ProxyQX11EmbedWidget().NewQX11EmbedWidget();
		}
		[SmokeMethod("embedInto", "(WId)", "$")]
		public void EmbedInto(ulong id) {
			ProxyQX11EmbedWidget().EmbedInto(id);
		}
		[SmokeMethod("containerWinId", "() const", "")]
		public ulong ContainerWinId() {
			return ProxyQX11EmbedWidget().ContainerWinId();
		}
		[SmokeMethod("error", "() const", "")]
		public QX11EmbedWidget.Error error() {
			return ProxyQX11EmbedWidget().error();
		}
		public static new string Tr(string s, string c) {
			return StaticQX11EmbedWidget().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQX11EmbedWidget().Tr(s);
		}
		// bool x11Event(XEvent* arg1); >>>> NOT CONVERTED
		[SmokeMethod("eventFilter", "(QObject*, QEvent*)", "##")]
		public new bool EventFilter(QObject arg1, QEvent arg2) {
			return ProxyQX11EmbedWidget().EventFilter(arg1,arg2);
		}
		[SmokeMethod("event", "(QEvent*)", "#")]
		public new bool Event(QEvent arg1) {
			return ProxyQX11EmbedWidget().Event(arg1);
		}
		[SmokeMethod("resizeEvent", "(QResizeEvent*)", "#")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQX11EmbedWidget().ResizeEvent(arg1);
		}
		~QX11EmbedWidget() {
			DisposeQX11EmbedWidget();
		}
		public new void Dispose() {
			DisposeQX11EmbedWidget();
		}
		[SmokeMethod("~QX11EmbedWidget", "()", "")]
		private void DisposeQX11EmbedWidget() {
			ProxyQX11EmbedWidget().DisposeQX11EmbedWidget();
		}
		protected new IQX11EmbedWidgetSignals Emit {
			get {
				return (IQX11EmbedWidgetSignals) Q_EMIT;
			}
		}
	}

	public interface IQX11EmbedWidgetSignals : IQWidgetSignals {
		[Q_SIGNAL("void embedded()")]
		void Embedded();
		[Q_SIGNAL("void containerClosed()")]
		void ContainerClosed();
		[Q_SIGNAL("void error(QX11EmbedWidget::Error)")]
		void Error(QX11EmbedWidget.Error error);
	}
}
