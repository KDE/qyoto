//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QGLFormat")]
	public class QGLFormat : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QGLFormat(Type dummy) {}
		interface IQGLFormatProxy {
			QGLFormat DefaultFormat();
			void SetDefaultFormat(QGLFormat f);
			QGLFormat DefaultOverlayFormat();
			void SetDefaultOverlayFormat(QGLFormat f);
			bool HasOpenGL();
			bool HasOpenGLOverlays();
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QGLFormat), this);
			_interceptor = (QGLFormat) realProxy.GetTransparentProxy();
		}
		private QGLFormat ProxyQGLFormat() {
			return (QGLFormat) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QGLFormat() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQGLFormatProxy), null);
			_staticInterceptor = (IQGLFormatProxy) realProxy.GetTransparentProxy();
		}
		private static IQGLFormatProxy StaticQGLFormat() {
			return (IQGLFormatProxy) _staticInterceptor;
		}

		public QGLFormat() : this((Type) null) {
			CreateProxy();
			NewQGLFormat();
		}
		[SmokeMethod("QGLFormat()")]
		private void NewQGLFormat() {
			ProxyQGLFormat().NewQGLFormat();
		}
		public QGLFormat(int options, int plane) : this((Type) null) {
			CreateProxy();
			NewQGLFormat(options,plane);
		}
		[SmokeMethod("QGLFormat(QGL::FormatOptions, int)")]
		private void NewQGLFormat(int options, int plane) {
			ProxyQGLFormat().NewQGLFormat(options,plane);
		}
		public QGLFormat(int options) : this((Type) null) {
			CreateProxy();
			NewQGLFormat(options);
		}
		[SmokeMethod("QGLFormat(QGL::FormatOptions)")]
		private void NewQGLFormat(int options) {
			ProxyQGLFormat().NewQGLFormat(options);
		}
		public QGLFormat(QGLFormat other) : this((Type) null) {
			CreateProxy();
			NewQGLFormat(other);
		}
		[SmokeMethod("QGLFormat(const QGLFormat&)")]
		private void NewQGLFormat(QGLFormat other) {
			ProxyQGLFormat().NewQGLFormat(other);
		}
		[SmokeMethod("setDepthBufferSize(int)")]
		public void SetDepthBufferSize(int size) {
			ProxyQGLFormat().SetDepthBufferSize(size);
		}
		[SmokeMethod("depthBufferSize() const")]
		public int DepthBufferSize() {
			return ProxyQGLFormat().DepthBufferSize();
		}
		[SmokeMethod("setAccumBufferSize(int)")]
		public void SetAccumBufferSize(int size) {
			ProxyQGLFormat().SetAccumBufferSize(size);
		}
		[SmokeMethod("accumBufferSize() const")]
		public int AccumBufferSize() {
			return ProxyQGLFormat().AccumBufferSize();
		}
		[SmokeMethod("setAlphaBufferSize(int)")]
		public void SetAlphaBufferSize(int size) {
			ProxyQGLFormat().SetAlphaBufferSize(size);
		}
		[SmokeMethod("alphaBufferSize() const")]
		public int AlphaBufferSize() {
			return ProxyQGLFormat().AlphaBufferSize();
		}
		[SmokeMethod("setStencilBufferSize(int)")]
		public void SetStencilBufferSize(int size) {
			ProxyQGLFormat().SetStencilBufferSize(size);
		}
		[SmokeMethod("stencilBufferSize() const")]
		public int StencilBufferSize() {
			return ProxyQGLFormat().StencilBufferSize();
		}
		[SmokeMethod("setSampleBuffers(bool)")]
		public void SetSampleBuffers(bool enable) {
			ProxyQGLFormat().SetSampleBuffers(enable);
		}
		[SmokeMethod("sampleBuffers() const")]
		public bool SampleBuffers() {
			return ProxyQGLFormat().SampleBuffers();
		}
		[SmokeMethod("setSamples(int)")]
		public void SetSamples(int numSamples) {
			ProxyQGLFormat().SetSamples(numSamples);
		}
		[SmokeMethod("samples() const")]
		public int Samples() {
			return ProxyQGLFormat().Samples();
		}
		[SmokeMethod("doubleBuffer() const")]
		public bool DoubleBuffer() {
			return ProxyQGLFormat().DoubleBuffer();
		}
		[SmokeMethod("setDoubleBuffer(bool)")]
		public void SetDoubleBuffer(bool enable) {
			ProxyQGLFormat().SetDoubleBuffer(enable);
		}
		[SmokeMethod("depth() const")]
		public bool Depth() {
			return ProxyQGLFormat().Depth();
		}
		[SmokeMethod("setDepth(bool)")]
		public void SetDepth(bool enable) {
			ProxyQGLFormat().SetDepth(enable);
		}
		[SmokeMethod("rgba() const")]
		public bool Rgba() {
			return ProxyQGLFormat().Rgba();
		}
		[SmokeMethod("setRgba(bool)")]
		public void SetRgba(bool enable) {
			ProxyQGLFormat().SetRgba(enable);
		}
		[SmokeMethod("alpha() const")]
		public bool Alpha() {
			return ProxyQGLFormat().Alpha();
		}
		[SmokeMethod("setAlpha(bool)")]
		public void SetAlpha(bool enable) {
			ProxyQGLFormat().SetAlpha(enable);
		}
		[SmokeMethod("accum() const")]
		public bool Accum() {
			return ProxyQGLFormat().Accum();
		}
		[SmokeMethod("setAccum(bool)")]
		public void SetAccum(bool enable) {
			ProxyQGLFormat().SetAccum(enable);
		}
		[SmokeMethod("stencil() const")]
		public bool Stencil() {
			return ProxyQGLFormat().Stencil();
		}
		[SmokeMethod("setStencil(bool)")]
		public void SetStencil(bool enable) {
			ProxyQGLFormat().SetStencil(enable);
		}
		[SmokeMethod("stereo() const")]
		public bool Stereo() {
			return ProxyQGLFormat().Stereo();
		}
		[SmokeMethod("setStereo(bool)")]
		public void SetStereo(bool enable) {
			ProxyQGLFormat().SetStereo(enable);
		}
		[SmokeMethod("directRendering() const")]
		public bool DirectRendering() {
			return ProxyQGLFormat().DirectRendering();
		}
		[SmokeMethod("setDirectRendering(bool)")]
		public void SetDirectRendering(bool enable) {
			ProxyQGLFormat().SetDirectRendering(enable);
		}
		[SmokeMethod("hasOverlay() const")]
		public bool HasOverlay() {
			return ProxyQGLFormat().HasOverlay();
		}
		[SmokeMethod("setOverlay(bool)")]
		public void SetOverlay(bool enable) {
			ProxyQGLFormat().SetOverlay(enable);
		}
		[SmokeMethod("plane() const")]
		public int Plane() {
			return ProxyQGLFormat().Plane();
		}
		[SmokeMethod("setPlane(int)")]
		public void SetPlane(int plane) {
			ProxyQGLFormat().SetPlane(plane);
		}
		[SmokeMethod("setOption(QGL::FormatOptions)")]
		public void SetOption(int opt) {
			ProxyQGLFormat().SetOption(opt);
		}
		[SmokeMethod("testOption(QGL::FormatOptions) const")]
		public bool TestOption(int opt) {
			return ProxyQGLFormat().TestOption(opt);
		}
		[SmokeMethod("defaultFormat()")]
		public static QGLFormat DefaultFormat() {
			return StaticQGLFormat().DefaultFormat();
		}
		[SmokeMethod("setDefaultFormat(const QGLFormat&)")]
		public static void SetDefaultFormat(QGLFormat f) {
			StaticQGLFormat().SetDefaultFormat(f);
		}
		[SmokeMethod("defaultOverlayFormat()")]
		public static QGLFormat DefaultOverlayFormat() {
			return StaticQGLFormat().DefaultOverlayFormat();
		}
		[SmokeMethod("setDefaultOverlayFormat(const QGLFormat&)")]
		public static void SetDefaultOverlayFormat(QGLFormat f) {
			StaticQGLFormat().SetDefaultOverlayFormat(f);
		}
		[SmokeMethod("hasOpenGL()")]
		public static bool HasOpenGL() {
			return StaticQGLFormat().HasOpenGL();
		}
		[SmokeMethod("hasOpenGLOverlays()")]
		public static bool HasOpenGLOverlays() {
			return StaticQGLFormat().HasOpenGLOverlays();
		}
		~QGLFormat() {
			DisposeQGLFormat();
		}
		public void Dispose() {
			DisposeQGLFormat();
		}
		private void DisposeQGLFormat() {
			ProxyQGLFormat().DisposeQGLFormat();
		}
	}
}
