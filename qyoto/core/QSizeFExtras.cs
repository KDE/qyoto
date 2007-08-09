namespace Qyoto {

	using System;

	public partial class QSizeF : Object, IDisposable {
		public static implicit operator QSizeF(QSize arg) {
			return new QSizeF(arg);
		}
	}
}
