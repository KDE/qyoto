namespace Qyoto {

	using System;

	public partial class QPolygonF : Object, IDisposable {
		public static implicit operator QPolygonF(QPolygon arg) {
			return new QPolygonF(arg);
		}
		public static implicit operator QPolygonF(QRectF arg) {
			return new QPolygonF(arg);
		}
	}
}
