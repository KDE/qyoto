//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	[SmokeClass("QHideEvent")]
	public class QHideEvent : QEvent, IDisposable {
 		protected QHideEvent(Type dummy) : base((Type) null) {}
		interface IQHideEventProxy {
		}

		protected void CreateQHideEventProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHideEvent), this);
			_interceptor = (QHideEvent) realProxy.GetTransparentProxy();
		}
		private QHideEvent ProxyQHideEvent() {
			return (QHideEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHideEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHideEventProxy), null);
			_staticInterceptor = (IQHideEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQHideEventProxy StaticQHideEvent() {
			return (IQHideEventProxy) _staticInterceptor;
		}

		public QHideEvent() : this((Type) null) {
			CreateQHideEventProxy();
			NewQHideEvent();
		}
		[SmokeMethod("QHideEvent()")]
		private void NewQHideEvent() {
			ProxyQHideEvent().NewQHideEvent();
		}
		~QHideEvent() {
			DisposeQHideEvent();
		}
		public new void Dispose() {
			DisposeQHideEvent();
		}
		private void DisposeQHideEvent() {
			ProxyQHideEvent().DisposeQHideEvent();
		}
	}
}