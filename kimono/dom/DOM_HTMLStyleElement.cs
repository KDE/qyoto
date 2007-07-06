//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Style information. A more detailed style sheet object model is
	///  planned to be defined in a separate document. See the <a
	///  href="http://www.w3.org/TR/REC-html40/present/styles.html#edef-STYLE">
	///  STYLE element definition </a> in HTML 4.0.
	///  </remarks>		<short>    Style information.</short>

	[SmokeClass("DOM::HTMLStyleElement")]
	public class HTMLStyleElement : DOM.HTMLElement, IDisposable {
 		protected HTMLStyleElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLStyleElement), this);
		}
		// DOM::HTMLStyleElement* HTMLStyleElement(DOM::HTMLStyleElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLStyleElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLStyleElement", "HTMLStyleElement()", typeof(void));
		}
		public HTMLStyleElement(DOM.HTMLStyleElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLStyleElement#", "HTMLStyleElement(const DOM::HTMLStyleElement&)", typeof(void), typeof(DOM.HTMLStyleElement), other);
		}
		public HTMLStyleElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLStyleElement#", "HTMLStyleElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  Enables/disables the style sheet.
		///      </remarks>		<short>    Enables/disables the style sheet.</short>
		public bool Disabled() {
			return (bool) interceptor.Invoke("disabled", "disabled() const", typeof(bool));
		}
		/// <remarks>
		///  see disabled
		///      </remarks>		<short>    see disabled      </short>
		public void SetDisabled(bool arg1) {
			interceptor.Invoke("setDisabled$", "setDisabled(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  Designed for use with one or more target media. See the <a
		///  href="http://www.w3.org/TR/REC-html40/present/styles.html#adef-media">
		///  media attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    Designed for use with one or more target media.</short>
		public string Media() {
			return (string) interceptor.Invoke("media", "media() const", typeof(string));
		}
		/// <remarks>
		///  see media
		///      </remarks>		<short>    see media      </short>
		public void SetMedia(string arg1) {
			interceptor.Invoke("setMedia#", "setMedia(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  The style sheet language (Internet media type). See the <a
		///  href="http://www.w3.org/TR/REC-html40/present/styles.html#adef-type-STYLE">
		///  type attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The style sheet language (Internet media type).</short>
		public string type() {
			return (string) interceptor.Invoke("type", "type() const", typeof(string));
		}
		/// <remarks>
		///  see type
		///      </remarks>		<short>    see type      </short>
		public void SetType(string arg1) {
			interceptor.Invoke("setType#", "setType(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  This method is from the LinkStyle interface
		///  The style sheet.
		///      </remarks>		<short>    Introduced in DOM Level 2  This method is from the LinkStyle interface </short>
		public DOM.StyleSheet Sheet() {
			return (DOM.StyleSheet) interceptor.Invoke("sheet", "sheet() const", typeof(DOM.StyleSheet));
		}
		~HTMLStyleElement() {
			interceptor.Invoke("~HTMLStyleElement", "~HTMLStyleElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLStyleElement", "~HTMLStyleElement()", typeof(void));
		}
	}
	}
}
