//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	[SmokeClass("QGLWidget")]
	public class QGLWidget : QWidget, IQGL, IDisposable {
 		protected QGLWidget(Type dummy) : base((Type) null) {}
		interface IQGLWidgetProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
			QImage ConvertToGLFormat(QImage img);
		}

		protected void CreateQGLWidgetProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QGLWidget), this);
			_interceptor = (QGLWidget) realProxy.GetTransparentProxy();
		}
		private QGLWidget ProxyQGLWidget() {
			return (QGLWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QGLWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQGLWidgetProxy), null);
			_staticInterceptor = (IQGLWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQGLWidgetProxy StaticQGLWidget() {
			return (IQGLWidgetProxy) _staticInterceptor;
		}

		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQGLWidget().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQGLWidget().ClassName();
		}
		public QGLWidget(QWidget parent, string name, QGLWidget shareWidget, int f) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(parent,name,shareWidget,f);
		}
		[SmokeMethod("QGLWidget(QWidget*, const char*, const QGLWidget*, Qt::WFlags)")]
		private void NewQGLWidget(QWidget parent, string name, QGLWidget shareWidget, int f) {
			ProxyQGLWidget().NewQGLWidget(parent,name,shareWidget,f);
		}
		public QGLWidget(QWidget parent, string name, QGLWidget shareWidget) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(parent,name,shareWidget);
		}
		[SmokeMethod("QGLWidget(QWidget*, const char*, const QGLWidget*)")]
		private void NewQGLWidget(QWidget parent, string name, QGLWidget shareWidget) {
			ProxyQGLWidget().NewQGLWidget(parent,name,shareWidget);
		}
		public QGLWidget(QWidget parent, string name) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(parent,name);
		}
		[SmokeMethod("QGLWidget(QWidget*, const char*)")]
		private void NewQGLWidget(QWidget parent, string name) {
			ProxyQGLWidget().NewQGLWidget(parent,name);
		}
		public QGLWidget(QWidget parent) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(parent);
		}
		[SmokeMethod("QGLWidget(QWidget*)")]
		private void NewQGLWidget(QWidget parent) {
			ProxyQGLWidget().NewQGLWidget(parent);
		}
		public QGLWidget() : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget();
		}
		[SmokeMethod("QGLWidget()")]
		private void NewQGLWidget() {
			ProxyQGLWidget().NewQGLWidget();
		}
		public QGLWidget(QGLContext context, QWidget parent, string name, QGLWidget shareWidget, int f) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(context,parent,name,shareWidget,f);
		}
		[SmokeMethod("QGLWidget(QGLContext*, QWidget*, const char*, const QGLWidget*, Qt::WFlags)")]
		private void NewQGLWidget(QGLContext context, QWidget parent, string name, QGLWidget shareWidget, int f) {
			ProxyQGLWidget().NewQGLWidget(context,parent,name,shareWidget,f);
		}
		public QGLWidget(QGLContext context, QWidget parent, string name, QGLWidget shareWidget) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(context,parent,name,shareWidget);
		}
		[SmokeMethod("QGLWidget(QGLContext*, QWidget*, const char*, const QGLWidget*)")]
		private void NewQGLWidget(QGLContext context, QWidget parent, string name, QGLWidget shareWidget) {
			ProxyQGLWidget().NewQGLWidget(context,parent,name,shareWidget);
		}
		public QGLWidget(QGLContext context, QWidget parent, string name) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(context,parent,name);
		}
		[SmokeMethod("QGLWidget(QGLContext*, QWidget*, const char*)")]
		private void NewQGLWidget(QGLContext context, QWidget parent, string name) {
			ProxyQGLWidget().NewQGLWidget(context,parent,name);
		}
		public QGLWidget(QGLContext context, QWidget parent) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(context,parent);
		}
		[SmokeMethod("QGLWidget(QGLContext*, QWidget*)")]
		private void NewQGLWidget(QGLContext context, QWidget parent) {
			ProxyQGLWidget().NewQGLWidget(context,parent);
		}
		public QGLWidget(QGLFormat format, QWidget parent, string name, QGLWidget shareWidget, int f) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(format,parent,name,shareWidget,f);
		}
		[SmokeMethod("QGLWidget(const QGLFormat&, QWidget*, const char*, const QGLWidget*, Qt::WFlags)")]
		private void NewQGLWidget(QGLFormat format, QWidget parent, string name, QGLWidget shareWidget, int f) {
			ProxyQGLWidget().NewQGLWidget(format,parent,name,shareWidget,f);
		}
		public QGLWidget(QGLFormat format, QWidget parent, string name, QGLWidget shareWidget) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(format,parent,name,shareWidget);
		}
		[SmokeMethod("QGLWidget(const QGLFormat&, QWidget*, const char*, const QGLWidget*)")]
		private void NewQGLWidget(QGLFormat format, QWidget parent, string name, QGLWidget shareWidget) {
			ProxyQGLWidget().NewQGLWidget(format,parent,name,shareWidget);
		}
		public QGLWidget(QGLFormat format, QWidget parent, string name) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(format,parent,name);
		}
		[SmokeMethod("QGLWidget(const QGLFormat&, QWidget*, const char*)")]
		private void NewQGLWidget(QGLFormat format, QWidget parent, string name) {
			ProxyQGLWidget().NewQGLWidget(format,parent,name);
		}
		public QGLWidget(QGLFormat format, QWidget parent) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(format,parent);
		}
		[SmokeMethod("QGLWidget(const QGLFormat&, QWidget*)")]
		private void NewQGLWidget(QGLFormat format, QWidget parent) {
			ProxyQGLWidget().NewQGLWidget(format,parent);
		}
		public QGLWidget(QGLFormat format) : this((Type) null) {
			CreateQGLWidgetProxy();
			CreateQGLWidgetSignalProxy();
			NewQGLWidget(format);
		}
		[SmokeMethod("QGLWidget(const QGLFormat&)")]
		private void NewQGLWidget(QGLFormat format) {
			ProxyQGLWidget().NewQGLWidget(format);
		}
		[SmokeMethod("qglColor(const QColor&) const")]
		public void QglColor(QColor c) {
			ProxyQGLWidget().QglColor(c);
		}
		[SmokeMethod("qglClearColor(const QColor&) const")]
		public void QglClearColor(QColor c) {
			ProxyQGLWidget().QglClearColor(c);
		}
		[SmokeMethod("isValid() const")]
		public bool IsValid() {
			return ProxyQGLWidget().IsValid();
		}
		[SmokeMethod("isSharing() const")]
		public bool IsSharing() {
			return ProxyQGLWidget().IsSharing();
		}
		[SmokeMethod("makeCurrent()")]
		public virtual void MakeCurrent() {
			ProxyQGLWidget().MakeCurrent();
		}
		[SmokeMethod("doneCurrent()")]
		public void DoneCurrent() {
			ProxyQGLWidget().DoneCurrent();
		}
		[SmokeMethod("doubleBuffer() const")]
		public bool DoubleBuffer() {
			return ProxyQGLWidget().DoubleBuffer();
		}
		[SmokeMethod("swapBuffers()")]
		public virtual void SwapBuffers() {
			ProxyQGLWidget().SwapBuffers();
		}
		[SmokeMethod("format() const")]
		public QGLFormat Format() {
			return ProxyQGLWidget().Format();
		}
		[SmokeMethod("setFormat(const QGLFormat&)")]
		public virtual void SetFormat(QGLFormat format) {
			ProxyQGLWidget().SetFormat(format);
		}
		[SmokeMethod("context() const")]
		public QGLContext Context() {
			return ProxyQGLWidget().Context();
		}
		[SmokeMethod("setContext(QGLContext*, const QGLContext*, bool)")]
		public virtual void SetContext(QGLContext context, QGLContext shareContext, bool deleteOldContext) {
			ProxyQGLWidget().SetContext(context,shareContext,deleteOldContext);
		}
		[SmokeMethod("setContext(QGLContext*, const QGLContext*)")]
		public virtual void SetContext(QGLContext context, QGLContext shareContext) {
			ProxyQGLWidget().SetContext(context,shareContext);
		}
		[SmokeMethod("setContext(QGLContext*)")]
		public virtual void SetContext(QGLContext context) {
			ProxyQGLWidget().SetContext(context);
		}
		[SmokeMethod("renderPixmap(int, int, bool)")]
		public virtual QPixmap RenderPixmap(int w, int h, bool useContext) {
			return ProxyQGLWidget().RenderPixmap(w,h,useContext);
		}
		[SmokeMethod("renderPixmap(int, int)")]
		public virtual QPixmap RenderPixmap(int w, int h) {
			return ProxyQGLWidget().RenderPixmap(w,h);
		}
		[SmokeMethod("renderPixmap(int)")]
		public virtual QPixmap RenderPixmap(int w) {
			return ProxyQGLWidget().RenderPixmap(w);
		}
		[SmokeMethod("renderPixmap()")]
		public virtual QPixmap RenderPixmap() {
			return ProxyQGLWidget().RenderPixmap();
		}
		[SmokeMethod("grabFrameBuffer(bool)")]
		public virtual QImage GrabFrameBuffer(bool withAlpha) {
			return ProxyQGLWidget().GrabFrameBuffer(withAlpha);
		}
		[SmokeMethod("grabFrameBuffer()")]
		public virtual QImage GrabFrameBuffer() {
			return ProxyQGLWidget().GrabFrameBuffer();
		}
		[SmokeMethod("makeOverlayCurrent()")]
		public virtual void MakeOverlayCurrent() {
			ProxyQGLWidget().MakeOverlayCurrent();
		}
		[SmokeMethod("overlayContext() const")]
		public QGLContext OverlayContext() {
			return ProxyQGLWidget().OverlayContext();
		}
		[SmokeMethod("setMouseTracking(bool)")]
		public new void SetMouseTracking(bool enable) {
			ProxyQGLWidget().SetMouseTracking(enable);
		}
		[SmokeMethod("reparent(QWidget*, Qt::WFlags, const QPoint&, bool)")]
		public new virtual void Reparent(QWidget parent, int f, QPoint p, bool showIt) {
			ProxyQGLWidget().Reparent(parent,f,p,showIt);
		}
		[SmokeMethod("reparent(QWidget*, Qt::WFlags, const QPoint&)")]
		public new virtual void Reparent(QWidget parent, int f, QPoint p) {
			ProxyQGLWidget().Reparent(parent,f,p);
		}
		[SmokeMethod("colormap() const")]
		public QGLColormap Colormap() {
			return ProxyQGLWidget().Colormap();
		}
		[SmokeMethod("setColormap(const QGLColormap&)")]
		public void SetColormap(QGLColormap map) {
			ProxyQGLWidget().SetColormap(map);
		}
		[SmokeMethod("renderText(int, int, const QString&, const QFont&, int)")]
		public void RenderText(int x, int y, string str, QFont fnt, int listBase) {
			ProxyQGLWidget().RenderText(x,y,str,fnt,listBase);
		}
		[SmokeMethod("renderText(int, int, const QString&, const QFont&)")]
		public void RenderText(int x, int y, string str, QFont fnt) {
			ProxyQGLWidget().RenderText(x,y,str,fnt);
		}
		[SmokeMethod("renderText(int, int, const QString&)")]
		public void RenderText(int x, int y, string str) {
			ProxyQGLWidget().RenderText(x,y,str);
		}
		[SmokeMethod("renderText(double, double, double, const QString&, const QFont&, int)")]
		public void RenderText(double x, double y, double z, string str, QFont fnt, int listBase) {
			ProxyQGLWidget().RenderText(x,y,z,str,fnt,listBase);
		}
		[SmokeMethod("renderText(double, double, double, const QString&, const QFont&)")]
		public void RenderText(double x, double y, double z, string str, QFont fnt) {
			ProxyQGLWidget().RenderText(x,y,z,str,fnt);
		}
		[SmokeMethod("renderText(double, double, double, const QString&)")]
		public void RenderText(double x, double y, double z, string str) {
			ProxyQGLWidget().RenderText(x,y,z,str);
		}
		[Q_SLOT("void updateGL()")]
		[SmokeMethod("updateGL()")]
		public virtual void UpdateGL() {
			ProxyQGLWidget().UpdateGL();
		}
		[Q_SLOT("void updateOverlayGL()")]
		[SmokeMethod("updateOverlayGL()")]
		public virtual void UpdateOverlayGL() {
			ProxyQGLWidget().UpdateOverlayGL();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQGLWidget().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQGLWidget().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQGLWidget().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQGLWidget().TrUtf8(arg1);
		}
		[SmokeMethod("convertToGLFormat(const QImage&)")]
		public static QImage ConvertToGLFormat(QImage img) {
			return StaticQGLWidget().ConvertToGLFormat(img);
		}
		[SmokeMethod("initializeGL()")]
		protected virtual void InitializeGL() {
			ProxyQGLWidget().InitializeGL();
		}
		[SmokeMethod("resizeGL(int, int)")]
		protected virtual void ResizeGL(int w, int h) {
			ProxyQGLWidget().ResizeGL(w,h);
		}
		[SmokeMethod("paintGL()")]
		protected virtual void PaintGL() {
			ProxyQGLWidget().PaintGL();
		}
		[SmokeMethod("initializeOverlayGL()")]
		protected virtual void InitializeOverlayGL() {
			ProxyQGLWidget().InitializeOverlayGL();
		}
		[SmokeMethod("resizeOverlayGL(int, int)")]
		protected virtual void ResizeOverlayGL(int w, int h) {
			ProxyQGLWidget().ResizeOverlayGL(w,h);
		}
		[SmokeMethod("paintOverlayGL()")]
		protected virtual void PaintOverlayGL() {
			ProxyQGLWidget().PaintOverlayGL();
		}
		[SmokeMethod("setAutoBufferSwap(bool)")]
		protected void SetAutoBufferSwap(bool on) {
			ProxyQGLWidget().SetAutoBufferSwap(on);
		}
		[SmokeMethod("autoBufferSwap() const")]
		protected bool AutoBufferSwap() {
			return ProxyQGLWidget().AutoBufferSwap();
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected new void PaintEvent(QPaintEvent arg1) {
			ProxyQGLWidget().PaintEvent(arg1);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQGLWidget().ResizeEvent(arg1);
		}
		[SmokeMethod("glInit()")]
		protected virtual void GlInit() {
			ProxyQGLWidget().GlInit();
		}
		[SmokeMethod("glDraw()")]
		protected virtual void GlDraw() {
			ProxyQGLWidget().GlDraw();
		}
		~QGLWidget() {
			DisposeQGLWidget();
		}
		public new void Dispose() {
			DisposeQGLWidget();
		}
		private void DisposeQGLWidget() {
			ProxyQGLWidget().DisposeQGLWidget();
		}
		protected void CreateQGLWidgetSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQGLWidgetSignals), this);
			Q_EMIT = (IQGLWidgetSignals) realProxy.GetTransparentProxy();
		}
		protected new IQGLWidgetSignals Emit() {
			return (IQGLWidgetSignals) Q_EMIT;
		}
	}

	public interface IQGLWidgetSignals : IQWidgetSignals {
	}
}