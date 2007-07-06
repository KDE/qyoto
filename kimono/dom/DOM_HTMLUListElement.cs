//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Unordered list. See the <a
	///  href="http://www.w3.org/TR/REC-html40/struct/lists.html#edef-UL">
	///  UL element definition </a> in HTML 4.0.
	///  </remarks>		<short>    Unordered list.</short>

	[SmokeClass("DOM::HTMLUListElement")]
	public class HTMLUListElement : DOM.HTMLElement, IDisposable {
 		protected HTMLUListElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLUListElement), this);
		}
		// DOM::HTMLUListElement* HTMLUListElement(DOM::HTMLUListElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLUListElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLUListElement", "HTMLUListElement()", typeof(void));
		}
		public HTMLUListElement(DOM.HTMLUListElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLUListElement#", "HTMLUListElement(const DOM::HTMLUListElement&)", typeof(void), typeof(DOM.HTMLUListElement), other);
		}
		public HTMLUListElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLUListElement#", "HTMLUListElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  Reduce spacing between list items. See the <a
		///  href="http://www.w3.org/TR/REC-html40/struct/lists.html#adef-compact">
		///  compact attribute definition </a> in HTML 4.0. This attribute
		///  is deprecated in HTML 4.0.
		///      </remarks>		<short>    Reduce spacing between list items.</short>
		public bool Compact() {
			return (bool) interceptor.Invoke("compact", "compact() const", typeof(bool));
		}
		/// <remarks>
		///  see compact
		///      </remarks>		<short>    see compact      </short>
		public void SetCompact(bool arg1) {
			interceptor.Invoke("setCompact$", "setCompact(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  Bullet style. See the <a
		///  href="http://www.w3.org/TR/REC-html40/struct/lists.html#adef-type-UL">
		///  type attribute definition </a> in HTML 4.0. This attribute is
		///  deprecated in HTML 4.0.
		///      </remarks>		<short>    Bullet style.</short>
		public string type() {
			return (string) interceptor.Invoke("type", "type() const", typeof(string));
		}
		/// <remarks>
		///  see type
		///      </remarks>		<short>    see type      </short>
		public void SetType(string arg1) {
			interceptor.Invoke("setType#", "setType(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		~HTMLUListElement() {
			interceptor.Invoke("~HTMLUListElement", "~HTMLUListElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLUListElement", "~HTMLUListElement()", typeof(void));
		}
	}
	}
}
