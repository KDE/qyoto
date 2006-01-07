//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public interface IQPaintDevice {
			int DevType();
			bool IsExtDev();
			bool PaintingActive();
			void SetResolution(int arg1);
			int Resolution();
	}

	[SmokeClass("QPaintDevice")]
	public class QPaintDevice : MarshalByRefObject, IQPaintDevice, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QPaintDevice(Type dummy) {}
		interface IQPaintDeviceProxy {
		}

		protected void CreateQPaintDeviceProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPaintDevice), this);
			_interceptor = (QPaintDevice) realProxy.GetTransparentProxy();
		}
		private QPaintDevice ProxyQPaintDevice() {
			return (QPaintDevice) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPaintDevice() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPaintDeviceProxy), null);
			_staticInterceptor = (IQPaintDeviceProxy) realProxy.GetTransparentProxy();
		}
		private static IQPaintDeviceProxy StaticQPaintDevice() {
			return (IQPaintDeviceProxy) _staticInterceptor;
		}

		public enum PDevCmd {
			PdcNOP = 0,
			PdcDrawPoint = 1,
			PdcDrawFirst = PdcDrawPoint,
			PdcMoveTo = 2,
			PdcLineTo = 3,
			PdcDrawLine = 4,
			PdcDrawRect = 5,
			PdcDrawRoundRect = 6,
			PdcDrawEllipse = 7,
			PdcDrawArc = 8,
			PdcDrawPie = 9,
			PdcDrawChord = 10,
			PdcDrawLineSegments = 11,
			PdcDrawPolyline = 12,
			PdcDrawPolygon = 13,
			PdcDrawCubicBezier = 14,
			PdcDrawText = 15,
			PdcDrawTextFormatted = 16,
			PdcDrawPixmap = 17,
			PdcDrawImage = 18,
			PdcDrawText2 = 19,
			PdcDrawText2Formatted = 20,
			PdcDrawTextItem = 21,
			PdcDrawLast = PdcDrawTextItem,
			PdcBegin = 30,
			PdcEnd = 31,
			PdcSave = 32,
			PdcRestore = 33,
			PdcSetdev = 34,
			PdcSetBkColor = 40,
			PdcSetBkMode = 41,
			PdcSetROP = 42,
			PdcSetBrushOrigin = 43,
			PdcSetFont = 45,
			PdcSetPen = 46,
			PdcSetBrush = 47,
			PdcSetTabStops = 48,
			PdcSetTabArray = 49,
			PdcSetUnit = 50,
			PdcSetVXform = 51,
			PdcSetWindow = 52,
			PdcSetViewport = 53,
			PdcSetWXform = 54,
			PdcSetWMatrix = 55,
			PdcSaveWMatrix = 56,
			PdcRestoreWMatrix = 57,
			PdcSetClip = 60,
			PdcSetClipRegion = 61,
			PdcReservedStart = 0,
			PdcReservedStop = 199,
		}
		[SmokeMethod("devType() const")]
		public int DevType() {
			return ProxyQPaintDevice().DevType();
		}
		[SmokeMethod("isExtDev() const")]
		public bool IsExtDev() {
			return ProxyQPaintDevice().IsExtDev();
		}
		[SmokeMethod("paintingActive() const")]
		public bool PaintingActive() {
			return ProxyQPaintDevice().PaintingActive();
		}
		[SmokeMethod("setResolution(int)")]
		public virtual void SetResolution(int arg1) {
			ProxyQPaintDevice().SetResolution(arg1);
		}
		[SmokeMethod("resolution() const")]
		public virtual int Resolution() {
			return ProxyQPaintDevice().Resolution();
		}
		public QPaintDevice(uint devflags) : this((Type) null) {
			CreateQPaintDeviceProxy();
			NewQPaintDevice(devflags);
		}
		[SmokeMethod("QPaintDevice(uint)")]
		private void NewQPaintDevice(uint devflags) {
			ProxyQPaintDevice().NewQPaintDevice(devflags);
		}
		// bool cmd(int arg1,QPainter* arg2,QPDevCmdParam* arg3); >>>> NOT CONVERTED
		[SmokeMethod("metric(int) const")]
		protected virtual int Metric(int arg1) {
			return ProxyQPaintDevice().Metric(arg1);
		}
		[SmokeMethod("fontMet(QFont*, int, const char*, int) const")]
		protected virtual int FontMet(QFont arg1, int arg2, string arg3, int arg4) {
			return ProxyQPaintDevice().FontMet(arg1,arg2,arg3,arg4);
		}
		[SmokeMethod("fontMet(QFont*, int, const char*) const")]
		protected virtual int FontMet(QFont arg1, int arg2, string arg3) {
			return ProxyQPaintDevice().FontMet(arg1,arg2,arg3);
		}
		[SmokeMethod("fontMet(QFont*, int) const")]
		protected virtual int FontMet(QFont arg1, int arg2) {
			return ProxyQPaintDevice().FontMet(arg1,arg2);
		}
		[SmokeMethod("fontInf(QFont*, int) const")]
		protected virtual int FontInf(QFont arg1, int arg2) {
			return ProxyQPaintDevice().FontInf(arg1,arg2);
		}
		~QPaintDevice() {
			DisposeQPaintDevice();
		}
		public void Dispose() {
			DisposeQPaintDevice();
		}
		private void DisposeQPaintDevice() {
			ProxyQPaintDevice().DisposeQPaintDevice();
		}

	}
}