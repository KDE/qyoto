//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QSystemLocale")]
	public class QSystemLocale : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QSystemLocale(Type dummy) {}
		interface IQSystemLocaleProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSystemLocale), this);
			_interceptor = (QSystemLocale) realProxy.GetTransparentProxy();
		}
		private QSystemLocale ProxyQSystemLocale() {
			return (QSystemLocale) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSystemLocale() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSystemLocaleProxy), null);
			_staticInterceptor = (IQSystemLocaleProxy) realProxy.GetTransparentProxy();
		}
		private static IQSystemLocaleProxy StaticQSystemLocale() {
			return (IQSystemLocaleProxy) _staticInterceptor;
		}

		public enum QueryType {
			LanguageId = 0,
			CountryId = 1,
			DecimalPoint = 2,
			GroupSeparator = 3,
			ZeroDigit = 4,
			NegativeSign = 5,
			DateFormatLong = 6,
			DateFormatShort = 7,
			TimeFormatLong = 8,
			TimeFormatShort = 9,
			DayNameLong = 10,
			DayNameShort = 11,
			MonthNameLong = 12,
			MonthNameShort = 13,
			DateToStringLong = 14,
			DateToStringShort = 15,
			TimeToStringLong = 16,
			TimeToStringShort = 17,
		}
		public QSystemLocale() : this((Type) null) {
			CreateProxy();
			NewQSystemLocale();
		}
		[SmokeMethod("QSystemLocale", "()", "")]
		private void NewQSystemLocale() {
			ProxyQSystemLocale().NewQSystemLocale();
		}
		[SmokeMethod("query", "(QSystemLocale::QueryType, QVariant) const", "$#")]
		public virtual QVariant Query(QSystemLocale.QueryType type, QVariant arg2) {
			return ProxyQSystemLocale().Query(type,arg2);
		}
		[SmokeMethod("fallbackLocale", "() const", "")]
		public virtual QLocale FallbackLocale() {
			return ProxyQSystemLocale().FallbackLocale();
		}
		~QSystemLocale() {
			DisposeQSystemLocale();
		}
		public void Dispose() {
			DisposeQSystemLocale();
		}
		[SmokeMethod("~QSystemLocale", "()", "")]
		private void DisposeQSystemLocale() {
			ProxyQSystemLocale().DisposeQSystemLocale();
		}
	}
}
