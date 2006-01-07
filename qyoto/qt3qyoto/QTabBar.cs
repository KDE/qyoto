//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	/// See <see cref="IQTabBarSignals"></see> for signals emitted by QTabBar
	[SmokeClass("QTabBar")]
	public class QTabBar : QWidget, IDisposable {
 		protected QTabBar(Type dummy) : base((Type) null) {}
		interface IQTabBarProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQTabBarProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTabBar), this);
			_interceptor = (QTabBar) realProxy.GetTransparentProxy();
		}
		private QTabBar ProxyQTabBar() {
			return (QTabBar) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTabBar() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTabBarProxy), null);
			_staticInterceptor = (IQTabBarProxy) realProxy.GetTransparentProxy();
		}
		private static IQTabBarProxy StaticQTabBar() {
			return (IQTabBarProxy) _staticInterceptor;
		}

		public enum Shape {
			RoundedAbove = 0,
			RoundedBelow = 1,
			TriangularAbove = 2,
			TriangularBelow = 3,
		}
		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQTabBar().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQTabBar().ClassName();
		}
		public QTabBar(QWidget parent, string name) : this((Type) null) {
			CreateQTabBarProxy();
			CreateQTabBarSignalProxy();
			NewQTabBar(parent,name);
		}
		[SmokeMethod("QTabBar(QWidget*, const char*)")]
		private void NewQTabBar(QWidget parent, string name) {
			ProxyQTabBar().NewQTabBar(parent,name);
		}
		public QTabBar(QWidget parent) : this((Type) null) {
			CreateQTabBarProxy();
			CreateQTabBarSignalProxy();
			NewQTabBar(parent);
		}
		[SmokeMethod("QTabBar(QWidget*)")]
		private void NewQTabBar(QWidget parent) {
			ProxyQTabBar().NewQTabBar(parent);
		}
		public QTabBar() : this((Type) null) {
			CreateQTabBarProxy();
			CreateQTabBarSignalProxy();
			NewQTabBar();
		}
		[SmokeMethod("QTabBar()")]
		private void NewQTabBar() {
			ProxyQTabBar().NewQTabBar();
		}
		[SmokeMethod("shape() const")]
		public QTabBar.Shape shape() {
			return ProxyQTabBar().shape();
		}
		[SmokeMethod("setShape(QTabBar::Shape)")]
		public virtual void SetShape(QTabBar.Shape arg1) {
			ProxyQTabBar().SetShape(arg1);
		}
		[SmokeMethod("show()")]
		public new void Show() {
			ProxyQTabBar().Show();
		}
		[SmokeMethod("addTab(QTab*)")]
		public virtual int AddTab(QTab arg1) {
			return ProxyQTabBar().AddTab(arg1);
		}
		[SmokeMethod("insertTab(QTab*, int)")]
		public virtual int InsertTab(QTab arg1, int index) {
			return ProxyQTabBar().InsertTab(arg1,index);
		}
		[SmokeMethod("insertTab(QTab*)")]
		public virtual int InsertTab(QTab arg1) {
			return ProxyQTabBar().InsertTab(arg1);
		}
		[SmokeMethod("removeTab(QTab*)")]
		public virtual void RemoveTab(QTab arg1) {
			ProxyQTabBar().RemoveTab(arg1);
		}
		[SmokeMethod("setTabEnabled(int, bool)")]
		public virtual void SetTabEnabled(int arg1, bool arg2) {
			ProxyQTabBar().SetTabEnabled(arg1,arg2);
		}
		[SmokeMethod("isTabEnabled(int) const")]
		public bool IsTabEnabled(int arg1) {
			return ProxyQTabBar().IsTabEnabled(arg1);
		}
		[SmokeMethod("sizeHint() const")]
		public new QSize SizeHint() {
			return ProxyQTabBar().SizeHint();
		}
		[SmokeMethod("minimumSizeHint() const")]
		public new QSize MinimumSizeHint() {
			return ProxyQTabBar().MinimumSizeHint();
		}
		[SmokeMethod("currentTab() const")]
		public int CurrentTab() {
			return ProxyQTabBar().CurrentTab();
		}
		[SmokeMethod("keyboardFocusTab() const")]
		public int KeyboardFocusTab() {
			return ProxyQTabBar().KeyboardFocusTab();
		}
		[SmokeMethod("tab(int) const")]
		public QTab Tab(int arg1) {
			return ProxyQTabBar().Tab(arg1);
		}
		[SmokeMethod("tabAt(int) const")]
		public QTab TabAt(int arg1) {
			return ProxyQTabBar().TabAt(arg1);
		}
		[SmokeMethod("indexOf(int) const")]
		public int IndexOf(int arg1) {
			return ProxyQTabBar().IndexOf(arg1);
		}
		[SmokeMethod("count() const")]
		public int Count() {
			return ProxyQTabBar().Count();
		}
		[SmokeMethod("layoutTabs()")]
		public virtual void LayoutTabs() {
			ProxyQTabBar().LayoutTabs();
		}
		[SmokeMethod("selectTab(const QPoint&) const")]
		public virtual QTab SelectTab(QPoint p) {
			return ProxyQTabBar().SelectTab(p);
		}
		[SmokeMethod("removeToolTip(int)")]
		public void RemoveToolTip(int index) {
			ProxyQTabBar().RemoveToolTip(index);
		}
		[SmokeMethod("setToolTip(int, const QString&)")]
		public void SetToolTip(int index, string tip) {
			ProxyQTabBar().SetToolTip(index,tip);
		}
		[SmokeMethod("toolTip(int) const")]
		public string ToolTip(int index) {
			return ProxyQTabBar().ToolTip(index);
		}
		[Q_SLOT("void setCurrentTab(int)")]
		[SmokeMethod("setCurrentTab(int)")]
		public virtual void SetCurrentTab(int arg1) {
			ProxyQTabBar().SetCurrentTab(arg1);
		}
		[Q_SLOT("void setCurrentTab(QTab*)")]
		[SmokeMethod("setCurrentTab(QTab*)")]
		public virtual void SetCurrentTab(QTab arg1) {
			ProxyQTabBar().SetCurrentTab(arg1);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQTabBar().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQTabBar().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQTabBar().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQTabBar().TrUtf8(arg1);
		}
		[SmokeMethod("paint(QPainter*, QTab*, bool) const")]
		protected virtual void Paint(QPainter arg1, QTab arg2, bool arg3) {
			ProxyQTabBar().Paint(arg1,arg2,arg3);
		}
		[SmokeMethod("paintLabel(QPainter*, const QRect&, QTab*, bool) const")]
		protected virtual void PaintLabel(QPainter arg1, QRect arg2, QTab arg3, bool arg4) {
			ProxyQTabBar().PaintLabel(arg1,arg2,arg3,arg4);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected new void FocusInEvent(QFocusEvent e) {
			ProxyQTabBar().FocusInEvent(e);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected new void FocusOutEvent(QFocusEvent e) {
			ProxyQTabBar().FocusOutEvent(e);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQTabBar().ResizeEvent(arg1);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected new void PaintEvent(QPaintEvent arg1) {
			ProxyQTabBar().PaintEvent(arg1);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected new void MousePressEvent(QMouseEvent arg1) {
			ProxyQTabBar().MousePressEvent(arg1);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected new void MouseMoveEvent(QMouseEvent arg1) {
			ProxyQTabBar().MouseMoveEvent(arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected new void MouseReleaseEvent(QMouseEvent arg1) {
			ProxyQTabBar().MouseReleaseEvent(arg1);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected new void KeyPressEvent(QKeyEvent arg1) {
			ProxyQTabBar().KeyPressEvent(arg1);
		}
		[SmokeMethod("styleChange(QStyle&)")]
		public new void StyleChange(QStyle arg1) {
			ProxyQTabBar().StyleChange(arg1);
		}
		[SmokeMethod("fontChange(const QFont&)")]
		protected new void FontChange(QFont arg1) {
			ProxyQTabBar().FontChange(arg1);
		}
		[SmokeMethod("event(QEvent*)")]
		public new bool Event(QEvent e) {
			return ProxyQTabBar().Event(e);
		}
		// QPtrList<QTab>* tabList(); >>>> NOT CONVERTED
		~QTabBar() {
			DisposeQTabBar();
		}
		public new void Dispose() {
			DisposeQTabBar();
		}
		private void DisposeQTabBar() {
			ProxyQTabBar().DisposeQTabBar();
		}
		protected void CreateQTabBarSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQTabBarSignals), this);
			Q_EMIT = (IQTabBarSignals) realProxy.GetTransparentProxy();
		}
		protected new IQTabBarSignals Emit() {
			return (IQTabBarSignals) Q_EMIT;
		}
	}

	public interface IQTabBarSignals : IQWidgetSignals {
		[Q_SIGNAL("void selected(int)")]
		void Selected(int arg1);
		[Q_SIGNAL("void layoutChanged()")]
		void LayoutChanged();
	}
}