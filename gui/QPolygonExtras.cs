namespace Qyoto {

	using System;

	public partial class QPolygon : Object, IDisposable {
		public static implicit operator QPolygon(QPolygonF arg) {
			return new QPolygon(arg);
		}
	}
}
