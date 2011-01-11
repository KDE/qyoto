namespace Qyoto {

	using System;

	public partial class QColor : Object, IDisposable {
		public static implicit operator QColor(Qt.GlobalColor arg) {
			return new QColor(arg);
		}
	}
}
