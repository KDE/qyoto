//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  An action that takes care of everything associated with
    ///  showing or hiding a toolbar by a menu action. It will
    ///  show or hide the toolbar with the given name when
    ///  activated, and check or uncheck itself if the toolbar
    ///  is manually shown or hidden.
    ///  If you need to perfom some additional action when the
    ///  toolbar is shown or hidden, connect to the toggled(bool)
    ///  signal. It will be emitted after the toolbar's
    ///  visibility has changed, whenever it changes.
    ///  </remarks>        <short>    An action that takes care of everything associated with  showing or hiding a toolbar by a menu action.</short>
    [SmokeClass("KToggleToolBarAction")]
    public class KToggleToolBarAction : KToggleAction, IDisposable {
        protected KToggleToolBarAction(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KToggleToolBarAction), this);
        }
        /// <remarks>
        ///  Create a KToggleToolbarAction that manages the toolbar
        ///  named toolBarName. This can be either the name of a
        ///  toolbar in an xml ui file, or a toolbar programmatically
        ///  created with that name.
        /// <param> name="The" action's parent object.
        ///      </param></remarks>        <short>    Create a KToggleToolbarAction that manages the toolbar  named toolBarName.</short>
        public KToggleToolBarAction(string toolBarName, string text, QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KToggleToolBarAction$$#", "KToggleToolBarAction(const char*, const QString&, QObject*)", typeof(void), typeof(string), toolBarName, typeof(string), text, typeof(QObject), parent);
        }
        /// <remarks>
        ///  Create a KToggleToolbarAction that manages the @param toolBar.
        ///  This can be either the name of a toolbar in an xml ui file,
        ///  or a toolbar programmatically created with that name.
        /// <param> name="toolBar" the toolbar to be managed
        /// </param><param> name="parent" The action's parent object.
        ///      </param></remarks>        <short>    Create a KToggleToolbarAction that manages the @param toolBar.</short>
        public KToggleToolBarAction(KToolBar toolBar, string text, QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KToggleToolBarAction#$#", "KToggleToolBarAction(KToolBar*, const QString&, QObject*)", typeof(void), typeof(KToolBar), toolBar, typeof(string), text, typeof(QObject), parent);
        }
        /// <remarks>
        ///  Returns a pointer to the tool bar it manages.
        ///      </remarks>        <short>    Returns a pointer to the tool bar it manages.</short>
        public KToolBar ToolBar() {
            return (KToolBar) interceptor.Invoke("toolBar", "toolBar()", typeof(KToolBar));
        }
        /// <remarks>
        ///  Reimplemented from @see QObject.
        ///      </remarks>        <short>    Reimplemented from @see QObject.</short>
        [SmokeMethod("eventFilter(QObject*, QEvent*)")]
        public new virtual bool EventFilter(QObject watched, QEvent arg2) {
            return (bool) interceptor.Invoke("eventFilter##", "eventFilter(QObject*, QEvent*)", typeof(bool), typeof(QObject), watched, typeof(QEvent), arg2);
        }
        ~KToggleToolBarAction() {
            interceptor.Invoke("~KToggleToolBarAction", "~KToggleToolBarAction()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KToggleToolBarAction", "~KToggleToolBarAction()", typeof(void));
        }
        protected new IKToggleToolBarActionSignals Emit {
            get { return (IKToggleToolBarActionSignals) Q_EMIT; }
        }
    }

    public interface IKToggleToolBarActionSignals : IKToggleActionSignals {
    }
}
