//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QBitRef")]
	public class QBitRef : MarshalByRefObject {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QBitRef(Type dummy) {}
		interface IQBitRefProxy {
			bool op_not(QBitRef lhs);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QBitRef), this);
			_interceptor = (QBitRef) realProxy.GetTransparentProxy();
		}
		private QBitRef ProxyQBitRef() {
			return (QBitRef) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QBitRef() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQBitRefProxy), null);
			_staticInterceptor = (IQBitRefProxy) realProxy.GetTransparentProxy();
		}
		private static IQBitRefProxy StaticQBitRef() {
			return (IQBitRefProxy) _staticInterceptor;
		}

		//  operator bool(); >>>> NOT CONVERTED
		[SmokeMethod("operator!() const")]
		public static bool operator!(QBitRef lhs) {
			return StaticQBitRef().op_not(lhs);
		}
		~QBitRef() {
			DisposeQBitRef();
		}
		public void Dispose() {
			DisposeQBitRef();
		}
		private void DisposeQBitRef() {
			ProxyQBitRef().DisposeQBitRef();
		}
	}
}
