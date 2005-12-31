//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QDialog : QWidget, IDisposable {
 		protected QDialog(Type dummy) : base((Type) null) {}
		interface IQDialogProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQDialogProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDialog), this);
			_interceptor = (QDialog) realProxy.GetTransparentProxy();
		}
		private QDialog ProxyQDialog() {
			return (QDialog) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDialog() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDialogProxy), null);
			_staticInterceptor = (IQDialogProxy) realProxy.GetTransparentProxy();
		}
		private static IQDialogProxy StaticQDialog() {
			return (IQDialogProxy) _staticInterceptor;
		}

		enum DialogCode {
			Rejected = 0,
			Accepted = 1,
		}
		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQDialog().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQDialog().ClassName();
		}
		public QDialog(QWidget parent, string name, bool modal, int f) : this((Type) null) {
			CreateQDialogProxy();
			CreateQDialogSignalProxy();
			NewQDialog(parent,name,modal,f);
		}
		[SmokeMethod("QDialog(QWidget*, const char*, bool, Qt::WFlags)")]
		private void NewQDialog(QWidget parent, string name, bool modal, int f) {
			ProxyQDialog().NewQDialog(parent,name,modal,f);
		}
		public QDialog(QWidget parent, string name, bool modal) : this((Type) null) {
			CreateQDialogProxy();
			CreateQDialogSignalProxy();
			NewQDialog(parent,name,modal);
		}
		[SmokeMethod("QDialog(QWidget*, const char*, bool)")]
		private void NewQDialog(QWidget parent, string name, bool modal) {
			ProxyQDialog().NewQDialog(parent,name,modal);
		}
		public QDialog(QWidget parent, string name) : this((Type) null) {
			CreateQDialogProxy();
			CreateQDialogSignalProxy();
			NewQDialog(parent,name);
		}
		[SmokeMethod("QDialog(QWidget*, const char*)")]
		private void NewQDialog(QWidget parent, string name) {
			ProxyQDialog().NewQDialog(parent,name);
		}
		public QDialog(QWidget parent) : this((Type) null) {
			CreateQDialogProxy();
			CreateQDialogSignalProxy();
			NewQDialog(parent);
		}
		[SmokeMethod("QDialog(QWidget*)")]
		private void NewQDialog(QWidget parent) {
			ProxyQDialog().NewQDialog(parent);
		}
		public QDialog() : this((Type) null) {
			CreateQDialogProxy();
			CreateQDialogSignalProxy();
			NewQDialog();
		}
		[SmokeMethod("QDialog()")]
		private void NewQDialog() {
			ProxyQDialog().NewQDialog();
		}
		[SmokeMethod("result() const")]
		public int Result() {
			return ProxyQDialog().Result();
		}
		[SmokeMethod("show()")]
		public new void Show() {
			ProxyQDialog().Show();
		}
		[SmokeMethod("hide()")]
		public new void Hide() {
			ProxyQDialog().Hide();
		}
		[SmokeMethod("move(int, int)")]
		public new void Move(int x, int y) {
			ProxyQDialog().Move(x,y);
		}
		[SmokeMethod("move(const QPoint&)")]
		public new void Move(QPoint p) {
			ProxyQDialog().Move(p);
		}
		[SmokeMethod("resize(int, int)")]
		public new void Resize(int w, int h) {
			ProxyQDialog().Resize(w,h);
		}
		[SmokeMethod("resize(const QSize&)")]
		public new void Resize(QSize arg1) {
			ProxyQDialog().Resize(arg1);
		}
		[SmokeMethod("setGeometry(int, int, int, int)")]
		public new void SetGeometry(int x, int y, int w, int h) {
			ProxyQDialog().SetGeometry(x,y,w,h);
		}
		[SmokeMethod("setGeometry(const QRect&)")]
		public new void SetGeometry(QRect arg1) {
			ProxyQDialog().SetGeometry(arg1);
		}
		[SmokeMethod("setOrientation(Qt::Orientation)")]
		public void SetOrientation(int orientation) {
			ProxyQDialog().SetOrientation(orientation);
		}
		[SmokeMethod("orientation() const")]
		public int Orientation() {
			return ProxyQDialog().Orientation();
		}
		[SmokeMethod("setExtension(QWidget*)")]
		public void SetExtension(QWidget extension) {
			ProxyQDialog().SetExtension(extension);
		}
		[SmokeMethod("extension() const")]
		public QWidget Extension() {
			return ProxyQDialog().Extension();
		}
		[SmokeMethod("sizeHint() const")]
		public new QSize SizeHint() {
			return ProxyQDialog().SizeHint();
		}
		[SmokeMethod("minimumSizeHint() const")]
		public new QSize MinimumSizeHint() {
			return ProxyQDialog().MinimumSizeHint();
		}
		[SmokeMethod("setSizeGripEnabled(bool)")]
		public void SetSizeGripEnabled(bool arg1) {
			ProxyQDialog().SetSizeGripEnabled(arg1);
		}
		[SmokeMethod("isSizeGripEnabled() const")]
		public bool IsSizeGripEnabled() {
			return ProxyQDialog().IsSizeGripEnabled();
		}
		[SmokeMethod("setModal(bool)")]
		public void SetModal(bool modal) {
			ProxyQDialog().SetModal(modal);
		}
		[SmokeMethod("isModal() const")]
		public new bool IsModal() {
			return ProxyQDialog().IsModal();
		}
		[Q_SLOT("int exec()")]
		[SmokeMethod("exec()")]
		public int Exec() {
			return ProxyQDialog().Exec();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQDialog().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQDialog().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQDialog().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQDialog().TrUtf8(arg1);
		}
		[SmokeMethod("setResult(int)")]
		protected void SetResult(int r) {
			ProxyQDialog().SetResult(r);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected new void KeyPressEvent(QKeyEvent arg1) {
			ProxyQDialog().KeyPressEvent(arg1);
		}
		[SmokeMethod("closeEvent(QCloseEvent*)")]
		protected new void CloseEvent(QCloseEvent arg1) {
			ProxyQDialog().CloseEvent(arg1);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQDialog().ResizeEvent(arg1);
		}
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected new void ContextMenuEvent(QContextMenuEvent arg1) {
			ProxyQDialog().ContextMenuEvent(arg1);
		}
		[SmokeMethod("eventFilter(QObject*, QEvent*)")]
		public new bool EventFilter(QObject arg1, QEvent arg2) {
			return ProxyQDialog().EventFilter(arg1,arg2);
		}
		[SmokeMethod("adjustPosition(QWidget*)")]
		protected void AdjustPosition(QWidget arg1) {
			ProxyQDialog().AdjustPosition(arg1);
		}
		[Q_SLOT("void done(int)")]
		[SmokeMethod("done(int)")]
		protected virtual void Done(int arg1) {
			ProxyQDialog().Done(arg1);
		}
		[Q_SLOT("void accept()")]
		[SmokeMethod("accept()")]
		protected virtual void Accept() {
			ProxyQDialog().Accept();
		}
		[Q_SLOT("void reject()")]
		[SmokeMethod("reject()")]
		protected virtual void Reject() {
			ProxyQDialog().Reject();
		}
		[Q_SLOT("void showExtension(bool)")]
		[SmokeMethod("showExtension(bool)")]
		protected void ShowExtension(bool arg1) {
			ProxyQDialog().ShowExtension(arg1);
		}
		~QDialog() {
			DisposeQDialog();
		}
		public new void Dispose() {
			DisposeQDialog();
		}
		private void DisposeQDialog() {
			ProxyQDialog().DisposeQDialog();
		}
		protected void CreateQDialogSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQDialogSignals), this);
			_signalInterceptor = (IQDialogSignals) realProxy.GetTransparentProxy();
		}
		protected new IQDialogSignals Emit() {
			return (IQDialogSignals) _signalInterceptor;
		}
	}

	public interface IQDialogSignals : IQWidgetSignals {
	}
}
