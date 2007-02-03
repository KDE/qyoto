//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QStyleOptionDockWidget")]
	public class QStyleOptionDockWidget : QStyleOption, IDisposable {
 		protected QStyleOptionDockWidget(Type dummy) : base((Type) null) {}
		interface IQStyleOptionDockWidgetProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStyleOptionDockWidget), this);
			_interceptor = (QStyleOptionDockWidget) realProxy.GetTransparentProxy();
		}
		private QStyleOptionDockWidget ProxyQStyleOptionDockWidget() {
			return (QStyleOptionDockWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStyleOptionDockWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStyleOptionDockWidgetProxy), null);
			_staticInterceptor = (IQStyleOptionDockWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQStyleOptionDockWidgetProxy StaticQStyleOptionDockWidget() {
			return (IQStyleOptionDockWidgetProxy) _staticInterceptor;
		}

		public enum StyleOptionType {
			Type = QStyleOption.OptionType.SO_DockWidget,
		}
		public enum StyleOptionVersion {
			Version = 1,
		}
		public QStyleOptionDockWidget() : this((Type) null) {
			CreateProxy();
			NewQStyleOptionDockWidget();
		}
		[SmokeMethod("QStyleOptionDockWidget", "()", "")]
		private void NewQStyleOptionDockWidget() {
			ProxyQStyleOptionDockWidget().NewQStyleOptionDockWidget();
		}
		public QStyleOptionDockWidget(QStyleOptionDockWidget other) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionDockWidget(other);
		}
		[SmokeMethod("QStyleOptionDockWidget", "(const QStyleOptionDockWidget&)", "#")]
		private void NewQStyleOptionDockWidget(QStyleOptionDockWidget other) {
			ProxyQStyleOptionDockWidget().NewQStyleOptionDockWidget(other);
		}
		public QStyleOptionDockWidget(int version) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionDockWidget(version);
		}
		[SmokeMethod("QStyleOptionDockWidget", "(int)", "$")]
		private void NewQStyleOptionDockWidget(int version) {
			ProxyQStyleOptionDockWidget().NewQStyleOptionDockWidget(version);
		}
		~QStyleOptionDockWidget() {
			DisposeQStyleOptionDockWidget();
		}
		public void Dispose() {
			DisposeQStyleOptionDockWidget();
		}
		[SmokeMethod("~QStyleOptionDockWidget", "()", "")]
		private void DisposeQStyleOptionDockWidget() {
			ProxyQStyleOptionDockWidget().DisposeQStyleOptionDockWidget();
		}
	}
}
