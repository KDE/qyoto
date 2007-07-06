//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  A selectable choice. See the <a
	///  href="http://www.w3.org/TR/REC-html40/interact/forms.html#edef-OPTION">
	///  OPTION element definition </a> in HTML 4.0.
	///  </remarks>		<short>    A selectable choice.</short>

	[SmokeClass("DOM::HTMLOptionElement")]
	public class HTMLOptionElement : DOM.HTMLElement, IDisposable {
 		protected HTMLOptionElement(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLOptionElement), this);
		}
		// DOM::HTMLOptionElement* HTMLOptionElement(DOM::HTMLOptionElementImpl* arg1); >>>> NOT CONVERTED
		public HTMLOptionElement() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLOptionElement", "HTMLOptionElement()", typeof(void));
		}
		public HTMLOptionElement(DOM.HTMLOptionElement other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLOptionElement#", "HTMLOptionElement(const DOM::HTMLOptionElement&)", typeof(void), typeof(DOM.HTMLOptionElement), other);
		}
		public HTMLOptionElement(DOM.Node other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("HTMLOptionElement#", "HTMLOptionElement(const DOM::Node&)", typeof(void), typeof(DOM.Node), other);
		}
		/// <remarks>
		///  ### KDE 4.0: remove
		///      </remarks>		<short>    ### KDE 4.</short>
		public new DOM.HTMLFormElement Form() {
			return (DOM.HTMLFormElement) interceptor.Invoke("form", "form() const", typeof(DOM.HTMLFormElement));
		}
		/// <remarks>
		///  Stores the initial value of the <code>selected</code>
		///  attribute.
		///      </remarks>		<short>    Stores the initial value of the <code>selected</code>  attribute.</short>
		public bool DefaultSelected() {
			return (bool) interceptor.Invoke("defaultSelected", "defaultSelected() const", typeof(bool));
		}
		/// <remarks>
		///  see defaultSelected
		///      </remarks>		<short>    see defaultSelected      </short>
		public void SetDefaultSelected(bool arg1) {
			interceptor.Invoke("setDefaultSelected$", "setDefaultSelected(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  The text contained within the option element.
		///      </remarks>		<short>    The text contained within the option element.</short>
		public string Text() {
			return (string) interceptor.Invoke("text", "text() const", typeof(string));
		}
		/// <remarks>
		///  The index of this <code>OPTION</code> in its parent
		///  <code>SELECT</code> .
		///      </remarks>		<short>    The index of this <code>OPTION</code> in its parent  <code>SELECT</code> .</short>
		public new long Index() {
			return (long) interceptor.Invoke("index", "index() const", typeof(long));
		}
		/// <remarks>
		///  see index
		///  This function is obsolete - the index property is actually supposed to be read-only
		///  (http://www.w3.org/DOM/updates/REC-DOM-Level-1-19981001-errata.html)
		///      </remarks>		<short>    see index </short>
		public void SetIndex(long arg1) {
			interceptor.Invoke("setIndex$", "setIndex(long)", typeof(void), typeof(long), arg1);
		}
		/// <remarks>
		///  The control is unavailable in this context. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/forms.html#adef-disabled">
		///  disabled attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The control is unavailable in this context.</short>
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
		///  Option label for use in hierarchical menus. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/forms.html#adef-label-OPTION">
		///  label attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    Option label for use in hierarchical menus.</short>
		public string Label() {
			return (string) interceptor.Invoke("label", "label() const", typeof(string));
		}
		/// <remarks>
		///  see label
		///      </remarks>		<short>    see label      </short>
		public void SetLabel(string arg1) {
			interceptor.Invoke("setLabel#", "setLabel(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Means that this option is initially selected. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/forms.html#adef-selected">
		///  selected attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    Means that this option is initially selected.</short>
		public bool Selected() {
			return (bool) interceptor.Invoke("selected", "selected() const", typeof(bool));
		}
		/// <remarks>
		///  see selected
		///      </remarks>		<short>    see selected      </short>
		public void SetSelected(bool arg1) {
			interceptor.Invoke("setSelected$", "setSelected(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  The current form control value. See the <a
		///  href="http://www.w3.org/TR/REC-html40/interact/forms.html#adef-value-OPTION">
		///  value attribute definition </a> in HTML 4.0.
		///      </remarks>		<short>    The current form control value.</short>
		public string Value() {
			return (string) interceptor.Invoke("value", "value() const", typeof(string));
		}
		/// <remarks>
		///  see value
		///      </remarks>		<short>    see value      </short>
		public void SetValue(string arg1) {
			interceptor.Invoke("setValue#", "setValue(const DOM::DOMString&)", typeof(void), typeof(string), arg1);
		}
		~HTMLOptionElement() {
			interceptor.Invoke("~HTMLOptionElement", "~HTMLOptionElement()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLOptionElement", "~HTMLOptionElement()", typeof(void));
		}
	}
	}
}
