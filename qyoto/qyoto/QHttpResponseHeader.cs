//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QHttpResponseHeader")]
	public class QHttpResponseHeader : QHttpHeader, IDisposable {
 		protected QHttpResponseHeader(Type dummy) : base((Type) null) {}
		interface IQHttpResponseHeaderProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHttpResponseHeader), this);
			_interceptor = (QHttpResponseHeader) realProxy.GetTransparentProxy();
		}
		private QHttpResponseHeader ProxyQHttpResponseHeader() {
			return (QHttpResponseHeader) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHttpResponseHeader() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHttpResponseHeaderProxy), null);
			_staticInterceptor = (IQHttpResponseHeaderProxy) realProxy.GetTransparentProxy();
		}
		private static IQHttpResponseHeaderProxy StaticQHttpResponseHeader() {
			return (IQHttpResponseHeaderProxy) _staticInterceptor;
		}

		public QHttpResponseHeader() : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader();
		}
		[SmokeMethod("QHttpResponseHeader()")]
		private void NewQHttpResponseHeader() {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader();
		}
		public QHttpResponseHeader(QHttpResponseHeader header) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(header);
		}
		[SmokeMethod("QHttpResponseHeader(const QHttpResponseHeader&)")]
		private void NewQHttpResponseHeader(QHttpResponseHeader header) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(header);
		}
		public QHttpResponseHeader(string str) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(str);
		}
		[SmokeMethod("QHttpResponseHeader(const QString&)")]
		private void NewQHttpResponseHeader(string str) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(str);
		}
		public QHttpResponseHeader(int code, string text, int majorVer, int minorVer) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(code,text,majorVer,minorVer);
		}
		[SmokeMethod("QHttpResponseHeader(int, const QString&, int, int)")]
		private void NewQHttpResponseHeader(int code, string text, int majorVer, int minorVer) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(code,text,majorVer,minorVer);
		}
		public QHttpResponseHeader(int code, string text, int majorVer) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(code,text,majorVer);
		}
		[SmokeMethod("QHttpResponseHeader(int, const QString&, int)")]
		private void NewQHttpResponseHeader(int code, string text, int majorVer) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(code,text,majorVer);
		}
		public QHttpResponseHeader(int code, string text) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(code,text);
		}
		[SmokeMethod("QHttpResponseHeader(int, const QString&)")]
		private void NewQHttpResponseHeader(int code, string text) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(code,text);
		}
		public QHttpResponseHeader(int code) : this((Type) null) {
			CreateProxy();
			NewQHttpResponseHeader(code);
		}
		[SmokeMethod("QHttpResponseHeader(int)")]
		private void NewQHttpResponseHeader(int code) {
			ProxyQHttpResponseHeader().NewQHttpResponseHeader(code);
		}
		[SmokeMethod("setStatusLine(int, const QString&, int, int)")]
		public void SetStatusLine(int code, string text, int majorVer, int minorVer) {
			ProxyQHttpResponseHeader().SetStatusLine(code,text,majorVer,minorVer);
		}
		[SmokeMethod("setStatusLine(int, const QString&, int)")]
		public void SetStatusLine(int code, string text, int majorVer) {
			ProxyQHttpResponseHeader().SetStatusLine(code,text,majorVer);
		}
		[SmokeMethod("setStatusLine(int, const QString&)")]
		public void SetStatusLine(int code, string text) {
			ProxyQHttpResponseHeader().SetStatusLine(code,text);
		}
		[SmokeMethod("setStatusLine(int)")]
		public void SetStatusLine(int code) {
			ProxyQHttpResponseHeader().SetStatusLine(code);
		}
		[SmokeMethod("statusCode() const")]
		public int StatusCode() {
			return ProxyQHttpResponseHeader().StatusCode();
		}
		[SmokeMethod("reasonPhrase() const")]
		public string ReasonPhrase() {
			return ProxyQHttpResponseHeader().ReasonPhrase();
		}
		[SmokeMethod("majorVersion() const")]
		public new int MajorVersion() {
			return ProxyQHttpResponseHeader().MajorVersion();
		}
		[SmokeMethod("minorVersion() const")]
		public new int MinorVersion() {
			return ProxyQHttpResponseHeader().MinorVersion();
		}
		[SmokeMethod("toString() const")]
		public new string ToString() {
			return ProxyQHttpResponseHeader().ToString();
		}
		[SmokeMethod("parseLine(const QString&, int)")]
		protected new bool ParseLine(string line, int number) {
			return ProxyQHttpResponseHeader().ParseLine(line,number);
		}
		~QHttpResponseHeader() {
			DisposeQHttpResponseHeader();
		}
		public new void Dispose() {
			DisposeQHttpResponseHeader();
		}
		private void DisposeQHttpResponseHeader() {
			ProxyQHttpResponseHeader().DisposeQHttpResponseHeader();
		}
	}
}
