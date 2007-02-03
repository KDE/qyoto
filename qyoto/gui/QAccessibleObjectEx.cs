//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	[SmokeClass("QAccessibleObjectEx")]
	public class QAccessibleObjectEx : QAccessibleInterfaceEx {
 		protected QAccessibleObjectEx(Type dummy) : base((Type) null) {}
		interface IQAccessibleObjectExProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAccessibleObjectEx), this);
			_interceptor = (QAccessibleObjectEx) realProxy.GetTransparentProxy();
		}
		private QAccessibleObjectEx ProxyQAccessibleObjectEx() {
			return (QAccessibleObjectEx) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAccessibleObjectEx() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAccessibleObjectExProxy), null);
			_staticInterceptor = (IQAccessibleObjectExProxy) realProxy.GetTransparentProxy();
		}
		private static IQAccessibleObjectExProxy StaticQAccessibleObjectEx() {
			return (IQAccessibleObjectExProxy) _staticInterceptor;
		}

		public QAccessibleObjectEx(QObject arg1) : this((Type) null) {
			CreateProxy();
			NewQAccessibleObjectEx(arg1);
		}
		[SmokeMethod("QAccessibleObjectEx", "(QObject*)", "#")]
		private void NewQAccessibleObjectEx(QObject arg1) {
			ProxyQAccessibleObjectEx().NewQAccessibleObjectEx(arg1);
		}
		[SmokeMethod("isValid", "() const", "")]
		public new bool IsValid() {
			return ProxyQAccessibleObjectEx().IsValid();
		}
		[SmokeMethod("object", "() const", "")]
		public new QObject Object() {
			return ProxyQAccessibleObjectEx().Object();
		}
		[SmokeMethod("rect", "(int) const", "$")]
		public new QRect Rect(int child) {
			return ProxyQAccessibleObjectEx().Rect(child);
		}
		[SmokeMethod("setText", "(QAccessible::Text, int, const QString&)", "$$$")]
		public new void SetText(QAccessible.Text t, int child, string text) {
			ProxyQAccessibleObjectEx().SetText(t,child,text);
		}
		[SmokeMethod("userActionCount", "(int) const", "$")]
		public new int UserActionCount(int child) {
			return ProxyQAccessibleObjectEx().UserActionCount(child);
		}
		[SmokeMethod("doAction", "(int, int, const QVariantList&)", "$$?")]
		public new bool DoAction(int action, int child, List<QVariant> arg3) {
			return ProxyQAccessibleObjectEx().DoAction(action,child,arg3);
		}
		[SmokeMethod("actionText", "(int, QAccessible::Text, int) const", "$$$")]
		public new string ActionText(int action, QAccessible.Text t, int child) {
			return ProxyQAccessibleObjectEx().ActionText(action,t,child);
		}
	}
}
