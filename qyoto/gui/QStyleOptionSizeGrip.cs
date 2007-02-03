//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QStyleOptionSizeGrip")]
	public class QStyleOptionSizeGrip : QStyleOptionComplex, IDisposable {
 		protected QStyleOptionSizeGrip(Type dummy) : base((Type) null) {}
		interface IQStyleOptionSizeGripProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStyleOptionSizeGrip), this);
			_interceptor = (QStyleOptionSizeGrip) realProxy.GetTransparentProxy();
		}
		private QStyleOptionSizeGrip ProxyQStyleOptionSizeGrip() {
			return (QStyleOptionSizeGrip) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStyleOptionSizeGrip() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStyleOptionSizeGripProxy), null);
			_staticInterceptor = (IQStyleOptionSizeGripProxy) realProxy.GetTransparentProxy();
		}
		private static IQStyleOptionSizeGripProxy StaticQStyleOptionSizeGrip() {
			return (IQStyleOptionSizeGripProxy) _staticInterceptor;
		}

		public enum StyleOptionType {
			Type = QStyleOption.OptionType.SO_SizeGrip,
		}
		public enum StyleOptionVersion {
			Version = 1,
		}
		public QStyleOptionSizeGrip() : this((Type) null) {
			CreateProxy();
			NewQStyleOptionSizeGrip();
		}
		[SmokeMethod("QStyleOptionSizeGrip", "()", "")]
		private void NewQStyleOptionSizeGrip() {
			ProxyQStyleOptionSizeGrip().NewQStyleOptionSizeGrip();
		}
		public QStyleOptionSizeGrip(QStyleOptionSizeGrip other) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionSizeGrip(other);
		}
		[SmokeMethod("QStyleOptionSizeGrip", "(const QStyleOptionSizeGrip&)", "#")]
		private void NewQStyleOptionSizeGrip(QStyleOptionSizeGrip other) {
			ProxyQStyleOptionSizeGrip().NewQStyleOptionSizeGrip(other);
		}
		public QStyleOptionSizeGrip(int version) : this((Type) null) {
			CreateProxy();
			NewQStyleOptionSizeGrip(version);
		}
		[SmokeMethod("QStyleOptionSizeGrip", "(int)", "$")]
		private void NewQStyleOptionSizeGrip(int version) {
			ProxyQStyleOptionSizeGrip().NewQStyleOptionSizeGrip(version);
		}
		~QStyleOptionSizeGrip() {
			DisposeQStyleOptionSizeGrip();
		}
		public void Dispose() {
			DisposeQStyleOptionSizeGrip();
		}
		[SmokeMethod("~QStyleOptionSizeGrip", "()", "")]
		private void DisposeQStyleOptionSizeGrip() {
			ProxyQStyleOptionSizeGrip().DisposeQStyleOptionSizeGrip();
		}
	}
}
