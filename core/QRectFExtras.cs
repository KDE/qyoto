namespace Qyoto {

	using System;

	public partial class QRectF : Object, IDisposable {
		public static implicit operator QRectF(QRect arg) {
			return new QRectF(arg);
		}
	}
}
