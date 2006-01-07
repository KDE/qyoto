//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QSqlDriver : QObject {
 		protected QSqlDriver(Type dummy) : base((Type) null) {}
		interface IQSqlDriverProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected void CreateQSqlDriverProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSqlDriver), this);
			_interceptor = (QSqlDriver) realProxy.GetTransparentProxy();
		}
		private QSqlDriver ProxyQSqlDriver() {
			return (QSqlDriver) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSqlDriver() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlDriverProxy), null);
			_staticInterceptor = (IQSqlDriverProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlDriverProxy StaticQSqlDriver() {
			return (IQSqlDriverProxy) _staticInterceptor;
		}

		enum DriverFeature {
			Transactions = 0,
			QuerySize = 1,
			BLOB = 2,
			Unicode = 3,
			PreparedQueries = 4,
			NamedPlaceholders = 5,
			PositionalPlaceholders = 6,
			LastInsertId = 7,
		}
		enum StatementType {
			WhereStatement = 0,
			SelectStatement = 1,
			UpdateStatement = 2,
			InsertStatement = 3,
			DeleteStatement = 4,
		}
		enum IdentifierType {
			FieldName = 0,
			TableName = 1,
		}
		public new virtual QMetaObject MetaObject() {
			return ProxyQSqlDriver().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public virtual bool IsOpen() {
			return ProxyQSqlDriver().IsOpen();
		}
		public bool IsOpenError() {
			return ProxyQSqlDriver().IsOpenError();
		}
		public virtual bool BeginTransaction() {
			return ProxyQSqlDriver().BeginTransaction();
		}
		public virtual bool CommitTransaction() {
			return ProxyQSqlDriver().CommitTransaction();
		}
		public virtual bool RollbackTransaction() {
			return ProxyQSqlDriver().RollbackTransaction();
		}
		public virtual ArrayList Tables(int tableType) {
			return ProxyQSqlDriver().Tables(tableType);
		}
		public virtual QSqlIndex PrimaryIndex(string tableName) {
			return ProxyQSqlDriver().PrimaryIndex(tableName);
		}
		public virtual QSqlRecord Record(string tableName) {
			return ProxyQSqlDriver().Record(tableName);
		}
		public virtual string FormatValue(QSqlField field, bool trimStrings) {
			return ProxyQSqlDriver().FormatValue(field,trimStrings);
		}
		public virtual string FormatValue(QSqlField field) {
			return ProxyQSqlDriver().FormatValue(field);
		}
		public virtual string EscapeIdentifier(string identifier, int type) {
			return ProxyQSqlDriver().EscapeIdentifier(identifier,type);
		}
		public virtual string SqlStatement(int type, string tableName, QSqlRecord rec, bool preparedStatement) {
			return ProxyQSqlDriver().SqlStatement(type,tableName,rec,preparedStatement);
		}
		public QSqlError LastError() {
			return ProxyQSqlDriver().LastError();
		}
		public virtual QVariant Handle() {
			return ProxyQSqlDriver().Handle();
		}
		public virtual bool HasFeature(int f) {
			return ProxyQSqlDriver().HasFeature(f);
		}
		public virtual void Close() {
			ProxyQSqlDriver().Close();
		}
		public virtual QSqlResult CreateResult() {
			return ProxyQSqlDriver().CreateResult();
		}
		public virtual bool Open(string db, string user, string password, string host, int port, string connOpts) {
			return ProxyQSqlDriver().Open(db,user,password,host,port,connOpts);
		}
		public virtual bool Open(string db, string user, string password, string host, int port) {
			return ProxyQSqlDriver().Open(db,user,password,host,port);
		}
		public virtual bool Open(string db, string user, string password, string host) {
			return ProxyQSqlDriver().Open(db,user,password,host);
		}
		public virtual bool Open(string db, string user, string password) {
			return ProxyQSqlDriver().Open(db,user,password);
		}
		public virtual bool Open(string db, string user) {
			return ProxyQSqlDriver().Open(db,user);
		}
		public virtual bool Open(string db) {
			return ProxyQSqlDriver().Open(db);
		}
		public static new string Tr(string s, string c) {
			return StaticQSqlDriver().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQSqlDriver().Tr(s);
		}
	}
}