namespace Qyoto {

	using System;

	public partial class QPointF : Object, IDisposable {
		public static implicit operator QPointF(QPoint arg) {
			return new QPointF(arg);
		}
	}
}
