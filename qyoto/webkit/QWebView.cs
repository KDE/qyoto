//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	/// <remarks> See <see cref="IQWebViewSignals"></see> for signals emitted by QWebView
	/// </remarks>

	[SmokeClass("QWebView")]
	public class QWebView : QWidget, IDisposable {
 		protected QWebView(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QWebView), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QWebView() {
			staticInterceptor = new SmokeInvocation(typeof(QWebView), null);
		}
		[Q_PROPERTY("QString", "title")]
		public string Title {
			get { return (string) interceptor.Invoke("title", "title()", typeof(string)); }
		}
		[Q_PROPERTY("QUrl", "url")]
		public QUrl Url {
			get { return (QUrl) interceptor.Invoke("url", "url()", typeof(QUrl)); }
			set { interceptor.Invoke("setUrl#", "setUrl(QUrl)", typeof(void), typeof(QUrl), value); }
		}
		[Q_PROPERTY("QIcon", "icon")]
		public QIcon icon {
			get { return (QIcon) interceptor.Invoke("icon", "icon()", typeof(QIcon)); }
		}
		[Q_PROPERTY("QString", "selectedText")]
		public string SelectedText {
			get { return (string) interceptor.Invoke("selectedText", "selectedText()", typeof(string)); }
		}
		[Q_PROPERTY("bool", "modified")]
		public bool Modified {
			get { return (bool) interceptor.Invoke("isModified", "isModified()", typeof(bool)); }
		}
		[Q_PROPERTY("qreal", "textSizeMultiplier")]
		public double TextSizeMultiplier {
			get { return (double) interceptor.Invoke("textSizeMultiplier", "textSizeMultiplier()", typeof(double)); }
			set { interceptor.Invoke("setTextSizeMultiplier$", "setTextSizeMultiplier(qreal)", typeof(void), typeof(double), value); }
		}
		public QWebView(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QWebView#", "QWebView(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public QWebView() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QWebView", "QWebView()", typeof(void));
		}
		public QWebPage Page() {
			return (QWebPage) interceptor.Invoke("page", "page() const", typeof(QWebPage));
		}
		public void SetPage(QWebPage page) {
			interceptor.Invoke("setPage#", "setPage(QWebPage*)", typeof(void), typeof(QWebPage), page);
		}
		public void Load(QUrl url) {
			interceptor.Invoke("load#", "load(const QUrl&)", typeof(void), typeof(QUrl), url);
		}
		public void Load(QNetworkRequest request, QNetworkAccessManager.Operation operation, QByteArray body) {
			interceptor.Invoke("load#$#", "load(const QNetworkRequest&, QNetworkAccessManager::Operation, const QByteArray&)", typeof(void), typeof(QNetworkRequest), request, typeof(QNetworkAccessManager.Operation), operation, typeof(QByteArray), body);
		}
		public void Load(QNetworkRequest request, QNetworkAccessManager.Operation operation) {
			interceptor.Invoke("load#$", "load(const QNetworkRequest&, QNetworkAccessManager::Operation)", typeof(void), typeof(QNetworkRequest), request, typeof(QNetworkAccessManager.Operation), operation);
		}
		public void Load(QNetworkRequest request) {
			interceptor.Invoke("load#", "load(const QNetworkRequest&)", typeof(void), typeof(QNetworkRequest), request);
		}
		public void SetHtml(string html, QUrl baseUrl) {
			interceptor.Invoke("setHtml$#", "setHtml(const QString&, const QUrl&)", typeof(void), typeof(string), html, typeof(QUrl), baseUrl);
		}
		public void SetHtml(string html) {
			interceptor.Invoke("setHtml$", "setHtml(const QString&)", typeof(void), typeof(string), html);
		}
		public void SetContent(QByteArray data, string mimeType, QUrl baseUrl) {
			interceptor.Invoke("setContent#$#", "setContent(const QByteArray&, const QString&, const QUrl&)", typeof(void), typeof(QByteArray), data, typeof(string), mimeType, typeof(QUrl), baseUrl);
		}
		public void SetContent(QByteArray data, string mimeType) {
			interceptor.Invoke("setContent#$", "setContent(const QByteArray&, const QString&)", typeof(void), typeof(QByteArray), data, typeof(string), mimeType);
		}
		public void SetContent(QByteArray data) {
			interceptor.Invoke("setContent#", "setContent(const QByteArray&)", typeof(void), typeof(QByteArray), data);
		}
		public QWebHistory History() {
			return (QWebHistory) interceptor.Invoke("history", "history() const", typeof(QWebHistory));
		}
		public QWebSettings Settings() {
			return (QWebSettings) interceptor.Invoke("settings", "settings() const", typeof(QWebSettings));
		}
		public QAction PageAction(QWebPage.WebAction action) {
			return (QAction) interceptor.Invoke("pageAction$", "pageAction(QWebPage::WebAction) const", typeof(QAction), typeof(QWebPage.WebAction), action);
		}
		public void TriggerPageAction(QWebPage.WebAction action, bool arg2) {
			interceptor.Invoke("triggerPageAction$$", "triggerPageAction(QWebPage::WebAction, bool)", typeof(void), typeof(QWebPage.WebAction), action, typeof(bool), arg2);
		}
		public void TriggerPageAction(QWebPage.WebAction action) {
			interceptor.Invoke("triggerPageAction$", "triggerPageAction(QWebPage::WebAction)", typeof(void), typeof(QWebPage.WebAction), action);
		}
		[SmokeMethod("inputMethodQuery(Qt::InputMethodQuery) const")]
		public override QVariant InputMethodQuery(Qt.InputMethodQuery property) {
			return (QVariant) interceptor.Invoke("inputMethodQuery$", "inputMethodQuery(Qt::InputMethodQuery) const", typeof(QVariant), typeof(Qt.InputMethodQuery), property);
		}
		[SmokeMethod("sizeHint() const")]
		public override QSize SizeHint() {
			return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
		}
		public bool FindText(string subString, uint options) {
			return (bool) interceptor.Invoke("findText$$", "findText(const QString&, QWebPage::FindFlags)", typeof(bool), typeof(string), subString, typeof(uint), options);
		}
		public bool FindText(string subString) {
			return (bool) interceptor.Invoke("findText$", "findText(const QString&)", typeof(bool), typeof(string), subString);
		}
		[SmokeMethod("event(QEvent*)")]
		public new virtual bool Event(QEvent arg1) {
			return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
		}
		[Q_SLOT("void stop()")]
		public void Stop() {
			interceptor.Invoke("stop", "stop()", typeof(void));
		}
		[Q_SLOT("void back()")]
		public void Back() {
			interceptor.Invoke("back", "back()", typeof(void));
		}
		[Q_SLOT("void forward()")]
		public void Forward() {
			interceptor.Invoke("forward", "forward()", typeof(void));
		}
		[Q_SLOT("void reload()")]
		public void Reload() {
			interceptor.Invoke("reload", "reload()", typeof(void));
		}
		[Q_SLOT("void print(QPrinter*) const")]
		public void Print(QPrinter printer) {
			interceptor.Invoke("print#", "print(QPrinter*) const", typeof(void), typeof(QPrinter), printer);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected override void ResizeEvent(QResizeEvent e) {
			interceptor.Invoke("resizeEvent#", "resizeEvent(QResizeEvent*)", typeof(void), typeof(QResizeEvent), e);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected override void PaintEvent(QPaintEvent ev) {
			interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), ev);
		}
		[SmokeMethod("createWindow(QWebPage::WebWindowType)")]
		protected virtual QWebView CreateWindow(QWebPage.WebWindowType type) {
			return (QWebView) interceptor.Invoke("createWindow$", "createWindow(QWebPage::WebWindowType)", typeof(QWebView), typeof(QWebPage.WebWindowType), type);
		}
		[SmokeMethod("changeEvent(QEvent*)")]
		protected override void ChangeEvent(QEvent arg1) {
			interceptor.Invoke("changeEvent#", "changeEvent(QEvent*)", typeof(void), typeof(QEvent), arg1);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected override void MouseMoveEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected override void MousePressEvent(QMouseEvent arg1) {
			interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected override void MouseDoubleClickEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected override void MouseReleaseEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected override void ContextMenuEvent(QContextMenuEvent arg1) {
			interceptor.Invoke("contextMenuEvent#", "contextMenuEvent(QContextMenuEvent*)", typeof(void), typeof(QContextMenuEvent), arg1);
		}
		[SmokeMethod("wheelEvent(QWheelEvent*)")]
		protected override void WheelEvent(QWheelEvent arg1) {
			interceptor.Invoke("wheelEvent#", "wheelEvent(QWheelEvent*)", typeof(void), typeof(QWheelEvent), arg1);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected override void KeyPressEvent(QKeyEvent arg1) {
			interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
		}
		[SmokeMethod("keyReleaseEvent(QKeyEvent*)")]
		protected override void KeyReleaseEvent(QKeyEvent arg1) {
			interceptor.Invoke("keyReleaseEvent#", "keyReleaseEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
		}
		[SmokeMethod("dragEnterEvent(QDragEnterEvent*)")]
		protected override void DragEnterEvent(QDragEnterEvent arg1) {
			interceptor.Invoke("dragEnterEvent#", "dragEnterEvent(QDragEnterEvent*)", typeof(void), typeof(QDragEnterEvent), arg1);
		}
		[SmokeMethod("dragLeaveEvent(QDragLeaveEvent*)")]
		protected override void DragLeaveEvent(QDragLeaveEvent arg1) {
			interceptor.Invoke("dragLeaveEvent#", "dragLeaveEvent(QDragLeaveEvent*)", typeof(void), typeof(QDragLeaveEvent), arg1);
		}
		[SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
		protected override void DragMoveEvent(QDragMoveEvent arg1) {
			interceptor.Invoke("dragMoveEvent#", "dragMoveEvent(QDragMoveEvent*)", typeof(void), typeof(QDragMoveEvent), arg1);
		}
		[SmokeMethod("dropEvent(QDropEvent*)")]
		protected override void DropEvent(QDropEvent arg1) {
			interceptor.Invoke("dropEvent#", "dropEvent(QDropEvent*)", typeof(void), typeof(QDropEvent), arg1);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected override void FocusInEvent(QFocusEvent arg1) {
			interceptor.Invoke("focusInEvent#", "focusInEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), arg1);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected override void FocusOutEvent(QFocusEvent arg1) {
			interceptor.Invoke("focusOutEvent#", "focusOutEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), arg1);
		}
		[SmokeMethod("inputMethodEvent(QInputMethodEvent*)")]
		protected override void InputMethodEvent(QInputMethodEvent arg1) {
			interceptor.Invoke("inputMethodEvent#", "inputMethodEvent(QInputMethodEvent*)", typeof(void), typeof(QInputMethodEvent), arg1);
		}
		[SmokeMethod("focusNextPrevChild(bool)")]
		protected override bool FocusNextPrevChild(bool next) {
			return (bool) interceptor.Invoke("focusNextPrevChild$", "focusNextPrevChild(bool)", typeof(bool), typeof(bool), next);
		}
		~QWebView() {
			interceptor.Invoke("~QWebView", "~QWebView()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QWebView", "~QWebView()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQWebViewSignals Emit {
			get { return (IQWebViewSignals) Q_EMIT; }
		}
	}

	public interface IQWebViewSignals : IQWidgetSignals {
		[Q_SIGNAL("void loadStarted()")]
		void LoadStarted();
		[Q_SIGNAL("void loadProgress(int)")]
		void LoadProgress(int progress);
		[Q_SIGNAL("void loadFinished(bool)")]
		void LoadFinished(bool arg1);
		[Q_SIGNAL("void titleChanged(const QString&)")]
		void TitleChanged(string title);
		[Q_SIGNAL("void statusBarMessage(const QString&)")]
		void StatusBarMessage(string text);
		[Q_SIGNAL("void linkClicked(const QUrl&)")]
		void LinkClicked(QUrl url);
		[Q_SIGNAL("void selectionChanged()")]
		void SelectionChanged();
		[Q_SIGNAL("void iconChanged()")]
		void IconChanged();
		[Q_SIGNAL("void urlChanged(const QUrl&)")]
		void UrlChanged(QUrl url);
	}
}
