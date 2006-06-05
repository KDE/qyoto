//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;

	[SmokeClass("QInputContextFactoryInterface")]
	public class QInputContextFactoryInterface : QFactoryInterface {
 		protected QInputContextFactoryInterface(Type dummy) : base((Type) null) {}
		interface IQInputContextFactoryInterfaceProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QInputContextFactoryInterface), this);
			_interceptor = (QInputContextFactoryInterface) realProxy.GetTransparentProxy();
		}
		private QInputContextFactoryInterface ProxyQInputContextFactoryInterface() {
			return (QInputContextFactoryInterface) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QInputContextFactoryInterface() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQInputContextFactoryInterfaceProxy), null);
			_staticInterceptor = (IQInputContextFactoryInterfaceProxy) realProxy.GetTransparentProxy();
		}
		private static IQInputContextFactoryInterfaceProxy StaticQInputContextFactoryInterface() {
			return (IQInputContextFactoryInterfaceProxy) _staticInterceptor;
		}

		[SmokeMethod("create(const QString&)")]
		public virtual QInputContext Create(string key) {
			return ProxyQInputContextFactoryInterface().Create(key);
		}
		[SmokeMethod("languages(const QString&)")]
		public virtual ArrayList Languages(string key) {
			return ProxyQInputContextFactoryInterface().Languages(key);
		}
		[SmokeMethod("displayName(const QString&)")]
		public virtual string DisplayName(string key) {
			return ProxyQInputContextFactoryInterface().DisplayName(key);
		}
		[SmokeMethod("description(const QString&)")]
		public virtual string Description(string key) {
			return ProxyQInputContextFactoryInterface().Description(key);
		}
		public QInputContextFactoryInterface() : this((Type) null) {
			CreateProxy();
			NewQInputContextFactoryInterface();
		}
		[SmokeMethod("QInputContextFactoryInterface()")]
		private void NewQInputContextFactoryInterface() {
			ProxyQInputContextFactoryInterface().NewQInputContextFactoryInterface();
		}
		~QInputContextFactoryInterface() {
			DisposeQInputContextFactoryInterface();
		}
		public new void Dispose() {
			DisposeQInputContextFactoryInterface();
		}
		private void DisposeQInputContextFactoryInterface() {
			ProxyQInputContextFactoryInterface().DisposeQInputContextFactoryInterface();
		}
	}
}
