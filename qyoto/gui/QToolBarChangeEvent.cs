//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QToolBarChangeEvent")]
	public class QToolBarChangeEvent : QEvent, IDisposable {
 		protected QToolBarChangeEvent(Type dummy) : base((Type) null) {}
		interface IQToolBarChangeEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QToolBarChangeEvent), this);
			_interceptor = (QToolBarChangeEvent) realProxy.GetTransparentProxy();
		}
		private QToolBarChangeEvent ProxyQToolBarChangeEvent() {
			return (QToolBarChangeEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QToolBarChangeEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQToolBarChangeEventProxy), null);
			_staticInterceptor = (IQToolBarChangeEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQToolBarChangeEventProxy StaticQToolBarChangeEvent() {
			return (IQToolBarChangeEventProxy) _staticInterceptor;
		}

		public QToolBarChangeEvent(bool t) : this((Type) null) {
			CreateProxy();
			NewQToolBarChangeEvent(t);
		}
		[SmokeMethod("QToolBarChangeEvent", "(bool)", "$")]
		private void NewQToolBarChangeEvent(bool t) {
			ProxyQToolBarChangeEvent().NewQToolBarChangeEvent(t);
		}
		[SmokeMethod("toggle", "() const", "")]
		public bool Toggle() {
			return ProxyQToolBarChangeEvent().Toggle();
		}
		~QToolBarChangeEvent() {
			DisposeQToolBarChangeEvent();
		}
		public new void Dispose() {
			DisposeQToolBarChangeEvent();
		}
		[SmokeMethod("~QToolBarChangeEvent", "()", "")]
		private void DisposeQToolBarChangeEvent() {
			ProxyQToolBarChangeEvent().DisposeQToolBarChangeEvent();
		}
	}
}
