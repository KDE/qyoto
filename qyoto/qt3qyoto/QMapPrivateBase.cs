//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	[SmokeClass("QMapPrivateBase")]
	public class QMapPrivateBase : QShared, IDisposable {
 		protected QMapPrivateBase(Type dummy) : base((Type) null) {}
		interface IQMapPrivateBaseProxy {
		}

		protected void CreateQMapPrivateBaseProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QMapPrivateBase), this);
			_interceptor = (QMapPrivateBase) realProxy.GetTransparentProxy();
		}
		private QMapPrivateBase ProxyQMapPrivateBase() {
			return (QMapPrivateBase) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QMapPrivateBase() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQMapPrivateBaseProxy), null);
			_staticInterceptor = (IQMapPrivateBaseProxy) realProxy.GetTransparentProxy();
		}
		private static IQMapPrivateBaseProxy StaticQMapPrivateBase() {
			return (IQMapPrivateBaseProxy) _staticInterceptor;
		}

		// QMapPrivateBase* QMapPrivateBase(); >>>> NOT CONVERTED
		// QMapPrivateBase* QMapPrivateBase(const QMapPrivateBase* arg1); >>>> NOT CONVERTED
		///<remarks>
		/// Implementations of basic tree algorithms
		///     </remarks>		<short>    Implementations of basic tree algorithms      </short>
		// void rotateLeft(QMapNodeBase* arg1,QMapNodeBase*& arg2); >>>> NOT CONVERTED
		// void rotateRight(QMapNodeBase* arg1,QMapNodeBase*& arg2); >>>> NOT CONVERTED
		// void rebalance(QMapNodeBase* arg1,QMapNodeBase*& arg2); >>>> NOT CONVERTED
		// QMapNodeBase* removeAndRebalance(QMapNodeBase* arg1,QMapNodeBase*& arg2,QMapNodeBase*& arg3,QMapNodeBase*& arg4); >>>> NOT CONVERTED
		~QMapPrivateBase() {
			DisposeQMapPrivateBase();
		}
		public void Dispose() {
			DisposeQMapPrivateBase();
		}
		private void DisposeQMapPrivateBase() {
			ProxyQMapPrivateBase().DisposeQMapPrivateBase();
		}
	}
}