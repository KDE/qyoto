//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QGraphicsSceneHoverEvent")]
	public class QGraphicsSceneHoverEvent : QGraphicsSceneEvent, IDisposable {
 		protected QGraphicsSceneHoverEvent(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QGraphicsSceneHoverEvent), this);
		}
		public QGraphicsSceneHoverEvent(QEvent.TypeOf type) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsSceneHoverEvent$", "QGraphicsSceneHoverEvent(QEvent::Type)", typeof(void), typeof(QEvent.TypeOf), type);
		}
		public QGraphicsSceneHoverEvent() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsSceneHoverEvent", "QGraphicsSceneHoverEvent()", typeof(void));
		}
		public QPointF Pos() {
			return (QPointF) interceptor.Invoke("pos", "pos() const", typeof(QPointF));
		}
		public void SetPos(QPointF pos) {
			interceptor.Invoke("setPos#", "setPos(const QPointF&)", typeof(void), typeof(QPointF), pos);
		}
		public QPointF ScenePos() {
			return (QPointF) interceptor.Invoke("scenePos", "scenePos() const", typeof(QPointF));
		}
		public void SetScenePos(QPointF pos) {
			interceptor.Invoke("setScenePos#", "setScenePos(const QPointF&)", typeof(void), typeof(QPointF), pos);
		}
		public QPoint ScreenPos() {
			return (QPoint) interceptor.Invoke("screenPos", "screenPos() const", typeof(QPoint));
		}
		public void SetScreenPos(QPoint pos) {
			interceptor.Invoke("setScreenPos#", "setScreenPos(const QPoint&)", typeof(void), typeof(QPoint), pos);
		}
		public QPointF LastPos() {
			return (QPointF) interceptor.Invoke("lastPos", "lastPos() const", typeof(QPointF));
		}
		public void SetLastPos(QPointF pos) {
			interceptor.Invoke("setLastPos#", "setLastPos(const QPointF&)", typeof(void), typeof(QPointF), pos);
		}
		public QPointF LastScenePos() {
			return (QPointF) interceptor.Invoke("lastScenePos", "lastScenePos() const", typeof(QPointF));
		}
		public void SetLastScenePos(QPointF pos) {
			interceptor.Invoke("setLastScenePos#", "setLastScenePos(const QPointF&)", typeof(void), typeof(QPointF), pos);
		}
		public QPoint LastScreenPos() {
			return (QPoint) interceptor.Invoke("lastScreenPos", "lastScreenPos() const", typeof(QPoint));
		}
		public void SetLastScreenPos(QPoint pos) {
			interceptor.Invoke("setLastScreenPos#", "setLastScreenPos(const QPoint&)", typeof(void), typeof(QPoint), pos);
		}
		public uint Modifiers() {
			return (uint) interceptor.Invoke("modifiers", "modifiers() const", typeof(uint));
		}
		public void SetModifiers(uint modifiers) {
			interceptor.Invoke("setModifiers$", "setModifiers(Qt::KeyboardModifiers)", typeof(void), typeof(uint), modifiers);
		}
		~QGraphicsSceneHoverEvent() {
			interceptor.Invoke("~QGraphicsSceneHoverEvent", "~QGraphicsSceneHoverEvent()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QGraphicsSceneHoverEvent", "~QGraphicsSceneHoverEvent()", typeof(void));
		}
	}
}
