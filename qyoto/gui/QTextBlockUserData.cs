//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QTextBlockUserData")]
	public class QTextBlockUserData : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QTextBlockUserData(Type dummy) {}
		interface IQTextBlockUserDataProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextBlockUserData), this);
			_interceptor = (QTextBlockUserData) realProxy.GetTransparentProxy();
		}
		private QTextBlockUserData ProxyQTextBlockUserData() {
			return (QTextBlockUserData) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextBlockUserData() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextBlockUserDataProxy), null);
			_staticInterceptor = (IQTextBlockUserDataProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextBlockUserDataProxy StaticQTextBlockUserData() {
			return (IQTextBlockUserDataProxy) _staticInterceptor;
		}

		public QTextBlockUserData() : this((Type) null) {
			CreateProxy();
			NewQTextBlockUserData();
		}
		[SmokeMethod("QTextBlockUserData", "()", "")]
		private void NewQTextBlockUserData() {
			ProxyQTextBlockUserData().NewQTextBlockUserData();
		}
		~QTextBlockUserData() {
			DisposeQTextBlockUserData();
		}
		public void Dispose() {
			DisposeQTextBlockUserData();
		}
		[SmokeMethod("~QTextBlockUserData", "()", "")]
		private void DisposeQTextBlockUserData() {
			ProxyQTextBlockUserData().DisposeQTextBlockUserData();
		}
	}
}
