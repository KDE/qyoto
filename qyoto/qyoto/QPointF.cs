//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QPointF")]
	public class QPointF : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QPointF(Type dummy) {}
		interface IQPointFProxy {
			QPointF op_mult(QPointF lhs, double c);
			QPointF op_div(QPointF lhs, double c);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPointF), this);
			_interceptor = (QPointF) realProxy.GetTransparentProxy();
		}
		private QPointF ProxyQPointF() {
			return (QPointF) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPointF() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPointFProxy), null);
			_staticInterceptor = (IQPointFProxy) realProxy.GetTransparentProxy();
		}
		private static IQPointFProxy StaticQPointF() {
			return (IQPointFProxy) _staticInterceptor;
		}

		public QPointF() : this((Type) null) {
			CreateProxy();
			NewQPointF();
		}
		[SmokeMethod("QPointF()")]
		private void NewQPointF() {
			ProxyQPointF().NewQPointF();
		}
		public QPointF(QPoint p) : this((Type) null) {
			CreateProxy();
			NewQPointF(p);
		}
		[SmokeMethod("QPointF(const QPoint&)")]
		private void NewQPointF(QPoint p) {
			ProxyQPointF().NewQPointF(p);
		}
		public QPointF(double xpos, double ypos) : this((Type) null) {
			CreateProxy();
			NewQPointF(xpos,ypos);
		}
		[SmokeMethod("QPointF(qreal, qreal)")]
		private void NewQPointF(double xpos, double ypos) {
			ProxyQPointF().NewQPointF(xpos,ypos);
		}
		[SmokeMethod("isNull() const")]
		public bool IsNull() {
			return ProxyQPointF().IsNull();
		}
		[SmokeMethod("x() const")]
		public double X() {
			return ProxyQPointF().X();
		}
		[SmokeMethod("y() const")]
		public double Y() {
			return ProxyQPointF().Y();
		}
		[SmokeMethod("setX(qreal)")]
		public void SetX(double x) {
			ProxyQPointF().SetX(x);
		}
		[SmokeMethod("setY(qreal)")]
		public void SetY(double y) {
			ProxyQPointF().SetY(y);
		}
		// qreal& rx(); >>>> NOT CONVERTED
		// qreal& ry(); >>>> NOT CONVERTED
		[SmokeMethod("operator*=(qreal)")]
		public static QPointF operator*(QPointF lhs, double c) {
			return StaticQPointF().op_mult(lhs,c);
		}
		[SmokeMethod("operator/=(qreal)")]
		public static QPointF operator/(QPointF lhs, double c) {
			return StaticQPointF().op_div(lhs,c);
		}
		[SmokeMethod("toPoint() const")]
		public QPoint ToPoint() {
			return ProxyQPointF().ToPoint();
		}
		~QPointF() {
			DisposeQPointF();
		}
		public void Dispose() {
			DisposeQPointF();
		}
		private void DisposeQPointF() {
			ProxyQPointF().DisposeQPointF();
		}
	}
}
