//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QHostAddress : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QHostAddress(Type dummy) {}
		interface IQHostAddressProxy {
			bool op_equals(QHostAddress lhs, QHostAddress address);
			bool op_equals(QHostAddress lhs, int address);
		}

		protected void CreateQHostAddressProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHostAddress), this);
			_interceptor = (QHostAddress) realProxy.GetTransparentProxy();
		}
		private QHostAddress ProxyQHostAddress() {
			return (QHostAddress) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHostAddress() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHostAddressProxy), null);
			_staticInterceptor = (IQHostAddressProxy) realProxy.GetTransparentProxy();
		}
		private static IQHostAddressProxy StaticQHostAddress() {
			return (IQHostAddressProxy) _staticInterceptor;
		}

		enum SpecialAddress {
			Null = 0,
			Broadcast = 1,
			LocalHost = 2,
			LocalHostIPv6 = 3,
			Any = 4,
			AnyIPv6 = 5,
		}
		public QHostAddress() : this((Type) null) {
			CreateQHostAddressProxy();
			NewQHostAddress();
		}
		private void NewQHostAddress() {
			ProxyQHostAddress().NewQHostAddress();
		}
		public QHostAddress(uint ip4Addr) : this((Type) null) {
			CreateQHostAddressProxy();
			NewQHostAddress(ip4Addr);
		}
		private void NewQHostAddress(uint ip4Addr) {
			ProxyQHostAddress().NewQHostAddress(ip4Addr);
		}
		// QHostAddress* QHostAddress(quint8* arg1); >>>> NOT CONVERTED
		// QHostAddress* QHostAddress(const Q_IPV6ADDR& arg1); >>>> NOT CONVERTED
		public QHostAddress(string address) : this((Type) null) {
			CreateQHostAddressProxy();
			NewQHostAddress(address);
		}
		private void NewQHostAddress(string address) {
			ProxyQHostAddress().NewQHostAddress(address);
		}
		public QHostAddress(QHostAddress copy) : this((Type) null) {
			CreateQHostAddressProxy();
			NewQHostAddress(copy);
		}
		private void NewQHostAddress(QHostAddress copy) {
			ProxyQHostAddress().NewQHostAddress(copy);
		}
		public QHostAddress(int address) : this((Type) null) {
			CreateQHostAddressProxy();
			NewQHostAddress(address);
		}
		private void NewQHostAddress(int address) {
			ProxyQHostAddress().NewQHostAddress(address);
		}
		public void SetAddress(uint ip4Addr) {
			ProxyQHostAddress().SetAddress(ip4Addr);
		}
		// void setAddress(quint8* arg1); >>>> NOT CONVERTED
		// void setAddress(const Q_IPV6ADDR& arg1); >>>> NOT CONVERTED
		public bool SetAddress(string address) {
			return ProxyQHostAddress().SetAddress(address);
		}
		public int Protocol() {
			return ProxyQHostAddress().Protocol();
		}
		public uint ToIPv4Address() {
			return ProxyQHostAddress().ToIPv4Address();
		}
		// Q_IPV6ADDR toIPv6Address(); >>>> NOT CONVERTED
		public new string ToString() {
			return ProxyQHostAddress().ToString();
		}
		public static bool operator==(QHostAddress lhs, QHostAddress address) {
			return StaticQHostAddress().op_equals(lhs,address);
		}
		public static bool operator!=(QHostAddress lhs, QHostAddress address) {
			return !StaticQHostAddress().op_equals(lhs,address);
		}
		public override bool Equals(object o) {
			if (!(o is QHostAddress)) { return false; }
			return this == (QHostAddress) o;
		}
		public override int GetHashCode() {
			return ProxyQHostAddress().GetHashCode();
		}
		public static bool operator==(QHostAddress lhs, int address) {
			return StaticQHostAddress().op_equals(lhs,address);
		}
		public static bool operator!=(QHostAddress lhs, int address) {
			return !StaticQHostAddress().op_equals(lhs,address);
		}
/*
		public override bool Equals(object o) {
			if (!(o is QHostAddress)) { return false; }
			return this == (QHostAddress) o;
		}
		public override int GetHashCode() {
			return ProxyQHostAddress().GetHashCode();
		}
*/
		public bool IsNull() {
			return ProxyQHostAddress().IsNull();
		}
		public void Clear() {
			ProxyQHostAddress().Clear();
		}
		~QHostAddress() {
			ProxyQHostAddress().Dispose();
		}
		public void Dispose() {
			ProxyQHostAddress().Dispose();
		}
	}
}