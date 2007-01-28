//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQTabBarSignals"></see> for signals emitted by QTabBar
	[SmokeClass("QTabBar")]
	public class QTabBar : QWidget, IDisposable {
 		protected QTabBar(Type dummy) : base((Type) null) {}
		interface IQTabBarProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
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
			RoundedNorth = 0,
			RoundedSouth = 1,
			RoundedWest = 2,
			RoundedEast = 3,
			TriangularNorth = 4,
			TriangularSouth = 5,
			TriangularWest = 6,
			TriangularEast = 7,
		}
		[Q_PROPERTY("QTabBar::Shape", "shape")]
		public QTabBar.Shape shape {
			get {
				return Property("shape").Value<QTabBar.Shape>();
			}
			set {
				SetProperty("shape", QVariant.FromValue<QTabBar.Shape>(value));
			}
		}
		[Q_PROPERTY("int", "currentIndex")]
		public int CurrentIndex {
			get {
				return Property("currentIndex").Value<int>();
			}
			set {
				SetProperty("currentIndex", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "count")]
		public int Count {
			get {
				return Property("count").Value<int>();
			}
		}
		[Q_PROPERTY("bool", "drawBase")]
		public bool DrawBase {
			get {
				return Property("drawBase").Value<bool>();
			}
			set {
				SetProperty("drawBase", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QSize", "iconSize")]
		public QSize IconSize {
			get {
				return Property("iconSize").Value<QSize>();
			}
			set {
				SetProperty("iconSize", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("Qt::TextElideMode", "elideMode")]
		public Qt.TextElideMode ElideMode {
			get {
				return Property("elideMode").Value<Qt.TextElideMode>();
			}
			set {
				SetProperty("elideMode", QVariant.FromValue<Qt.TextElideMode>(value));
			}
		}
		[Q_PROPERTY("bool", "usesScrollButtons")]
		public bool UsesScrollButtons {
			get {
				return Property("usesScrollButtons").Value<bool>();
			}
			set {
				SetProperty("usesScrollButtons", QVariant.FromValue<bool>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QTabBar(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQTabBar(parent);
		}
		[SmokeMethod("QTabBar(QWidget*)")]
		private void NewQTabBar(QWidget parent) {
			ProxyQTabBar().NewQTabBar(parent);
		}
		public QTabBar() : this((Type) null) {
			CreateProxy();
			NewQTabBar();
		}
		[SmokeMethod("QTabBar()")]
		private void NewQTabBar() {
			ProxyQTabBar().NewQTabBar();
		}
		[SmokeMethod("addTab(const QString&)")]
		public int AddTab(string text) {
			return ProxyQTabBar().AddTab(text);
		}
		[SmokeMethod("addTab(const QIcon&, const QString&)")]
		public int AddTab(QIcon icon, string text) {
			return ProxyQTabBar().AddTab(icon,text);
		}
		[SmokeMethod("insertTab(int, const QString&)")]
		public int InsertTab(int index, string text) {
			return ProxyQTabBar().InsertTab(index,text);
		}
		[SmokeMethod("insertTab(int, const QIcon&, const QString&)")]
		public int InsertTab(int index, QIcon icon, string text) {
			return ProxyQTabBar().InsertTab(index,icon,text);
		}
		[SmokeMethod("removeTab(int)")]
		public void RemoveTab(int index) {
			ProxyQTabBar().RemoveTab(index);
		}
		[SmokeMethod("isTabEnabled(int) const")]
		public bool IsTabEnabled(int index) {
			return ProxyQTabBar().IsTabEnabled(index);
		}
		[SmokeMethod("setTabEnabled(int, bool)")]
		public void SetTabEnabled(int index, bool arg2) {
			ProxyQTabBar().SetTabEnabled(index,arg2);
		}
		[SmokeMethod("tabText(int) const")]
		public string TabText(int index) {
			return ProxyQTabBar().TabText(index);
		}
		[SmokeMethod("setTabText(int, const QString&)")]
		public void SetTabText(int index, string text) {
			ProxyQTabBar().SetTabText(index,text);
		}
		[SmokeMethod("tabTextColor(int) const")]
		public QColor TabTextColor(int index) {
			return ProxyQTabBar().TabTextColor(index);
		}
		[SmokeMethod("setTabTextColor(int, const QColor&)")]
		public void SetTabTextColor(int index, QColor color) {
			ProxyQTabBar().SetTabTextColor(index,color);
		}
		[SmokeMethod("tabIcon(int) const")]
		public QIcon TabIcon(int index) {
			return ProxyQTabBar().TabIcon(index);
		}
		[SmokeMethod("setTabIcon(int, const QIcon&)")]
		public void SetTabIcon(int index, QIcon icon) {
			ProxyQTabBar().SetTabIcon(index,icon);
		}
		[SmokeMethod("setTabToolTip(int, const QString&)")]
		public void SetTabToolTip(int index, string tip) {
			ProxyQTabBar().SetTabToolTip(index,tip);
		}
		[SmokeMethod("tabToolTip(int) const")]
		public string TabToolTip(int index) {
			return ProxyQTabBar().TabToolTip(index);
		}
		[SmokeMethod("setTabWhatsThis(int, const QString&)")]
		public void SetTabWhatsThis(int index, string text) {
			ProxyQTabBar().SetTabWhatsThis(index,text);
		}
		[SmokeMethod("tabWhatsThis(int) const")]
		public string TabWhatsThis(int index) {
			return ProxyQTabBar().TabWhatsThis(index);
		}
		[SmokeMethod("setTabData(int, const QVariant&)")]
		public void SetTabData(int index, QVariant data) {
			ProxyQTabBar().SetTabData(index,data);
		}
		[SmokeMethod("tabData(int) const")]
		public QVariant TabData(int index) {
			return ProxyQTabBar().TabData(index);
		}
		[SmokeMethod("tabRect(int) const")]
		public QRect TabRect(int index) {
			return ProxyQTabBar().TabRect(index);
		}
		[SmokeMethod("sizeHint() const")]
		public new QSize SizeHint() {
			return ProxyQTabBar().SizeHint();
		}
		[SmokeMethod("minimumSizeHint() const")]
		public new QSize MinimumSizeHint() {
			return ProxyQTabBar().MinimumSizeHint();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQTabBar().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQTabBar().Tr(s);
		}
		[SmokeMethod("tabSizeHint(int) const")]
		protected virtual QSize TabSizeHint(int index) {
			return ProxyQTabBar().TabSizeHint(index);
		}
		[SmokeMethod("tabInserted(int)")]
		protected virtual void TabInserted(int index) {
			ProxyQTabBar().TabInserted(index);
		}
		[SmokeMethod("tabRemoved(int)")]
		protected virtual void TabRemoved(int index) {
			ProxyQTabBar().TabRemoved(index);
		}
		[SmokeMethod("tabLayoutChange()")]
		protected virtual void TabLayoutChange() {
			ProxyQTabBar().TabLayoutChange();
		}
		[SmokeMethod("event(QEvent*)")]
		public new bool Event(QEvent arg1) {
			return ProxyQTabBar().Event(arg1);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQTabBar().ResizeEvent(arg1);
		}
		[SmokeMethod("showEvent(QShowEvent*)")]
		public new void ShowEvent(QShowEvent arg1) {
			ProxyQTabBar().ShowEvent(arg1);
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
		[SmokeMethod("changeEvent(QEvent*)")]
		protected new void ChangeEvent(QEvent arg1) {
			ProxyQTabBar().ChangeEvent(arg1);
		}
		~QTabBar() {
			DisposeQTabBar();
		}
		public new void Dispose() {
			DisposeQTabBar();
		}
		[SmokeMethod("~QTabBar()")]
		private void DisposeQTabBar() {
			ProxyQTabBar().DisposeQTabBar();
		}
		protected new IQTabBarSignals Emit {
			get {
				return (IQTabBarSignals) Q_EMIT;
			}
		}
	}

	public interface IQTabBarSignals : IQWidgetSignals {
		[Q_SIGNAL("void currentChanged(int)")]
		void CurrentChanged(int index);
	}
}
