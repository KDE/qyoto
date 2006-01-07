//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	[SmokeClass("QDragObject")]
	public class QDragObject : QObject, IQMimeSource {
 		protected QDragObject(Type dummy) : base((Type) null) {}
		interface IQDragObjectProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
			QWidget Target();
			void SetTarget(QWidget arg1);
		}

		protected void CreateQDragObjectProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDragObject), this);
			_interceptor = (QDragObject) realProxy.GetTransparentProxy();
		}
		private QDragObject ProxyQDragObject() {
			return (QDragObject) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDragObject() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDragObjectProxy), null);
			_staticInterceptor = (IQDragObjectProxy) realProxy.GetTransparentProxy();
		}
		private static IQDragObjectProxy StaticQDragObject() {
			return (IQDragObjectProxy) _staticInterceptor;
		}

		public enum DragMode {
			DragDefault = 0,
			DragCopy = 1,
			DragMove = 2,
			DragLink = 3,
			DragCopyOrMove = 4,
		}
		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQDragObject().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQDragObject().ClassName();
		}
		public QDragObject(QWidget dragSource, string name) : this((Type) null) {
			CreateQDragObjectProxy();
			CreateQDragObjectSignalProxy();
			NewQDragObject(dragSource,name);
		}
		[SmokeMethod("QDragObject(QWidget*, const char*)")]
		private void NewQDragObject(QWidget dragSource, string name) {
			ProxyQDragObject().NewQDragObject(dragSource,name);
		}
		public QDragObject(QWidget dragSource) : this((Type) null) {
			CreateQDragObjectProxy();
			CreateQDragObjectSignalProxy();
			NewQDragObject(dragSource);
		}
		[SmokeMethod("QDragObject(QWidget*)")]
		private void NewQDragObject(QWidget dragSource) {
			ProxyQDragObject().NewQDragObject(dragSource);
		}
		public QDragObject() : this((Type) null) {
			CreateQDragObjectProxy();
			CreateQDragObjectSignalProxy();
			NewQDragObject();
		}
		[SmokeMethod("QDragObject()")]
		private void NewQDragObject() {
			ProxyQDragObject().NewQDragObject();
		}
		[SmokeMethod("drag()")]
		public bool Drag() {
			return ProxyQDragObject().Drag();
		}
		[SmokeMethod("dragMove()")]
		public bool DragMove() {
			return ProxyQDragObject().DragMove();
		}
		[SmokeMethod("dragCopy()")]
		public void DragCopy() {
			ProxyQDragObject().DragCopy();
		}
		[SmokeMethod("dragLink()")]
		public void DragLink() {
			ProxyQDragObject().DragLink();
		}
		[SmokeMethod("setPixmap(QPixmap)")]
		public virtual void SetPixmap(QPixmap arg1) {
			ProxyQDragObject().SetPixmap(arg1);
		}
		[SmokeMethod("setPixmap(QPixmap, const QPoint&)")]
		public virtual void SetPixmap(QPixmap arg1, QPoint hotspot) {
			ProxyQDragObject().SetPixmap(arg1,hotspot);
		}
		[SmokeMethod("pixmap() const")]
		public QPixmap Pixmap() {
			return ProxyQDragObject().Pixmap();
		}
		[SmokeMethod("pixmapHotSpot() const")]
		public QPoint PixmapHotSpot() {
			return ProxyQDragObject().PixmapHotSpot();
		}
		[SmokeMethod("source()")]
		public QWidget Source() {
			return ProxyQDragObject().Source();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQDragObject().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQDragObject().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQDragObject().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQDragObject().TrUtf8(arg1);
		}
		[SmokeMethod("target()")]
		public static QWidget Target() {
			return StaticQDragObject().Target();
		}
		[SmokeMethod("setTarget(QWidget*)")]
		public static void SetTarget(QWidget arg1) {
			StaticQDragObject().SetTarget(arg1);
		}
		~QDragObject() {
			DisposeQDragObject();
		}
		public new void Dispose() {
			DisposeQDragObject();
		}
		private void DisposeQDragObject() {
			ProxyQDragObject().DisposeQDragObject();
		}
		[SmokeMethod("format(int) const")]
		public virtual string Format(int n) {
			return ProxyQDragObject().Format(n);
		}
		[SmokeMethod("format() const")]
		public virtual string Format() {
			return ProxyQDragObject().Format();
		}
		[SmokeMethod("provides(const char*) const")]
		public virtual bool Provides(string arg1) {
			return ProxyQDragObject().Provides(arg1);
		}
		[SmokeMethod("encodedData(const char*) const")]
		public virtual QByteArray EncodedData(string arg1) {
			return ProxyQDragObject().EncodedData(arg1);
		}
		[SmokeMethod("serialNumber() const")]
		public int SerialNumber() {
			return ProxyQDragObject().SerialNumber();
		}

		protected void CreateQDragObjectSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQDragObjectSignals), this);
			Q_EMIT = (IQDragObjectSignals) realProxy.GetTransparentProxy();
		}
		protected new IQDragObjectSignals Emit() {
			return (IQDragObjectSignals) Q_EMIT;
		}
	}

	public interface IQDragObjectSignals : IQObjectSignals {
	}
}