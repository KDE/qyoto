//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QTextObject")]
	public class QTextObject : QObject {
 		protected QTextObject(Type dummy) : base((Type) null) {}
		interface IQTextObjectProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextObject), this);
			_interceptor = (QTextObject) realProxy.GetTransparentProxy();
		}
		private QTextObject ProxyQTextObject() {
			return (QTextObject) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextObject() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextObjectProxy), null);
			_staticInterceptor = (IQTextObjectProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextObjectProxy StaticQTextObject() {
			return (IQTextObjectProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		// QTextFormat format(); >>>> NOT CONVERTED
		[SmokeMethod("formatIndex", "() const", "")]
		public int FormatIndex() {
			return ProxyQTextObject().FormatIndex();
		}
		// QTextDocument* document(); >>>> NOT CONVERTED
		[SmokeMethod("objectIndex", "() const", "")]
		public int ObjectIndex() {
			return ProxyQTextObject().ObjectIndex();
		}
		// QTextDocumentPrivate* docHandle(); >>>> NOT CONVERTED
		public static new string Tr(string s, string c) {
			return StaticQTextObject().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQTextObject().Tr(s);
		}
		// QTextObject* QTextObject(QTextDocument* arg1); >>>> NOT CONVERTED
		// void setFormat(const QTextFormat& arg1); >>>> NOT CONVERTED
		protected new IQTextObjectSignals Emit {
			get {
				return (IQTextObjectSignals) Q_EMIT;
			}
		}
	}

	public interface IQTextObjectSignals : IQObjectSignals {
	}
}
