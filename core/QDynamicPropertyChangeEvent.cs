//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QDynamicPropertyChangeEvent")]
    public class QDynamicPropertyChangeEvent : QEvent, IDisposable {
        protected QDynamicPropertyChangeEvent(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QDynamicPropertyChangeEvent), this);
        }
        public QDynamicPropertyChangeEvent(QByteArray name) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QDynamicPropertyChangeEvent#", "QDynamicPropertyChangeEvent(const QByteArray&)", typeof(void), typeof(QByteArray), name);
        }
        public QByteArray PropertyName() {
            return (QByteArray) interceptor.Invoke("propertyName", "propertyName() const", typeof(QByteArray));
        }
        ~QDynamicPropertyChangeEvent() {
            interceptor.Invoke("~QDynamicPropertyChangeEvent", "~QDynamicPropertyChangeEvent()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QDynamicPropertyChangeEvent", "~QDynamicPropertyChangeEvent()", typeof(void));
        }
    }
}
