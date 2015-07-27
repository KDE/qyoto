//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    using System.Collections.Generic;
    [SmokeClass("QSslConfiguration")]
    public class QSslConfiguration : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QSslConfiguration(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QSslConfiguration), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QSslConfiguration() {
            staticInterceptor = new SmokeInvocation(typeof(QSslConfiguration), null);
        }
        public QSslConfiguration() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSslConfiguration", "QSslConfiguration()", typeof(void));
        }
        public QSslConfiguration(QSslConfiguration other) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSslConfiguration#", "QSslConfiguration(const QSslConfiguration&)", typeof(void), typeof(QSslConfiguration), other);
        }
        public override bool Equals(object o) {
            if (!(o is QSslConfiguration)) { return false; }
            return this == (QSslConfiguration) o;
        }
        public override int GetHashCode() {
            return interceptor.GetHashCode();
        }
        public bool IsNull() {
            return (bool) interceptor.Invoke("isNull", "isNull() const", typeof(bool));
        }
        public QSsl.SslProtocol Protocol() {
            return (QSsl.SslProtocol) interceptor.Invoke("protocol", "protocol() const", typeof(QSsl.SslProtocol));
        }
        public void SetProtocol(QSsl.SslProtocol protocol) {
            interceptor.Invoke("setProtocol$", "setProtocol(QSsl::SslProtocol)", typeof(void), typeof(QSsl.SslProtocol), protocol);
        }
        public QSslSocket.PeerVerifyMode PeerVerifyMode() {
            return (QSslSocket.PeerVerifyMode) interceptor.Invoke("peerVerifyMode", "peerVerifyMode() const", typeof(QSslSocket.PeerVerifyMode));
        }
        public void SetPeerVerifyMode(QSslSocket.PeerVerifyMode mode) {
            interceptor.Invoke("setPeerVerifyMode$", "setPeerVerifyMode(QSslSocket::PeerVerifyMode)", typeof(void), typeof(QSslSocket.PeerVerifyMode), mode);
        }
        public int PeerVerifyDepth() {
            return (int) interceptor.Invoke("peerVerifyDepth", "peerVerifyDepth() const", typeof(int));
        }
        public void SetPeerVerifyDepth(int depth) {
            interceptor.Invoke("setPeerVerifyDepth$", "setPeerVerifyDepth(int)", typeof(void), typeof(int), depth);
        }
        public QSslCertificate LocalCertificate() {
            return (QSslCertificate) interceptor.Invoke("localCertificate", "localCertificate() const", typeof(QSslCertificate));
        }
        public void SetLocalCertificate(QSslCertificate certificate) {
            interceptor.Invoke("setLocalCertificate#", "setLocalCertificate(const QSslCertificate&)", typeof(void), typeof(QSslCertificate), certificate);
        }
        public QSslCertificate PeerCertificate() {
            return (QSslCertificate) interceptor.Invoke("peerCertificate", "peerCertificate() const", typeof(QSslCertificate));
        }
        public List<QSslCertificate> PeerCertificateChain() {
            return (List<QSslCertificate>) interceptor.Invoke("peerCertificateChain", "peerCertificateChain() const", typeof(List<QSslCertificate>));
        }
        public QSslCipher SessionCipher() {
            return (QSslCipher) interceptor.Invoke("sessionCipher", "sessionCipher() const", typeof(QSslCipher));
        }
        public QSslKey PrivateKey() {
            return (QSslKey) interceptor.Invoke("privateKey", "privateKey() const", typeof(QSslKey));
        }
        public void SetPrivateKey(QSslKey key) {
            interceptor.Invoke("setPrivateKey#", "setPrivateKey(const QSslKey&)", typeof(void), typeof(QSslKey), key);
        }
        public List<QSslCipher> Ciphers() {
            return (List<QSslCipher>) interceptor.Invoke("ciphers", "ciphers() const", typeof(List<QSslCipher>));
        }
        public void SetCiphers(List<QSslCipher> ciphers) {
            interceptor.Invoke("setCiphers?", "setCiphers(const QList<QSslCipher>&)", typeof(void), typeof(List<QSslCipher>), ciphers);
        }
        public List<QSslCertificate> CaCertificates() {
            return (List<QSslCertificate>) interceptor.Invoke("caCertificates", "caCertificates() const", typeof(List<QSslCertificate>));
        }
        public void SetCaCertificates(List<QSslCertificate> certificates) {
            interceptor.Invoke("setCaCertificates?", "setCaCertificates(const QList<QSslCertificate>&)", typeof(void), typeof(List<QSslCertificate>), certificates);
        }
        ~QSslConfiguration() {
            interceptor.Invoke("~QSslConfiguration", "~QSslConfiguration()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QSslConfiguration", "~QSslConfiguration()", typeof(void));
        }
        public static bool operator==(QSslConfiguration lhs, QSslConfiguration other) {
            return (bool) staticInterceptor.Invoke("operator==#", "operator==(const QSslConfiguration&) const", typeof(bool), typeof(QSslConfiguration), lhs, typeof(QSslConfiguration), other);
        }
        public static bool operator!=(QSslConfiguration lhs, QSslConfiguration other) {
            return !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QSslConfiguration&) const", typeof(bool), typeof(QSslConfiguration), lhs, typeof(QSslConfiguration), other);
        }
        public static QSslConfiguration DefaultConfiguration() {
            return (QSslConfiguration) staticInterceptor.Invoke("defaultConfiguration", "defaultConfiguration()", typeof(QSslConfiguration));
        }
        public static void SetDefaultConfiguration(QSslConfiguration configuration) {
            staticInterceptor.Invoke("setDefaultConfiguration#", "setDefaultConfiguration(const QSslConfiguration&)", typeof(void), typeof(QSslConfiguration), configuration);
        }
    }
}