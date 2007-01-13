namespace Qyoto {

	using System;
	using System.Collections.Generic; 

	public class QDBusReply<T> {
		public QDBusReply(QDBusMessage reply) {
			m_error = new QDBusError(reply);
			if (m_error.IsValid()) {
				return;
			}

			if (reply.Arguments().Count >= 1) {
				m_data = ((QVariant) reply.Arguments()[0]).Value<T>();
				return;
			}

			m_error = new QDBusError(	QDBusError.ErrorType.InvalidSignature, 
										"Unexpected reply signature" );
		}
	
		public QDBusReply(QDBusError dbusError) {
			m_error = dbusError;
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
