//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	/// See <see cref="IQTextDocumentSignals"></see> for signals emitted by QTextDocument
	public class QTextDocument : QObject, IDisposable {
 		protected QTextDocument(Type dummy) : base((Type) null) {}
		interface IQTextDocumentProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected void CreateQTextDocumentProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextDocument), this);
			_interceptor = (QTextDocument) realProxy.GetTransparentProxy();
		}
		private QTextDocument ProxyQTextDocument() {
			return (QTextDocument) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextDocument() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextDocumentProxy), null);
			_staticInterceptor = (IQTextDocumentProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextDocumentProxy StaticQTextDocument() {
			return (IQTextDocumentProxy) _staticInterceptor;
		}

		enum E_MetaInformation {
			DocumentTitle = 0,
		}
		enum FindFlag {
			FindBackward = 0x00001,
			FindCaseSensitively = 0x00002,
			FindWholeWords = 0x00004,
		}
		enum ResourceType {
			HtmlResource = 1,
			ImageResource = 2,
			UserResource = 100,
		}
		public new virtual QMetaObject MetaObject() {
			return ProxyQTextDocument().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		// QTextDocument* QTextDocument(QObject* arg1); >>>> NOT CONVERTED
		// QTextDocument* QTextDocument(); >>>> NOT CONVERTED
		// QTextDocument* QTextDocument(const QString& arg1,QObject* arg2); >>>> NOT CONVERTED
		// QTextDocument* QTextDocument(const QString& arg1); >>>> NOT CONVERTED
		// QTextDocument* clone(QObject* arg1); >>>> NOT CONVERTED
		// QTextDocument* clone(); >>>> NOT CONVERTED
		public bool IsEmpty() {
			return ProxyQTextDocument().IsEmpty();
		}
		public virtual void Clear() {
			ProxyQTextDocument().Clear();
		}
		public void SetUndoRedoEnabled(bool enable) {
			ProxyQTextDocument().SetUndoRedoEnabled(enable);
		}
		public bool IsUndoRedoEnabled() {
			return ProxyQTextDocument().IsUndoRedoEnabled();
		}
		public bool IsUndoAvailable() {
			return ProxyQTextDocument().IsUndoAvailable();
		}
		public bool IsRedoAvailable() {
			return ProxyQTextDocument().IsRedoAvailable();
		}
		public void SetDocumentLayout(QAbstractTextDocumentLayout layout) {
			ProxyQTextDocument().SetDocumentLayout(layout);
		}
		public QAbstractTextDocumentLayout DocumentLayout() {
			return ProxyQTextDocument().DocumentLayout();
		}
		// void setMetaInformation(QTextDocument::MetaInformation arg1,const QString& arg2); >>>> NOT CONVERTED
		// QString metaInformation(QTextDocument::MetaInformation arg1); >>>> NOT CONVERTED
		public string ToHtml(QByteArray encoding) {
			return ProxyQTextDocument().ToHtml(encoding);
		}
		public string ToHtml() {
			return ProxyQTextDocument().ToHtml();
		}
		public void SetHtml(string html) {
			ProxyQTextDocument().SetHtml(html);
		}
		public string ToPlainText() {
			return ProxyQTextDocument().ToPlainText();
		}
		public void SetPlainText(string text) {
			ProxyQTextDocument().SetPlainText(text);
		}
		// QTextCursor find(const QString& arg1,int arg2,FindFlags arg3); >>>> NOT CONVERTED
		// QTextCursor find(const QString& arg1,int arg2); >>>> NOT CONVERTED
		// QTextCursor find(const QString& arg1); >>>> NOT CONVERTED
		// QTextCursor find(const QString& arg1,const QTextCursor& arg2,FindFlags arg3); >>>> NOT CONVERTED
		// QTextCursor find(const QString& arg1,const QTextCursor& arg2); >>>> NOT CONVERTED
		public QTextFrame FrameAt(int pos) {
			return ProxyQTextDocument().FrameAt(pos);
		}
		public QTextFrame RootFrame() {
			return ProxyQTextDocument().RootFrame();
		}
		public QTextObject Object(int objectIndex) {
			return ProxyQTextDocument().Object(objectIndex);
		}
		// QTextObject* objectForFormat(const QTextFormat& arg1); >>>> NOT CONVERTED
		public QTextBlock FindBlock(int pos) {
			return ProxyQTextDocument().FindBlock(pos);
		}
		public QTextBlock Begin() {
			return ProxyQTextDocument().Begin();
		}
		public QTextBlock End() {
			return ProxyQTextDocument().End();
		}
		public void SetPageSize(QSizeF size) {
			ProxyQTextDocument().SetPageSize(size);
		}
		public QSizeF PageSize() {
			return ProxyQTextDocument().PageSize();
		}
		public void SetDefaultFont(QFont font) {
			ProxyQTextDocument().SetDefaultFont(font);
		}
		public QFont DefaultFont() {
			return ProxyQTextDocument().DefaultFont();
		}
		public int PageCount() {
			return ProxyQTextDocument().PageCount();
		}
		public bool IsModified() {
			return ProxyQTextDocument().IsModified();
		}
		public void Print(QPrinter printer) {
			ProxyQTextDocument().Print(printer);
		}
		public QVariant Resource(int type, IQUrl name) {
			return ProxyQTextDocument().Resource(type,name);
		}
		public void AddResource(int type, IQUrl name, QVariant resource) {
			ProxyQTextDocument().AddResource(type,name,resource);
		}
		// QVector<QTextFormat> allFormats(); >>>> NOT CONVERTED
		public void MarkContentsDirty(int from, int length) {
			ProxyQTextDocument().MarkContentsDirty(from,length);
		}
		// QTextDocumentPrivate* docHandle(); >>>> NOT CONVERTED
		public void Undo() {
			ProxyQTextDocument().Undo();
		}
		public void Redo() {
			ProxyQTextDocument().Redo();
		}
		// void appendUndoItem(QAbstractUndoItem* arg1); >>>> NOT CONVERTED
		public void SetModified(bool m) {
			ProxyQTextDocument().SetModified(m);
		}
		public void SetModified() {
			ProxyQTextDocument().SetModified();
		}
		public static new string Tr(string s, string c) {
			return StaticQTextDocument().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQTextDocument().Tr(s);
		}
		// QTextObject* createObject(const QTextFormat& arg1); >>>> NOT CONVERTED
		protected virtual QVariant LoadResource(int type, IQUrl name) {
			return ProxyQTextDocument().LoadResource(type,name);
		}
		~QTextDocument() {
			ProxyQTextDocument().Dispose();
		}
		public new void Dispose() {
			ProxyQTextDocument().Dispose();
		}
	}

	public interface IQTextDocumentSignals {
		void ContentsChange(int from, int charsRemoves, int charsAdded);
		void ContentsChanged();
		void UndoAvailable(bool arg1);
		void RedoAvailable(bool arg1);
		void ModificationChanged(bool m);
		// void cursorPositionChanged(const QTextCursor& arg1); >>>> NOT CONVERTED
	}
}