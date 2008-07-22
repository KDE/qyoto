//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  This class provides a framework for assistant dialogs.
    ///  The use of this class is the same as KWizard in KDE3.
    ///  You should use the word "assistant" instead of "wizard" both in the source 
    ///  and translatable strings.
    ///  An assistant dialog consists of a sequence of pages.
    ///  Its purpose is to walk the user (assist) through a process step by step.
    ///  Assistant dialogs are useful for complex or infrequently occurring tasks 
    ///  that people may find difficult to learn or do. 
    ///  Sometimes a task requires too many input fields to fit them on a single dialog.
    ///  KAssistantDialog provides page titles and displays Next, Back, Finish, Cancel, 
    ///  and Help push buttons, as appropriate to the current position in the page sequence.
    ///  The Finish Button has the code KDialog.User1, The Next button is KDialog.User2 
    ///  and the Back button is KDialog.User3.
    ///  The help button may be hidden using showButton(KDialog.Help, false)
    ///  Create and populate dialog pages that inherit from QWidget and add them 
    ///  to the assistant dialog using addPage().
    ///  The functions next() and back() are and may be reimplemented to
    ///  override the default actions of the next and back buttons.
    /// </remarks>        <author> Olivier Goffart <ogoffart at kde.org>
    ///  </author>
    ///         <short>    This class provides a framework for assistant dialogs.</short>
    [SmokeClass("KAssistantDialog")]
    public class KAssistantDialog : KPageDialog, IDisposable {
        protected KAssistantDialog(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KAssistantDialog), this);
        }
        /// <remarks>
        ///  Construct a new assistant dialog with <code>parent</code> as parent.
        /// <param> name="parent" is the parent of the widget. 
        ///  @flags the window flags to give to the assistant dialog. The
        ///  default of zero is usually what you want.
        ///          </param></remarks>        <short>    Construct a new assistant dialog with <code>parent</code> as parent.</short>
        public KAssistantDialog(QWidget parent, uint flags) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog#$", "KAssistantDialog(QWidget*, Qt::WindowFlags)", typeof(void), typeof(QWidget), parent, typeof(uint), flags);
        }
        public KAssistantDialog(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog#", "KAssistantDialog(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public KAssistantDialog() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog", "KAssistantDialog()", typeof(void));
        }
        /// <remarks>
        ///  Specify if the content of the page is valid, and if the next button may be enabled on this page.
        ///  By default all pages are valid.
        ///  This will disable or enable the next button on the specified page
        /// <param> name="page" the page on which the next button will be enabled/disable
        /// </param><param> name="enable" if true the next button will be enabled, if false it will be disabled
        ///          </param></remarks>        <short>    Specify if the content of the page is valid, and if the next button may be enabled on this page.</short>
        public void SetValid(KPageWidgetItem page, bool enable) {
            interceptor.Invoke("setValid#$", "setValid(KPageWidgetItem*, bool)", typeof(void), typeof(KPageWidgetItem), page, typeof(bool), enable);
        }
        /// <remarks>
        ///  return if a page is valid
        /// <param> name="page" the page to check the validity of
        ///          </param></remarks>        <short>    return if a page is valid </short>
        ///         <see> setValid</see>
        public bool IsValid(KPageWidgetItem page) {
            return (bool) interceptor.Invoke("isValid#", "isValid(KPageWidgetItem*) const", typeof(bool), typeof(KPageWidgetItem), page);
        }
        /// <remarks>
        ///  Specify whether a page is appropriate.
        ///  A page is considered inappropriate if it should not be shown due to 
        ///  the contents of other pages making it inappropriate.
        ///  A page which is inappropriate will not be shown.
        ///  The last page in an assistant dialog should always be appropriate
        /// <param> name="page" the page to set as appropriate
        /// </param><param> name="appropriate" flag indicating the appropriateness of the page.
        ///  If <code>appropriate</code> is true, then <code>page</code> is appropriate and will be
        ///  shown in the assistant dialog. If false, <code>page</code> will not be shown.
        ///          </param></remarks>        <short>    Specify whether a page is appropriate.</short>
        public void SetAppropriate(KPageWidgetItem page, bool appropriate) {
            interceptor.Invoke("setAppropriate#$", "setAppropriate(KPageWidgetItem*, bool)", typeof(void), typeof(KPageWidgetItem), page, typeof(bool), appropriate);
        }
        /// <remarks>
        ///  Check if a page is appropriate for use in the assistant dialog.
        /// <param> name="page" is the page to check the appropriateness of.
        /// </param></remarks>        <return> true if <code>page</code> is appropriate, false if it is not
        ///          </return>
        ///         <short>    Check if a page is appropriate for use in the assistant dialog.</short>
        public bool IsAppropriate(KPageWidgetItem page) {
            return (bool) interceptor.Invoke("isAppropriate#", "isAppropriate(KPageWidgetItem*) const", typeof(bool), typeof(KPageWidgetItem), page);
        }
        /// <remarks>
        ///  Called when the user clicks the Back button.
        ///  This function will show the preceding relevant page in the sequence.
        ///  Do nothing if the current page is the first page is the sequence.
        ///          </remarks>        <short>    Called when the user clicks the Back button.</short>
        [Q_SLOT("void back()")]
        [SmokeMethod("back()")]
        public virtual void Back() {
            interceptor.Invoke("back", "back()", typeof(void));
        }
        /// <remarks>
        ///  Called when the user clicks the Next/Finish button.
        ///  This function will show the next relevant page in the sequence.
        ///  If the current page is the last page, it will call accept()
        ///          </remarks>        <short>    Called when the user clicks the Next/Finish button.</short>
        [Q_SLOT("void next()")]
        [SmokeMethod("next()")]
        public virtual void Next() {
            interceptor.Invoke("next", "next()", typeof(void));
        }
        /// <remarks>
        ///  Construct an assistant dialog from a single widget.
        /// <param> name="widget" the widget to construct the dialog with
        /// </param><param> name="parent" the parent of the assistant dialog
        ///  @flags the window flags to use when creating the widget. The default
        ///  of zero is usually fine.
        /// </param> Calls the KPageDialog(KPageWidget widget, QWidget parent, Qt.WFlags flags) constructor
        ///          </remarks>        <short>    Construct an assistant dialog from a single widget.</short>
        public KAssistantDialog(KPageWidget widget, QWidget parent, uint flags) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog##$", "KAssistantDialog(KPageWidget*, QWidget*, Qt::WindowFlags)", typeof(void), typeof(KPageWidget), widget, typeof(QWidget), parent, typeof(uint), flags);
        }
        public KAssistantDialog(KPageWidget widget, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog##", "KAssistantDialog(KPageWidget*, QWidget*)", typeof(void), typeof(KPageWidget), widget, typeof(QWidget), parent);
        }
        public KAssistantDialog(KPageWidget widget) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KAssistantDialog#", "KAssistantDialog(KPageWidget*)", typeof(void), typeof(KPageWidget), widget);
        }
        [SmokeMethod("showEvent(QShowEvent*)")]
        protected override void ShowEvent(QShowEvent arg1) {
            interceptor.Invoke("showEvent#", "showEvent(QShowEvent*)", typeof(void), typeof(QShowEvent), arg1);
        }
        ~KAssistantDialog() {
            interceptor.Invoke("~KAssistantDialog", "~KAssistantDialog()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KAssistantDialog", "~KAssistantDialog()", typeof(void));
        }
        protected new IKAssistantDialogSignals Emit {
            get { return (IKAssistantDialogSignals) Q_EMIT; }
        }
    }

    public interface IKAssistantDialogSignals : IKPageDialogSignals {
    }
}
