namespace Qyoto {

	using System;

	public class QDBusVariant : QVariant {

		public QDBusVariant() : base() { }
		public QDBusVariant(QVariant variant) : base(variant) { }

		static public QDBusVariant FromValue<T>(object value) {
			return new QDBusVariant(QVariant.FromValue<T>(value));
		}

		public void SetVariant(QVariant variant) {
		}

		QVariant Variant() { return this; }
	}
}
