//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QTextObject : QObject {
 		protected QTextObject(Type dummy) : base((Type) null) {}
		interface IQTextObjectProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected void CreateQTextObjectProxy() {
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

		public new virtual QMetaObject MetaObject() {
			return ProxyQTextObject().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		// QTextFormat format(); >>>> NOT CONVERTED
		public int FormatIndex() {
			return ProxyQTextObject().FormatIndex();
		}
		// QTextDocument* document(); >>>> NOT CONVERTED
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
	}
}