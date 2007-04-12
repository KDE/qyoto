//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QDBusContext")]
	public class QDBusContext : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected QDBusContext(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QDBusContext), this);
		}
		public QDBusContext() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QDBusContext", "QDBusContext()", typeof(void));
		}
		public bool CalledFromDBus() {
			return (bool) interceptor.Invoke("calledFromDBus", "calledFromDBus() const", typeof(bool));
		}
		public QDBusConnection Connection() {
			return (QDBusConnection) interceptor.Invoke("connection", "connection() const", typeof(QDBusConnection));
		}
		public QDBusMessage Message() {
			return (QDBusMessage) interceptor.Invoke("message", "message() const", typeof(QDBusMessage));
		}
		public bool IsDelayedReply() {
			return (bool) interceptor.Invoke("isDelayedReply", "isDelayedReply() const", typeof(bool));
		}
		public void SetDelayedReply(bool enable) {
			interceptor.Invoke("setDelayedReply$", "setDelayedReply(bool) const", typeof(void), typeof(bool), enable);
		}
		public void SendErrorReply(string name, string msg) {
			interceptor.Invoke("sendErrorReply$$", "sendErrorReply(const QString&, const QString&) const", typeof(void), typeof(string), name, typeof(string), msg);
		}
		public void SendErrorReply(string name) {
			interceptor.Invoke("sendErrorReply$", "sendErrorReply(const QString&) const", typeof(void), typeof(string), name);
		}
		public void SendErrorReply(QDBusError.ErrorType type, string msg) {
			interceptor.Invoke("sendErrorReply$$", "sendErrorReply(QDBusError::ErrorType, const QString&) const", typeof(void), typeof(QDBusError.ErrorType), type, typeof(string), msg);
		}
		public void SendErrorReply(QDBusError.ErrorType type) {
			interceptor.Invoke("sendErrorReply$", "sendErrorReply(QDBusError::ErrorType) const", typeof(void), typeof(QDBusError.ErrorType), type);
		}
		~QDBusContext() {
			interceptor.Invoke("~QDBusContext", "~QDBusContext()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~QDBusContext", "~QDBusContext()", typeof(void));
		}
	}
}