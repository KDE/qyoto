//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  A pretty dialog for a KDirSelect control for selecting directories.
	/// </remarks>		<author> Michael Jarrett <michaelj@corel.com>
	/// </author>
	/// 		<short>    A pretty dialog for a KDirSelect control for selecting directories.</short>
	/// 		<see> KFileDialog</see>

	[SmokeClass("KDirSelectDialog")]
	public class KDirSelectDialog : KDialog, IDisposable {
 		protected KDirSelectDialog(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KDirSelectDialog), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KDirSelectDialog() {
			staticInterceptor = new SmokeInvocation(typeof(KDirSelectDialog), null);
		}
		// K3FileTreeView* view(); >>>> NOT CONVERTED
		/// <remarks>
		///  The constructor. Creates a dialog to select a directory (url).
		/// <param> name="startDir" the directory, initially shown
		/// </param><param> name="localOnly" unused. You can only select paths below the startDir
		/// </param><param> name="parent" the parent for the dialog, usually null
		///      </param></remarks>		<short>    The constructor.</short>
		public KDirSelectDialog(KUrl startDir, bool localOnly, QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDirSelectDialog#$#", "KDirSelectDialog(const KUrl&, bool, QWidget*)", typeof(void), typeof(KUrl), startDir, typeof(bool), localOnly, typeof(QWidget), parent);
		}
		public KDirSelectDialog(KUrl startDir, bool localOnly) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDirSelectDialog#$", "KDirSelectDialog(const KUrl&, bool)", typeof(void), typeof(KUrl), startDir, typeof(bool), localOnly);
		}
		public KDirSelectDialog(KUrl startDir) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDirSelectDialog#", "KDirSelectDialog(const KUrl&)", typeof(void), typeof(KUrl), startDir);
		}
		public KDirSelectDialog() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDirSelectDialog", "KDirSelectDialog()", typeof(void));
		}
		/// <remarks>
		///  Returns the currently-selected URL, or a blank URL if none is selected.
		/// </remarks>		<return> The currently-selected URL, if one was selected.
		///      </return>
		/// 		<short>    Returns the currently-selected URL, or a blank URL if none is selected.</short>
		public KUrl Url() {
			return (KUrl) interceptor.Invoke("url", "url() const", typeof(KUrl));
		}
		public bool LocalOnly() {
			return (bool) interceptor.Invoke("localOnly", "localOnly() const", typeof(bool));
		}
		/// <remarks>
		/// </remarks>		<return> The path for the root node
		///      </return>
		/// 		<short>   </short>
		public KUrl StartDir() {
			return (KUrl) interceptor.Invoke("startDir", "startDir() const", typeof(KUrl));
		}
		[Q_SLOT("void setCurrentUrl(const KUrl&)")]
		public void SetCurrentUrl(KUrl url) {
			interceptor.Invoke("setCurrentUrl#", "setCurrentUrl(const KUrl&)", typeof(void), typeof(KUrl), url);
		}
		[SmokeMethod("accept()")]
		protected new virtual void Accept() {
			interceptor.Invoke("accept", "accept()", typeof(void));
		}
		[Q_SLOT("void slotUser1()")]
		[SmokeMethod("slotUser1()")]
		protected virtual void SlotUser1() {
			interceptor.Invoke("slotUser1", "slotUser1()", typeof(void));
		}
		~KDirSelectDialog() {
			interceptor.Invoke("~KDirSelectDialog", "~KDirSelectDialog()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KDirSelectDialog", "~KDirSelectDialog()", typeof(void));
		}
		/// <remarks>
		///  Creates a KDirSelectDialog, and returns the result.
		/// <param> name="startDir" the directory, initially shown
		///  The tree will display this directory and subdirectories of it.
		/// </param><param> name="localOnly" unused. You can only select paths below the startDir
		/// </param><param> name="parent" the parent widget to use for the dialog, or NULL to create a parent-less dialog
		/// </param><param> name="caption" the caption to use for the dialog, or string() for the default caption
		/// </param></remarks>		<return> The URL selected, or an empty URL if the user canceled
		///  or no URL was selected.
		///      </return>
		/// 		<short>    Creates a KDirSelectDialog, and returns the result.</short>
		public static KUrl SelectDirectory(KUrl startDir, bool localOnly, QWidget parent, string caption) {
			return (KUrl) staticInterceptor.Invoke("selectDirectory#$#$", "selectDirectory(const KUrl&, bool, QWidget*, const QString&)", typeof(KUrl), typeof(KUrl), startDir, typeof(bool), localOnly, typeof(QWidget), parent, typeof(string), caption);
		}
		public static KUrl SelectDirectory(KUrl startDir, bool localOnly, QWidget parent) {
			return (KUrl) staticInterceptor.Invoke("selectDirectory#$#", "selectDirectory(const KUrl&, bool, QWidget*)", typeof(KUrl), typeof(KUrl), startDir, typeof(bool), localOnly, typeof(QWidget), parent);
		}
		public static KUrl SelectDirectory(KUrl startDir, bool localOnly) {
			return (KUrl) staticInterceptor.Invoke("selectDirectory#$", "selectDirectory(const KUrl&, bool)", typeof(KUrl), typeof(KUrl), startDir, typeof(bool), localOnly);
		}
		public static KUrl SelectDirectory(KUrl startDir) {
			return (KUrl) staticInterceptor.Invoke("selectDirectory#", "selectDirectory(const KUrl&)", typeof(KUrl), typeof(KUrl), startDir);
		}
		public static KUrl SelectDirectory() {
			return (KUrl) staticInterceptor.Invoke("selectDirectory", "selectDirectory()", typeof(KUrl));
		}
		protected new IKDirSelectDialogSignals Emit {
			get { return (IKDirSelectDialogSignals) Q_EMIT; }
		}
	}

	public interface IKDirSelectDialogSignals : IKDialogSignals {
	}
}
