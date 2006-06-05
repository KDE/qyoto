//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QTextDecoder")]
	public class QTextDecoder : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QTextDecoder(Type dummy) {}
		interface IQTextDecoderProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextDecoder), this);
			_interceptor = (QTextDecoder) realProxy.GetTransparentProxy();
		}
		private QTextDecoder ProxyQTextDecoder() {
			return (QTextDecoder) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextDecoder() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextDecoderProxy), null);
			_staticInterceptor = (IQTextDecoderProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextDecoderProxy StaticQTextDecoder() {
			return (IQTextDecoderProxy) _staticInterceptor;
		}

		public QTextDecoder(QTextCodec codec) : this((Type) null) {
			CreateProxy();
			NewQTextDecoder(codec);
		}
		[SmokeMethod("QTextDecoder(const QTextCodec*)")]
		private void NewQTextDecoder(QTextCodec codec) {
			ProxyQTextDecoder().NewQTextDecoder(codec);
		}
		[SmokeMethod("toUnicode(const char*, int)")]
		public string ToUnicode(string chars, int len) {
			return ProxyQTextDecoder().ToUnicode(chars,len);
		}
		[SmokeMethod("toUnicode(const QByteArray&)")]
		public string ToUnicode(QByteArray ba) {
			return ProxyQTextDecoder().ToUnicode(ba);
		}
		~QTextDecoder() {
			DisposeQTextDecoder();
		}
		public void Dispose() {
			DisposeQTextDecoder();
		}
		private void DisposeQTextDecoder() {
			ProxyQTextDecoder().DisposeQTextDecoder();
		}
	}
}
