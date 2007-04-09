//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	///<remarks> See <see cref="IQSslSocketSignals"></see> for signals emitted by QSslSocket
	///</remarks>

	[SmokeClass("QSslSocket")]
	public class QSslSocket : QTcpSocket, IDisposable {
 		protected QSslSocket(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QSslSocket), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QSslSocket() {
			staticInterceptor = new SmokeInvocation(typeof(QSslSocket), null);
		}
		public enum Mode {
			PlainMode = 0,
			SslClientMode = 1,
			SslServerMode = 2,
		}
		public enum Protocol {
			SslV3 = 0,
			SslV2 = 1,
			TlsV1 = 2,
			Compat = 3,
		}
		public QSslSocket(QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSslSocket#", "QSslSocket(QObject*)", typeof(void), typeof(QObject), parent);
		}
		public QSslSocket() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSslSocket", "QSslSocket()", typeof(void));
		}
		public void ConnectToHostEncrypted(string hostName, ushort port, int mode) {
			interceptor.Invoke("connectToHostEncrypted$$$", "connectToHostEncrypted(const QString&, quint16, OpenMode)", typeof(void), typeof(string), hostName, typeof(ushort), port, typeof(int), mode);
		}
		public void ConnectToHostEncrypted(string hostName, ushort port) {
			interceptor.Invoke("connectToHostEncrypted$$", "connectToHostEncrypted(const QString&, quint16)", typeof(void), typeof(string), hostName, typeof(ushort), port);
		}
		public QSslSocket.Mode mode() {
			return (QSslSocket.Mode) interceptor.Invoke("mode", "mode() const", typeof(QSslSocket.Mode));
		}
		public bool IsEncrypted() {
			return (bool) interceptor.Invoke("isEncrypted", "isEncrypted() const", typeof(bool));
		}
		public QSslSocket.Protocol protocol() {
			return (QSslSocket.Protocol) interceptor.Invoke("protocol", "protocol() const", typeof(QSslSocket.Protocol));
		}
		public void SetProtocol(QSslSocket.Protocol protocol) {
			interceptor.Invoke("setProtocol$", "setProtocol(QSslSocket::Protocol)", typeof(void), typeof(QSslSocket.Protocol), protocol);
		}
		[SmokeMethod("bytesAvailable() const")]
		public override long BytesAvailable() {
			return (long) interceptor.Invoke("bytesAvailable", "bytesAvailable() const", typeof(long));
		}
		[SmokeMethod("bytesToWrite() const")]
		public override long BytesToWrite() {
			return (long) interceptor.Invoke("bytesToWrite", "bytesToWrite() const", typeof(long));
		}
		[SmokeMethod("canReadLine() const")]
		public override bool CanReadLine() {
			return (bool) interceptor.Invoke("canReadLine", "canReadLine() const", typeof(bool));
		}
		[SmokeMethod("close()")]
		public override void Close() {
			interceptor.Invoke("close", "close()", typeof(void));
		}
		[SmokeMethod("atEnd() const")]
		public override bool AtEnd() {
			return (bool) interceptor.Invoke("atEnd", "atEnd() const", typeof(bool));
		}
		public void SetLocalCertificate(QSslCertificate certificate) {
			interceptor.Invoke("setLocalCertificate#", "setLocalCertificate(const QSslCertificate&)", typeof(void), typeof(QSslCertificate), certificate);
		}
		public QSslCertificate LocalCertificate() {
			return (QSslCertificate) interceptor.Invoke("localCertificate", "localCertificate() const", typeof(QSslCertificate));
		}
		public QSslCertificate PeerCertificate() {
			return (QSslCertificate) interceptor.Invoke("peerCertificate", "peerCertificate() const", typeof(QSslCertificate));
		}
		public List<QSslCertificate> PeerCertificateChain() {
			return (List<QSslCertificate>) interceptor.Invoke("peerCertificateChain", "peerCertificateChain() const", typeof(List<QSslCertificate>));
		}
		public QSslCipher CurrentCipher() {
			return (QSslCipher) interceptor.Invoke("currentCipher", "currentCipher() const", typeof(QSslCipher));
		}
		public void SetPrivateKey(QSslKey key) {
			interceptor.Invoke("setPrivateKey#", "setPrivateKey(const QSslKey&)", typeof(void), typeof(QSslKey), key);
		}
		public QSslKey PrivateKey() {
			return (QSslKey) interceptor.Invoke("privateKey", "privateKey() const", typeof(QSslKey));
		}
		public List<QSslCipher> Ciphers() {
			return (List<QSslCipher>) interceptor.Invoke("ciphers", "ciphers() const", typeof(List<QSslCipher>));
		}
		public void ResetCiphers() {
			interceptor.Invoke("resetCiphers", "resetCiphers()", typeof(void));
		}
		public void SetCiphers(List<QSslCipher> ciphers) {
			interceptor.Invoke("setCiphers?", "setCiphers(const QList<QSslCipher>&)", typeof(void), typeof(List<QSslCipher>), ciphers);
		}
		public bool AddCaCertificates(string path) {
			return (bool) interceptor.Invoke("addCaCertificates$", "addCaCertificates(const QString&)", typeof(bool), typeof(string), path);
		}
		public void AddCaCertificate(QSslCertificate certificate) {
			interceptor.Invoke("addCaCertificate#", "addCaCertificate(const QSslCertificate&)", typeof(void), typeof(QSslCertificate), certificate);
		}
		public void AddCaCertificates(List<QSslCertificate> certificates) {
			interceptor.Invoke("addCaCertificates?", "addCaCertificates(const QList<QSslCertificate>&)", typeof(void), typeof(List<QSslCertificate>), certificates);
		}
		public void SetCaCertificates(List<QSslCertificate> certificates) {
			interceptor.Invoke("setCaCertificates?", "setCaCertificates(const QList<QSslCertificate>&)", typeof(void), typeof(List<QSslCertificate>), certificates);
		}
		public void ResetCaCertificates() {
			interceptor.Invoke("resetCaCertificates", "resetCaCertificates()", typeof(void));
		}
		public List<QSslCertificate> CaCertificates() {
			return (List<QSslCertificate>) interceptor.Invoke("caCertificates", "caCertificates() const", typeof(List<QSslCertificate>));
		}
		public bool WaitForEncrypted(int msecs) {
			return (bool) interceptor.Invoke("waitForEncrypted$", "waitForEncrypted(int)", typeof(bool), typeof(int), msecs);
		}
		[SmokeMethod("waitForReadyRead(int)")]
		public override bool WaitForReadyRead(int msecs) {
			return (bool) interceptor.Invoke("waitForReadyRead$", "waitForReadyRead(int)", typeof(bool), typeof(int), msecs);
		}
		[SmokeMethod("waitForBytesWritten(int)")]
		public override bool WaitForBytesWritten(int msecs) {
			return (bool) interceptor.Invoke("waitForBytesWritten$", "waitForBytesWritten(int)", typeof(bool), typeof(int), msecs);
		}
		[Q_SLOT("void startClientHandShake()")]
		public void StartClientHandShake() {
			interceptor.Invoke("startClientHandShake", "startClientHandShake()", typeof(void));
		}
		[Q_SLOT("void startServerHandShake()")]
		public void StartServerHandShake() {
			interceptor.Invoke("startServerHandShake", "startServerHandShake()", typeof(void));
		}
		[Q_SLOT("void ignoreSslErrors()")]
		public void IgnoreSslErrors() {
			interceptor.Invoke("ignoreSslErrors", "ignoreSslErrors()", typeof(void));
		}
		[SmokeMethod("readData(char*, qint64)")]
		protected override long ReadData(string data, long maxlen) {
			return (long) interceptor.Invoke("readData$$", "readData(char*, qint64)", typeof(long), typeof(string), data, typeof(long), maxlen);
		}
		[SmokeMethod("writeData(const char*, qint64)")]
		protected override long WriteData(string data, long len) {
			return (long) interceptor.Invoke("writeData$$", "writeData(const char*, qint64)", typeof(long), typeof(string), data, typeof(long), len);
		}
		[Q_SLOT("void connectToHostImplementation(const QString&, quint16, OpenMode)")]
		protected new void ConnectToHostImplementation(string hostName, ushort port, int openMode) {
			interceptor.Invoke("connectToHostImplementation$$$", "connectToHostImplementation(const QString&, quint16, OpenMode)", typeof(void), typeof(string), hostName, typeof(ushort), port, typeof(int), openMode);
		}
		[Q_SLOT("void disconnectFromHostImplementation()")]
		protected new void DisconnectFromHostImplementation() {
			interceptor.Invoke("disconnectFromHostImplementation", "disconnectFromHostImplementation()", typeof(void));
		}
		~QSslSocket() {
			interceptor.Invoke("~QSslSocket", "~QSslSocket()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QSslSocket", "~QSslSocket()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		public static void SetGlobalCiphers(List<QSslCipher> ciphers) {
			staticInterceptor.Invoke("setGlobalCiphers?", "setGlobalCiphers(const QList<QSslCipher>&)", typeof(void), typeof(List<QSslCipher>), ciphers);
		}
		public static void ResetGlobalCiphers() {
			staticInterceptor.Invoke("resetGlobalCiphers", "resetGlobalCiphers()", typeof(void));
		}
		public static List<QSslCipher> GlobalCiphers() {
			return (List<QSslCipher>) staticInterceptor.Invoke("globalCiphers", "globalCiphers()", typeof(List<QSslCipher>));
		}
		public static List<QSslCipher> SupportedCiphers() {
			return (List<QSslCipher>) staticInterceptor.Invoke("supportedCiphers", "supportedCiphers()", typeof(List<QSslCipher>));
		}
		public static bool AddGlobalCaCertificates(string path) {
			return (bool) staticInterceptor.Invoke("addGlobalCaCertificates$", "addGlobalCaCertificates(const QString&)", typeof(bool), typeof(string), path);
		}
		public static void AddGlobalCaCertificate(QSslCertificate certificate) {
			staticInterceptor.Invoke("addGlobalCaCertificate#", "addGlobalCaCertificate(const QSslCertificate&)", typeof(void), typeof(QSslCertificate), certificate);
		}
		public static void AddGlobalCaCertificates(List<QSslCertificate> certificates) {
			staticInterceptor.Invoke("addGlobalCaCertificates?", "addGlobalCaCertificates(const QList<QSslCertificate>&)", typeof(void), typeof(List<QSslCertificate>), certificates);
		}
		public static void SetGlobalCaCertificates(List<QSslCertificate> certificates) {
			staticInterceptor.Invoke("setGlobalCaCertificates?", "setGlobalCaCertificates(const QList<QSslCertificate>&)", typeof(void), typeof(List<QSslCertificate>), certificates);
		}
		public static List<QSslCertificate> GlobalCaCertificates() {
			return (List<QSslCertificate>) staticInterceptor.Invoke("globalCaCertificates", "globalCaCertificates()", typeof(List<QSslCertificate>));
		}
		public static List<QSslCertificate> SystemCaCertificates() {
			return (List<QSslCertificate>) staticInterceptor.Invoke("systemCaCertificates", "systemCaCertificates()", typeof(List<QSslCertificate>));
		}
		public static bool SupportsSsl() {
			return (bool) staticInterceptor.Invoke("supportsSsl", "supportsSsl()", typeof(bool));
		}
		protected new IQSslSocketSignals Emit {
			get { return (IQSslSocketSignals) Q_EMIT; }
		}
	}

	public interface IQSslSocketSignals : IQTcpSocketSignals {
		[Q_SIGNAL("void encrypted()")]
		void Encrypted();
		[Q_SIGNAL("void sslErrors(const QList<QSslError>&)")]
		void SslErrors(List<QSslError> errors);
		[Q_SIGNAL("void modeChanged(QSslSocket::Mode)")]
		void ModeChanged(QSslSocket.Mode newMode);
	}
}
