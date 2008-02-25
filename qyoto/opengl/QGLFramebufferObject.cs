//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QGLFramebufferObject")]
	public class QGLFramebufferObject : QPaintDevice, IDisposable {
 		protected QGLFramebufferObject(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QGLFramebufferObject), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QGLFramebufferObject() {
			staticInterceptor = new SmokeInvocation(typeof(QGLFramebufferObject), null);
		}
		public enum Attachment {
			NoAttachment = 0,
			CombinedDepthStencil = 1,
			Depth = 2,
		}
		public QGLFramebufferObject(QSize size, int target) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject#$", "QGLFramebufferObject(const QSize&, GLenum)", typeof(void), typeof(QSize), size, typeof(int), target);
		}
		public QGLFramebufferObject(QSize size) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject#", "QGLFramebufferObject(const QSize&)", typeof(void), typeof(QSize), size);
		}
		public QGLFramebufferObject(int width, int height, int target) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject$$$", "QGLFramebufferObject(int, int, GLenum)", typeof(void), typeof(int), width, typeof(int), height, typeof(int), target);
		}
		public QGLFramebufferObject(int width, int height) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject$$", "QGLFramebufferObject(int, int)", typeof(void), typeof(int), width, typeof(int), height);
		}
		public QGLFramebufferObject(QSize size, QGLFramebufferObject.Attachment attachment, int target, int internal_format) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject#$$$", "QGLFramebufferObject(const QSize&, QGLFramebufferObject::Attachment, GLenum, GLenum)", typeof(void), typeof(QSize), size, typeof(QGLFramebufferObject.Attachment), attachment, typeof(int), target, typeof(int), internal_format);
		}
		public QGLFramebufferObject(QSize size, QGLFramebufferObject.Attachment attachment, int target) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject#$$", "QGLFramebufferObject(const QSize&, QGLFramebufferObject::Attachment, GLenum)", typeof(void), typeof(QSize), size, typeof(QGLFramebufferObject.Attachment), attachment, typeof(int), target);
		}
		public QGLFramebufferObject(QSize size, QGLFramebufferObject.Attachment attachment) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject#$", "QGLFramebufferObject(const QSize&, QGLFramebufferObject::Attachment)", typeof(void), typeof(QSize), size, typeof(QGLFramebufferObject.Attachment), attachment);
		}
		public QGLFramebufferObject(int width, int height, QGLFramebufferObject.Attachment attachment, int target, int internal_format) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject$$$$$", "QGLFramebufferObject(int, int, QGLFramebufferObject::Attachment, GLenum, GLenum)", typeof(void), typeof(int), width, typeof(int), height, typeof(QGLFramebufferObject.Attachment), attachment, typeof(int), target, typeof(int), internal_format);
		}
		public QGLFramebufferObject(int width, int height, QGLFramebufferObject.Attachment attachment, int target) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject$$$$", "QGLFramebufferObject(int, int, QGLFramebufferObject::Attachment, GLenum)", typeof(void), typeof(int), width, typeof(int), height, typeof(QGLFramebufferObject.Attachment), attachment, typeof(int), target);
		}
		public QGLFramebufferObject(int width, int height, QGLFramebufferObject.Attachment attachment) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGLFramebufferObject$$$", "QGLFramebufferObject(int, int, QGLFramebufferObject::Attachment)", typeof(void), typeof(int), width, typeof(int), height, typeof(QGLFramebufferObject.Attachment), attachment);
		}
		public bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid() const", typeof(bool));
		}
		public bool Bind() {
			return (bool) interceptor.Invoke("bind", "bind()", typeof(bool));
		}
		public bool Release() {
			return (bool) interceptor.Invoke("release", "release()", typeof(bool));
		}
		public uint Texture() {
			return (uint) interceptor.Invoke("texture", "texture() const", typeof(uint));
		}
		public QSize Size() {
			return (QSize) interceptor.Invoke("size", "size() const", typeof(QSize));
		}
		public QImage ToImage() {
			return (QImage) interceptor.Invoke("toImage", "toImage() const", typeof(QImage));
		}
		public QGLFramebufferObject.Attachment attachment() {
			return (QGLFramebufferObject.Attachment) interceptor.Invoke("attachment", "attachment() const", typeof(QGLFramebufferObject.Attachment));
		}
		[SmokeMethod("paintEngine() const")]
		public override QPaintEngine PaintEngine() {
			return (QPaintEngine) interceptor.Invoke("paintEngine", "paintEngine() const", typeof(QPaintEngine));
		}
		public void DrawTexture(QRectF target, uint textureId, int textureTarget) {
			interceptor.Invoke("drawTexture#$$", "drawTexture(const QRectF&, GLuint, GLenum)", typeof(void), typeof(QRectF), target, typeof(uint), textureId, typeof(int), textureTarget);
		}
		public void DrawTexture(QRectF target, uint textureId) {
			interceptor.Invoke("drawTexture#$", "drawTexture(const QRectF&, GLuint)", typeof(void), typeof(QRectF), target, typeof(uint), textureId);
		}
		public void DrawTexture(QPointF point, uint textureId, int textureTarget) {
			interceptor.Invoke("drawTexture#$$", "drawTexture(const QPointF&, GLuint, GLenum)", typeof(void), typeof(QPointF), point, typeof(uint), textureId, typeof(int), textureTarget);
		}
		public void DrawTexture(QPointF point, uint textureId) {
			interceptor.Invoke("drawTexture#$", "drawTexture(const QPointF&, GLuint)", typeof(void), typeof(QPointF), point, typeof(uint), textureId);
		}
		[SmokeMethod("metric(QPaintDevice::PaintDeviceMetric) const")]
		protected override int Metric(IQPaintDevice metric) {
			return (int) interceptor.Invoke("metric$", "metric(QPaintDevice::PaintDeviceMetric) const", typeof(int), typeof(IQPaintDevice), metric);
		}
		[SmokeMethod("devType() const")]
		protected new virtual int DevType() {
			return (int) interceptor.Invoke("devType", "devType() const", typeof(int));
		}
		~QGLFramebufferObject() {
			interceptor.Invoke("~QGLFramebufferObject", "~QGLFramebufferObject()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~QGLFramebufferObject", "~QGLFramebufferObject()", typeof(void));
		}
		public static bool HasOpenGLFramebufferObjects() {
			return (bool) staticInterceptor.Invoke("hasOpenGLFramebufferObjects", "hasOpenGLFramebufferObjects()", typeof(bool));
		}
	}
}
