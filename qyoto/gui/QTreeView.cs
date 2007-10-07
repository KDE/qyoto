//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	/// <remarks> See <see cref="IQTreeViewSignals"></see> for signals emitted by QTreeView
	/// </remarks>

	[SmokeClass("QTreeView")]
	public class QTreeView : QAbstractItemView, IDisposable {
 		protected QTreeView(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QTreeView), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QTreeView() {
			staticInterceptor = new SmokeInvocation(typeof(QTreeView), null);
		}
		[Q_PROPERTY("int", "autoExpandDelay")]
		public int AutoExpandDelay {
			get { return (int) interceptor.Invoke("autoExpandDelay", "autoExpandDelay()", typeof(int)); }
			set { interceptor.Invoke("setAutoExpandDelay$", "setAutoExpandDelay(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("int", "indentation")]
		public int Indentation {
			get { return (int) interceptor.Invoke("indentation", "indentation()", typeof(int)); }
			set { interceptor.Invoke("setIndentation$", "setIndentation(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("bool", "rootIsDecorated")]
		public bool RootIsDecorated {
			get { return (bool) interceptor.Invoke("rootIsDecorated", "rootIsDecorated()", typeof(bool)); }
			set { interceptor.Invoke("setRootIsDecorated$", "setRootIsDecorated(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "uniformRowHeights")]
		public bool UniformRowHeights {
			get { return (bool) interceptor.Invoke("uniformRowHeights", "uniformRowHeights()", typeof(bool)); }
			set { interceptor.Invoke("setUniformRowHeights$", "setUniformRowHeights(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "itemsExpandable")]
		public bool ItemsExpandable {
			get { return (bool) interceptor.Invoke("itemsExpandable", "itemsExpandable()", typeof(bool)); }
			set { interceptor.Invoke("setItemsExpandable$", "setItemsExpandable(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "sortingEnabled")]
		public bool SortingEnabled {
			get { return (bool) interceptor.Invoke("isSortingEnabled", "isSortingEnabled()", typeof(bool)); }
			set { interceptor.Invoke("setSortingEnabled$", "setSortingEnabled(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "animated")]
		public bool Animated {
			get { return (bool) interceptor.Invoke("isAnimated", "isAnimated()", typeof(bool)); }
			set { interceptor.Invoke("setAnimated$", "setAnimated(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "allColumnsShowFocus")]
		public bool AllColumnsShowFocus {
			get { return (bool) interceptor.Invoke("allColumnsShowFocus", "allColumnsShowFocus()", typeof(bool)); }
			set { interceptor.Invoke("setAllColumnsShowFocus$", "setAllColumnsShowFocus(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "wordWrap")]
		public bool WordWrap {
			get { return (bool) interceptor.Invoke("wordWrap", "wordWrap()", typeof(bool)); }
			set { interceptor.Invoke("setWordWrap$", "setWordWrap(bool)", typeof(void), typeof(bool), value); }
		}
		public QTreeView(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QTreeView#", "QTreeView(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public QTreeView() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QTreeView", "QTreeView()", typeof(void));
		}
		[SmokeMethod("setModel(QAbstractItemModel*)")]
		public override void SetModel(QAbstractItemModel model) {
			interceptor.Invoke("setModel#", "setModel(QAbstractItemModel*)", typeof(void), typeof(QAbstractItemModel), model);
		}
		[SmokeMethod("setRootIndex(const QModelIndex&)")]
		public override void SetRootIndex(QModelIndex index) {
			interceptor.Invoke("setRootIndex#", "setRootIndex(const QModelIndex&)", typeof(void), typeof(QModelIndex), index);
		}
		[SmokeMethod("setSelectionModel(QItemSelectionModel*)")]
		public override void SetSelectionModel(QItemSelectionModel selectionModel) {
			interceptor.Invoke("setSelectionModel#", "setSelectionModel(QItemSelectionModel*)", typeof(void), typeof(QItemSelectionModel), selectionModel);
		}
		public QHeaderView Header() {
			return (QHeaderView) interceptor.Invoke("header", "header() const", typeof(QHeaderView));
		}
		public void SetHeader(QHeaderView header) {
			interceptor.Invoke("setHeader#", "setHeader(QHeaderView*)", typeof(void), typeof(QHeaderView), header);
		}
		public int ColumnViewportPosition(int column) {
			return (int) interceptor.Invoke("columnViewportPosition$", "columnViewportPosition(int) const", typeof(int), typeof(int), column);
		}
		public int ColumnWidth(int column) {
			return (int) interceptor.Invoke("columnWidth$", "columnWidth(int) const", typeof(int), typeof(int), column);
		}
		public void SetColumnWidth(int column, int width) {
			interceptor.Invoke("setColumnWidth$$", "setColumnWidth(int, int)", typeof(void), typeof(int), column, typeof(int), width);
		}
		public int ColumnAt(int x) {
			return (int) interceptor.Invoke("columnAt$", "columnAt(int) const", typeof(int), typeof(int), x);
		}
		public bool IsColumnHidden(int column) {
			return (bool) interceptor.Invoke("isColumnHidden$", "isColumnHidden(int) const", typeof(bool), typeof(int), column);
		}
		public void SetColumnHidden(int column, bool hide) {
			interceptor.Invoke("setColumnHidden$$", "setColumnHidden(int, bool)", typeof(void), typeof(int), column, typeof(bool), hide);
		}
		public bool IsRowHidden(int row, QModelIndex parent) {
			return (bool) interceptor.Invoke("isRowHidden$#", "isRowHidden(int, const QModelIndex&) const", typeof(bool), typeof(int), row, typeof(QModelIndex), parent);
		}
		public void SetRowHidden(int row, QModelIndex parent, bool hide) {
			interceptor.Invoke("setRowHidden$#$", "setRowHidden(int, const QModelIndex&, bool)", typeof(void), typeof(int), row, typeof(QModelIndex), parent, typeof(bool), hide);
		}
		public bool IsFirstColumnSpanned(int row, QModelIndex parent) {
			return (bool) interceptor.Invoke("isFirstColumnSpanned$#", "isFirstColumnSpanned(int, const QModelIndex&) const", typeof(bool), typeof(int), row, typeof(QModelIndex), parent);
		}
		public void SetFirstColumnSpanned(int row, QModelIndex parent, bool span) {
			interceptor.Invoke("setFirstColumnSpanned$#$", "setFirstColumnSpanned(int, const QModelIndex&, bool)", typeof(void), typeof(int), row, typeof(QModelIndex), parent, typeof(bool), span);
		}
		public bool IsExpanded(QModelIndex index) {
			return (bool) interceptor.Invoke("isExpanded#", "isExpanded(const QModelIndex&) const", typeof(bool), typeof(QModelIndex), index);
		}
		public void SetExpanded(QModelIndex index, bool expand) {
			interceptor.Invoke("setExpanded#$", "setExpanded(const QModelIndex&, bool)", typeof(void), typeof(QModelIndex), index, typeof(bool), expand);
		}
		[SmokeMethod("keyboardSearch(const QString&)")]
		public override void KeyboardSearch(string search) {
			interceptor.Invoke("keyboardSearch$", "keyboardSearch(const QString&)", typeof(void), typeof(string), search);
		}
		[SmokeMethod("visualRect(const QModelIndex&) const")]
		public override QRect VisualRect(QModelIndex index) {
			return (QRect) interceptor.Invoke("visualRect#", "visualRect(const QModelIndex&) const", typeof(QRect), typeof(QModelIndex), index);
		}
		[SmokeMethod("scrollTo(const QModelIndex&, QAbstractItemView::ScrollHint)")]
		public override void ScrollTo(QModelIndex index, QAbstractItemView.ScrollHint hint) {
			interceptor.Invoke("scrollTo#$", "scrollTo(const QModelIndex&, QAbstractItemView::ScrollHint)", typeof(void), typeof(QModelIndex), index, typeof(QAbstractItemView.ScrollHint), hint);
		}
		[SmokeMethod("scrollTo(const QModelIndex&)")]
		public virtual void ScrollTo(QModelIndex index) {
			interceptor.Invoke("scrollTo#", "scrollTo(const QModelIndex&)", typeof(void), typeof(QModelIndex), index);
		}
		[SmokeMethod("indexAt(const QPoint&) const")]
		public override QModelIndex IndexAt(QPoint p) {
			return (QModelIndex) interceptor.Invoke("indexAt#", "indexAt(const QPoint&) const", typeof(QModelIndex), typeof(QPoint), p);
		}
		public QModelIndex IndexAbove(QModelIndex index) {
			return (QModelIndex) interceptor.Invoke("indexAbove#", "indexAbove(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), index);
		}
		public QModelIndex IndexBelow(QModelIndex index) {
			return (QModelIndex) interceptor.Invoke("indexBelow#", "indexBelow(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), index);
		}
		[SmokeMethod("doItemsLayout()")]
		public override void DoItemsLayout() {
			interceptor.Invoke("doItemsLayout", "doItemsLayout()", typeof(void));
		}
		[SmokeMethod("reset()")]
		public override void Reset() {
			interceptor.Invoke("reset", "reset()", typeof(void));
		}
		public void SortByColumn(int column, Qt.SortOrder order) {
			interceptor.Invoke("sortByColumn$$", "sortByColumn(int, Qt::SortOrder)", typeof(void), typeof(int), column, typeof(Qt.SortOrder), order);
		}
		[Q_SLOT("void dataChanged(const QModelIndex&, const QModelIndex&)")]
		[SmokeMethod("dataChanged(const QModelIndex&, const QModelIndex&)")]
		public new virtual void DataChanged(QModelIndex topLeft, QModelIndex bottomRight) {
			interceptor.Invoke("dataChanged##", "dataChanged(const QModelIndex&, const QModelIndex&)", typeof(void), typeof(QModelIndex), topLeft, typeof(QModelIndex), bottomRight);
		}
		[Q_SLOT("void hideColumn(int)")]
		public void HideColumn(int column) {
			interceptor.Invoke("hideColumn$", "hideColumn(int)", typeof(void), typeof(int), column);
		}
		[Q_SLOT("void showColumn(int)")]
		public void ShowColumn(int column) {
			interceptor.Invoke("showColumn$", "showColumn(int)", typeof(void), typeof(int), column);
		}
		[Q_SLOT("void expand(const QModelIndex&)")]
		public void Expand(QModelIndex index) {
			interceptor.Invoke("expand#", "expand(const QModelIndex&)", typeof(void), typeof(QModelIndex), index);
		}
		[Q_SLOT("void collapse(const QModelIndex&)")]
		public void Collapse(QModelIndex index) {
			interceptor.Invoke("collapse#", "collapse(const QModelIndex&)", typeof(void), typeof(QModelIndex), index);
		}
		[Q_SLOT("void resizeColumnToContents(int)")]
		public void ResizeColumnToContents(int column) {
			interceptor.Invoke("resizeColumnToContents$", "resizeColumnToContents(int)", typeof(void), typeof(int), column);
		}
		[Q_SLOT("void sortByColumn(int)")]
		public void SortByColumn(int column) {
			interceptor.Invoke("sortByColumn$", "sortByColumn(int)", typeof(void), typeof(int), column);
		}
		[Q_SLOT("void selectAll()")]
		[SmokeMethod("selectAll()")]
		public override void SelectAll() {
			interceptor.Invoke("selectAll", "selectAll()", typeof(void));
		}
		[Q_SLOT("void expandAll()")]
		public void ExpandAll() {
			interceptor.Invoke("expandAll", "expandAll()", typeof(void));
		}
		[Q_SLOT("void collapseAll()")]
		public void CollapseAll() {
			interceptor.Invoke("collapseAll", "collapseAll()", typeof(void));
		}
		[Q_SLOT("void expandToDepth(int)")]
		public void ExpandToDepth(int depth) {
			interceptor.Invoke("expandToDepth$", "expandToDepth(int)", typeof(void), typeof(int), depth);
		}
		[SmokeMethod("scrollContentsBy(int, int)")]
		protected override void ScrollContentsBy(int dx, int dy) {
			interceptor.Invoke("scrollContentsBy$$", "scrollContentsBy(int, int)", typeof(void), typeof(int), dx, typeof(int), dy);
		}
		[SmokeMethod("rowsInserted(const QModelIndex&, int, int)")]
		protected override void RowsInserted(QModelIndex parent, int start, int end) {
			interceptor.Invoke("rowsInserted#$$", "rowsInserted(const QModelIndex&, int, int)", typeof(void), typeof(QModelIndex), parent, typeof(int), start, typeof(int), end);
		}
		[SmokeMethod("rowsAboutToBeRemoved(const QModelIndex&, int, int)")]
		protected override void RowsAboutToBeRemoved(QModelIndex parent, int start, int end) {
			interceptor.Invoke("rowsAboutToBeRemoved#$$", "rowsAboutToBeRemoved(const QModelIndex&, int, int)", typeof(void), typeof(QModelIndex), parent, typeof(int), start, typeof(int), end);
		}
		[SmokeMethod("moveCursor(QAbstractItemView::CursorAction, Qt::KeyboardModifiers)")]
		protected override QModelIndex MoveCursor(QAbstractItemView.CursorAction cursorAction, uint modifiers) {
			return (QModelIndex) interceptor.Invoke("moveCursor$$", "moveCursor(QAbstractItemView::CursorAction, Qt::KeyboardModifiers)", typeof(QModelIndex), typeof(QAbstractItemView.CursorAction), cursorAction, typeof(uint), modifiers);
		}
		[SmokeMethod("horizontalOffset() const")]
		protected override int HorizontalOffset() {
			return (int) interceptor.Invoke("horizontalOffset", "horizontalOffset() const", typeof(int));
		}
		[SmokeMethod("verticalOffset() const")]
		protected override int VerticalOffset() {
			return (int) interceptor.Invoke("verticalOffset", "verticalOffset() const", typeof(int));
		}
		[SmokeMethod("setSelection(const QRect&, QItemSelectionModel::SelectionFlags)")]
		protected override void SetSelection(QRect rect, uint command) {
			interceptor.Invoke("setSelection#$", "setSelection(const QRect&, QItemSelectionModel::SelectionFlags)", typeof(void), typeof(QRect), rect, typeof(uint), command);
		}
		[SmokeMethod("visualRegionForSelection(const QItemSelection&) const")]
		protected override QRegion VisualRegionForSelection(QItemSelection selection) {
			return (QRegion) interceptor.Invoke("visualRegionForSelection#", "visualRegionForSelection(const QItemSelection&) const", typeof(QRegion), typeof(QItemSelection), selection);
		}
		[SmokeMethod("selectedIndexes() const")]
		protected override List<QModelIndex> SelectedIndexes() {
			return (List<QModelIndex>) interceptor.Invoke("selectedIndexes", "selectedIndexes() const", typeof(List<QModelIndex>));
		}
		[SmokeMethod("timerEvent(QTimerEvent*)")]
		protected override void TimerEvent(QTimerEvent arg1) {
			interceptor.Invoke("timerEvent#", "timerEvent(QTimerEvent*)", typeof(void), typeof(QTimerEvent), arg1);
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected override void PaintEvent(QPaintEvent arg1) {
			interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), arg1);
		}
		protected void DrawTree(QPainter painter, QRegion region) {
			interceptor.Invoke("drawTree##", "drawTree(QPainter*, const QRegion&) const", typeof(void), typeof(QPainter), painter, typeof(QRegion), region);
		}
		[SmokeMethod("drawRow(QPainter*, const QStyleOptionViewItem&, const QModelIndex&) const")]
		protected virtual void DrawRow(QPainter painter, QStyleOptionViewItem options, QModelIndex index) {
			interceptor.Invoke("drawRow###", "drawRow(QPainter*, const QStyleOptionViewItem&, const QModelIndex&) const", typeof(void), typeof(QPainter), painter, typeof(QStyleOptionViewItem), options, typeof(QModelIndex), index);
		}
		[SmokeMethod("drawBranches(QPainter*, const QRect&, const QModelIndex&) const")]
		protected virtual void DrawBranches(QPainter painter, QRect rect, QModelIndex index) {
			interceptor.Invoke("drawBranches###", "drawBranches(QPainter*, const QRect&, const QModelIndex&) const", typeof(void), typeof(QPainter), painter, typeof(QRect), rect, typeof(QModelIndex), index);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected override void MousePressEvent(QMouseEvent arg1) {
			interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected override void MouseReleaseEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected override void MouseDoubleClickEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected override void MouseMoveEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected override void KeyPressEvent(QKeyEvent arg1) {
			interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), arg1);
		}
		[SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
		protected override void DragMoveEvent(QDragMoveEvent arg1) {
			interceptor.Invoke("dragMoveEvent#", "dragMoveEvent(QDragMoveEvent*)", typeof(void), typeof(QDragMoveEvent), arg1);
		}
		[SmokeMethod("viewportEvent(QEvent*)")]
		protected override bool ViewportEvent(QEvent arg1) {
			return (bool) interceptor.Invoke("viewportEvent#", "viewportEvent(QEvent*)", typeof(bool), typeof(QEvent), arg1);
		}
		[SmokeMethod("updateGeometries()")]
		protected override void UpdateGeometries() {
			interceptor.Invoke("updateGeometries", "updateGeometries()", typeof(void));
		}
		[SmokeMethod("sizeHintForColumn(int) const")]
		protected new virtual int SizeHintForColumn(int column) {
			return (int) interceptor.Invoke("sizeHintForColumn$", "sizeHintForColumn(int) const", typeof(int), typeof(int), column);
		}
		protected int IndexRowSizeHint(QModelIndex index) {
			return (int) interceptor.Invoke("indexRowSizeHint#", "indexRowSizeHint(const QModelIndex&) const", typeof(int), typeof(QModelIndex), index);
		}
		protected int RowHeight(QModelIndex index) {
			return (int) interceptor.Invoke("rowHeight#", "rowHeight(const QModelIndex&) const", typeof(int), typeof(QModelIndex), index);
		}
		[SmokeMethod("horizontalScrollbarAction(int)")]
		protected override void HorizontalScrollbarAction(int action) {
			interceptor.Invoke("horizontalScrollbarAction$", "horizontalScrollbarAction(int)", typeof(void), typeof(int), action);
		}
		[SmokeMethod("isIndexHidden(const QModelIndex&) const")]
		protected override bool IsIndexHidden(QModelIndex index) {
			return (bool) interceptor.Invoke("isIndexHidden#", "isIndexHidden(const QModelIndex&) const", typeof(bool), typeof(QModelIndex), index);
		}
		[SmokeMethod("selectionChanged(const QItemSelection&, const QItemSelection&)")]
		protected override void SelectionChanged(QItemSelection selected, QItemSelection deselected) {
			interceptor.Invoke("selectionChanged##", "selectionChanged(const QItemSelection&, const QItemSelection&)", typeof(void), typeof(QItemSelection), selected, typeof(QItemSelection), deselected);
		}
		[SmokeMethod("currentChanged(const QModelIndex&, const QModelIndex&)")]
		protected override void CurrentChanged(QModelIndex current, QModelIndex previous) {
			interceptor.Invoke("currentChanged##", "currentChanged(const QModelIndex&, const QModelIndex&)", typeof(void), typeof(QModelIndex), current, typeof(QModelIndex), previous);
		}
		[Q_SLOT("void columnResized(int, int, int)")]
		protected void ColumnResized(int column, int oldSize, int newSize) {
			interceptor.Invoke("columnResized$$$", "columnResized(int, int, int)", typeof(void), typeof(int), column, typeof(int), oldSize, typeof(int), newSize);
		}
		[Q_SLOT("void columnCountChanged(int, int)")]
		protected void ColumnCountChanged(int oldCount, int newCount) {
			interceptor.Invoke("columnCountChanged$$", "columnCountChanged(int, int)", typeof(void), typeof(int), oldCount, typeof(int), newCount);
		}
		[Q_SLOT("void columnMoved()")]
		protected void ColumnMoved() {
			interceptor.Invoke("columnMoved", "columnMoved()", typeof(void));
		}
		[Q_SLOT("void reexpand()")]
		protected void Reexpand() {
			interceptor.Invoke("reexpand", "reexpand()", typeof(void));
		}
		[Q_SLOT("void rowsRemoved(const QModelIndex&, int, int)")]
		protected void RowsRemoved(QModelIndex parent, int first, int last) {
			interceptor.Invoke("rowsRemoved#$$", "rowsRemoved(const QModelIndex&, int, int)", typeof(void), typeof(QModelIndex), parent, typeof(int), first, typeof(int), last);
		}
		~QTreeView() {
			interceptor.Invoke("~QTreeView", "~QTreeView()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QTreeView", "~QTreeView()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQTreeViewSignals Emit {
			get { return (IQTreeViewSignals) Q_EMIT; }
		}
	}

	public interface IQTreeViewSignals : IQAbstractItemViewSignals {
		[Q_SIGNAL("void expanded(const QModelIndex&)")]
		void Expanded(QModelIndex index);
		[Q_SIGNAL("void collapsed(const QModelIndex&)")]
		void Collapsed(QModelIndex index);
	}
}
