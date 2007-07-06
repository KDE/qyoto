//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace KIO {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;

	/// <remarks>
	///  @private
	///  This class provides a simple means for IPC between two applications
	///  via a pipe.
	///  It handles a queue of commands to be sent which makes it possible to
	///  queue data before an actual connection has been established.
	///      </remarks>		<short>    @private </short>

	[SmokeClass("KIO::Connection")]
	public class Connection : QObject, IDisposable {
 		protected Connection(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(Connection), this);
		}
		// void init(KNetwork::KStreamSocket* arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Creates a new connection.
		/// </remarks>		<short>    Creates a new connection.</short>
		/// 		<see> init</see>
		public Connection() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("Connection", "Connection()", typeof(void));
		}
		/// <remarks>
		///  Initialize this connection to use the given socket.
		/// <param> name="sock" the socket to use
		/// </param></remarks>		<short>    Initialize this connection to use the given socket.</short>
		/// 		<see> inited</see>
		/// <remarks>
		///  Initialize the connection to use the given file
		///  descriptors.
		/// <param> name="fd_in" the input file descriptor to use
		/// </param><param> name="fd_out" the output file descriptor to use
		/// </param></remarks>		<short>    Initialize the connection to use the given file  descriptors.</short>
		/// 		<see> inited</see>
		public void Init(int fd_in, int fd_out) {
			interceptor.Invoke("init$$", "init(int, int)", typeof(void), typeof(int), fd_in, typeof(int), fd_out);
		}
		public void Connect(QObject receiver, string member) {
			interceptor.Invoke("connect#$", "connect(QObject*, const char*)", typeof(void), typeof(QObject), receiver, typeof(string), member);
		}
		public void Connect(QObject receiver) {
			interceptor.Invoke("connect#", "connect(QObject*)", typeof(void), typeof(QObject), receiver);
		}
		public void Connect() {
			interceptor.Invoke("connect", "connect()", typeof(void));
		}
		public void Close() {
			interceptor.Invoke("close", "close()", typeof(void));
		}
		/// <remarks>
		///  Returns the input file descriptor.
		/// </remarks>		<return> the input file descriptor
		/// 	 </return>
		/// 		<short>    Returns the input file descriptor.</short>
		public int Fd_from() {
			return (int) interceptor.Invoke("fd_from", "fd_from() const", typeof(int));
		}
		/// <remarks>
		///  Returns the output file descriptor.
		/// </remarks>		<return> the output file descriptor
		/// 	 </return>
		/// 		<short>    Returns the output file descriptor.</short>
		public int Fd_to() {
			return (int) interceptor.Invoke("fd_to", "fd_to() const", typeof(int));
		}
		/// <remarks>
		///  Checks whether the connection has been initialized.
		/// </remarks>		<return> true if the initialized
		/// </return>
		/// 		<short>    Checks whether the connection has been initialized.</short>
		/// 		<see> init</see>
		public bool Inited() {
			return (bool) interceptor.Invoke("inited", "inited() const", typeof(bool));
		}
		/// <remarks>
		///  Sends/queues the given command to be sent.
		/// <param> name="cmd" the command to set
		/// </param><param> name="arr" the bytes to send
		/// </param></remarks>		<return> true if successful, false otherwise
		/// 	 </return>
		/// 		<short>    Sends/queues the given command to be sent.</short>
		public bool Send(int cmd, QByteArray arr) {
			return (bool) interceptor.Invoke("send$#", "send(int, const QByteArray&)", typeof(bool), typeof(int), cmd, typeof(QByteArray), arr);
		}
		public bool Send(int cmd) {
			return (bool) interceptor.Invoke("send$", "send(int)", typeof(bool), typeof(int), cmd);
		}
		/// <remarks>
		///  Sends the given command immediately.
		/// <param> name="_cmd" the command to set
		/// </param><param> name="data" the bytes to send
		/// </param></remarks>		<return> true if successful, false otherwise
		/// 	 </return>
		/// 		<short>    Sends the given command immediately.</short>
		public bool Sendnow(int _cmd, QByteArray data) {
			return (bool) interceptor.Invoke("sendnow$#", "sendnow(int, const QByteArray&)", typeof(bool), typeof(int), _cmd, typeof(QByteArray), data);
		}
		/// <remarks>
		///  Receive data.
		/// <param> name="_cmd" the received command will be written here
		/// </param><param> name="data" the received data will be written here
		/// </param></remarks>		<return> >=0 indicates the received data size upon success
		///          -1  indicates error
		/// 	 </return>
		/// 		<short>    Receive data.</short>
		public int Read(ref int _cmd, QByteArray data) {
			StackItem[] stack = new StackItem[3];
			stack[1].s_int = _cmd;
#if DEBUG
			stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(data);
#else
			stack[2].s_class = (IntPtr) GCHandle.Alloc(data);
#endif
			interceptor.Invoke("read$#", "read(int*, QByteArray&)", stack);
			_cmd = stack[1].s_int;
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
			((GCHandle) stack[2].s_class).Free();
#endif
			return stack[0].s_int;
		}
		/// <remarks>
		///  Don't handle incoming data until resumed.
		///          </remarks>		<short>    Don't handle incoming data until resumed.</short>
		public void Suspend() {
			interceptor.Invoke("suspend", "suspend()", typeof(void));
		}
		/// <remarks>
		///  Resume handling of incoming data.
		///          </remarks>		<short>    Resume handling of incoming data.</short>
		public void Resume() {
			interceptor.Invoke("resume", "resume()", typeof(void));
		}
		/// <remarks>
		///  Returns status of connection.
		/// </remarks>		<return> true if suspended, false otherwise
		///          </return>
		/// 		<short>    Returns status of connection.</short>
		public bool Suspended() {
			return (bool) interceptor.Invoke("suspended", "suspended() const", typeof(bool));
		}
		[Q_SLOT("void dequeue()")]
		protected void Dequeue() {
			interceptor.Invoke("dequeue", "dequeue()", typeof(void));
		}
		~Connection() {
			interceptor.Invoke("~Connection", "~Connection()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~Connection", "~Connection()", typeof(void));
		}
		protected new IConnectionSignals Emit {
			get { return (IConnectionSignals) Q_EMIT; }
		}
	}

	public interface IConnectionSignals : IQObjectSignals {
	}
	}
}
