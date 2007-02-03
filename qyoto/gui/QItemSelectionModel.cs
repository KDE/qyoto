//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	/// See <see cref="IQItemSelectionModelSignals"></see> for signals emitted by QItemSelectionModel
	[SmokeClass("QItemSelectionModel")]
	public class QItemSelectionModel : QObject, IDisposable {
 		protected QItemSelectionModel(Type dummy) : base((Type) null) {}
		interface IQItemSelectionModelProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QItemSelectionModel), this);
			_interceptor = (QItemSelectionModel) realProxy.GetTransparentProxy();
		}
		private QItemSelectionModel ProxyQItemSelectionModel() {
			return (QItemSelectionModel) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QItemSelectionModel() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQItemSelectionModelProxy), null);
			_staticInterceptor = (IQItemSelectionModelProxy) realProxy.GetTransparentProxy();
		}
		private static IQItemSelectionModelProxy StaticQItemSelectionModel() {
			return (IQItemSelectionModelProxy) _staticInterceptor;
		}

		public enum SelectionFlag {
			NoUpdate = 0x0000,
			Clear = 0x0001,
			Select = 0x0002,
			Deselect = 0x0004,
			Toggle = 0x0008,
			Current = 0x0010,
			Rows = 0x0020,
			Columns = 0x0040,
			SelectCurrent = Select|Current,
			ToggleCurrent = Toggle|Current,
			ClearAndSelect = Clear|Select,
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QItemSelectionModel(QAbstractItemModel model) : this((Type) null) {
			CreateProxy();
			NewQItemSelectionModel(model);
		}
		[SmokeMethod("QItemSelectionModel", "(QAbstractItemModel*)", "#")]
		private void NewQItemSelectionModel(QAbstractItemModel model) {
			ProxyQItemSelectionModel().NewQItemSelectionModel(model);
		}
		public QItemSelectionModel(QAbstractItemModel model, QObject parent) : this((Type) null) {
			CreateProxy();
			NewQItemSelectionModel(model,parent);
		}
		[SmokeMethod("QItemSelectionModel", "(QAbstractItemModel*, QObject*)", "##")]
		private void NewQItemSelectionModel(QAbstractItemModel model, QObject parent) {
			ProxyQItemSelectionModel().NewQItemSelectionModel(model,parent);
		}
		[SmokeMethod("currentIndex", "() const", "")]
		public QModelIndex CurrentIndex() {
			return ProxyQItemSelectionModel().CurrentIndex();
		}
		[SmokeMethod("isSelected", "(const QModelIndex&) const", "#")]
		public bool IsSelected(QModelIndex index) {
			return ProxyQItemSelectionModel().IsSelected(index);
		}
		[SmokeMethod("isRowSelected", "(int, const QModelIndex&) const", "$#")]
		public bool IsRowSelected(int row, QModelIndex parent) {
			return ProxyQItemSelectionModel().IsRowSelected(row,parent);
		}
		[SmokeMethod("isColumnSelected", "(int, const QModelIndex&) const", "$#")]
		public bool IsColumnSelected(int column, QModelIndex parent) {
			return ProxyQItemSelectionModel().IsColumnSelected(column,parent);
		}
		[SmokeMethod("rowIntersectsSelection", "(int, const QModelIndex&) const", "$#")]
		public bool RowIntersectsSelection(int row, QModelIndex parent) {
			return ProxyQItemSelectionModel().RowIntersectsSelection(row,parent);
		}
		[SmokeMethod("columnIntersectsSelection", "(int, const QModelIndex&) const", "$#")]
		public bool ColumnIntersectsSelection(int column, QModelIndex parent) {
			return ProxyQItemSelectionModel().ColumnIntersectsSelection(column,parent);
		}
		[SmokeMethod("hasSelection", "() const", "")]
		public bool HasSelection() {
			return ProxyQItemSelectionModel().HasSelection();
		}
		[SmokeMethod("selectedIndexes", "() const", "")]
		public List<QModelIndex> SelectedIndexes() {
			return ProxyQItemSelectionModel().SelectedIndexes();
		}
		[SmokeMethod("selectedRows", "(int) const", "$")]
		public List<QModelIndex> SelectedRows(int column) {
			return ProxyQItemSelectionModel().SelectedRows(column);
		}
		[SmokeMethod("selectedRows", "() const", "")]
		public List<QModelIndex> SelectedRows() {
			return ProxyQItemSelectionModel().SelectedRows();
		}
		[SmokeMethod("selectedColumns", "(int) const", "$")]
		public List<QModelIndex> SelectedColumns(int row) {
			return ProxyQItemSelectionModel().SelectedColumns(row);
		}
		[SmokeMethod("selectedColumns", "() const", "")]
		public List<QModelIndex> SelectedColumns() {
			return ProxyQItemSelectionModel().SelectedColumns();
		}
		[SmokeMethod("selection", "() const", "")]
		public QItemSelection Selection() {
			return ProxyQItemSelectionModel().Selection();
		}
		[SmokeMethod("model", "() const", "")]
		public QAbstractItemModel Model() {
			return ProxyQItemSelectionModel().Model();
		}
		[Q_SLOT("void setCurrentIndex(const QModelIndex&, QItemSelectionModel::SelectionFlags)")]
		[SmokeMethod("setCurrentIndex", "(const QModelIndex&, QItemSelectionModel::SelectionFlags)", "#$")]
		public void SetCurrentIndex(QModelIndex index, int command) {
			ProxyQItemSelectionModel().SetCurrentIndex(index,command);
		}
		[Q_SLOT("void select(const QModelIndex&, QItemSelectionModel::SelectionFlags)")]
		[SmokeMethod("select", "(const QModelIndex&, QItemSelectionModel::SelectionFlags)", "#$")]
		public virtual void Select(QModelIndex index, int command) {
			ProxyQItemSelectionModel().Select(index,command);
		}
		[Q_SLOT("void select(const QItemSelection&, QItemSelectionModel::SelectionFlags)")]
		[SmokeMethod("select", "(const QItemSelection&, QItemSelectionModel::SelectionFlags)", "#$")]
		public virtual void Select(QItemSelection selection, int command) {
			ProxyQItemSelectionModel().Select(selection,command);
		}
		[Q_SLOT("void clear()")]
		[SmokeMethod("clear", "()", "")]
		public virtual void Clear() {
			ProxyQItemSelectionModel().Clear();
		}
		[Q_SLOT("void reset()")]
		[SmokeMethod("reset", "()", "")]
		public virtual void Reset() {
			ProxyQItemSelectionModel().Reset();
		}
		[Q_SLOT("void clearSelection()")]
		[SmokeMethod("clearSelection", "()", "")]
		public void ClearSelection() {
			ProxyQItemSelectionModel().ClearSelection();
		}
		public static new string Tr(string s, string c) {
			return StaticQItemSelectionModel().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQItemSelectionModel().Tr(s);
		}
		[SmokeMethod("emitSelectionChanged", "(const QItemSelection&, const QItemSelection&)", "##")]
		protected void EmitSelectionChanged(QItemSelection newSelection, QItemSelection oldSelection) {
			ProxyQItemSelectionModel().EmitSelectionChanged(newSelection,oldSelection);
		}
		~QItemSelectionModel() {
			DisposeQItemSelectionModel();
		}
		public new void Dispose() {
			DisposeQItemSelectionModel();
		}
		[SmokeMethod("~QItemSelectionModel", "()", "")]
		private void DisposeQItemSelectionModel() {
			ProxyQItemSelectionModel().DisposeQItemSelectionModel();
		}
		protected new IQItemSelectionModelSignals Emit {
			get {
				return (IQItemSelectionModelSignals) Q_EMIT;
			}
		}
	}

	public interface IQItemSelectionModelSignals : IQObjectSignals {
		[Q_SIGNAL("void selectionChanged(const QItemSelection&, const QItemSelection&)")]
		void SelectionChanged(QItemSelection selected, QItemSelection deselected);
		[Q_SIGNAL("void currentChanged(const QModelIndex&, const QModelIndex&)")]
		void CurrentChanged(QModelIndex current, QModelIndex previous);
		[Q_SIGNAL("void currentRowChanged(const QModelIndex&, const QModelIndex&)")]
		void CurrentRowChanged(QModelIndex current, QModelIndex previous);
		[Q_SIGNAL("void currentColumnChanged(const QModelIndex&, const QModelIndex&)")]
		void CurrentColumnChanged(QModelIndex current, QModelIndex previous);
	}
}
