//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	public class QXmlSimpleReader : QXmlReader, IDisposable {
 		protected QXmlSimpleReader(Type dummy) : base((Type) null) {}
		interface IQXmlSimpleReaderProxy {
		}

		protected void CreateQXmlSimpleReaderProxy() {
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
			CreateQXmlSimpleReaderProxy();
			NewQXmlSimpleReader();
		}
		private void NewQXmlSimpleReader() {
			ProxyQXmlSimpleReader().NewQXmlSimpleReader();
		}
		public new bool Feature(string name, out bool ok) {
			return ProxyQXmlSimpleReader().Feature(name,out ok);
		}
		public new bool Feature(string name) {
			return ProxyQXmlSimpleReader().Feature(name);
		}
		public new void SetFeature(string name, bool value) {
			ProxyQXmlSimpleReader().SetFeature(name,value);
		}
		public new bool HasFeature(string name) {
			return ProxyQXmlSimpleReader().HasFeature(name);
		}
		// void* property(const QString& arg1,bool* arg2); >>>> NOT CONVERTED
		// void* property(const QString& arg1); >>>> NOT CONVERTED
		// void setProperty(const QString& arg1,void* arg2); >>>> NOT CONVERTED
		public new bool HasProperty(string name) {
			return ProxyQXmlSimpleReader().HasProperty(name);
		}
		public new void SetEntityResolver(IQXmlEntityResolver handler) {
			ProxyQXmlSimpleReader().SetEntityResolver(handler);
		}
		public new IQXmlEntityResolver EntityResolver() {
			return ProxyQXmlSimpleReader().EntityResolver();
		}
		public new void SetDTDHandler(IQXmlDTDHandler handler) {
			ProxyQXmlSimpleReader().SetDTDHandler(handler);
		}
		public new IQXmlDTDHandler DTDHandler() {
			return ProxyQXmlSimpleReader().DTDHandler();
		}
		public new void SetContentHandler(IQXmlContentHandler handler) {
			ProxyQXmlSimpleReader().SetContentHandler(handler);
		}
		public new IQXmlContentHandler ContentHandler() {
			return ProxyQXmlSimpleReader().ContentHandler();
		}
		public new void SetErrorHandler(IQXmlErrorHandler handler) {
			ProxyQXmlSimpleReader().SetErrorHandler(handler);
		}
		public new IQXmlErrorHandler ErrorHandler() {
			return ProxyQXmlSimpleReader().ErrorHandler();
		}
		public new void SetLexicalHandler(IQXmlLexicalHandler handler) {
			ProxyQXmlSimpleReader().SetLexicalHandler(handler);
		}
		public new IQXmlLexicalHandler LexicalHandler() {
			return ProxyQXmlSimpleReader().LexicalHandler();
		}
		public new void SetDeclHandler(IQXmlDeclHandler handler) {
			ProxyQXmlSimpleReader().SetDeclHandler(handler);
		}
		public new IQXmlDeclHandler DeclHandler() {
			return ProxyQXmlSimpleReader().DeclHandler();
		}
		public new bool Parse(QXmlInputSource input) {
			return ProxyQXmlSimpleReader().Parse(input);
		}
		public new virtual bool Parse(QXmlInputSource input, bool incremental) {
			return ProxyQXmlSimpleReader().Parse(input,incremental);
		}
		public virtual bool ParseContinue() {
			return ProxyQXmlSimpleReader().ParseContinue();
		}
		~QXmlSimpleReader() {
			ProxyQXmlSimpleReader().Dispose();
		}
		public new void Dispose() {
			ProxyQXmlSimpleReader().Dispose();
		}
	}
}