//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QWebHitTestResult")]
    public class QWebHitTestResult : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QWebHitTestResult(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QWebHitTestResult), this);
        }
        public QWebHitTestResult() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QWebHitTestResult", "QWebHitTestResult()", typeof(void));
        }
        public QWebHitTestResult(QWebHitTestResult other) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QWebHitTestResult#", "QWebHitTestResult(const QWebHitTestResult&)", typeof(void), typeof(QWebHitTestResult), other);
        }
        public bool IsNull() {
            return (bool) interceptor.Invoke("isNull", "isNull() const", typeof(bool));
        }
        public QPoint Pos() {
            return (QPoint) interceptor.Invoke("pos", "pos() const", typeof(QPoint));
        }
        public QRect BoundingRect() {
            return (QRect) interceptor.Invoke("boundingRect", "boundingRect() const", typeof(QRect));
        }
        public QWebElement EnclosingBlockElement() {
            return (QWebElement) interceptor.Invoke("enclosingBlockElement", "enclosingBlockElement() const", typeof(QWebElement));
        }
        public string Title() {
            return (string) interceptor.Invoke("title", "title() const", typeof(string));
        }
        public string LinkText() {
            return (string) interceptor.Invoke("linkText", "linkText() const", typeof(string));
        }
        public QUrl LinkUrl() {
            return (QUrl) interceptor.Invoke("linkUrl", "linkUrl() const", typeof(QUrl));
        }
        public QUrl LinkTitle() {
            return (QUrl) interceptor.Invoke("linkTitle", "linkTitle() const", typeof(QUrl));
        }
        public QWebFrame LinkTargetFrame() {
            return (QWebFrame) interceptor.Invoke("linkTargetFrame", "linkTargetFrame() const", typeof(QWebFrame));
        }
        public QWebElement LinkElement() {
            return (QWebElement) interceptor.Invoke("linkElement", "linkElement() const", typeof(QWebElement));
        }
        public string AlternateText() {
            return (string) interceptor.Invoke("alternateText", "alternateText() const", typeof(string));
        }
        public QUrl ImageUrl() {
            return (QUrl) interceptor.Invoke("imageUrl", "imageUrl() const", typeof(QUrl));
        }
        public QPixmap Pixmap() {
            return (QPixmap) interceptor.Invoke("pixmap", "pixmap() const", typeof(QPixmap));
        }
        public bool IsContentEditable() {
            return (bool) interceptor.Invoke("isContentEditable", "isContentEditable() const", typeof(bool));
        }
        public bool IsContentSelected() {
            return (bool) interceptor.Invoke("isContentSelected", "isContentSelected() const", typeof(bool));
        }
        public QWebElement Element() {
            return (QWebElement) interceptor.Invoke("element", "element() const", typeof(QWebElement));
        }
        public QWebFrame Frame() {
            return (QWebFrame) interceptor.Invoke("frame", "frame() const", typeof(QWebFrame));
        }
        ~QWebHitTestResult() {
            interceptor.Invoke("~QWebHitTestResult", "~QWebHitTestResult()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QWebHitTestResult", "~QWebHitTestResult()", typeof(void));
        }
    }
}
