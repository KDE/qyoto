//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QTextBlockFormat")]
	public class QTextBlockFormat : QTextFormat, IDisposable {
 		protected QTextBlockFormat(Type dummy) : base((Type) null) {}
		interface IQTextBlockFormatProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextBlockFormat), this);
			_interceptor = (QTextBlockFormat) realProxy.GetTransparentProxy();
		}
		private QTextBlockFormat ProxyQTextBlockFormat() {
			return (QTextBlockFormat) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextBlockFormat() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextBlockFormatProxy), null);
			_staticInterceptor = (IQTextBlockFormatProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextBlockFormatProxy StaticQTextBlockFormat() {
			return (IQTextBlockFormatProxy) _staticInterceptor;
		}

		public QTextBlockFormat() : this((Type) null) {
			CreateProxy();
			NewQTextBlockFormat();
		}
		[SmokeMethod("QTextBlockFormat()")]
		private void NewQTextBlockFormat() {
			ProxyQTextBlockFormat().NewQTextBlockFormat();
		}
		[SmokeMethod("isValid() const")]
		public new bool IsValid() {
			return ProxyQTextBlockFormat().IsValid();
		}
		[SmokeMethod("setAlignment(Qt::Alignment)")]
		public void SetAlignment(int alignment) {
			ProxyQTextBlockFormat().SetAlignment(alignment);
		}
		[SmokeMethod("alignment() const")]
		public int Alignment() {
			return ProxyQTextBlockFormat().Alignment();
		}
		[SmokeMethod("setTopMargin(qreal)")]
		public void SetTopMargin(double margin) {
			ProxyQTextBlockFormat().SetTopMargin(margin);
		}
		[SmokeMethod("topMargin() const")]
		public double TopMargin() {
			return ProxyQTextBlockFormat().TopMargin();
		}
		[SmokeMethod("setBottomMargin(qreal)")]
		public void SetBottomMargin(double margin) {
			ProxyQTextBlockFormat().SetBottomMargin(margin);
		}
		[SmokeMethod("bottomMargin() const")]
		public double BottomMargin() {
			return ProxyQTextBlockFormat().BottomMargin();
		}
		[SmokeMethod("setLeftMargin(qreal)")]
		public void SetLeftMargin(double margin) {
			ProxyQTextBlockFormat().SetLeftMargin(margin);
		}
		[SmokeMethod("leftMargin() const")]
		public double LeftMargin() {
			return ProxyQTextBlockFormat().LeftMargin();
		}
		[SmokeMethod("setRightMargin(qreal)")]
		public void SetRightMargin(double margin) {
			ProxyQTextBlockFormat().SetRightMargin(margin);
		}
		[SmokeMethod("rightMargin() const")]
		public double RightMargin() {
			return ProxyQTextBlockFormat().RightMargin();
		}
		[SmokeMethod("setTextIndent(qreal)")]
		public void SetTextIndent(double margin) {
			ProxyQTextBlockFormat().SetTextIndent(margin);
		}
		[SmokeMethod("textIndent() const")]
		public double TextIndent() {
			return ProxyQTextBlockFormat().TextIndent();
		}
		[SmokeMethod("setIndent(int)")]
		public void SetIndent(int indent) {
			ProxyQTextBlockFormat().SetIndent(indent);
		}
		[SmokeMethod("indent() const")]
		public int Indent() {
			return ProxyQTextBlockFormat().Indent();
		}
		[SmokeMethod("setNonBreakableLines(bool)")]
		public void SetNonBreakableLines(bool b) {
			ProxyQTextBlockFormat().SetNonBreakableLines(b);
		}
		[SmokeMethod("nonBreakableLines() const")]
		public bool NonBreakableLines() {
			return ProxyQTextBlockFormat().NonBreakableLines();
		}
		~QTextBlockFormat() {
			DisposeQTextBlockFormat();
		}
		public void Dispose() {
			DisposeQTextBlockFormat();
		}
		private void DisposeQTextBlockFormat() {
			ProxyQTextBlockFormat().DisposeQTextBlockFormat();
		}
	}
}
