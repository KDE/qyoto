//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QTableView")]
	public class QTableView : QAbstractItemView, IDisposable {
 		protected QTableView(Type dummy) : base((Type) null) {}
		interface IQTableViewProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTableView), this);
			_interceptor = (QTableView) realProxy.GetTransparentProxy();
		}
		private QTableView ProxyQTableView() {
			return (QTableView) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTableView() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTableViewProxy), null);
			_staticInterceptor = (IQTableViewProxy) realProxy.GetTransparentProxy();
		}
		private static IQTableViewProxy StaticQTableView() {
			return (IQTableViewProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QTableView(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQTableView(parent);
		}
		[SmokeMethod("QTableView(QWidget*)")]
		private void NewQTableView(QWidget parent) {
			ProxyQTableView().NewQTableView(parent);
		}
		public QTableView() : this((Type) null) {
			CreateProxy();
			NewQTableView();
		}
		[SmokeMethod("QTableView()")]
		private void NewQTableView() {
			ProxyQTableView().NewQTableView();
		}
		[SmokeMethod("setModel(QAbstractItemModel*)")]
		public new void SetModel(QAbstractItemModel model) {
			ProxyQTableView().SetModel(model);
		}
		[SmokeMethod("setRootIndex(const QModelIndex&)")]
		public new void SetRootIndex(QModelIndex index) {
			ProxyQTableView().SetRootIndex(index);
		}
		[SmokeMethod("setSelectionModel(QItemSelectionModel*)")]
		public new void SetSelectionModel(QItemSelectionModel selectionModel) {
			ProxyQTableView().SetSelectionModel(selectionModel);
		}
		[SmokeMethod("horizontalHeader() const")]
		public QHeaderView HorizontalHeader() {
			return ProxyQTableView().HorizontalHeader();
		}
		[SmokeMethod("verticalHeader() const")]
		public QHeaderView VerticalHeader() {
			return ProxyQTableView().VerticalHeader();
		}
		[SmokeMethod("setHorizontalHeader(QHeaderView*)")]
		public void SetHorizontalHeader(QHeaderView header) {
			ProxyQTableView().SetHorizontalHeader(header);
		}
		[SmokeMethod("setVerticalHeader(QHeaderView*)")]
		public void SetVerticalHeader(QHeaderView header) {
			ProxyQTableView().SetVerticalHeader(header);
		}
		[SmokeMethod("rowViewportPosition(int) const")]
		public int RowViewportPosition(int row) {
			return ProxyQTableView().RowViewportPosition(row);
		}
		[SmokeMethod("rowAt(int) const")]
		public int RowAt(int y) {
			return ProxyQTableView().RowAt(y);
		}
		[SmokeMethod("setRowHeight(int, int)")]
		public void SetRowHeight(int row, int height) {
			ProxyQTableView().SetRowHeight(row,height);
		}
		[SmokeMethod("rowHeight(int) const")]
		public int RowHeight(int row) {
			return ProxyQTableView().RowHeight(row);
		}
		[SmokeMethod("columnViewportPosition(int) const")]
		public int ColumnViewportPosition(int column) {
			return ProxyQTableView().ColumnViewportPosition(column);
		}
		[SmokeMethod("columnAt(int) const")]
		public int ColumnAt(int x) {
			return ProxyQTableView().ColumnAt(x);
		}
		[SmokeMethod("setColumnWidth(int, int)")]
		public void SetColumnWidth(int column, int width) {
			ProxyQTableView().SetColumnWidth(column,width);
		}
		[SmokeMethod("columnWidth(int) const")]
		public int ColumnWidth(int column) {
			return ProxyQTableView().ColumnWidth(column);
		}
		[SmokeMethod("isRowHidden(int) const")]
		public bool IsRowHidden(int row) {
			return ProxyQTableView().IsRowHidden(row);
		}
		[SmokeMethod("setRowHidden(int, bool)")]
		public void SetRowHidden(int row, bool hide) {
			ProxyQTableView().SetRowHidden(row,hide);
		}
		[SmokeMethod("isColumnHidden(int) const")]
		public bool IsColumnHidden(int column) {
			return ProxyQTableView().IsColumnHidden(column);
		}
		[SmokeMethod("setColumnHidden(int, bool)")]
		public void SetColumnHidden(int column, bool hide) {
			ProxyQTableView().SetColumnHidden(column,hide);
		}
		[SmokeMethod("showGrid() const")]
		public bool ShowGrid() {
			return ProxyQTableView().ShowGrid();
		}
		[SmokeMethod("gridStyle() const")]
		public Qt.PenStyle GridStyle() {
			return ProxyQTableView().GridStyle();
		}
		[SmokeMethod("setGridStyle(Qt::PenStyle)")]
		public void SetGridStyle(Qt.PenStyle style) {
			ProxyQTableView().SetGridStyle(style);
		}
		[SmokeMethod("visualRect(const QModelIndex&) const")]
		public new QRect VisualRect(QModelIndex index) {
			return ProxyQTableView().VisualRect(index);
		}
		[SmokeMethod("scrollTo(const QModelIndex&, QAbstractItemView::ScrollHint)")]
		public new void ScrollTo(QModelIndex index, QAbstractItemView.ScrollHint hint) {
			ProxyQTableView().ScrollTo(index,hint);
		}
		[SmokeMethod("scrollTo(const QModelIndex&)")]
		public new void ScrollTo(QModelIndex index) {
			ProxyQTableView().ScrollTo(index);
		}
		[SmokeMethod("indexAt(const QPoint&) const")]
		public new QModelIndex IndexAt(QPoint p) {
			return ProxyQTableView().IndexAt(p);
		}
		[SmokeMethod("selectRow(int)")]
		public void SelectRow(int row) {
			ProxyQTableView().SelectRow(row);
		}
		[SmokeMethod("selectColumn(int)")]
		public void SelectColumn(int column) {
			ProxyQTableView().SelectColumn(column);
		}
		[SmokeMethod("hideRow(int)")]
		public void HideRow(int row) {
			ProxyQTableView().HideRow(row);
		}
		[SmokeMethod("hideColumn(int)")]
		public void HideColumn(int column) {
			ProxyQTableView().HideColumn(column);
		}
		[SmokeMethod("showRow(int)")]
		public void ShowRow(int row) {
			ProxyQTableView().ShowRow(row);
		}
		[SmokeMethod("showColumn(int)")]
		public void ShowColumn(int column) {
			ProxyQTableView().ShowColumn(column);
		}
		[SmokeMethod("resizeRowToContents(int)")]
		public void ResizeRowToContents(int row) {
			ProxyQTableView().ResizeRowToContents(row);
		}
		[SmokeMethod("resizeRowsToContents()")]
		public void ResizeRowsToContents() {
			ProxyQTableView().ResizeRowsToContents();
		}
		[SmokeMethod("resizeColumnToContents(int)")]
		public void ResizeColumnToContents(int column) {
			ProxyQTableView().ResizeColumnToContents(column);
		}
		[SmokeMethod("resizeColumnsToContents()")]
		public void ResizeColumnsToContents() {
			ProxyQTableView().ResizeColumnsToContents();
		}
		[SmokeMethod("sortByColumn(int)")]
		public void SortByColumn(int column) {
			ProxyQTableView().SortByColumn(column);
		}
		[SmokeMethod("setShowGrid(bool)")]
		public void SetShowGrid(bool show) {
			ProxyQTableView().SetShowGrid(show);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQTableView().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQTableView().Tr(s);
		}
		[SmokeMethod("rowMoved(int, int, int)")]
		protected void RowMoved(int row, int oldIndex, int newIndex) {
			ProxyQTableView().RowMoved(row,oldIndex,newIndex);
		}
		[SmokeMethod("columnMoved(int, int, int)")]
		protected void ColumnMoved(int column, int oldIndex, int newIndex) {
			ProxyQTableView().ColumnMoved(column,oldIndex,newIndex);
		}
		[SmokeMethod("rowResized(int, int, int)")]
		protected void RowResized(int row, int oldHeight, int newHeight) {
			ProxyQTableView().RowResized(row,oldHeight,newHeight);
		}
		[SmokeMethod("columnResized(int, int, int)")]
		protected void ColumnResized(int column, int oldWidth, int newWidth) {
			ProxyQTableView().ColumnResized(column,oldWidth,newWidth);
		}
		[SmokeMethod("rowCountChanged(int, int)")]
		protected void RowCountChanged(int oldCount, int newCount) {
			ProxyQTableView().RowCountChanged(oldCount,newCount);
		}
		[SmokeMethod("columnCountChanged(int, int)")]
		protected void ColumnCountChanged(int oldCount, int newCount) {
			ProxyQTableView().ColumnCountChanged(oldCount,newCount);
		}
		[SmokeMethod("scrollContentsBy(int, int)")]
		protected new void ScrollContentsBy(int dx, int dy) {
			ProxyQTableView().ScrollContentsBy(dx,dy);
		}
		[SmokeMethod("viewOptions() const")]
		protected new QStyleOptionViewItem ViewOptions() {
			return ProxyQTableView().ViewOptions();
		}
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected new void PaintEvent(QPaintEvent e) {
			ProxyQTableView().PaintEvent(e);
		}
		[SmokeMethod("timerEvent(QTimerEvent*)")]
		protected new void TimerEvent(QTimerEvent arg1) {
			ProxyQTableView().TimerEvent(arg1);
		}
		[SmokeMethod("horizontalOffset() const")]
		protected new int HorizontalOffset() {
			return ProxyQTableView().HorizontalOffset();
		}
		[SmokeMethod("verticalOffset() const")]
		protected new int VerticalOffset() {
			return ProxyQTableView().VerticalOffset();
		}
		[SmokeMethod("moveCursor(QAbstractItemView::CursorAction, Qt::KeyboardModifiers)")]
		protected new QModelIndex MoveCursor(QAbstractItemView.CursorAction cursorAction, int modifiers) {
			return ProxyQTableView().MoveCursor(cursorAction,modifiers);
		}
		[SmokeMethod("setSelection(const QRect&, QItemSelectionModel::SelectionFlags)")]
		protected new void SetSelection(QRect rect, int command) {
			ProxyQTableView().SetSelection(rect,command);
		}
		[SmokeMethod("visualRegionForSelection(const QItemSelection&) const")]
		protected new QRegion VisualRegionForSelection(QItemSelection selection) {
			return ProxyQTableView().VisualRegionForSelection(selection);
		}
		// QModelIndexList selectedIndexes(); >>>> NOT CONVERTED
		[SmokeMethod("updateGeometries()")]
		protected new void UpdateGeometries() {
			ProxyQTableView().UpdateGeometries();
		}
		[SmokeMethod("sizeHintForRow(int) const")]
		protected new int SizeHintForRow(int row) {
			return ProxyQTableView().SizeHintForRow(row);
		}
		[SmokeMethod("sizeHintForColumn(int) const")]
		protected new int SizeHintForColumn(int column) {
			return ProxyQTableView().SizeHintForColumn(column);
		}
		[SmokeMethod("verticalScrollbarAction(int)")]
		protected new void VerticalScrollbarAction(int action) {
			ProxyQTableView().VerticalScrollbarAction(action);
		}
		[SmokeMethod("horizontalScrollbarAction(int)")]
		protected new void HorizontalScrollbarAction(int action) {
			ProxyQTableView().HorizontalScrollbarAction(action);
		}
		[SmokeMethod("isIndexHidden(const QModelIndex&) const")]
		protected new bool IsIndexHidden(QModelIndex index) {
			return ProxyQTableView().IsIndexHidden(index);
		}
		~QTableView() {
			DisposeQTableView();
		}
		public new void Dispose() {
			DisposeQTableView();
		}
		private void DisposeQTableView() {
			ProxyQTableView().DisposeQTableView();
		}
		protected new IQTableViewSignals Emit() {
			return (IQTableViewSignals) Q_EMIT;
		}
	}

	public interface IQTableViewSignals : IQAbstractItemViewSignals {
	}
}
