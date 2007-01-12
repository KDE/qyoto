//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QUdpSocket")]
	public class QUdpSocket : QAbstractSocket, IDisposable {
 		protected QUdpSocket(Type dummy) : base((Type) null) {}
		interface IQUdpSocketProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QUdpSocket), this);
			_interceptor = (QUdpSocket) realProxy.GetTransparentProxy();
		}
		private QUdpSocket ProxyQUdpSocket() {
			return (QUdpSocket) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QUdpSocket() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQUdpSocketProxy), null);
			_staticInterceptor = (IQUdpSocketProxy) realProxy.GetTransparentProxy();
		}
		private static IQUdpSocketProxy StaticQUdpSocket() {
			return (IQUdpSocketProxy) _staticInterceptor;
		}

		public enum BindFlag {
			DefaultForPlatform = 0x0,
			ShareAddress = 0x1,
			DontShareAddress = 0x2,
			ReuseAddressHint = 0x4,
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QUdpSocket(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQUdpSocket(parent);
		}
		[SmokeMethod("QUdpSocket(QObject*)")]
		private void NewQUdpSocket(QObject parent) {
			ProxyQUdpSocket().NewQUdpSocket(parent);
		}
		public QUdpSocket() : this((Type) null) {
			CreateProxy();
			NewQUdpSocket();
		}
		[SmokeMethod("QUdpSocket()")]
		private void NewQUdpSocket() {
			ProxyQUdpSocket().NewQUdpSocket();
		}
		[SmokeMethod("bind(const QHostAddress&, quint16)")]
		public bool Bind(QHostAddress address, ushort port) {
			return ProxyQUdpSocket().Bind(address,port);
		}
		[SmokeMethod("bind(quint16)")]
		public bool Bind(ushort port) {
			return ProxyQUdpSocket().Bind(port);
		}
		[SmokeMethod("bind()")]
		public bool Bind() {
			return ProxyQUdpSocket().Bind();
		}
		[SmokeMethod("bind(const QHostAddress&, quint16, BindMode)")]
		public bool Bind(QHostAddress address, ushort port, int mode) {
			return ProxyQUdpSocket().Bind(address,port,mode);
		}
		[SmokeMethod("bind(quint16, BindMode)")]
		public bool Bind(ushort port, int mode) {
			return ProxyQUdpSocket().Bind(port,mode);
		}
		[SmokeMethod("hasPendingDatagrams() const")]
		public bool HasPendingDatagrams() {
			return ProxyQUdpSocket().HasPendingDatagrams();
		}
		// qint64 pendingDatagramSize(); >>>> NOT CONVERTED
		// qint64 readDatagram(char* arg1,qint64 arg2,QHostAddress* arg3,quint16* arg4); >>>> NOT CONVERTED
		// qint64 readDatagram(char* arg1,qint64 arg2,QHostAddress* arg3); >>>> NOT CONVERTED
		// qint64 readDatagram(char* arg1,qint64 arg2); >>>> NOT CONVERTED
		// qint64 writeDatagram(const char* arg1,qint64 arg2,const QHostAddress& arg3,quint16 arg4); >>>> NOT CONVERTED
		// qint64 writeDatagram(const QByteArray& arg1,const QHostAddress& arg2,quint16 arg3); >>>> NOT CONVERTED
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQUdpSocket().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQUdpSocket().Tr(s);
		}
		~QUdpSocket() {
			DisposeQUdpSocket();
		}
		public new void Dispose() {
			DisposeQUdpSocket();
		}
		[SmokeMethod("~QUdpSocket()")]
		private void DisposeQUdpSocket() {
			ProxyQUdpSocket().DisposeQUdpSocket();
		}
		protected new IQUdpSocketSignals Emit() {
			return (IQUdpSocketSignals) Q_EMIT;
		}
	}

	public interface IQUdpSocketSignals : IQAbstractSocketSignals {
	}
}