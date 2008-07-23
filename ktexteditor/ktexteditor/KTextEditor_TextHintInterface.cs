//Auto-generated by kalyptus. DO NOT EDIT.
namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    using System.Text;
    /// <remarks>
    ///  This is an interface for the KTextEditor.View class.
    ///  \ingroup kte_group_view_extensions
    ///  </remarks>        <short>    This is an interface for the KTextEditor.View class.</short>
    [SmokeClass("KTextEditor::TextHintInterface")]
    public abstract class TextHintInterface : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected TextHintInterface(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(TextHintInterface), this);
        }
        public TextHintInterface() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("TextHintInterface", "TextHintInterface()", typeof(void));
        }
        /// <remarks>
        ///  enable Texthints. If they are enabled a signal needTextHint is emitted, if the mouse
        ///  changed the position and a new character is beneath the mouse cursor. The signal is delayed
        ///  for a certain time, specifiedin the timeout parameter.
        ///      </remarks>        <short>    enable Texthints.</short>
        [SmokeMethod("enableTextHints(int)")]
        public abstract void EnableTextHints(int timeout);
        /// <remarks>
        ///  Disable texthints. Per default they are disabled.
        ///      </remarks>        <short>    Disable texthints.</short>
        [SmokeMethod("disableTextHints()")]
        public abstract void DisableTextHints();
        /// <remarks>
        ///  emit this signal, if a tooltip text is needed for displaying.
        ///  I you don't want a tooltip to be displayd set text to an emtpy string in a connected slot,
        ///  otherwise set text to the string you want the editor to display
        ///      </remarks>        <short>    emit this signal, if a tooltip text is needed for displaying.</short>
        [SmokeMethod("needTextHint(const KTextEditor::Cursor&, QString&)")]
        public abstract void NeedTextHint(KTextEditor.Cursor position, StringBuilder text);
    }
}
