//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QStyleHintReturn")]
	public class QStyleHintReturn : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QStyleHintReturn(Type dummy) {}
		interface IQStyleHintReturnProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStyleHintReturn), this);
			_interceptor = (QStyleHintReturn) realProxy.GetTransparentProxy();
		}
		private QStyleHintReturn ProxyQStyleHintReturn() {
			return (QStyleHintReturn) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStyleHintReturn() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStyleHintReturnProxy), null);
			_staticInterceptor = (IQStyleHintReturnProxy) realProxy.GetTransparentProxy();
		}
		private static IQStyleHintReturnProxy StaticQStyleHintReturn() {
			return (IQStyleHintReturnProxy) _staticInterceptor;
		}

		public enum HintReturnType {
			SH_Default = 0xf000,
			SH_Mask = 0,
		}
		public const int Type = (int) QStyleHintReturn.HintReturnType.SH_Default;

		public const int Version = 1;

		public QStyleHintReturn(int version, int type) : this((Type) null) {
			CreateProxy();
			NewQStyleHintReturn(version,type);
		}
		[SmokeMethod("QStyleHintReturn(int, int)")]
		private void NewQStyleHintReturn(int version, int type) {
			ProxyQStyleHintReturn().NewQStyleHintReturn(version,type);
		}
		public QStyleHintReturn(int version) : this((Type) null) {
			CreateProxy();
			NewQStyleHintReturn(version);
		}
		[SmokeMethod("QStyleHintReturn(int)")]
		private void NewQStyleHintReturn(int version) {
			ProxyQStyleHintReturn().NewQStyleHintReturn(version);
		}
		public QStyleHintReturn() : this((Type) null) {
			CreateProxy();
			NewQStyleHintReturn();
		}
		[SmokeMethod("QStyleHintReturn()")]
		private void NewQStyleHintReturn() {
			ProxyQStyleHintReturn().NewQStyleHintReturn();
		}
		~QStyleHintReturn() {
			DisposeQStyleHintReturn();
		}
		public void Dispose() {
			DisposeQStyleHintReturn();
		}
		private void DisposeQStyleHintReturn() {
			ProxyQStyleHintReturn().DisposeQStyleHintReturn();
		}
	}
}
