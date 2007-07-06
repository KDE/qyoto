//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  This is the branch class of the K3FileTreeView, which represents one
	///  branch in the treeview. Every branch has a root which is an url. The branch
	///  lists the files under the root. Every branch uses its own dirlister and can
	///  have its own filter etc.
	///   See <see cref="IKFileTreeBranchSignals"></see> for signals emitted by KFileTreeBranch
	/// </remarks>		<short> Branch object for K3FileTreeView object. </short>

	[SmokeClass("KFileTreeBranch")]
	public class KFileTreeBranch : KDirLister, IDisposable {
 		protected KFileTreeBranch(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KFileTreeBranch), this);
		}
		// KFileTreeBranch* KFileTreeBranch(K3FileTreeView* arg1,const KUrl& arg2,const QString& arg3,const QPixmap& arg4,bool arg5,K3FileTreeViewItem* arg6); >>>> NOT CONVERTED
		// KFileTreeBranch* KFileTreeBranch(K3FileTreeView* arg1,const KUrl& arg2,const QString& arg3,const QPixmap& arg4,bool arg5); >>>> NOT CONVERTED
		// KFileTreeBranch* KFileTreeBranch(K3FileTreeView* arg1,const KUrl& arg2,const QString& arg3,const QPixmap& arg4); >>>> NOT CONVERTED
		// void setRoot(K3FileTreeViewItem* arg1); >>>> NOT CONVERTED
		// K3FileTreeViewItem* root(); >>>> NOT CONVERTED
		// K3FileTreeViewItem* findTVIByUrl(const KUrl& arg1); >>>> NOT CONVERTED
		// bool populate(const KUrl& arg1,K3FileTreeViewItem* arg2); >>>> NOT CONVERTED
		// K3FileTreeViewItem* createTreeViewItem(K3FileTreeViewItem* arg1,KFileItem* arg2); >>>> NOT CONVERTED
		/// <remarks>
		///  constructs a branch for K3FileTreeView. Does not yet start to list it.
		/// <param> name="url" start url of the branch.
		/// </param><param> name="name" the name of the branch, which is displayed in the first column of the treeview.
		/// </param><param> name="pix" is a pixmap to display as an icon of the branch.
		/// </param><param> name="showHidden" flag to make hidden files visible or not.
		/// </param><param> name="branchRoot" is the K3FileTreeViewItem to use as the root of the
		///         branch, with the default 0 meaning to let KFileTreeBranch create
		///         it for you.
		///     </param></remarks>		<short>    constructs a branch for K3FileTreeView.</short>
		/// <remarks>
		/// </remarks>		<return> the root url of the branch.
		///     </return>
		/// 		<short>   </short>
		public KUrl RootUrl() {
			return (KUrl) interceptor.Invoke("rootUrl", "rootUrl() const", typeof(KUrl));
		}
		/// <remarks>
		///  sets a K3FileTreeViewItem as root widget for the branch.
		///  That must be created outside of the branch. All KFileTreeViewItems
		///  the branch is allocating will become children of that object.
		/// <param> name="r" the K3FileTreeViewItem to become the root item.
		///     </param></remarks>		<short>    sets a K3FileTreeViewItem as root widget for the branch.</short>
		/// <remarks>
		/// </remarks>		<return> the root item.
		///     </return>
		/// 		<short>   </short>
		/// <remarks>
		/// </remarks>		<return> the name of the branch.
		///     </return>
		/// 		<short>   </short>
		public string Name() {
			return (string) interceptor.Invoke("name", "name() const", typeof(string));
		}
		/// <remarks>
		///  sets the name of the branch.
		///     </remarks>		<short>    sets the name of the branch.</short>
		[SmokeMethod("setName(const QString)")]
		public virtual void SetName(string n) {
			interceptor.Invoke("setName$", "setName(const QString)", typeof(void), typeof(string), n);
		}
		public QPixmap Pixmap() {
			return (QPixmap) interceptor.Invoke("pixmap", "pixmap() const", typeof(QPixmap));
		}
		public QPixmap OpenPixmap() {
			return (QPixmap) interceptor.Invoke("openPixmap", "openPixmap() const", typeof(QPixmap));
		}
		/// <remarks>
		/// </remarks>		<return> whether the items in the branch show their file extensions in the
		///  tree or not. See setShowExtensions for more information.
		///     </return>
		/// 		<short>   </short>
		public bool ShowExtensions() {
			return (bool) interceptor.Invoke("showExtensions", "showExtensions() const", typeof(bool));
		}
		/// <remarks>
		///  sets the root of the branch open or closed.
		///     </remarks>		<short>    sets the root of the branch open or closed.</short>
		public void SetOpen(bool setopen) {
			interceptor.Invoke("setOpen$", "setOpen(bool)", typeof(void), typeof(bool), setopen);
		}
		public void SetOpen() {
			interceptor.Invoke("setOpen", "setOpen()", typeof(void));
		}
		/// <remarks>
		///  sets if children recursion is wanted or not. If this is switched off, the
		///  child directories of a just opened directory are not listed internally.
		///  That means that it can not be determined if the sub directories are
		///  expandable or not. If this is switched off there will be no call to
		///  setExpandable.
		/// <param> name="t" set to true to switch on child recursion
		///     </param></remarks>		<short>    sets if children recursion is wanted or not.</short>
		public void SetChildRecurse(bool t) {
			interceptor.Invoke("setChildRecurse$", "setChildRecurse(bool)", typeof(void), typeof(bool), t);
		}
		public void SetChildRecurse() {
			interceptor.Invoke("setChildRecurse", "setChildRecurse()", typeof(void));
		}
		/// <remarks>
		/// </remarks>		<return> if child recursion is on or off.
		/// </return>
		/// 		<short>   </short>
		/// 		<see> setChildRecurse</see>
		public bool ChildRecurse() {
			return (bool) interceptor.Invoke("childRecurse", "childRecurse()", typeof(bool));
		}
		/// <remarks>
		///  find the according K3FileTreeViewItem by an url
		///     </remarks>		<short>    find the according K3FileTreeViewItem by an url     </short>
		/// <remarks>
		///  populates a branch. This method must be called after a branch was added
		///  to  a K3FileTreeView using method addBranch.
		/// <param> name="url" is the url of the root item where the branch starts.
		/// </param><param> name="currItem" is the current parent.
		///     </param></remarks>		<short>    populates a branch.</short>
		/// <remarks>
		///  sets printing of the file extensions on or off. If you pass false to this
		///  slot, all items of this branch will not show their file extensions in the
		///  tree.
		/// <param> name="visible" flags if the extensions should be visible or not.
		///     </param></remarks>		<short>    sets printing of the file extensions on or off.</short>
		[Q_SLOT("void setShowExtensions(bool)")]
		[SmokeMethod("setShowExtensions(bool)")]
		public virtual void SetShowExtensions(bool visible) {
			interceptor.Invoke("setShowExtensions$", "setShowExtensions(bool)", typeof(void), typeof(bool), visible);
		}
		[Q_SLOT("void setShowExtensions()")]
		[SmokeMethod("setShowExtensions()")]
		public virtual void SetShowExtensions() {
			interceptor.Invoke("setShowExtensions", "setShowExtensions()", typeof(void));
		}
		[Q_SLOT("void setOpenPixmap(const QPixmap&)")]
		public void SetOpenPixmap(QPixmap pix) {
			interceptor.Invoke("setOpenPixmap#", "setOpenPixmap(const QPixmap&)", typeof(void), typeof(QPixmap), pix);
		}
		/// <remarks>
		///  allocates a K3FileTreeViewItem for the branch
		///  for new items.
		///     </remarks>		<short>    allocates a K3FileTreeViewItem for the branch  for new items.</short>
		~KFileTreeBranch() {
			interceptor.Invoke("~KFileTreeBranch", "~KFileTreeBranch()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KFileTreeBranch", "~KFileTreeBranch()", typeof(void));
		}
		protected new IKFileTreeBranchSignals Emit {
			get { return (IKFileTreeBranchSignals) Q_EMIT; }
		}
	}

	public interface IKFileTreeBranchSignals : IKDirListerSignals {
		// void populateFinished(K3FileTreeViewItem* arg1); >>>> NOT CONVERTED
		// void newTreeViewItems(KFileTreeBranch* arg1,const K3FileTreeViewItemList& arg2); >>>> NOT CONVERTED
		// void directoryChildCount(K3FileTreeViewItem* arg1,int arg2); >>>> NOT CONVERTED
	}
}
