namespace Qyoto {

	using System;

	public partial class QRegion : Object, IDisposable {
		public static implicit operator QRegion(QRect arg) {
			return new QRegion(arg);
		}
	}
}
