//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QVBoxLayout : QBoxLayout, IDisposable {
 		protected QVBoxLayout(Type dummy) : base((Type) null) {}
		interface IQVBoxLayoutProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected void CreateQVBoxLayoutProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QVBoxLayout), this);
			_interceptor = (QVBoxLayout) realProxy.GetTransparentProxy();
		}
		private QVBoxLayout ProxyQVBoxLayout() {
			return (QVBoxLayout) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QVBoxLayout() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQVBoxLayoutProxy), null);
			_staticInterceptor = (IQVBoxLayoutProxy) realProxy.GetTransparentProxy();
		}
		private static IQVBoxLayoutProxy StaticQVBoxLayout() {
			return (IQVBoxLayoutProxy) _staticInterceptor;
		}

		public new virtual QMetaObject MetaObject() {
			return ProxyQVBoxLayout().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QVBoxLayout() : this((Type) null) {
			CreateQVBoxLayoutProxy();
			NewQVBoxLayout();
		}
		private void NewQVBoxLayout() {
			ProxyQVBoxLayout().NewQVBoxLayout();
		}
		public QVBoxLayout(QWidget parent) : this((Type) null) {
			CreateQVBoxLayoutProxy();
			NewQVBoxLayout(parent);
		}
		private void NewQVBoxLayout(QWidget parent) {
			ProxyQVBoxLayout().NewQVBoxLayout(parent);
		}
		public static new string Tr(string s, string c) {
			return StaticQVBoxLayout().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQVBoxLayout().Tr(s);
		}
		~QVBoxLayout() {
			ProxyQVBoxLayout().Dispose();
		}
		public new void Dispose() {
			ProxyQVBoxLayout().Dispose();
		}
	}
}