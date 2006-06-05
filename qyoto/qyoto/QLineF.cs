//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QLineF")]
	public class QLineF : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QLineF(Type dummy) {}
		interface IQLineFProxy {
			bool op_equals(QLineF lhs, QLineF d);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QLineF), this);
			_interceptor = (QLineF) realProxy.GetTransparentProxy();
		}
		private QLineF ProxyQLineF() {
			return (QLineF) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QLineF() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQLineFProxy), null);
			_staticInterceptor = (IQLineFProxy) realProxy.GetTransparentProxy();
		}
		private static IQLineFProxy StaticQLineF() {
			return (IQLineFProxy) _staticInterceptor;
		}

		public enum IntersectType {
			NoIntersection = 0,
			BoundedIntersection = 1,
			UnboundedIntersection = 2,
		}
		public QLineF() : this((Type) null) {
			CreateProxy();
			NewQLineF();
		}
		[SmokeMethod("QLineF()")]
		private void NewQLineF() {
			ProxyQLineF().NewQLineF();
		}
		public QLineF(QPointF pt1, QPointF pt2) : this((Type) null) {
			CreateProxy();
			NewQLineF(pt1,pt2);
		}
		[SmokeMethod("QLineF(const QPointF&, const QPointF&)")]
		private void NewQLineF(QPointF pt1, QPointF pt2) {
			ProxyQLineF().NewQLineF(pt1,pt2);
		}
		public QLineF(double x1, double y1, double x2, double y2) : this((Type) null) {
			CreateProxy();
			NewQLineF(x1,y1,x2,y2);
		}
		[SmokeMethod("QLineF(qreal, qreal, qreal, qreal)")]
		private void NewQLineF(double x1, double y1, double x2, double y2) {
			ProxyQLineF().NewQLineF(x1,y1,x2,y2);
		}
		public QLineF(QLine line) : this((Type) null) {
			CreateProxy();
			NewQLineF(line);
		}
		[SmokeMethod("QLineF(const QLine&)")]
		private void NewQLineF(QLine line) {
			ProxyQLineF().NewQLineF(line);
		}
		[SmokeMethod("isNull() const")]
		public bool IsNull() {
			return ProxyQLineF().IsNull();
		}
		[SmokeMethod("p1() const")]
		public QPointF P1() {
			return ProxyQLineF().P1();
		}
		[SmokeMethod("p2() const")]
		public QPointF P2() {
			return ProxyQLineF().P2();
		}
		[SmokeMethod("x1() const")]
		public double X1() {
			return ProxyQLineF().X1();
		}
		[SmokeMethod("y1() const")]
		public double Y1() {
			return ProxyQLineF().Y1();
		}
		[SmokeMethod("x2() const")]
		public double X2() {
			return ProxyQLineF().X2();
		}
		[SmokeMethod("y2() const")]
		public double Y2() {
			return ProxyQLineF().Y2();
		}
		[SmokeMethod("dx() const")]
		public double Dx() {
			return ProxyQLineF().Dx();
		}
		[SmokeMethod("dy() const")]
		public double Dy() {
			return ProxyQLineF().Dy();
		}
		[SmokeMethod("length() const")]
		public double Length() {
			return ProxyQLineF().Length();
		}
		[SmokeMethod("setLength(qreal)")]
		public void SetLength(double len) {
			ProxyQLineF().SetLength(len);
		}
		[SmokeMethod("unitVector() const")]
		public QLineF UnitVector() {
			return ProxyQLineF().UnitVector();
		}
		[SmokeMethod("normalVector() const")]
		public QLineF NormalVector() {
			return ProxyQLineF().NormalVector();
		}
		[SmokeMethod("intersect(const QLineF&, QPointF*) const")]
		public QLineF.IntersectType Intersect(QLineF l, QPointF intersectionPoint) {
			return ProxyQLineF().Intersect(l,intersectionPoint);
		}
		[SmokeMethod("angle(const QLineF&) const")]
		public double Angle(QLineF l) {
			return ProxyQLineF().Angle(l);
		}
		[SmokeMethod("pointAt(qreal) const")]
		public QPointF PointAt(double t) {
			return ProxyQLineF().PointAt(t);
		}
		[SmokeMethod("translate(const QPointF&)")]
		public void Translate(QPointF p) {
			ProxyQLineF().Translate(p);
		}
		[SmokeMethod("translate(qreal, qreal)")]
		public void Translate(double dx, double dy) {
			ProxyQLineF().Translate(dx,dy);
		}
		[SmokeMethod("operator==(const QLineF&) const")]
		public static bool operator==(QLineF lhs, QLineF d) {
			return StaticQLineF().op_equals(lhs,d);
		}
		public static bool operator!=(QLineF lhs, QLineF d) {
			return !StaticQLineF().op_equals(lhs,d);
		}
		public override bool Equals(object o) {
			if (!(o is QLineF)) { return false; }
			return this == (QLineF) o;
		}
		public override int GetHashCode() {
			return ProxyQLineF().GetHashCode();
		}
		[SmokeMethod("toLine() const")]
		public QLine ToLine() {
			return ProxyQLineF().ToLine();
		}
		~QLineF() {
			DisposeQLineF();
		}
		public void Dispose() {
			DisposeQLineF();
		}
		private void DisposeQLineF() {
			ProxyQLineF().DisposeQLineF();
		}
	}
}
