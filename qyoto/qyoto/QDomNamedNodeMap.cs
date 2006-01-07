//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QDomNamedNodeMap : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QDomNamedNodeMap(Type dummy) {}
		interface IQDomNamedNodeMapProxy {
			bool op_equals(QDomNamedNodeMap lhs, QDomNamedNodeMap arg1);
		}

		protected void CreateQDomNamedNodeMapProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDomNamedNodeMap), this);
			_interceptor = (QDomNamedNodeMap) realProxy.GetTransparentProxy();
		}
		private QDomNamedNodeMap ProxyQDomNamedNodeMap() {
			return (QDomNamedNodeMap) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDomNamedNodeMap() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDomNamedNodeMapProxy), null);
			_staticInterceptor = (IQDomNamedNodeMapProxy) realProxy.GetTransparentProxy();
		}
		private static IQDomNamedNodeMapProxy StaticQDomNamedNodeMap() {
			return (IQDomNamedNodeMapProxy) _staticInterceptor;
		}

		public QDomNamedNodeMap() : this((Type) null) {
			CreateQDomNamedNodeMapProxy();
			NewQDomNamedNodeMap();
		}
		private void NewQDomNamedNodeMap() {
			ProxyQDomNamedNodeMap().NewQDomNamedNodeMap();
		}
		public QDomNamedNodeMap(QDomNamedNodeMap arg1) : this((Type) null) {
			CreateQDomNamedNodeMapProxy();
			NewQDomNamedNodeMap(arg1);
		}
		private void NewQDomNamedNodeMap(QDomNamedNodeMap arg1) {
			ProxyQDomNamedNodeMap().NewQDomNamedNodeMap(arg1);
		}
		public static bool operator==(QDomNamedNodeMap lhs, QDomNamedNodeMap arg1) {
			return StaticQDomNamedNodeMap().op_equals(lhs,arg1);
		}
		public static bool operator!=(QDomNamedNodeMap lhs, QDomNamedNodeMap arg1) {
			return !StaticQDomNamedNodeMap().op_equals(lhs,arg1);
		}
		public override bool Equals(object o) {
			if (!(o is QDomNamedNodeMap)) { return false; }
			return this == (QDomNamedNodeMap) o;
		}
		public override int GetHashCode() {
			return ProxyQDomNamedNodeMap().GetHashCode();
		}
		public QDomNode NamedItem(string name) {
			return ProxyQDomNamedNodeMap().NamedItem(name);
		}
		public QDomNode SetNamedItem(QDomNode newNode) {
			return ProxyQDomNamedNodeMap().SetNamedItem(newNode);
		}
		public QDomNode RemoveNamedItem(string name) {
			return ProxyQDomNamedNodeMap().RemoveNamedItem(name);
		}
		public QDomNode Item(int index) {
			return ProxyQDomNamedNodeMap().Item(index);
		}
		public QDomNode NamedItemNS(string nsURI, string localName) {
			return ProxyQDomNamedNodeMap().NamedItemNS(nsURI,localName);
		}
		public QDomNode SetNamedItemNS(QDomNode newNode) {
			return ProxyQDomNamedNodeMap().SetNamedItemNS(newNode);
		}
		public QDomNode RemoveNamedItemNS(string nsURI, string localName) {
			return ProxyQDomNamedNodeMap().RemoveNamedItemNS(nsURI,localName);
		}
		public uint Length() {
			return ProxyQDomNamedNodeMap().Length();
		}
		public uint Count() {
			return ProxyQDomNamedNodeMap().Count();
		}
		public bool Contains(string name) {
			return ProxyQDomNamedNodeMap().Contains(name);
		}
		~QDomNamedNodeMap() {
			ProxyQDomNamedNodeMap().Dispose();
		}
		public void Dispose() {
			ProxyQDomNamedNodeMap().Dispose();
		}
	}
}