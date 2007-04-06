namespace Qyoto{

	using System;

	public class QAbstractButtonHelper : QAbstractButton {
		protected QAbstractButtonHelper(Type dummy) : base((Type) null) {}
		
		protected override void PaintEvent (QPaintEvent e) {}
	}
}
