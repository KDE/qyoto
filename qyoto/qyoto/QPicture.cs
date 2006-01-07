//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QPicture : QPaintDevice, IDisposable {
 		protected QPicture(Type dummy) : base((Type) null) {}
		interface IQPictureProxy {
			string PictureFormat(string fileName);
			ArrayList InputFormatList();
			ArrayList OutputFormatList();
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
		private void NewQPicture(int formatVersion) {
			ProxyQPicture().NewQPicture(formatVersion);
		}
		public QPicture() : this((Type) null) {
			CreateQPictureProxy();
			NewQPicture();
		}
		private void NewQPicture() {
			ProxyQPicture().NewQPicture();
		}
		public QPicture(QPicture arg1) : this((Type) null) {
			CreateQPictureProxy();
			NewQPicture(arg1);
		}
		private void NewQPicture(QPicture arg1) {
			ProxyQPicture().NewQPicture(arg1);
		}
		public bool IsNull() {
			return ProxyQPicture().IsNull();
		}
		public new int DevType() {
			return ProxyQPicture().DevType();
		}
		public uint Size() {
			return ProxyQPicture().Size();
		}
		public string Data() {
			return ProxyQPicture().Data();
		}
		public virtual void SetData(string data, uint size) {
			ProxyQPicture().SetData(data,size);
		}
		public bool Play(QPainter p) {
			return ProxyQPicture().Play(p);
		}
		public bool Load(IQIODevice dev, string format) {
			return ProxyQPicture().Load(dev,format);
		}
		public bool Load(IQIODevice dev) {
			return ProxyQPicture().Load(dev);
		}
		public bool Load(string fileName, string format) {
			return ProxyQPicture().Load(fileName,format);
		}
		public bool Load(string fileName) {
			return ProxyQPicture().Load(fileName);
		}
		public bool Save(IQIODevice dev, string format) {
			return ProxyQPicture().Save(dev,format);
		}
		public bool Save(IQIODevice dev) {
			return ProxyQPicture().Save(dev);
		}
		public bool Save(string fileName, string format) {
			return ProxyQPicture().Save(fileName,format);
		}
		public bool Save(string fileName) {
			return ProxyQPicture().Save(fileName);
		}
		public QRect BoundingRect() {
			return ProxyQPicture().BoundingRect();
		}
		public void SetBoundingRect(QRect r) {
			ProxyQPicture().SetBoundingRect(r);
		}
		public void Detach() {
			ProxyQPicture().Detach();
		}
		public bool IsDetached() {
			return ProxyQPicture().IsDetached();
		}
		public new QPaintEngine PaintEngine() {
			return ProxyQPicture().PaintEngine();
		}
		public static string PictureFormat(string fileName) {
			return StaticQPicture().PictureFormat(fileName);
		}
		// QList<QByteArray> inputFormats(); >>>> NOT CONVERTED
		// QList<QByteArray> outputFormats(); >>>> NOT CONVERTED
		public static ArrayList InputFormatList() {
			return StaticQPicture().InputFormatList();
		}
		public static ArrayList OutputFormatList() {
			return StaticQPicture().OutputFormatList();
		}
		// QPicture* QPicture(QPicturePrivate& arg1); >>>> NOT CONVERTED
		protected new int Metric(IQPaintDevice m) {
			return ProxyQPicture().Metric(m);
		}
		~QPicture() {
			ProxyQPicture().Dispose();
		}
		public void Dispose() {
			ProxyQPicture().Dispose();
		}
	}
}