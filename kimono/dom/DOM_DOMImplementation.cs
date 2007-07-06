//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  The <code>DOMImplementation</code> interface provides a number of
	///  methods for performing operations that are independent of any
	///  particular instance of the document object model.
	///  DOM Level 2 and newer provide means for creating documents directly,
	///  which was not possible with DOM Level 1.
	///  </remarks>		<short>    The <code>DOMImplementation</code> interface provides a number of  methods for performing operations that are independent of any  particular instance of the document object model.</short>

	[SmokeClass("DOM::DOMImplementation")]
	public class DOMImplementation : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected DOMImplementation(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(DOMImplementation), this);
		}
		// DOM::DOMImplementation* DOMImplementation(DOM::DOMImplementationImpl* arg1); >>>> NOT CONVERTED
		public DOMImplementation() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("DOMImplementation", "DOMImplementation()", typeof(void));
		}
		public DOMImplementation(DOM.DOMImplementation other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("DOMImplementation#", "DOMImplementation(const DOM::DOMImplementation&)", typeof(void), typeof(DOM.DOMImplementation), other);
		}
		/// <remarks>
		///  Test if the DOM implementation implements a specific feature.
		/// <param> name="feature" The package name of the feature to test. In
		///  Level 1, the legal values are "HTML" and "XML"
		///  (case-insensitive).
		/// </param><param> name="version" This is the version number of the package name
		///  to test. In Level 1, this is the string "1.0". If the version
		///  is not specified, supporting any version of the feature will
		///  cause the method to return <code>true</code> .
		/// </param>     </remarks>		<return> <code>true</code> if the feature is implemented in
		///  the specified version, <code>false</code> otherwise.
		/// </return>
		/// 		<short>    Test if the DOM implementation implements a specific feature.</short>
		public bool HasFeature(string feature, string version) {
			return (bool) interceptor.Invoke("hasFeature##", "hasFeature(const DOM::DOMString&, const DOM::DOMString&)", typeof(bool), typeof(string), feature, typeof(string), version);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  Creates an empty DocumentType node. Entity declarations and notations
		///  are not made available. Entity reference expansions and default
		///  attribute additions do not occur. It is expected that a future version
		///  of the DOM will provide a way for populating a DocumentType.
		///  HTML-only DOM implementations do not need to implement this method.
		/// <param> name="qualifiedName" The qualified name of the document type to be
		///  created.
		/// </param><param> name="publicId" The external subset public identifier.
		/// </param><param> name="systemId" The external subset system identifier.
		/// </param> NAMESPACE_ERR: Raised if the qualifiedName is malformed.
		///      </remarks>		<return> A new DocumentType node with Node.ownerDocument set to null.
		/// </return>
		/// 		<short>    Introduced in DOM Level 2 </short>
		public DOM.DocumentType CreateDocumentType(string qualifiedName, string publicId, string systemId) {
			return (DOM.DocumentType) interceptor.Invoke("createDocumentType###", "createDocumentType(const DOM::DOMString&, const DOM::DOMString&, const DOM::DOMString&)", typeof(DOM.DocumentType), typeof(string), qualifiedName, typeof(string), publicId, typeof(string), systemId);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  Creates an XML Document object of the specified type with its document
		///  element. HTML-only DOM implementations do not need to implement this
		///  method.
		/// <param> name="namespaceURI" The namespace URI of the document element to create.
		/// </param><param> name="qualifiedName" The qualified name of the document element to be
		///  created.
		/// </param><param> name="doctype" The type of document to be created or null. When doctype
		///  is not null, its Node.ownerDocument attribute is set to the document
		///  being created.
		/// </param> NAMESPACE_ERR: Raised if the qualifiedName is malformed, if the
		///  qualifiedName has a prefix and the namespaceURI is null, or if the
		///  qualifiedName has a prefix that is "xml" and the namespaceURI is
		///  different from "http://www.w3.org/XML/1998/namespace" [Namespaces].
		///  WRONG_DOCUMENT_ERR: Raised if doctype has already been used with a
		///  different document or was created from a different implementation.
		///      </remarks>		<return> A new Document object.
		/// </return>
		/// 		<short>    Introduced in DOM Level 2 </short>
		public DOM.Document CreateDocument(string namespaceURI, string qualifiedName, DOM.DocumentType doctype) {
			return (DOM.Document) interceptor.Invoke("createDocument###", "createDocument(const DOM::DOMString&, const DOM::DOMString&, const DOM::DocumentType&)", typeof(DOM.Document), typeof(string), namespaceURI, typeof(string), qualifiedName, typeof(DOM.DocumentType), doctype);
		}
		/// <remarks>
		///  Introduced in DOM Level 3
		///  This method makes available a DOMImplementation's specialized
		///  interface.
		/// <param> name="feature" The name of the feature requested (case-insensitive)
		/// </param></remarks>		<return> Returns an alternate DOMImplementation which implements
		///  the specialized APIs of the specified feature, if any, or null
		///  if there is no alternate DOMImplementation object which implements
		///  interfaces associated with that feature. Any alternate DOMImplementation
		///  returned by this method must delegate to the primary core DOMImplementation
		///  and not return results inconsistent with the primary DOMImplementation.
		///      </return>
		/// 		<short>    Introduced in DOM Level 3  This method makes available a DOMImplementation's specialized  interface.</short>
		public DOM.DOMImplementation GetInterface(string feature) {
			return (DOM.DOMImplementation) interceptor.Invoke("getInterface#", "getInterface(const DOM::DOMString&) const", typeof(DOM.DOMImplementation), typeof(string), feature);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  This method is from the DOMImplementationCSS interface
		///  Creates a new CSSStyleSheet.
		/// <param> name="title" The advisory title. See also the Style Sheet Interfaces
		///  section.
		/// </param><param> name="media" The comma-separated list of media associated with the
		///  new style sheet. See also the Style Sheet Interfaces section.
		/// </param></remarks>		<return> A new CSS style sheet.
		/// </return>
		/// 		<short>    Introduced in DOM Level 2  This method is from the DOMImplementationCSS interface </short>
		public DOM.CSSStyleSheet CreateCSSStyleSheet(string title, string media) {
			return (DOM.CSSStyleSheet) interceptor.Invoke("createCSSStyleSheet##", "createCSSStyleSheet(const DOM::DOMString&, const DOM::DOMString&)", typeof(DOM.CSSStyleSheet), typeof(string), title, typeof(string), media);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  This method is from the HTMLDOMImplementation interface
		///  Creates an HTMLDocument with the minimal tree made of these
		///  elements: HTML,HEAD,TITLE and BODY.
		///  It extends the core interface which can be used to create an
		///  XHTML document by passing the XHTML namespace as the namespace
		///  for the root element.
		/// <param> name="title" The title of the document to be set as the content
		///  of the TITLE element, through a child Text node.
		/// </param></remarks>		<return> the HTMLdocument
		///      </return>
		/// 		<short>    Introduced in DOM Level 2  This method is from the HTMLDOMImplementation interface </short>
		public DOM.HTMLDocument CreateHTMLDocument(string title) {
			return (DOM.HTMLDocument) interceptor.Invoke("createHTMLDocument#", "createHTMLDocument(const DOM::DOMString&)", typeof(DOM.HTMLDocument), typeof(string), title);
		}
		public bool IsNull() {
			return (bool) interceptor.Invoke("isNull", "isNull() const", typeof(bool));
		}
		~DOMImplementation() {
			interceptor.Invoke("~DOMImplementation", "~DOMImplementation()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~DOMImplementation", "~DOMImplementation()", typeof(void));
		}
	}
	}
}
