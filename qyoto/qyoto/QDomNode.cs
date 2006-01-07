//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QDomNode : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QDomNode(Type dummy) {}
		interface IQDomNodeProxy {
			bool op_equals(QDomNode lhs, QDomNode arg1);
		}

		protected void CreateQDomNodeProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDomNode), this);
			_interceptor = (QDomNode) realProxy.GetTransparentProxy();
		}
		private QDomNode ProxyQDomNode() {
			return (QDomNode) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDomNode() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDomNodeProxy), null);
			_staticInterceptor = (IQDomNodeProxy) realProxy.GetTransparentProxy();
		}
		private static IQDomNodeProxy StaticQDomNode() {
			return (IQDomNodeProxy) _staticInterceptor;
		}

		enum E_NodeType {
			ElementNode = 1,
			AttributeNode = 2,
			TextNode = 3,
			CDATASectionNode = 4,
			EntityReferenceNode = 5,
			EntityNode = 6,
			ProcessingInstructionNode = 7,
			CommentNode = 8,
			DocumentNode = 9,
			DocumentTypeNode = 10,
			DocumentFragmentNode = 11,
			NotationNode = 12,
			BaseNode = 21,
			CharacterDataNode = 22,
		}
		public QDomNode() : this((Type) null) {
			CreateQDomNodeProxy();
			NewQDomNode();
		}
		private void NewQDomNode() {
			ProxyQDomNode().NewQDomNode();
		}
		public QDomNode(QDomNode arg1) : this((Type) null) {
			CreateQDomNodeProxy();
			NewQDomNode(arg1);
		}
		private void NewQDomNode(QDomNode arg1) {
			ProxyQDomNode().NewQDomNode(arg1);
		}
		public static bool operator==(QDomNode lhs, QDomNode arg1) {
			return StaticQDomNode().op_equals(lhs,arg1);
		}
		public static bool operator!=(QDomNode lhs, QDomNode arg1) {
			return !StaticQDomNode().op_equals(lhs,arg1);
		}
		public override bool Equals(object o) {
			if (!(o is QDomNode)) { return false; }
			return this == (QDomNode) o;
		}
		public override int GetHashCode() {
			return ProxyQDomNode().GetHashCode();
		}
		public QDomNode InsertBefore(QDomNode newChild, QDomNode refChild) {
			return ProxyQDomNode().InsertBefore(newChild,refChild);
		}
		public QDomNode InsertAfter(QDomNode newChild, QDomNode refChild) {
			return ProxyQDomNode().InsertAfter(newChild,refChild);
		}
		public QDomNode ReplaceChild(QDomNode newChild, QDomNode oldChild) {
			return ProxyQDomNode().ReplaceChild(newChild,oldChild);
		}
		public QDomNode RemoveChild(QDomNode oldChild) {
			return ProxyQDomNode().RemoveChild(oldChild);
		}
		public QDomNode AppendChild(QDomNode newChild) {
			return ProxyQDomNode().AppendChild(newChild);
		}
		public bool HasChildNodes() {
			return ProxyQDomNode().HasChildNodes();
		}
		public QDomNode CloneNode(bool deep) {
			return ProxyQDomNode().CloneNode(deep);
		}
		public QDomNode CloneNode() {
			return ProxyQDomNode().CloneNode();
		}
		public void Normalize() {
			ProxyQDomNode().Normalize();
		}
		public bool IsSupported(string feature, string version) {
			return ProxyQDomNode().IsSupported(feature,version);
		}
		public string NodeName() {
			return ProxyQDomNode().NodeName();
		}
		public int NodeType() {
			return ProxyQDomNode().NodeType();
		}
		public QDomNode ParentNode() {
			return ProxyQDomNode().ParentNode();
		}
		public ArrayList ChildNodes() {
			return ProxyQDomNode().ChildNodes();
		}
		public QDomNode FirstChild() {
			return ProxyQDomNode().FirstChild();
		}
		public QDomNode LastChild() {
			return ProxyQDomNode().LastChild();
		}
		public QDomNode PreviousSibling() {
			return ProxyQDomNode().PreviousSibling();
		}
		public QDomNode NextSibling() {
			return ProxyQDomNode().NextSibling();
		}
		public QDomNamedNodeMap Attributes() {
			return ProxyQDomNode().Attributes();
		}
		public QDomDocument OwnerDocument() {
			return ProxyQDomNode().OwnerDocument();
		}
		public string NamespaceURI() {
			return ProxyQDomNode().NamespaceURI();
		}
		public string LocalName() {
			return ProxyQDomNode().LocalName();
		}
		public bool HasAttributes() {
			return ProxyQDomNode().HasAttributes();
		}
		public string NodeValue() {
			return ProxyQDomNode().NodeValue();
		}
		public void SetNodeValue(string arg1) {
			ProxyQDomNode().SetNodeValue(arg1);
		}
		public string Prefix() {
			return ProxyQDomNode().Prefix();
		}
		public void SetPrefix(string pre) {
			ProxyQDomNode().SetPrefix(pre);
		}
		public bool IsAttr() {
			return ProxyQDomNode().IsAttr();
		}
		public bool IsCDATASection() {
			return ProxyQDomNode().IsCDATASection();
		}
		public bool IsDocumentFragment() {
			return ProxyQDomNode().IsDocumentFragment();
		}
		public bool IsDocument() {
			return ProxyQDomNode().IsDocument();
		}
		public bool IsDocumentType() {
			return ProxyQDomNode().IsDocumentType();
		}
		public bool IsElement() {
			return ProxyQDomNode().IsElement();
		}
		public bool IsEntityReference() {
			return ProxyQDomNode().IsEntityReference();
		}
		public bool IsText() {
			return ProxyQDomNode().IsText();
		}
		public bool IsEntity() {
			return ProxyQDomNode().IsEntity();
		}
		public bool IsNotation() {
			return ProxyQDomNode().IsNotation();
		}
		public bool IsProcessingInstruction() {
			return ProxyQDomNode().IsProcessingInstruction();
		}
		public bool IsCharacterData() {
			return ProxyQDomNode().IsCharacterData();
		}
		public bool IsComment() {
			return ProxyQDomNode().IsComment();
		}
		///<remarks>
		/// Shortcut to avoid dealing with QDomArrayList
		/// all the time.
		///     </remarks>		<short>    Shortcut to avoid dealing with QDomNodeList  all the time.</short>
		public QDomNode NamedItem(string name) {
			return ProxyQDomNode().NamedItem(name);
		}
		public bool IsNull() {
			return ProxyQDomNode().IsNull();
		}
		public void Clear() {
			ProxyQDomNode().Clear();
		}
		public QDomAttr ToAttr() {
			return ProxyQDomNode().ToAttr();
		}
		public QDomCDATASection ToCDATASection() {
			return ProxyQDomNode().ToCDATASection();
		}
		public QDomDocumentFragment ToDocumentFragment() {
			return ProxyQDomNode().ToDocumentFragment();
		}
		public QDomDocument ToDocument() {
			return ProxyQDomNode().ToDocument();
		}
		public QDomDocumentType ToDocumentType() {
			return ProxyQDomNode().ToDocumentType();
		}
		public QDomElement ToElement() {
			return ProxyQDomNode().ToElement();
		}
		public QDomEntityReference ToEntityReference() {
			return ProxyQDomNode().ToEntityReference();
		}
		public QDomText ToText() {
			return ProxyQDomNode().ToText();
		}
		public QDomEntity ToEntity() {
			return ProxyQDomNode().ToEntity();
		}
		public QDomNotation ToNotation() {
			return ProxyQDomNode().ToNotation();
		}
		public QDomProcessingInstruction ToProcessingInstruction() {
			return ProxyQDomNode().ToProcessingInstruction();
		}
		public QDomCharacterData ToCharacterData() {
			return ProxyQDomNode().ToCharacterData();
		}
		public QDomComment ToComment() {
			return ProxyQDomNode().ToComment();
		}
		public void Save(QTextStream arg1, int arg2) {
			ProxyQDomNode().Save(arg1,arg2);
		}
		public QDomElement FirstChildElement(string tagName) {
			return ProxyQDomNode().FirstChildElement(tagName);
		}
		public QDomElement FirstChildElement() {
			return ProxyQDomNode().FirstChildElement();
		}
		public QDomElement LastChildElement(string tagName) {
			return ProxyQDomNode().LastChildElement(tagName);
		}
		public QDomElement LastChildElement() {
			return ProxyQDomNode().LastChildElement();
		}
		public QDomElement PreviousSiblingElement(string tagName) {
			return ProxyQDomNode().PreviousSiblingElement(tagName);
		}
		public QDomElement PreviousSiblingElement() {
			return ProxyQDomNode().PreviousSiblingElement();
		}
		public QDomElement NextSiblingElement(string taName) {
			return ProxyQDomNode().NextSiblingElement(taName);
		}
		public QDomElement NextSiblingElement() {
			return ProxyQDomNode().NextSiblingElement();
		}
		// QDomNode* QDomNode(QDomNodePrivate* arg1); >>>> NOT CONVERTED
		~QDomNode() {
			ProxyQDomNode().Dispose();
		}
		public void Dispose() {
			ProxyQDomNode().Dispose();
		}
	}
}