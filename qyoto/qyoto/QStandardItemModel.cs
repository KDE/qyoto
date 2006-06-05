//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QStandardItemModel")]
	public class QStandardItemModel : QAbstractItemModel, IDisposable {
 		protected QStandardItemModel(Type dummy) : base((Type) null) {}
		interface IQStandardItemModelProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStandardItemModel), this);
			_interceptor = (QStandardItemModel) realProxy.GetTransparentProxy();
		}
		private QStandardItemModel ProxyQStandardItemModel() {
			return (QStandardItemModel) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStandardItemModel() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStandardItemModelProxy), null);
			_staticInterceptor = (IQStandardItemModelProxy) realProxy.GetTransparentProxy();
		}
		private static IQStandardItemModelProxy StaticQStandardItemModel() {
			return (IQStandardItemModelProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QStandardItemModel(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQStandardItemModel(parent);
		}
		[SmokeMethod("QStandardItemModel(QObject*)")]
		private void NewQStandardItemModel(QObject parent) {
			ProxyQStandardItemModel().NewQStandardItemModel(parent);
		}
		public QStandardItemModel() : this((Type) null) {
			CreateProxy();
			NewQStandardItemModel();
		}
		[SmokeMethod("QStandardItemModel()")]
		private void NewQStandardItemModel() {
			ProxyQStandardItemModel().NewQStandardItemModel();
		}
		public QStandardItemModel(int rows, int columns, QObject parent) : this((Type) null) {
			CreateProxy();
			NewQStandardItemModel(rows,columns,parent);
		}
		[SmokeMethod("QStandardItemModel(int, int, QObject*)")]
		private void NewQStandardItemModel(int rows, int columns, QObject parent) {
			ProxyQStandardItemModel().NewQStandardItemModel(rows,columns,parent);
		}
		public QStandardItemModel(int rows, int columns) : this((Type) null) {
			CreateProxy();
			NewQStandardItemModel(rows,columns);
		}
		[SmokeMethod("QStandardItemModel(int, int)")]
		private void NewQStandardItemModel(int rows, int columns) {
			ProxyQStandardItemModel().NewQStandardItemModel(rows,columns);
		}
		[SmokeMethod("index(int, int, const QModelIndex&) const")]
		public new QModelIndex Index(int row, int column, QModelIndex parent) {
			return ProxyQStandardItemModel().Index(row,column,parent);
		}
		[SmokeMethod("index(int, int) const")]
		public new QModelIndex Index(int row, int column) {
			return ProxyQStandardItemModel().Index(row,column);
		}
		[SmokeMethod("parent(const QModelIndex&) const")]
		public new QModelIndex Parent(QModelIndex child) {
			return ProxyQStandardItemModel().Parent(child);
		}
		[SmokeMethod("rowCount(const QModelIndex&) const")]
		public new int RowCount(QModelIndex parent) {
			return ProxyQStandardItemModel().RowCount(parent);
		}
		[SmokeMethod("rowCount() const")]
		public new int RowCount() {
			return ProxyQStandardItemModel().RowCount();
		}
		[SmokeMethod("columnCount(const QModelIndex&) const")]
		public new int ColumnCount(QModelIndex parent) {
			return ProxyQStandardItemModel().ColumnCount(parent);
		}
		[SmokeMethod("columnCount() const")]
		public new int ColumnCount() {
			return ProxyQStandardItemModel().ColumnCount();
		}
		[SmokeMethod("hasChildren(const QModelIndex&) const")]
		public new bool HasChildren(QModelIndex parent) {
			return ProxyQStandardItemModel().HasChildren(parent);
		}
		[SmokeMethod("hasChildren() const")]
		public new bool HasChildren() {
			return ProxyQStandardItemModel().HasChildren();
		}
		[SmokeMethod("data(const QModelIndex&, int) const")]
		public new QVariant Data(QModelIndex index, int role) {
			return ProxyQStandardItemModel().Data(index,role);
		}
		[SmokeMethod("data(const QModelIndex&) const")]
		public new QVariant Data(QModelIndex index) {
			return ProxyQStandardItemModel().Data(index);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&, int)")]
		public new bool SetData(QModelIndex index, QVariant value, int role) {
			return ProxyQStandardItemModel().SetData(index,value,role);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&)")]
		public new bool SetData(QModelIndex index, QVariant value) {
			return ProxyQStandardItemModel().SetData(index,value);
		}
		[SmokeMethod("headerData(int, Qt::Orientation, int) const")]
		public new QVariant HeaderData(int section, Qt.Orientation orientation, int role) {
			return ProxyQStandardItemModel().HeaderData(section,orientation,role);
		}
		[SmokeMethod("headerData(int, Qt::Orientation) const")]
		public new QVariant HeaderData(int section, Qt.Orientation orientation) {
			return ProxyQStandardItemModel().HeaderData(section,orientation);
		}
		[SmokeMethod("setHeaderData(int, Qt::Orientation, const QVariant&, int)")]
		public new bool SetHeaderData(int section, Qt.Orientation orientation, QVariant value, int role) {
			return ProxyQStandardItemModel().SetHeaderData(section,orientation,value,role);
		}
		[SmokeMethod("setHeaderData(int, Qt::Orientation, const QVariant&)")]
		public new bool SetHeaderData(int section, Qt.Orientation orientation, QVariant value) {
			return ProxyQStandardItemModel().SetHeaderData(section,orientation,value);
		}
		[SmokeMethod("insertRows(int, int, const QModelIndex&)")]
		public new bool InsertRows(int row, int count, QModelIndex parent) {
			return ProxyQStandardItemModel().InsertRows(row,count,parent);
		}
		[SmokeMethod("insertRows(int, int)")]
		public new bool InsertRows(int row, int count) {
			return ProxyQStandardItemModel().InsertRows(row,count);
		}
		[SmokeMethod("insertColumns(int, int, const QModelIndex&)")]
		public new bool InsertColumns(int column, int count, QModelIndex parent) {
			return ProxyQStandardItemModel().InsertColumns(column,count,parent);
		}
		[SmokeMethod("insertColumns(int, int)")]
		public new bool InsertColumns(int column, int count) {
			return ProxyQStandardItemModel().InsertColumns(column,count);
		}
		[SmokeMethod("removeRows(int, int, const QModelIndex&)")]
		public new bool RemoveRows(int row, int count, QModelIndex parent) {
			return ProxyQStandardItemModel().RemoveRows(row,count,parent);
		}
		[SmokeMethod("removeRows(int, int)")]
		public new bool RemoveRows(int row, int count) {
			return ProxyQStandardItemModel().RemoveRows(row,count);
		}
		[SmokeMethod("removeColumns(int, int, const QModelIndex&)")]
		public new bool RemoveColumns(int column, int count, QModelIndex parent) {
			return ProxyQStandardItemModel().RemoveColumns(column,count,parent);
		}
		[SmokeMethod("removeColumns(int, int)")]
		public new bool RemoveColumns(int column, int count) {
			return ProxyQStandardItemModel().RemoveColumns(column,count);
		}
		[SmokeMethod("flags(const QModelIndex&) const")]
		public new int Flags(QModelIndex index) {
			return ProxyQStandardItemModel().Flags(index);
		}
		[SmokeMethod("clear()")]
		public void Clear() {
			ProxyQStandardItemModel().Clear();
		}
		[SmokeMethod("parent() const")]
		public new QObject Parent() {
			return ProxyQStandardItemModel().Parent();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQStandardItemModel().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQStandardItemModel().Tr(s);
		}
		~QStandardItemModel() {
			DisposeQStandardItemModel();
		}
		public new void Dispose() {
			DisposeQStandardItemModel();
		}
		private void DisposeQStandardItemModel() {
			ProxyQStandardItemModel().DisposeQStandardItemModel();
		}
		protected new IQStandardItemModelSignals Emit() {
			return (IQStandardItemModelSignals) Q_EMIT;
		}
	}

	public interface IQStandardItemModelSignals : IQAbstractItemModelSignals {
	}
}
