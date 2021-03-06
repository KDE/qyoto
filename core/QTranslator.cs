//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QTranslator")]
    public class QTranslator : QObject, IDisposable {
        protected QTranslator(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QTranslator), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QTranslator() {
            staticInterceptor = new SmokeInvocation(typeof(QTranslator), null);
        }
        public QTranslator(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QTranslator#", "QTranslator(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public QTranslator() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QTranslator", "QTranslator()", typeof(void));
        }
        [SmokeMethod("translate(const char*, const char*, const char*) const")]
        public virtual string Translate(string context, string sourceText, string disambiguation) {
            return (string) interceptor.Invoke("translate$$$", "translate(const char*, const char*, const char*) const", typeof(string), typeof(string), context, typeof(string), sourceText, typeof(string), disambiguation);
        }
        [SmokeMethod("translate(const char*, const char*) const")]
        public virtual string Translate(string context, string sourceText) {
            return (string) interceptor.Invoke("translate$$", "translate(const char*, const char*) const", typeof(string), typeof(string), context, typeof(string), sourceText);
        }
        public string Translate(string context, string sourceText, string disambiguation, int n) {
            return (string) interceptor.Invoke("translate$$$$", "translate(const char*, const char*, const char*, int) const", typeof(string), typeof(string), context, typeof(string), sourceText, typeof(string), disambiguation, typeof(int), n);
        }
        [SmokeMethod("isEmpty() const")]
        public virtual bool IsEmpty() {
            return (bool) interceptor.Invoke("isEmpty", "isEmpty() const", typeof(bool));
        }
        public bool Load(string filename, string directory, string search_delimiters, string suffix) {
            return (bool) interceptor.Invoke("load$$$$", "load(const QString&, const QString&, const QString&, const QString&)", typeof(bool), typeof(string), filename, typeof(string), directory, typeof(string), search_delimiters, typeof(string), suffix);
        }
        public bool Load(string filename, string directory, string search_delimiters) {
            return (bool) interceptor.Invoke("load$$$", "load(const QString&, const QString&, const QString&)", typeof(bool), typeof(string), filename, typeof(string), directory, typeof(string), search_delimiters);
        }
        public bool Load(string filename, string directory) {
            return (bool) interceptor.Invoke("load$$", "load(const QString&, const QString&)", typeof(bool), typeof(string), filename, typeof(string), directory);
        }
        public bool Load(string filename) {
            return (bool) interceptor.Invoke("load$", "load(const QString&)", typeof(bool), typeof(string), filename);
        }
        public bool Load(Pointer<byte> data, int len) {
            return (bool) interceptor.Invoke("load$$", "load(const unsigned char*, int)", typeof(bool), typeof(Pointer<byte>), data, typeof(int), len);
        }
        ~QTranslator() {
            interceptor.Invoke("~QTranslator", "~QTranslator()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QTranslator", "~QTranslator()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQTranslatorSignals Emit {
            get { return (IQTranslatorSignals) Q_EMIT; }
        }
    }

    public interface IQTranslatorSignals : IQObjectSignals {
    }
}
