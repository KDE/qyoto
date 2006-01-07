//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	[SmokeClass("QHBox")]
	public class QHBox : QFrame, IDisposable {
 		protected QHBox(Type dummy) : base((Type) null) {}
		interface IQHBoxProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQHBoxProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHBox), this);
			_interceptor = (QHBox) realProxy.GetTransparentProxy();
		}
		private QHBox ProxyQHBox() {
			return (QHBox) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHBox() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHBoxProxy), null);
			_staticInterceptor = (IQHBoxProxy) realProxy.GetTransparentProxy();
		}
		private static IQHBoxProxy StaticQHBox() {
			return (IQHBoxProxy) _staticInterceptor;
		}

		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQHBox().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQHBox().ClassName();
		}
		public QHBox(QWidget parent, string name, int f) : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox(parent,name,f);
		}
		[SmokeMethod("QHBox(QWidget*, const char*, Qt::WFlags)")]
		private void NewQHBox(QWidget parent, string name, int f) {
			ProxyQHBox().NewQHBox(parent,name,f);
		}
		public QHBox(QWidget parent, string name) : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox(parent,name);
		}
		[SmokeMethod("QHBox(QWidget*, const char*)")]
		private void NewQHBox(QWidget parent, string name) {
			ProxyQHBox().NewQHBox(parent,name);
		}
		public QHBox(QWidget parent) : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox(parent);
		}
		[SmokeMethod("QHBox(QWidget*)")]
		private void NewQHBox(QWidget parent) {
			ProxyQHBox().NewQHBox(parent);
		}
		public QHBox() : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox();
		}
		[SmokeMethod("QHBox()")]
		private void NewQHBox() {
			ProxyQHBox().NewQHBox();
		}
		[SmokeMethod("setSpacing(int)")]
		public void SetSpacing(int arg1) {
			ProxyQHBox().SetSpacing(arg1);
		}
		[SmokeMethod("setStretchFactor(QWidget*, int)")]
		public bool SetStretchFactor(QWidget arg1, int stretch) {
			return ProxyQHBox().SetStretchFactor(arg1,stretch);
		}
		[SmokeMethod("sizeHint() const")]
		public new QSize SizeHint() {
			return ProxyQHBox().SizeHint();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQHBox().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQHBox().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQHBox().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQHBox().TrUtf8(arg1);
		}
		public QHBox(bool horizontal, QWidget parent, string name, int f) : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox(horizontal,parent,name,f);
		}
		[SmokeMethod("QHBox(bool, QWidget*, const char*, Qt::WFlags)")]
		private void NewQHBox(bool horizontal, QWidget parent, string name, int f) {
			ProxyQHBox().NewQHBox(horizontal,parent,name,f);
		}
		public QHBox(bool horizontal, QWidget parent, string name) : this((Type) null) {
			CreateQHBoxProxy();
			CreateQHBoxSignalProxy();
			NewQHBox(horizontal,parent,name);
		}
		[SmokeMethod("QHBox(bool, QWidget*, const char*)")]
		private void NewQHBox(bool horizontal, QWidget parent, string name) {
			ProxyQHBox().NewQHBox(horizontal,parent,name);
		}
		[SmokeMethod("frameChanged()")]
		protected new void FrameChanged() {
			ProxyQHBox().FrameChanged();
		}
		~QHBox() {
			DisposeQHBox();
		}
		public new void Dispose() {
			DisposeQHBox();
		}
		private void DisposeQHBox() {
			ProxyQHBox().DisposeQHBox();
		}
		protected void CreateQHBoxSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQHBoxSignals), this);
			Q_EMIT = (IQHBoxSignals) realProxy.GetTransparentProxy();
		}
		protected new IQHBoxSignals Emit() {
			return (IQHBoxSignals) Q_EMIT;
		}
	}

	public interface IQHBoxSignals : IQFrameSignals {
	}
}