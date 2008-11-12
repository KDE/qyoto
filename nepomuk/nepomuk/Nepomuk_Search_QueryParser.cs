//Auto-generated by kalyptus. DO NOT EDIT.
namespace Nepomuk.Search {
    using Kimono;
    using System;
    using Qyoto;
    [SmokeClass("Nepomuk::Search::QueryParser")]
    public class QueryParser : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QueryParser(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QueryParser), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QueryParser() {
            staticInterceptor = new SmokeInvocation(typeof(QueryParser), null);
        }
        public QueryParser() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QueryParser", "QueryParser()", typeof(void));
        }
        public Nepomuk.Search.Query Parse(string query) {
            return (Nepomuk.Search.Query) interceptor.Invoke("parse$", "parse(const QString&)", typeof(Nepomuk.Search.Query), typeof(string), query);
        }
        ~QueryParser() {
            interceptor.Invoke("~QueryParser", "~QueryParser()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QueryParser", "~QueryParser()", typeof(void));
        }
        public static Nepomuk.Search.Query ParseQuery(string query) {
            return (Nepomuk.Search.Query) staticInterceptor.Invoke("parseQuery$", "parseQuery(const QString&)", typeof(Nepomuk.Search.Query), typeof(string), query);
        }
    }
}