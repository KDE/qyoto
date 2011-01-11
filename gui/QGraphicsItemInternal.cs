namespace Qyoto {
	using System;

	[SmokeClass("QGraphicsItem")]
	internal class QGraphicsItemInternal : QGraphicsItem {
		protected QGraphicsItemInternal(Type dummy) : base((Type) null) {}
		public override QRectF BoundingRect () {
			return (QRectF) interceptor.Invoke("boundingRect", "boundingRect() const", typeof(QRectF));
		}
		
		public override void Paint (QPainter painter, QStyleOptionGraphicsItem option, QWidget widget) {
			interceptor.Invoke("paint", "paint(QPainter*, const QStyleOptionGraphicsItem*, QWidget*)", typeof(void), typeof(QPainter), painter, typeof(QStyleOptionGraphicsItem), option, typeof(QWidget), widget);
		}
	}
}
