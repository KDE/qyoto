//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  Objects implementing the <code>NamedNodeMap</code> interface are
	///  used to represent collections of nodes that can be accessed by
	///  name. Note that <code>NamedNodeMap</code> does not inherit from
	///  <code>ArrayList</code> ; <code>NamedNodeMap</code> s are not
	///  maintained in any particular order. Objects contained in an object
	///  implementing <code>NamedNodeMap</code> may also be accessed by an
	///  ordinal index, but this is simply to allow convenient enumeration
	///  of the contents of a <code>NamedNodeMap</code> , and does not
	///  imply that the DOM specifies an order to these Nodes.
	///  </remarks>		<short>    Objects implementing the <code>NamedNodeMap</code> interface are  used to represent collections of nodes that can be accessed by  name.</short>

	[SmokeClass("DOM::NamedNodeMap")]
	public class NamedNodeMap : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected NamedNodeMap(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(NamedNodeMap), this);
		}
		// DOM::NamedNodeMap* NamedNodeMap(DOM::NamedNodeMapImpl* arg1); >>>> NOT CONVERTED
		public NamedNodeMap() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("NamedNodeMap", "NamedNodeMap()", typeof(void));
		}
		public NamedNodeMap(DOM.NamedNodeMap other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("NamedNodeMap#", "NamedNodeMap(const DOM::NamedNodeMap&)", typeof(void), typeof(DOM.NamedNodeMap), other);
		}
		/// <remarks>
		///  The number of nodes in the map. The range of valid child node
		///  indices is 0 to <code>length-1</code> inclusive.
		///      </remarks>		<short>    The number of nodes in the map.</short>
		public ulong Length() {
			return (ulong) interceptor.Invoke("length", "length() const", typeof(ulong));
		}
		/// <remarks>
		///  Retrieves a node specified by name.
		/// <param> name="name" Name of a node to retrieve.
		/// </param>     </remarks>		<return> A <code>Node</code> (of any type) with the specified
		///  name, or <code>null</code> if the specified name did not
		///  identify any node in the map.
		/// </return>
		/// 		<short>    Retrieves a node specified by name.</short>
		public DOM.Node GetNamedItem(string name) {
			return (DOM.Node) interceptor.Invoke("getNamedItem#", "getNamedItem(const DOM::DOMString&) const", typeof(DOM.Node), typeof(string), name);
		}
		/// <remarks>
		///  Adds a node using its <code>nodeName</code> attribute.
		///   As the <code>nodeName</code> attribute is used to derive the
		///  name which the node must be stored under, multiple nodes of
		///  certain types (those that have a "special" string value) cannot
		///  be stored as the names would clash. This is seen as preferable
		///  to allowing nodes to be aliased.
		/// <param> name="arg" A node to store in a named node map. The node will
		///  later be accessible using the value of the <code>nodeName</code>
		///  attribute of the node. If a node with that name is
		///  already present in the map, it is replaced by the new one.
		/// </param>  NO_MODIFICATION_ALLOWED_ERR: Raised if this
		///  <code>NamedNodeMap</code> is readonly.
		///   INUSE_ATTRIBUTE_ERR: Raised if <code>arg</code> is an
		///  <code>Attr</code> that is already an attribute of another
		///  <code>Element</code> object. The DOM user must explicitly clone
		///  <code>Attr</code> nodes to re-use them in other elements.
		///      </remarks>		<return> If the new <code>Node</code> replaces an existing
		///  node with the same name the previously existing <code>Node</code>
		///  is returned, otherwise <code>null</code> is returned.
		/// </return>
		/// 		<short>    Adds a node using its <code>nodeName</code> attribute.</short>
		public DOM.Node SetNamedItem(DOM.Node arg) {
			return (DOM.Node) interceptor.Invoke("setNamedItem#", "setNamedItem(const DOM::Node&)", typeof(DOM.Node), typeof(DOM.Node), arg);
		}
		/// <remarks>
		///  Removes a node specified by name. If the removed node is an
		///  <code>Attr</code> with a default value it is immediately
		///  replaced.
		/// <param> name="name" The name of a node to remove.
		/// </param>     </remarks>		<return> The node removed from the map or <code>null</code> if
		///  no node with such a name exists.
		/// </return>
		/// 		<short>    Removes a node specified by name.</short>
		public DOM.Node RemoveNamedItem(string name) {
			return (DOM.Node) interceptor.Invoke("removeNamedItem#", "removeNamedItem(const DOM::DOMString&)", typeof(DOM.Node), typeof(string), name);
		}
		/// <remarks>
		///  Returns the <code>index</code> th item in the map. If
		///  <code>index</code> is greater than or equal to the number of nodes
		///  in the map, this returns <code>null</code> .
		/// <param> name="index" Index into the map.
		/// </param>     </remarks>		<return> The node at the <code>index</code> th position in the
		///  <code>NamedNodeMap</code> , or <code>null</code> if that is
		///  not a valid index.
		/// </return>
		/// 		<short>    Returns the <code>index</code> th item in the map.</short>
		public DOM.Node Item(ulong index) {
			return (DOM.Node) interceptor.Invoke("item$", "item(unsigned long) const", typeof(DOM.Node), typeof(ulong), index);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  Retrieves a node specified by local name and namespace URI. HTML-only
		///  DOM implementations do not need to implement this method.
		/// <param> name="namespaceURI" The namespace URI of the node to retrieve.
		/// </param><param> name="localName" The local name of the node to retrieve.
		/// </param></remarks>		<return> A Node (of any type) with the specified local name and namespace
		///  URI, or null if they do not identify any node in this map.
		///      </return>
		/// 		<short>    Introduced in DOM Level 2 </short>
		public DOM.Node GetNamedItemNS(string namespaceURI, string localName) {
			return (DOM.Node) interceptor.Invoke("getNamedItemNS##", "getNamedItemNS(const DOM::DOMString&, const DOM::DOMString&) const", typeof(DOM.Node), typeof(string), namespaceURI, typeof(string), localName);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  Adds a node using its namespaceURI and localName. If a node with that
		///  namespace URI and that local name is already present in this map, it is
		///  replaced by the new one.
		///  HTML-only DOM implementations do not need to implement this method.
		/// <param> name="arg" A node to store in this map. The node will later be
		///  accessible using the value of its namespaceURI and localName attributes.
		/// </param> NO_MODIFICATION_ALLOWED_ERR: Raised if this map is readonly.
		///  INUSE_ATTRIBUTE_ERR: Raised if arg is an Attr that is already an
		///  attribute of another Element object. The DOM user must explicitly clone
		///  Attr nodes to re-use them in other elements.
		///      </remarks>		<return> If the new Node replaces an existing node the replaced Node is
		///  returned, otherwise null is returned.
		/// </return>
		/// 		<short>    Introduced in DOM Level 2 </short>
		public DOM.Node SetNamedItemNS(DOM.Node arg) {
			return (DOM.Node) interceptor.Invoke("setNamedItemNS#", "setNamedItemNS(const DOM::Node&)", typeof(DOM.Node), typeof(DOM.Node), arg);
		}
		/// <remarks>
		///  Introduced in DOM Level 2
		///  Removes a node specified by local name and namespace URI. A removed
		///  attribute may be known to have a default value when this map contains
		///  the attributes attached to an element, as returned by the attributes
		///  attribute of the Node interface. If so, an attribute immediately appears
		///  containing the default value as well as the corresponding namespace URI,
		///  local name, and prefix when applicable.
		///  HTML-only DOM implementations do not need to implement this method.
		/// <param> name="namespaceURI" The namespace URI of the node to remove.
		/// </param><param> name="localName" The local name of the node to remove.
		/// </param> NO_MODIFICATION_ALLOWED_ERR: Raised if this map is readonly.
		///      </remarks>		<return> The node removed from this map if a node with such a local name
		///  and namespace URI exists.
		/// </return>
		/// 		<short>    Introduced in DOM Level 2 </short>
		public DOM.Node RemoveNamedItemNS(string namespaceURI, string localName) {
			return (DOM.Node) interceptor.Invoke("removeNamedItemNS##", "removeNamedItemNS(const DOM::DOMString&, const DOM::DOMString&)", typeof(DOM.Node), typeof(string), namespaceURI, typeof(string), localName);
		}
		public bool IsNull() {
			return (bool) interceptor.Invoke("isNull", "isNull() const", typeof(bool));
		}
		~NamedNodeMap() {
			interceptor.Invoke("~NamedNodeMap", "~NamedNodeMap()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~NamedNodeMap", "~NamedNodeMap()", typeof(void));
		}
	}
	}
}
