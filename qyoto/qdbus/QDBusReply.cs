namespace Qyoto {

	using System;

	public class QDBusReply<T> {
		public QDBusReply(QDBusMessage reply) {
		}
	
		public QDBusReply(QDBusError dbusError)
		{
		}
	
		public bool IsValid() { return !m_error.IsValid(); }
	
		public QDBusError Error() { return m_error; }
	
		public T Value() {
			return m_data;
		}
	
		private QDBusError m_error;
		private T m_data;
	}
}
