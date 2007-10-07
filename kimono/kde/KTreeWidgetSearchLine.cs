//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  This class makes it easy to add a search line for filtering the items in
	///  listviews based on a simple text search.
	///  No changes to the application other than instantiating this class with
	///  appropriate QTreeWidgets should be needed.
	///  </remarks>		<short>    This class makes it easy to add a search line for filtering the items in  listviews based on a simple text search.</short>

	[SmokeClass("KTreeWidgetSearchLine")]
	public class KTreeWidgetSearchLine : KLineEdit, IDisposable {
 		protected KTreeWidgetSearchLine(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KTreeWidgetSearchLine), this);
		}
		[Q_PROPERTY("Qt::CaseSensitivity", "caseSensitity")]
		public Qt.CaseSensitivity CaseSensitity {
			get { return (Qt.CaseSensitivity) interceptor.Invoke("caseSensitivity", "caseSensitivity()", typeof(Qt.CaseSensitivity)); }
			set { interceptor.Invoke("setCaseSensitivity$", "setCaseSensitivity(Qt::CaseSensitivity)", typeof(void), typeof(Qt.CaseSensitivity), value); }
		}
		[Q_PROPERTY("bool", "keepParentsVisible")]
		public bool KeepParentsVisible {
			get { return (bool) interceptor.Invoke("keepParentsVisible", "keepParentsVisible()", typeof(bool)); }
			set { interceptor.Invoke("setKeepParentsVisible$", "setKeepParentsVisible(bool)", typeof(void), typeof(bool), value); }
		}
		// QList<QTreeWidget*> treeWidgets(); >>>> NOT CONVERTED
		/// <remarks>
		///  Constructs a KTreeWidgetSearchLine with \a treeWidget being the QTreeWidget to
		///  be filtered.
		///  If \a treeWidget is null then the widget will be disabled until listviews
		///  are set with setTreeWidget(), setTreeWidgets() or added with addTreeWidget().
		///      </remarks>		<short>    Constructs a KTreeWidgetSearchLine with \a treeWidget being the QTreeWidget to  be filtered.</short>
		public KTreeWidgetSearchLine(QWidget parent, QTreeWidget treeWidget) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTreeWidgetSearchLine##", "KTreeWidgetSearchLine(QWidget*, QTreeWidget*)", typeof(void), typeof(QWidget), parent, typeof(QTreeWidget), treeWidget);
		}
		public KTreeWidgetSearchLine(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTreeWidgetSearchLine#", "KTreeWidgetSearchLine(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KTreeWidgetSearchLine() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTreeWidgetSearchLine", "KTreeWidgetSearchLine()", typeof(void));
		}
		/// <remarks>
		///  Constructs a KTreeWidgetSearchLine with \a treeWidgets being the list of
		///  pointers to QTreeWidgets to be filtered.
		///  If \a treeWidgets is empty then the widget will be disabled until listviews
		///  are set with setTreeWidget(), setTreeWidgets() or added with addTreeWidget().
		///      </remarks>		<short>    Constructs a KTreeWidgetSearchLine with \a treeWidgets being the list of  pointers to QTreeWidgets to be filtered.</short>
		public KTreeWidgetSearchLine(QWidget parent, List<QTreeWidget> treeWidgets) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTreeWidgetSearchLine#?", "KTreeWidgetSearchLine(QWidget*, const QList<QTreeWidget*>&)", typeof(void), typeof(QWidget), parent, typeof(List<QTreeWidget>), treeWidgets);
		}
		/// <remarks>
		///  Returns the current list of columns that will be searched.  If the
		///  returned list is empty all visible columns will be searched.
		/// </remarks>		<short>    Returns the current list of columns that will be searched.</short>
		/// 		<see> setSearchColumns</see>
		public List<int> SearchColumns() {
			return (List<int>) interceptor.Invoke("searchColumns", "searchColumns() const", typeof(List<int>));
		}
		/// <remarks>
		///  Returns the listview that is currently filtered by the search.
		///  If there are multiple listviews filtered, it returns 0.
		/// </remarks>		<short>    Returns the listview that is currently filtered by the search.</short>
		/// 		<see> setTreeWidget</see>
		/// 		<see> treeWidgets</see>
		public QTreeWidget TreeWidget() {
			return (QTreeWidget) interceptor.Invoke("treeWidget", "treeWidget() const", typeof(QTreeWidget));
		}
		/// <remarks>
		///  Returns the list of pointers to listviews that are currently filtered by
		///  the search.
		/// </remarks>		<short>    Returns the list of pointers to listviews that are currently filtered by  the search.</short>
		/// 		<see> setTreeWidgets</see>
		/// 		<see> addTreeWidget</see>
		/// 		<see> treeWidget</see>
		/// <remarks>
		///  Adds a QTreeWidget to the list of listviews filtered by this search line.
		///  If \a treeWidget is null then the widget will be disabled.
		/// </remarks>		<short>    Adds a QTreeWidget to the list of listviews filtered by this search line.</short>
		/// 		<see> treeWidget</see>
		/// 		<see> setTreeWidgets</see>
		/// 		<see> removeTreeWidget</see>
		[Q_SLOT("void addTreeWidget(QTreeWidget*)")]
		public void AddTreeWidget(QTreeWidget treeWidget) {
			interceptor.Invoke("addTreeWidget#", "addTreeWidget(QTreeWidget*)", typeof(void), typeof(QTreeWidget), treeWidget);
		}
		/// <remarks>
		///  Removes a QTreeWidget from the list of listviews filtered by this search
		///  line. Does nothing if \a treeWidget is 0 or is not filtered by the quick search
		///  line.
		/// </remarks>		<short>    Removes a QTreeWidget from the list of listviews filtered by this search  line.</short>
		/// 		<see> listVew</see>
		/// 		<see> setTreeWidgets</see>
		/// 		<see> addTreeWidget</see>
		[Q_SLOT("void removeTreeWidget(QTreeWidget*)")]
		public void RemoveTreeWidget(QTreeWidget treeWidget) {
			interceptor.Invoke("removeTreeWidget#", "removeTreeWidget(QTreeWidget*)", typeof(void), typeof(QTreeWidget), treeWidget);
		}
		/// <remarks>
		///  Updates search to only make visible the items that match \a pattern.  If
		///  \a s is null then the line edit's text will be used.
		///      </remarks>		<short>    Updates search to only make visible the items that match \a pattern.</short>
		[Q_SLOT("void updateSearch(const QString&)")]
		[SmokeMethod("updateSearch(const QString&)")]
		public virtual void UpdateSearch(string pattern) {
			interceptor.Invoke("updateSearch$", "updateSearch(const QString&)", typeof(void), typeof(string), pattern);
		}
		[Q_SLOT("void updateSearch()")]
		[SmokeMethod("updateSearch()")]
		public virtual void UpdateSearch() {
			interceptor.Invoke("updateSearch", "updateSearch()", typeof(void));
		}
		/// <remarks>
		///  Make the search case sensitive or case insensitive.
		/// </remarks>		<short>    Make the search case sensitive or case insensitive.</short>
		/// 		<see> caseSenstivity</see>
		[Q_SLOT("void setCaseSensitivity(Qt::CaseSensitivity)")]
		public void SetCaseSensitivity(Qt.CaseSensitivity caseSensitivity) {
			interceptor.Invoke("setCaseSensitivity$", "setCaseSensitivity(Qt::CaseSensitivity)", typeof(void), typeof(Qt.CaseSensitivity), caseSensitivity);
		}
		/// <remarks>
		///  When a search is active on a list that's organized into a tree view if
		///  a parent or ancesestor of an item is does not match the search then it
		///  will be hidden and as such so too will any children that match.
		///  If this is set to true (the default) then the parents of matching items
		///  will be shown.
		/// </remarks>		<short>    When a search is active on a list that's organized into a tree view if  a parent or ancesestor of an item is does not match the search then it  will be hidden and as such so too will any children that match.</short>
		/// 		<see> keepParentsVisible</see>
		[Q_SLOT("void setKeepParentsVisible(bool)")]
		public void SetKeepParentsVisible(bool value) {
			interceptor.Invoke("setKeepParentsVisible$", "setKeepParentsVisible(bool)", typeof(void), typeof(bool), value);
		}
		/// <remarks>
		///  Sets the list of columns to be searched.  The default is to search all,
		///  visible columns which can be restored by passing \a columns as an empty
		///  list.
		///  If listviews to be filtered have different numbers or labels of columns
		///  this method has no effect.
		/// </remarks>		<short>    Sets the list of columns to be searched.</short>
		/// 		<see> searchColumns</see>
		[Q_SLOT("void setSearchColumns(const QList<int>&)")]
		public void SetSearchColumns(List<int> columns) {
			interceptor.Invoke("setSearchColumns?", "setSearchColumns(const QList<int>&)", typeof(void), typeof(List<int>), columns);
		}
		/// <remarks>
		///  Sets the QTreeWidget that is filtered by this search line, replacing any
		///  previously filtered listviews.  If \a treeWidget is null then the widget will be
		///  disabled.
		/// </remarks>		<short>    Sets the QTreeWidget that is filtered by this search line, replacing any  previously filtered listviews.</short>
		/// 		<see> treeWidget</see>
		/// 		<see> setTreeWidgets</see>
		[Q_SLOT("void setTreeWidget(QTreeWidget*)")]
		public void SetTreeWidget(QTreeWidget treeWidget) {
			interceptor.Invoke("setTreeWidget#", "setTreeWidget(QTreeWidget*)", typeof(void), typeof(QTreeWidget), treeWidget);
		}
		/// <remarks>
		///  Sets QTreeWidgets that are filtered by this search line, replacing any
		///  previously filtered listviews.  If \a treeWidgets is empty then the widget will
		///  be disabled.
		/// </remarks>		<short>    Sets QTreeWidgets that are filtered by this search line, replacing any  previously filtered listviews.</short>
		/// 		<see> treeWidgets</see>
		/// 		<see> addTreeWidget</see>
		/// 		<see> setTreeWidget</see>
		[Q_SLOT("void setTreeWidgets(const QList<QTreeWidget*>&)")]
		public void SetTreeWidgets(List<QTreeWidget> treeWidgets) {
			interceptor.Invoke("setTreeWidgets?", "setTreeWidgets(const QList<QTreeWidget*>&)", typeof(void), typeof(List<QTreeWidget>), treeWidgets);
		}
		/// <remarks>
		///  Returns true if \a item matches the search \a pattern.  This will be evaluated
		///  based on the value of caseSensitive().  This can be overridden in
		///  subclasses to implement more complicated matching schemes.
		///      </remarks>		<short>    Returns true if \a item matches the search \a pattern.</short>
		[SmokeMethod("itemMatches(const QTreeWidgetItem*, const QString&) const")]
		protected virtual bool ItemMatches(QTreeWidgetItem item, string pattern) {
			return (bool) interceptor.Invoke("itemMatches#$", "itemMatches(const QTreeWidgetItem*, const QString&) const", typeof(bool), typeof(QTreeWidgetItem), item, typeof(string), pattern);
		}
		/// <remarks>
		///  Re-implemented for internal reasons.  API not affected.
		///     </remarks>		<short>    Re-implemented for internal reasons.</short>
		[SmokeMethod("contextMenuEvent(QContextMenuEvent*)")]
		protected override void ContextMenuEvent(QContextMenuEvent arg1) {
			interceptor.Invoke("contextMenuEvent#", "contextMenuEvent(QContextMenuEvent*)", typeof(void), typeof(QContextMenuEvent), arg1);
		}
		/// <remarks>
		///  Updates search to only make visible appropriate items in \a treeWidget.  If
		///  \a treeWidget is null then nothing is done.
		///      </remarks>		<short>    Updates search to only make visible appropriate items in \a treeWidget.</short>
		[SmokeMethod("updateSearch(QTreeWidget*)")]
		protected virtual void UpdateSearch(QTreeWidget treeWidget) {
			interceptor.Invoke("updateSearch#", "updateSearch(QTreeWidget*)", typeof(void), typeof(QTreeWidget), treeWidget);
		}
		/// <remarks>
		///  Connects signals of this listview to the appropriate slots of the search
		///  line.
		///      </remarks>		<short>    Connects signals of this listview to the appropriate slots of the search  line.</short>
		[SmokeMethod("connectTreeWidget(QTreeWidget*)")]
		protected virtual void ConnectTreeWidget(QTreeWidget arg1) {
			interceptor.Invoke("connectTreeWidget#", "connectTreeWidget(QTreeWidget*)", typeof(void), typeof(QTreeWidget), arg1);
		}
		/// <remarks>
		///  Disconnects signals of a listviews from the search line.
		///      </remarks>		<short>    Disconnects signals of a listviews from the search line.</short>
		[SmokeMethod("disconnectTreeWidget(QTreeWidget*)")]
		protected virtual void DisconnectTreeWidget(QTreeWidget arg1) {
			interceptor.Invoke("disconnectTreeWidget#", "disconnectTreeWidget(QTreeWidget*)", typeof(void), typeof(QTreeWidget), arg1);
		}
		/// <remarks>
		///  Checks columns in all listviews and decides whether choosing columns to
		///  filter on makes any sense.
		///  Returns false if either of the following is true:
		///   there are no listviews connected,
		///   the listviews have different numbers of columns,
		///   the listviews have only one column,
		///   the listviews differ in column labels.
		///  Otherwise it returns true.
		/// </remarks>		<short>    Checks columns in all listviews and decides whether choosing columns to  filter on makes any sense.</short>
		/// 		<see> setSearchColumns</see>
		[SmokeMethod("canChooseColumnsCheck()")]
		protected virtual bool CanChooseColumnsCheck() {
			return (bool) interceptor.Invoke("canChooseColumnsCheck", "canChooseColumnsCheck()", typeof(bool));
		}
		~KTreeWidgetSearchLine() {
			interceptor.Invoke("~KTreeWidgetSearchLine", "~KTreeWidgetSearchLine()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KTreeWidgetSearchLine", "~KTreeWidgetSearchLine()", typeof(void));
		}
		protected new IKTreeWidgetSearchLineSignals Emit {
			get { return (IKTreeWidgetSearchLineSignals) Q_EMIT; }
		}
	}

	public interface IKTreeWidgetSearchLineSignals : IKLineEditSignals {
	}
}
