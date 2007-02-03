//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	/// See <see cref="IQButtonGroupSignals"></see> for signals emitted by QButtonGroup
	[SmokeClass("QButtonGroup")]
	public class QButtonGroup : QObject, IDisposable {
 		protected QButtonGroup(Type dummy) : base((Type) null) {}
		interface IQButtonGroupProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QButtonGroup), this);
			_interceptor = (QButtonGroup) realProxy.GetTransparentProxy();
		}
		private QButtonGroup ProxyQButtonGroup() {
			return (QButtonGroup) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QButtonGroup() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQButtonGroupProxy), null);
			_staticInterceptor = (IQButtonGroupProxy) realProxy.GetTransparentProxy();
		}
		private static IQButtonGroupProxy StaticQButtonGroup() {
			return (IQButtonGroupProxy) _staticInterceptor;
		}

		[Q_PROPERTY("bool", "exclusive")]
		public bool Exclusive {
			get {
				return Property("exclusive").Value<bool>();
			}
			set {
				SetProperty("exclusive", QVariant.FromValue<bool>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QButtonGroup(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQButtonGroup(parent);
		}
		[SmokeMethod("QButtonGroup", "(QObject*)", "#")]
		private void NewQButtonGroup(QObject parent) {
			ProxyQButtonGroup().NewQButtonGroup(parent);
		}
		public QButtonGroup() : this((Type) null) {
			CreateProxy();
			NewQButtonGroup();
		}
		[SmokeMethod("QButtonGroup", "()", "")]
		private void NewQButtonGroup() {
			ProxyQButtonGroup().NewQButtonGroup();
		}
		[SmokeMethod("addButton", "(QAbstractButton*)", "#")]
		public void AddButton(QAbstractButton arg1) {
			ProxyQButtonGroup().AddButton(arg1);
		}
		[SmokeMethod("addButton", "(QAbstractButton*, int)", "#$")]
		public void AddButton(QAbstractButton arg1, int id) {
			ProxyQButtonGroup().AddButton(arg1,id);
		}
		[SmokeMethod("removeButton", "(QAbstractButton*)", "#")]
		public void RemoveButton(QAbstractButton arg1) {
			ProxyQButtonGroup().RemoveButton(arg1);
		}
		[SmokeMethod("buttons", "() const", "")]
		public List<QAbstractButton> Buttons() {
			return ProxyQButtonGroup().Buttons();
		}
		[SmokeMethod("checkedButton", "() const", "")]
		public QAbstractButton CheckedButton() {
			return ProxyQButtonGroup().CheckedButton();
		}
		[SmokeMethod("button", "(int) const", "$")]
		public QAbstractButton Button(int id) {
			return ProxyQButtonGroup().Button(id);
		}
		[SmokeMethod("setId", "(QAbstractButton*, int)", "#$")]
		public void SetId(QAbstractButton button, int id) {
			ProxyQButtonGroup().SetId(button,id);
		}
		[SmokeMethod("id", "(QAbstractButton*) const", "#")]
		public int Id(QAbstractButton button) {
			return ProxyQButtonGroup().Id(button);
		}
		[SmokeMethod("checkedId", "() const", "")]
		public int CheckedId() {
			return ProxyQButtonGroup().CheckedId();
		}
		public static new string Tr(string s, string c) {
			return StaticQButtonGroup().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQButtonGroup().Tr(s);
		}
		~QButtonGroup() {
			DisposeQButtonGroup();
		}
		public new void Dispose() {
			DisposeQButtonGroup();
		}
		[SmokeMethod("~QButtonGroup", "()", "")]
		private void DisposeQButtonGroup() {
			ProxyQButtonGroup().DisposeQButtonGroup();
		}
		protected new IQButtonGroupSignals Emit {
			get {
				return (IQButtonGroupSignals) Q_EMIT;
			}
		}
	}

	public interface IQButtonGroupSignals : IQObjectSignals {
		[Q_SIGNAL("void buttonClicked(QAbstractButton*)")]
		void ButtonClicked(QAbstractButton arg1);
		[Q_SIGNAL("void buttonClicked(int)")]
		void ButtonClicked(int arg1);
		[Q_SIGNAL("void buttonPressed(QAbstractButton*)")]
		void ButtonPressed(QAbstractButton arg1);
		[Q_SIGNAL("void buttonPressed(int)")]
		void ButtonPressed(int arg1);
		[Q_SIGNAL("void buttonReleased(QAbstractButton*)")]
		void ButtonReleased(QAbstractButton arg1);
		[Q_SIGNAL("void buttonReleased(int)")]
		void ButtonReleased(int arg1);
	}
}
