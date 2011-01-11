namespace Qyoto {

	using System;

	public partial class QPen : Object, IDisposable {
		public static implicit operator QPen(QColor arg) {
			return new QPen(arg);
		}
	}
}
