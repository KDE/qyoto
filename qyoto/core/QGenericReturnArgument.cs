//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QGenericReturnArgument")]
	public class QGenericReturnArgument : QGenericArgument, IDisposable {
 		protected QGenericReturnArgument(Type dummy) : base((Type) null) {}
		interface IQGenericReturnArgumentProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QGenericReturnArgument), this);
			_interceptor = (QGenericReturnArgument) realProxy.GetTransparentProxy();
		}
		private QGenericReturnArgument ProxyQGenericReturnArgument() {
			return (QGenericReturnArgument) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QGenericReturnArgument() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQGenericReturnArgumentProxy), null);
			_staticInterceptor = (IQGenericReturnArgumentProxy) realProxy.GetTransparentProxy();
		}
		private static IQGenericReturnArgumentProxy StaticQGenericReturnArgument() {
			return (IQGenericReturnArgumentProxy) _staticInterceptor;
		}

		// QGenericReturnArgument* QGenericReturnArgument(const char* arg1,void* arg2); >>>> NOT CONVERTED
		public QGenericReturnArgument(string aName) : this((Type) null) {
			CreateProxy();
			NewQGenericReturnArgument(aName);
		}
		[SmokeMethod("QGenericReturnArgument", "(const char*)", "$")]
		private void NewQGenericReturnArgument(string aName) {
			ProxyQGenericReturnArgument().NewQGenericReturnArgument(aName);
		}
		public QGenericReturnArgument() : this((Type) null) {
			CreateProxy();
			NewQGenericReturnArgument();
		}
		[SmokeMethod("QGenericReturnArgument", "()", "")]
		private void NewQGenericReturnArgument() {
			ProxyQGenericReturnArgument().NewQGenericReturnArgument();
		}
		~QGenericReturnArgument() {
			DisposeQGenericReturnArgument();
		}
		public void Dispose() {
			DisposeQGenericReturnArgument();
		}
		[SmokeMethod("~QGenericReturnArgument", "()", "")]
		private void DisposeQGenericReturnArgument() {
			ProxyQGenericReturnArgument().DisposeQGenericReturnArgument();
		}
	}
}
