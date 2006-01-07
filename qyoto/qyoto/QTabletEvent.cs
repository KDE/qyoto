//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QTabletEvent : QInputEvent, IDisposable {
 		protected QTabletEvent(Type dummy) : base((Type) null) {}
		interface IQTabletEventProxy {
		}

		protected void CreateQTabletEventProxy() {
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

		enum TabletDevice {
			NoDevice = 0,
			Puck = 1,
			Stylus = 2,
			Airbrush = 3,
			FourDMouse = 4,
			XFreeEraser = 5,
		}
		enum E_PointerType {
			UnknownPointer = 0,
			Pen = 1,
			Cursor = 2,
			Eraser = 3,
		}
		// QTabletEvent* QTabletEvent(QEvent::Type arg1,const QPoint& arg2,const QPoint& arg3,const QPointF& arg4,int arg5,int arg6,qreal arg7,int arg8,int arg9,qreal arg10,qreal arg11,int arg12,Qt::KeyboardModifiers arg13,qint64 arg14); >>>> NOT CONVERTED
		public QPoint Pos() {
			return ProxyQTabletEvent().Pos();
		}
		public QPoint GlobalPos() {
			return ProxyQTabletEvent().GlobalPos();
		}
		public QPointF HiResGlobalPos() {
			return ProxyQTabletEvent().HiResGlobalPos();
		}
		public int X() {
			return ProxyQTabletEvent().X();
		}
		public int Y() {
			return ProxyQTabletEvent().Y();
		}
		public int GlobalX() {
			return ProxyQTabletEvent().GlobalX();
		}
		public int GlobalY() {
			return ProxyQTabletEvent().GlobalY();
		}
		public double HiResGlobalX() {
			return ProxyQTabletEvent().HiResGlobalX();
		}
		public double HiResGlobalY() {
			return ProxyQTabletEvent().HiResGlobalY();
		}
		public int Device() {
			return ProxyQTabletEvent().Device();
		}
		public int PointerType() {
			return ProxyQTabletEvent().PointerType();
		}
		// qint64 uniqueId(); >>>> NOT CONVERTED
		public double Pressure() {
			return ProxyQTabletEvent().Pressure();
		}
		public int Z() {
			return ProxyQTabletEvent().Z();
		}
		public double TangentialPressure() {
			return ProxyQTabletEvent().TangentialPressure();
		}
		public double Rotation() {
			return ProxyQTabletEvent().Rotation();
		}
		public int XTilt() {
			return ProxyQTabletEvent().XTilt();
		}
		public int YTilt() {
			return ProxyQTabletEvent().YTilt();
		}
		~QTabletEvent() {
			ProxyQTabletEvent().Dispose();
		}
		public new void Dispose() {
			ProxyQTabletEvent().Dispose();
		}
	}
}