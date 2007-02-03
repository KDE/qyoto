//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQTcpServerSignals"></see> for signals emitted by QTcpServer
	[SmokeClass("QTcpServer")]
	public class QTcpServer : QObject, IDisposable {
 		protected QTcpServer(Type dummy) : base((Type) null) {}
		interface IQTcpServerProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTcpServer), this);
			_interceptor = (QTcpServer) realProxy.GetTransparentProxy();
		}
		private QTcpServer ProxyQTcpServer() {
			return (QTcpServer) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTcpServer() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTcpServerProxy), null);
			_staticInterceptor = (IQTcpServerProxy) realProxy.GetTransparentProxy();
		}
		private static IQTcpServerProxy StaticQTcpServer() {
			return (IQTcpServerProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QTcpServer(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQTcpServer(parent);
		}
		[SmokeMethod("QTcpServer", "(QObject*)", "#")]
		private void NewQTcpServer(QObject parent) {
			ProxyQTcpServer().NewQTcpServer(parent);
		}
		public QTcpServer() : this((Type) null) {
			CreateProxy();
			NewQTcpServer();
		}
		[SmokeMethod("QTcpServer", "()", "")]
		private void NewQTcpServer() {
			ProxyQTcpServer().NewQTcpServer();
		}
		[SmokeMethod("listen", "(const QHostAddress&, quint16)", "#$")]
		public bool Listen(QHostAddress address, ushort port) {
			return ProxyQTcpServer().Listen(address,port);
		}
		[SmokeMethod("listen", "(const QHostAddress&)", "#")]
		public bool Listen(QHostAddress address) {
			return ProxyQTcpServer().Listen(address);
		}
		[SmokeMethod("listen", "()", "")]
		public bool Listen() {
			return ProxyQTcpServer().Listen();
		}
		[SmokeMethod("close", "()", "")]
		public void Close() {
			ProxyQTcpServer().Close();
		}
		[SmokeMethod("isListening", "() const", "")]
		public bool IsListening() {
			return ProxyQTcpServer().IsListening();
		}
		[SmokeMethod("setMaxPendingConnections", "(int)", "$")]
		public void SetMaxPendingConnections(int numConnections) {
			ProxyQTcpServer().SetMaxPendingConnections(numConnections);
		}
		[SmokeMethod("maxPendingConnections", "() const", "")]
		public int MaxPendingConnections() {
			return ProxyQTcpServer().MaxPendingConnections();
		}
		[SmokeMethod("serverPort", "() const", "")]
		public ushort ServerPort() {
			return ProxyQTcpServer().ServerPort();
		}
		[SmokeMethod("serverAddress", "() const", "")]
		public QHostAddress ServerAddress() {
			return ProxyQTcpServer().ServerAddress();
		}
		[SmokeMethod("socketDescriptor", "() const", "")]
		public int SocketDescriptor() {
			return ProxyQTcpServer().SocketDescriptor();
		}
		[SmokeMethod("setSocketDescriptor", "(int)", "$")]
		public bool SetSocketDescriptor(int socketDescriptor) {
			return ProxyQTcpServer().SetSocketDescriptor(socketDescriptor);
		}
		[SmokeMethod("waitForNewConnection", "(int, bool*)", "$$")]
		public bool WaitForNewConnection(int msec, out bool timedOut) {
			return ProxyQTcpServer().WaitForNewConnection(msec,out timedOut);
		}
		[SmokeMethod("waitForNewConnection", "(int)", "$")]
		public bool WaitForNewConnection(int msec) {
			return ProxyQTcpServer().WaitForNewConnection(msec);
		}
		[SmokeMethod("waitForNewConnection", "()", "")]
		public bool WaitForNewConnection() {
			return ProxyQTcpServer().WaitForNewConnection();
		}
		[SmokeMethod("hasPendingConnections", "() const", "")]
		public virtual bool HasPendingConnections() {
			return ProxyQTcpServer().HasPendingConnections();
		}
		[SmokeMethod("nextPendingConnection", "()", "")]
		public virtual QTcpSocket NextPendingConnection() {
			return ProxyQTcpServer().NextPendingConnection();
		}
		[SmokeMethod("serverError", "() const", "")]
		public QAbstractSocket.SocketError ServerError() {
			return ProxyQTcpServer().ServerError();
		}
		[SmokeMethod("errorString", "() const", "")]
		public string ErrorString() {
			return ProxyQTcpServer().ErrorString();
		}
		[SmokeMethod("setProxy", "(const QNetworkProxy&)", "#")]
		public void SetProxy(QNetworkProxy networkProxy) {
			ProxyQTcpServer().SetProxy(networkProxy);
		}
		[SmokeMethod("proxy", "() const", "")]
		public QNetworkProxy Proxy() {
			return ProxyQTcpServer().Proxy();
		}
		public static new string Tr(string s, string c) {
			return StaticQTcpServer().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQTcpServer().Tr(s);
		}
		[SmokeMethod("incomingConnection", "(int)", "$")]
		protected virtual void IncomingConnection(int handle) {
			ProxyQTcpServer().IncomingConnection(handle);
		}
		~QTcpServer() {
			DisposeQTcpServer();
		}
		public new void Dispose() {
			DisposeQTcpServer();
		}
		[SmokeMethod("~QTcpServer", "()", "")]
		private void DisposeQTcpServer() {
			ProxyQTcpServer().DisposeQTcpServer();
		}
		protected new IQTcpServerSignals Emit {
			get {
				return (IQTcpServerSignals) Q_EMIT;
			}
		}
	}

	public interface IQTcpServerSignals : IQObjectSignals {
		[Q_SIGNAL("void newConnection()")]
		void NewConnection();
	}
}
