//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	/// <remarks> See <see cref="IQGraphicsSceneSignals"></see> for signals emitted by QGraphicsScene
	/// </remarks>

	[SmokeClass("QGraphicsScene")]
	public class QGraphicsScene : QObject, IDisposable {
 		protected QGraphicsScene(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QGraphicsScene), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QGraphicsScene() {
			staticInterceptor = new SmokeInvocation(typeof(QGraphicsScene), null);
		}
		public enum ItemIndexMethod {
			BspTreeIndex = 0,
			NoIndex = -1,
		}
		public enum SceneLayer {
			ItemLayer = 0x1,
			BackgroundLayer = 0x2,
			ForegroundLayer = 0x4,
			AllLayers = 0xffff,
		}
		[Q_PROPERTY("QBrush", "backgroundBrush")]
		public QBrush BackgroundBrush {
			get { return (QBrush) interceptor.Invoke("backgroundBrush", "backgroundBrush()", typeof(QBrush)); }
			set { interceptor.Invoke("setBackgroundBrush#", "setBackgroundBrush(QBrush)", typeof(void), typeof(QBrush), value); }
		}
		[Q_PROPERTY("QBrush", "foregroundBrush")]
		public QBrush ForegroundBrush {
			get { return (QBrush) interceptor.Invoke("foregroundBrush", "foregroundBrush()", typeof(QBrush)); }
			set { interceptor.Invoke("setForegroundBrush#", "setForegroundBrush(QBrush)", typeof(void), typeof(QBrush), value); }
		}
		[Q_PROPERTY("QGraphicsScene::ItemIndexMethod", "itemIndexMethod")]
		public QGraphicsScene.ItemIndexMethod itemIndexMethod {
			get { return (QGraphicsScene.ItemIndexMethod) interceptor.Invoke("itemIndexMethod", "itemIndexMethod()", typeof(QGraphicsScene.ItemIndexMethod)); }
			set { interceptor.Invoke("setItemIndexMethod$", "setItemIndexMethod(QGraphicsScene::ItemIndexMethod)", typeof(void), typeof(QGraphicsScene.ItemIndexMethod), value); }
		}
		[Q_PROPERTY("QRectF", "sceneRect")]
		public QRectF SceneRect {
			get { return (QRectF) interceptor.Invoke("sceneRect", "sceneRect()", typeof(QRectF)); }
			set { interceptor.Invoke("setSceneRect#", "setSceneRect(QRectF)", typeof(void), typeof(QRectF), value); }
		}
		[Q_PROPERTY("int", "bspTreeDepth")]
		public int BspTreeDepth {
			get { return (int) interceptor.Invoke("bspTreeDepth", "bspTreeDepth()", typeof(int)); }
			set { interceptor.Invoke("setBspTreeDepth$", "setBspTreeDepth(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("QPalette", "palette")]
		public QPalette Palette {
			get { return (QPalette) interceptor.Invoke("palette", "palette()", typeof(QPalette)); }
			set { interceptor.Invoke("setPalette#", "setPalette(QPalette)", typeof(void), typeof(QPalette), value); }
		}
		[Q_PROPERTY("QFont", "font")]
		public QFont Font {
			get { return (QFont) interceptor.Invoke("font", "font()", typeof(QFont)); }
			set { interceptor.Invoke("setFont#", "setFont(QFont)", typeof(void), typeof(QFont), value); }
		}
		// void drawItems(QPainter* arg1,int arg2,QGraphicsItem** arg3,const QStyleOptionGraphicsItem* arg4,QWidget* arg5); >>>> NOT CONVERTED
		// void drawItems(QPainter* arg1,int arg2,QGraphicsItem** arg3,const QStyleOptionGraphicsItem* arg4); >>>> NOT CONVERTED
		public QGraphicsScene(QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene#", "QGraphicsScene(QObject*)", typeof(void), typeof(QObject), parent);
		}
		public QGraphicsScene() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene", "QGraphicsScene()", typeof(void));
		}
		public QGraphicsScene(QRectF sceneRect, QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene##", "QGraphicsScene(const QRectF&, QObject*)", typeof(void), typeof(QRectF), sceneRect, typeof(QObject), parent);
		}
		public QGraphicsScene(QRectF sceneRect) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene#", "QGraphicsScene(const QRectF&)", typeof(void), typeof(QRectF), sceneRect);
		}
		public QGraphicsScene(double x, double y, double width, double height, QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene$$$$#", "QGraphicsScene(qreal, qreal, qreal, qreal, QObject*)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), width, typeof(double), height, typeof(QObject), parent);
		}
		public QGraphicsScene(double x, double y, double width, double height) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QGraphicsScene$$$$", "QGraphicsScene(qreal, qreal, qreal, qreal)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), width, typeof(double), height);
		}
		public double Width() {
			return (double) interceptor.Invoke("width", "width() const", typeof(double));
		}
		public double Height() {
			return (double) interceptor.Invoke("height", "height() const", typeof(double));
		}
		public void SetSceneRect(double x, double y, double w, double h) {
			interceptor.Invoke("setSceneRect$$$$", "setSceneRect(qreal, qreal, qreal, qreal)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public void Render(QPainter painter, QRectF target, QRectF source, Qt.AspectRatioMode aspectRatioMode) {
			interceptor.Invoke("render###$", "render(QPainter*, const QRectF&, const QRectF&, Qt::AspectRatioMode)", typeof(void), typeof(QPainter), painter, typeof(QRectF), target, typeof(QRectF), source, typeof(Qt.AspectRatioMode), aspectRatioMode);
		}
		public void Render(QPainter painter, QRectF target, QRectF source) {
			interceptor.Invoke("render###", "render(QPainter*, const QRectF&, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), target, typeof(QRectF), source);
		}
		public void Render(QPainter painter, QRectF target) {
			interceptor.Invoke("render##", "render(QPainter*, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), target);
		}
		public void Render(QPainter painter) {
			interceptor.Invoke("render#", "render(QPainter*)", typeof(void), typeof(QPainter), painter);
		}
		public QRectF ItemsBoundingRect() {
			return (QRectF) interceptor.Invoke("itemsBoundingRect", "itemsBoundingRect() const", typeof(QRectF));
		}
		public List<QGraphicsItem> Items() {
			return (List<QGraphicsItem>) interceptor.Invoke("items", "items() const", typeof(List<QGraphicsItem>));
		}
		public List<QGraphicsItem> Items(QPointF pos) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#", "items(const QPointF&) const", typeof(List<QGraphicsItem>), typeof(QPointF), pos);
		}
		public List<QGraphicsItem> Items(QRectF rect, Qt.ItemSelectionMode mode) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#$", "items(const QRectF&, Qt::ItemSelectionMode) const", typeof(List<QGraphicsItem>), typeof(QRectF), rect, typeof(Qt.ItemSelectionMode), mode);
		}
		public List<QGraphicsItem> Items(QRectF rect) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#", "items(const QRectF&) const", typeof(List<QGraphicsItem>), typeof(QRectF), rect);
		}
		public List<QGraphicsItem> Items(QPolygonF polygon, Qt.ItemSelectionMode mode) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#$", "items(const QPolygonF&, Qt::ItemSelectionMode) const", typeof(List<QGraphicsItem>), typeof(QPolygonF), polygon, typeof(Qt.ItemSelectionMode), mode);
		}
		public List<QGraphicsItem> Items(QPolygonF polygon) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#", "items(const QPolygonF&) const", typeof(List<QGraphicsItem>), typeof(QPolygonF), polygon);
		}
		public List<QGraphicsItem> Items(QPainterPath path, Qt.ItemSelectionMode mode) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#$", "items(const QPainterPath&, Qt::ItemSelectionMode) const", typeof(List<QGraphicsItem>), typeof(QPainterPath), path, typeof(Qt.ItemSelectionMode), mode);
		}
		public List<QGraphicsItem> Items(QPainterPath path) {
			return (List<QGraphicsItem>) interceptor.Invoke("items#", "items(const QPainterPath&) const", typeof(List<QGraphicsItem>), typeof(QPainterPath), path);
		}
		public List<QGraphicsItem> CollidingItems(QGraphicsItem item, Qt.ItemSelectionMode mode) {
			return (List<QGraphicsItem>) interceptor.Invoke("collidingItems#$", "collidingItems(const QGraphicsItem*, Qt::ItemSelectionMode) const", typeof(List<QGraphicsItem>), typeof(QGraphicsItem), item, typeof(Qt.ItemSelectionMode), mode);
		}
		public List<QGraphicsItem> CollidingItems(QGraphicsItem item) {
			return (List<QGraphicsItem>) interceptor.Invoke("collidingItems#", "collidingItems(const QGraphicsItem*) const", typeof(List<QGraphicsItem>), typeof(QGraphicsItem), item);
		}
		public QGraphicsItem ItemAt(QPointF pos) {
			return (QGraphicsItem) interceptor.Invoke("itemAt#", "itemAt(const QPointF&) const", typeof(QGraphicsItem), typeof(QPointF), pos);
		}
		public List<QGraphicsItem> Items(double x, double y, double w, double h, Qt.ItemSelectionMode mode) {
			return (List<QGraphicsItem>) interceptor.Invoke("items$$$$$", "items(qreal, qreal, qreal, qreal, Qt::ItemSelectionMode) const", typeof(List<QGraphicsItem>), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(Qt.ItemSelectionMode), mode);
		}
		public List<QGraphicsItem> Items(double x, double y, double w, double h) {
			return (List<QGraphicsItem>) interceptor.Invoke("items$$$$", "items(qreal, qreal, qreal, qreal) const", typeof(List<QGraphicsItem>), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public QGraphicsItem ItemAt(double x, double y) {
			return (QGraphicsItem) interceptor.Invoke("itemAt$$", "itemAt(qreal, qreal) const", typeof(QGraphicsItem), typeof(double), x, typeof(double), y);
		}
		public List<QGraphicsItem> SelectedItems() {
			return (List<QGraphicsItem>) interceptor.Invoke("selectedItems", "selectedItems() const", typeof(List<QGraphicsItem>));
		}
		public QPainterPath SelectionArea() {
			return (QPainterPath) interceptor.Invoke("selectionArea", "selectionArea() const", typeof(QPainterPath));
		}
		public void SetSelectionArea(QPainterPath path) {
			interceptor.Invoke("setSelectionArea#", "setSelectionArea(const QPainterPath&)", typeof(void), typeof(QPainterPath), path);
		}
		public void SetSelectionArea(QPainterPath path, Qt.ItemSelectionMode arg2) {
			interceptor.Invoke("setSelectionArea#$", "setSelectionArea(const QPainterPath&, Qt::ItemSelectionMode)", typeof(void), typeof(QPainterPath), path, typeof(Qt.ItemSelectionMode), arg2);
		}
		public QGraphicsItemGroup CreateItemGroup(List<QGraphicsItem> items) {
			return (QGraphicsItemGroup) interceptor.Invoke("createItemGroup?", "createItemGroup(const QList<QGraphicsItem*>&)", typeof(QGraphicsItemGroup), typeof(List<QGraphicsItem>), items);
		}
		public void DestroyItemGroup(QGraphicsItemGroup group) {
			interceptor.Invoke("destroyItemGroup#", "destroyItemGroup(QGraphicsItemGroup*)", typeof(void), typeof(QGraphicsItemGroup), group);
		}
		public void AddItem(QGraphicsItem item) {
			interceptor.Invoke("addItem#", "addItem(QGraphicsItem*)", typeof(void), typeof(QGraphicsItem), item);
		}
		public QGraphicsEllipseItem AddEllipse(QRectF rect, QPen pen, QBrush brush) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse###", "addEllipse(const QRectF&, const QPen&, const QBrush&)", typeof(QGraphicsEllipseItem), typeof(QRectF), rect, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsEllipseItem AddEllipse(QRectF rect, QPen pen) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse##", "addEllipse(const QRectF&, const QPen&)", typeof(QGraphicsEllipseItem), typeof(QRectF), rect, typeof(QPen), pen);
		}
		public QGraphicsEllipseItem AddEllipse(QRectF rect) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse#", "addEllipse(const QRectF&)", typeof(QGraphicsEllipseItem), typeof(QRectF), rect);
		}
		public QGraphicsLineItem AddLine(QLineF line, QPen pen) {
			return (QGraphicsLineItem) interceptor.Invoke("addLine##", "addLine(const QLineF&, const QPen&)", typeof(QGraphicsLineItem), typeof(QLineF), line, typeof(QPen), pen);
		}
		public QGraphicsLineItem AddLine(QLineF line) {
			return (QGraphicsLineItem) interceptor.Invoke("addLine#", "addLine(const QLineF&)", typeof(QGraphicsLineItem), typeof(QLineF), line);
		}
		public QGraphicsPathItem AddPath(QPainterPath path, QPen pen, QBrush brush) {
			return (QGraphicsPathItem) interceptor.Invoke("addPath###", "addPath(const QPainterPath&, const QPen&, const QBrush&)", typeof(QGraphicsPathItem), typeof(QPainterPath), path, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsPathItem AddPath(QPainterPath path, QPen pen) {
			return (QGraphicsPathItem) interceptor.Invoke("addPath##", "addPath(const QPainterPath&, const QPen&)", typeof(QGraphicsPathItem), typeof(QPainterPath), path, typeof(QPen), pen);
		}
		public QGraphicsPathItem AddPath(QPainterPath path) {
			return (QGraphicsPathItem) interceptor.Invoke("addPath#", "addPath(const QPainterPath&)", typeof(QGraphicsPathItem), typeof(QPainterPath), path);
		}
		public QGraphicsPixmapItem AddPixmap(QPixmap pixmap) {
			return (QGraphicsPixmapItem) interceptor.Invoke("addPixmap#", "addPixmap(const QPixmap&)", typeof(QGraphicsPixmapItem), typeof(QPixmap), pixmap);
		}
		public QGraphicsPolygonItem AddPolygon(QPolygonF polygon, QPen pen, QBrush brush) {
			return (QGraphicsPolygonItem) interceptor.Invoke("addPolygon###", "addPolygon(const QPolygonF&, const QPen&, const QBrush&)", typeof(QGraphicsPolygonItem), typeof(QPolygonF), polygon, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsPolygonItem AddPolygon(QPolygonF polygon, QPen pen) {
			return (QGraphicsPolygonItem) interceptor.Invoke("addPolygon##", "addPolygon(const QPolygonF&, const QPen&)", typeof(QGraphicsPolygonItem), typeof(QPolygonF), polygon, typeof(QPen), pen);
		}
		public QGraphicsPolygonItem AddPolygon(QPolygonF polygon) {
			return (QGraphicsPolygonItem) interceptor.Invoke("addPolygon#", "addPolygon(const QPolygonF&)", typeof(QGraphicsPolygonItem), typeof(QPolygonF), polygon);
		}
		public QGraphicsRectItem AddRect(QRectF rect, QPen pen, QBrush brush) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect###", "addRect(const QRectF&, const QPen&, const QBrush&)", typeof(QGraphicsRectItem), typeof(QRectF), rect, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsRectItem AddRect(QRectF rect, QPen pen) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect##", "addRect(const QRectF&, const QPen&)", typeof(QGraphicsRectItem), typeof(QRectF), rect, typeof(QPen), pen);
		}
		public QGraphicsRectItem AddRect(QRectF rect) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect#", "addRect(const QRectF&)", typeof(QGraphicsRectItem), typeof(QRectF), rect);
		}
		public QGraphicsTextItem AddText(string text, QFont font) {
			return (QGraphicsTextItem) interceptor.Invoke("addText$#", "addText(const QString&, const QFont&)", typeof(QGraphicsTextItem), typeof(string), text, typeof(QFont), font);
		}
		public QGraphicsTextItem AddText(string text) {
			return (QGraphicsTextItem) interceptor.Invoke("addText$", "addText(const QString&)", typeof(QGraphicsTextItem), typeof(string), text);
		}
		public QGraphicsSimpleTextItem AddSimpleText(string text, QFont font) {
			return (QGraphicsSimpleTextItem) interceptor.Invoke("addSimpleText$#", "addSimpleText(const QString&, const QFont&)", typeof(QGraphicsSimpleTextItem), typeof(string), text, typeof(QFont), font);
		}
		public QGraphicsSimpleTextItem AddSimpleText(string text) {
			return (QGraphicsSimpleTextItem) interceptor.Invoke("addSimpleText$", "addSimpleText(const QString&)", typeof(QGraphicsSimpleTextItem), typeof(string), text);
		}
		public QGraphicsProxyWidget AddWidget(QWidget widget, uint wFlags) {
			return (QGraphicsProxyWidget) interceptor.Invoke("addWidget#$", "addWidget(QWidget*, Qt::WindowFlags)", typeof(QGraphicsProxyWidget), typeof(QWidget), widget, typeof(uint), wFlags);
		}
		public QGraphicsProxyWidget AddWidget(QWidget widget) {
			return (QGraphicsProxyWidget) interceptor.Invoke("addWidget#", "addWidget(QWidget*)", typeof(QGraphicsProxyWidget), typeof(QWidget), widget);
		}
		public QGraphicsEllipseItem AddEllipse(double x, double y, double w, double h, QPen pen, QBrush brush) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse$$$$##", "addEllipse(qreal, qreal, qreal, qreal, const QPen&, const QBrush&)", typeof(QGraphicsEllipseItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsEllipseItem AddEllipse(double x, double y, double w, double h, QPen pen) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse$$$$#", "addEllipse(qreal, qreal, qreal, qreal, const QPen&)", typeof(QGraphicsEllipseItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(QPen), pen);
		}
		public QGraphicsEllipseItem AddEllipse(double x, double y, double w, double h) {
			return (QGraphicsEllipseItem) interceptor.Invoke("addEllipse$$$$", "addEllipse(qreal, qreal, qreal, qreal)", typeof(QGraphicsEllipseItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public QGraphicsLineItem AddLine(double x1, double y1, double x2, double y2, QPen pen) {
			return (QGraphicsLineItem) interceptor.Invoke("addLine$$$$#", "addLine(qreal, qreal, qreal, qreal, const QPen&)", typeof(QGraphicsLineItem), typeof(double), x1, typeof(double), y1, typeof(double), x2, typeof(double), y2, typeof(QPen), pen);
		}
		public QGraphicsLineItem AddLine(double x1, double y1, double x2, double y2) {
			return (QGraphicsLineItem) interceptor.Invoke("addLine$$$$", "addLine(qreal, qreal, qreal, qreal)", typeof(QGraphicsLineItem), typeof(double), x1, typeof(double), y1, typeof(double), x2, typeof(double), y2);
		}
		public QGraphicsRectItem AddRect(double x, double y, double w, double h, QPen pen, QBrush brush) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect$$$$##", "addRect(qreal, qreal, qreal, qreal, const QPen&, const QBrush&)", typeof(QGraphicsRectItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(QPen), pen, typeof(QBrush), brush);
		}
		public QGraphicsRectItem AddRect(double x, double y, double w, double h, QPen pen) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect$$$$#", "addRect(qreal, qreal, qreal, qreal, const QPen&)", typeof(QGraphicsRectItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(QPen), pen);
		}
		public QGraphicsRectItem AddRect(double x, double y, double w, double h) {
			return (QGraphicsRectItem) interceptor.Invoke("addRect$$$$", "addRect(qreal, qreal, qreal, qreal)", typeof(QGraphicsRectItem), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public void RemoveItem(QGraphicsItem item) {
			interceptor.Invoke("removeItem#", "removeItem(QGraphicsItem*)", typeof(void), typeof(QGraphicsItem), item);
		}
		public QGraphicsItem FocusItem() {
			return (QGraphicsItem) interceptor.Invoke("focusItem", "focusItem() const", typeof(QGraphicsItem));
		}
		public void SetFocusItem(QGraphicsItem item, Qt.FocusReason focusReason) {
			interceptor.Invoke("setFocusItem#$", "setFocusItem(QGraphicsItem*, Qt::FocusReason)", typeof(void), typeof(QGraphicsItem), item, typeof(Qt.FocusReason), focusReason);
		}
		public void SetFocusItem(QGraphicsItem item) {
			interceptor.Invoke("setFocusItem#", "setFocusItem(QGraphicsItem*)", typeof(void), typeof(QGraphicsItem), item);
		}
		public bool HasFocus() {
			return (bool) interceptor.Invoke("hasFocus", "hasFocus() const", typeof(bool));
		}
		public void SetFocus(Qt.FocusReason focusReason) {
			interceptor.Invoke("setFocus$", "setFocus(Qt::FocusReason)", typeof(void), typeof(Qt.FocusReason), focusReason);
		}
		public void SetFocus() {
			interceptor.Invoke("setFocus", "setFocus()", typeof(void));
		}
		public void ClearFocus() {
			interceptor.Invoke("clearFocus", "clearFocus()", typeof(void));
		}
		public QGraphicsItem MouseGrabberItem() {
			return (QGraphicsItem) interceptor.Invoke("mouseGrabberItem", "mouseGrabberItem() const", typeof(QGraphicsItem));
		}
		[SmokeMethod("inputMethodQuery(Qt::InputMethodQuery) const")]
		public new virtual QVariant InputMethodQuery(Qt.InputMethodQuery query) {
			return (QVariant) interceptor.Invoke("inputMethodQuery$", "inputMethodQuery(Qt::InputMethodQuery) const", typeof(QVariant), typeof(Qt.InputMethodQuery), query);
		}
		public List<QGraphicsView> Views() {
			return (List<QGraphicsView>) interceptor.Invoke("views", "views() const", typeof(List<QGraphicsView>));
		}
		public void Update(double x, double y, double w, double h) {
			interceptor.Invoke("update$$$$", "update(qreal, qreal, qreal, qreal)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public void Invalidate(double x, double y, double w, double h, uint layers) {
			interceptor.Invoke("invalidate$$$$$", "invalidate(qreal, qreal, qreal, qreal, QGraphicsScene::SceneLayers)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h, typeof(uint), layers);
		}
		public void Invalidate(double x, double y, double w, double h) {
			interceptor.Invoke("invalidate$$$$", "invalidate(qreal, qreal, qreal, qreal)", typeof(void), typeof(double), x, typeof(double), y, typeof(double), w, typeof(double), h);
		}
		public QStyle Style() {
			return (QStyle) interceptor.Invoke("style", "style() const", typeof(QStyle));
		}
		public void SetStyle(QStyle style) {
			interceptor.Invoke("setStyle#", "setStyle(QStyle*)", typeof(void), typeof(QStyle), style);
		}
		public QGraphicsWidget ActiveWindow() {
			return (QGraphicsWidget) interceptor.Invoke("activeWindow", "activeWindow() const", typeof(QGraphicsWidget));
		}
		public void SetActiveWindow(QGraphicsWidget widget) {
			interceptor.Invoke("setActiveWindow#", "setActiveWindow(QGraphicsWidget*)", typeof(void), typeof(QGraphicsWidget), widget);
		}
		[Q_SLOT("void update(const QRectF&)")]
		public void Update(QRectF rect) {
			interceptor.Invoke("update#", "update(const QRectF&)", typeof(void), typeof(QRectF), rect);
		}
		[Q_SLOT("void update()")]
		public void Update() {
			interceptor.Invoke("update", "update()", typeof(void));
		}
		[Q_SLOT("void invalidate(const QRectF&, QGraphicsScene::SceneLayers)")]
		public void Invalidate(QRectF rect, uint layers) {
			interceptor.Invoke("invalidate#$", "invalidate(const QRectF&, QGraphicsScene::SceneLayers)", typeof(void), typeof(QRectF), rect, typeof(uint), layers);
		}
		[Q_SLOT("void invalidate(const QRectF&)")]
		public void Invalidate(QRectF rect) {
			interceptor.Invoke("invalidate#", "invalidate(const QRectF&)", typeof(void), typeof(QRectF), rect);
		}
		[Q_SLOT("void invalidate()")]
		public void Invalidate() {
			interceptor.Invoke("invalidate", "invalidate()", typeof(void));
		}
		[Q_SLOT("void advance()")]
		public void Advance() {
			interceptor.Invoke("advance", "advance()", typeof(void));
		}
		[Q_SLOT("void clearSelection()")]
		public void ClearSelection() {
			interceptor.Invoke("clearSelection", "clearSelection()", typeof(void));
		}
		[Q_SLOT("void clear()")]
		public void Clear() {
			interceptor.Invoke("clear", "clear()", typeof(void));
		}
		[SmokeMethod("event(QEvent*)")]
		protected new virtual bool Event(QEvent arg1) {
			return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
		}
		[SmokeMethod("eventFilter(QObject*, QEvent*)")]
		protected new virtual bool EventFilter(QObject watched, QEvent arg2) {
			return (bool) interceptor.Invoke("eventFilter##", "eventFilter(QObject*, QEvent*)", typeof(bool), typeof(QObject), watched, typeof(QEvent), arg2);
		}
		[SmokeMethod("contextMenuEvent(QGraphicsSceneContextMenuEvent*)")]
		protected virtual void ContextMenuEvent(QGraphicsSceneContextMenuEvent arg1) {
			interceptor.Invoke("contextMenuEvent#", "contextMenuEvent(QGraphicsSceneContextMenuEvent*)", typeof(void), typeof(QGraphicsSceneContextMenuEvent), arg1);
		}
		[SmokeMethod("dragEnterEvent(QGraphicsSceneDragDropEvent*)")]
		protected virtual void DragEnterEvent(QGraphicsSceneDragDropEvent arg1) {
			interceptor.Invoke("dragEnterEvent#", "dragEnterEvent(QGraphicsSceneDragDropEvent*)", typeof(void), typeof(QGraphicsSceneDragDropEvent), arg1);
		}
		[SmokeMethod("dragMoveEvent(QGraphicsSceneDragDropEvent*)")]
		protected virtual void DragMoveEvent(QGraphicsSceneDragDropEvent arg1) {
			interceptor.Invoke("dragMoveEvent#", "dragMoveEvent(QGraphicsSceneDragDropEvent*)", typeof(void), typeof(QGraphicsSceneDragDropEvent), arg1);
		}
		[SmokeMethod("dragLeaveEvent(QGraphicsSceneDragDropEvent*)")]
		protected virtual void DragLeaveEvent(QGraphicsSceneDragDropEvent arg1) {
			interceptor.Invoke("dragLeaveEvent#", "dragLeaveEvent(QGraphicsSceneDragDropEvent*)", typeof(void), typeof(QGraphicsSceneDragDropEvent), arg1);
		}
		[SmokeMethod("dropEvent(QGraphicsSceneDragDropEvent*)")]
		protected virtual void DropEvent(QGraphicsSceneDragDropEvent arg1) {
			interceptor.Invoke("dropEvent#", "dropEvent(QGraphicsSceneDragDropEvent*)", typeof(void), typeof(QGraphicsSceneDragDropEvent), arg1);
		}
		[SmokeMethod("focusInEvent(QFocusEvent*)")]
		protected virtual void FocusInEvent(QFocusEvent arg1) {
			interceptor.Invoke("focusInEvent#", "focusInEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), arg1);
		}
		[SmokeMethod("focusOutEvent(QFocusEvent*)")]
		protected virtual void FocusOutEvent(QFocusEvent arg1) {
			interceptor.Invoke("focusOutEvent#", "focusOutEvent(QFocusEvent*)", typeof(void), typeof(QFocusEvent), arg1);
		}
		[SmokeMethod("helpEvent(QGraphicsSceneHelpEvent*)")]
		protected virtual void HelpEvent(QGraphicsSceneHelpEvent arg1) {
			interceptor.Invoke("helpEvent#", "helpEvent(QGraphicsSceneHelpEvent*)", typeof(void), typeof(QGraphicsSceneHelpEvent), arg1);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected virtual void KeyPressEvent(QKeyEvent arg1) {
			interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
		}
		[SmokeMethod("keyReleaseEvent(QKeyEvent*)")]
		protected virtual void KeyReleaseEvent(QKeyEvent arg1) {
			interceptor.Invoke("keyReleaseEvent#", "keyReleaseEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
		}
		[SmokeMethod("mousePressEvent(QGraphicsSceneMouseEvent*)")]
		protected virtual void MousePressEvent(QGraphicsSceneMouseEvent arg1) {
			interceptor.Invoke("mousePressEvent#", "mousePressEvent(QGraphicsSceneMouseEvent*)", typeof(void), typeof(QGraphicsSceneMouseEvent), arg1);
		}
		[SmokeMethod("mouseMoveEvent(QGraphicsSceneMouseEvent*)")]
		protected virtual void MouseMoveEvent(QGraphicsSceneMouseEvent arg1) {
			interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QGraphicsSceneMouseEvent*)", typeof(void), typeof(QGraphicsSceneMouseEvent), arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QGraphicsSceneMouseEvent*)")]
		protected virtual void MouseReleaseEvent(QGraphicsSceneMouseEvent arg1) {
			interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QGraphicsSceneMouseEvent*)", typeof(void), typeof(QGraphicsSceneMouseEvent), arg1);
		}
		[SmokeMethod("mouseDoubleClickEvent(QGraphicsSceneMouseEvent*)")]
		protected virtual void MouseDoubleClickEvent(QGraphicsSceneMouseEvent arg1) {
			interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QGraphicsSceneMouseEvent*)", typeof(void), typeof(QGraphicsSceneMouseEvent), arg1);
		}
		[SmokeMethod("wheelEvent(QGraphicsSceneWheelEvent*)")]
		protected virtual void WheelEvent(QGraphicsSceneWheelEvent arg1) {
			interceptor.Invoke("wheelEvent#", "wheelEvent(QGraphicsSceneWheelEvent*)", typeof(void), typeof(QGraphicsSceneWheelEvent), arg1);
		}
		[SmokeMethod("inputMethodEvent(QInputMethodEvent*)")]
		protected virtual void InputMethodEvent(QInputMethodEvent arg1) {
			interceptor.Invoke("inputMethodEvent#", "inputMethodEvent(QInputMethodEvent*)", typeof(void), typeof(QInputMethodEvent), arg1);
		}
		[SmokeMethod("drawBackground(QPainter*, const QRectF&)")]
		protected virtual void DrawBackground(QPainter painter, QRectF rect) {
			interceptor.Invoke("drawBackground##", "drawBackground(QPainter*, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), rect);
		}
		[SmokeMethod("drawForeground(QPainter*, const QRectF&)")]
		protected virtual void DrawForeground(QPainter painter, QRectF rect) {
			interceptor.Invoke("drawForeground##", "drawForeground(QPainter*, const QRectF&)", typeof(void), typeof(QPainter), painter, typeof(QRectF), rect);
		}
		[Q_SLOT("bool focusNextPrevChild(bool)")]
		protected bool FocusNextPrevChild(bool next) {
			return (bool) interceptor.Invoke("focusNextPrevChild$", "focusNextPrevChild(bool)", typeof(bool), typeof(bool), next);
		}
		~QGraphicsScene() {
			interceptor.Invoke("~QGraphicsScene", "~QGraphicsScene()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QGraphicsScene", "~QGraphicsScene()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQGraphicsSceneSignals Emit {
			get { return (IQGraphicsSceneSignals) Q_EMIT; }
		}
	}

	public interface IQGraphicsSceneSignals : IQObjectSignals {
		[Q_SIGNAL("void changed(const QList<QRectF>&)")]
		void Changed(List<QRectF> region);
		[Q_SIGNAL("void sceneRectChanged(const QRectF&)")]
		void SceneRectChanged(QRectF rect);
		[Q_SIGNAL("void selectionChanged()")]
		void SelectionChanged();
	}
}
