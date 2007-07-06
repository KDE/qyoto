//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Script statements. See the <a
	///  href="http://www.w3.org/TR/REC-html40/interact/scripts.html#edef-SCRIPT">
	///  SCRIPT element definition </a> in HTML 4.0.
	///  </remarks>		<short>    Script statements.</short>

	[SmokeClass("DOM::HTMLScriptElement")]
	public class HTMLScriptElement : DOM.HTMLElement, IDisposable {
 		protected HTMLScriptElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLScriptElement), this);
		}
		// DOM::HTMLScriptElement* HTMLScriptElement(DOM::HTMLScriptElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLScriptElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLScriptElement", "HTMLScriptElement()", typeof(void));
		}
		public HTMLScriptElement(DOM.HTMLScriptElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLScriptElement#", "HTMLScriptElement(const DOM::HTMLScriptElement&)", typeof(void), typeof(DOM.HTMLScriptElement), other);
		}
		public HTMLScriptElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLScriptElement#", "HTMLScriptElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  The script content of the element.
		///      </remarks>		<short>    The script content of the element.</short>
		public string Text() {
			return (string) interceptor.Invoke("text", "text() const", typeof(string));
		}
		/// <remarks>
		///  see text
		///      </remarks>		<short>    see text      </short>
		public void SetText(string arg1) {
			interceptor.Invoke("setText#", "setText(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Reserved for future use.
		///      </remarks>		<short>    Reserved for future use.</short>
		public string HtmlFor() {
			return (string) interceptor.Invoke("htmlFor", "htmlFor() const", typeof(string));
		}
		/// <remarks>
		///  see htmlFor
		///      </remarks>		<short>    see htmlFor      </short>
		public void SetHtmlFor(string arg1) {
			interceptor.Invoke("setHtmlFor#", "setHtmlFor(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Reserved for future use.
		///      </remarks>		<short>    Reserved for future use.</short>
		public string Event() {
			return (string) interceptor.Invoke("event", "event() const", typeof(string));
		}
		/// <remarks>
		///  see event
		///      </remarks>		<short>    see event      </short>
		public void SetEvent(string arg1) {
			interceptor.Invoke("setEvent#", "setEvent(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  The character encoding of the linked resource. See the <a
		///  href="http://www.w3.org/TR/REC-html40/struct/links.html#adef-charset">
		///  charset attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The character encoding of the linked resource.</short>
		public string Charset() {
			return (string) interceptor.Invoke("charset", "charset() const", typeof(string));
		}
		/// <remarks>
		///  see charset
		///      </remarks>		<short>    see charset      </short>
		public void SetCharset(string arg1) {
			interceptor.Invoke("setCharset#", "setCharset(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Indicates that the user agent can defer processing of the
		///  script. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/scripts.html#adef-defer">
		///  defer attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    Indicates that the user agent can defer processing of the  script.</short>
		public bool Defer() {
			return (bool) interceptor.Invoke("defer", "defer() const", typeof(bool));
		}
		/// <remarks>
		///  see defer
		///      </remarks>		<short>    see defer      </short>
		public void SetDefer(bool arg1) {
			interceptor.Invoke("setDefer$", "setDefer(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  URI designating an external script. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/scripts.html#adef-src-SCRIPT">
		///  src attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    URI designating an external script.</short>
		public string Src() {
			return (string) interceptor.Invoke("src", "src() const", typeof(string));
		}
		/// <remarks>
		///  see src
		///      </remarks>		<short>    see src      </short>
		public void SetSrc(string arg1) {
			interceptor.Invoke("setSrc#", "setSrc(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  The content type of the script language. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/scripts.html#adef-type-SCRIPT">
		///  type attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The content type of the script language.</short>
		public string type() {
			return (string) interceptor.Invoke("type", "type() const", typeof(string));
		}
		/// <remarks>
		///  see type
		///      </remarks>		<short>    see type      </short>
		public void SetType(string arg1) {
			interceptor.Invoke("setType#", "setType(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		~HTMLScriptElement() {
			interceptor.Invoke("~HTMLScriptElement", "~HTMLScriptElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLScriptElement", "~HTMLScriptElement()", typeof(void));
		}
	}
	}
}
