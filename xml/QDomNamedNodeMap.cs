//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QDomNamedNodeMap")]
    public class QDomNamedNodeMap : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QDomNamedNodeMap(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QDomNamedNodeMap), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QDomNamedNodeMap() {
            staticInterceptor = new SmokeInvocation(typeof(QDomNamedNodeMap), null);
        }
        public QDomNamedNodeMap() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDomNamedNodeMap", "QDomNamedNodeMap()", typeof(void));
        }
        public QDomNamedNodeMap(QDomNamedNodeMap arg1) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDomNamedNodeMap#", "QDomNamedNodeMap(const QDomNamedNodeMap&)", typeof(void), typeof(QDomNamedNodeMap), arg1);
        }
        public override bool Equals(object o) {
            if (!(o is QDomNamedNodeMap)) { return false; }
            return this == (QDomNamedNodeMap) o;
        }
        public override int GetHashCode() {
            return interceptor.GetHashCode();
        }
        public QDomNode NamedItem(string name) {
            return (QDomNode) interceptor.Invoke("namedItem$", "namedItem(const QString&) const", typeof(QDomNode), typeof(string), name);
        }
        public QDomNode SetNamedItem(QDomNode newNode) {
            return (QDomNode) interceptor.Invoke("setNamedItem#", "setNamedItem(const QDomNode&)", typeof(QDomNode), typeof(QDomNode), newNode);
        }
        public QDomNode RemoveNamedItem(string name) {
            return (QDomNode) interceptor.Invoke("removeNamedItem$", "removeNamedItem(const QString&)", typeof(QDomNode), typeof(string), name);
        }
        public QDomNode Item(int index) {
            return (QDomNode) interceptor.Invoke("item$", "item(int) const", typeof(QDomNode), typeof(int), index);
        }
        public QDomNode NamedItemNS(string nsURI, string localName) {
            return (QDomNode) interceptor.Invoke("namedItemNS$$", "namedItemNS(const QString&, const QString&) const", typeof(QDomNode), typeof(string), nsURI, typeof(string), localName);
        }
        public QDomNode SetNamedItemNS(QDomNode newNode) {
            return (QDomNode) interceptor.Invoke("setNamedItemNS#", "setNamedItemNS(const QDomNode&)", typeof(QDomNode), typeof(QDomNode), newNode);
        }
        public QDomNode RemoveNamedItemNS(string nsURI, string localName) {
            return (QDomNode) interceptor.Invoke("removeNamedItemNS$$", "removeNamedItemNS(const QString&, const QString&)", typeof(QDomNode), typeof(string), nsURI, typeof(string), localName);
        }
        public uint Length() {
            return (uint) interceptor.Invoke("length", "length() const", typeof(uint));
        }
        public int Count() {
            return (int) interceptor.Invoke("count", "count() const", typeof(int));
        }
        public int Size() {
            return (int) interceptor.Invoke("size", "size() const", typeof(int));
        }
        public bool IsEmpty() {
            return (bool) interceptor.Invoke("isEmpty", "isEmpty() const", typeof(bool));
        }
        public bool Contains(string name) {
            return (bool) interceptor.Invoke("contains$", "contains(const QString&) const", typeof(bool), typeof(string), name);
        }
        ~QDomNamedNodeMap() {
            interceptor.Invoke("~QDomNamedNodeMap", "~QDomNamedNodeMap()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QDomNamedNodeMap", "~QDomNamedNodeMap()", typeof(void));
        }
        public static bool operator==(QDomNamedNodeMap lhs, QDomNamedNodeMap arg1) {
            return (bool) staticInterceptor.Invoke("operator==#", "operator==(const QDomNamedNodeMap&) const", typeof(bool), typeof(QDomNamedNodeMap), lhs, typeof(QDomNamedNodeMap), arg1);
        }
        public static bool operator!=(QDomNamedNodeMap lhs, QDomNamedNodeMap arg1) {
            return !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QDomNamedNodeMap&) const", typeof(bool), typeof(QDomNamedNodeMap), lhs, typeof(QDomNamedNodeMap), arg1);
        }
    }
}