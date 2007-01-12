//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QTextListFormat")]
	public class QTextListFormat : QTextFormat, IDisposable {
 		protected QTextListFormat(Type dummy) : base((Type) null) {}
		interface IQTextListFormatProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextListFormat), this);
			_interceptor = (QTextListFormat) realProxy.GetTransparentProxy();
		}
		private QTextListFormat ProxyQTextListFormat() {
			return (QTextListFormat) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextListFormat() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextListFormatProxy), null);
			_staticInterceptor = (IQTextListFormatProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextListFormatProxy StaticQTextListFormat() {
			return (IQTextListFormatProxy) _staticInterceptor;
		}

		public enum Style {
			ListDisc = -1,
			ListCircle = -2,
			ListSquare = -3,
			ListDecimal = -4,
			ListLowerAlpha = -5,
			ListUpperAlpha = -6,
			ListStyleUndefined = 0,
		}
		public QTextListFormat() : this((Type) null) {
			CreateProxy();
			NewQTextListFormat();
		}
		[SmokeMethod("QTextListFormat()")]
		private void NewQTextListFormat() {
			ProxyQTextListFormat().NewQTextListFormat();
		}
		[SmokeMethod("isValid() const")]
		public new bool IsValid() {
			return ProxyQTextListFormat().IsValid();
		}
		[SmokeMethod("setStyle(QTextListFormat::Style)")]
		public void SetStyle(QTextListFormat.Style style) {
			ProxyQTextListFormat().SetStyle(style);
		}
		[SmokeMethod("style() const")]
		public QTextListFormat.Style style() {
			return ProxyQTextListFormat().style();
		}
		[SmokeMethod("setIndent(int)")]
		public void SetIndent(int indent) {
			ProxyQTextListFormat().SetIndent(indent);
		}
		[SmokeMethod("indent() const")]
		public int Indent() {
			return ProxyQTextListFormat().Indent();
		}
		~QTextListFormat() {
			DisposeQTextListFormat();
		}
		public void Dispose() {
			DisposeQTextListFormat();
		}
		[SmokeMethod("~QTextListFormat()")]
		private void DisposeQTextListFormat() {
			ProxyQTextListFormat().DisposeQTextListFormat();
		}
	}
}