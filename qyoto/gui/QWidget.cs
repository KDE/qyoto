//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	/// See <see cref="IQWidgetSignals"></see> for signals emitted by QWidget
	[SmokeClass("QWidget")]
	public class QWidget : QObject, IQPaintDevice, IDisposable {
 		protected QWidget(Type dummy) : base((Type) null) {}
		interface IQWidgetProxy {
			string Tr(string s, string c);
			string Tr(string s);
			void SetTabOrder(QWidget arg1, QWidget arg2);
			QWidget MouseGrabber();
			QWidget KeyboardGrabber();
			QWidget Find(ulong arg1);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QWidget), this);
			_interceptor = (QWidget) realProxy.GetTransparentProxy();
		}
		private QWidget ProxyQWidget() {
			return (QWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQWidgetProxy), null);
			_staticInterceptor = (IQWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQWidgetProxy StaticQWidget() {
			return (IQWidgetProxy) _staticInterceptor;
		}

		[Q_PROPERTY("bool", "modal")]
		public bool Modal {
			get {
				return Property("modal").Value<bool>();
			}
		}
		[Q_PROPERTY("Qt::WindowModality", "windowModality")]
		public Qt.WindowModality WindowModality {
			get {
				return Property("windowModality").Value<Qt.WindowModality>();
			}
			set {
				SetProperty("windowModality", QVariant.FromValue<Qt.WindowModality>(value));
			}
		}
		[Q_PROPERTY("bool", "enabled")]
		public bool Enabled {
			get {
				return Property("enabled").Value<bool>();
			}
			set {
				SetProperty("enabled", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QRect", "geometry")]
		public QRect Geometry {
			get {
				return Property("geometry").Value<QRect>();
			}
			set {
				SetProperty("geometry", QVariant.FromValue<QRect>(value));
			}
		}
		[Q_PROPERTY("QRect", "frameGeometry")]
		public QRect FrameGeometry {
			get {
				return Property("frameGeometry").Value<QRect>();
			}
		}
		[Q_PROPERTY("QRect", "normalGeometry")]
		public QRect NormalGeometry {
			get {
				return Property("normalGeometry").Value<QRect>();
			}
		}
		[Q_PROPERTY("int", "x")]
		public int X {
			get {
				return Property("x").Value<int>();
			}
		}
		[Q_PROPERTY("int", "y")]
		public int Y {
			get {
				return Property("y").Value<int>();
			}
		}
		[Q_PROPERTY("QPoint", "pos")]
		public QPoint Pos {
			get {
				return Property("pos").Value<QPoint>();
			}
			set {
				SetProperty("pos", QVariant.FromValue<QPoint>(value));
			}
		}
		[Q_PROPERTY("QSize", "frameSize")]
		public QSize FrameSize {
			get {
				return Property("frameSize").Value<QSize>();
			}
		}
		[Q_PROPERTY("QSize", "size")]
		public QSize Size {
			get {
				return Property("size").Value<QSize>();
			}
			set {
				SetProperty("size", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("QRect", "rect")]
		public QRect Rect {
			get {
				return Property("rect").Value<QRect>();
			}
		}
		[Q_PROPERTY("QRect", "childrenRect")]
		public QRect ChildrenRect {
			get {
				return Property("childrenRect").Value<QRect>();
			}
		}
		[Q_PROPERTY("QRegion", "childrenRegion")]
		public QRegion ChildrenRegion {
			get {
				return Property("childrenRegion").Value<QRegion>();
			}
		}
		[Q_PROPERTY("QSizePolicy", "sizePolicy")]
		public QSizePolicy SizePolicy {
			get {
				return Property("sizePolicy").Value<QSizePolicy>();
			}
			set {
				SetProperty("sizePolicy", QVariant.FromValue<QSizePolicy>(value));
			}
		}
		[Q_PROPERTY("QSize", "minimumSize")]
		public QSize MinimumSize {
			get {
				return Property("minimumSize").Value<QSize>();
			}
			set {
				SetProperty("minimumSize", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("QSize", "maximumSize")]
		public QSize MaximumSize {
			get {
				return Property("maximumSize").Value<QSize>();
			}
			set {
				SetProperty("maximumSize", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("int", "minimumWidth")]
		public int MinimumWidth {
			get {
				return Property("minimumWidth").Value<int>();
			}
			set {
				SetProperty("minimumWidth", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "minimumHeight")]
		public int MinimumHeight {
			get {
				return Property("minimumHeight").Value<int>();
			}
			set {
				SetProperty("minimumHeight", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "maximumWidth")]
		public int MaximumWidth {
			get {
				return Property("maximumWidth").Value<int>();
			}
			set {
				SetProperty("maximumWidth", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "maximumHeight")]
		public int MaximumHeight {
			get {
				return Property("maximumHeight").Value<int>();
			}
			set {
				SetProperty("maximumHeight", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("QSize", "sizeIncrement")]
		public QSize SizeIncrement {
			get {
				return Property("sizeIncrement").Value<QSize>();
			}
			set {
				SetProperty("sizeIncrement", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("QSize", "baseSize")]
		public QSize BaseSize {
			get {
				return Property("baseSize").Value<QSize>();
			}
			set {
				SetProperty("baseSize", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("QPalette", "palette")]
		public QPalette Palette {
			get {
				return Property("palette").Value<QPalette>();
			}
			set {
				SetProperty("palette", QVariant.FromValue<QPalette>(value));
			}
		}
		[Q_PROPERTY("QFont", "font")]
		public QFont Font {
			get {
				return Property("font").Value<QFont>();
			}
			set {
				SetProperty("font", QVariant.FromValue<QFont>(value));
			}
		}
		[Q_PROPERTY("QCursor", "cursor")]
		public QCursor Cursor {
			get {
				return Property("cursor").Value<QCursor>();
			}
			set {
				SetProperty("cursor", QVariant.FromValue<QCursor>(value));
			}
		}
		[Q_PROPERTY("bool", "mouseTracking")]
		public bool MouseTracking {
			get {
				return Property("mouseTracking").Value<bool>();
			}
			set {
				SetProperty("mouseTracking", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "isActiveWindow")]
		public bool IsActiveWindow {
			get {
				return Property("isActiveWindow").Value<bool>();
			}
		}
		[Q_PROPERTY("Qt::FocusPolicy", "focusPolicy")]
		public Qt.FocusPolicy FocusPolicy {
			get {
				return Property("focusPolicy").Value<Qt.FocusPolicy>();
			}
			set {
				SetProperty("focusPolicy", QVariant.FromValue<Qt.FocusPolicy>(value));
			}
		}
		[Q_PROPERTY("bool", "focus")]
		public bool Focus {
			get {
				return Property("focus").Value<bool>();
			}
		}
		[Q_PROPERTY("Qt::ContextMenuPolicy", "contextMenuPolicy")]
		public Qt.ContextMenuPolicy ContextMenuPolicy {
			get {
				return Property("contextMenuPolicy").Value<Qt.ContextMenuPolicy>();
			}
			set {
				SetProperty("contextMenuPolicy", QVariant.FromValue<Qt.ContextMenuPolicy>(value));
			}
		}
		[Q_PROPERTY("bool", "updatesEnabled")]
		public bool UpdatesEnabled {
			get {
				return Property("updatesEnabled").Value<bool>();
			}
			set {
				SetProperty("updatesEnabled", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "visible")]
		public bool Visible {
			get {
				return Property("visible").Value<bool>();
			}
			set {
				SetProperty("visible", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "minimized")]
		public bool Minimized {
			get {
				return Property("minimized").Value<bool>();
			}
		}
		[Q_PROPERTY("bool", "maximized")]
		public bool Maximized {
			get {
				return Property("maximized").Value<bool>();
			}
		}
		[Q_PROPERTY("bool", "fullScreen")]
		public bool FullScreen {
			get {
				return Property("fullScreen").Value<bool>();
			}
		}
		[Q_PROPERTY("QSize", "minimumSizeHint")]
		public QSize MinimumSizeHint {
			get {
				return Property("minimumSizeHint").Value<QSize>();
			}
		}
		[Q_PROPERTY("bool", "acceptDrops")]
		public bool AcceptDrops {
			get {
				return Property("acceptDrops").Value<bool>();
			}
			set {
				SetProperty("acceptDrops", QVariant.FromValue<bool>(value));
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
		[Q_PROPERTY("QIcon", "windowIcon")]
		public QIcon WindowIcon {
			get {
				return Property("windowIcon").Value<QIcon>();
			}
			set {
				SetProperty("windowIcon", QVariant.FromValue<QIcon>(value));
			}
		}
		[Q_PROPERTY("QString", "windowIconText")]
		public string WindowIconText {
			get {
				return Property("windowIconText").Value<string>();
			}
			set {
				SetProperty("windowIconText", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("double", "windowOpacity")]
		public double WindowOpacity {
			get {
				return Property("windowOpacity").Value<double>();
			}
			set {
				SetProperty("windowOpacity", QVariant.FromValue<double>(value));
			}
		}
		[Q_PROPERTY("bool", "windowModified")]
		public bool WindowModified {
			get {
				return Property("windowModified").Value<bool>();
			}
			set {
				SetProperty("windowModified", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QString", "toolTip")]
		public string ToolTip {
			get {
				return Property("toolTip").Value<string>();
			}
			set {
				SetProperty("toolTip", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("QString", "statusTip")]
		public string StatusTip {
			get {
				return Property("statusTip").Value<string>();
			}
			set {
				SetProperty("statusTip", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("QString", "whatsThis")]
		public string WhatsThis {
			get {
				return Property("whatsThis").Value<string>();
			}
			set {
				SetProperty("whatsThis", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("QString", "accessibleName")]
		public string AccessibleName {
			get {
				return Property("accessibleName").Value<string>();
			}
			set {
				SetProperty("accessibleName", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("QString", "accessibleDescription")]
		public string AccessibleDescription {
			get {
				return Property("accessibleDescription").Value<string>();
			}
			set {
				SetProperty("accessibleDescription", QVariant.FromValue<string>(value));
			}
		}
		[Q_PROPERTY("Qt::LayoutDirection", "layoutDirection")]
		public Qt.LayoutDirection LayoutDirection {
			get {
				return Property("layoutDirection").Value<Qt.LayoutDirection>();
			}
			set {
				SetProperty("layoutDirection", QVariant.FromValue<Qt.LayoutDirection>(value));
			}
		}
		[Q_PROPERTY("bool", "autoFillBackground")]
		public bool AutoFillBackground {
			get {
				return Property("autoFillBackground").Value<bool>();
			}
			set {
				SetProperty("autoFillBackground", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QString", "styleSheet")]
		public string StyleSheet {
			get {
				return Property("styleSheet").Value<string>();
			}
			set {
				SetProperty("styleSheet", QVariant.FromValue<string>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QWidget(QWidget parent, int f) : this((Type) null) {
			CreateProxy();
			NewQWidget(parent,f);
		}
		[SmokeMethod("QWidget(QWidget*, Qt::WindowFlags)")]
		private void NewQWidget(QWidget parent, int f) {
			ProxyQWidget().NewQWidget(parent,f);
		}
		public QWidget(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQWidget(parent);
		}
		[SmokeMethod("QWidget(QWidget*)")]
		private void NewQWidget(QWidget parent) {
			ProxyQWidget().NewQWidget(parent);
		}
		public QWidget() : this((Type) null) {
			CreateProxy();
			NewQWidget();
		}
		[SmokeMethod("QWidget()")]
		private void NewQWidget() {
			ProxyQWidget().NewQWidget();
		}
		[SmokeMethod("devType() const")]
		public int DevType() {
			return ProxyQWidget().DevType();
		}
		[SmokeMethod("winId() const")]
		public ulong WinId() {
			return ProxyQWidget().WinId();
		}
		[SmokeMethod("createWinId()")]
		public void CreateWinId() {
			ProxyQWidget().CreateWinId();
		}
		[SmokeMethod("internalWinId() const")]
		public ulong InternalWinId() {
			return ProxyQWidget().InternalWinId();
		}
		[SmokeMethod("style() const")]
		public QStyle Style() {
			return ProxyQWidget().Style();
		}
		[SmokeMethod("setStyle(QStyle*)")]
		public void SetStyle(QStyle arg1) {
			ProxyQWidget().SetStyle(arg1);
		}
		[SmokeMethod("isTopLevel() const")]
		public bool IsTopLevel() {
			return ProxyQWidget().IsTopLevel();
		}
		[SmokeMethod("isWindow() const")]
		public bool IsWindow() {
			return ProxyQWidget().IsWindow();
		}
		[SmokeMethod("isModal() const")]
		public bool IsModal() {
			return ProxyQWidget().IsModal();
		}
		[SmokeMethod("isEnabled() const")]
		public bool IsEnabled() {
			return ProxyQWidget().IsEnabled();
		}
		[SmokeMethod("isEnabledTo(QWidget*) const")]
		public bool IsEnabledTo(QWidget arg1) {
			return ProxyQWidget().IsEnabledTo(arg1);
		}
		[SmokeMethod("isEnabledToTLW() const")]
		public bool IsEnabledToTLW() {
			return ProxyQWidget().IsEnabledToTLW();
		}
		[SmokeMethod("width() const")]
		public int Width() {
			return ProxyQWidget().Width();
		}
		[SmokeMethod("height() const")]
		public int Height() {
			return ProxyQWidget().Height();
		}
		[SmokeMethod("setMinimumSize(int, int)")]
		public void SetMinimumSize(int minw, int minh) {
			ProxyQWidget().SetMinimumSize(minw,minh);
		}
		[SmokeMethod("setMaximumSize(int, int)")]
		public void SetMaximumSize(int maxw, int maxh) {
			ProxyQWidget().SetMaximumSize(maxw,maxh);
		}
		[SmokeMethod("setSizeIncrement(int, int)")]
		public void SetSizeIncrement(int w, int h) {
			ProxyQWidget().SetSizeIncrement(w,h);
		}
		[SmokeMethod("setBaseSize(int, int)")]
		public void SetBaseSize(int basew, int baseh) {
			ProxyQWidget().SetBaseSize(basew,baseh);
		}
		[SmokeMethod("setFixedSize(const QSize&)")]
		public void SetFixedSize(QSize arg1) {
			ProxyQWidget().SetFixedSize(arg1);
		}
		[SmokeMethod("setFixedSize(int, int)")]
		public void SetFixedSize(int w, int h) {
			ProxyQWidget().SetFixedSize(w,h);
		}
		[SmokeMethod("setFixedWidth(int)")]
		public void SetFixedWidth(int w) {
			ProxyQWidget().SetFixedWidth(w);
		}
		[SmokeMethod("setFixedHeight(int)")]
		public void SetFixedHeight(int h) {
			ProxyQWidget().SetFixedHeight(h);
		}
		[SmokeMethod("mapToGlobal(const QPoint&) const")]
		public QPoint MapToGlobal(QPoint arg1) {
			return ProxyQWidget().MapToGlobal(arg1);
		}
		[SmokeMethod("mapFromGlobal(const QPoint&) const")]
		public QPoint MapFromGlobal(QPoint arg1) {
			return ProxyQWidget().MapFromGlobal(arg1);
		}
		[SmokeMethod("mapToParent(const QPoint&) const")]
		public QPoint MapToParent(QPoint arg1) {
			return ProxyQWidget().MapToParent(arg1);
		}
		[SmokeMethod("mapFromParent(const QPoint&) const")]
		public QPoint MapFromParent(QPoint arg1) {
			return ProxyQWidget().MapFromParent(arg1);
		}
		[SmokeMethod("mapTo(QWidget*, const QPoint&) const")]
		public QPoint MapTo(QWidget arg1, QPoint arg2) {
			return ProxyQWidget().MapTo(arg1,arg2);
		}
		[SmokeMethod("mapFrom(QWidget*, const QPoint&) const")]
		public QPoint MapFrom(QWidget arg1, QPoint arg2) {
			return ProxyQWidget().MapFrom(arg1,arg2);
		}
		[SmokeMethod("window() const")]
		public QWidget Window() {
			return ProxyQWidget().Window();
		}
		[SmokeMethod("topLevelWidget() const")]
		public QWidget TopLevelWidget() {
			return ProxyQWidget().TopLevelWidget();
		}
		[SmokeMethod("setBackgroundRole(QPalette::ColorRole)")]
		public void SetBackgroundRole(QPalette.ColorRole arg1) {
			ProxyQWidget().SetBackgroundRole(arg1);
		}
		[SmokeMethod("backgroundRole() const")]
		public QPalette.ColorRole BackgroundRole() {
			return ProxyQWidget().BackgroundRole();
		}
		[SmokeMethod("setForegroundRole(QPalette::ColorRole)")]
		public void SetForegroundRole(QPalette.ColorRole arg1) {
			ProxyQWidget().SetForegroundRole(arg1);
		}
		[SmokeMethod("foregroundRole() const")]
		public QPalette.ColorRole ForegroundRole() {
			return ProxyQWidget().ForegroundRole();
		}
		[SmokeMethod("fontMetrics() const")]
		public QFontMetrics FontMetrics() {
			return ProxyQWidget().FontMetrics();
		}
		[SmokeMethod("fontInfo() const")]
		public QFontInfo FontInfo() {
			return ProxyQWidget().FontInfo();
		}
		[SmokeMethod("unsetCursor()")]
		public void UnsetCursor() {
			ProxyQWidget().UnsetCursor();
		}
		[SmokeMethod("hasMouseTracking() const")]
		public bool HasMouseTracking() {
			return ProxyQWidget().HasMouseTracking();
		}
		[SmokeMethod("underMouse() const")]
		public bool UnderMouse() {
			return ProxyQWidget().UnderMouse();
		}
		[SmokeMethod("setMask(const QBitmap&)")]
		public void SetMask(QBitmap arg1) {
			ProxyQWidget().SetMask(arg1);
		}
		[SmokeMethod("setMask(const QRegion&)")]
		public void SetMask(QRegion arg1) {
			ProxyQWidget().SetMask(arg1);
		}
		[SmokeMethod("mask() const")]
		public QRegion Mask() {
			return ProxyQWidget().Mask();
		}
		[SmokeMethod("clearMask()")]
		public void ClearMask() {
			ProxyQWidget().ClearMask();
		}
		[SmokeMethod("setWindowRole(const QString&)")]
		public void SetWindowRole(string arg1) {
			ProxyQWidget().SetWindowRole(arg1);
		}
		[SmokeMethod("windowRole() const")]
		public string WindowRole() {
			return ProxyQWidget().WindowRole();
		}
		[SmokeMethod("isWindowModified() const")]
		public bool IsWindowModified() {
			return ProxyQWidget().IsWindowModified();
		}
		[SmokeMethod("unsetLayoutDirection()")]
		public void UnsetLayoutDirection() {
			ProxyQWidget().UnsetLayoutDirection();
		}
		[SmokeMethod("isRightToLeft() const")]
		public bool IsRightToLeft() {
			return ProxyQWidget().IsRightToLeft();
		}
		[SmokeMethod("isLeftToRight() const")]
		public bool IsLeftToRight() {
			return ProxyQWidget().IsLeftToRight();
		}
		[SmokeMethod("activateWindow()")]
		public void ActivateWindow() {
			ProxyQWidget().ActivateWindow();
		}
		[SmokeMethod("clearFocus()")]
		public void ClearFocus() {
			ProxyQWidget().ClearFocus();
		}
		[SmokeMethod("hasFocus() const")]
		public bool HasFocus() {
			return ProxyQWidget().HasFocus();
		}
		[SmokeMethod("setFocusProxy(QWidget*)")]
		public void SetFocusProxy(QWidget arg1) {
			ProxyQWidget().SetFocusProxy(arg1);
		}
		[SmokeMethod("focusProxy() const")]
		public QWidget FocusProxy() {
			return ProxyQWidget().FocusProxy();
		}
		[SmokeMethod("grabMouse()")]
		public void GrabMouse() {
			ProxyQWidget().GrabMouse();
		}
		[SmokeMethod("grabMouse(const QCursor&)")]
		public void GrabMouse(QCursor arg1) {
			ProxyQWidget().GrabMouse(arg1);
		}
		[SmokeMethod("releaseMouse()")]
		public void ReleaseMouse() {
			ProxyQWidget().ReleaseMouse();
		}
		[SmokeMethod("grabKeyboard()")]
		public void GrabKeyboard() {
			ProxyQWidget().GrabKeyboard();
		}
		[SmokeMethod("releaseKeyboard()")]
		public void ReleaseKeyboard() {
			ProxyQWidget().ReleaseKeyboard();
		}
		[SmokeMethod("grabShortcut(const QKeySequence&, Qt::ShortcutContext)")]
		public int GrabShortcut(QKeySequence key, Qt.ShortcutContext context) {
			return ProxyQWidget().GrabShortcut(key,context);
		}
		[SmokeMethod("grabShortcut(const QKeySequence&)")]
		public int GrabShortcut(QKeySequence key) {
			return ProxyQWidget().GrabShortcut(key);
		}
		[SmokeMethod("releaseShortcut(int)")]
		public void ReleaseShortcut(int id) {
			ProxyQWidget().ReleaseShortcut(id);
		}
		[SmokeMethod("setShortcutEnabled(int, bool)")]
		public void SetShortcutEnabled(int id, bool enable) {
			ProxyQWidget().SetShortcutEnabled(id,enable);
		}
		[SmokeMethod("setShortcutEnabled(int)")]
		public void SetShortcutEnabled(int id) {
			ProxyQWidget().SetShortcutEnabled(id);
		}
		[SmokeMethod("setShortcutAutoRepeat(int, bool)")]
		public void SetShortcutAutoRepeat(int id, bool enable) {
			ProxyQWidget().SetShortcutAutoRepeat(id,enable);
		}
		[SmokeMethod("setShortcutAutoRepeat(int)")]
		public void SetShortcutAutoRepeat(int id) {
			ProxyQWidget().SetShortcutAutoRepeat(id);
		}
		[SmokeMethod("update(int, int, int, int)")]
		public void Update(int x, int y, int w, int h) {
			ProxyQWidget().Update(x,y,w,h);
		}
		[SmokeMethod("update(const QRect&)")]
		public void Update(QRect arg1) {
			ProxyQWidget().Update(arg1);
		}
		[SmokeMethod("update(const QRegion&)")]
		public void Update(QRegion arg1) {
			ProxyQWidget().Update(arg1);
		}
		[SmokeMethod("repaint(int, int, int, int)")]
		public void Repaint(int x, int y, int w, int h) {
			ProxyQWidget().Repaint(x,y,w,h);
		}
		[SmokeMethod("repaint(const QRect&)")]
		public void Repaint(QRect arg1) {
			ProxyQWidget().Repaint(arg1);
		}
		[SmokeMethod("repaint(const QRegion&)")]
		public void Repaint(QRegion arg1) {
			ProxyQWidget().Repaint(arg1);
		}
		[SmokeMethod("stackUnder(QWidget*)")]
		public void StackUnder(QWidget arg1) {
			ProxyQWidget().StackUnder(arg1);
		}
		[SmokeMethod("move(int, int)")]
		public void Move(int x, int y) {
			ProxyQWidget().Move(x,y);
		}
		[SmokeMethod("move(const QPoint&)")]
		public void Move(QPoint arg1) {
			ProxyQWidget().Move(arg1);
		}
		[SmokeMethod("resize(int, int)")]
		public void Resize(int w, int h) {
			ProxyQWidget().Resize(w,h);
		}
		[SmokeMethod("resize(const QSize&)")]
		public void Resize(QSize arg1) {
			ProxyQWidget().Resize(arg1);
		}
		[SmokeMethod("setGeometry(int, int, int, int)")]
		public void SetGeometry(int x, int y, int w, int h) {
			ProxyQWidget().SetGeometry(x,y,w,h);
		}
		[SmokeMethod("saveGeometry() const")]
		public QByteArray SaveGeometry() {
			return ProxyQWidget().SaveGeometry();
		}
		[SmokeMethod("restoreGeometry(const QByteArray&)")]
		public bool RestoreGeometry(QByteArray geometry) {
			return ProxyQWidget().RestoreGeometry(geometry);
		}
		[SmokeMethod("adjustSize()")]
		public void AdjustSize() {
			ProxyQWidget().AdjustSize();
		}
		[SmokeMethod("isVisible() const")]
		public bool IsVisible() {
			return ProxyQWidget().IsVisible();
		}
		[SmokeMethod("isVisibleTo(QWidget*) const")]
		public bool IsVisibleTo(QWidget arg1) {
			return ProxyQWidget().IsVisibleTo(arg1);
		}
		[SmokeMethod("isHidden() const")]
		public bool IsHidden() {
			return ProxyQWidget().IsHidden();
		}
		[SmokeMethod("isMinimized() const")]
		public bool IsMinimized() {
			return ProxyQWidget().IsMinimized();
		}
		[SmokeMethod("isMaximized() const")]
		public bool IsMaximized() {
			return ProxyQWidget().IsMaximized();
		}
		[SmokeMethod("isFullScreen() const")]
		public bool IsFullScreen() {
			return ProxyQWidget().IsFullScreen();
		}
		[SmokeMethod("windowState() const")]
		public int WindowState() {
			return ProxyQWidget().WindowState();
		}
		[SmokeMethod("setWindowState(Qt::WindowStates)")]
		public void SetWindowState(int state) {
			ProxyQWidget().SetWindowState(state);
		}
		[SmokeMethod("overrideWindowState(Qt::WindowStates)")]
		public void OverrideWindowState(int state) {
			ProxyQWidget().OverrideWindowState(state);
		}
		[SmokeMethod("sizeHint() const")]
		public virtual QSize SizeHint() {
			return ProxyQWidget().SizeHint();
		}
		[SmokeMethod("setSizePolicy(QSizePolicy::Policy, QSizePolicy::Policy)")]
		public void SetSizePolicy(QSizePolicy.Policy horizontal, QSizePolicy.Policy vertical) {
			ProxyQWidget().SetSizePolicy(horizontal,vertical);
		}
		[SmokeMethod("heightForWidth(int) const")]
		public virtual int HeightForWidth(int arg1) {
			return ProxyQWidget().HeightForWidth(arg1);
		}
		[SmokeMethod("visibleRegion() const")]
		public QRegion VisibleRegion() {
			return ProxyQWidget().VisibleRegion();
		}
		[SmokeMethod("setContentsMargins(int, int, int, int)")]
		public void SetContentsMargins(int left, int top, int right, int bottom) {
			ProxyQWidget().SetContentsMargins(left,top,right,bottom);
		}
		[SmokeMethod("getContentsMargins(int*, int*, int*, int*) const")]
		public void GetContentsMargins(out int left, out int top, out int right, out int bottom) {
			ProxyQWidget().GetContentsMargins(out left,out top,out right,out bottom);
		}
		[SmokeMethod("contentsRect() const")]
		public QRect ContentsRect() {
			return ProxyQWidget().ContentsRect();
		}
		[SmokeMethod("layout() const")]
		public QLayout Layout() {
			return ProxyQWidget().Layout();
		}
		[SmokeMethod("setLayout(QLayout*)")]
		public void SetLayout(QLayout arg1) {
			ProxyQWidget().SetLayout(arg1);
		}
		[SmokeMethod("updateGeometry()")]
		public void UpdateGeometry() {
			ProxyQWidget().UpdateGeometry();
		}
		[SmokeMethod("setParent(QWidget*)")]
		public new void SetParent(QWidget parent) {
			ProxyQWidget().SetParent(parent);
		}
		[SmokeMethod("setParent(QWidget*, Qt::WindowFlags)")]
		public new void SetParent(QWidget parent, int f) {
			ProxyQWidget().SetParent(parent,f);
		}
		[SmokeMethod("scroll(int, int)")]
		public void Scroll(int dx, int dy) {
			ProxyQWidget().Scroll(dx,dy);
		}
		[SmokeMethod("scroll(int, int, const QRect&)")]
		public void Scroll(int dx, int dy, QRect arg3) {
			ProxyQWidget().Scroll(dx,dy,arg3);
		}
		[SmokeMethod("focusWidget() const")]
		public QWidget FocusWidget() {
			return ProxyQWidget().FocusWidget();
		}
		[SmokeMethod("nextInFocusChain() const")]
		public QWidget NextInFocusChain() {
			return ProxyQWidget().NextInFocusChain();
		}
		[SmokeMethod("addAction(QAction*)")]
		public void AddAction(QAction action) {
			ProxyQWidget().AddAction(action);
		}
		[SmokeMethod("addActions(QList<QAction*>)")]
		public void AddActions(List<QAction> actions) {
			ProxyQWidget().AddActions(actions);
		}
		[SmokeMethod("insertAction(QAction*, QAction*)")]
		public void InsertAction(QAction before, QAction action) {
			ProxyQWidget().InsertAction(before,action);
		}
		[SmokeMethod("insertActions(QAction*, QList<QAction*>)")]
		public void InsertActions(QAction before, List<QAction> actions) {
			ProxyQWidget().InsertActions(before,actions);
		}
		[SmokeMethod("removeAction(QAction*)")]
		public void RemoveAction(QAction action) {
			ProxyQWidget().RemoveAction(action);
		}
		[SmokeMethod("actions() const")]
		public List<QAction> Actions() {
			return ProxyQWidget().Actions();
		}
		[SmokeMethod("parentWidget() const")]
		public QWidget ParentWidget() {
			return ProxyQWidget().ParentWidget();
		}
		[SmokeMethod("setWindowFlags(Qt::WindowFlags)")]
		public void SetWindowFlags(int type) {
			ProxyQWidget().SetWindowFlags(type);
		}
		[SmokeMethod("windowFlags() const")]
		public int WindowFlags() {
			return ProxyQWidget().WindowFlags();
		}
		[SmokeMethod("overrideWindowFlags(Qt::WindowFlags)")]
		public void OverrideWindowFlags(int type) {
			ProxyQWidget().OverrideWindowFlags(type);
		}
		[SmokeMethod("windowType() const")]
		public Qt.WindowType WindowType() {
			return ProxyQWidget().WindowType();
		}
		[SmokeMethod("childAt(int, int) const")]
		public QWidget ChildAt(int x, int y) {
			return ProxyQWidget().ChildAt(x,y);
		}
		[SmokeMethod("childAt(const QPoint&) const")]
		public QWidget ChildAt(QPoint p) {
			return ProxyQWidget().ChildAt(p);
		}
		[SmokeMethod("setAttribute(Qt::WidgetAttribute, bool)")]
		public void SetAttribute(Qt.WidgetAttribute arg1, bool on) {
			ProxyQWidget().SetAttribute(arg1,on);
		}
		[SmokeMethod("setAttribute(Qt::WidgetAttribute)")]
		public void SetAttribute(Qt.WidgetAttribute arg1) {
			ProxyQWidget().SetAttribute(arg1);
		}
		[SmokeMethod("testAttribute(Qt::WidgetAttribute) const")]
		public bool TestAttribute(Qt.WidgetAttribute arg1) {
			return ProxyQWidget().TestAttribute(arg1);
		}
		[SmokeMethod("paintEngine() const")]
		public QPaintEngine PaintEngine() {
			return ProxyQWidget().PaintEngine();
		}
		[SmokeMethod("ensurePolished() const")]
		public void EnsurePolished() {
			ProxyQWidget().EnsurePolished();
		}
		[SmokeMethod("inputContext()")]
		public QInputContext InputContext() {
			return ProxyQWidget().InputContext();
		}
		[SmokeMethod("setInputContext(QInputContext*)")]
		public void SetInputContext(QInputContext arg1) {
			ProxyQWidget().SetInputContext(arg1);
		}
		[SmokeMethod("isAncestorOf(const QWidget*) const")]
		public bool IsAncestorOf(QWidget child) {
			return ProxyQWidget().IsAncestorOf(child);
		}
		// void setWindowSurface(QWindowSurface* arg1); >>>> NOT CONVERTED
		// QWindowSurface* windowSurface(); >>>> NOT CONVERTED
		[SmokeMethod("inputMethodQuery(Qt::InputMethodQuery) const")]
		public virtual QVariant InputMethodQuery(Qt.InputMethodQuery arg1) {
			return ProxyQWidget().InputMethodQuery(arg1);
		}
		[Q_SLOT("void setDisabled(bool)")]
		[SmokeMethod("setDisabled(bool)")]
		public void SetDisabled(bool arg1) {
			ProxyQWidget().SetDisabled(arg1);
		}
		[Q_SLOT("void setFocus()")]
		[SmokeMethod("setFocus()")]
		public void SetFocus() {
			ProxyQWidget().SetFocus();
		}
		[Q_SLOT("void update()")]
		[SmokeMethod("update()")]
		public void Update() {
			ProxyQWidget().Update();
		}
		[Q_SLOT("void repaint()")]
		[SmokeMethod("repaint()")]
		public void Repaint() {
			ProxyQWidget().Repaint();
		}
		[Q_SLOT("void setHidden(bool)")]
		[SmokeMethod("setHidden(bool)")]
		public void SetHidden(bool hidden) {
			ProxyQWidget().SetHidden(hidden);
		}
		[Q_SLOT("void show()")]
		[SmokeMethod("show()")]
		public void Show() {
			ProxyQWidget().Show();
		}
		[Q_SLOT("void hide()")]
		[SmokeMethod("hide()")]
		public void Hide() {
			ProxyQWidget().Hide();
		}
		[Q_SLOT("void setShown(bool)")]
		[SmokeMethod("setShown(bool)")]
		public void SetShown(bool shown) {
			ProxyQWidget().SetShown(shown);
		}
		[Q_SLOT("void showMinimized()")]
		[SmokeMethod("showMinimized()")]
		public void ShowMinimized() {
			ProxyQWidget().ShowMinimized();
		}
		[Q_SLOT("void showMaximized()")]
		[SmokeMethod("showMaximized()")]
		public void ShowMaximized() {
			ProxyQWidget().ShowMaximized();
		}
		[Q_SLOT("void showFullScreen()")]
		[SmokeMethod("showFullScreen()")]
		public void ShowFullScreen() {
			ProxyQWidget().ShowFullScreen();
		}
		[Q_SLOT("void showNormal()")]
		[SmokeMethod("showNormal()")]
		public void ShowNormal() {
			ProxyQWidget().ShowNormal();
		}
		[Q_SLOT("bool close()")]
		[SmokeMethod("close()")]
		public bool Close() {
			return ProxyQWidget().Close();
		}
		[Q_SLOT("void raise()")]
		[SmokeMethod("raise()")]
		public void Raise() {
			ProxyQWidget().Raise();
		}
		[Q_SLOT("void lower()")]
		[SmokeMethod("lower()")]
		public void Lower() {
			ProxyQWidget().Lower();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQWidget().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQWidget().Tr(s);
		}
		[SmokeMethod("setTabOrder(QWidget*, QWidget*)")]
		public static void SetTabOrder(QWidget arg1, QWidget arg2) {
			StaticQWidget().SetTabOrder(arg1,arg2);
		}
		[SmokeMethod("mouseGrabber()")]
		public static QWidget MouseGrabber() {
			return StaticQWidget().MouseGrabber();
		}
		[SmokeMethod("keyboardGrabber()")]
		public static QWidget KeyboardGrabber() {
			return StaticQWidget().KeyboardGrabber();
		}
		[SmokeMethod("find(WId)")]
		public static QWidget Find(ulong arg1) {
			return StaticQWidget().Find(arg1);
		}
		[SmokeMethod("event(QEvent*)")]
		public new bool Event(QEvent arg1) {
			return ProxyQWidget().Event(arg1);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected virtual void MousePressEvent(QMouseEvent arg1) {
			ProxyQWidget().MousePressEvent(arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected virtual void MouseReleaseEvent(QMouseEvent arg1) {
			ProxyQWidget().MouseReleaseEvent(arg1);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected virtual void MouseDoubleClickEvent(QMouseEvent arg1) {
			ProxyQWidget().MouseDoubleClickEvent(arg1);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected virtual void MouseMoveEvent(QMouseEvent arg1) {
			ProxyQWidget().MouseMoveEvent(arg1);
		}
		[SmokeMethod("wheelEvent(QWheelEvent*)")]
		protected virtual void WheelEvent(QWheelEvent arg1) {
			ProxyQWidget().WheelEvent(arg1);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected virtual void KeyPressEvent(QKeyEvent arg1) {
			ProxyQWidget().KeyPressEvent(arg1);
		}
		[SmokeMethod("keyReleaseEvent(QKeyEvent*)")]
		protected virtual void KeyReleaseEvent(QKeyEvent arg1) {
			ProxyQWidget().KeyReleaseEvent(arg1);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected virtual void FocusInEvent(QFocusEvent arg1) {
			ProxyQWidget().FocusInEvent(arg1);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected virtual void FocusOutEvent(QFocusEvent arg1) {
			ProxyQWidget().FocusOutEvent(arg1);
		}
		[SmokeMethod("enterEvent(QEvent*)")]
		protected virtual void EnterEvent(QEvent arg1) {
			ProxyQWidget().EnterEvent(arg1);
		}
		[SmokeMethod("leaveEvent(QEvent*)")]
		protected virtual void LeaveEvent(QEvent arg1) {
			ProxyQWidget().LeaveEvent(arg1);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected virtual void PaintEvent(QPaintEvent arg1) {
			ProxyQWidget().PaintEvent(arg1);
		}
		[SmokeMethod("moveEvent(QMoveEvent*)")]
		protected virtual void MoveEvent(QMoveEvent arg1) {
			ProxyQWidget().MoveEvent(arg1);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected virtual void ResizeEvent(QResizeEvent arg1) {
			ProxyQWidget().ResizeEvent(arg1);
		}
		[SmokeMethod("closeEvent(QCloseEvent*)")]
		protected virtual void CloseEvent(QCloseEvent arg1) {
			ProxyQWidget().CloseEvent(arg1);
		}
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected virtual void ContextMenuEvent(QContextMenuEvent arg1) {
			ProxyQWidget().ContextMenuEvent(arg1);
		}
		[SmokeMethod("tabletEvent(QTabletEvent*)")]
		protected virtual void TabletEvent(QTabletEvent arg1) {
			ProxyQWidget().TabletEvent(arg1);
		}
		[SmokeMethod("actionEvent(QActionEvent*)")]
		protected virtual void ActionEvent(QActionEvent arg1) {
			ProxyQWidget().ActionEvent(arg1);
		}
		[SmokeMethod("dragEnterEvent(QDragEnterEvent*)")]
		protected virtual void DragEnterEvent(QDragEnterEvent arg1) {
			ProxyQWidget().DragEnterEvent(arg1);
		}
		[SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
		protected virtual void DragMoveEvent(QDragMoveEvent arg1) {
			ProxyQWidget().DragMoveEvent(arg1);
		}
		[SmokeMethod("dragLeaveEvent(QDragLeaveEvent*)")]
		protected virtual void DragLeaveEvent(QDragLeaveEvent arg1) {
			ProxyQWidget().DragLeaveEvent(arg1);
		}
		[SmokeMethod("dropEvent(QDropEvent*)")]
		protected virtual void DropEvent(QDropEvent arg1) {
			ProxyQWidget().DropEvent(arg1);
		}
		[SmokeMethod("showEvent(QShowEvent*)")]
		public virtual void ShowEvent(QShowEvent arg1) {
			ProxyQWidget().ShowEvent(arg1);
		}
		[SmokeMethod("hideEvent(QHideEvent*)")]
		protected virtual void HideEvent(QHideEvent arg1) {
			ProxyQWidget().HideEvent(arg1);
		}
		[SmokeMethod("changeEvent(QEvent*)")]
		protected virtual void ChangeEvent(QEvent arg1) {
			ProxyQWidget().ChangeEvent(arg1);
		}
		[SmokeMethod("metric(QPaintDevice::PaintDeviceMetric) const")]
		protected int Metric(IQPaintDevice arg1) {
			return ProxyQWidget().Metric(arg1);
		}
		[SmokeMethod("inputMethodEvent(QInputMethodEvent*)")]
		protected virtual void InputMethodEvent(QInputMethodEvent arg1) {
			ProxyQWidget().InputMethodEvent(arg1);
		}
		[SmokeMethod("resetInputContext()")]
		protected void ResetInputContext() {
			ProxyQWidget().ResetInputContext();
		}
		[SmokeMethod("create(WId, bool, bool)")]
		protected void Create(ulong arg1, bool initializeWindow, bool destroyOldWindow) {
			ProxyQWidget().Create(arg1,initializeWindow,destroyOldWindow);
		}
		[SmokeMethod("create(WId, bool)")]
		protected void Create(ulong arg1, bool initializeWindow) {
			ProxyQWidget().Create(arg1,initializeWindow);
		}
		[SmokeMethod("create(WId)")]
		protected void Create(ulong arg1) {
			ProxyQWidget().Create(arg1);
		}
		[SmokeMethod("create()")]
		protected void Create() {
			ProxyQWidget().Create();
		}
		[SmokeMethod("destroy(bool, bool)")]
		protected void Destroy(bool destroyWindow, bool destroySubWindows) {
			ProxyQWidget().Destroy(destroyWindow,destroySubWindows);
		}
		[SmokeMethod("destroy(bool)")]
		protected void Destroy(bool destroyWindow) {
			ProxyQWidget().Destroy(destroyWindow);
		}
		[SmokeMethod("destroy()")]
		protected void Destroy() {
			ProxyQWidget().Destroy();
		}
		[SmokeMethod("focusNextPrevChild(bool)")]
		protected virtual bool FocusNextPrevChild(bool next) {
			return ProxyQWidget().FocusNextPrevChild(next);
		}
		[SmokeMethod("focusNextChild()")]
		protected bool FocusNextChild() {
			return ProxyQWidget().FocusNextChild();
		}
		[SmokeMethod("focusPreviousChild()")]
		protected bool FocusPreviousChild() {
			return ProxyQWidget().FocusPreviousChild();
		}
		[SmokeMethod("styleChange(QStyle&)")]
		public virtual void StyleChange(QStyle arg1) {
			ProxyQWidget().StyleChange(arg1);
		}
		[SmokeMethod("enabledChange(bool)")]
		protected virtual void EnabledChange(bool arg1) {
			ProxyQWidget().EnabledChange(arg1);
		}
		[SmokeMethod("paletteChange(const QPalette&)")]
		protected virtual void PaletteChange(QPalette arg1) {
			ProxyQWidget().PaletteChange(arg1);
		}
		[SmokeMethod("fontChange(const QFont&)")]
		protected virtual void FontChange(QFont arg1) {
			ProxyQWidget().FontChange(arg1);
		}
		[SmokeMethod("windowActivationChange(bool)")]
		protected virtual void WindowActivationChange(bool arg1) {
			ProxyQWidget().WindowActivationChange(arg1);
		}
		[SmokeMethod("languageChange()")]
		protected virtual void LanguageChange() {
			ProxyQWidget().LanguageChange();
		}
		[Q_SLOT("void updateMicroFocus()")]
		[SmokeMethod("updateMicroFocus()")]
		protected void UpdateMicroFocus() {
			ProxyQWidget().UpdateMicroFocus();
		}
		~QWidget() {
			DisposeQWidget();
		}
		public new void Dispose() {
			DisposeQWidget();
		}
		[SmokeMethod("~QWidget()")]
		private void DisposeQWidget() {
			ProxyQWidget().DisposeQWidget();
		}
		[SmokeMethod("paintingActive() const")]
		public bool PaintingActive() {
			return ProxyQWidget().PaintingActive();
		}
		[SmokeMethod("widthMM() const")]
		public int WidthMM() {
			return ProxyQWidget().WidthMM();
		}
		[SmokeMethod("heightMM() const")]
		public int HeightMM() {
			return ProxyQWidget().HeightMM();
		}
		[SmokeMethod("logicalDpiX() const")]
		public int LogicalDpiX() {
			return ProxyQWidget().LogicalDpiX();
		}
		[SmokeMethod("logicalDpiY() const")]
		public int LogicalDpiY() {
			return ProxyQWidget().LogicalDpiY();
		}
		[SmokeMethod("physicalDpiX() const")]
		public int PhysicalDpiX() {
			return ProxyQWidget().PhysicalDpiX();
		}
		[SmokeMethod("physicalDpiY() const")]
		public int PhysicalDpiY() {
			return ProxyQWidget().PhysicalDpiY();
		}
		[SmokeMethod("numColors() const")]
		public int NumColors() {
			return ProxyQWidget().NumColors();
		}
		[SmokeMethod("depth() const")]
		public int Depth() {
			return ProxyQWidget().Depth();
		}
		protected new IQWidgetSignals Emit {
			get {
				return (IQWidgetSignals) Q_EMIT;
			}
		}
	}

	public interface IQWidgetSignals : IQObjectSignals {
		[Q_SIGNAL("void customContextMenuRequested(const QPoint&)")]
		void CustomContextMenuRequested(QPoint pos);
	}
}
