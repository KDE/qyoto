//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QSqlDriverFactoryInterface")]
	public class QSqlDriverFactoryInterface : QFactoryInterface {
 		protected QSqlDriverFactoryInterface(Type dummy) : base((Type) null) {}
		interface IQSqlDriverFactoryInterfaceProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSqlDriverFactoryInterface), this);
			_interceptor = (QSqlDriverFactoryInterface) realProxy.GetTransparentProxy();
		}
		private QSqlDriverFactoryInterface ProxyQSqlDriverFactoryInterface() {
			return (QSqlDriverFactoryInterface) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSqlDriverFactoryInterface() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlDriverFactoryInterfaceProxy), null);
			_staticInterceptor = (IQSqlDriverFactoryInterfaceProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlDriverFactoryInterfaceProxy StaticQSqlDriverFactoryInterface() {
			return (IQSqlDriverFactoryInterfaceProxy) _staticInterceptor;
		}

		[SmokeMethod("create", "(const QString&)", "$")]
		public virtual QSqlDriver Create(string name) {
			return ProxyQSqlDriverFactoryInterface().Create(name);
		}
		public QSqlDriverFactoryInterface() : this((Type) null) {
			CreateProxy();
			NewQSqlDriverFactoryInterface();
		}
		[SmokeMethod("QSqlDriverFactoryInterface", "()", "")]
		private void NewQSqlDriverFactoryInterface() {
			ProxyQSqlDriverFactoryInterface().NewQSqlDriverFactoryInterface();
		}
		~QSqlDriverFactoryInterface() {
			DisposeQSqlDriverFactoryInterface();
		}
		public new void Dispose() {
			DisposeQSqlDriverFactoryInterface();
		}
		[SmokeMethod("~QSqlDriverFactoryInterface", "()", "")]
		private void DisposeQSqlDriverFactoryInterface() {
			ProxyQSqlDriverFactoryInterface().DisposeQSqlDriverFactoryInterface();
		}
	}
}
