namespace Qyoto {
	using System.IO;
	
	public abstract partial class QIODevice : QObject {
		public static implicit operator QIODevice(Stream stream) {
			return new StreamWrapper(stream);
		}
	}
}
