//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Text;
	using System.Collections.Generic;

	public interface IKXMLGUIClient {
		QAction Action(string name);
		QAction Action(QDomElement element);
		KActionCollection ActionCollection();
		KComponentData ComponentData();
		QDomDocument DomDocument();
		string XmlFile();
		string LocalXMLFile();
		void SetXMLGUIBuildDocument(QDomDocument doc);
		QDomDocument XmlguiBuildDocument();
		void SetFactory(KXMLGUIFactory factory);
		KXMLGUIFactory Factory();
		KXMLGUIClient ParentClient();
		void InsertChildClient(KXMLGUIClient child);
		void RemoveChildClient(KXMLGUIClient child);
		void SetClientBuilder(KXMLGUIBuilder builder);
		KXMLGUIBuilder ClientBuilder();
		void ReloadXML();
		void PlugActionList(string name, List<QAction> actionList);
		void UnplugActionList(string name);
		void AddStateActionEnabled(string state, string action);
		void AddStateActionDisabled(string state, string action);
		void BeginXMLPlug(QWidget arg1);
		void EndXMLPlug();
		void PrepareXMLUnplug(QWidget arg1);
	}

	/// <remarks>
	///  A KXMLGUIClient can be used with KXMLGUIFactory to create a
	///  GUI from actions and an XML document, and can be dynamically merged
	///  with other KXMLGUIClients.
	///  </remarks>		<short>   </short>

	[SmokeClass("KXMLGUIClient")]
	public class KXMLGUIClient : Object, IKXMLGUIClient, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KXMLGUIClient(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KXMLGUIClient), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KXMLGUIClient() {
			staticInterceptor = new SmokeInvocation(typeof(KXMLGUIClient), null);
		}
		public enum ReverseStateChange {
			StateNoReverse = 0,
			StateReverse = 1,
		}
		// QList<KXMLGUIClient*> childClients(); >>>> NOT CONVERTED
		// KXMLGUIClient::StateChange getActionsToChangeForState(const QString& arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Constructs a KXMLGUIClient which can be used with a
		///  KXMLGUIFactory to create a GUI from actions and an XML document, and
		///  which can be dynamically merged with other KXMLGUIClients.
		///    </remarks>		<short>    Constructs a KXMLGUIClient which can be used with a  KXMLGUIFactory to create a GUI from actions and an XML document, and  which can be dynamically merged with other KXMLGUIClients.</short>
		public KXMLGUIClient() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KXMLGUIClient", "KXMLGUIClient()", typeof(void));
		}
		/// <remarks>
		///  Constructs a KXMLGUIClient which can be used with a KXMLGUIFactory
		///  to create a GUI from actions and an XML document,
		///  and which can be dynamically merged with other KXMLGUIClients.
		///  This constructor takes an additional <code>parent</code> argument, which makes
		///  the client a child client of the parent.
		///  Child clients are automatically added to the GUI if the parent is added.
		///    </remarks>		<short>    Constructs a KXMLGUIClient which can be used with a KXMLGUIFactory  to create a GUI from actions and an XML document,  and which can be dynamically merged with other KXMLGUIClients.</short>
		public KXMLGUIClient(KXMLGUIClient parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KXMLGUIClient#", "KXMLGUIClient(KXMLGUIClient*)", typeof(void), typeof(KXMLGUIClient), parent);
		}
		/// <remarks>
		///  Retrieves an action of the client by name.  If not found, it looks in its child clients.
		///  This method is provided for convenience, as it uses actionCollection()
		///  to get the action object.
		///    </remarks>		<short>    Retrieves an action of the client by name.</short>
		public QAction Action(string name) {
			return (QAction) interceptor.Invoke("action$", "action(const char*) const", typeof(QAction), typeof(string), name);
		}
		/// <remarks>
		///  Retrieves an action for a given QDomElement. The default
		///  implementation uses the "name" attribute to query the action
		///  object via the other action() method.
		///    </remarks>		<short>    Retrieves an action for a given QDomElement.</short>
		[SmokeMethod("action(const QDomElement&) const")]
		public virtual QAction Action(QDomElement element) {
			return (QAction) interceptor.Invoke("action#", "action(const QDomElement&) const", typeof(QAction), typeof(QDomElement), element);
		}
		/// <remarks>
		///  Retrieves the entire action collection for the GUI client.
		///    </remarks>		<short>    Retrieves the entire action collection for the GUI client.</short>
		[SmokeMethod("actionCollection() const")]
		public virtual KActionCollection ActionCollection() {
			return (KActionCollection) interceptor.Invoke("actionCollection", "actionCollection() const", typeof(KActionCollection));
		}
		/// <remarks>
		/// </remarks>		<return> The componentData ( KComponentData ) for this GUI client.
		///    </return>
		/// 		<short>   </short>
		[SmokeMethod("componentData() const")]
		public virtual KComponentData ComponentData() {
			return (KComponentData) interceptor.Invoke("componentData", "componentData() const", typeof(KComponentData));
		}
		/// <remarks>
		/// </remarks>		<return> The parsed XML in a QDomDocument, set by
		///  setXMLFile() or setXML().
		///  This document describes the layout of the GUI.
		///    </return>
		/// 		<short>   </short>
		[SmokeMethod("domDocument() const")]
		public virtual QDomDocument DomDocument() {
			return (QDomDocument) interceptor.Invoke("domDocument", "domDocument() const", typeof(QDomDocument));
		}
		/// <remarks>
		///  This will return the name of the XML file as set by setXMLFile().
		///  If setXML() is used directly, then this will return NULL.
		///  The filename that this returns is obvious for components as each
		///  component has exactly one XML file.  In non-components, however,
		///  there are usually two: the global file and the local file.  This
		///  function doesn't really care about that, though.  It will always
		///  return the last XML file set.  This, in almost all cases, will
		///  be the local XML file.
		/// </remarks>		<return> The name of the XML file or string()
		///    </return>
		/// 		<short>    This will return the name of the XML file as set by setXMLFile().</short>
		[SmokeMethod("xmlFile() const")]
		public virtual string XmlFile() {
			return (string) interceptor.Invoke("xmlFile", "xmlFile() const", typeof(string));
		}
		[SmokeMethod("localXMLFile() const")]
		public virtual string LocalXMLFile() {
			return (string) interceptor.Invoke("localXMLFile", "localXMLFile() const", typeof(string));
		}
		/// <remarks>
		///    </remarks>		<short>   </short>
		public void SetXMLGUIBuildDocument(QDomDocument doc) {
			interceptor.Invoke("setXMLGUIBuildDocument#", "setXMLGUIBuildDocument(const QDomDocument&)", typeof(void), typeof(QDomDocument), doc);
		}
		/// <remarks>
		///    </remarks>		<short>   </short>
		public QDomDocument XmlguiBuildDocument() {
			return (QDomDocument) interceptor.Invoke("xmlguiBuildDocument", "xmlguiBuildDocument() const", typeof(QDomDocument));
		}
		/// <remarks>
		///  This method is called by the KXMLGUIFactory as soon as the client
		///  is added to the KXMLGUIFactory's GUI.
		///    </remarks>		<short>    This method is called by the KXMLGUIFactory as soon as the client  is added to the KXMLGUIFactory's GUI.</short>
		public void SetFactory(KXMLGUIFactory factory) {
			interceptor.Invoke("setFactory#", "setFactory(KXMLGUIFactory*)", typeof(void), typeof(KXMLGUIFactory), factory);
		}
		/// <remarks>
		///  Retrieves a pointer to the KXMLGUIFactory this client is
		///  associated with (will return null if the client's GUI has not been built
		///  by a KXMLGUIFactory.
		///    </remarks>		<short>    Retrieves a pointer to the KXMLGUIFactory this client is  associated with (will return 0L if the client's GUI has not been built  by a KXMLGUIFactory.</short>
		public KXMLGUIFactory Factory() {
			return (KXMLGUIFactory) interceptor.Invoke("factory", "factory() const", typeof(KXMLGUIFactory));
		}
		/// <remarks>
		///  KXMLGUIClients can form a simple child/parent object tree. This
		///  method returns a pointer to the parent client or null if it has no
		///  parent client assigned.
		///    </remarks>		<short>    KXMLGUIClients can form a simple child/parent object tree.</short>
		public KXMLGUIClient ParentClient() {
			return (KXMLGUIClient) interceptor.Invoke("parentClient", "parentClient() const", typeof(KXMLGUIClient));
		}
		/// <remarks>
		///  Use this method to make a client a child client of another client.
		///  Usually you don't need to call this method, as it is called
		///  automatically when using the second constructor, which takes a
		///  parent argument.
		///    </remarks>		<short>    Use this method to make a client a child client of another client.</short>
		public void InsertChildClient(KXMLGUIClient child) {
			interceptor.Invoke("insertChildClient#", "insertChildClient(KXMLGUIClient*)", typeof(void), typeof(KXMLGUIClient), child);
		}
		/// <remarks>
		///  Removes the given <code>child</code> from the client's children list.
		///    </remarks>		<short>    Removes the given <code>child</code> from the client's children list.</short>
		public void RemoveChildClient(KXMLGUIClient child) {
			interceptor.Invoke("removeChildClient#", "removeChildClient(KXMLGUIClient*)", typeof(void), typeof(KXMLGUIClient), child);
		}
		/// <remarks>
		///  Retrieves a list of all child clients.
		///    </remarks>		<short>    Retrieves a list of all child clients.</short>
		/// <remarks>
		///  A client can have an own KXMLGUIBuilder.
		///  Use this method to assign your builder instance to the client (so that the
		///  KXMLGUIFactory can use it when building the client's GUI)
		///  Client specific guibuilders are useful if you want to create
		///  custom container widgets for your GUI.
		///    </remarks>		<short>    A client can have an own KXMLGUIBuilder.</short>
		public void SetClientBuilder(KXMLGUIBuilder builder) {
			interceptor.Invoke("setClientBuilder#", "setClientBuilder(KXMLGUIBuilder*)", typeof(void), typeof(KXMLGUIBuilder), builder);
		}
		/// <remarks>
		///  Retrieves the client's GUI builder or null if no client specific
		///  builder has been assigned via setClientBuilder()
		///    </remarks>		<short>    Retrieves the client's GUI builder or 0L if no client specific  builder has been assigned via setClientBuilder()    </short>
		public KXMLGUIBuilder ClientBuilder() {
			return (KXMLGUIBuilder) interceptor.Invoke("clientBuilder", "clientBuilder() const", typeof(KXMLGUIBuilder));
		}
		/// <remarks>
		///  Forces this client to re-read its XML resource file.  This is
		///  intended to be used when you know that the resource file has
		///  changed and you will soon be rebuilding the GUI.  It has no
		///  useful effect with non-KParts GUIs, so don't bother using it
		///  unless your app is component based.
		///    </remarks>		<short>    Forces this client to re-read its XML resource file.</short>
		public void ReloadXML() {
			interceptor.Invoke("reloadXML", "reloadXML()", typeof(void));
		}
		/// <remarks>
		///  ActionLists are a way for XMLGUI to support dynamic lists of
		///  actions.  E.g. if you are writing a file manager, and there is a
		///  menu file whose contents depend on the mimetype of the file that
		///  is selected, then you can achieve this using ActionLists. It
		///  works as follows:
		///  In your xxxui.rc file ( the one that you set in setXMLFile() / pass to setupGUI()
		///  ), you put an <p>\<ActionList name="xxx"\></p> tag.  E.g.
		///  <pre>
		///  <kpartgui name="xxx_part" version="1">
		///  <MenuBar>
		///    <Menu name="file">
		///      ...  <!-- some useful actions-->
		///      <ActionList name="xxx_file_actionlist" />
		///      ...  <!-- even more useful actions-->
		///    </Menu>
		///    ...
		///  </MenuBar>
		///  </kpartgui>
		///  </pre>
		///  This tag will get expanded to a list of actions.  In the example
		///  above ( a file manager with a dynamic file menu ), you would call
		///  <pre>
		///  QList<QAction> file_actions;
		///  for( ... )
		///    if( ... )
		///      file_actions.append( cool_action );
		///  unplugActionList( "xxx_file_actionlist" );
		///  plugActionList( "xxx_file_actionlist", file_actions );
		///  </pre>
		///  every time a file is selected, unselected or ...
		///  <b>Note:<> You should not call createGUI() after calling this
		///        function.  In fact, that would remove the newly added
		///        actionlists again...
		///  <b>Note:<> Forgetting to call unplugActionList() before
		///        plugActionList() would leave the previous actions in the
		///        menu too..
		///    </remarks>		<short>    ActionLists are a way for XMLGUI to support dynamic lists of  actions.</short>
		public void PlugActionList(string name, List<QAction> actionList) {
			interceptor.Invoke("plugActionList$?", "plugActionList(const QString&, const QList<QAction*>&)", typeof(void), typeof(string), name, typeof(List<QAction>), actionList);
		}
		/// <remarks>
		///  The complement of plugActionList() ...
		///    </remarks>		<short>    The complement of plugActionList() .</short>
		public void UnplugActionList(string name) {
			interceptor.Invoke("unplugActionList$", "unplugActionList(const QString&)", typeof(void), typeof(string), name);
		}
		public void AddStateActionEnabled(string state, string action) {
			interceptor.Invoke("addStateActionEnabled$$", "addStateActionEnabled(const QString&, const QString&)", typeof(void), typeof(string), state, typeof(string), action);
		}
		public void AddStateActionDisabled(string state, string action) {
			interceptor.Invoke("addStateActionDisabled$$", "addStateActionDisabled(const QString&, const QString&)", typeof(void), typeof(string), state, typeof(string), action);
		}
		public void BeginXMLPlug(QWidget arg1) {
			interceptor.Invoke("beginXMLPlug#", "beginXMLPlug(QWidget*)", typeof(void), typeof(QWidget), arg1);
		}
		public void EndXMLPlug() {
			interceptor.Invoke("endXMLPlug", "endXMLPlug()", typeof(void));
		}
		public void PrepareXMLUnplug(QWidget arg1) {
			interceptor.Invoke("prepareXMLUnplug#", "prepareXMLUnplug(QWidget*)", typeof(void), typeof(QWidget), arg1);
		}
		/// <remarks>
		///  Sets the componentData ( KComponentData) for this part.
		///  Call this first in the inherited class constructor.
		///  (At least before setXMLFile().)
		///    </remarks>		<short>    Sets the componentData ( KComponentData) for this part.</short>
		[SmokeMethod("setComponentData(const KComponentData&)")]
		protected virtual void SetComponentData(KComponentData componentData) {
			interceptor.Invoke("setComponentData#", "setComponentData(const KComponentData&)", typeof(void), typeof(KComponentData), componentData);
		}
		/// <remarks>
		///  Sets the name of the rc file containing the XML for the part.
		///  Call this in the Part-inherited class constructor.
		///  If you're writing usual application, use KXmlGuiWindow.SetupGUI() with non-default arguments
		/// <param> name="file" Either an absolute path for the file, or simply the
		///              filename, which will then be assumed to be installed
		///              in the "data" resource, under a directory named like
		///              the componentData.
		/// </param><param> name="merge" Whether to merge with the global document.
		/// </param><param> name="setXMLDoc" Specify whether to call setXML. Default is true.
		///                and the DOM document at once.
		/// </param></remarks>		<short>    Sets the name of the rc file containing the XML for the part.</short>
		[SmokeMethod("setXMLFile(const QString&, bool, bool)")]
		protected virtual void SetXMLFile(string file, bool merge, bool setXMLDoc) {
			interceptor.Invoke("setXMLFile$$$", "setXMLFile(const QString&, bool, bool)", typeof(void), typeof(string), file, typeof(bool), merge, typeof(bool), setXMLDoc);
		}
		[SmokeMethod("setXMLFile(const QString&, bool)")]
		protected virtual void SetXMLFile(string file, bool merge) {
			interceptor.Invoke("setXMLFile$$", "setXMLFile(const QString&, bool)", typeof(void), typeof(string), file, typeof(bool), merge);
		}
		[SmokeMethod("setXMLFile(const QString&)")]
		protected virtual void SetXMLFile(string file) {
			interceptor.Invoke("setXMLFile$", "setXMLFile(const QString&)", typeof(void), typeof(string), file);
		}
		[SmokeMethod("setLocalXMLFile(const QString&)")]
		protected virtual void SetLocalXMLFile(string file) {
			interceptor.Invoke("setLocalXMLFile$", "setLocalXMLFile(const QString&)", typeof(void), typeof(string), file);
		}
		/// <remarks>
		///  Sets the XML for the part.
		///  Call this in the Part-inherited class constructor if you
		///   don't call setXMLFile().
		/// </remarks>		<short>    Sets the XML for the part.</short>
		[SmokeMethod("setXML(const QString&, bool)")]
		protected virtual void SetXML(string document, bool merge) {
			interceptor.Invoke("setXML$$", "setXML(const QString&, bool)", typeof(void), typeof(string), document, typeof(bool), merge);
		}
		[SmokeMethod("setXML(const QString&)")]
		protected virtual void SetXML(string document) {
			interceptor.Invoke("setXML$", "setXML(const QString&)", typeof(void), typeof(string), document);
		}
		/// <remarks>
		///  Sets the Document for the part, describing the layout of the GUI.
		///  Call this in the Part-inherited class constructor if you don't call
		///  setXMLFile or setXML .
		///    </remarks>		<short>    Sets the Document for the part, describing the layout of the GUI.</short>
		[SmokeMethod("setDOMDocument(const QDomDocument&, bool)")]
		protected virtual void SetDOMDocument(QDomDocument document, bool merge) {
			interceptor.Invoke("setDOMDocument#$", "setDOMDocument(const QDomDocument&, bool)", typeof(void), typeof(QDomDocument), document, typeof(bool), merge);
		}
		[SmokeMethod("setDOMDocument(const QDomDocument&)")]
		protected virtual void SetDOMDocument(QDomDocument document) {
			interceptor.Invoke("setDOMDocument#", "setDOMDocument(const QDomDocument&)", typeof(void), typeof(QDomDocument), document);
		}
		/// <remarks>
		///  Actions can collectively be assigned a "State". To accomplish this
		///  the respective actions are tagged as \<enable\> or \<disable\> in
		///  a \<State\> \</State\> group of the XMLfile. During program execution the
		///  programmer can call stateChanged() to set actions to a defined state.
		/// <param> name="newstate" Name of a State in the XMLfile.
		/// </param><param> name="reverse" If the flag reverse is set to StateReverse, the State is reversed.
		///  (actions to be enabled will be disabled and action to be disabled will be enabled)
		///  Default is reverse=false.
		///    </param></remarks>		<short>    Actions can collectively be assigned a "State".</short>
		[SmokeMethod("stateChanged(const QString&, KXMLGUIClient::ReverseStateChange)")]
		protected virtual void StateChanged(string newstate, KXMLGUIClient.ReverseStateChange reverse) {
			interceptor.Invoke("stateChanged$$", "stateChanged(const QString&, KXMLGUIClient::ReverseStateChange)", typeof(void), typeof(string), newstate, typeof(KXMLGUIClient.ReverseStateChange), reverse);
		}
		[SmokeMethod("stateChanged(const QString&)")]
		protected virtual void StateChanged(string newstate) {
			interceptor.Invoke("stateChanged$", "stateChanged(const QString&)", typeof(void), typeof(string), newstate);
		}
		~KXMLGUIClient() {
			interceptor.Invoke("~KXMLGUIClient", "~KXMLGUIClient()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KXMLGUIClient", "~KXMLGUIClient()", typeof(void));
		}
		public static string FindMostRecentXMLFile(List<string> files, StringBuilder doc) {
			return (string) staticInterceptor.Invoke("findMostRecentXMLFile?$", "findMostRecentXMLFile(const QStringList&, QString&)", typeof(string), typeof(List<string>), files, typeof(StringBuilder), doc);
		}
	}
}
