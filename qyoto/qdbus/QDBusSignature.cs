namespace Qyoto {

	using System;

	public class QDBusSignature {
		private string text;
		public QDBusSignature() : this((string) null) {}
		public QDBusSignature(string text) {
			this.text = text;
		}
		public new string ToString() {
			return text;
		}
	}
}
