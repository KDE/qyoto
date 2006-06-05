//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QDate")]
	public class QDate : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QDate(Type dummy) {}
		interface IQDateProxy {
			bool op_equals(QDate lhs, DateTime other);
			bool op_lt(QDate lhs, DateTime other);
			bool op_lte(QDate lhs, DateTime other);
			bool op_gt(QDate lhs, DateTime other);
			bool op_gte(QDate lhs, DateTime other);
			string ShortMonthName(int month);
			string ShortDayName(int weekday);
			string LongMonthName(int month);
			string LongDayName(int weekday);
			DateTime CurrentDate();
			DateTime FromString(string s, Qt.DateFormat f);
			DateTime FromString(string s);
			DateTime FromString(string s, string format);
			bool IsValid(int y, int m, int d);
			bool IsLeapYear(int year);
			uint GregorianToJulian(int y, int m, int d);
			void JulianToGregorian(uint jd, out int y, out int m, out int d);
			DateTime FromJulianDay(int jd);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDate), this);
			_interceptor = (QDate) realProxy.GetTransparentProxy();
		}
		private QDate ProxyQDate() {
			return (QDate) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDate() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDateProxy), null);
			_staticInterceptor = (IQDateProxy) realProxy.GetTransparentProxy();
		}
		private static IQDateProxy StaticQDate() {
			return (IQDateProxy) _staticInterceptor;
		}

		public QDate() : this((Type) null) {
			CreateProxy();
			NewQDate();
		}
		[SmokeMethod("QDate()")]
		private void NewQDate() {
			ProxyQDate().NewQDate();
		}
		public QDate(int y, int m, int d) : this((Type) null) {
			CreateProxy();
			NewQDate(y,m,d);
		}
		[SmokeMethod("QDate(int, int, int)")]
		private void NewQDate(int y, int m, int d) {
			ProxyQDate().NewQDate(y,m,d);
		}
		[SmokeMethod("isNull() const")]
		public bool IsNull() {
			return ProxyQDate().IsNull();
		}
		[SmokeMethod("isValid() const")]
		public bool IsValid() {
			return ProxyQDate().IsValid();
		}
		[SmokeMethod("year() const")]
		public int Year() {
			return ProxyQDate().Year();
		}
		[SmokeMethod("month() const")]
		public int Month() {
			return ProxyQDate().Month();
		}
		[SmokeMethod("day() const")]
		public int Day() {
			return ProxyQDate().Day();
		}
		[SmokeMethod("dayOfWeek() const")]
		public int DayOfWeek() {
			return ProxyQDate().DayOfWeek();
		}
		[SmokeMethod("dayOfYear() const")]
		public int DayOfYear() {
			return ProxyQDate().DayOfYear();
		}
		[SmokeMethod("daysInMonth() const")]
		public int DaysInMonth() {
			return ProxyQDate().DaysInMonth();
		}
		[SmokeMethod("daysInYear() const")]
		public int DaysInYear() {
			return ProxyQDate().DaysInYear();
		}
		[SmokeMethod("weekNumber(int*) const")]
		public int WeekNumber(out int yearNum) {
			return ProxyQDate().WeekNumber(out yearNum);
		}
		[SmokeMethod("weekNumber() const")]
		public int WeekNumber() {
			return ProxyQDate().WeekNumber();
		}
		[SmokeMethod("toString(Qt::DateFormat) const")]
		public new string ToString(Qt.DateFormat f) {
			return ProxyQDate().ToString(f);
		}
		[SmokeMethod("toString() const")]
		public new string ToString() {
			return ProxyQDate().ToString();
		}
		[SmokeMethod("toString(const QString&) const")]
		public new string ToString(string format) {
			return ProxyQDate().ToString(format);
		}
		[SmokeMethod("setYMD(int, int, int)")]
		public bool SetYMD(int y, int m, int d) {
			return ProxyQDate().SetYMD(y,m,d);
		}
		[SmokeMethod("addDays(int) const")]
		public DateTime AddDays(int days) {
			return ProxyQDate().AddDays(days);
		}
		[SmokeMethod("addMonths(int) const")]
		public DateTime AddMonths(int months) {
			return ProxyQDate().AddMonths(months);
		}
		[SmokeMethod("addYears(int) const")]
		public DateTime AddYears(int years) {
			return ProxyQDate().AddYears(years);
		}
		[SmokeMethod("daysTo(const QDate&) const")]
		public int DaysTo(DateTime arg1) {
			return ProxyQDate().DaysTo(arg1);
		}
		[SmokeMethod("operator==(const QDate&) const")]
		public static bool operator==(QDate lhs, DateTime other) {
			return StaticQDate().op_equals(lhs,other);
		}
		public static bool operator!=(QDate lhs, DateTime other) {
			return !StaticQDate().op_equals(lhs,other);
		}
		public override bool Equals(object o) {
			if (!(o is QDate)) { return false; }
			return this == (QDate) o;
		}
		public override int GetHashCode() {
			return ProxyQDate().GetHashCode();
		}
		[SmokeMethod("operator<(const QDate&) const")]
		public static bool operator<(QDate lhs, DateTime other) {
			return StaticQDate().op_lt(lhs,other);
		}
		[SmokeMethod("operator<=(const QDate&) const")]
		public static bool operator<=(QDate lhs, DateTime other) {
			return StaticQDate().op_lte(lhs,other);
		}
		[SmokeMethod("operator>(const QDate&) const")]
		public static bool operator>(QDate lhs, DateTime other) {
			return StaticQDate().op_gt(lhs,other);
		}
		[SmokeMethod("operator>=(const QDate&) const")]
		public static bool operator>=(QDate lhs, DateTime other) {
			return StaticQDate().op_gte(lhs,other);
		}
		[SmokeMethod("toJulianDay() const")]
		public int ToJulianDay() {
			return ProxyQDate().ToJulianDay();
		}
		[SmokeMethod("shortMonthName(int)")]
		public static string ShortMonthName(int month) {
			return StaticQDate().ShortMonthName(month);
		}
		[SmokeMethod("shortDayName(int)")]
		public static string ShortDayName(int weekday) {
			return StaticQDate().ShortDayName(weekday);
		}
		[SmokeMethod("longMonthName(int)")]
		public static string LongMonthName(int month) {
			return StaticQDate().LongMonthName(month);
		}
		[SmokeMethod("longDayName(int)")]
		public static string LongDayName(int weekday) {
			return StaticQDate().LongDayName(weekday);
		}
		[SmokeMethod("currentDate()")]
		public static DateTime CurrentDate() {
			return StaticQDate().CurrentDate();
		}
		[SmokeMethod("fromString(const QString&, Qt::DateFormat)")]
		public static DateTime FromString(string s, Qt.DateFormat f) {
			return StaticQDate().FromString(s,f);
		}
		[SmokeMethod("fromString(const QString&)")]
		public static DateTime FromString(string s) {
			return StaticQDate().FromString(s);
		}
		[SmokeMethod("fromString(const QString&, const QString&)")]
		public static DateTime FromString(string s, string format) {
			return StaticQDate().FromString(s,format);
		}
		[SmokeMethod("isValid(int, int, int)")]
		public static bool IsValid(int y, int m, int d) {
			return StaticQDate().IsValid(y,m,d);
		}
		[SmokeMethod("isLeapYear(int)")]
		public static bool IsLeapYear(int year) {
			return StaticQDate().IsLeapYear(year);
		}
		[SmokeMethod("gregorianToJulian(int, int, int)")]
		public static uint GregorianToJulian(int y, int m, int d) {
			return StaticQDate().GregorianToJulian(y,m,d);
		}
		[SmokeMethod("julianToGregorian(uint, int&, int&, int&)")]
		public static void JulianToGregorian(uint jd, out int y, out int m, out int d) {
			StaticQDate().JulianToGregorian(jd,out y,out m,out d);
		}
		[SmokeMethod("fromJulianDay(int)")]
		public static DateTime FromJulianDay(int jd) {
			return StaticQDate().FromJulianDay(jd);
		}
		~QDate() {
			DisposeQDate();
		}
		public void Dispose() {
			DisposeQDate();
		}
		private void DisposeQDate() {
			ProxyQDate().DisposeQDate();
		}
	}
}
