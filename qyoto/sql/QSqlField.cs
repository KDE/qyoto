//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QSqlField")]
	public class QSqlField : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QSqlField(Type dummy) {}
		interface IQSqlFieldProxy {
			bool op_equals(QSqlField lhs, QSqlField other);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSqlField), this);
			_interceptor = (QSqlField) realProxy.GetTransparentProxy();
		}
		private QSqlField ProxyQSqlField() {
			return (QSqlField) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSqlField() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSqlFieldProxy), null);
			_staticInterceptor = (IQSqlFieldProxy) realProxy.GetTransparentProxy();
		}
		private static IQSqlFieldProxy StaticQSqlField() {
			return (IQSqlFieldProxy) _staticInterceptor;
		}

		public enum RequiredStatus {
			Unknown = -1,
			Optional = 0,
			Required = 1,
		}
		public QSqlField(string fieldName, QVariant.TypeOf type) : this((Type) null) {
			CreateProxy();
			NewQSqlField(fieldName,type);
		}
		[SmokeMethod("QSqlField", "(const QString&, QVariant::Type)", "$$")]
		private void NewQSqlField(string fieldName, QVariant.TypeOf type) {
			ProxyQSqlField().NewQSqlField(fieldName,type);
		}
		public QSqlField(string fieldName) : this((Type) null) {
			CreateProxy();
			NewQSqlField(fieldName);
		}
		[SmokeMethod("QSqlField", "(const QString&)", "$")]
		private void NewQSqlField(string fieldName) {
			ProxyQSqlField().NewQSqlField(fieldName);
		}
		public QSqlField() : this((Type) null) {
			CreateProxy();
			NewQSqlField();
		}
		[SmokeMethod("QSqlField", "()", "")]
		private void NewQSqlField() {
			ProxyQSqlField().NewQSqlField();
		}
		public QSqlField(QSqlField other) : this((Type) null) {
			CreateProxy();
			NewQSqlField(other);
		}
		[SmokeMethod("QSqlField", "(const QSqlField&)", "#")]
		private void NewQSqlField(QSqlField other) {
			ProxyQSqlField().NewQSqlField(other);
		}
		[SmokeMethod("operator==", "(const QSqlField&) const", "#")]
		public static bool operator==(QSqlField lhs, QSqlField other) {
			return StaticQSqlField().op_equals(lhs,other);
		}
		public static bool operator!=(QSqlField lhs, QSqlField other) {
			return !StaticQSqlField().op_equals(lhs,other);
		}
		public override bool Equals(object o) {
			if (!(o is QSqlField)) { return false; }
			return this == (QSqlField) o;
		}
		public override int GetHashCode() {
			return ProxyQSqlField().GetHashCode();
		}
		[SmokeMethod("setValue", "(const QVariant&)", "#")]
		public void SetValue(QVariant value) {
			ProxyQSqlField().SetValue(value);
		}
		[SmokeMethod("value", "() const", "")]
		public QVariant Value() {
			return ProxyQSqlField().Value();
		}
		[SmokeMethod("setName", "(const QString&)", "$")]
		public void SetName(string name) {
			ProxyQSqlField().SetName(name);
		}
		[SmokeMethod("name", "() const", "")]
		public string Name() {
			return ProxyQSqlField().Name();
		}
		[SmokeMethod("isNull", "() const", "")]
		public bool IsNull() {
			return ProxyQSqlField().IsNull();
		}
		[SmokeMethod("setReadOnly", "(bool)", "$")]
		public void SetReadOnly(bool readOnly) {
			ProxyQSqlField().SetReadOnly(readOnly);
		}
		[SmokeMethod("isReadOnly", "() const", "")]
		public bool IsReadOnly() {
			return ProxyQSqlField().IsReadOnly();
		}
		[SmokeMethod("clear", "()", "")]
		public void Clear() {
			ProxyQSqlField().Clear();
		}
		[SmokeMethod("type", "() const", "")]
		public QVariant.TypeOf type() {
			return ProxyQSqlField().type();
		}
		[SmokeMethod("isAutoValue", "() const", "")]
		public bool IsAutoValue() {
			return ProxyQSqlField().IsAutoValue();
		}
		[SmokeMethod("setType", "(QVariant::Type)", "$")]
		public void SetType(QVariant.TypeOf type) {
			ProxyQSqlField().SetType(type);
		}
		[SmokeMethod("setRequiredStatus", "(QSqlField::RequiredStatus)", "$")]
		public void SetRequiredStatus(QSqlField.RequiredStatus status) {
			ProxyQSqlField().SetRequiredStatus(status);
		}
		[SmokeMethod("setRequired", "(bool)", "$")]
		public void SetRequired(bool required) {
			ProxyQSqlField().SetRequired(required);
		}
		[SmokeMethod("setLength", "(int)", "$")]
		public void SetLength(int fieldLength) {
			ProxyQSqlField().SetLength(fieldLength);
		}
		[SmokeMethod("setPrecision", "(int)", "$")]
		public void SetPrecision(int precision) {
			ProxyQSqlField().SetPrecision(precision);
		}
		[SmokeMethod("setDefaultValue", "(const QVariant&)", "#")]
		public void SetDefaultValue(QVariant value) {
			ProxyQSqlField().SetDefaultValue(value);
		}
		[SmokeMethod("setSqlType", "(int)", "$")]
		public void SetSqlType(int type) {
			ProxyQSqlField().SetSqlType(type);
		}
		[SmokeMethod("setGenerated", "(bool)", "$")]
		public void SetGenerated(bool gen) {
			ProxyQSqlField().SetGenerated(gen);
		}
		[SmokeMethod("setAutoValue", "(bool)", "$")]
		public void SetAutoValue(bool autoVal) {
			ProxyQSqlField().SetAutoValue(autoVal);
		}
		[SmokeMethod("requiredStatus", "() const", "")]
		public QSqlField.RequiredStatus requiredStatus() {
			return ProxyQSqlField().requiredStatus();
		}
		[SmokeMethod("length", "() const", "")]
		public int Length() {
			return ProxyQSqlField().Length();
		}
		[SmokeMethod("precision", "() const", "")]
		public int Precision() {
			return ProxyQSqlField().Precision();
		}
		[SmokeMethod("defaultValue", "() const", "")]
		public QVariant DefaultValue() {
			return ProxyQSqlField().DefaultValue();
		}
		[SmokeMethod("typeID", "() const", "")]
		public int TypeID() {
			return ProxyQSqlField().TypeID();
		}
		[SmokeMethod("isGenerated", "() const", "")]
		public bool IsGenerated() {
			return ProxyQSqlField().IsGenerated();
		}
		[SmokeMethod("isValid", "() const", "")]
		public bool IsValid() {
			return ProxyQSqlField().IsValid();
		}
		~QSqlField() {
			DisposeQSqlField();
		}
		public void Dispose() {
			DisposeQSqlField();
		}
		[SmokeMethod("~QSqlField", "()", "")]
		private void DisposeQSqlField() {
			ProxyQSqlField().DisposeQSqlField();
		}
	}
}
