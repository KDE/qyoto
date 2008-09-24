//Auto-generated by kalyptus. DO NOT EDIT.
namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    /// <remarks>
    ///  Namespace for the KDE Text Editor Interfaces.
    ///  These interfaces provide easy access to editor parts for the
    ///  applications embedding them. At the moment they are at least
    ///  supported by both the Kate Part and the Yzis Part.
    ///  </remarks>        <short>    Namespace for the KDE Text Editor Interfaces.</short>
    [SmokeClass("KTextEditor")]
    public class Global {
        private static SmokeInvocation staticInterceptor = null;
        static Global() {
            staticInterceptor = new SmokeInvocation(typeof(Global), null);
        }
        /// <remarks>
        ///  Helper function for the EditorChooser.
        ///  Usually you do not have to use this function. Instead, use
        ///  KTextEditor.EditorChooser.Editor().
        ///  \param libname library name, for example "katepart"
        ///  \return the Editor object on success, otherwise NULL
        ///  \see KTextEditor.EditorChooser.Editor()
        ///  </remarks>        <short>    Helper function for the EditorChooser.</short>
        public static KTextEditor.Editor Editor(string libname) {
            return (KTextEditor.Editor) staticInterceptor.Invoke("editor$", "editor(const char*)", typeof(KTextEditor.Editor), typeof(string), libname);
        }
        /// <remarks>
        ///  Create a plugin represented by <pre>service</pre> with parent object <pre>parent</pre>.
        ///  To get the KService object you usually use KServiceTypeTrader. Example
        ///  <pre>
        ///  KService.List list = KServiceTypeTrader.Self().Query("KTextEditor/Plugin");
        ///  foreach(const KService.Ptr &service, list) {
        ///    // do something with service
        ///  }
        ///  </pre>
        ///  \return the plugin or NULL if it could not be loaded
        ///  </remarks>        <short>    Create a plugin represented by \p service with parent object \p parent.</short>
        public static KTextEditor.Plugin CreatePlugin(KService service, QObject parent) {
            return (KTextEditor.Plugin) staticInterceptor.Invoke("createPlugin?#", "createPlugin(KSharedPtr<KService>, QObject*)", typeof(KTextEditor.Plugin), typeof(KService), service, typeof(QObject), parent);
        }
    }
}
