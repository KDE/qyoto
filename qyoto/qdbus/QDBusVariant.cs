namespace Qyoto {

	using System;

	public class QDBusVariant : QVariant {
		protected QDBusVariant(System.Type dummy) : base((System.Type) null) {}
		public QDBusVariant() : base() { }
		public QDBusVariant(QVariant variant) : base(variant) { }

		static public new QDBusVariant FromValue<T>(object value) {
			return new QDBusVariant(QVariant.FromValue<T>(value));
		}

		public void SetVariant(QVariant variant) {
		}

		public QVariant Variant() { return this; }
	}
}
