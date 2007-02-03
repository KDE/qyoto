//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQToolBoxSignals"></see> for signals emitted by QToolBox
	[SmokeClass("QToolBox")]
	public class QToolBox : QFrame, IDisposable {
 		protected QToolBox(Type dummy) : base((Type) null) {}
		interface IQToolBoxProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QToolBox), this);
			_interceptor = (QToolBox) realProxy.GetTransparentProxy();
		}
		private QToolBox ProxyQToolBox() {
			return (QToolBox) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QToolBox() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQToolBoxProxy), null);
			_staticInterceptor = (IQToolBoxProxy) realProxy.GetTransparentProxy();
		}
		private static IQToolBoxProxy StaticQToolBox() {
			return (IQToolBoxProxy) _staticInterceptor;
		}

		[Q_PROPERTY("int", "currentIndex")]
		public int CurrentIndex {
			get {
				return Property("currentIndex").Value<int>();
			}
			set {
				SetProperty("currentIndex", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "count")]
		public int Count {
			get {
				return Property("count").Value<int>();
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QToolBox(QWidget parent, int f) : this((Type) null) {
			CreateProxy();
			NewQToolBox(parent,f);
		}
		[SmokeMethod("QToolBox", "(QWidget*, Qt::WindowFlags)", "#$")]
		private void NewQToolBox(QWidget parent, int f) {
			ProxyQToolBox().NewQToolBox(parent,f);
		}
		public QToolBox(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQToolBox(parent);
		}
		[SmokeMethod("QToolBox", "(QWidget*)", "#")]
		private void NewQToolBox(QWidget parent) {
			ProxyQToolBox().NewQToolBox(parent);
		}
		public QToolBox() : this((Type) null) {
			CreateProxy();
			NewQToolBox();
		}
		[SmokeMethod("QToolBox", "()", "")]
		private void NewQToolBox() {
			ProxyQToolBox().NewQToolBox();
		}
		[SmokeMethod("addItem", "(QWidget*, const QString&)", "#$")]
		public int AddItem(QWidget widget, string text) {
			return ProxyQToolBox().AddItem(widget,text);
		}
		[SmokeMethod("addItem", "(QWidget*, const QIcon&, const QString&)", "##$")]
		public int AddItem(QWidget widget, QIcon icon, string text) {
			return ProxyQToolBox().AddItem(widget,icon,text);
		}
		[SmokeMethod("insertItem", "(int, QWidget*, const QString&)", "$#$")]
		public int InsertItem(int index, QWidget widget, string text) {
			return ProxyQToolBox().InsertItem(index,widget,text);
		}
		[SmokeMethod("insertItem", "(int, QWidget*, const QIcon&, const QString&)", "$##$")]
		public int InsertItem(int index, QWidget widget, QIcon icon, string text) {
			return ProxyQToolBox().InsertItem(index,widget,icon,text);
		}
		[SmokeMethod("removeItem", "(int)", "$")]
		public void RemoveItem(int index) {
			ProxyQToolBox().RemoveItem(index);
		}
		[SmokeMethod("setItemEnabled", "(int, bool)", "$$")]
		public void SetItemEnabled(int index, bool enabled) {
			ProxyQToolBox().SetItemEnabled(index,enabled);
		}
		[SmokeMethod("isItemEnabled", "(int) const", "$")]
		public bool IsItemEnabled(int index) {
			return ProxyQToolBox().IsItemEnabled(index);
		}
		[SmokeMethod("setItemText", "(int, const QString&)", "$$")]
		public void SetItemText(int index, string text) {
			ProxyQToolBox().SetItemText(index,text);
		}
		[SmokeMethod("itemText", "(int) const", "$")]
		public string ItemText(int index) {
			return ProxyQToolBox().ItemText(index);
		}
		[SmokeMethod("setItemIcon", "(int, const QIcon&)", "$#")]
		public void SetItemIcon(int index, QIcon icon) {
			ProxyQToolBox().SetItemIcon(index,icon);
		}
		[SmokeMethod("itemIcon", "(int) const", "$")]
		public QIcon ItemIcon(int index) {
			return ProxyQToolBox().ItemIcon(index);
		}
		[SmokeMethod("setItemToolTip", "(int, const QString&)", "$$")]
		public void SetItemToolTip(int index, string toolTip) {
			ProxyQToolBox().SetItemToolTip(index,toolTip);
		}
		[SmokeMethod("itemToolTip", "(int) const", "$")]
		public string ItemToolTip(int index) {
			return ProxyQToolBox().ItemToolTip(index);
		}
		[SmokeMethod("currentWidget", "() const", "")]
		public QWidget CurrentWidget() {
			return ProxyQToolBox().CurrentWidget();
		}
		[SmokeMethod("widget", "(int) const", "$")]
		public QWidget Widget(int index) {
			return ProxyQToolBox().Widget(index);
		}
		[SmokeMethod("indexOf", "(QWidget*) const", "#")]
		public int IndexOf(QWidget widget) {
			return ProxyQToolBox().IndexOf(widget);
		}
		[Q_SLOT("void setCurrentWidget(QWidget*)")]
		[SmokeMethod("setCurrentWidget", "(QWidget*)", "#")]
		public void SetCurrentWidget(QWidget widget) {
			ProxyQToolBox().SetCurrentWidget(widget);
		}
		public static new string Tr(string s, string c) {
			return StaticQToolBox().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQToolBox().Tr(s);
		}
		[SmokeMethod("event", "(QEvent*)", "#")]
		public new bool Event(QEvent e) {
			return ProxyQToolBox().Event(e);
		}
		[SmokeMethod("itemInserted", "(int)", "$")]
		protected virtual void ItemInserted(int index) {
			ProxyQToolBox().ItemInserted(index);
		}
		[SmokeMethod("itemRemoved", "(int)", "$")]
		protected virtual void ItemRemoved(int index) {
			ProxyQToolBox().ItemRemoved(index);
		}
		[SmokeMethod("showEvent", "(QShowEvent*)", "#")]
		public new void ShowEvent(QShowEvent e) {
			ProxyQToolBox().ShowEvent(e);
		}
		[SmokeMethod("changeEvent", "(QEvent*)", "#")]
		protected new void ChangeEvent(QEvent arg1) {
			ProxyQToolBox().ChangeEvent(arg1);
		}
		~QToolBox() {
			DisposeQToolBox();
		}
		public new void Dispose() {
			DisposeQToolBox();
		}
		[SmokeMethod("~QToolBox", "()", "")]
		private void DisposeQToolBox() {
			ProxyQToolBox().DisposeQToolBox();
		}
		protected new IQToolBoxSignals Emit {
			get {
				return (IQToolBoxSignals) Q_EMIT;
			}
		}
	}

	public interface IQToolBoxSignals : IQFrameSignals {
		[Q_SIGNAL("void currentChanged(int)")]
		void CurrentChanged(int index);
	}
}
