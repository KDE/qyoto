//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QSqlRecord")]
	public class QSqlRecord : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QSqlRecord(Type dummy) {}
		interface IQSqlRecordProxy {
			bool op_equals(QSqlRecord lhs, QSqlRecord other);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSqlRecord), this);
			_interceptor = (QSqlRecord) realProxy.GetTransparentProxy();
		}
		private QSqlRecord ProxyQSqlRecord() {
			return (QSqlRecord) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSqlRecord() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlRecordProxy), null);
			_staticInterceptor = (IQSqlRecordProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlRecordProxy StaticQSqlRecord() {
			return (IQSqlRecordProxy) _staticInterceptor;
		}

		public QSqlRecord() : this((Type) null) {
			CreateProxy();
			NewQSqlRecord();
		}
		[SmokeMethod("QSqlRecord", "()", "")]
		private void NewQSqlRecord() {
			ProxyQSqlRecord().NewQSqlRecord();
		}
		public QSqlRecord(QSqlRecord other) : this((Type) null) {
			CreateProxy();
			NewQSqlRecord(other);
		}
		[SmokeMethod("QSqlRecord", "(const QSqlRecord&)", "#")]
		private void NewQSqlRecord(QSqlRecord other) {
			ProxyQSqlRecord().NewQSqlRecord(other);
		}
		[SmokeMethod("operator==", "(const QSqlRecord&) const", "#")]
		public static bool operator==(QSqlRecord lhs, QSqlRecord other) {
			return StaticQSqlRecord().op_equals(lhs,other);
		}
		public static bool operator!=(QSqlRecord lhs, QSqlRecord other) {
			return !StaticQSqlRecord().op_equals(lhs,other);
		}
		public override bool Equals(object o) {
			if (!(o is QSqlRecord)) { return false; }
			return this == (QSqlRecord) o;
		}
		public override int GetHashCode() {
			return ProxyQSqlRecord().GetHashCode();
		}
		[SmokeMethod("value", "(int) const", "$")]
		public QVariant Value(int i) {
			return ProxyQSqlRecord().Value(i);
		}
		[SmokeMethod("value", "(const QString&) const", "$")]
		public QVariant Value(string name) {
			return ProxyQSqlRecord().Value(name);
		}
		[SmokeMethod("setValue", "(int, const QVariant&)", "$#")]
		public void SetValue(int i, QVariant val) {
			ProxyQSqlRecord().SetValue(i,val);
		}
		[SmokeMethod("setValue", "(const QString&, const QVariant&)", "$#")]
		public void SetValue(string name, QVariant val) {
			ProxyQSqlRecord().SetValue(name,val);
		}
		[SmokeMethod("setNull", "(int)", "$")]
		public void SetNull(int i) {
			ProxyQSqlRecord().SetNull(i);
		}
		[SmokeMethod("setNull", "(const QString&)", "$")]
		public void SetNull(string name) {
			ProxyQSqlRecord().SetNull(name);
		}
		[SmokeMethod("isNull", "(int) const", "$")]
		public bool IsNull(int i) {
			return ProxyQSqlRecord().IsNull(i);
		}
		[SmokeMethod("isNull", "(const QString&) const", "$")]
		public bool IsNull(string name) {
			return ProxyQSqlRecord().IsNull(name);
		}
		[SmokeMethod("indexOf", "(const QString&) const", "$")]
		public int IndexOf(string name) {
			return ProxyQSqlRecord().IndexOf(name);
		}
		[SmokeMethod("fieldName", "(int) const", "$")]
		public string FieldName(int i) {
			return ProxyQSqlRecord().FieldName(i);
		}
		[SmokeMethod("field", "(int) const", "$")]
		public QSqlField Field(int i) {
			return ProxyQSqlRecord().Field(i);
		}
		[SmokeMethod("field", "(const QString&) const", "$")]
		public QSqlField Field(string name) {
			return ProxyQSqlRecord().Field(name);
		}
		[SmokeMethod("isGenerated", "(int) const", "$")]
		public bool IsGenerated(int i) {
			return ProxyQSqlRecord().IsGenerated(i);
		}
		[SmokeMethod("isGenerated", "(const QString&) const", "$")]
		public bool IsGenerated(string name) {
			return ProxyQSqlRecord().IsGenerated(name);
		}
		[SmokeMethod("setGenerated", "(const QString&, bool)", "$$")]
		public void SetGenerated(string name, bool generated) {
			ProxyQSqlRecord().SetGenerated(name,generated);
		}
		[SmokeMethod("setGenerated", "(int, bool)", "$$")]
		public void SetGenerated(int i, bool generated) {
			ProxyQSqlRecord().SetGenerated(i,generated);
		}
		[SmokeMethod("append", "(const QSqlField&)", "#")]
		public void Append(QSqlField field) {
			ProxyQSqlRecord().Append(field);
		}
		[SmokeMethod("replace", "(int, const QSqlField&)", "$#")]
		public void Replace(int pos, QSqlField field) {
			ProxyQSqlRecord().Replace(pos,field);
		}
		[SmokeMethod("insert", "(int, const QSqlField&)", "$#")]
		public void Insert(int pos, QSqlField field) {
			ProxyQSqlRecord().Insert(pos,field);
		}
		[SmokeMethod("remove", "(int)", "$")]
		public void Remove(int pos) {
			ProxyQSqlRecord().Remove(pos);
		}
		[SmokeMethod("isEmpty", "() const", "")]
		public bool IsEmpty() {
			return ProxyQSqlRecord().IsEmpty();
		}
		[SmokeMethod("contains", "(const QString&) const", "$")]
		public bool Contains(string name) {
			return ProxyQSqlRecord().Contains(name);
		}
		[SmokeMethod("clear", "()", "")]
		public void Clear() {
			ProxyQSqlRecord().Clear();
		}
		[SmokeMethod("clearValues", "()", "")]
		public void ClearValues() {
			ProxyQSqlRecord().ClearValues();
		}
		[SmokeMethod("count", "() const", "")]
		public int Count() {
			return ProxyQSqlRecord().Count();
		}
		~QSqlRecord() {
			DisposeQSqlRecord();
		}
		public void Dispose() {
			DisposeQSqlRecord();
		}
		[SmokeMethod("~QSqlRecord", "()", "")]
		private void DisposeQSqlRecord() {
			ProxyQSqlRecord().DisposeQSqlRecord();
		}
	}
}
