//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	[SmokeClass("QPainterPathStroker")]
	public class QPainterPathStroker : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QPainterPathStroker(Type dummy) {}
		interface IQPainterPathStrokerProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPainterPathStroker), this);
			_interceptor = (QPainterPathStroker) realProxy.GetTransparentProxy();
		}
		private QPainterPathStroker ProxyQPainterPathStroker() {
			return (QPainterPathStroker) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPainterPathStroker() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPainterPathStrokerProxy), null);
			_staticInterceptor = (IQPainterPathStrokerProxy) realProxy.GetTransparentProxy();
		}
		private static IQPainterPathStrokerProxy StaticQPainterPathStroker() {
			return (IQPainterPathStrokerProxy) _staticInterceptor;
		}

		public QPainterPathStroker() : this((Type) null) {
			CreateProxy();
			NewQPainterPathStroker();
		}
		[SmokeMethod("QPainterPathStroker", "()", "")]
		private void NewQPainterPathStroker() {
			ProxyQPainterPathStroker().NewQPainterPathStroker();
		}
		[SmokeMethod("setWidth", "(qreal)", "$")]
		public void SetWidth(double width) {
			ProxyQPainterPathStroker().SetWidth(width);
		}
		[SmokeMethod("width", "() const", "")]
		public double Width() {
			return ProxyQPainterPathStroker().Width();
		}
		[SmokeMethod("setCapStyle", "(Qt::PenCapStyle)", "$")]
		public void SetCapStyle(Qt.PenCapStyle style) {
			ProxyQPainterPathStroker().SetCapStyle(style);
		}
		[SmokeMethod("capStyle", "() const", "")]
		public Qt.PenCapStyle CapStyle() {
			return ProxyQPainterPathStroker().CapStyle();
		}
		[SmokeMethod("setJoinStyle", "(Qt::PenJoinStyle)", "$")]
		public void SetJoinStyle(Qt.PenJoinStyle style) {
			ProxyQPainterPathStroker().SetJoinStyle(style);
		}
		[SmokeMethod("joinStyle", "() const", "")]
		public Qt.PenJoinStyle JoinStyle() {
			return ProxyQPainterPathStroker().JoinStyle();
		}
		[SmokeMethod("setMiterLimit", "(qreal)", "$")]
		public void SetMiterLimit(double length) {
			ProxyQPainterPathStroker().SetMiterLimit(length);
		}
		[SmokeMethod("miterLimit", "() const", "")]
		public double MiterLimit() {
			return ProxyQPainterPathStroker().MiterLimit();
		}
		[SmokeMethod("setCurveThreshold", "(qreal)", "$")]
		public void SetCurveThreshold(double threshold) {
			ProxyQPainterPathStroker().SetCurveThreshold(threshold);
		}
		[SmokeMethod("curveThreshold", "() const", "")]
		public double CurveThreshold() {
			return ProxyQPainterPathStroker().CurveThreshold();
		}
		[SmokeMethod("setDashPattern", "(Qt::PenStyle)", "$")]
		public void SetDashPattern(Qt.PenStyle arg1) {
			ProxyQPainterPathStroker().SetDashPattern(arg1);
		}
		[SmokeMethod("setDashPattern", "(const QVector<qreal>&)", "?")]
		public void SetDashPattern(List<double> dashPattern) {
			ProxyQPainterPathStroker().SetDashPattern(dashPattern);
		}
		[SmokeMethod("dashPattern", "() const", "")]
		public List<double> DashPattern() {
			return ProxyQPainterPathStroker().DashPattern();
		}
		[SmokeMethod("createStroke", "(const QPainterPath&) const", "#")]
		public QPainterPath CreateStroke(QPainterPath path) {
			return ProxyQPainterPathStroker().CreateStroke(path);
		}
		~QPainterPathStroker() {
			DisposeQPainterPathStroker();
		}
		public void Dispose() {
			DisposeQPainterPathStroker();
		}
		[SmokeMethod("~QPainterPathStroker", "()", "")]
		private void DisposeQPainterPathStroker() {
			ProxyQPainterPathStroker().DisposeQPainterPathStroker();
		}
	}
}
