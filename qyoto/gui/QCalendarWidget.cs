//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	/// See <see cref="IQCalendarWidgetSignals"></see> for signals emitted by QCalendarWidget
	[SmokeClass("QCalendarWidget")]
	public class QCalendarWidget : QWidget, IDisposable {
 		protected QCalendarWidget(Type dummy) : base((Type) null) {}
		interface IQCalendarWidgetProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QCalendarWidget), this);
			_interceptor = (QCalendarWidget) realProxy.GetTransparentProxy();
		}
		private QCalendarWidget ProxyQCalendarWidget() {
			return (QCalendarWidget) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QCalendarWidget() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQCalendarWidgetProxy), null);
			_staticInterceptor = (IQCalendarWidgetProxy) realProxy.GetTransparentProxy();
		}
		private static IQCalendarWidgetProxy StaticQCalendarWidget() {
			return (IQCalendarWidgetProxy) _staticInterceptor;
		}

		public enum HorizontalHeaderFormat {
			NoHorizontalHeader = 0,
			SingleLetterDayNames = 1,
			ShortDayNames = 2,
			LongDayNames = 3,
		}
		public enum VerticalHeaderFormat {
			NoVerticalHeader = 0,
			ISOWeekNumbers = 1,
		}
		public enum SelectionMode {
			NoSelection = 0,
			SingleSelection = 1,
		}
		[Q_PROPERTY("QDate", "selectedDate")]
		public QDate SelectedDate {
			get {
				return Property("selectedDate").Value<QDate>();
			}
			set {
				SetProperty("selectedDate", QVariant.FromValue<QDate>(value));
			}
		}
		[Q_PROPERTY("QDate", "minimumDate")]
		public QDate MinimumDate {
			get {
				return Property("minimumDate").Value<QDate>();
			}
			set {
				SetProperty("minimumDate", QVariant.FromValue<QDate>(value));
			}
		}
		[Q_PROPERTY("QDate", "maximumDate")]
		public QDate MaximumDate {
			get {
				return Property("maximumDate").Value<QDate>();
			}
			set {
				SetProperty("maximumDate", QVariant.FromValue<QDate>(value));
			}
		}
		[Q_PROPERTY("Qt::DayOfWeek", "firstDayOfWeek")]
		public Qt.DayOfWeek FirstDayOfWeek {
			get {
				return Property("firstDayOfWeek").Value<Qt.DayOfWeek>();
			}
			set {
				SetProperty("firstDayOfWeek", QVariant.FromValue<Qt.DayOfWeek>(value));
			}
		}
		[Q_PROPERTY("bool", "gridVisible")]
		public bool GridVisible {
			get {
				return Property("gridVisible").Value<bool>();
			}
			set {
				SetProperty("gridVisible", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QCalendarWidget::SelectionMode", "selectionMode")]
		public QCalendarWidget.SelectionMode selectionMode {
			get {
				return Property("selectionMode").Value<QCalendarWidget.SelectionMode>();
			}
			set {
				SetProperty("selectionMode", QVariant.FromValue<QCalendarWidget.SelectionMode>(value));
			}
		}
		[Q_PROPERTY("QCalendarWidget::HorizontalHeaderFormat", "horizontalHeaderFormat")]
		public QCalendarWidget.HorizontalHeaderFormat horizontalHeaderFormat {
			get {
				return Property("horizontalHeaderFormat").Value<QCalendarWidget.HorizontalHeaderFormat>();
			}
			set {
				SetProperty("horizontalHeaderFormat", QVariant.FromValue<QCalendarWidget.HorizontalHeaderFormat>(value));
			}
		}
		[Q_PROPERTY("QCalendarWidget::VerticalHeaderFormat", "verticalHeaderFormat")]
		public QCalendarWidget.VerticalHeaderFormat verticalHeaderFormat {
			get {
				return Property("verticalHeaderFormat").Value<QCalendarWidget.VerticalHeaderFormat>();
			}
			set {
				SetProperty("verticalHeaderFormat", QVariant.FromValue<QCalendarWidget.VerticalHeaderFormat>(value));
			}
		}
		[Q_PROPERTY("bool", "headerVisible")]
		public bool HeaderVisible {
			get {
				return Property("headerVisible").Value<bool>();
			}
			set {
				SetProperty("headerVisible", QVariant.FromValue<bool>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QCalendarWidget(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQCalendarWidget(parent);
		}
		[SmokeMethod("QCalendarWidget", "(QWidget*)", "#")]
		private void NewQCalendarWidget(QWidget parent) {
			ProxyQCalendarWidget().NewQCalendarWidget(parent);
		}
		public QCalendarWidget() : this((Type) null) {
			CreateProxy();
			NewQCalendarWidget();
		}
		[SmokeMethod("QCalendarWidget", "()", "")]
		private void NewQCalendarWidget() {
			ProxyQCalendarWidget().NewQCalendarWidget();
		}
		[SmokeMethod("sizeHint", "() const", "")]
		public new virtual QSize SizeHint() {
			return ProxyQCalendarWidget().SizeHint();
		}
		[SmokeMethod("minimumSizeHint", "() const", "")]
		public new virtual QSize MinimumSizeHint() {
			return ProxyQCalendarWidget().MinimumSizeHint();
		}
		[SmokeMethod("yearShown", "() const", "")]
		public int YearShown() {
			return ProxyQCalendarWidget().YearShown();
		}
		[SmokeMethod("monthShown", "() const", "")]
		public int MonthShown() {
			return ProxyQCalendarWidget().MonthShown();
		}
		[SmokeMethod("isHeaderVisible", "() const", "")]
		public bool IsHeaderVisible() {
			return ProxyQCalendarWidget().IsHeaderVisible();
		}
		[SmokeMethod("isGridVisible", "() const", "")]
		public bool IsGridVisible() {
			return ProxyQCalendarWidget().IsGridVisible();
		}
		[SmokeMethod("headerTextFormat", "() const", "")]
		public QTextCharFormat HeaderTextFormat() {
			return ProxyQCalendarWidget().HeaderTextFormat();
		}
		[SmokeMethod("setHeaderTextFormat", "(const QTextCharFormat&)", "#")]
		public void SetHeaderTextFormat(QTextCharFormat format) {
			ProxyQCalendarWidget().SetHeaderTextFormat(format);
		}
		[SmokeMethod("weekdayTextFormat", "(Qt::DayOfWeek) const", "$")]
		public QTextCharFormat WeekdayTextFormat(Qt.DayOfWeek dayOfWeek) {
			return ProxyQCalendarWidget().WeekdayTextFormat(dayOfWeek);
		}
		[SmokeMethod("setWeekdayTextFormat", "(Qt::DayOfWeek, const QTextCharFormat&)", "$#")]
		public void SetWeekdayTextFormat(Qt.DayOfWeek dayOfWeek, QTextCharFormat format) {
			ProxyQCalendarWidget().SetWeekdayTextFormat(dayOfWeek,format);
		}
		[SmokeMethod("dateTextFormat", "() const", "")]
		public Dictionary<QDate, QTextCharFormat> DateTextFormat() {
			return ProxyQCalendarWidget().DateTextFormat();
		}
		[SmokeMethod("dateTextFormat", "(const QDate&) const", "#")]
		public QTextCharFormat DateTextFormat(QDate date) {
			return ProxyQCalendarWidget().DateTextFormat(date);
		}
		[SmokeMethod("setDateTextFormat", "(const QDate&, const QTextCharFormat&)", "##")]
		public void SetDateTextFormat(QDate date, QTextCharFormat color) {
			ProxyQCalendarWidget().SetDateTextFormat(date,color);
		}
		[Q_SLOT("void setDateRange(const QDate&, const QDate&)")]
		[SmokeMethod("setDateRange", "(const QDate&, const QDate&)", "##")]
		public void SetDateRange(QDate min, QDate max) {
			ProxyQCalendarWidget().SetDateRange(min,max);
		}
		[Q_SLOT("void setCurrentPage(int, int)")]
		[SmokeMethod("setCurrentPage", "(int, int)", "$$")]
		public void SetCurrentPage(int year, int month) {
			ProxyQCalendarWidget().SetCurrentPage(year,month);
		}
		[Q_SLOT("void showNextMonth()")]
		[SmokeMethod("showNextMonth", "()", "")]
		public void ShowNextMonth() {
			ProxyQCalendarWidget().ShowNextMonth();
		}
		[Q_SLOT("void showPreviousMonth()")]
		[SmokeMethod("showPreviousMonth", "()", "")]
		public void ShowPreviousMonth() {
			ProxyQCalendarWidget().ShowPreviousMonth();
		}
		[Q_SLOT("void showNextYear()")]
		[SmokeMethod("showNextYear", "()", "")]
		public void ShowNextYear() {
			ProxyQCalendarWidget().ShowNextYear();
		}
		[Q_SLOT("void showPreviousYear()")]
		[SmokeMethod("showPreviousYear", "()", "")]
		public void ShowPreviousYear() {
			ProxyQCalendarWidget().ShowPreviousYear();
		}
		[Q_SLOT("void showSelectedDate()")]
		[SmokeMethod("showSelectedDate", "()", "")]
		public void ShowSelectedDate() {
			ProxyQCalendarWidget().ShowSelectedDate();
		}
		[Q_SLOT("void showToday()")]
		[SmokeMethod("showToday", "()", "")]
		public void ShowToday() {
			ProxyQCalendarWidget().ShowToday();
		}
		public static new string Tr(string s, string c) {
			return StaticQCalendarWidget().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQCalendarWidget().Tr(s);
		}
		[SmokeMethod("event", "(QEvent*)", "#")]
		public new bool Event(QEvent arg1) {
			return ProxyQCalendarWidget().Event(arg1);
		}
		[SmokeMethod("mousePressEvent", "(QMouseEvent*)", "#")]
		protected new void MousePressEvent(QMouseEvent arg1) {
			ProxyQCalendarWidget().MousePressEvent(arg1);
		}
		[SmokeMethod("resizeEvent", "(QResizeEvent*)", "#")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQCalendarWidget().ResizeEvent(arg1);
		}
		[SmokeMethod("keyPressEvent", "(QKeyEvent*)", "#")]
		protected new void KeyPressEvent(QKeyEvent arg1) {
			ProxyQCalendarWidget().KeyPressEvent(arg1);
		}
		[SmokeMethod("paintCell", "(QPainter*, const QRect&, const QDate&) const", "###")]
		public virtual void PaintCell(QPainter painter, QRect rect, QDate date) {
			ProxyQCalendarWidget().PaintCell(painter,rect,date);
		}
		~QCalendarWidget() {
			DisposeQCalendarWidget();
		}
		public new void Dispose() {
			DisposeQCalendarWidget();
		}
		[SmokeMethod("~QCalendarWidget", "()", "")]
		private void DisposeQCalendarWidget() {
			ProxyQCalendarWidget().DisposeQCalendarWidget();
		}
		protected new IQCalendarWidgetSignals Emit {
			get {
				return (IQCalendarWidgetSignals) Q_EMIT;
			}
		}
	}

	public interface IQCalendarWidgetSignals : IQWidgetSignals {
		[Q_SIGNAL("void selectionChanged()")]
		void SelectionChanged();
		[Q_SIGNAL("void clicked(const QDate&)")]
		void Clicked(QDate date);
		[Q_SIGNAL("void activated(const QDate&)")]
		void Activated(QDate date);
		[Q_SIGNAL("void currentPageChanged(int, int)")]
		void CurrentPageChanged(int year, int month);
	}
}
