//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QTabletEvent")]
	public class QTabletEvent : QInputEvent, IDisposable {
 		protected QTabletEvent(Type dummy) : base((Type) null) {}
		interface IQTabletEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTabletEvent), this);
			_interceptor = (QTabletEvent) realProxy.GetTransparentProxy();
		}
		private QTabletEvent ProxyQTabletEvent() {
			return (QTabletEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTabletEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTabletEventProxy), null);
			_staticInterceptor = (IQTabletEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQTabletEventProxy StaticQTabletEvent() {
			return (IQTabletEventProxy) _staticInterceptor;
		}

		public enum TabletDevice {
			NoDevice = 0,
			Puck = 1,
			Stylus = 2,
			Airbrush = 3,
			FourDMouse = 4,
			XFreeEraser = 5,
			RotationStylus = 6,
		}
		public enum PointerType {
			UnknownPointer = 0,
			Pen = 1,
			Cursor = 2,
			Eraser = 3,
		}
		// QTabletEvent* QTabletEvent(QEvent::Type arg1,const QPoint& arg2,const QPoint& arg3,const QPointF& arg4,int arg5,int arg6,qreal arg7,int arg8,int arg9,qreal arg10,qreal arg11,int arg12,Qt::KeyboardModifiers arg13,qint64 arg14); >>>> NOT CONVERTED
		[SmokeMethod("pos() const")]
		public QPoint Pos() {
			return ProxyQTabletEvent().Pos();
		}
		[SmokeMethod("globalPos() const")]
		public QPoint GlobalPos() {
			return ProxyQTabletEvent().GlobalPos();
		}
		[SmokeMethod("hiResGlobalPos() const")]
		public QPointF HiResGlobalPos() {
			return ProxyQTabletEvent().HiResGlobalPos();
		}
		[SmokeMethod("x() const")]
		public int X() {
			return ProxyQTabletEvent().X();
		}
		[SmokeMethod("y() const")]
		public int Y() {
			return ProxyQTabletEvent().Y();
		}
		[SmokeMethod("globalX() const")]
		public int GlobalX() {
			return ProxyQTabletEvent().GlobalX();
		}
		[SmokeMethod("globalY() const")]
		public int GlobalY() {
			return ProxyQTabletEvent().GlobalY();
		}
		[SmokeMethod("hiResGlobalX() const")]
		public double HiResGlobalX() {
			return ProxyQTabletEvent().HiResGlobalX();
		}
		[SmokeMethod("hiResGlobalY() const")]
		public double HiResGlobalY() {
			return ProxyQTabletEvent().HiResGlobalY();
		}
		[SmokeMethod("device() const")]
		public QTabletEvent.TabletDevice Device() {
			return ProxyQTabletEvent().Device();
		}
		[SmokeMethod("pointerType() const")]
		public QTabletEvent.PointerType pointerType() {
			return ProxyQTabletEvent().pointerType();
		}
		// qint64 uniqueId(); >>>> NOT CONVERTED
		[SmokeMethod("pressure() const")]
		public double Pressure() {
			return ProxyQTabletEvent().Pressure();
		}
		[SmokeMethod("z() const")]
		public int Z() {
			return ProxyQTabletEvent().Z();
		}
		[SmokeMethod("tangentialPressure() const")]
		public double TangentialPressure() {
			return ProxyQTabletEvent().TangentialPressure();
		}
		[SmokeMethod("rotation() const")]
		public double Rotation() {
			return ProxyQTabletEvent().Rotation();
		}
		[SmokeMethod("xTilt() const")]
		public int XTilt() {
			return ProxyQTabletEvent().XTilt();
		}
		[SmokeMethod("yTilt() const")]
		public int YTilt() {
			return ProxyQTabletEvent().YTilt();
		}
		~QTabletEvent() {
			DisposeQTabletEvent();
		}
		public new void Dispose() {
			DisposeQTabletEvent();
		}
		[SmokeMethod("~QTabletEvent()")]
		private void DisposeQTabletEvent() {
			ProxyQTabletEvent().DisposeQTabletEvent();
		}
	}
}