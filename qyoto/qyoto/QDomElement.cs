//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QDomElement : QDomNode, IDisposable {
 		protected QDomElement(Type dummy) : base((Type) null) {}
		interface IQDomElementProxy {
		}

		protected void CreateQDomElementProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDomElement), this);
			_interceptor = (QDomElement) realProxy.GetTransparentProxy();
		}
		private QDomElement ProxyQDomElement() {
			return (QDomElement) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDomElement() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDomElementProxy), null);
			_staticInterceptor = (IQDomElementProxy) realProxy.GetTransparentProxy();
		}
		private static IQDomElementProxy StaticQDomElement() {
			return (IQDomElementProxy) _staticInterceptor;
		}

		public QDomElement() : this((Type) null) {
			CreateQDomElementProxy();
			NewQDomElement();
		}
		private void NewQDomElement() {
			ProxyQDomElement().NewQDomElement();
		}
		public QDomElement(QDomElement x) : this((Type) null) {
			CreateQDomElementProxy();
			NewQDomElement(x);
		}
		private void NewQDomElement(QDomElement x) {
			ProxyQDomElement().NewQDomElement(x);
		}
		public string Attribute(string name, string defValue) {
			return ProxyQDomElement().Attribute(name,defValue);
		}
		public string Attribute(string name) {
			return ProxyQDomElement().Attribute(name);
		}
		public void SetAttribute(string name, string value) {
			ProxyQDomElement().SetAttribute(name,value);
		}
		// void setAttribute(const QString& arg1,qlonglong arg2); >>>> NOT CONVERTED
		// void setAttribute(const QString& arg1,qulonglong arg2); >>>> NOT CONVERTED
		public void SetAttribute(string name, int value) {
			ProxyQDomElement().SetAttribute(name,value);
		}
		public void SetAttribute(string name, uint value) {
			ProxyQDomElement().SetAttribute(name,value);
		}
		public void SetAttribute(string name, double value) {
			ProxyQDomElement().SetAttribute(name,value);
		}
		public void RemoveAttribute(string name) {
			ProxyQDomElement().RemoveAttribute(name);
		}
		public QDomAttr AttributeNode(string name) {
			return ProxyQDomElement().AttributeNode(name);
		}
		public QDomAttr SetAttributeNode(QDomAttr newAttr) {
			return ProxyQDomElement().SetAttributeNode(newAttr);
		}
		public QDomAttr RemoveAttributeNode(QDomAttr oldAttr) {
			return ProxyQDomElement().RemoveAttributeNode(oldAttr);
		}
		public ArrayList ElementsByTagName(string tagname) {
			return ProxyQDomElement().ElementsByTagName(tagname);
		}
		public bool HasAttribute(string name) {
			return ProxyQDomElement().HasAttribute(name);
		}
		public string AttributeNS(string nsURI, string localName, string defValue) {
			return ProxyQDomElement().AttributeNS(nsURI,localName,defValue);
		}
		public string AttributeNS(string nsURI, string localName) {
			return ProxyQDomElement().AttributeNS(nsURI,localName);
		}
		public void SetAttributeNS(string nsURI, string qName, string value) {
			ProxyQDomElement().SetAttributeNS(nsURI,qName,value);
		}
		public void SetAttributeNS(string nsURI, string qName, int value) {
			ProxyQDomElement().SetAttributeNS(nsURI,qName,value);
		}
		public void SetAttributeNS(string nsURI, string qName, uint value) {
			ProxyQDomElement().SetAttributeNS(nsURI,qName,value);
		}
		// void setAttributeNS(const QString arg1,const QString& arg2,qlonglong arg3); >>>> NOT CONVERTED
		// void setAttributeNS(const QString arg1,const QString& arg2,qulonglong arg3); >>>> NOT CONVERTED
		public void SetAttributeNS(string nsURI, string qName, double value) {
			ProxyQDomElement().SetAttributeNS(nsURI,qName,value);
		}
		public void RemoveAttributeNS(string nsURI, string localName) {
			ProxyQDomElement().RemoveAttributeNS(nsURI,localName);
		}
		public QDomAttr AttributeNodeNS(string nsURI, string localName) {
			return ProxyQDomElement().AttributeNodeNS(nsURI,localName);
		}
		public QDomAttr SetAttributeNodeNS(QDomAttr newAttr) {
			return ProxyQDomElement().SetAttributeNodeNS(newAttr);
		}
		public ArrayList ElementsByTagNameNS(string nsURI, string localName) {
			return ProxyQDomElement().ElementsByTagNameNS(nsURI,localName);
		}
		public bool HasAttributeNS(string nsURI, string localName) {
			return ProxyQDomElement().HasAttributeNS(nsURI,localName);
		}
		public string TagName() {
			return ProxyQDomElement().TagName();
		}
		public void SetTagName(string name) {
			ProxyQDomElement().SetTagName(name);
		}
		public new QDomNamedNodeMap Attributes() {
			return ProxyQDomElement().Attributes();
		}
		public new int NodeType() {
			return ProxyQDomElement().NodeType();
		}
		public string Text() {
			return ProxyQDomElement().Text();
		}
		~QDomElement() {
			ProxyQDomElement().Dispose();
		}
		public void Dispose() {
			ProxyQDomElement().Dispose();
		}
	}
}