//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QXmlSimpleReader")]
	public class QXmlSimpleReader : QXmlReader, IDisposable {
 		protected QXmlSimpleReader(Type dummy) : base((Type) null) {}
		interface IQXmlSimpleReaderProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QXmlSimpleReader), this);
			_interceptor = (QXmlSimpleReader) realProxy.GetTransparentProxy();
		}
		private QXmlSimpleReader ProxyQXmlSimpleReader() {
			return (QXmlSimpleReader) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QXmlSimpleReader() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQXmlSimpleReaderProxy), null);
			_staticInterceptor = (IQXmlSimpleReaderProxy) realProxy.GetTransparentProxy();
		}
		private static IQXmlSimpleReaderProxy StaticQXmlSimpleReader() {
			return (IQXmlSimpleReaderProxy) _staticInterceptor;
		}

		public QXmlSimpleReader() : this((Type) null) {
			CreateProxy();
			NewQXmlSimpleReader();
		}
		[SmokeMethod("QXmlSimpleReader()")]
		private void NewQXmlSimpleReader() {
			ProxyQXmlSimpleReader().NewQXmlSimpleReader();
		}
		[SmokeMethod("feature(const QString&, bool*) const")]
		public new bool Feature(string name, out bool ok) {
			return ProxyQXmlSimpleReader().Feature(name,out ok);
		}
		[SmokeMethod("feature(const QString&) const")]
		public new bool Feature(string name) {
			return ProxyQXmlSimpleReader().Feature(name);
		}
		[SmokeMethod("setFeature(const QString&, bool)")]
		public new void SetFeature(string name, bool value) {
			ProxyQXmlSimpleReader().SetFeature(name,value);
		}
		[SmokeMethod("hasFeature(const QString&) const")]
		public new bool HasFeature(string name) {
			return ProxyQXmlSimpleReader().HasFeature(name);
		}
		// void* property(const QString& arg1,bool* arg2); >>>> NOT CONVERTED
		// void* property(const QString& arg1); >>>> NOT CONVERTED
		// void setProperty(const QString& arg1,void* arg2); >>>> NOT CONVERTED
		[SmokeMethod("hasProperty(const QString&) const")]
		public new bool HasProperty(string name) {
			return ProxyQXmlSimpleReader().HasProperty(name);
		}
		[SmokeMethod("setEntityResolver(QXmlEntityResolver*)")]
		public new void SetEntityResolver(IQXmlEntityResolver handler) {
			ProxyQXmlSimpleReader().SetEntityResolver(handler);
		}
		[SmokeMethod("entityResolver() const")]
		public new IQXmlEntityResolver EntityResolver() {
			return ProxyQXmlSimpleReader().EntityResolver();
		}
		[SmokeMethod("setDTDHandler(QXmlDTDHandler*)")]
		public new void SetDTDHandler(IQXmlDTDHandler handler) {
			ProxyQXmlSimpleReader().SetDTDHandler(handler);
		}
		[SmokeMethod("DTDHandler() const")]
		public new IQXmlDTDHandler DTDHandler() {
			return ProxyQXmlSimpleReader().DTDHandler();
		}
		[SmokeMethod("setContentHandler(QXmlContentHandler*)")]
		public new void SetContentHandler(IQXmlContentHandler handler) {
			ProxyQXmlSimpleReader().SetContentHandler(handler);
		}
		[SmokeMethod("contentHandler() const")]
		public new IQXmlContentHandler ContentHandler() {
			return ProxyQXmlSimpleReader().ContentHandler();
		}
		[SmokeMethod("setErrorHandler(QXmlErrorHandler*)")]
		public new void SetErrorHandler(IQXmlErrorHandler handler) {
			ProxyQXmlSimpleReader().SetErrorHandler(handler);
		}
		[SmokeMethod("errorHandler() const")]
		public new IQXmlErrorHandler ErrorHandler() {
			return ProxyQXmlSimpleReader().ErrorHandler();
		}
		[SmokeMethod("setLexicalHandler(QXmlLexicalHandler*)")]
		public new void SetLexicalHandler(IQXmlLexicalHandler handler) {
			ProxyQXmlSimpleReader().SetLexicalHandler(handler);
		}
		[SmokeMethod("lexicalHandler() const")]
		public new IQXmlLexicalHandler LexicalHandler() {
			return ProxyQXmlSimpleReader().LexicalHandler();
		}
		[SmokeMethod("setDeclHandler(QXmlDeclHandler*)")]
		public new void SetDeclHandler(IQXmlDeclHandler handler) {
			ProxyQXmlSimpleReader().SetDeclHandler(handler);
		}
		[SmokeMethod("declHandler() const")]
		public new IQXmlDeclHandler DeclHandler() {
			return ProxyQXmlSimpleReader().DeclHandler();
		}
		[SmokeMethod("parse(const QXmlInputSource&)")]
		public new bool Parse(QXmlInputSource input) {
			return ProxyQXmlSimpleReader().Parse(input);
		}
		[SmokeMethod("parse(const QXmlInputSource*, bool)")]
		public new virtual bool Parse(QXmlInputSource input, bool incremental) {
			return ProxyQXmlSimpleReader().Parse(input,incremental);
		}
		[SmokeMethod("parseContinue()")]
		public virtual bool ParseContinue() {
			return ProxyQXmlSimpleReader().ParseContinue();
		}
		~QXmlSimpleReader() {
			DisposeQXmlSimpleReader();
		}
		public new void Dispose() {
			DisposeQXmlSimpleReader();
		}
		private void DisposeQXmlSimpleReader() {
			ProxyQXmlSimpleReader().DisposeQXmlSimpleReader();
		}
	}
}
