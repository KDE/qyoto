//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	/// See <see cref="IQSocketSignals"></see> for signals emitted by QSocket
	[SmokeClass("QSocket")]
	public class QSocket : QObject, IQIODevice, IDisposable {
 		protected QSocket(Type dummy) : base((Type) null) {}
		interface IQSocketProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQSocketProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSocket), this);
			_interceptor = (QSocket) realProxy.GetTransparentProxy();
		}
		private QSocket ProxyQSocket() {
			return (QSocket) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSocket() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSocketProxy), null);
			_staticInterceptor = (IQSocketProxy) realProxy.GetTransparentProxy();
		}
		private static IQSocketProxy StaticQSocket() {
			return (IQSocketProxy) _staticInterceptor;
		}

		public enum Error {
			ErrConnectionRefused = 0,
			ErrHostNotFound = 1,
			ErrSocketRead = 2,
		}
		public enum State {
			Idle = 0,
			HostLookup = 1,
			Connecting = 2,
			Connected = 3,
			Closing = 4,
			Connection = Connected,
		}
		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQSocket().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQSocket().ClassName();
		}
		public QSocket(QObject parent, string name) : this((Type) null) {
			CreateQSocketProxy();
			CreateQSocketSignalProxy();
			NewQSocket(parent,name);
		}
		[SmokeMethod("QSocket(QObject*, const char*)")]
		private void NewQSocket(QObject parent, string name) {
			ProxyQSocket().NewQSocket(parent,name);
		}
		public QSocket(QObject parent) : this((Type) null) {
			CreateQSocketProxy();
			CreateQSocketSignalProxy();
			NewQSocket(parent);
		}
		[SmokeMethod("QSocket(QObject*)")]
		private void NewQSocket(QObject parent) {
			ProxyQSocket().NewQSocket(parent);
		}
		public QSocket() : this((Type) null) {
			CreateQSocketProxy();
			CreateQSocketSignalProxy();
			NewQSocket();
		}
		[SmokeMethod("QSocket()")]
		private void NewQSocket() {
			ProxyQSocket().NewQSocket();
		}
		[SmokeMethod("state() const")]
		public int state() {
			return ProxyQSocket().state();
		}
		[SmokeMethod("socket() const")]
		public int Socket() {
			return ProxyQSocket().Socket();
		}
		[SmokeMethod("setSocket(int)")]
		public virtual void SetSocket(int arg1) {
			ProxyQSocket().SetSocket(arg1);
		}
		[SmokeMethod("socketDevice()")]
		public QSocketDevice SocketDevice() {
			return ProxyQSocket().SocketDevice();
		}
		[SmokeMethod("setSocketDevice(QSocketDevice*)")]
		public virtual void SetSocketDevice(QSocketDevice arg1) {
			ProxyQSocket().SetSocketDevice(arg1);
		}
		[SmokeMethod("connectToHost(const QString&, Q_UINT16)")]
		public virtual void ConnectToHost(string host, ushort port) {
			ProxyQSocket().ConnectToHost(host,port);
		}
		[SmokeMethod("peerName() const")]
		public string PeerName() {
			return ProxyQSocket().PeerName();
		}
		[SmokeMethod("open(int)")]
		public bool Open(int mode) {
			return ProxyQSocket().Open(mode);
		}
		[SmokeMethod("close()")]
		public void Close() {
			ProxyQSocket().Close();
		}
		[SmokeMethod("flush()")]
		public void Flush() {
			ProxyQSocket().Flush();
		}
		[SmokeMethod("size() const")]
		public ulong Size() {
			return ProxyQSocket().Size();
		}
		[SmokeMethod("at() const")]
		public ulong At() {
			return ProxyQSocket().At();
		}
		[SmokeMethod("at(QIODevice::Offset)")]
		public bool At(ulong arg1) {
			return ProxyQSocket().At(arg1);
		}
		[SmokeMethod("atEnd() const")]
		public bool AtEnd() {
			return ProxyQSocket().AtEnd();
		}
		[SmokeMethod("bytesAvailable() const")]
		public long BytesAvailable() {
			return ProxyQSocket().BytesAvailable();
		}
		[SmokeMethod("waitForMore(int, bool*) const")]
		public long WaitForMore(int msecs, out bool timeout) {
			return ProxyQSocket().WaitForMore(msecs,out timeout);
		}
		[SmokeMethod("waitForMore(int) const")]
		public long WaitForMore(int msecs) {
			return ProxyQSocket().WaitForMore(msecs);
		}
		[SmokeMethod("bytesToWrite() const")]
		public long BytesToWrite() {
			return ProxyQSocket().BytesToWrite();
		}
		[SmokeMethod("clearPendingData()")]
		public void ClearPendingData() {
			ProxyQSocket().ClearPendingData();
		}
		[SmokeMethod("readBlock(char*, Q_ULONG)")]
		public long ReadBlock(string data, long maxlen) {
			return ProxyQSocket().ReadBlock(data,maxlen);
		}
		[SmokeMethod("writeBlock(const char*, Q_ULONG)")]
		public long WriteBlock(string data, long len) {
			return ProxyQSocket().WriteBlock(data,len);
		}
		[SmokeMethod("readLine(char*, Q_ULONG)")]
		public long ReadLine(string data, long maxlen) {
			return ProxyQSocket().ReadLine(data,maxlen);
		}
		[SmokeMethod("getch()")]
		public int Getch() {
			return ProxyQSocket().Getch();
		}
		[SmokeMethod("putch(int)")]
		public int Putch(int arg1) {
			return ProxyQSocket().Putch(arg1);
		}
		[SmokeMethod("ungetch(int)")]
		public int Ungetch(int arg1) {
			return ProxyQSocket().Ungetch(arg1);
		}
		[SmokeMethod("canReadLine() const")]
		public bool CanReadLine() {
			return ProxyQSocket().CanReadLine();
		}
		[SmokeMethod("readLine()")]
		public virtual string ReadLine() {
			return ProxyQSocket().ReadLine();
		}
		[SmokeMethod("port() const")]
		public ushort Port() {
			return ProxyQSocket().Port();
		}
		[SmokeMethod("peerPort() const")]
		public ushort PeerPort() {
			return ProxyQSocket().PeerPort();
		}
		[SmokeMethod("address() const")]
		public QHostAddress Address() {
			return ProxyQSocket().Address();
		}
		[SmokeMethod("peerAddress() const")]
		public QHostAddress PeerAddress() {
			return ProxyQSocket().PeerAddress();
		}
		[SmokeMethod("setReadBufferSize(Q_ULONG)")]
		public void SetReadBufferSize(long arg1) {
			ProxyQSocket().SetReadBufferSize(arg1);
		}
		[SmokeMethod("readBufferSize() const")]
		public long ReadBufferSize() {
			return ProxyQSocket().ReadBufferSize();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQSocket().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQSocket().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQSocket().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQSocket().TrUtf8(arg1);
		}
		[Q_SLOT("void sn_read(bool)")]
		[SmokeMethod("sn_read(bool)")]
		protected virtual void Sn_read(bool force) {
			ProxyQSocket().Sn_read(force);
		}
		[Q_SLOT("void sn_read()")]
		[SmokeMethod("sn_read()")]
		protected virtual void Sn_read() {
			ProxyQSocket().Sn_read();
		}
		[Q_SLOT("void sn_write()")]
		[SmokeMethod("sn_write()")]
		protected virtual void Sn_write() {
			ProxyQSocket().Sn_write();
		}
		~QSocket() {
			DisposeQSocket();
		}
		public new void Dispose() {
			DisposeQSocket();
		}
		private void DisposeQSocket() {
			ProxyQSocket().DisposeQSocket();
		}
		[SmokeMethod("flags() const")]
		public int Flags() {
			return ProxyQSocket().Flags();
		}
		[SmokeMethod("mode() const")]
		public int Mode() {
			return ProxyQSocket().Mode();
		}
		[SmokeMethod("isDirectAccess() const")]
		public bool IsDirectAccess() {
			return ProxyQSocket().IsDirectAccess();
		}
		[SmokeMethod("isSequentialAccess() const")]
		public bool IsSequentialAccess() {
			return ProxyQSocket().IsSequentialAccess();
		}
		[SmokeMethod("isCombinedAccess() const")]
		public bool IsCombinedAccess() {
			return ProxyQSocket().IsCombinedAccess();
		}
		[SmokeMethod("isBuffered() const")]
		public bool IsBuffered() {
			return ProxyQSocket().IsBuffered();
		}
		[SmokeMethod("isRaw() const")]
		public bool IsRaw() {
			return ProxyQSocket().IsRaw();
		}
		[SmokeMethod("isSynchronous() const")]
		public bool IsSynchronous() {
			return ProxyQSocket().IsSynchronous();
		}
		[SmokeMethod("isAsynchronous() const")]
		public bool IsAsynchronous() {
			return ProxyQSocket().IsAsynchronous();
		}
		[SmokeMethod("isTranslated() const")]
		public bool IsTranslated() {
			return ProxyQSocket().IsTranslated();
		}
		[SmokeMethod("isReadable() const")]
		public bool IsReadable() {
			return ProxyQSocket().IsReadable();
		}
		[SmokeMethod("isWritable() const")]
		public bool IsWritable() {
			return ProxyQSocket().IsWritable();
		}
		[SmokeMethod("isReadWrite() const")]
		public bool IsReadWrite() {
			return ProxyQSocket().IsReadWrite();
		}
		[SmokeMethod("isInactive() const")]
		public bool IsInactive() {
			return ProxyQSocket().IsInactive();
		}
		[SmokeMethod("isOpen() const")]
		public bool IsOpen() {
			return ProxyQSocket().IsOpen();
		}
		[SmokeMethod("status() const")]
		public int Status() {
			return ProxyQSocket().Status();
		}
		[SmokeMethod("resetStatus()")]
		public void ResetStatus() {
			ProxyQSocket().ResetStatus();
		}
		[SmokeMethod("reset()")]
		public bool Reset() {
			return ProxyQSocket().Reset();
		}
		[SmokeMethod("writeBlock(const QByteArray&)")]
		public long WriteBlock(QByteArray data) {
			return ProxyQSocket().WriteBlock(data);
		}
		[SmokeMethod("readAll()")]
		public virtual QByteArray ReadAll() {
			return ProxyQSocket().ReadAll();
		}
		[SmokeMethod("setFlags(int)")]
		protected void SetFlags(int f) {
			ProxyQSocket().SetFlags(f);
		}
		[SmokeMethod("setType(int)")]
		protected void SetType(int arg1) {
			ProxyQSocket().SetType(arg1);
		}
		[SmokeMethod("setMode(int)")]
		protected void SetMode(int arg1) {
			ProxyQSocket().SetMode(arg1);
		}
		[SmokeMethod("setState(int)")]
		public void SetState(int arg1) {
			ProxyQSocket().SetState(arg1);
		}
		[SmokeMethod("setStatus(int)")]
		public void SetStatus(int arg1) {
			ProxyQSocket().SetStatus(arg1);
		}
		protected void CreateQSocketSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQSocketSignals), this);
			Q_EMIT = (IQSocketSignals) realProxy.GetTransparentProxy();
		}
		protected new IQSocketSignals Emit() {
			return (IQSocketSignals) Q_EMIT;
		}
	}

	public interface IQSocketSignals : IQObjectSignals {
		[Q_SIGNAL("void hostFound()")]
		void HostFound();
		[Q_SIGNAL("void connected()")]
		void Connected();
		[Q_SIGNAL("void connectionClosed()")]
		void ConnectionClosed();
		[Q_SIGNAL("void delayedCloseFinished()")]
		void DelayedCloseFinished();
		[Q_SIGNAL("void readyRead()")]
		void ReadyRead();
		[Q_SIGNAL("void bytesWritten(int)")]
		void BytesWritten(int nbytes);
		[Q_SIGNAL("void error(int)")]
		void Error(int arg1);
	}
}