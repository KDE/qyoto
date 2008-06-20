//Auto-generated by kalyptus. DO NOT EDIT.
namespace DOM {
	using Kimono;
	using System;
	using Qyoto;
	[SmokeClass("DOM::DocumentStyle")]
	public class DocumentStyle : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected DocumentStyle(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(DocumentStyle), this);
		}
		public DocumentStyle() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("DocumentStyle", "DocumentStyle()", typeof(void));
		}
		public DocumentStyle(DOM.DocumentStyle other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("DocumentStyle#", "DocumentStyle(const DOM::DocumentStyle&)", typeof(void), typeof(DOM.DocumentStyle), other);
		}
		public DOM.StyleSheetList StyleSheets() {
			return (DOM.StyleSheetList) interceptor.Invoke("styleSheets", "styleSheets() const", typeof(DOM.StyleSheetList));
		}
		public DOM.DOMString PreferredStylesheetSet() {
			return (DOM.DOMString) interceptor.Invoke("preferredStylesheetSet", "preferredStylesheetSet() const", typeof(DOM.DOMString));
		}
		public DOM.DOMString SelectedStylesheetSet() {
			return (DOM.DOMString) interceptor.Invoke("selectedStylesheetSet", "selectedStylesheetSet() const", typeof(DOM.DOMString));
		}
		public void SetSelectedStylesheetSet(DOM.DOMString aString) {
			interceptor.Invoke("setSelectedStylesheetSet#", "setSelectedStylesheetSet(const DOM::DOMString&)", typeof(void), typeof(DOM.DOMString), aString);
		}
		public bool IsNull() {
			return (bool) interceptor.Invoke("isNull", "isNull() const", typeof(bool));
		}
		~DocumentStyle() {
			interceptor.Invoke("~DocumentStyle", "~DocumentStyle()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~DocumentStyle", "~DocumentStyle()", typeof(void));
		}
	}
}