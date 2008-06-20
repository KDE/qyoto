//Auto-generated by kalyptus. DO NOT EDIT.
namespace DOM {
	using Kimono;
	using System;
	using Qyoto;
	/// <remarks>
	///  Base font. See the <a
	///  href="http://www.w3.org/TR/REC-html40/present/graphics.html#edef-BASEFONT">
	///  BASEFONT element definition </a> in HTML 4.0. This element is
	///  deprecated in HTML 4.0.
	///  </remarks>		<short>    Base font.</short>
	[SmokeClass("DOM::HTMLBaseFontElement")]
	public class HTMLBaseFontElement : DOM.HTMLElement, IDisposable {
 		protected HTMLBaseFontElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLBaseFontElement), this);
		}
		// DOM::HTMLBaseFontElement* HTMLBaseFontElement(DOM::HTMLBaseFontElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLBaseFontElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseFontElement", "HTMLBaseFontElement()", typeof(void));
		}
		public HTMLBaseFontElement(DOM.HTMLBaseFontElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseFontElement#", "HTMLBaseFontElement(const DOM::HTMLBaseFontElement&)", typeof(void), typeof(DOM.HTMLBaseFontElement), other);
		}
		public HTMLBaseFontElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLBaseFontElement#", "HTMLBaseFontElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  Font color. See the <a href="http://www.w3.org/TR/REC-html40/">
		///  color attribute definition </a> in HTML 4.0. This attribute is
		///  deprecated in HTML 4.0.
		///      </remarks>		<short>    Font color.</short>
		public DOM.DOMString Color() {
			return (DOM.DOMString) interceptor.Invoke("color", "color() const", typeof(DOM.DOMString));
		}
		/// <remarks>
		///  see color
		///      </remarks>		<short>    see color      </short>
		public void SetColor(DOM.DOMString arg1) {
			interceptor.Invoke("setColor#", "setColor(const DOM::DOMString&)", typeof(void), typeof(DOM.DOMString), arg1);
		}
		/// <remarks>
		///  Font face identifier. See the <a
		///  href="http://www.w3.org/TR/REC-html40/"> face attribute
		///  definition </a> in HTML 4.0. This attribute is deprecated in
		///  HTML 4.0.
		///      </remarks>		<short>    Font face identifier.</short>
		public DOM.DOMString Face() {
			return (DOM.DOMString) interceptor.Invoke("face", "face() const", typeof(DOM.DOMString));
		}
		/// <remarks>
		///  see face
		///      </remarks>		<short>    see face      </short>
		public void SetFace(DOM.DOMString arg1) {
			interceptor.Invoke("setFace#", "setFace(const DOM::DOMString&)", typeof(void), typeof(DOM.DOMString), arg1);
		}
		/// <remarks>
		///  Computed Font size. See the <a
		///  href="http://www.w3.org/TR/REC-html40/present/graphics.html#adef-size-BASEFONT">
		///  size attribute definition </a> in HTML 4.0. This attribute is
		///  deprecated in HTML 4.0.
		///      </remarks>		<short>    Computed Font size.</short>
		public long GetSize() {
			return (long) interceptor.Invoke("getSize", "getSize() const", typeof(long));
		}
		/// <remarks>
		///  see size
		///       </remarks>		<short>    see size       </short>
		public void SetSize(long arg1) {
			interceptor.Invoke("setSize$", "setSize(long)", typeof(void), typeof(long), arg1);
		}
		~HTMLBaseFontElement() {
			interceptor.Invoke("~HTMLBaseFontElement", "~HTMLBaseFontElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLBaseFontElement", "~HTMLBaseFontElement()", typeof(void));
		}
	}
}