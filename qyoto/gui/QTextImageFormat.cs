//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QTextImageFormat")]
	public class QTextImageFormat : QTextCharFormat, IDisposable {
 		protected QTextImageFormat(Type dummy) : base((Type) null) {}
		interface IQTextImageFormatProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextImageFormat), this);
			_interceptor = (QTextImageFormat) realProxy.GetTransparentProxy();
		}
		private QTextImageFormat ProxyQTextImageFormat() {
			return (QTextImageFormat) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextImageFormat() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextImageFormatProxy), null);
			_staticInterceptor = (IQTextImageFormatProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextImageFormatProxy StaticQTextImageFormat() {
			return (IQTextImageFormatProxy) _staticInterceptor;
		}

		public QTextImageFormat() : this((Type) null) {
			CreateProxy();
			NewQTextImageFormat();
		}
		[SmokeMethod("QTextImageFormat()")]
		private void NewQTextImageFormat() {
			ProxyQTextImageFormat().NewQTextImageFormat();
		}
		[SmokeMethod("isValid() const")]
		public new bool IsValid() {
			return ProxyQTextImageFormat().IsValid();
		}
		[SmokeMethod("setName(const QString&)")]
		public void SetName(string name) {
			ProxyQTextImageFormat().SetName(name);
		}
		[SmokeMethod("name() const")]
		public string Name() {
			return ProxyQTextImageFormat().Name();
		}
		[SmokeMethod("setWidth(qreal)")]
		public void SetWidth(double width) {
			ProxyQTextImageFormat().SetWidth(width);
		}
		[SmokeMethod("width() const")]
		public double Width() {
			return ProxyQTextImageFormat().Width();
		}
		[SmokeMethod("setHeight(qreal)")]
		public void SetHeight(double height) {
			ProxyQTextImageFormat().SetHeight(height);
		}
		[SmokeMethod("height() const")]
		public double Height() {
			return ProxyQTextImageFormat().Height();
		}
		~QTextImageFormat() {
			DisposeQTextImageFormat();
		}
		public void Dispose() {
			DisposeQTextImageFormat();
		}
		[SmokeMethod("~QTextImageFormat()")]
		private void DisposeQTextImageFormat() {
			ProxyQTextImageFormat().DisposeQTextImageFormat();
		}
	}
}