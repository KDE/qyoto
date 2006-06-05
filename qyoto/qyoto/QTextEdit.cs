//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQTextEditSignals"></see> for signals emitted by QTextEdit
	[SmokeClass("QTextEdit")]
	public class QTextEdit : QAbstractScrollArea, IDisposable {
 		protected QTextEdit(Type dummy) : base((Type) null) {}
		interface IQTextEditProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextEdit), this);
			_interceptor = (QTextEdit) realProxy.GetTransparentProxy();
		}
		private QTextEdit ProxyQTextEdit() {
			return (QTextEdit) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextEdit() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextEditProxy), null);
			_staticInterceptor = (IQTextEditProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextEditProxy StaticQTextEdit() {
			return (IQTextEditProxy) _staticInterceptor;
		}

		public enum LineWrapMode {
			NoWrap = 0,
			WidgetWidth = 1,
			FixedPixelWidth = 2,
			FixedColumnWidth = 3,
		}
		public enum AutoFormattingFlag : uint {
			AutoNone = 0,
			AutoBulletList = 0x00000001,
			AutoAll = 0xffffffff,
		}
		public enum CursorAction {
			MoveBackward = 0,
			MoveForward = 1,
			MoveWordBackward = 2,
			MoveWordForward = 3,
			MoveUp = 4,
			MoveDown = 5,
			MoveLineStart = 6,
			MoveLineEnd = 7,
			MoveHome = 8,
			MoveEnd = 9,
			MovePageUp = 10,
			MovePageDown = 11,
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QTextEdit(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQTextEdit(parent);
		}
		[SmokeMethod("QTextEdit(QWidget*)")]
		private void NewQTextEdit(QWidget parent) {
			ProxyQTextEdit().NewQTextEdit(parent);
		}
		public QTextEdit() : this((Type) null) {
			CreateProxy();
			NewQTextEdit();
		}
		[SmokeMethod("QTextEdit()")]
		private void NewQTextEdit() {
			ProxyQTextEdit().NewQTextEdit();
		}
		public QTextEdit(string text, QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQTextEdit(text,parent);
		}
		[SmokeMethod("QTextEdit(const QString&, QWidget*)")]
		private void NewQTextEdit(string text, QWidget parent) {
			ProxyQTextEdit().NewQTextEdit(text,parent);
		}
		public QTextEdit(string text) : this((Type) null) {
			CreateProxy();
			NewQTextEdit(text);
		}
		[SmokeMethod("QTextEdit(const QString&)")]
		private void NewQTextEdit(string text) {
			ProxyQTextEdit().NewQTextEdit(text);
		}
		// void setDocument(QTextDocument* arg1); >>>> NOT CONVERTED
		// QTextDocument* document(); >>>> NOT CONVERTED
		// void setTextCursor(const QTextCursor& arg1); >>>> NOT CONVERTED
		// QTextCursor textCursor(); >>>> NOT CONVERTED
		[SmokeMethod("isReadOnly() const")]
		public bool IsReadOnly() {
			return ProxyQTextEdit().IsReadOnly();
		}
		[SmokeMethod("setReadOnly(bool)")]
		public void SetReadOnly(bool ro) {
			ProxyQTextEdit().SetReadOnly(ro);
		}
		[SmokeMethod("fontPointSize() const")]
		public double FontPointSize() {
			return ProxyQTextEdit().FontPointSize();
		}
		[SmokeMethod("fontFamily() const")]
		public string FontFamily() {
			return ProxyQTextEdit().FontFamily();
		}
		[SmokeMethod("fontWeight() const")]
		public int FontWeight() {
			return ProxyQTextEdit().FontWeight();
		}
		[SmokeMethod("fontUnderline() const")]
		public bool FontUnderline() {
			return ProxyQTextEdit().FontUnderline();
		}
		[SmokeMethod("fontItalic() const")]
		public bool FontItalic() {
			return ProxyQTextEdit().FontItalic();
		}
		[SmokeMethod("textColor() const")]
		public QColor TextColor() {
			return ProxyQTextEdit().TextColor();
		}
		[SmokeMethod("currentFont() const")]
		public QFont CurrentFont() {
			return ProxyQTextEdit().CurrentFont();
		}
		[SmokeMethod("alignment() const")]
		public int Alignment() {
			return ProxyQTextEdit().Alignment();
		}
		[SmokeMethod("mergeCurrentCharFormat(const QTextCharFormat&)")]
		public void MergeCurrentCharFormat(QTextCharFormat modifier) {
			ProxyQTextEdit().MergeCurrentCharFormat(modifier);
		}
		[SmokeMethod("setCurrentCharFormat(const QTextCharFormat&)")]
		public void SetCurrentCharFormat(QTextCharFormat format) {
			ProxyQTextEdit().SetCurrentCharFormat(format);
		}
		[SmokeMethod("currentCharFormat() const")]
		public QTextCharFormat CurrentCharFormat() {
			return ProxyQTextEdit().CurrentCharFormat();
		}
		[SmokeMethod("autoFormatting() const")]
		public int AutoFormatting() {
			return ProxyQTextEdit().AutoFormatting();
		}
		[SmokeMethod("setAutoFormatting(AutoFormatting)")]
		public void SetAutoFormatting(int features) {
			ProxyQTextEdit().SetAutoFormatting(features);
		}
		[SmokeMethod("tabChangesFocus() const")]
		public bool TabChangesFocus() {
			return ProxyQTextEdit().TabChangesFocus();
		}
		[SmokeMethod("setTabChangesFocus(bool)")]
		public void SetTabChangesFocus(bool b) {
			ProxyQTextEdit().SetTabChangesFocus(b);
		}
		[SmokeMethod("setDocumentTitle(const QString&)")]
		public void SetDocumentTitle(string title) {
			ProxyQTextEdit().SetDocumentTitle(title);
		}
		[SmokeMethod("documentTitle() const")]
		public string DocumentTitle() {
			return ProxyQTextEdit().DocumentTitle();
		}
		[SmokeMethod("isUndoRedoEnabled() const")]
		public bool IsUndoRedoEnabled() {
			return ProxyQTextEdit().IsUndoRedoEnabled();
		}
		[SmokeMethod("setUndoRedoEnabled(bool)")]
		public void SetUndoRedoEnabled(bool enable) {
			ProxyQTextEdit().SetUndoRedoEnabled(enable);
		}
		[SmokeMethod("lineWrapMode() const")]
		public QTextEdit.LineWrapMode lineWrapMode() {
			return ProxyQTextEdit().lineWrapMode();
		}
		[SmokeMethod("setLineWrapMode(QTextEdit::LineWrapMode)")]
		public void SetLineWrapMode(QTextEdit.LineWrapMode mode) {
			ProxyQTextEdit().SetLineWrapMode(mode);
		}
		[SmokeMethod("lineWrapColumnOrWidth() const")]
		public int LineWrapColumnOrWidth() {
			return ProxyQTextEdit().LineWrapColumnOrWidth();
		}
		[SmokeMethod("setLineWrapColumnOrWidth(int)")]
		public void SetLineWrapColumnOrWidth(int w) {
			ProxyQTextEdit().SetLineWrapColumnOrWidth(w);
		}
		[SmokeMethod("wordWrapMode() const")]
		public QTextOption.WrapMode WordWrapMode() {
			return ProxyQTextEdit().WordWrapMode();
		}
		[SmokeMethod("setWordWrapMode(QTextOption::WrapMode)")]
		public void SetWordWrapMode(QTextOption.WrapMode policy) {
			ProxyQTextEdit().SetWordWrapMode(policy);
		}
		// bool find(const QString& arg1,QTextDocument::FindFlags arg2); >>>> NOT CONVERTED
		[SmokeMethod("find(const QString&)")]
		public new bool Find(string exp) {
			return ProxyQTextEdit().Find(exp);
		}
		[SmokeMethod("toPlainText() const")]
		public string ToPlainText() {
			return ProxyQTextEdit().ToPlainText();
		}
		[SmokeMethod("toHtml() const")]
		public string ToHtml() {
			return ProxyQTextEdit().ToHtml();
		}
		[SmokeMethod("ensureCursorVisible()")]
		public void EnsureCursorVisible() {
			ProxyQTextEdit().EnsureCursorVisible();
		}
		[SmokeMethod("loadResource(int, const QUrl&)")]
		public virtual QVariant LoadResource(int type, IQUrl name) {
			return ProxyQTextEdit().LoadResource(type,name);
		}
		[SmokeMethod("createStandardContextMenu()")]
		public QMenu CreateStandardContextMenu() {
			return ProxyQTextEdit().CreateStandardContextMenu();
		}
		// QTextCursor cursorForPosition(const QPoint& arg1); >>>> NOT CONVERTED
		// QRect cursorRect(const QTextCursor& arg1); >>>> NOT CONVERTED
		[SmokeMethod("cursorRect() const")]
		public QRect CursorRect() {
			return ProxyQTextEdit().CursorRect();
		}
		[SmokeMethod("anchorAt(const QPoint&) const")]
		public string AnchorAt(QPoint pos) {
			return ProxyQTextEdit().AnchorAt(pos);
		}
		[SmokeMethod("overwriteMode() const")]
		public bool OverwriteMode() {
			return ProxyQTextEdit().OverwriteMode();
		}
		[SmokeMethod("setOverwriteMode(bool)")]
		public void SetOverwriteMode(bool overwrite) {
			ProxyQTextEdit().SetOverwriteMode(overwrite);
		}
		[SmokeMethod("tabStopWidth() const")]
		public int TabStopWidth() {
			return ProxyQTextEdit().TabStopWidth();
		}
		[SmokeMethod("setTabStopWidth(int)")]
		public void SetTabStopWidth(int width) {
			ProxyQTextEdit().SetTabStopWidth(width);
		}
		[SmokeMethod("acceptRichText() const")]
		public bool AcceptRichText() {
			return ProxyQTextEdit().AcceptRichText();
		}
		[SmokeMethod("setAcceptRichText(bool)")]
		public void SetAcceptRichText(bool accept) {
			ProxyQTextEdit().SetAcceptRichText(accept);
		}
		[SmokeMethod("setFontPointSize(qreal)")]
		public void SetFontPointSize(double s) {
			ProxyQTextEdit().SetFontPointSize(s);
		}
		[SmokeMethod("setFontFamily(const QString&)")]
		public void SetFontFamily(string fontFamily) {
			ProxyQTextEdit().SetFontFamily(fontFamily);
		}
		[SmokeMethod("setFontWeight(int)")]
		public void SetFontWeight(int w) {
			ProxyQTextEdit().SetFontWeight(w);
		}
		[SmokeMethod("setFontUnderline(bool)")]
		public void SetFontUnderline(bool b) {
			ProxyQTextEdit().SetFontUnderline(b);
		}
		[SmokeMethod("setFontItalic(bool)")]
		public void SetFontItalic(bool b) {
			ProxyQTextEdit().SetFontItalic(b);
		}
		[SmokeMethod("setTextColor(const QColor&)")]
		public void SetTextColor(QColor c) {
			ProxyQTextEdit().SetTextColor(c);
		}
		[SmokeMethod("setCurrentFont(const QFont&)")]
		public void SetCurrentFont(QFont f) {
			ProxyQTextEdit().SetCurrentFont(f);
		}
		[SmokeMethod("setAlignment(Qt::Alignment)")]
		public void SetAlignment(int a) {
			ProxyQTextEdit().SetAlignment(a);
		}
		[SmokeMethod("setPlainText(const QString&)")]
		public void SetPlainText(string text) {
			ProxyQTextEdit().SetPlainText(text);
		}
		[SmokeMethod("setHtml(const QString&)")]
		public void SetHtml(string text) {
			ProxyQTextEdit().SetHtml(text);
		}
		[SmokeMethod("cut()")]
		public void Cut() {
			ProxyQTextEdit().Cut();
		}
		[SmokeMethod("copy()")]
		public void Copy() {
			ProxyQTextEdit().Copy();
		}
		[SmokeMethod("paste()")]
		public void Paste() {
			ProxyQTextEdit().Paste();
		}
		[SmokeMethod("clear()")]
		public void Clear() {
			ProxyQTextEdit().Clear();
		}
		[SmokeMethod("selectAll()")]
		public void SelectAll() {
			ProxyQTextEdit().SelectAll();
		}
		[SmokeMethod("insertPlainText(const QString&)")]
		public void InsertPlainText(string text) {
			ProxyQTextEdit().InsertPlainText(text);
		}
		[SmokeMethod("insertHtml(const QString&)")]
		public void InsertHtml(string text) {
			ProxyQTextEdit().InsertHtml(text);
		}
		[SmokeMethod("append(const QString&)")]
		public void Append(string text) {
			ProxyQTextEdit().Append(text);
		}
		[SmokeMethod("scrollToAnchor(const QString&)")]
		public void ScrollToAnchor(string name) {
			ProxyQTextEdit().ScrollToAnchor(name);
		}
		[SmokeMethod("zoomIn(int)")]
		public void ZoomIn(int range) {
			ProxyQTextEdit().ZoomIn(range);
		}
		[SmokeMethod("zoomIn()")]
		public void ZoomIn() {
			ProxyQTextEdit().ZoomIn();
		}
		[SmokeMethod("zoomOut(int)")]
		public void ZoomOut(int range) {
			ProxyQTextEdit().ZoomOut(range);
		}
		[SmokeMethod("zoomOut()")]
		public void ZoomOut() {
			ProxyQTextEdit().ZoomOut();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQTextEdit().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQTextEdit().Tr(s);
		}
		[SmokeMethod("event(QEvent*)")]
		public new virtual bool Event(QEvent e) {
			return ProxyQTextEdit().Event(e);
		}
		[SmokeMethod("timerEvent(QTimerEvent*)")]
		protected new virtual void TimerEvent(QTimerEvent e) {
			ProxyQTextEdit().TimerEvent(e);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected new virtual void KeyPressEvent(QKeyEvent e) {
			ProxyQTextEdit().KeyPressEvent(e);
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new virtual void ResizeEvent(QResizeEvent e) {
			ProxyQTextEdit().ResizeEvent(e);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected new virtual void PaintEvent(QPaintEvent e) {
			ProxyQTextEdit().PaintEvent(e);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected new virtual void MousePressEvent(QMouseEvent e) {
			ProxyQTextEdit().MousePressEvent(e);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected new virtual void MouseMoveEvent(QMouseEvent e) {
			ProxyQTextEdit().MouseMoveEvent(e);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected new virtual void MouseReleaseEvent(QMouseEvent e) {
			ProxyQTextEdit().MouseReleaseEvent(e);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected new virtual void MouseDoubleClickEvent(QMouseEvent e) {
			ProxyQTextEdit().MouseDoubleClickEvent(e);
		}
		[SmokeMethod("focusNextPrevChild(bool)")]
		protected new virtual bool FocusNextPrevChild(bool next) {
			return ProxyQTextEdit().FocusNextPrevChild(next);
		}
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected new virtual void ContextMenuEvent(QContextMenuEvent e) {
			ProxyQTextEdit().ContextMenuEvent(e);
		}
		[SmokeMethod("dragEnterEvent(QDragEnterEvent*)")]
		protected new virtual void DragEnterEvent(QDragEnterEvent e) {
			ProxyQTextEdit().DragEnterEvent(e);
		}
		[SmokeMethod("dragLeaveEvent(QDragLeaveEvent*)")]
		protected new virtual void DragLeaveEvent(QDragLeaveEvent e) {
			ProxyQTextEdit().DragLeaveEvent(e);
		}
		[SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
		protected new virtual void DragMoveEvent(QDragMoveEvent e) {
			ProxyQTextEdit().DragMoveEvent(e);
		}
		[SmokeMethod("dropEvent(QDropEvent*)")]
		protected new virtual void DropEvent(QDropEvent e) {
			ProxyQTextEdit().DropEvent(e);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected new virtual void FocusInEvent(QFocusEvent e) {
			ProxyQTextEdit().FocusInEvent(e);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected new virtual void FocusOutEvent(QFocusEvent e) {
			ProxyQTextEdit().FocusOutEvent(e);
		}
		[SmokeMethod("showEvent(QShowEvent*)")]
		public new virtual void ShowEvent(QShowEvent arg1) {
			ProxyQTextEdit().ShowEvent(arg1);
		}
		[SmokeMethod("changeEvent(QEvent*)")]
		protected new virtual void ChangeEvent(QEvent e) {
			ProxyQTextEdit().ChangeEvent(e);
		}
		[SmokeMethod("wheelEvent(QWheelEvent*)")]
		protected new virtual void WheelEvent(QWheelEvent e) {
			ProxyQTextEdit().WheelEvent(e);
		}
		[SmokeMethod("createMimeDataFromSelection() const")]
		protected virtual QMimeData CreateMimeDataFromSelection() {
			return ProxyQTextEdit().CreateMimeDataFromSelection();
		}
		[SmokeMethod("canInsertFromMimeData(const QMimeData*) const")]
		protected virtual bool CanInsertFromMimeData(QMimeData source) {
			return ProxyQTextEdit().CanInsertFromMimeData(source);
		}
		[SmokeMethod("insertFromMimeData(const QMimeData*)")]
		protected virtual void InsertFromMimeData(QMimeData source) {
			ProxyQTextEdit().InsertFromMimeData(source);
		}
		[SmokeMethod("inputMethodEvent(QInputMethodEvent*)")]
		protected new virtual void InputMethodEvent(QInputMethodEvent arg1) {
			ProxyQTextEdit().InputMethodEvent(arg1);
		}
		[SmokeMethod("inputMethodQuery(Qt::InputMethodQuery) const")]
		protected new QVariant InputMethodQuery(Qt.InputMethodQuery property) {
			return ProxyQTextEdit().InputMethodQuery(property);
		}
		[SmokeMethod("scrollContentsBy(int, int)")]
		protected new virtual void ScrollContentsBy(int dx, int dy) {
			ProxyQTextEdit().ScrollContentsBy(dx,dy);
		}
		~QTextEdit() {
			DisposeQTextEdit();
		}
		public new void Dispose() {
			DisposeQTextEdit();
		}
		private void DisposeQTextEdit() {
			ProxyQTextEdit().DisposeQTextEdit();
		}
		protected new IQTextEditSignals Emit() {
			return (IQTextEditSignals) Q_EMIT;
		}
	}

	public interface IQTextEditSignals : IQAbstractScrollAreaSignals {
		[Q_SIGNAL("void textChanged()")]
		void TextChanged();
		[Q_SIGNAL("void undoAvailable(bool)")]
		void UndoAvailable(bool b);
		[Q_SIGNAL("void redoAvailable(bool)")]
		void RedoAvailable(bool b);
		[Q_SIGNAL("void currentCharFormatChanged(const QTextCharFormat&)")]
		void CurrentCharFormatChanged(QTextCharFormat format);
		[Q_SIGNAL("void copyAvailable(bool)")]
		void CopyAvailable(bool b);
		[Q_SIGNAL("void selectionChanged()")]
		void SelectionChanged();
		[Q_SIGNAL("void cursorPositionChanged()")]
		void CursorPositionChanged();
	}
}
