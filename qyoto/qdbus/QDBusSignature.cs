namespace Qyoto {

	using System;

	public class QDBusSignature {
		private string text;
		public QDBusSignature() : this((string) null) {}
		public QDBusSignature(string text) {
			this.text = text;
		}
		public string ToString() {
			return text;
		}
	}
}
