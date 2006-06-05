//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QInputEvent")]
	public class QInputEvent : QEvent, IDisposable {
 		protected QInputEvent(Type dummy) : base((Type) null) {}
		interface IQInputEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QInputEvent), this);
			_interceptor = (QInputEvent) realProxy.GetTransparentProxy();
		}
		private QInputEvent ProxyQInputEvent() {
			return (QInputEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QInputEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQInputEventProxy), null);
			_staticInterceptor = (IQInputEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQInputEventProxy StaticQInputEvent() {
			return (IQInputEventProxy) _staticInterceptor;
		}

		public QInputEvent(QEvent.E_Type type, int modifiers) : this((Type) null) {
			CreateProxy();
			NewQInputEvent(type,modifiers);
		}
		[SmokeMethod("QInputEvent(QEvent::Type, Qt::KeyboardModifiers)")]
		private void NewQInputEvent(QEvent.E_Type type, int modifiers) {
			ProxyQInputEvent().NewQInputEvent(type,modifiers);
		}
		public QInputEvent(QEvent.E_Type type) : this((Type) null) {
			CreateProxy();
			NewQInputEvent(type);
		}
		[SmokeMethod("QInputEvent(QEvent::Type)")]
		private void NewQInputEvent(QEvent.E_Type type) {
			ProxyQInputEvent().NewQInputEvent(type);
		}
		[SmokeMethod("modifiers() const")]
		public int Modifiers() {
			return ProxyQInputEvent().Modifiers();
		}
		~QInputEvent() {
			DisposeQInputEvent();
		}
		public new void Dispose() {
			DisposeQInputEvent();
		}
		private void DisposeQInputEvent() {
			ProxyQInputEvent().DisposeQInputEvent();
		}
	}
}
