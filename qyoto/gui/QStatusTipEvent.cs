//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QStatusTipEvent")]
	public class QStatusTipEvent : QEvent, IDisposable {
 		protected QStatusTipEvent(Type dummy) : base((Type) null) {}
		interface IQStatusTipEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStatusTipEvent), this);
			_interceptor = (QStatusTipEvent) realProxy.GetTransparentProxy();
		}
		private QStatusTipEvent ProxyQStatusTipEvent() {
			return (QStatusTipEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStatusTipEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStatusTipEventProxy), null);
			_staticInterceptor = (IQStatusTipEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQStatusTipEventProxy StaticQStatusTipEvent() {
			return (IQStatusTipEventProxy) _staticInterceptor;
		}

		public QStatusTipEvent(string tip) : this((Type) null) {
			CreateProxy();
			NewQStatusTipEvent(tip);
		}
		[SmokeMethod("QStatusTipEvent(const QString&)")]
		private void NewQStatusTipEvent(string tip) {
			ProxyQStatusTipEvent().NewQStatusTipEvent(tip);
		}
		[SmokeMethod("tip() const")]
		public string Tip() {
			return ProxyQStatusTipEvent().Tip();
		}
		~QStatusTipEvent() {
			DisposeQStatusTipEvent();
		}
		public new void Dispose() {
			DisposeQStatusTipEvent();
		}
		[SmokeMethod("~QStatusTipEvent()")]
		private void DisposeQStatusTipEvent() {
			ProxyQStatusTipEvent().DisposeQStatusTipEvent();
		}
	}
}