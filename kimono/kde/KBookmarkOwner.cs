//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  The KBookmarkMenu and KBookmarkBar classes gives the user
	///  the ability to either edit bookmarks or add their own.  In the
	///  first case, the app may want to open the bookmark in a special way.
	///  In the second case, the app <em>must</em> supply the name and the
	///  URL for the bookmark.
	///  This class gives the app this callback-like ability.
	///  If your app does not give the user the ability to add bookmarks and
	///  you don't mind using the default bookmark editor to edit your
	///  bookmarks, then you don't need to overload this class at all.
	///  Rather, just use something like:
	///  <CODE>
	///  bookmarks = new KBookmarkMenu( mgr, 0, menu, actioncollec  )
	///  </CODE>
	///  If you wish to use your own editor or allow the user to add
	///  bookmarks, you must overload this class.
	///  </remarks>		<short>    The KBookmarkMenu and KBookmarkBar classes gives the user  the ability to either edit bookmarks or add their own.</short>

	[SmokeClass("KBookmarkOwner")]
	public abstract class KBookmarkOwner : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KBookmarkOwner(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KBookmarkOwner), this);
		}
		/// <remarks>
		///  This function is called whenever the user wants to add the
		///  current page to the bookmarks list.  The title will become the
		///  "name" of the bookmark.  You must overload this function if you
		///  wish to give your users the ability to add bookmarks.
		/// </remarks>		<return> the title of the current page.
		///    </return>
		/// 		<short>    This function is called whenever the user wants to add the  current page to the bookmarks list.</short>
		[SmokeMethod("currentTitle() const")]
		public virtual string CurrentTitle() {
			return (string) interceptor.Invoke("currentTitle", "currentTitle() const", typeof(string));
		}
		/// <remarks>
		///  This function is called whenever the user wants to add the
		///  current page to the bookmarks list.  The URL will become the URL
		///  of the bookmark.  You must overload this function if you wish to
		///  give your users the ability to add bookmarks.
		/// </remarks>		<return> the URL of the current page.
		///    </return>
		/// 		<short>    This function is called whenever the user wants to add the  current page to the bookmarks list.</short>
		[SmokeMethod("currentUrl() const")]
		public virtual string CurrentUrl() {
			return (string) interceptor.Invoke("currentUrl", "currentUrl() const", typeof(string));
		}
		/// <remarks>
		///  This function returns whether the owner supports tabs.
		///    </remarks>		<short>    This function returns whether the owner supports tabs.</short>
		[SmokeMethod("supportsTabs() const")]
		public virtual bool SupportsTabs() {
			return (bool) interceptor.Invoke("supportsTabs", "supportsTabs() const", typeof(bool));
		}
		/// <remarks>
		///  Returns a list of title, URL pairs of the open tabs.
		///    </remarks>		<short>    Returns a list of title, URL pairs of the open tabs.</short>
		[SmokeMethod("currentBookmarkList() const")]
		public virtual List<QPair<string, string>> CurrentBookmarkList() {
			return (List<QPair<string, string>>) interceptor.Invoke("currentBookmarkList", "currentBookmarkList() const", typeof(List<QPair<string, string>>));
		}
		/// <remarks>
		///  Returns true if the bookmark menu/toolbar should show an "Add Bookmark" Entry
		///    </remarks>		<short>    Returns true if the bookmark menu/toolbar should show an "Add Bookmark" Entry    </short>
		[SmokeMethod("addBookmarkEntry() const")]
		public virtual bool AddBookmarkEntry() {
			return (bool) interceptor.Invoke("addBookmarkEntry", "addBookmarkEntry() const", typeof(bool));
		}
		/// <remarks>
		///  Returns true if the bookmark menu/toolbar should show an "Edit Bookmarks" Entry
		///    </remarks>		<short>    Returns true if the bookmark menu/toolbar should show an "Edit Bookmarks" Entry    </short>
		[SmokeMethod("editBookmarkEntry() const")]
		public virtual bool EditBookmarkEntry() {
			return (bool) interceptor.Invoke("editBookmarkEntry", "editBookmarkEntry() const", typeof(bool));
		}
		/// <remarks>
		///  Called if a bookmark is selected. You need to override this.
		///    </remarks>		<short>    Called if a bookmark is selected.</short>
		[SmokeMethod("openBookmark(const KBookmark&, Qt::MouseButtons, Qt::KeyboardModifiers)")]
		public abstract void OpenBookmark(KBookmark bm, int mb, int km);
		public KBookmarkOwner() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KBookmarkOwner", "KBookmarkOwner()", typeof(void));
		}
	}
}
