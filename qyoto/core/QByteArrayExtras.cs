namespace Qyoto {
	using System;
	public partial class QByteArray : Object, IDisposable {
		public static implicit operator QByteArray(string arg) {
			return new QByteArray(arg);
		}
	}
}
