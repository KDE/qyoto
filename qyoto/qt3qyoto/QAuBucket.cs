//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	[SmokeClass("QAuBucket")]
	public class QAuBucket : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QAuBucket(Type dummy) {}
		interface IQAuBucketProxy {
		}

		protected void CreateQAuBucketProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAuBucket), this);
			_interceptor = (QAuBucket) realProxy.GetTransparentProxy();
		}
		private QAuBucket ProxyQAuBucket() {
			return (QAuBucket) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAuBucket() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAuBucketProxy), null);
			_staticInterceptor = (IQAuBucketProxy) realProxy.GetTransparentProxy();
		}
		private static IQAuBucketProxy StaticQAuBucket() {
			return (IQAuBucketProxy) _staticInterceptor;
		}

		// QAuBucket* QAuBucket(); >>>> NOT CONVERTED
		~QAuBucket() {
			DisposeQAuBucket();
		}
		public void Dispose() {
			DisposeQAuBucket();
		}
		private void DisposeQAuBucket() {
			ProxyQAuBucket().DisposeQAuBucket();
		}
	}
}