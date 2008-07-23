//Auto-generated by kalyptus. DO NOT EDIT.
namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    /// <remarks>
    ///  \brief Variable/Modeline extension interface for the Document.
    ///  \ingroup kte_group_doc_extensions
    ///  \section variface_intro Introduction
    ///  The VariableInterface is designed to provide access to so called
    ///  "document variables" (also called modelines), for example variables
    ///  defined in files like "kate: variable value;" or the emacs style
    ///  "-*- variable: value -*-".
    ///  The idea is to allow KTextEditor plugins and applications to use document
    ///  variables. A document implementing this interface should return values
    ///  for variables that it does not otherwise know how to use, since they
    ///  could be of interest for plugins. A Document implementing this interface
    ///  must emit the signal variableChanged() whenever a variable/value pair was
    ///  set, changed or removed.
    ///  <b>Note:<> Implementations should check the document variables whenever the
    ///        document was saved or loaded.
    ///  \section variface_access Accessing the VariableInterface
    ///  The VariableInterface is an extension interface for a
    ///  Document, i.e. the Document inherits the interface \e provided that the
    ///  used KTextEditor library implements the interface. Use qobject_cast to
    ///  access the interface:
    ///  <pre>
    ///  // doc is of type KTextEditor.Document
    ///  KTextEditor.VariableInterface iface =
    ///      qobject_cast<KTextEditor.VariableInterface>( doc );
    ///  if( iface ) {
    ///      // the implementation supports the interface
    ///      // do stuff
    ///  }
    ///  </pre>
    ///  \see KTextEditor.Document, KTextEditor.Plugin
    ///  \author Anders Lund \<anders@alweb.dk\>
    ///  </remarks>        <short>    \brief Variable/Modeline extension interface for the Document.</short>
    [SmokeClass("KTextEditor::VariableInterface")]
    public abstract class VariableInterface : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected VariableInterface(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(VariableInterface), this);
        }
        public VariableInterface() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("VariableInterface", "VariableInterface()", typeof(void));
        }
        /// <remarks>
        ///  Get the value of the variable <pre>name</pre>.
        ///  \return the value or an empty string if the variable is not set or has
        ///          no value.
        ///      </remarks>        <short>    Get the value of the variable \p name.</short>
        [SmokeMethod("variable(const QString&) const")]
        public abstract string Variable(string name);
        /// <remarks>
        ///  The <pre>document</pre> emits this signal whenever the <pre>value</pre> of the
        ///  <pre>variable</pre> changed, this includes when a variable was initially set.
        ///  \param document document that emitted the signal
        ///  \param variable variable that changed
        ///  \param value new value for \e variable
        ///  \see variable()
        ///      </remarks>        <short>    The \p document emits this signal whenever the \p value of the  \p variable changed, this includes when a variable was initially set.</short>
        [SmokeMethod("variableChanged(KTextEditor::Document*, const QString&, const QString&)")]
        public abstract void VariableChanged(KTextEditor.Document document, string variable, string value);
    }
}
