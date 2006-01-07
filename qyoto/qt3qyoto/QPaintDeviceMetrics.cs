//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	[SmokeClass("QPaintDeviceMetrics")]
	public class QPaintDeviceMetrics : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QPaintDeviceMetrics(Type dummy) {}
		interface IQPaintDeviceMetricsProxy {
		}

		protected void CreateQPaintDeviceMetricsProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPaintDeviceMetrics), this);
			_interceptor = (QPaintDeviceMetrics) realProxy.GetTransparentProxy();
		}
		private QPaintDeviceMetrics ProxyQPaintDeviceMetrics() {
			return (QPaintDeviceMetrics) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPaintDeviceMetrics() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPaintDeviceMetricsProxy), null);
			_staticInterceptor = (IQPaintDeviceMetricsProxy) realProxy.GetTransparentProxy();
		}
		private static IQPaintDeviceMetricsProxy StaticQPaintDeviceMetrics() {
			return (IQPaintDeviceMetricsProxy) _staticInterceptor;
		}

		public const int PdmWidth = 1;
		public const int PdmHeight = 2;
		public const int PdmWidthMM = 3;
		public const int PdmHeightMM = 4;
		public const int PdmNumColors = 5;
		public const int PdmDepth = 6;
		public const int PdmDpiX = 7;
		public const int PdmDpiY = 8;
		public const int PdmPhysicalDpiX = 9;
		public const int PdmPhysicalDpiY = 10;

		public QPaintDeviceMetrics(IQPaintDevice arg1) : this((Type) null) {
			CreateQPaintDeviceMetricsProxy();
			NewQPaintDeviceMetrics(arg1);
		}
		[SmokeMethod("QPaintDeviceMetrics(const QPaintDevice*)")]
		private void NewQPaintDeviceMetrics(IQPaintDevice arg1) {
			ProxyQPaintDeviceMetrics().NewQPaintDeviceMetrics(arg1);
		}
		[SmokeMethod("width() const")]
		public int Width() {
			return ProxyQPaintDeviceMetrics().Width();
		}
		[SmokeMethod("height() const")]
		public int Height() {
			return ProxyQPaintDeviceMetrics().Height();
		}
		[SmokeMethod("widthMM() const")]
		public int WidthMM() {
			return ProxyQPaintDeviceMetrics().WidthMM();
		}
		[SmokeMethod("heightMM() const")]
		public int HeightMM() {
			return ProxyQPaintDeviceMetrics().HeightMM();
		}
		[SmokeMethod("logicalDpiX() const")]
		public int LogicalDpiX() {
			return ProxyQPaintDeviceMetrics().LogicalDpiX();
		}
		[SmokeMethod("logicalDpiY() const")]
		public int LogicalDpiY() {
			return ProxyQPaintDeviceMetrics().LogicalDpiY();
		}
		[SmokeMethod("physicalDpiX() const")]
		public int PhysicalDpiX() {
			return ProxyQPaintDeviceMetrics().PhysicalDpiX();
		}
		[SmokeMethod("physicalDpiY() const")]
		public int PhysicalDpiY() {
			return ProxyQPaintDeviceMetrics().PhysicalDpiY();
		}
		[SmokeMethod("numColors() const")]
		public int NumColors() {
			return ProxyQPaintDeviceMetrics().NumColors();
		}
		[SmokeMethod("depth() const")]
		public int Depth() {
			return ProxyQPaintDeviceMetrics().Depth();
		}
		~QPaintDeviceMetrics() {
			DisposeQPaintDeviceMetrics();
		}
		public void Dispose() {
			DisposeQPaintDeviceMetrics();
		}
		private void DisposeQPaintDeviceMetrics() {
			ProxyQPaintDeviceMetrics().DisposeQPaintDeviceMetrics();
		}
	}
}