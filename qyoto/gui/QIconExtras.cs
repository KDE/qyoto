namespace Qyoto {

	using System;

	public partial class QIcon : Object, IDisposable {
		public static implicit operator QIcon(QPixmap arg) {
			return new QIcon(arg);
		}
	}
}
