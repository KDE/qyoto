namespace Qyoto {
    using System;
    
    [SmokeClass("QNetworkReply")]
    internal class QNetworkReplyInternal : QNetworkReply {
        protected QNetworkReplyInternal(Type dummy) : base((Type) null) {}
        public override void Abort() {
            interceptor.Invoke("abort", "abort()", typeof(void));
        }
        protected override long ReadData(Pointer<sbyte> data, long maxsize) {
            return 0;
        }
    }
}
