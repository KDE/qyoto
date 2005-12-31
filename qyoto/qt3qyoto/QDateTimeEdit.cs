//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	/// See <see cref="IQDateTimeEditSignals"></see> for signals emitted by QDateTimeEdit
	public class QDateTimeEdit : QWidget, IDisposable {
 		protected QDateTimeEdit(Type dummy) : base((Type) null) {}
		interface IQDateTimeEditProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQDateTimeEditProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDateTimeEdit), this);
			_interceptor = (QDateTimeEdit) realProxy.GetTransparentProxy();
		}
		private QDateTimeEdit ProxyQDateTimeEdit() {
			return (QDateTimeEdit) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDateTimeEdit() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDateTimeEditProxy), null);
			_staticInterceptor = (IQDateTimeEditProxy) realProxy.GetTransparentProxy();
		}
		private static IQDateTimeEditProxy StaticQDateTimeEdit() {
			return (IQDateTimeEditProxy) _staticInterceptor;
		}

		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQDateTimeEdit().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQDateTimeEdit().ClassName();
		}
		public QDateTimeEdit(QWidget parent, string name) : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit(parent,name);
		}
		[SmokeMethod("QDateTimeEdit(QWidget*, const char*)")]
		private void NewQDateTimeEdit(QWidget parent, string name) {
			ProxyQDateTimeEdit().NewQDateTimeEdit(parent,name);
		}
		public QDateTimeEdit(QWidget parent) : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit(parent);
		}
		[SmokeMethod("QDateTimeEdit(QWidget*)")]
		private void NewQDateTimeEdit(QWidget parent) {
			ProxyQDateTimeEdit().NewQDateTimeEdit(parent);
		}
		public QDateTimeEdit() : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit();
		}
		[SmokeMethod("QDateTimeEdit()")]
		private void NewQDateTimeEdit() {
			ProxyQDateTimeEdit().NewQDateTimeEdit();
		}
		public QDateTimeEdit(DateTime datetime, QWidget parent, string name) : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit(datetime,parent,name);
		}
		[SmokeMethod("QDateTimeEdit(const QDateTime&, QWidget*, const char*)")]
		private void NewQDateTimeEdit(DateTime datetime, QWidget parent, string name) {
			ProxyQDateTimeEdit().NewQDateTimeEdit(datetime,parent,name);
		}
		public QDateTimeEdit(DateTime datetime, QWidget parent) : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit(datetime,parent);
		}
		[SmokeMethod("QDateTimeEdit(const QDateTime&, QWidget*)")]
		private void NewQDateTimeEdit(DateTime datetime, QWidget parent) {
			ProxyQDateTimeEdit().NewQDateTimeEdit(datetime,parent);
		}
		public QDateTimeEdit(DateTime datetime) : this((Type) null) {
			CreateQDateTimeEditProxy();
			CreateQDateTimeEditSignalProxy();
			NewQDateTimeEdit(datetime);
		}
		[SmokeMethod("QDateTimeEdit(const QDateTime&)")]
		private void NewQDateTimeEdit(DateTime datetime) {
			ProxyQDateTimeEdit().NewQDateTimeEdit(datetime);
		}
		[SmokeMethod("sizeHint() const")]
		public new QSize SizeHint() {
			return ProxyQDateTimeEdit().SizeHint();
		}
		[SmokeMethod("minimumSizeHint() const")]
		public new QSize MinimumSizeHint() {
			return ProxyQDateTimeEdit().MinimumSizeHint();
		}
		[SmokeMethod("dateTime() const")]
		public DateTime DateTime() {
			return ProxyQDateTimeEdit().DateTime();
		}
		[SmokeMethod("dateEdit()")]
		public QDateEdit DateEdit() {
			return ProxyQDateTimeEdit().DateEdit();
		}
		[SmokeMethod("timeEdit()")]
		public QTimeEdit TimeEdit() {
			return ProxyQDateTimeEdit().TimeEdit();
		}
		[SmokeMethod("setAutoAdvance(bool)")]
		public virtual void SetAutoAdvance(bool advance) {
			ProxyQDateTimeEdit().SetAutoAdvance(advance);
		}
		[SmokeMethod("autoAdvance() const")]
		public bool AutoAdvance() {
			return ProxyQDateTimeEdit().AutoAdvance();
		}
		[Q_SLOT("void setDateTime(const QDateTime&)")]
		[SmokeMethod("setDateTime(const QDateTime&)")]
		public virtual void SetDateTime(DateTime dt) {
			ProxyQDateTimeEdit().SetDateTime(dt);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQDateTimeEdit().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQDateTimeEdit().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQDateTimeEdit().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQDateTimeEdit().TrUtf8(arg1);
		}
		[SmokeMethod("init()")]
		protected void Init() {
			ProxyQDateTimeEdit().Init();
		}
		[SmokeMethod("resizeEvent(QResizeEvent*)")]
		protected new void ResizeEvent(QResizeEvent arg1) {
			ProxyQDateTimeEdit().ResizeEvent(arg1);
		}
		[Q_SLOT("void newValue(const QDate&)")]
		[SmokeMethod("newValue(const QDate&)")]
		protected void NewValue(DateTime d) {
			ProxyQDateTimeEdit().NewValue(d);
		}
		~QDateTimeEdit() {
			DisposeQDateTimeEdit();
		}
		public new void Dispose() {
			DisposeQDateTimeEdit();
		}
		private void DisposeQDateTimeEdit() {
			ProxyQDateTimeEdit().DisposeQDateTimeEdit();
		}
		protected void CreateQDateTimeEditSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQDateTimeEditSignals), this);
			_signalInterceptor = (IQDateTimeEditSignals) realProxy.GetTransparentProxy();
		}
		protected new IQDateTimeEditSignals Emit() {
			return (IQDateTimeEditSignals) _signalInterceptor;
		}
	}

	public interface IQDateTimeEditSignals : IQWidgetSignals {
		[Q_SIGNAL("void valueChanged(const QDateTime&)")]
		void ValueChanged(DateTime datetime);
	}
}
