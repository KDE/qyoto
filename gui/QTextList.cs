//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QTextList")]
    public class QTextList : QTextBlockGroup, IDisposable {
        protected QTextList(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QTextList), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QTextList() {
            staticInterceptor = new SmokeInvocation(typeof(QTextList), null);
        }
        public QTextList(QTextDocument doc) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QTextList#", "QTextList(QTextDocument*)", typeof(void), typeof(QTextDocument), doc);
        }
        public int Count() {
            return (int) interceptor.Invoke("count", "count() const", typeof(int));
        }
        public bool IsEmpty() {
            return (bool) interceptor.Invoke("isEmpty", "isEmpty() const", typeof(bool));
        }
        public QTextBlock Item(int i) {
            return (QTextBlock) interceptor.Invoke("item$", "item(int) const", typeof(QTextBlock), typeof(int), i);
        }
        public int ItemNumber(QTextBlock arg1) {
            return (int) interceptor.Invoke("itemNumber#", "itemNumber(const QTextBlock&) const", typeof(int), typeof(QTextBlock), arg1);
        }
        public string ItemText(QTextBlock arg1) {
            return (string) interceptor.Invoke("itemText#", "itemText(const QTextBlock&) const", typeof(string), typeof(QTextBlock), arg1);
        }
        public void RemoveItem(int i) {
            interceptor.Invoke("removeItem$", "removeItem(int)", typeof(void), typeof(int), i);
        }
        public void Remove(QTextBlock arg1) {
            interceptor.Invoke("remove#", "remove(const QTextBlock&)", typeof(void), typeof(QTextBlock), arg1);
        }
        public void Add(QTextBlock block) {
            interceptor.Invoke("add#", "add(const QTextBlock&)", typeof(void), typeof(QTextBlock), block);
        }
        public void SetFormat(QTextListFormat format) {
            interceptor.Invoke("setFormat#", "setFormat(const QTextListFormat&)", typeof(void), typeof(QTextListFormat), format);
        }
        public new QTextListFormat Format() {
            return (QTextListFormat) interceptor.Invoke("format", "format() const", typeof(QTextListFormat));
        }
        ~QTextList() {
            interceptor.Invoke("~QTextList", "~QTextList()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QTextList", "~QTextList()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQTextListSignals Emit {
            get { return (IQTextListSignals) Q_EMIT; }
        }
    }

    public interface IQTextListSignals : IQTextBlockGroupSignals {
    }
}