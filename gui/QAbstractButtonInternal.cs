namespace Qyoto{

	using System;

	[SmokeClass("QAbstractButton")]
	internal class QAbstractButtonInternal : QAbstractButton {
		protected QAbstractButtonInternal(Type dummy) : base((Type) null) {}
		
		protected override void PaintEvent (QPaintEvent e) {}
	}
}
