//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	public interface IQXmlDTDHandler {
			bool NotationDecl(string name, string publicId, string systemId);
			bool UnparsedEntityDecl(string name, string publicId, string systemId, string notationName);
			string ErrorString();
	}

	[SmokeClass("QXmlDTDHandler")]
	public class QXmlDTDHandler : MarshalByRefObject, IQXmlDTDHandler {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QXmlDTDHandler(Type dummy) {}
		interface IQXmlDTDHandlerProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QXmlDTDHandler), this);
			_interceptor = (QXmlDTDHandler) realProxy.GetTransparentProxy();
		}
		private QXmlDTDHandler ProxyQXmlDTDHandler() {
			return (QXmlDTDHandler) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QXmlDTDHandler() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQXmlDTDHandlerProxy), null);
			_staticInterceptor = (IQXmlDTDHandlerProxy) realProxy.GetTransparentProxy();
		}
		private static IQXmlDTDHandlerProxy StaticQXmlDTDHandler() {
			return (IQXmlDTDHandlerProxy) _staticInterceptor;
		}

		[SmokeMethod("notationDecl(const QString&, const QString&, const QString&)")]
		public virtual bool NotationDecl(string name, string publicId, string systemId) {
			return ProxyQXmlDTDHandler().NotationDecl(name,publicId,systemId);
		}
		[SmokeMethod("unparsedEntityDecl(const QString&, const QString&, const QString&, const QString&)")]
		public virtual bool UnparsedEntityDecl(string name, string publicId, string systemId, string notationName) {
			return ProxyQXmlDTDHandler().UnparsedEntityDecl(name,publicId,systemId,notationName);
		}
		[SmokeMethod("errorString() const")]
		public virtual string ErrorString() {
			return ProxyQXmlDTDHandler().ErrorString();
		}
		public QXmlDTDHandler() : this((Type) null) {
			CreateProxy();
			NewQXmlDTDHandler();
		}
		[SmokeMethod("QXmlDTDHandler()")]
		private void NewQXmlDTDHandler() {
			ProxyQXmlDTDHandler().NewQXmlDTDHandler();
		}
		~QXmlDTDHandler() {
			DisposeQXmlDTDHandler();
		}
		public void Dispose() {
			DisposeQXmlDTDHandler();
		}
		private void DisposeQXmlDTDHandler() {
			ProxyQXmlDTDHandler().DisposeQXmlDTDHandler();
		}
	}
}
