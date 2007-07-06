//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  ??? See the <a
	///  href="http://www.w3.org/TR/REC-html40/struct/text.html#edef-BLOCKQUOTE">
	///  BLOCKQUOTE element definition </a> in HTML 4.0.
	///  </remarks>		<short>    ??? See the <a  href="http://www.</short>

	[SmokeClass("DOM::HTMLBlockquoteElement")]
	public class HTMLBlockquoteElement : DOM.HTMLElement, IDisposable {
 		protected HTMLBlockquoteElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLBlockquoteElement), this);
		}
		// DOM::HTMLBlockquoteElement* HTMLBlockquoteElement(DOM::HTMLElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLBlockquoteElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBlockquoteElement", "HTMLBlockquoteElement()", typeof(void));
		}
		public HTMLBlockquoteElement(DOM.HTMLBlockquoteElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBlockquoteElement#", "HTMLBlockquoteElement(const DOM::HTMLBlockquoteElement&)", typeof(void), typeof(DOM.HTMLBlockquoteElement), other);
		}
		public HTMLBlockquoteElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBlockquoteElement#", "HTMLBlockquoteElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  A URI designating a document that describes the reason for the
		///  change. See the <a href="http://www.w3.org/TR/REC-html40/">
		///  cite attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    A URI designating a document that describes the reason for the  change.</short>
		public string Cite() {
			return (string) interceptor.Invoke("cite", "cite() const", typeof(string));
		}
		/// <remarks>
		///  see cite
		///      </remarks>		<short>    see cite      </short>
		public void SetCite(string arg1) {
			interceptor.Invoke("setCite#", "setCite(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		~HTMLBlockquoteElement() {
			interceptor.Invoke("~HTMLBlockquoteElement", "~HTMLBlockquoteElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLBlockquoteElement", "~HTMLBlockquoteElement()", typeof(void));
		}
	}
	}
}
