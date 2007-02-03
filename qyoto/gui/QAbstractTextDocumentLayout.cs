//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQAbstractTextDocumentLayoutSignals"></see> for signals emitted by QAbstractTextDocumentLayout
	[SmokeClass("QAbstractTextDocumentLayout")]
	public class QAbstractTextDocumentLayout : QObject {
 		protected QAbstractTextDocumentLayout(Type dummy) : base((Type) null) {}
		interface IQAbstractTextDocumentLayoutProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAbstractTextDocumentLayout), this);
			_interceptor = (QAbstractTextDocumentLayout) realProxy.GetTransparentProxy();
		}
		private QAbstractTextDocumentLayout ProxyQAbstractTextDocumentLayout() {
			return (QAbstractTextDocumentLayout) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAbstractTextDocumentLayout() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAbstractTextDocumentLayoutProxy), null);
			_staticInterceptor = (IQAbstractTextDocumentLayoutProxy) realProxy.GetTransparentProxy();
		}
		private static IQAbstractTextDocumentLayoutProxy StaticQAbstractTextDocumentLayout() {
			return (IQAbstractTextDocumentLayoutProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		// QAbstractTextDocumentLayout* QAbstractTextDocumentLayout(QTextDocument* arg1); >>>> NOT CONVERTED
		// void draw(QPainter* arg1,const QAbstractTextDocumentLayout::PaintContext& arg2); >>>> NOT CONVERTED
		[SmokeMethod("hitTest", "(const QPointF&, Qt::HitTestAccuracy) const", "#$")]
		public virtual int HitTest(QPointF point, Qt.HitTestAccuracy accuracy) {
			return ProxyQAbstractTextDocumentLayout().HitTest(point,accuracy);
		}
		[SmokeMethod("anchorAt", "(const QPointF&) const", "#")]
		public string AnchorAt(QPointF pos) {
			return ProxyQAbstractTextDocumentLayout().AnchorAt(pos);
		}
		[SmokeMethod("pageCount", "() const", "")]
		public virtual int PageCount() {
			return ProxyQAbstractTextDocumentLayout().PageCount();
		}
		[SmokeMethod("documentSize", "() const", "")]
		public virtual QSizeF DocumentSize() {
			return ProxyQAbstractTextDocumentLayout().DocumentSize();
		}
		[SmokeMethod("frameBoundingRect", "(QTextFrame*) const", "#")]
		public virtual QRectF FrameBoundingRect(QTextFrame frame) {
			return ProxyQAbstractTextDocumentLayout().FrameBoundingRect(frame);
		}
		[SmokeMethod("blockBoundingRect", "(const QTextBlock&) const", "#")]
		public virtual QRectF BlockBoundingRect(QTextBlock block) {
			return ProxyQAbstractTextDocumentLayout().BlockBoundingRect(block);
		}
		[SmokeMethod("setPaintDevice", "(QPaintDevice*)", "#")]
		public void SetPaintDevice(IQPaintDevice device) {
			ProxyQAbstractTextDocumentLayout().SetPaintDevice(device);
		}
		[SmokeMethod("paintDevice", "() const", "")]
		public IQPaintDevice PaintDevice() {
			return ProxyQAbstractTextDocumentLayout().PaintDevice();
		}
		// QTextDocument* document(); >>>> NOT CONVERTED
		[SmokeMethod("registerHandler", "(int, QObject*)", "$#")]
		public void RegisterHandler(int objectType, QObject component) {
			ProxyQAbstractTextDocumentLayout().RegisterHandler(objectType,component);
		}
		[SmokeMethod("handlerForObject", "(int) const", "$")]
		public QTextObjectInterface HandlerForObject(int objectType) {
			return ProxyQAbstractTextDocumentLayout().HandlerForObject(objectType);
		}
		public static new string Tr(string s, string c) {
			return StaticQAbstractTextDocumentLayout().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQAbstractTextDocumentLayout().Tr(s);
		}
		~QAbstractTextDocumentLayout() {
			DisposeQAbstractTextDocumentLayout();
		}
		public new void Dispose() {
			DisposeQAbstractTextDocumentLayout();
		}
		[SmokeMethod("~QAbstractTextDocumentLayout", "()", "")]
		private void DisposeQAbstractTextDocumentLayout() {
			ProxyQAbstractTextDocumentLayout().DisposeQAbstractTextDocumentLayout();
		}
		protected new IQAbstractTextDocumentLayoutSignals Emit {
			get {
				return (IQAbstractTextDocumentLayoutSignals) Q_EMIT;
			}
		}
	}

	public interface IQAbstractTextDocumentLayoutSignals : IQObjectSignals {
		[Q_SIGNAL("void update(const QRectF&)")]
		void Update(QRectF arg1);
		[Q_SIGNAL("void update()")]
		void Update();
		[Q_SIGNAL("void documentSizeChanged(const QSizeF&)")]
		void DocumentSizeChanged(QSizeF newSize);
		[Q_SIGNAL("void pageCountChanged(int)")]
		void PageCountChanged(int newPages);
	}
}
