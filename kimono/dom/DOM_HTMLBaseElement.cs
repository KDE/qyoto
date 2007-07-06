//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Document base URI. See the <a
	///  href="http://www.w3.org/TR/REC-html40/struct/links.html#edef-BASE">
	///  BASE element definition </a> in HTML 4.0.
	///  </remarks>		<short>    Document base URI.</short>

	[SmokeClass("DOM::HTMLBaseElement")]
	public class HTMLBaseElement : DOM.HTMLElement, IDisposable {
 		protected HTMLBaseElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLBaseElement), this);
		}
		// DOM::HTMLBaseElement* HTMLBaseElement(DOM::HTMLBaseElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLBaseElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseElement", "HTMLBaseElement()", typeof(void));
		}
		public HTMLBaseElement(DOM.HTMLBaseElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseElement#", "HTMLBaseElement(const DOM::HTMLBaseElement&)", typeof(void), typeof(DOM.HTMLBaseElement), other);
		}
		public HTMLBaseElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseElement#", "HTMLBaseElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  The base URI See the <a
		///  href="http://www.w3.org/TR/REC-html40/struct/links.html#adef-href-BASE">
		///  href attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The base URI See the <a  href="http://www.</short>
		public string Href() {
			return (string) interceptor.Invoke("href", "href() const", typeof(string));
		}
		/// <remarks>
		///  see href
		///      </remarks>		<short>    see href      </short>
		public void SetHref(string arg1) {
			interceptor.Invoke("setHref#", "setHref(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  The default target frame. See the <a
		///  href="http://www.w3.org/TR/REC-html40/present/frames.html#adef-target">
		///  target attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The default target frame.</short>
		public string Target() {
			return (string) interceptor.Invoke("target", "target() const", typeof(string));
		}
		/// <remarks>
		///  see target
		///      </remarks>		<short>    see target      </short>
		public void SetTarget(string arg1) {
			interceptor.Invoke("setTarget#", "setTarget(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		~HTMLBaseElement() {
			interceptor.Invoke("~HTMLBaseElement", "~HTMLBaseElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLBaseElement", "~HTMLBaseElement()", typeof(void));
		}
	}
	}
}
