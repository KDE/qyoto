//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace KParts {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  The Browser Extension is an extension (yes, no kidding) to
	///  KParts.ReadOnlyPart, which allows a better integration of parts
	///  with browsers (in particular Konqueror).
	///  Remember that ReadOnlyPart only has openUrl(KUrl) and a few arguments() but not much more.
	///  For full-fledged browsing, we need much more than that, including
	///  enabling/disabling of standard actions (print, copy, paste...),
	///  allowing parts to save and restore their data into the back/forward history,
	///  allowing parts to control the location bar URL, to requests URLs
	///  to be opened by the hosting browser, etc.
	///  The part developer needs to define its own class derived from BrowserExtension,
	///  to implement the methods [and the standard-actions slots, see below].
	///  The way to associate the BrowserExtension with the part is to simply
	///  create the BrowserExtension as a child of the part (in QObject's terms).
	///  The hosting application will look for it automatically.
	///  Another aspect of the browser integration is that a set of standard
	///  actions are provided by the browser, but implemented by the part
	///  (for the actions it supports).
	///  The following standard actions are defined by the host of the view :
	///  [selection-dependent actions]
	/// 
	/// <li>
	/// <code>cut</code> : Copy selected items to clipboard and store 'not cut' in clipboard.
	/// </li>
	/// 
	/// <li>
	/// <code>copy</code> : Copy selected items to clipboard and store 'cut' in clipboard.
	/// </li>
	/// 
	/// <li>
	/// <code>paste</code> : Paste clipboard into view URL.
	/// </li>
	/// 
	/// <li>
	/// <code>pasteTo</code>(KUrl) : Paste clipboard into given URL.
	/// </li>
	/// 
	/// <li>
	/// <code>rename</code> : Rename item in place.
	/// </li>
	/// 
	/// <li>
	/// <code>trash</code> : Move selected items to trash.
	/// </li>
	/// 
	/// <li>
	/// <code>del</code> : Delete selected items (couldn't call it delete!).
	/// </li>
	/// 
	/// <li>
	/// <code>shred</code> : Shred selected items (secure deletion) - DEPRECATED.
	/// </li>
	/// 
	/// <li>
	/// <code>properties</code> : Show file/document properties.
	/// </li>
	/// 
	/// <li>
	/// <code>editMimeType</code> : show file/document's mimetype properties.
	/// </li>
	/// 
	/// <li>
	/// <code>searchProvider</code> : Lookup selected text at default search provider
	/// </li>
	///  [normal actions]
	/// 
	/// <li>
	/// <code>print</code> : Print :-)
	/// </li>
	/// 
	/// <li>
	/// <code>reparseConfiguration</code> : Re-read configuration and apply it.
	/// </li>
	/// 
	/// <li>
	/// <code>refreshMimeTypes</code> : If the view uses mimetypes it should re-determine them.
	/// </li>
	///  The view defines a slot with the name of the action in order to implement the action.
	///  The browser will detect the slot automatically and connect its action to it when
	///  appropriate (i.e. when the view is active).
	///  The selection-dependent actions are disabled by default and the view should
	///  enable them when the selection changes, emitting enableAction().
	///  The normal actions do not depend on the selection.
	///  You need to enable 'print' when printing is possible - you can even do that
	///  in the constructor.
	///  A special case is the configuration slots, not connected to any action directly,
	///  and having parameters.
	///  [configuration slot]
	/// 
	/// <li>
	/// <code>setSaveViewPropertiesLocally</code>( bool ): If <code>true</code>, view properties are saved into .directory
	///                                        otherwise, they are saved globally.
	/// </li>
	/// 
	/// <li>
	/// <code>disableScrolling</code>: no scrollbars
	///   
	/// </li></remarks>		<short>    The Browser Extension is an extension (yes, no kidding) to  KParts.ReadOnlyPart, which allows a better integration of parts  with browsers (in particular Konqueror).</short>

	[SmokeClass("KParts::BrowserExtension")]
	public class BrowserExtension : QObject, IDisposable {
 		protected BrowserExtension(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(BrowserExtension), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static BrowserExtension() {
			staticInterceptor = new SmokeInvocation(typeof(BrowserExtension), null);
		}
		// void createNewWindow(const KUrl& arg1,const KParts::OpenUrlArguments& arg2,const KParts::BrowserArguments& arg3,const KParts::WindowArgs& arg4,KParts::ReadOnlyPart** arg5); >>>> NOT CONVERTED
		// void popupMenu(const QPoint& arg1,const KFileItemList& arg2,const KParts::OpenUrlArguments& arg3,const KParts::BrowserArguments& arg4,KParts::BrowserExtension::PopupFlags arg5,const KParts::BrowserExtension::ActionGroupMap& arg6); >>>> NOT CONVERTED
		// void popupMenu(const QPoint& arg1,const KUrl& arg2,mode_t arg3,const KParts::OpenUrlArguments& arg4,const KParts::BrowserArguments& arg5,KParts::BrowserExtension::PopupFlags arg6,const KParts::BrowserExtension::ActionGroupMap& arg7); >>>> NOT CONVERTED
		// KParts::BrowserExtension::ActionSlotMap actionSlotMap(); >>>> NOT CONVERTED
		// KParts::BrowserExtension::ActionSlotMap* actionSlotMapPtr(); >>>> NOT CONVERTED
		/// <remarks>
		///  Constructor
		/// <param> name="parent" The KParts.ReadOnlyPart that this extension ... "extends" :)
		///    </param></remarks>		<short>    Constructor </short>
		public BrowserExtension(KParts.ReadOnlyPart parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("BrowserExtension#", "BrowserExtension(KParts::ReadOnlyPart*)", typeof(void), typeof(KParts.ReadOnlyPart), parent);
		}
		/// <remarks>
		///  Set the parameters to use for opening the next URL.
		///  This is called by the "hosting" application, to pass parameters to the part.
		/// </remarks>		<short>    Set the parameters to use for opening the next URL.</short>
		/// 		<see> BrowserArguments</see>
		[SmokeMethod("setBrowserArguments(const KParts::BrowserArguments&)")]
		public virtual void SetBrowserArguments(KParts.BrowserArguments args) {
			interceptor.Invoke("setBrowserArguments#", "setBrowserArguments(const KParts::BrowserArguments&)", typeof(void), typeof(KParts.BrowserArguments), args);
		}
		/// <remarks>
		///  Retrieve the set of parameters to use for opening the URL
		///  (this must be called from openUrl() in the part).
		/// </remarks>		<short>    Retrieve the set of parameters to use for opening the URL  (this must be called from openUrl() in the part).</short>
		/// 		<see> BrowserArguments</see>
		public KParts.BrowserArguments BrowserArguments() {
			return (KParts.BrowserArguments) interceptor.Invoke("browserArguments", "browserArguments() const", typeof(KParts.BrowserArguments));
		}
		/// <remarks>
		///  Returns the current x offset.
		///  For a scrollview, implement this using contentsX().
		///    </remarks>		<short>    Returns the current x offset.</short>
		[SmokeMethod("xOffset()")]
		public virtual int XOffset() {
			return (int) interceptor.Invoke("xOffset", "xOffset()", typeof(int));
		}
		/// <remarks>
		///  Returns the current y offset.
		///  For a scrollview, implement this using contentsY().
		///    </remarks>		<short>    Returns the current y offset.</short>
		[SmokeMethod("yOffset()")]
		public virtual int YOffset() {
			return (int) interceptor.Invoke("yOffset", "yOffset()", typeof(int));
		}
		/// <remarks>
		///  Used by the browser to save the current state of the view
		///  (in order to restore it if going back in navigation).
		///  If you want to save additional properties, reimplement it
		///  but don't forget to call the parent method (probably first).
		///    </remarks>		<short>    Used by the browser to save the current state of the view  (in order to restore it if going back in navigation).</short>
		[SmokeMethod("saveState(QDataStream&)")]
		public virtual void SaveState(QDataStream stream) {
			interceptor.Invoke("saveState#", "saveState(QDataStream&)", typeof(void), typeof(QDataStream), stream);
		}
		/// <remarks>
		///  Used by the browser to restore the view in the state
		///  it was when we left it.
		///  If you saved additional properties, reimplement it
		///  but don't forget to call the parent method (probably first).
		///    </remarks>		<short>    Used by the browser to restore the view in the state  it was when we left it.</short>
		[SmokeMethod("restoreState(QDataStream&)")]
		public virtual void RestoreState(QDataStream stream) {
			interceptor.Invoke("restoreState#", "restoreState(QDataStream&)", typeof(void), typeof(QDataStream), stream);
		}
		public void SetBrowserInterface(KParts.BrowserInterface impl) {
			interceptor.Invoke("setBrowserInterface#", "setBrowserInterface(KParts::BrowserInterface*)", typeof(void), typeof(KParts.BrowserInterface), impl);
		}
		public KParts.BrowserInterface BrowserInterface() {
			return (KParts.BrowserInterface) interceptor.Invoke("browserInterface", "browserInterface() const", typeof(KParts.BrowserInterface));
		}
		/// <remarks>
		/// </remarks>		<return> the status (enabled/disabled) of an action.
		///  When the enableAction signal is emitted, the browserextension
		///  stores the status of the action internally, so that it's possible
		///  to query later for the status of the action, using this method.
		///    </return>
		/// 		<short>   </short>
		public bool IsActionEnabled(string name) {
			return (bool) interceptor.Invoke("isActionEnabled$", "isActionEnabled(const char*) const", typeof(bool), typeof(string), name);
		}
		/// <remarks>
		/// </remarks>		<return> the text of an action, if it was set explicitly by the part.
		///  When the setActionText signal is emitted, the browserextension
		///  stores the text of the action internally, so that it's possible
		///  to query later for the text of the action, using this method.
		///    </return>
		/// 		<short>   </short>
		public string ActionText(string name) {
			return (string) interceptor.Invoke("actionText$", "actionText(const char*) const", typeof(string), typeof(string), name);
		}
		/// <remarks>
		///  Asks the hosting browser to perform a paste (using openUrlRequestDelayed())
		///    </remarks>		<short>    Asks the hosting browser to perform a paste (using openUrlRequestDelayed())    </short>
		public void PasteRequest() {
			interceptor.Invoke("pasteRequest", "pasteRequest()", typeof(void));
		}
		/// <remarks>
		///  Enables or disable a standard action held by the browser.
		///  See class documentation for the list of standard actions.
		///    </remarks>		<short>    Enables or disable a standard action held by the browser.</short>
		public void EnableAction(string name, bool enabled) {
			interceptor.Invoke("enableAction$$", "enableAction(const char*, bool)", typeof(void), typeof(string), name, typeof(bool), enabled);
		}
		/// <remarks>
		///  Change the text of a standard action held by the browser.
		///  This can be used to change "Paste" into "Paste Image" for instance.
		///  See class documentation for the list of standard actions.
		///    </remarks>		<short>    Change the text of a standard action held by the browser.</short>
		public void SetActionText(string name, string text) {
			interceptor.Invoke("setActionText$$", "setActionText(const char*, const QString&)", typeof(void), typeof(string), name, typeof(string), text);
		}
		/// <remarks>
		///  Asks the host (browser) to open <code>url.</code>
		///  To set a reload, the x and y offsets, the service type etc., fill in the
		///  appropriate fields in the <code>args</code> structure.
		///  Hosts should not connect to this signal but to openUrlRequestDelayed().
		///    </remarks>		<short>    Asks the host (browser) to open <code>url.</code></short>
		public void OpenUrlRequest(KUrl url, KParts.OpenUrlArguments arguments, KParts.BrowserArguments browserArguments) {
			interceptor.Invoke("openUrlRequest###", "openUrlRequest(const KUrl&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments, typeof(KParts.BrowserArguments), browserArguments);
		}
		public void OpenUrlRequest(KUrl url, KParts.OpenUrlArguments arguments) {
			interceptor.Invoke("openUrlRequest##", "openUrlRequest(const KUrl&, const KParts::OpenUrlArguments&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments);
		}
		public void OpenUrlRequest(KUrl url) {
			interceptor.Invoke("openUrlRequest#", "openUrlRequest(const KUrl&)", typeof(void), typeof(KUrl), url);
		}
		/// <remarks>
		///  This signal is emitted when openUrlRequest() is called, after a 0-seconds timer.
		///  This allows the caller to terminate what it's doing first, before (usually)
		///  being destroyed. Parts should never use this signal, hosts should only connect
		///  to this signal.
		///    </remarks>		<short>    This signal is emitted when openUrlRequest() is called, after a 0-seconds timer.</short>
		public void OpenUrlRequestDelayed(KUrl url, KParts.OpenUrlArguments arguments, KParts.BrowserArguments browserArguments) {
			interceptor.Invoke("openUrlRequestDelayed###", "openUrlRequestDelayed(const KUrl&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments, typeof(KParts.BrowserArguments), browserArguments);
		}
		/// <remarks>
		///  Tells the hosting browser that the part opened a new URL (which can be
		///  queried via KParts.Part.Url().
		///  This helps the browser to update/create an entry in the history.
		///  The part may <b>not</b> emit this signal together with openUrlRequest().
		///  Emit openUrlRequest() if you want the browser to handle a URL the user
		///  asked to open (from within your part/document). This signal however is
		///  useful if you want to handle URLs all yourself internally, while still
		///  telling the hosting browser about new opened URLs, in order to provide
		///  a proper history functionality to the user.
		///  An example of usage is a html rendering component which wants to emit
		///  this signal when a child frame document changed its URL.
		///  Conclusion: you probably want to use openUrlRequest() instead.
		///    </remarks>		<short>    Tells the hosting browser that the part opened a new URL (which can be  queried via KParts.Part.Url().</short>
		public void OpenUrlNotify() {
			interceptor.Invoke("openUrlNotify", "openUrlNotify()", typeof(void));
		}
		/// <remarks>
		///  Updates the URL shown in the browser's location bar to <code>url.</code>
		///    </remarks>		<short>    Updates the URL shown in the browser's location bar to <code>url.</code></short>
		public void SetLocationBarUrl(string url) {
			interceptor.Invoke("setLocationBarUrl$", "setLocationBarUrl(const QString&)", typeof(void), typeof(string), url);
		}
		/// <remarks>
		///  Sets the URL of an icon for the currently displayed page.
		///    </remarks>		<short>    Sets the URL of an icon for the currently displayed page.</short>
		public void SetIconUrl(KUrl url) {
			interceptor.Invoke("setIconUrl#", "setIconUrl(const KUrl&)", typeof(void), typeof(KUrl), url);
		}
		/// <remarks>
		///  Asks the hosting browser to open a new window for the given <code>url</code>
		///  and return a reference to the content part.
		///  <code>arguments</code> is optional additional information about how to open the url,
		///  <code>browserArguments</code> is optional additional information for web browsers,
		///  The request for a pointer to the part is only fulfilled/processed
		///  if the mimeType is set in the <code>browserArguments.</code>
		///  (otherwise the request cannot be processed synchronously).
		///    </remarks>		<short>    Asks the hosting browser to open a new window for the given <code>url</code>  and return a reference to the content part.</short>
		/// 		<see> OpenUrlArguments</see>
		/// 		<see> BrowserArguments</see>
		public void CreateNewWindow(KUrl url, KParts.OpenUrlArguments arguments, KParts.BrowserArguments browserArguments, KParts.WindowArgs windowArgs) {
			interceptor.Invoke("createNewWindow####", "createNewWindow(const KUrl&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&, const KParts::WindowArgs&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments, typeof(KParts.BrowserArguments), browserArguments, typeof(KParts.WindowArgs), windowArgs);
		}
		public void CreateNewWindow(KUrl url, KParts.OpenUrlArguments arguments, KParts.BrowserArguments browserArguments) {
			interceptor.Invoke("createNewWindow###", "createNewWindow(const KUrl&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments, typeof(KParts.BrowserArguments), browserArguments);
		}
		public void CreateNewWindow(KUrl url, KParts.OpenUrlArguments arguments) {
			interceptor.Invoke("createNewWindow##", "createNewWindow(const KUrl&, const KParts::OpenUrlArguments&)", typeof(void), typeof(KUrl), url, typeof(KParts.OpenUrlArguments), arguments);
		}
		public void CreateNewWindow(KUrl url) {
			interceptor.Invoke("createNewWindow#", "createNewWindow(const KUrl&)", typeof(void), typeof(KUrl), url);
		}
		/// <remarks>
		///  Since the part emits the jobid in the started() signal,
		///  progress information is automatically displayed.
		///  However, if you don't use a KIO.Job in the part,
		///  you can use loadingProgress() and speedProgress()
		///  to display progress information.
		///    </remarks>		<short>    Since the part emits the jobid in the started() signal,  progress information is automatically displayed.</short>
		public void LoadingProgress(int percent) {
			interceptor.Invoke("loadingProgress$", "loadingProgress(int)", typeof(void), typeof(int), percent);
		}
		/// <remarks>
		/// </remarks>		<short>   </short>
		/// 		<see> loadingProgress</see>
		public void SpeedProgress(int bytesPerSecond) {
			interceptor.Invoke("speedProgress$", "speedProgress(int)", typeof(void), typeof(int), bytesPerSecond);
		}
		public void InfoMessage(string arg1) {
			interceptor.Invoke("infoMessage$", "infoMessage(const QString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Emit this to make the browser show a standard popup menu for the files <code>items.</code>
		/// <param> name="global" global coordinates where the popup should be shown
		/// </param><param> name="items" list of file items which the popup applies to
		/// </param><param> name="args" OpenUrlArguments, mostly for metadata here
		/// </param><param> name="browserArguments" BrowserArguments, mostly for referrer
		/// </param><param> name="flags" enables/disables certain builtin actions in the popupmenu
		/// </param><param> name="actionGroups" named groups of actions which should be inserted into the popup, see ActionGroupMap
		///    </param></remarks>		<short>    Emit this to make the browser show a standard popup menu for the files <code>items.</code></short>
		public void PopupMenu(QPoint global, List<KFileItem> items, KParts.OpenUrlArguments args, KParts.BrowserArguments browserArgs, uint flags) {
			interceptor.Invoke("popupMenu####$", "popupMenu(const QPoint&, const KFileItemList&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&, KParts::BrowserExtension::PopupFlags)", typeof(void), typeof(QPoint), global, typeof(List<KFileItem>), items, typeof(KParts.OpenUrlArguments), args, typeof(KParts.BrowserArguments), browserArgs, typeof(uint), flags);
		}
		public void PopupMenu(QPoint global, List<KFileItem> items, KParts.OpenUrlArguments args, KParts.BrowserArguments browserArgs) {
			interceptor.Invoke("popupMenu####", "popupMenu(const QPoint&, const KFileItemList&, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&)", typeof(void), typeof(QPoint), global, typeof(List<KFileItem>), items, typeof(KParts.OpenUrlArguments), args, typeof(KParts.BrowserArguments), browserArgs);
		}
		public void PopupMenu(QPoint global, List<KFileItem> items, KParts.OpenUrlArguments args) {
			interceptor.Invoke("popupMenu###", "popupMenu(const QPoint&, const KFileItemList&, const KParts::OpenUrlArguments&)", typeof(void), typeof(QPoint), global, typeof(List<KFileItem>), items, typeof(KParts.OpenUrlArguments), args);
		}
		public void PopupMenu(QPoint global, List<KFileItem> items) {
			interceptor.Invoke("popupMenu##", "popupMenu(const QPoint&, const KFileItemList&)", typeof(void), typeof(QPoint), global, typeof(List<KFileItem>), items);
		}
		/// <remarks>
		///  Emit this to make the browser show a standard popup menu for the given <code>url.</code>
		///  Give as much information about this URL as possible,
		///  like <code>args.mimeType</code> and the file type <code>mode</code>
		/// <param> name="global" global coordinates where the popup should be shown
		/// </param><param> name="url" the URL this popup applies to
		/// </param><param> name="mode" the file type of the url (S_IFREG, S_IFDIR...)
		/// </param><param> name="args" OpenUrlArguments, set the mimetype of the URL using setMimeType()
		/// </param><param> name="browserArguments" BrowserArguments, mostly for referrer
		/// </param><param> name="flags" enables/disables certain builtin actions in the popupmenu
		/// </param><param> name="actionGroups" named groups of actions which should be inserted into the popup, see ActionGroupMap
		///    </param></remarks>		<short>    Emit this to make the browser show a standard popup menu for the given <code>url.</code></short>
		public void PopupMenu(QPoint global, KUrl url, long mode, KParts.OpenUrlArguments args, KParts.BrowserArguments browserArgs, uint flags) {
			interceptor.Invoke("popupMenu##$##$", "popupMenu(const QPoint&, const KUrl&, mode_t, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&, KParts::BrowserExtension::PopupFlags)", typeof(void), typeof(QPoint), global, typeof(KUrl), url, typeof(long), mode, typeof(KParts.OpenUrlArguments), args, typeof(KParts.BrowserArguments), browserArgs, typeof(uint), flags);
		}
		public void PopupMenu(QPoint global, KUrl url, long mode, KParts.OpenUrlArguments args, KParts.BrowserArguments browserArgs) {
			interceptor.Invoke("popupMenu##$##", "popupMenu(const QPoint&, const KUrl&, mode_t, const KParts::OpenUrlArguments&, const KParts::BrowserArguments&)", typeof(void), typeof(QPoint), global, typeof(KUrl), url, typeof(long), mode, typeof(KParts.OpenUrlArguments), args, typeof(KParts.BrowserArguments), browserArgs);
		}
		public void PopupMenu(QPoint global, KUrl url, long mode, KParts.OpenUrlArguments args) {
			interceptor.Invoke("popupMenu##$#", "popupMenu(const QPoint&, const KUrl&, mode_t, const KParts::OpenUrlArguments&)", typeof(void), typeof(QPoint), global, typeof(KUrl), url, typeof(long), mode, typeof(KParts.OpenUrlArguments), args);
		}
		public void PopupMenu(QPoint global, KUrl url, long mode) {
			interceptor.Invoke("popupMenu##$", "popupMenu(const QPoint&, const KUrl&, mode_t)", typeof(void), typeof(QPoint), global, typeof(KUrl), url, typeof(long), mode);
		}
		public void PopupMenu(QPoint global, KUrl url) {
			interceptor.Invoke("popupMenu##", "popupMenu(const QPoint&, const KUrl&)", typeof(void), typeof(QPoint), global, typeof(KUrl), url);
		}
		/// <remarks>
		///  Inform the hosting application about the current selection.
		///  Used when a set of files/URLs is selected (with full information
		///  about those URLs, including size, permissions etc.)
		///    </remarks>		<short>    Inform the hosting application about the current selection.</short>
		public void SelectionInfo(List<KFileItem> items) {
			interceptor.Invoke("selectionInfo#", "selectionInfo(const KFileItemList&)", typeof(void), typeof(List<KFileItem>), items);
		}
		/// <remarks>
		///  Inform the hosting application about the current selection.
		///  Used when some text is selected.
		///    </remarks>		<short>    Inform the hosting application about the current selection.</short>
		public void SelectionInfo(string text) {
			interceptor.Invoke("selectionInfo$", "selectionInfo(const QString&)", typeof(void), typeof(string), text);
		}
		/// <remarks>
		///  Inform the hosting application about the current selection.
		///  Used when a set of URLs is selected.
		///    </remarks>		<short>    Inform the hosting application about the current selection.</short>
		public void SelectionInfo(List<KUrl> urls) {
			interceptor.Invoke("selectionInfo?", "selectionInfo(const KUrl::List&)", typeof(void), typeof(List<KUrl>), urls);
		}
		/// <remarks>
		///  Inform the hosting application that the user moved the mouse over an item.
		///  Used when the mouse is on an URL.
		///    </remarks>		<short>    Inform the hosting application that the user moved the mouse over an item.</short>
		public void MouseOverInfo(KFileItem item) {
			interceptor.Invoke("mouseOverInfo#", "mouseOverInfo(const KFileItem&)", typeof(void), typeof(KFileItem), item);
		}
		/// <remarks>
		///  Ask the hosting application to add a new HTML (aka Mozilla/Netscape)
		///  SideBar entry.
		///    </remarks>		<short>    Ask the hosting application to add a new HTML (aka Mozilla/Netscape)  SideBar entry.</short>
		public void AddWebSideBar(KUrl url, string name) {
			interceptor.Invoke("addWebSideBar#$", "addWebSideBar(const KUrl&, const QString&)", typeof(void), typeof(KUrl), url, typeof(string), name);
		}
		/// <remarks>
		///  Ask the hosting application to move the top level widget.
		///    </remarks>		<short>    Ask the hosting application to move the top level widget.</short>
		public void MoveTopLevelWidget(int x, int y) {
			interceptor.Invoke("moveTopLevelWidget$$", "moveTopLevelWidget(int, int)", typeof(void), typeof(int), x, typeof(int), y);
		}
		/// <remarks>
		///  Ask the hosting application to resize the top level widget.
		///    </remarks>		<short>    Ask the hosting application to resize the top level widget.</short>
		public void ResizeTopLevelWidget(int w, int h) {
			interceptor.Invoke("resizeTopLevelWidget$$", "resizeTopLevelWidget(int, int)", typeof(void), typeof(int), w, typeof(int), h);
		}
		/// <remarks>
		///  Ask the hosting application to focus <code>part.</code>
		///    </remarks>		<short>    Ask the hosting application to focus <code>part.</code></short>
		public void RequestFocus(KParts.ReadOnlyPart part) {
			interceptor.Invoke("requestFocus#", "requestFocus(KParts::ReadOnlyPart*)", typeof(void), typeof(KParts.ReadOnlyPart), part);
		}
		/// <remarks>
		///  Tell the host (browser) about security state of current page
		///  enum PageSecurity { NotCrypted, Encrypted, Mixed }
		///    </remarks>		<short>    Tell the host (browser) about security state of current page  enum PageSecurity { NotCrypted, Encrypted, Mixed }    </short>
		public void SetPageSecurity(int arg1) {
			interceptor.Invoke("setPageSecurity$", "setPageSecurity(int)", typeof(void), typeof(int), arg1);
		}
		/// <remarks>
		///  Inform the host about items that have been removed.
		///    </remarks>		<short>    Inform the host about items that have been removed.</short>
		public void ItemsRemoved(List<KFileItem> items) {
			interceptor.Invoke("itemsRemoved#", "itemsRemoved(const KFileItemList&)", typeof(void), typeof(List<KFileItem>), items);
		}
		~BrowserExtension() {
			interceptor.Invoke("~BrowserExtension", "~BrowserExtension()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~BrowserExtension", "~BrowserExtension()", typeof(void));
		}
		/// <remarks>
		///  Returns a map containing the action names as keys and corresponding
		///  SLOT()'ified method names as data entries.
		///  This is very useful for
		///  the host component, when connecting the own signals with the
		///  extension's slots.
		///  Basically you iterate over the map, check if the extension implements
		///  the slot and connect to the slot using the data value of your map
		///  iterator.
		///  Checking if the extension implements a certain slot can be done like this:
		///  <pre>
		///    extension.MetaObject().SlotNames().contains( actionName + "()" )
		///  </pre>
		///  (note that <code>actionName</code> is the iterator's key value if already
		///   iterating over the action slot map, returned by this method)
		///  Connecting to the slot can be done like this:
		///  <pre>
		///    connect( yourObject, SIGNAL("yourSignal()"),
		///             extension, mapIterator.data() )
		///  </pre>
		///  (where "mapIterator" is your QMap<string,string> iterator)
		///    </remarks>		<short>    Returns a map containing the action names as keys and corresponding  SLOT()'ified method names as data entries.</short>
		/// <remarks>
		/// </remarks>		<return> a pointer to the static action-slot map. Preferred method to get it.
		///  The map is created if it doesn't exist yet
		///    </return>
		/// 		<short>   </short>
		/// <remarks>
		///  Queries <code>obj</code> for a child object which inherits from this
		///  BrowserExtension class. Convenience method.
		///    </remarks>		<short>    Queries <code>obj</code> for a child object which inherits from this  BrowserExtension class.</short>
		public static KParts.BrowserExtension ChildObject(QObject arg1) {
			return (KParts.BrowserExtension) staticInterceptor.Invoke("childObject#", "childObject(QObject*)", typeof(KParts.BrowserExtension), typeof(QObject), arg1);
		}
		protected new IBrowserExtensionSignals Emit {
			get { return (IBrowserExtensionSignals) Q_EMIT; }
		}
	}

	public interface IBrowserExtensionSignals : IQObjectSignals {
	}
	}
}
