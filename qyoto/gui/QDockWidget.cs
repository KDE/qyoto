//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQDockWidgetSignals"></see> for signals emitted by QDockWidget
	[SmokeClass("QDockWidget")]
	public class QDockWidget : QWidget, IDisposable {
 		protected QDockWidget(Type dummy) : base((Type) null) {}
		interface IQDockWidgetProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDockWidget), this);
			_interceptor = (QDockWidget) realProxy.GetTransparentProxy();
		}
		private QDockWidget ProxyQDockWidget() {
			return (QDockWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDockWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDockWidgetProxy), null);
			_staticInterceptor = (IQDockWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQDockWidgetProxy StaticQDockWidget() {
			return (IQDockWidgetProxy) _staticInterceptor;
		}

		public enum DockWidgetFeature {
			DockWidgetClosable = 0x01,
			DockWidgetMovable = 0x02,
			DockWidgetFloatable = 0x04,
			DockWidgetFeatureMask = 0x07,
			AllDockWidgetFeatures = DockWidgetFeatureMask,
			NoDockWidgetFeatures = 0x00,
			Reserved = 0xff,
		}
		[Q_PROPERTY("bool", "floating")]
		public bool Floating {
			get {
				return Property("floating").Value<bool>();
			}
			set {
				SetProperty("floating", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("DockWidgetFeatures", "features")]
		public int Features {
			get {
				return Property("features").Value<int>();
			}
			set {
				SetProperty("features", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("Qt::DockWidgetAreas", "allowedAreas")]
		public int AllowedAreas {
			get {
				return Property("allowedAreas").Value<int>();
			}
			set {
				SetProperty("allowedAreas", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("QString", "windowTitle")]
		public string WindowTitle {
			get {
				return Property("windowTitle").Value<string>();
			}
			set {
				SetProperty("windowTitle", QVariant.FromValue<string>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QDockWidget(string title, QWidget parent, int flags) : this((Type) null) {
			CreateProxy();
			NewQDockWidget(title,parent,flags);
		}
		[SmokeMethod("QDockWidget(const QString&, QWidget*, Qt::WindowFlags)")]
		private void NewQDockWidget(string title, QWidget parent, int flags) {
			ProxyQDockWidget().NewQDockWidget(title,parent,flags);
		}
		public QDockWidget(string title, QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQDockWidget(title,parent);
		}
		[SmokeMethod("QDockWidget(const QString&, QWidget*)")]
		private void NewQDockWidget(string title, QWidget parent) {
			ProxyQDockWidget().NewQDockWidget(title,parent);
		}
		public QDockWidget(string title) : this((Type) null) {
			CreateProxy();
			NewQDockWidget(title);
		}
		[SmokeMethod("QDockWidget(const QString&)")]
		private void NewQDockWidget(string title) {
			ProxyQDockWidget().NewQDockWidget(title);
		}
		public QDockWidget(QWidget parent, int flags) : this((Type) null) {
			CreateProxy();
			NewQDockWidget(parent,flags);
		}
		[SmokeMethod("QDockWidget(QWidget*, Qt::WindowFlags)")]
		private void NewQDockWidget(QWidget parent, int flags) {
			ProxyQDockWidget().NewQDockWidget(parent,flags);
		}
		public QDockWidget(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQDockWidget(parent);
		}
		[SmokeMethod("QDockWidget(QWidget*)")]
		private void NewQDockWidget(QWidget parent) {
			ProxyQDockWidget().NewQDockWidget(parent);
		}
		public QDockWidget() : this((Type) null) {
			CreateProxy();
			NewQDockWidget();
		}
		[SmokeMethod("QDockWidget()")]
		private void NewQDockWidget() {
			ProxyQDockWidget().NewQDockWidget();
		}
		[SmokeMethod("widget() const")]
		public QWidget Widget() {
			return ProxyQDockWidget().Widget();
		}
		[SmokeMethod("setWidget(QWidget*)")]
		public void SetWidget(QWidget widget) {
			ProxyQDockWidget().SetWidget(widget);
		}
		[SmokeMethod("isFloating() const")]
		public bool IsFloating() {
			return ProxyQDockWidget().IsFloating();
		}
		[SmokeMethod("isAreaAllowed(Qt::DockWidgetArea) const")]
		public bool IsAreaAllowed(Qt.DockWidgetArea area) {
			return ProxyQDockWidget().IsAreaAllowed(area);
		}
		[SmokeMethod("toggleViewAction() const")]
		public QAction ToggleViewAction() {
			return ProxyQDockWidget().ToggleViewAction();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQDockWidget().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQDockWidget().Tr(s);
		}
		[SmokeMethod("changeEvent(QEvent*)")]
		protected new void ChangeEvent(QEvent arg1) {
			ProxyQDockWidget().ChangeEvent(arg1);
		}
		[SmokeMethod("closeEvent(QCloseEvent*)")]
		protected new void CloseEvent(QCloseEvent arg1) {
			ProxyQDockWidget().CloseEvent(arg1);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected new void PaintEvent(QPaintEvent arg1) {
			ProxyQDockWidget().PaintEvent(arg1);
		}
		[SmokeMethod("event(QEvent*)")]
		public new bool Event(QEvent arg1) {
			return ProxyQDockWidget().Event(arg1);
		}
		~QDockWidget() {
			DisposeQDockWidget();
		}
		public new void Dispose() {
			DisposeQDockWidget();
		}
		[SmokeMethod("~QDockWidget()")]
		private void DisposeQDockWidget() {
			ProxyQDockWidget().DisposeQDockWidget();
		}
		protected new IQDockWidgetSignals Emit {
			get {
				return (IQDockWidgetSignals) Q_EMIT;
			}
		}
	}

	public interface IQDockWidgetSignals : IQWidgetSignals {
		[Q_SIGNAL("void featuresChanged(QDockWidget::DockWidgetFeatures)")]
		void FeaturesChanged(int features);
		[Q_SIGNAL("void topLevelChanged(bool)")]
		void TopLevelChanged(bool topLevel);
		[Q_SIGNAL("void allowedAreasChanged(Qt::DockWidgetAreas)")]
		void AllowedAreasChanged(int allowedAreas);
	}
}
