//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QChildEvent")]
    public class QChildEvent : QEvent, IDisposable {
        protected QChildEvent(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QChildEvent), this);
        }
        public QChildEvent(QEvent.TypeOf type, QObject child) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QChildEvent$#", "QChildEvent(QEvent::Type, QObject*)", typeof(void), typeof(QEvent.TypeOf), type, typeof(QObject), child);
        }
        public QObject Child() {
            return (QObject) interceptor.Invoke("child", "child() const", typeof(QObject));
        }
        public bool Added() {
            return (bool) interceptor.Invoke("added", "added() const", typeof(bool));
        }
        public bool Polished() {
            return (bool) interceptor.Invoke("polished", "polished() const", typeof(bool));
        }
        public bool Removed() {
            return (bool) interceptor.Invoke("removed", "removed() const", typeof(bool));
        }
        ~QChildEvent() {
            interceptor.Invoke("~QChildEvent", "~QChildEvent()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QChildEvent", "~QChildEvent()", typeof(void));
        }
    }
}
