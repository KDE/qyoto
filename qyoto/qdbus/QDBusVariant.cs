namespace Qyoto {

	using System;

	public class QDBusVariant : QVariant {

		public QDBusVariant() : base() { }
		public QDBusVariant(QVariant variant) : base(variant) { }

		public void SetVariant(QVariant variant) {}

		QVariant Variant() { return this; }
	}
}
