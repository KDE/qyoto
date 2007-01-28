//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QSqlRelationalTableModel")]
	public class QSqlRelationalTableModel : QSqlTableModel, IDisposable {
 		protected QSqlRelationalTableModel(Type dummy) : base((Type) null) {}
		interface IQSqlRelationalTableModelProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSqlRelationalTableModel), this);
			_interceptor = (QSqlRelationalTableModel) realProxy.GetTransparentProxy();
		}
		private QSqlRelationalTableModel ProxyQSqlRelationalTableModel() {
			return (QSqlRelationalTableModel) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSqlRelationalTableModel() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlRelationalTableModelProxy), null);
			_staticInterceptor = (IQSqlRelationalTableModelProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlRelationalTableModelProxy StaticQSqlRelationalTableModel() {
			return (IQSqlRelationalTableModelProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QSqlRelationalTableModel(QObject parent, QSqlDatabase db) : this((Type) null) {
			CreateProxy();
			NewQSqlRelationalTableModel(parent,db);
		}
		[SmokeMethod("QSqlRelationalTableModel(QObject*, QSqlDatabase)")]
		private void NewQSqlRelationalTableModel(QObject parent, QSqlDatabase db) {
			ProxyQSqlRelationalTableModel().NewQSqlRelationalTableModel(parent,db);
		}
		public QSqlRelationalTableModel(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQSqlRelationalTableModel(parent);
		}
		[SmokeMethod("QSqlRelationalTableModel(QObject*)")]
		private void NewQSqlRelationalTableModel(QObject parent) {
			ProxyQSqlRelationalTableModel().NewQSqlRelationalTableModel(parent);
		}
		public QSqlRelationalTableModel() : this((Type) null) {
			CreateProxy();
			NewQSqlRelationalTableModel();
		}
		[SmokeMethod("QSqlRelationalTableModel()")]
		private void NewQSqlRelationalTableModel() {
			ProxyQSqlRelationalTableModel().NewQSqlRelationalTableModel();
		}
		[SmokeMethod("data(const QModelIndex&, int) const")]
		public new QVariant Data(QModelIndex item, int role) {
			return ProxyQSqlRelationalTableModel().Data(item,role);
		}
		[SmokeMethod("data(const QModelIndex&) const")]
		public new QVariant Data(QModelIndex item) {
			return ProxyQSqlRelationalTableModel().Data(item);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&, int)")]
		public new bool SetData(QModelIndex item, QVariant value, int role) {
			return ProxyQSqlRelationalTableModel().SetData(item,value,role);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&)")]
		public new bool SetData(QModelIndex item, QVariant value) {
			return ProxyQSqlRelationalTableModel().SetData(item,value);
		}
		[SmokeMethod("removeColumns(int, int, const QModelIndex&)")]
		public new bool RemoveColumns(int column, int count, QModelIndex parent) {
			return ProxyQSqlRelationalTableModel().RemoveColumns(column,count,parent);
		}
		[SmokeMethod("removeColumns(int, int)")]
		public new bool RemoveColumns(int column, int count) {
			return ProxyQSqlRelationalTableModel().RemoveColumns(column,count);
		}
		[SmokeMethod("clear()")]
		public new void Clear() {
			ProxyQSqlRelationalTableModel().Clear();
		}
		[SmokeMethod("select()")]
		public new bool Select() {
			return ProxyQSqlRelationalTableModel().Select();
		}
		[SmokeMethod("setTable(const QString&)")]
		public new void SetTable(string tableName) {
			ProxyQSqlRelationalTableModel().SetTable(tableName);
		}
		[SmokeMethod("setRelation(int, const QSqlRelation&)")]
		public virtual void SetRelation(int column, QSqlRelation relation) {
			ProxyQSqlRelationalTableModel().SetRelation(column,relation);
		}
		[SmokeMethod("relation(int) const")]
		public QSqlRelation Relation(int column) {
			return ProxyQSqlRelationalTableModel().Relation(column);
		}
		[SmokeMethod("relationModel(int) const")]
		public virtual QSqlTableModel RelationModel(int column) {
			return ProxyQSqlRelationalTableModel().RelationModel(column);
		}
		[Q_SLOT("void revertRow(int)")]
		[SmokeMethod("revertRow(int)")]
		public new void RevertRow(int row) {
			ProxyQSqlRelationalTableModel().RevertRow(row);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQSqlRelationalTableModel().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQSqlRelationalTableModel().Tr(s);
		}
		[SmokeMethod("selectStatement() const")]
		protected new string SelectStatement() {
			return ProxyQSqlRelationalTableModel().SelectStatement();
		}
		[SmokeMethod("updateRowInTable(int, const QSqlRecord&)")]
		protected new bool UpdateRowInTable(int row, QSqlRecord values) {
			return ProxyQSqlRelationalTableModel().UpdateRowInTable(row,values);
		}
		[SmokeMethod("insertRowIntoTable(const QSqlRecord&)")]
		protected new bool InsertRowIntoTable(QSqlRecord values) {
			return ProxyQSqlRelationalTableModel().InsertRowIntoTable(values);
		}
		[SmokeMethod("orderByClause() const")]
		protected new string OrderByClause() {
			return ProxyQSqlRelationalTableModel().OrderByClause();
		}
		~QSqlRelationalTableModel() {
			DisposeQSqlRelationalTableModel();
		}
		public new void Dispose() {
			DisposeQSqlRelationalTableModel();
		}
		[SmokeMethod("~QSqlRelationalTableModel()")]
		private void DisposeQSqlRelationalTableModel() {
			ProxyQSqlRelationalTableModel().DisposeQSqlRelationalTableModel();
		}
		protected new IQSqlRelationalTableModelSignals Emit {
			get {
				return (IQSqlRelationalTableModelSignals) Q_EMIT;
			}
		}
	}

	public interface IQSqlRelationalTableModelSignals : IQSqlTableModelSignals {
	}
}
