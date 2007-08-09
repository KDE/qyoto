namespace Qyoto {

	using System;

	public partial class QLineF : Object, IDisposable {
		public static implicit operator QLineF(QLine arg) {
			return new QLineF(arg);
		}
	}
}
