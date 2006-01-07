//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	[SmokeClass("QPicture")]
	public class QPicture : QPaintDevice, IDisposable {
 		protected QPicture(Type dummy) : base((Type) null) {}
		interface IQPictureProxy {
		}

		protected void CreateQPictureProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPicture), this);
			_interceptor = (QPicture) realProxy.GetTransparentProxy();
		}
		private QPicture ProxyQPicture() {
			return (QPicture) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPicture() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPictureProxy), null);
			_staticInterceptor = (IQPictureProxy) realProxy.GetTransparentProxy();
		}
		private static IQPictureProxy StaticQPicture() {
			return (IQPictureProxy) _staticInterceptor;
		}

		public QPicture(int formatVersion) : this((Type) null) {
			CreateQPictureProxy();
			NewQPicture(formatVersion);
		}
		[SmokeMethod("QPicture(int)")]
		private void NewQPicture(int formatVersion) {
			ProxyQPicture().NewQPicture(formatVersion);
		}
		public QPicture() : this((Type) null) {
			CreateQPictureProxy();
			NewQPicture();
		}
		[SmokeMethod("QPicture()")]
		private void NewQPicture() {
			ProxyQPicture().NewQPicture();
		}
		public QPicture(QPicture arg1) : this((Type) null) {
			CreateQPictureProxy();
			NewQPicture(arg1);
		}
		[SmokeMethod("QPicture(const QPicture&)")]
		private void NewQPicture(QPicture arg1) {
			ProxyQPicture().NewQPicture(arg1);
		}
		[SmokeMethod("isNull() const")]
		public bool IsNull() {
			return ProxyQPicture().IsNull();
		}
		[SmokeMethod("size() const")]
		public uint Size() {
			return ProxyQPicture().Size();
		}
		[SmokeMethod("data() const")]
		public string Data() {
			return ProxyQPicture().Data();
		}
		[SmokeMethod("setData(const char*, uint)")]
		public virtual void SetData(string data, uint size) {
			ProxyQPicture().SetData(data,size);
		}
		[SmokeMethod("play(QPainter*)")]
		public bool Play(QPainter arg1) {
			return ProxyQPicture().Play(arg1);
		}
		[SmokeMethod("load(QIODevice*, const char*)")]
		public bool Load(IQIODevice dev, string format) {
			return ProxyQPicture().Load(dev,format);
		}
		[SmokeMethod("load(QIODevice*)")]
		public bool Load(IQIODevice dev) {
			return ProxyQPicture().Load(dev);
		}
		[SmokeMethod("load(const QString&, const char*)")]
		public bool Load(string fileName, string format) {
			return ProxyQPicture().Load(fileName,format);
		}
		[SmokeMethod("load(const QString&)")]
		public bool Load(string fileName) {
			return ProxyQPicture().Load(fileName);
		}
		[SmokeMethod("save(QIODevice*, const char*)")]
		public bool Save(IQIODevice dev, string format) {
			return ProxyQPicture().Save(dev,format);
		}
		[SmokeMethod("save(QIODevice*)")]
		public bool Save(IQIODevice dev) {
			return ProxyQPicture().Save(dev);
		}
		[SmokeMethod("save(const QString&, const char*)")]
		public bool Save(string fileName, string format) {
			return ProxyQPicture().Save(fileName,format);
		}
		[SmokeMethod("save(const QString&)")]
		public bool Save(string fileName) {
			return ProxyQPicture().Save(fileName);
		}
		[SmokeMethod("boundingRect() const")]
		public QRect BoundingRect() {
			return ProxyQPicture().BoundingRect();
		}
		[SmokeMethod("setBoundingRect(const QRect&)")]
		public void SetBoundingRect(QRect r) {
			ProxyQPicture().SetBoundingRect(r);
		}
		// bool cmd(int arg1,QPainter* arg2,QPDevCmdParam* arg3); >>>> NOT CONVERTED
		[SmokeMethod("metric(int) const")]
		protected new int Metric(int arg1) {
			return ProxyQPicture().Metric(arg1);
		}
		[SmokeMethod("detach()")]
		public void Detach() {
			ProxyQPicture().Detach();
		}
		[SmokeMethod("copy() const")]
		public QPicture Copy() {
			return ProxyQPicture().Copy();
		}
		~QPicture() {
			DisposeQPicture();
		}
		public void Dispose() {
			DisposeQPicture();
		}
		private void DisposeQPicture() {
			ProxyQPicture().DisposeQPicture();
		}
	}
}