//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QHttpRequestHeader")]
    public class QHttpRequestHeader : QHttpHeader, IDisposable {
        protected QHttpRequestHeader(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QHttpRequestHeader), this);
        }
        public QHttpRequestHeader() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader", "QHttpRequestHeader()", typeof(void));
        }
        public QHttpRequestHeader(string method, string path, int majorVer, int minorVer) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader$$$$", "QHttpRequestHeader(const QString&, const QString&, int, int)", typeof(void), typeof(string), method, typeof(string), path, typeof(int), majorVer, typeof(int), minorVer);
        }
        public QHttpRequestHeader(string method, string path, int majorVer) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader$$$", "QHttpRequestHeader(const QString&, const QString&, int)", typeof(void), typeof(string), method, typeof(string), path, typeof(int), majorVer);
        }
        public QHttpRequestHeader(string method, string path) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader$$", "QHttpRequestHeader(const QString&, const QString&)", typeof(void), typeof(string), method, typeof(string), path);
        }
        public QHttpRequestHeader(QHttpRequestHeader header) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader#", "QHttpRequestHeader(const QHttpRequestHeader&)", typeof(void), typeof(QHttpRequestHeader), header);
        }
        public QHttpRequestHeader(string str) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QHttpRequestHeader$", "QHttpRequestHeader(const QString&)", typeof(void), typeof(string), str);
        }
        public void SetRequest(string method, string path, int majorVer, int minorVer) {
            interceptor.Invoke("setRequest$$$$", "setRequest(const QString&, const QString&, int, int)", typeof(void), typeof(string), method, typeof(string), path, typeof(int), majorVer, typeof(int), minorVer);
        }
        public void SetRequest(string method, string path, int majorVer) {
            interceptor.Invoke("setRequest$$$", "setRequest(const QString&, const QString&, int)", typeof(void), typeof(string), method, typeof(string), path, typeof(int), majorVer);
        }
        public void SetRequest(string method, string path) {
            interceptor.Invoke("setRequest$$", "setRequest(const QString&, const QString&)", typeof(void), typeof(string), method, typeof(string), path);
        }
        public string Method() {
            return (string) interceptor.Invoke("method", "method() const", typeof(string));
        }
        public string Path() {
            return (string) interceptor.Invoke("path", "path() const", typeof(string));
        }
        [SmokeMethod("majorVersion() const")]
        public override int MajorVersion() {
            return (int) interceptor.Invoke("majorVersion", "majorVersion() const", typeof(int));
        }
        [SmokeMethod("minorVersion() const")]
        public override int MinorVersion() {
            return (int) interceptor.Invoke("minorVersion", "minorVersion() const", typeof(int));
        }
        [SmokeMethod("toString() const")]
        public new string ToString() {
            return (string) interceptor.Invoke("toString", "toString() const", typeof(string));
        }
        [SmokeMethod("parseLine(const QString&, int)")]
        protected override bool ParseLine(string line, int number) {
            return (bool) interceptor.Invoke("parseLine$$", "parseLine(const QString&, int)", typeof(bool), typeof(string), line, typeof(int), number);
        }
        ~QHttpRequestHeader() {
            interceptor.Invoke("~QHttpRequestHeader", "~QHttpRequestHeader()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QHttpRequestHeader", "~QHttpRequestHeader()", typeof(void));
        }
    }
}
