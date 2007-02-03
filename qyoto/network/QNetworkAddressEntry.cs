//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QNetworkAddressEntry")]
	public class QNetworkAddressEntry : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QNetworkAddressEntry(Type dummy) {}
		interface IQNetworkAddressEntryProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QNetworkAddressEntry), this);
			_interceptor = (QNetworkAddressEntry) realProxy.GetTransparentProxy();
		}
		private QNetworkAddressEntry ProxyQNetworkAddressEntry() {
			return (QNetworkAddressEntry) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QNetworkAddressEntry() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQNetworkAddressEntryProxy), null);
			_staticInterceptor = (IQNetworkAddressEntryProxy) realProxy.GetTransparentProxy();
		}
		private static IQNetworkAddressEntryProxy StaticQNetworkAddressEntry() {
			return (IQNetworkAddressEntryProxy) _staticInterceptor;
		}

		public QNetworkAddressEntry() : this((Type) null) {
			CreateProxy();
			NewQNetworkAddressEntry();
		}
		[SmokeMethod("QNetworkAddressEntry", "()", "")]
		private void NewQNetworkAddressEntry() {
			ProxyQNetworkAddressEntry().NewQNetworkAddressEntry();
		}
		public QNetworkAddressEntry(QNetworkAddressEntry other) : this((Type) null) {
			CreateProxy();
			NewQNetworkAddressEntry(other);
		}
		[SmokeMethod("QNetworkAddressEntry", "(const QNetworkAddressEntry&)", "#")]
		private void NewQNetworkAddressEntry(QNetworkAddressEntry other) {
			ProxyQNetworkAddressEntry().NewQNetworkAddressEntry(other);
		}
		[SmokeMethod("ip", "() const", "")]
		public QHostAddress Ip() {
			return ProxyQNetworkAddressEntry().Ip();
		}
		[SmokeMethod("setIp", "(const QHostAddress&)", "#")]
		public void SetIp(QHostAddress newIp) {
			ProxyQNetworkAddressEntry().SetIp(newIp);
		}
		[SmokeMethod("netmask", "() const", "")]
		public QHostAddress Netmask() {
			return ProxyQNetworkAddressEntry().Netmask();
		}
		[SmokeMethod("setNetmask", "(const QHostAddress&)", "#")]
		public void SetNetmask(QHostAddress newNetmask) {
			ProxyQNetworkAddressEntry().SetNetmask(newNetmask);
		}
		[SmokeMethod("broadcast", "() const", "")]
		public QHostAddress Broadcast() {
			return ProxyQNetworkAddressEntry().Broadcast();
		}
		[SmokeMethod("setBroadcast", "(const QHostAddress&)", "#")]
		public void SetBroadcast(QHostAddress newBroadcast) {
			ProxyQNetworkAddressEntry().SetBroadcast(newBroadcast);
		}
		~QNetworkAddressEntry() {
			DisposeQNetworkAddressEntry();
		}
		public void Dispose() {
			DisposeQNetworkAddressEntry();
		}
		[SmokeMethod("~QNetworkAddressEntry", "()", "")]
		private void DisposeQNetworkAddressEntry() {
			ProxyQNetworkAddressEntry().DisposeQNetworkAddressEntry();
		}
	}
}
