//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	public class QSql {
		protected Object _interceptor = null;
		interface IQSqlProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSql), this);
			_interceptor = (QSql) realProxy.GetTransparentProxy();
		}
		private QSql ProxyQSql() {
			return (QSql) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSql() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlProxy), null);
			_staticInterceptor = (IQSqlProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlProxy StaticQSql() {
			return (IQSqlProxy) _staticInterceptor;
		}

		public enum Location {
			BeforeFirstRow = -1,
			AfterLastRow = -2,
		}
		public enum ParamTypeFlag {
			In = 0x00000001,
			Out = 0x00000002,
			InOut = In|Out,
			Binary = 0x00000004,
		}
		public enum TableType {
			Tables = 0x01,
			SystemTables = 0x02,
			Views = 0x04,
			AllTables = 0xff,
		}
		~QSql() {
			DisposeQSql();
		}
		public void Dispose() {
			DisposeQSql();
		}
		private void DisposeQSql() {
			ProxyQSql().DisposeQSql();
		}
	}
}
