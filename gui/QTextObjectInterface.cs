//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QTextObjectInterface")]
    public abstract class QTextObjectInterface : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QTextObjectInterface(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QTextObjectInterface), this);
        }
        [SmokeMethod("intrinsicSize(QTextDocument*, int, const QTextFormat&)")]
        public abstract QSizeF IntrinsicSize(QTextDocument doc, int posInDocument, QTextFormat format);
        [SmokeMethod("drawObject(QPainter*, const QRectF&, QTextDocument*, int, const QTextFormat&)")]
        public abstract void DrawObject(QPainter painter, QRectF rect, QTextDocument doc, int posInDocument, QTextFormat format);
        public QTextObjectInterface() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QTextObjectInterface", "QTextObjectInterface()", typeof(void));
        }
    }
}