//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QPainterPathStroker : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QPainterPathStroker(Type dummy) {}
		interface IQPainterPathStrokerProxy {
		}

		protected void CreateQPainterPathStrokerProxy() {
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
			CreateQPainterPathStrokerProxy();
			NewQPainterPathStroker();
		}
		private void NewQPainterPathStroker() {
			ProxyQPainterPathStroker().NewQPainterPathStroker();
		}
		public void SetWidth(double width) {
			ProxyQPainterPathStroker().SetWidth(width);
		}
		public double Width() {
			return ProxyQPainterPathStroker().Width();
		}
		public void SetCapStyle(int style) {
			ProxyQPainterPathStroker().SetCapStyle(style);
		}
		public int CapStyle() {
			return ProxyQPainterPathStroker().CapStyle();
		}
		public void SetJoinStyle(int style) {
			ProxyQPainterPathStroker().SetJoinStyle(style);
		}
		public int JoinStyle() {
			return ProxyQPainterPathStroker().JoinStyle();
		}
		public void SetMiterLimit(double length) {
			ProxyQPainterPathStroker().SetMiterLimit(length);
		}
		public double MiterLimit() {
			return ProxyQPainterPathStroker().MiterLimit();
		}
		public void SetCurveThreshold(double threshold) {
			ProxyQPainterPathStroker().SetCurveThreshold(threshold);
		}
		public double CurveThreshold() {
			return ProxyQPainterPathStroker().CurveThreshold();
		}
		public void SetDashPattern(int arg1) {
			ProxyQPainterPathStroker().SetDashPattern(arg1);
		}
		// void setDashPattern(const QVector<qreal>& arg1); >>>> NOT CONVERTED
		// QVector<qreal> dashPattern(); >>>> NOT CONVERTED
		public QPainterPath CreateStroke(QPainterPath path) {
			return ProxyQPainterPathStroker().CreateStroke(path);
		}
		~QPainterPathStroker() {
			ProxyQPainterPathStroker().Dispose();
		}
		public void Dispose() {
			ProxyQPainterPathStroker().Dispose();
		}
	}
}