//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QStyleOptionToolBox")]
	public class QStyleOptionToolBox : QStyleOption, IDisposable {
 		protected QStyleOptionToolBox(Type dummy) : base((Type) null) {}
		interface IQStyleOptionToolBoxProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStyleOptionToolBox), this);
			_interceptor = (QStyleOptionToolBox) realProxy.GetTransparentProxy();
		}
		private QStyleOptionToolBox ProxyQStyleOptionToolBox() {
			return (QStyleOptionToolBox) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStyleOptionToolBox() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStyleOptionToolBoxProxy), null);
			_staticInterceptor = (IQStyleOptionToolBoxProxy) realProxy.GetTransparentProxy();
		}
		private static IQStyleOptionToolBoxProxy StaticQStyleOptionToolBox() {
			return (IQStyleOptionToolBoxProxy) _staticInterceptor;
		}

		public enum StyleOptionType {
			Type = QStyleOption.OptionType.SO_ToolBox,
		}
		public enum StyleOptionVersion {
			Version = 1,
		}
		public QStyleOptionToolBox() : this((Type) null) {
			CreateProxy();
			NewQStyleOptionToolBox();
		}
		[SmokeMethod("QStyleOptionToolBox", "()", "")]
		private void NewQStyleOptionToolBox() {
			ProxyQStyleOptionToolBox().NewQStyleOptionToolBox();
		}
		public QStyleOptionToolBox(QStyleOptionToolBox other) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionToolBox(other);
		}
		[SmokeMethod("QStyleOptionToolBox", "(const QStyleOptionToolBox&)", "#")]
		private void NewQStyleOptionToolBox(QStyleOptionToolBox other) {
			ProxyQStyleOptionToolBox().NewQStyleOptionToolBox(other);
		}
		public QStyleOptionToolBox(int version) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionToolBox(version);
		}
		[SmokeMethod("QStyleOptionToolBox", "(int)", "$")]
		private void NewQStyleOptionToolBox(int version) {
			ProxyQStyleOptionToolBox().NewQStyleOptionToolBox(version);
		}
		~QStyleOptionToolBox() {
			DisposeQStyleOptionToolBox();
		}
		public void Dispose() {
			DisposeQStyleOptionToolBox();
		}
		[SmokeMethod("~QStyleOptionToolBox", "()", "")]
		private void DisposeQStyleOptionToolBox() {
			ProxyQStyleOptionToolBox().DisposeQStyleOptionToolBox();
		}
	}
}
