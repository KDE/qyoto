namespace PlasmaScripting {
    using System;
    using System.Collections.Generic;
    using QyotoQGraphicsWidget = Qyoto.QGraphicsWidget;
    using Qyoto;
    using Plasma;

    public class QGraphicsWidget : QObject {
        protected AppletScript appletScript;
        protected Plasma.Applet applet;
        protected Type appletType;

        public new const int Type = 11;

        public Plasma.Applet PlasmaApplet {
            get { return applet; }
        }
        [Q_PROPERTY("QPalette", "palette")]
        public QPalette Palette {
            get { return applet.Palette; }
            set { applet.Palette = value; }
        }
//        [Q_PROPERTY("QFont", "font")]
//        public QFont Font {
//            get { return applet.Font; }
//            set { applet.Font = value; }
//        }
        [Q_PROPERTY("Qt::LayoutDirection", "layoutDirection")]
        public new Qt.LayoutDirection LayoutDirection {
            get { return applet.LayoutDirection; }
            set { applet.LayoutDirection = value; }
        }
        [Q_PROPERTY("QSizeF", "size")]
        public QSizeF Size {
            get { return applet.Size; }
            set { applet.Size = value; }
        }
        [Q_PROPERTY("Qt::FocusPolicy", "focusPolicy")]
        public new Qt.FocusPolicy FocusPolicy {
            get { return applet.FocusPolicy; }
            set { applet.FocusPolicy = value; }
        }
        [Q_PROPERTY("bool", "enabled")]
        public bool Enabled {
            get { return applet.Enabled; }
            set { applet.Enabled = value; }
        }
        [Q_PROPERTY("bool", "visible")]
        public bool Visible {
            get { return applet.Visible; }
            set { applet.Visible = value; }
        }
        [Q_PROPERTY("Qt::WindowFlags", "windowFlags")]
        public uint WindowFlags {
            get { return applet.WindowFlags; }
            set { applet.WindowFlags = value; }
        }
        [Q_PROPERTY("QString", "windowTitle")]
        public string WindowTitle {
            get { return applet.WindowTitle; }
            set { applet.WindowTitle = value; }
        }
        public QGraphicsWidget(AppletScript parent) : base(parent) {
            appletScript = parent;
            applet = parent.Applet();
            appletType = applet.GetType();
        }
        public QGraphicsLayout Layout() {
            return applet.Layout();
        }
        public void SetLayout(QGraphicsLayout layout) {
            applet.SetLayout(layout);
        }
        public void AdjustSize() {
            applet.AdjustSize();
        }
        public void UnsetLayoutDirection() {
            applet.UnsetLayoutDirection();
        }
        public QStyle Style() {
            return applet.Style();
        }
        public void SetStyle(QStyle style) {
            applet.SetStyle(style);
        }
        public void Resize(QSizeF size) {
            applet.Resize(size);
        }
        public void Resize(double w, double h) {
            applet.Resize(w, h);
        }
        public virtual void SetGeometry(QRectF rect) {
            applet.SetGeometry(rect);
        }
        public void SetGeometry(double x, double y, double w, double h) {
            applet.SetGeometry(x, y, w, h);
        }
        public QRectF Rect() {
            return applet.Rect();
        }
        public void SetContentsMargins(double left, double top, double right, double bottom) {
            applet.SetContentsMargins(left, top, right, bottom);
        }
        public virtual void GetContentsMargins(ref double left, ref double top, ref double right, ref double bottom) {
            applet.GetContentsMargins(ref left, ref top, ref right, ref bottom);
        }
        public void SetWindowFrameMargins(double left, double top, double right, double bottom) {
            applet.SetWindowFrameMargins(left, top, right, bottom);
        }
        public void GetWindowFrameMargins(ref double left, ref double top, ref double right, ref double bottom) {
            applet.GetWindowFrameMargins(ref left, ref top, ref right, ref bottom);
        }
        public void UnsetWindowFrameMargins() {
            applet.UnsetWindowFrameMargins();
        }
        public QRectF WindowFrameGeometry() {
            return applet.WindowFrameGeometry();
        }
        public QRectF WindowFrameRect() {
            return applet.WindowFrameRect();
        }
        public new Qt.WindowType WindowType() {
            return applet.WindowType();
        }
        public bool IsActiveWindow() {
            return applet.IsActiveWindow();
        }
        public QyotoQGraphicsWidget FocusWidget() {
            return applet.FocusWidget();
        }
        public void SetAttribute(Qt.WidgetAttribute attribute, bool on) {
            applet.SetAttribute(attribute, on);
        }
        public void SetAttribute(Qt.WidgetAttribute attribute) {
            applet.SetAttribute(attribute);
        }
        public bool TestAttribute(Qt.WidgetAttribute attribute) {
            return applet.TestAttribute(attribute);
        }
        public virtual int type() {
            return applet.type();
        }
        public virtual void Paint(QPainter painter, QStyleOptionGraphicsItem option, QWidget widget) {
            applet.Paint(painter, option, widget);
        }
        public virtual void Paint(QPainter painter, QStyleOptionGraphicsItem option) {
            applet.Paint(painter, option);
        }
        public virtual void PaintWindowFrame(QPainter painter, QStyleOptionGraphicsItem option, QWidget widget) {
            applet.PaintWindowFrame(painter, option, widget);
        }
        public virtual void PaintWindowFrame(QPainter painter, QStyleOptionGraphicsItem option) {
            applet.PaintWindowFrame(painter, option);
        }
        public virtual QRectF BoundingRect() {
            return applet.BoundingRect();
        }
        public virtual QPainterPath Shape() {
            return applet.Shape();
        }
        [Q_SLOT("bool close()")]
        public bool Close() {
            return applet.Close();
        }
        protected virtual void InitStyleOption(QStyleOption option) {
        }
        public virtual QSizeF SizeHint(Qt.SizeHint which, QSizeF constraint) {
            return applet.SizeHint(which, constraint);
        }
        protected virtual QSizeF SizeHint(Qt.SizeHint which) {
            return null;
        }
        public new virtual void UpdateGeometry() {
            applet.UpdateGeometry();
        }
        protected virtual QVariant ItemChange(QGraphicsItem.GraphicsItemChange change, QVariant value) {
            return null;
        }
        protected virtual QVariant PropertyChange(string propertyName, QVariant value) {
            return null;
        }
        protected virtual bool SceneEvent(QEvent arg1) {
            return false;
        }
        protected virtual bool WindowFrameEvent(QEvent e) {
            return false;
        }
        protected virtual Qt.WindowFrameSection WindowFrameSectionAt(QPointF pos) {
            return 0;
        }
        protected new virtual bool Event(QEvent arg1) {
            return false;
        }
        protected virtual void ChangeEvent(QEvent arg1) {
        }
        protected virtual void CloseEvent(QCloseEvent arg1) {
        }
        protected virtual void FocusInEvent(QFocusEvent arg1) {
        }
        protected virtual bool FocusNextPrevChild(bool next) {
            return false;
        }
        protected virtual void FocusOutEvent(QFocusEvent arg1) {
        }
        protected virtual void HideEvent(QHideEvent arg1) {
        }
        protected virtual void MoveEvent(QGraphicsSceneMoveEvent arg1) {
        }
        protected virtual void PolishEvent() {
        }
        protected virtual void ResizeEvent(QGraphicsSceneResizeEvent arg1) {
        }
        protected virtual void ShowEvent(QShowEvent arg1) {
        }
        protected virtual void HoverMoveEvent(QGraphicsSceneHoverEvent arg1) {
        }
        protected virtual void HoverLeaveEvent(QGraphicsSceneHoverEvent arg1) {
        }
        protected virtual void GrabMouseEvent(QEvent arg1) {
        }
        protected virtual void UngrabMouseEvent(QEvent arg1) {
        }
        protected virtual void GrabKeyboardEvent(QEvent arg1) {
        }
        protected virtual void UngrabKeyboardEvent(QEvent arg1) {
        }
        public QGraphicsScene Scene() {
            return applet.Scene();
        }
        public IQGraphicsItem ParentItem() {
            return applet.ParentItem();
        }
        public IQGraphicsItem TopLevelItem() {
            return applet.TopLevelItem();
        }
        public QyotoQGraphicsWidget ParentWidget() {
            return applet.ParentWidget();
        }
        public QyotoQGraphicsWidget TopLevelWidget() {
            return applet.TopLevelWidget();
        }
        public QyotoQGraphicsWidget Window() {
            return applet.Window();
        }
        public void SetParentItem(IQGraphicsItem parent) {
            applet.SetParentItem(parent);
        }
        public List<IQGraphicsItem> Children() {
            return applet.Children();
        }
        public List<IQGraphicsItem> ChildItems() {
            return applet.ChildItems();
        }
        public bool IsWidget() {
            return applet.IsWidget();
        }
        public bool IsWindow() {
            return applet.IsWindow();
        }
        public QGraphicsItemGroup Group() {
            return applet.Group();
        }
        public void SetGroup(QGraphicsItemGroup group) {
            applet.SetGroup(group);
        }
        public uint Flags() {
            return applet.Flags();
        }
        public void SetFlag(QGraphicsItem.GraphicsItemFlag flag, bool enabled) {
            applet.SetFlag(flag, enabled);
        }
        public void SetFlag(QGraphicsItem.GraphicsItemFlag flag) {
            applet.SetFlag(flag);
        }
        public void SetFlags(uint flags) {
            applet.SetFlags(flags);
        }
        public QGraphicsItem.CacheMode cacheMode() {
            return applet.cacheMode();
        }
        public void SetCacheMode(QGraphicsItem.CacheMode mode, QSize cacheSize) {
            applet.SetCacheMode(mode, cacheSize);
        }
        public void SetCacheMode(QGraphicsItem.CacheMode mode) {
            applet.SetCacheMode(mode);
        }
        public string ToolTip() {
            return applet.ToolTip();
        }
        public void SetToolTip(string toolTip) {
            applet.SetToolTip(toolTip);
        }
        public QCursor Cursor() {
            return applet.Cursor();
        }
        public void SetCursor(QCursor cursor) {
            applet.SetCursor(cursor);
        }
        public bool HasCursor() {
            return applet.HasCursor();
        }
        public void UnsetCursor() {
            applet.UnsetCursor();
        }
        public bool IsVisible() {
            return applet.IsVisible();
        }
        public bool IsVisibleTo(IQGraphicsItem parent) {
            return applet.IsVisibleTo(parent);
        }
        public void SetVisible(bool visible) {
            applet.SetVisible(visible);
        }
        public void Hide() {
            applet.Hide();
        }
        public void Show() {
            applet.Show();
        }
        public bool IsEnabled() {
            return applet.IsEnabled();
        }
        public void SetEnabled(bool enabled) {
            applet.SetEnabled(enabled);
        }
        public bool IsSelected() {
            return applet.IsSelected();
        }
        public void SetSelected(bool selected) {
            applet.SetSelected(selected);
        }
        public bool AcceptDrops() {
            return applet.AcceptDrops();
        }
        public void SetAcceptDrops(bool on) {
            applet.SetAcceptDrops(on);
        }
        public uint AcceptedMouseButtons() {
            return applet.AcceptedMouseButtons();
        }
        public void SetAcceptedMouseButtons(uint buttons) {
            applet.SetAcceptedMouseButtons(buttons);
        }
        public bool AcceptsHoverEvents() {
            return applet.AcceptsHoverEvents();
        }
        public void SetAcceptsHoverEvents(bool enabled) {
            applet.SetAcceptsHoverEvents(enabled);
        }
        public bool AcceptHoverEvents() {
            return applet.AcceptHoverEvents();
        }
        public void SetAcceptHoverEvents(bool enabled) {
            applet.SetAcceptHoverEvents(enabled);
        }
        public bool HandlesChildEvents() {
            return applet.HandlesChildEvents();
        }
        public void SetHandlesChildEvents(bool enabled) {
            applet.SetHandlesChildEvents(enabled);
        }
        public bool HasFocus() {
            return applet.HasFocus();
        }
        public void SetFocus(Qt.FocusReason focusReason) {
            applet.SetFocus(focusReason);
        }
        public void SetFocus() {
            applet.SetFocus();
        }
        public void ClearFocus() {
            applet.ClearFocus();
        }
        public void GrabMouse() {
            applet.GrabMouse();
        }
        public void UngrabMouse() {
            applet.UngrabMouse();
        }
        public void GrabKeyboard() {
            applet.GrabKeyboard();
        }
        public void UngrabKeyboard() {
            applet.UngrabKeyboard();
        }
        public QPointF Pos() {
            return applet.Pos();
        }
        public double X() {
            return applet.X();
        }
        public double Y() {
            return applet.Y();
        }
        public QPointF ScenePos() {
            return applet.ScenePos();
        }
        public void SetPos(QPointF pos) {
            applet.SetPos(pos);
        }
        public void SetPos(double x, double y) {
            applet.SetPos(x, y);
        }
        public void MoveBy(double dx, double dy) {
            applet.MoveBy(dx, dy);
        }
        public void EnsureVisible(QRectF rect, int xmargin, int ymargin) {
            applet.EnsureVisible(rect, xmargin, ymargin);
        }
        public void EnsureVisible(QRectF rect, int xmargin) {
            applet.EnsureVisible(rect, xmargin);
        }
        public void EnsureVisible(QRectF rect) {
            applet.EnsureVisible(rect);
        }
        public void EnsureVisible() {
            applet.EnsureVisible();
        }
        public void EnsureVisible(double x, double y, double w, double h, int xmargin, int ymargin) {
            applet.EnsureVisible(x, y, w, h, xmargin, ymargin);
        }
        public void EnsureVisible(double x, double y, double w, double h, int xmargin) {
            applet.EnsureVisible(x, y, w, h, xmargin);
        }
        public void EnsureVisible(double x, double y, double w, double h) {
            applet.EnsureVisible(x, y, w, h);
        }
        public QMatrix Matrix() {
            return applet.Matrix();
        }
        public QMatrix SceneMatrix() {
            return applet.Matrix();
        }
        public void SetMatrix(QMatrix matrix, bool combine) {
            applet.SetMatrix(matrix, combine);
        }
        public void SetMatrix(QMatrix matrix) {
            applet.SetMatrix(matrix);
        }
        public void ResetMatrix() {
            applet.ResetMatrix();
        }
        public QTransform Transform() {
            return applet.Transform();
        }
        public QTransform SceneTransform() {
            return applet.SceneTransform();
        }
        public QTransform DeviceTransform(QTransform viewportTransform) {
            return applet.DeviceTransform(viewportTransform);
        }
        public void SetTransform(QTransform matrix, bool combine) {
            applet.SetTransform(matrix, combine);
        }
        public void SetTransform(QTransform matrix) {
            applet.SetTransform(matrix);
        }
        public void ResetTransform() {
            applet.ResetTransform();
        }
        public void Rotate(double angle) {
            applet.Rotate(angle);
        }
        public void Scale(double sx, double sy) {
            applet.Scale(sx, sy);
        }
        public void Shear(double sh, double sv) {
            applet.Shear(sh, sv);
        }
        public void Translate(double dx, double dy) {
            applet.Translate(dx, dy);
        }
        public virtual void Advance(int phase) {
            applet.Advance(phase);
        }
        public double ZValue() {
            return applet.ZValue();
        }
        public void SetZValue(double z) {
            applet.SetZValue(z);
        }
        public QRectF ChildrenBoundingRect() {
            return applet.ChildrenBoundingRect();
        }
        public QRectF SceneBoundingRect() {
            return applet.SceneBoundingRect();
        }
        public virtual bool Contains(QPointF point) {
            return applet.Contains(point);
        }
        public virtual bool CollidesWithItem(IQGraphicsItem other, Qt.ItemSelectionMode mode) {
            return applet.CollidesWithItem(other, mode);
        }
        public virtual bool CollidesWithItem(IQGraphicsItem other) {
            return applet.CollidesWithItem(other);
        }
        public virtual bool CollidesWithPath(QPainterPath path, Qt.ItemSelectionMode mode) {
            return applet.CollidesWithPath(path, mode);
        }
        public virtual bool CollidesWithPath(QPainterPath path) {
            return applet.CollidesWithPath(path);
        }
        public List<IQGraphicsItem> CollidingItems(Qt.ItemSelectionMode mode) {
            return applet.CollidingItems(mode);
        }
        public List<IQGraphicsItem> CollidingItems() {
            return applet.CollidingItems();
        }
        public bool IsObscured() {
            return applet.IsObscured();
        }
        public bool IsObscured(QRectF rect) {
            return applet.IsObscured(rect);
        }
        public bool IsObscured(double x, double y, double w, double h) {
            return applet.IsObscured(x, y, w, h);
        }
        public virtual bool IsObscuredBy(IQGraphicsItem item) {
            return applet.IsObscuredBy(item);
        }
        public virtual QPainterPath OpaqueArea() {
            return applet.OpaqueArea();
        }
        public QRegion BoundingRegion(QTransform itemToDeviceTransform) {
            return applet.BoundingRegion(itemToDeviceTransform);
        }
        public double BoundingRegionGranularity() {
            return applet.BoundingRegionGranularity();
        }
        public void SetBoundingRegionGranularity(double granularity) {
            applet.SetBoundingRegionGranularity(granularity);
        }
        public void Update(QRectF rect) {
            applet.Update(rect);
        }
        public void Update() {
            applet.Update();
        }
        public void Update(double x, double y, double width, double height) {
            applet.Update(x, y, width, height);
        }
        public void Scroll(double dx, double dy, QRectF rect) {
            applet.Scroll(dx, dy, rect);
        }
        public void Scroll(double dx, double dy) {
            applet.Scroll(dx, dy);
        }
        public QPointF MapToItem(IQGraphicsItem item, QPointF point) {
            return applet.MapToItem(item, point);
        }
        public QPointF MapToParent(QPointF point) {
            return applet.MapToParent(point);
        }
        public QPointF MapToScene(QPointF point) {
            return applet.MapToScene(point);
        }
        public QPolygonF MapToItem(IQGraphicsItem item, QRectF rect) {
            return applet.MapToItem(item, rect);
        }
        public QPolygonF MapToParent(QRectF rect) {
            return applet.MapToParent(rect);
        }
        public QPolygonF MapToScene(QRectF rect) {
            return applet.MapToScene(rect);
        }
        public QPolygonF MapToItem(IQGraphicsItem item, QPolygonF polygon) {
            return applet.MapToItem(item, polygon);
        }
        public QPolygonF MapToParent(QPolygonF polygon) {
            return applet.MapToParent(polygon);
        }
        public QPolygonF MapToScene(QPolygonF polygon) {
            return applet.MapToScene(polygon);
        }
        public QPainterPath MapToItem(IQGraphicsItem item, QPainterPath path) {
            return applet.MapToItem(item, path);
        }
        public QPainterPath MapToParent(QPainterPath path) {
            return applet.MapToParent(path);
        }
        public QPainterPath MapToScene(QPainterPath path) {
            return applet.MapToScene(path);
        }
        public QPointF MapFromItem(IQGraphicsItem item, QPointF point) {
            return applet.MapFromItem(item, point);
        }
        public QPointF MapFromParent(QPointF point) {
            return applet.MapFromParent(point);
        }
        public QPointF MapFromScene(QPointF point) {
            return applet.MapFromScene(point);
        }
        public QPolygonF MapFromItem(IQGraphicsItem item, QRectF rect) {
            return applet.MapFromItem(item, rect);
        }
        public QPolygonF MapFromParent(QRectF rect) {
            return applet.MapFromParent(rect);
        }
        public QPolygonF MapFromScene(QRectF rect) {
            return applet.MapFromScene(rect);
        }
        public QPolygonF MapFromItem(IQGraphicsItem item, QPolygonF polygon) {
            return applet.MapFromItem(item, polygon);
        }
        public QPolygonF MapFromParent(QPolygonF polygon) {
            return applet.MapFromParent(polygon);
        }
        public QPolygonF MapFromScene(QPolygonF polygon) {
            return applet.MapFromScene(polygon);
        }
        public QPainterPath MapFromItem(IQGraphicsItem item, QPainterPath path) {
            return applet.MapFromItem(item, path);
        }
        public QPainterPath MapFromParent(QPainterPath path) {
            return applet.MapFromParent(path);
        }
        public QPainterPath MapFromScene(QPainterPath path) {
            return applet.MapFromScene(path);
        }
        public QPointF MapToItem(IQGraphicsItem item, double x, double y) {
            return applet.MapToItem(item, x, y);
        }
        public QPointF MapToParent(double x, double y) {
            return applet.MapToParent(x, y);
        }
        public QPointF MapToScene(double x, double y) {
            return applet.MapToScene(x, y);
        }
        public QPolygonF MapToItem(IQGraphicsItem item, double x, double y, double w, double h) {
            return applet.MapToItem(item, x, y, w, h);
        }
        public QPolygonF MapToParent(double x, double y, double w, double h) {
            return applet.MapToParent(x, y, w, h);
        }
        public QPolygonF MapToScene(double x, double y, double w, double h) {
            return applet.MapToScene(x, y, w, h);
        }
        public QPointF MapFromItem(IQGraphicsItem item, double x, double y) {
            return applet.MapFromItem(item, x, y);
        }
        public QPointF MapFromParent(double x, double y) {
            return applet.MapFromParent(x, y);
        }
        public QPointF MapFromScene(double x, double y) {
            return applet.MapFromScene(x, y);
        }
        public QPolygonF MapFromItem(IQGraphicsItem item, double x, double y, double w, double h) {
            return applet.MapFromItem(item, x, y, w, h);
        }
        public QPolygonF MapFromParent(double x, double y, double w, double h) {
            return applet.MapFromParent(x, y, w, h);
        }
        public QPolygonF MapFromScene(double x, double y, double w, double h) {
            return applet.MapFromScene(x, y, w, h);
        }
        public bool IsAncestorOf(IQGraphicsItem child) {
            return applet.IsAncestorOf(child);
        }
        public IQGraphicsItem CommonAncestorItem(IQGraphicsItem other) {
            return applet.CommonAncestorItem(other);
        }
        public bool IsUnderMouse() {
            return applet.IsUnderMouse();
        }
        public QVariant Data(int key) {
            return applet.Data(key);
        }
        public void SetData(int key, QVariant value) {
            applet.SetData(key, value);
        }
        public void InstallSceneEventFilter(IQGraphicsItem filterItem) {
            applet.InstallSceneEventFilter(filterItem);
        }
        public void RemoveSceneEventFilter(IQGraphicsItem filterItem) {
            applet.RemoveSceneEventFilter(filterItem);
        }
        protected virtual bool SceneEventFilter(IQGraphicsItem watched, QEvent arg2) {
            return false;
        }
        protected virtual void ContextMenuEvent(QGraphicsSceneContextMenuEvent arg1) {
        }
        protected virtual void DragEnterEvent(QGraphicsSceneDragDropEvent arg1) {
        }
        protected virtual void DragLeaveEvent(QGraphicsSceneDragDropEvent arg1) {
        }
        protected virtual void DragMoveEvent(QGraphicsSceneDragDropEvent arg1) {
        }
        protected virtual void DropEvent(QGraphicsSceneDragDropEvent arg1) {
        }
        protected virtual void HoverEnterEvent(QGraphicsSceneHoverEvent arg1) {
        }
        protected virtual void KeyPressEvent(QKeyEvent arg1) {
        }
        protected virtual void KeyReleaseEvent(QKeyEvent arg1) {
        }
        protected virtual void MousePressEvent(QGraphicsSceneMouseEvent arg1) {
        }
        protected virtual void MouseMoveEvent(QGraphicsSceneMouseEvent arg1) {
        }
        protected virtual void MouseReleaseEvent(QGraphicsSceneMouseEvent arg1) {
        }
        protected virtual void MouseDoubleClickEvent(QGraphicsSceneMouseEvent arg1) {
        }
        protected virtual void WheelEvent(QGraphicsSceneWheelEvent arg1) {
        }
        protected virtual void InputMethodEvent(QInputMethodEvent arg1) {
        }
        protected virtual QVariant InputMethodQuery(Qt.InputMethodQuery query) {
            return null;
        }
        protected virtual bool SupportsExtension(QGraphicsItem.Extension extension) {
            return false;
        }
        protected virtual void SetExtension(QGraphicsItem.Extension extension, QVariant variant) {
        }
        protected virtual QVariant extension(QVariant variant) {
            return null;
        }
        protected void AddToIndex() {
        }
        protected void RemoveFromIndex() {
        }
        protected void PrepareGeometryChange() {
        }
        public void SetSizePolicy(QSizePolicy policy) {
            applet.SetSizePolicy(policy);
        }
        public void SetSizePolicy(QSizePolicy.Policy hPolicy, QSizePolicy.Policy vPolicy, QSizePolicy.ControlType controlType) {
            applet.SetSizePolicy(hPolicy, vPolicy, controlType);
        }
        public void SetSizePolicy(QSizePolicy.Policy hPolicy, QSizePolicy.Policy vPolicy) {
            applet.SetSizePolicy(hPolicy, vPolicy);
        }
        public QSizePolicy SizePolicy() {
            return applet.SizePolicy();
        }
        public void SetMinimumSize(QSizeF size) {
            applet.SetMinimumSize(size);
        }
        public void SetMinimumSize(double w, double h) {
            applet.SetMinimumSize(w, h);
        }
        public QSizeF MinimumSize() {
            return applet.MinimumSize();
        }
        public void SetMinimumWidth(double width) {
            applet.SetMinimumWidth(width);
        }
        public double MinimumWidth() {
            return applet.MinimumWidth();
        }
        public void SetMinimumHeight(double height) {
            applet.SetMinimumHeight(height);
        }
        public double MinimumHeight() {
            return applet.MinimumHeight();
        }
        public void SetPreferredSize(QSizeF size) {
            applet.SetPreferredSize(size);
        }
        public void SetPreferredSize(double w, double h) {
            applet.SetPreferredSize(w, h);
        }
        public QSizeF PreferredSize() {
            return applet.PreferredSize();
        }
        public void SetPreferredWidth(double width) {
            applet.SetPreferredWidth(width);
        }
        public double PreferredWidth() {
            return applet.PreferredWidth();
        }
        public void SetPreferredHeight(double height) {
            applet.SetPreferredHeight(height);
        }
        public double PreferredHeight() {
            return applet.PreferredHeight();
        }
        public void SetMaximumSize(QSizeF size) {
            applet.SetMaximumSize(size);
        }
        public void SetMaximumSize(double w, double h) {
            applet.SetMaximumSize(w, h);
        }
        public QSizeF MaximumSize() {
            return applet.MaximumSize();
        }
        public void SetMaximumWidth(double width) {
            applet.SetMaximumWidth(width);
        }
        public double MaximumWidth() {
            return applet.MaximumWidth();
        }
        public void SetMaximumHeight(double height) {
            applet.SetMaximumHeight(height);
        }
        public double MaximumHeight() {
            return applet.MaximumHeight();
        }
        public QRectF Geometry() {
            return applet.Geometry;
        }
        public QRectF ContentsRect() {
            return applet.ContentsRect();
        }
        public QSizeF EffectiveSizeHint(Qt.SizeHint which, QSizeF constraint) {
            return applet.EffectiveSizeHint(which, constraint);
        }
        public QSizeF EffectiveSizeHint(Qt.SizeHint which) {
            return applet.EffectiveSizeHint(which);
        }
        public IQGraphicsLayoutItem ParentLayoutItem() {
            return applet.ParentLayoutItem();
        }
        public void SetParentLayoutItem(QGraphicsLayoutItem parent) {
            applet.SetParentLayoutItem(parent);
        }
        public bool IsLayout() {
            return applet.IsLayout();
        }
        protected new IQGraphicsWidgetSignals Emit {
            get { return (IQGraphicsWidgetSignals) Q_EMIT; }
        }
        public static implicit operator QyotoQGraphicsWidget(QGraphicsWidget arg) {
            return arg.PlasmaApplet;
        }
    }

    public interface IQGraphicsWidgetSignals : IQObjectSignals {
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;
