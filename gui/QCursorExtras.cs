namespace Qyoto {

	using System;

	public partial class QCursor : Object, IDisposable {
		public static implicit operator QCursor(QPixmap arg) {
			return new QCursor(arg);
		}
	}
}
