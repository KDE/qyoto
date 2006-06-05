//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	public interface IQXmlDeclHandler {
			bool AttributeDecl(string eName, string aName, string type, string valueDefault, string value);
			bool InternalEntityDecl(string name, string value);
			bool ExternalEntityDecl(string name, string publicId, string systemId);
			string ErrorString();
	}

	[SmokeClass("QXmlDeclHandler")]
	public class QXmlDeclHandler : MarshalByRefObject, IQXmlDeclHandler {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QXmlDeclHandler(Type dummy) {}
		interface IQXmlDeclHandlerProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QXmlDeclHandler), this);
			_interceptor = (QXmlDeclHandler) realProxy.GetTransparentProxy();
		}
		private QXmlDeclHandler ProxyQXmlDeclHandler() {
			return (QXmlDeclHandler) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QXmlDeclHandler() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQXmlDeclHandlerProxy), null);
			_staticInterceptor = (IQXmlDeclHandlerProxy) realProxy.GetTransparentProxy();
		}
		private static IQXmlDeclHandlerProxy StaticQXmlDeclHandler() {
			return (IQXmlDeclHandlerProxy) _staticInterceptor;
		}

		[SmokeMethod("attributeDecl(const QString&, const QString&, const QString&, const QString&, const QString&)")]
		public virtual bool AttributeDecl(string eName, string aName, string type, string valueDefault, string value) {
			return ProxyQXmlDeclHandler().AttributeDecl(eName,aName,type,valueDefault,value);
		}
		[SmokeMethod("internalEntityDecl(const QString&, const QString&)")]
		public virtual bool InternalEntityDecl(string name, string value) {
			return ProxyQXmlDeclHandler().InternalEntityDecl(name,value);
		}
		[SmokeMethod("externalEntityDecl(const QString&, const QString&, const QString&)")]
		public virtual bool ExternalEntityDecl(string name, string publicId, string systemId) {
			return ProxyQXmlDeclHandler().ExternalEntityDecl(name,publicId,systemId);
		}
		[SmokeMethod("errorString() const")]
		public virtual string ErrorString() {
			return ProxyQXmlDeclHandler().ErrorString();
		}
		public QXmlDeclHandler() : this((Type) null) {
			CreateProxy();
			NewQXmlDeclHandler();
		}
		[SmokeMethod("QXmlDeclHandler()")]
		private void NewQXmlDeclHandler() {
			ProxyQXmlDeclHandler().NewQXmlDeclHandler();
		}
		~QXmlDeclHandler() {
			DisposeQXmlDeclHandler();
		}
		public void Dispose() {
			DisposeQXmlDeclHandler();
		}
		private void DisposeQXmlDeclHandler() {
			ProxyQXmlDeclHandler().DisposeQXmlDeclHandler();
		}
	}
}
