namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;
	using System.Collections.Generic; 

	public class QDBusReply<T> {
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		private static extern void qyoto_qdbus_reply_fill(IntPtr msg, IntPtr error, IntPtr variant);
		
		public QDBusReply(QDBusMessage reply) {
			m_error = new QDBusError(reply);
			QVariant variant = QVariant.FromValue<T>(default(T));
			qyoto_qdbus_reply_fill((IntPtr) GCHandle.Alloc(reply), (IntPtr) GCHandle.Alloc(m_error),
				(IntPtr) GCHandle.Alloc(variant));
			if (!m_error.IsValid())
				m_data = variant.Value<T>();
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
