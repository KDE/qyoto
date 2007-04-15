namespace Qyoto {

	using System;

	public partial class QRegion : Object, IDisposable {
		public static implicit operator QRegion(QRect arg) {
Console.WriteLine("In operator QRegion arg: {0}", arg);
			return new QRegion(arg);
		}
	}
}
