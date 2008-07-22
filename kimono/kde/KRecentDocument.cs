//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    using System.Collections.Generic;
    /// <remarks>
    ///  Manage the "Recent Document Menu" entries displayed by
    ///  applications such as Kicker and Konqueror.
    ///  These entries are automatically generated .desktop files pointing
    ///  to the current application and document.  You should call the
    ///  static add() method whenever the user opens or saves a new
    ///  document if you want it to show up in the menu.
    ///  You don't have to worry about this if you are using any
    ///  KFileDialog derived class to open and save documents, as it
    ///  already calls this class.  User defined limits on the maximum
    ///  number of documents to save, etc... are all automatically handled.
    /// </remarks>        <author> Daniel M. Duley <mosfet@kde.org>
    ///  </author>
    ///         <short>    Manage the "Recent Document Menu" entries displayed by  applications such as Kicker and Konqueror.</short>
    [SmokeClass("KRecentDocument")]
    public class KRecentDocument : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected KRecentDocument(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KRecentDocument), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static KRecentDocument() {
            staticInterceptor = new SmokeInvocation(typeof(KRecentDocument), null);
        }
        public KRecentDocument() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KRecentDocument", "KRecentDocument()", typeof(void));
        }
        ~KRecentDocument() {
            interceptor.Invoke("~KRecentDocument", "~KRecentDocument()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~KRecentDocument", "~KRecentDocument()", typeof(void));
        }
        /// <remarks>
        ///  Return a list of absolute paths to recent document .desktop files,
        ///  sorted by date.
        ///      </remarks>        <short>   </short>
        public static List<string> RecentDocuments() {
            return (List<string>) staticInterceptor.Invoke("recentDocuments", "recentDocuments()", typeof(List<string>));
        }
        /// <remarks>
        ///  Add a new item to the Recent Document menu.
        /// <param> name="url" The url to add.
        ///      </param></remarks>        <short>    Add a new item to the Recent Document menu.</short>
        public static void Add(KUrl url) {
            staticInterceptor.Invoke("add#", "add(const KUrl&)", typeof(void), typeof(KUrl), url);
        }
        /// <remarks>
        ///  Add a new item to the Recent Document menu, specifying the application to open it with.
        ///  The above add() method uses KGlobal.MainComponent().componentName() for the app name,
        ///  which isn't always flexible enough.
        ///  This method is used when an application launches another one to open a document.
        /// <param> name="url" The url to add.
        /// </param><param> name="desktopEntryName" The desktopEntryName of the service to use for opening this document.
        ///      </param></remarks>        <short>    Add a new item to the Recent Document menu, specifying the application to open it with.</short>
        public static void Add(KUrl url, string desktopEntryName) {
            staticInterceptor.Invoke("add#$", "add(const KUrl&, const QString&)", typeof(void), typeof(KUrl), url, typeof(string), desktopEntryName);
        }
        /// <remarks>
        ///  Add a new item to the Recent Document menu. Calls add( url ).
        /// <param> name="documentStr" The full path to the document or URL to add.
        /// </param><param> name="isURL" Set to <code>true</code> if <code>documentStr</code> is an URL and not a local file path.
        ///      </param></remarks>        <short>   </short>
        public static void Add(string documentStr, bool isURL) {
            staticInterceptor.Invoke("add$$", "add(const QString&, bool)", typeof(void), typeof(string), documentStr, typeof(bool), isURL);
        }
        public static void Add(string documentStr) {
            staticInterceptor.Invoke("add$", "add(const QString&)", typeof(void), typeof(string), documentStr);
        }
        /// <remarks>
        ///  Clear the recent document menu of all entries.
        ///      </remarks>        <short>    Clear the recent document menu of all entries.</short>
        public static void Clear() {
            staticInterceptor.Invoke("clear", "clear()", typeof(void));
        }
        /// <remarks>
        ///  Returns the maximum amount of recent document entries allowed.
        ///      </remarks>        <short>    Returns the maximum amount of recent document entries allowed.</short>
        public static int MaximumItems() {
            return (int) staticInterceptor.Invoke("maximumItems", "maximumItems()", typeof(int));
        }
        /// <remarks>
        ///  Returns the path to the directory where recent document .desktop files
        ///  are stored.
        ///      </remarks>        <short>    Returns the path to the directory where recent document .</short>
        public static string RecentDocumentDirectory() {
            return (string) staticInterceptor.Invoke("recentDocumentDirectory", "recentDocumentDirectory()", typeof(string));
        }
    }
}
