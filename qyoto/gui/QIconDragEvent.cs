//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QIconDragEvent")]
	public class QIconDragEvent : QEvent, IDisposable {
 		protected QIconDragEvent(Type dummy) : base((Type) null) {}
		interface IQIconDragEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QIconDragEvent), this);
			_interceptor = (QIconDragEvent) realProxy.GetTransparentProxy();
		}
		private QIconDragEvent ProxyQIconDragEvent() {
			return (QIconDragEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QIconDragEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQIconDragEventProxy), null);
			_staticInterceptor = (IQIconDragEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQIconDragEventProxy StaticQIconDragEvent() {
			return (IQIconDragEventProxy) _staticInterceptor;
		}

		public QIconDragEvent() : this((Type) null) {
			CreateProxy();
			NewQIconDragEvent();
		}
		[SmokeMethod("QIconDragEvent", "()", "")]
		private void NewQIconDragEvent() {
			ProxyQIconDragEvent().NewQIconDragEvent();
		}
		~QIconDragEvent() {
			DisposeQIconDragEvent();
		}
		public new void Dispose() {
			DisposeQIconDragEvent();
		}
		[SmokeMethod("~QIconDragEvent", "()", "")]
		private void DisposeQIconDragEvent() {
			ProxyQIconDragEvent().DisposeQIconDragEvent();
		}
	}
}
