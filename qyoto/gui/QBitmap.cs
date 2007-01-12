//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QBitmap")]
	public class QBitmap : QPixmap, IDisposable {
 		protected QBitmap(Type dummy) : base((Type) null) {}
		interface IQBitmapProxy {
			QBitmap FromImage(QImage image, int flags);
			QBitmap FromImage(QImage image);
			QBitmap FromData(QSize size, char[] bits, QImage.Format monoFormat);
			QBitmap FromData(QSize size, char[] bits);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QBitmap), this);
			_interceptor = (QBitmap) realProxy.GetTransparentProxy();
		}
		private QBitmap ProxyQBitmap() {
			return (QBitmap) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QBitmap() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQBitmapProxy), null);
			_staticInterceptor = (IQBitmapProxy) realProxy.GetTransparentProxy();
		}
		private static IQBitmapProxy StaticQBitmap() {
			return (IQBitmapProxy) _staticInterceptor;
		}

		public QBitmap() : this((Type) null) {
			CreateProxy();
			NewQBitmap();
		}
		[SmokeMethod("QBitmap()")]
		private void NewQBitmap() {
			ProxyQBitmap().NewQBitmap();
		}
		public QBitmap(QPixmap arg1) : this((Type) null) {
			CreateProxy();
			NewQBitmap(arg1);
		}
		[SmokeMethod("QBitmap(const QPixmap&)")]
		private void NewQBitmap(QPixmap arg1) {
			ProxyQBitmap().NewQBitmap(arg1);
		}
		public QBitmap(int w, int h) : this((Type) null) {
			CreateProxy();
			NewQBitmap(w,h);
		}
		[SmokeMethod("QBitmap(int, int)")]
		private void NewQBitmap(int w, int h) {
			ProxyQBitmap().NewQBitmap(w,h);
		}
		public QBitmap(QSize arg1) : this((Type) null) {
			CreateProxy();
			NewQBitmap(arg1);
		}
		[SmokeMethod("QBitmap(const QSize&)")]
		private void NewQBitmap(QSize arg1) {
			ProxyQBitmap().NewQBitmap(arg1);
		}
		public QBitmap(string fileName, string format) : this((Type) null) {
			CreateProxy();
			NewQBitmap(fileName,format);
		}
		[SmokeMethod("QBitmap(const QString&, const char*)")]
		private void NewQBitmap(string fileName, string format) {
			ProxyQBitmap().NewQBitmap(fileName,format);
		}
		public QBitmap(string fileName) : this((Type) null) {
			CreateProxy();
			NewQBitmap(fileName);
		}
		[SmokeMethod("QBitmap(const QString&)")]
		private void NewQBitmap(string fileName) {
			ProxyQBitmap().NewQBitmap(fileName);
		}
		//  operator QVariant(); >>>> NOT CONVERTED
		[SmokeMethod("clear()")]
		public void Clear() {
			ProxyQBitmap().Clear();
		}
		[SmokeMethod("transformed(const QMatrix&) const")]
		public new QBitmap Transformed(QMatrix arg1) {
			return ProxyQBitmap().Transformed(arg1);
		}
		[SmokeMethod("fromImage(const QImage&, Qt::ImageConversionFlags)")]
		public static new QBitmap FromImage(QImage image, int flags) {
			return StaticQBitmap().FromImage(image,flags);
		}
		[SmokeMethod("fromImage(const QImage&)")]
		public static new QBitmap FromImage(QImage image) {
			return StaticQBitmap().FromImage(image);
		}
		[SmokeMethod("fromData(const QSize&, const uchar*, QImage::Format)")]
		public static QBitmap FromData(QSize size, char[] bits, QImage.Format monoFormat) {
			return StaticQBitmap().FromData(size,bits,monoFormat);
		}
		[SmokeMethod("fromData(const QSize&, const uchar*)")]
		public static QBitmap FromData(QSize size, char[] bits) {
			return StaticQBitmap().FromData(size,bits);
		}
		~QBitmap() {
			DisposeQBitmap();
		}
		public void Dispose() {
			DisposeQBitmap();
		}
		[SmokeMethod("~QBitmap()")]
		private void DisposeQBitmap() {
			ProxyQBitmap().DisposeQBitmap();
		}
//	public QBitmap(QPixmap arg1) {
//		super((Class) null);
//		newQBitmap(arg1);
//	}
//	private native void newQBitmap(QPixmap arg1);
//	public QBitmap(QImage arg1) {
//		super((Class) null);
//		newQBitmap(arg1);
//	}
//	private native void newQBitmap(QImage arg1);
	
	}
}