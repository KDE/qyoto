//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;

	/// <remarks>
	///  @brief A generic implementation of the "find" function.
	///  <b></b>etail:
	///  This class includes prompt handling etc. Also provides some
	///  static functions which can be used to create custom behavior
	///  instead of using the class directly.
	///  <b></b>xample:
	///  To use the class to implement a complete find feature:
	///  In the slot connected to the find action, after using KFindDialog:
	///  <pre>
	///   // This creates a find-next-prompt dialog if needed.
	///   m_find = new KFind(pattern, options, this);
	///   // Connect highlight signal to code which handles highlighting
	///   // of found text.
	///   connect( m_find, SIGNAL("highlight( string, int, int )"),
	///           this, SLOT("slotHighlight( string, int, int )") );
	///   // Connect findNext signal - called when pressing the button in the dialog
	///   connect( m_find, SIGNAL("findNext()"),
	///           this, SLOT("slotFindNext()") );
	///  </pre>
	///  If you are using a non-modal find dialog (the recommended new way
	///  in KDE-3.2), you should call right away m_find.CloseFindNextDialog().
	///   Then initialize the variables determining the "current position"
	///   (to the cursor, if the option FromCursor is set,
	///    to the beginning of the selection if the option SelectedText is set,
	///    and to the beginning of the document otherwise).
	///   Initialize the "end of search" variables as well (end of doc or end of selection).
	///   Swap begin and end if FindBackwards.
	///   Finally, call slotFindNext();
	///  <pre>
	///   void slotFindNext()
	///   {
	///       KFind.Result res = KFind.NoMatch;
	///       while ( res == KFind.NoMatch && <position not at end> ) {
	///           if ( m_find.NeedData() )
	///               m_find.SetData( <current text fragment> );
	///           // Let KFind inspect the text fragment, and display a dialog if a match is found
	///           res = m_find.Find();
	///           if ( res == KFind.NoMatch ) {
	///               <Move to the next text fragment, honoring the FindBackwards setting for the direction>
	///           }
	///       }
	///       if ( res == KFind.NoMatch ) // i.e. at end
	///           <Call either  m_find.DisplayFinalDialog(); delete m_find; m_find = null;
	///            or           if ( m_find.ShouldRestart() ) { reinit (w/o FromCursor) and call slotFindNext(); }
	///                         else { m_find.CloseFindNextDialog(); }>
	///   }
	///  </pre>
	///   Don't forget to delete m_find in the destructor of your class,
	///   unless you gave it a parent widget on construction.
	///   This implementation allows to have a "Find Next" action, which resumes the
	///   search, even if the user closed the "Find Next" dialog.
	///   A "Find Previous" action can simply switch temporarily the value of
	///   FindBackwards and call slotFindNext() - and reset the value afterwards.
	///   See <see cref="IKFindSignals"></see> for signals emitted by KFind
	/// </remarks>		<author> S.R.Haque <srhaque@iee.org>, David Faure <faure@kde.org>,
	///          Arend van Beelen jr. <arend@auton.nl>
	/// </author>
	/// 		<short>    @brief A generic implementation of the "find" function.</short>

	[SmokeClass("KFind")]
	public class KFind : QObject, IDisposable {
 		protected KFind(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KFind), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KFind() {
			staticInterceptor = new SmokeInvocation(typeof(KFind), null);
		}
		public enum Options {
			WholeWordsOnly = 1,
			FromCursor = 2,
			SelectedText = 4,
			CaseSensitive = 8,
			FindBackwards = 16,
			RegularExpression = 32,
			FindIncremental = 64,
			MinimumUserOption = 65536,
		}
		public enum Result {
			NoMatch = 0,
			Match = 1,
		}
		/// <remarks>
		///  Only use this constructor if you don't use KFindDialog, or if
		///  you use it as a modal dialog.
		///      </remarks>		<short>    Only use this constructor if you don't use KFindDialog, or if  you use it as a modal dialog.</short>
		public KFind(string pattern, long options, QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFind$$#", "KFind(const QString&, long, QWidget*)", typeof(void), typeof(string), pattern, typeof(long), options, typeof(QWidget), parent);
		}
		/// <remarks>
		/// </remarks>		<return> true if the application must supply a new text fragment
		///  It also means the last call returned "NoMatch". But by storing this here
		///  the application doesn't have to store it in a member variable (between
		///  calls to slotFindNext()).
		///      </return>
		/// 		<short>   </short>
		public bool NeedData() {
			return (bool) interceptor.Invoke("needData", "needData() const", typeof(bool));
		}
		/// <remarks>
		///  Call this when needData returns true, before calling find().
		/// <param> name="data" the text fragment (line)
		/// </param><param> name="startPos" if set, the index at which the search should start.
		///  This is only necessary for the very first call to setData usually,
		///  for the 'find in selection' feature. A value of -1 (the default value)
		///  means "process all the data", i.e. either 0 or data.length()-1 depending
		///  on FindBackwards.
		///      </param></remarks>		<short>    Call this when needData returns true, before calling find().</short>
		public void SetData(string data, int startPos) {
			interceptor.Invoke("setData$$", "setData(const QString&, int)", typeof(void), typeof(string), data, typeof(int), startPos);
		}
		public void SetData(string data) {
			interceptor.Invoke("setData$", "setData(const QString&)", typeof(void), typeof(string), data);
		}
		/// <remarks>
		///  Call this when needData returns true, before calling find(). The use of
		///  ID's is especially useful if you're using the FindIncremental option.
		/// <param> name="id" the id of the text fragment
		/// </param><param> name="data" the text fragment (line)
		/// </param><param> name="startPos" if set, the index at which the search should start.
		///  This is only necessary for the very first call to setData usually,
		///  for the 'find in selection' feature. A value of -1 (the default value)
		///  means "process all the data", i.e. either 0 or data.length()-1 depending
		///  on FindBackwards.
		///      </param></remarks>		<short>    Call this when needData returns true, before calling find().</short>
		public void SetData(int id, string data, int startPos) {
			interceptor.Invoke("setData$$$", "setData(int, const QString&, int)", typeof(void), typeof(int), id, typeof(string), data, typeof(int), startPos);
		}
		public void SetData(int id, string data) {
			interceptor.Invoke("setData$$", "setData(int, const QString&)", typeof(void), typeof(int), id, typeof(string), data);
		}
		/// <remarks>
		///  Walk the text fragment (e.g. text-processor line, kspread cell) looking for matches.
		///  For each match, emits the highlight() signal and displays the find-again dialog
		///  proceeding.
		///      </remarks>		<short>    Walk the text fragment (e.</short>
		public KFind.Result Find() {
			return (KFind.Result) interceptor.Invoke("find", "find()", typeof(KFind.Result));
		}
		/// <remarks>
		///  Return the current options.
		///  Warning: this is usually the same value as the one passed to the constructor,
		///  but options might change _during_ the replace operation:
		///  e.g. the "All" button resets the PromptOnReplace flag.
		///      </remarks>		<short>    Return the current options.</short>
		public long options() {
			return (long) interceptor.Invoke("options", "options() const", typeof(long));
		}
		/// <remarks>
		///  Set new options. Usually this is used for setting or clearing the
		///  FindBackwards options.
		///      </remarks>		<short>    Set new options.</short>
		[SmokeMethod("setOptions(long)")]
		public virtual void SetOptions(long options) {
			interceptor.Invoke("setOptions$", "setOptions(long)", typeof(void), typeof(long), options);
		}
		/// <remarks>
		/// </remarks>		<return> the pattern we're currently looking for
		///      </return>
		/// 		<short>   </short>
		public string Pattern() {
			return (string) interceptor.Invoke("pattern", "pattern() const", typeof(string));
		}
		/// <remarks>
		///  Change the pattern we're looking for
		///      </remarks>		<short>    Change the pattern we're looking for      </short>
		public void SetPattern(string pattern) {
			interceptor.Invoke("setPattern$", "setPattern(const QString&)", typeof(void), typeof(string), pattern);
		}
		/// <remarks>
		///  Return the number of matches found (i.e. the number of times
		///  the highlight signal was emitted).
		///  If 0, can be used in a dialog box to tell the user "no match was found".
		///  The final dialog does so already, unless you used setDisplayFinalDialog(false).
		///      </remarks>		<short>    Return the number of matches found (i.</short>
		public int NumMatches() {
			return (int) interceptor.Invoke("numMatches", "numMatches() const", typeof(int));
		}
		/// <remarks>
		///  Call this to reset the numMatches count
		///  (and the numReplacements count for a KReplace).
		///  Can be useful if reusing the same KReplace for different operations,
		///  or when restarting from the beginning of the document.
		///      </remarks>		<short>    Call this to reset the numMatches count  (and the numReplacements count for a KReplace).</short>
		[SmokeMethod("resetCounts()")]
		public virtual void ResetCounts() {
			interceptor.Invoke("resetCounts", "resetCounts()", typeof(void));
		}
		/// <remarks>
		///  Virtual method, which allows applications to add extra checks for
		///  validating a candidate match. It's only necessary to reimplement this
		///  if the find dialog extension has been used to provide additional
		///  criterias.
		/// <param> name="text" The current text fragment
		/// </param><param> name="index" The starting index where the candidate match was found
		/// </param><param> name="matchedlength" The length of the candidate match
		///      </param></remarks>		<short>    Virtual method, which allows applications to add extra checks for  validating a candidate match.</short>
		[SmokeMethod("validateMatch(const QString&, int, int)")]
		public virtual bool ValidateMatch(string text, int index, int matchedlength) {
			return (bool) interceptor.Invoke("validateMatch$$$", "validateMatch(const QString&, int, int)", typeof(bool), typeof(string), text, typeof(int), index, typeof(int), matchedlength);
		}
		/// <remarks>
		///  Returns true if we should restart the search from scratch.
		///  Can ask the user, or return false (if we already searched the whole document).
		/// <param> name="forceAsking" set to true if the user modified the document during the
		///  search. In that case it makes sense to restart the search again.
		/// </param><param> name="showNumMatches" set to true if the dialog should show the number of
		///  matches. Set to false if the application provides a "find previous" action,
		///  in which case the match count will be erroneous when hitting the end,
		///  and we could even be hitting the beginning of the document (so not all
		///  matches have even been seen).
		///      </param></remarks>		<short>    Returns true if we should restart the search from scratch.</short>
		[SmokeMethod("shouldRestart(bool, bool) const")]
		public virtual bool ShouldRestart(bool forceAsking, bool showNumMatches) {
			return (bool) interceptor.Invoke("shouldRestart$$", "shouldRestart(bool, bool) const", typeof(bool), typeof(bool), forceAsking, typeof(bool), showNumMatches);
		}
		[SmokeMethod("shouldRestart(bool) const")]
		public virtual bool ShouldRestart(bool forceAsking) {
			return (bool) interceptor.Invoke("shouldRestart$", "shouldRestart(bool) const", typeof(bool), typeof(bool), forceAsking);
		}
		[SmokeMethod("shouldRestart() const")]
		public virtual bool ShouldRestart() {
			return (bool) interceptor.Invoke("shouldRestart", "shouldRestart() const", typeof(bool));
		}
		/// <remarks>
		///  Displays the final dialog saying "no match was found", if that was the case.
		///  Call either this or shouldRestart().
		///      </remarks>		<short>    Displays the final dialog saying "no match was found", if that was the case.</short>
		[SmokeMethod("displayFinalDialog() const")]
		public virtual void DisplayFinalDialog() {
			interceptor.Invoke("displayFinalDialog", "displayFinalDialog() const", typeof(void));
		}
		/// <remarks>
		///  Return (or create) the dialog that shows the "find next?" prompt.
		///  Usually you don't need to call this.
		///  One case where it can be useful, is when the user selects the "Find"
		///  menu item while a find operation is under way. In that case, the
		///  program may want to call setActiveWindow() on that dialog.
		///      </remarks>		<short>    Return (or create) the dialog that shows the "find next?" prompt.</short>
		public KDialog FindNextDialog(bool create) {
			return (KDialog) interceptor.Invoke("findNextDialog$", "findNextDialog(bool)", typeof(KDialog), typeof(bool), create);
		}
		public KDialog FindNextDialog() {
			return (KDialog) interceptor.Invoke("findNextDialog", "findNextDialog()", typeof(KDialog));
		}
		/// <remarks>
		///  Close the "find next?" dialog. The application should do this when
		///  the last match was hit. If the application deletes the KFind, then
		///  "find previous" won't be possible anymore.
		///  IMPORTANT: you should also call this if you are using a non-modal
		///  find dialog, to tell KFind not to pop up its own dialog.
		///      </remarks>		<short>    Close the "find next?" dialog.</short>
		public void CloseFindNextDialog() {
			interceptor.Invoke("closeFindNextDialog", "closeFindNextDialog()", typeof(void));
		}
		/// <remarks>
		/// </remarks>		<return> the current matching index ( or -1 ).
		///  Same as the matchingIndex parameter passed to highlight.
		///  You usually don't need to use this, except maybe when updating the current data,
		///  so you need to call setData( newData, index() ).
		///      </return>
		/// 		<short>   </short>
		public int Index() {
			return (int) interceptor.Invoke("index", "index() const", typeof(int));
		}
		protected QWidget ParentWidget() {
			return (QWidget) interceptor.Invoke("parentWidget", "parentWidget() const", typeof(QWidget));
		}
		protected QWidget DialogsParent() {
			return (QWidget) interceptor.Invoke("dialogsParent", "dialogsParent() const", typeof(QWidget));
		}
		[Q_SLOT("void slotFindNext()")]
		protected void SlotFindNext() {
			interceptor.Invoke("slotFindNext", "slotFindNext()", typeof(void));
		}
		[Q_SLOT("void slotDialogClosed()")]
		protected void SlotDialogClosed() {
			interceptor.Invoke("slotDialogClosed", "slotDialogClosed()", typeof(void));
		}
		~KFind() {
			interceptor.Invoke("~KFind", "~KFind()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KFind", "~KFind()", typeof(void));
		}
		/// <remarks>
		///  Search the given string, and returns whether a match was found. If one is,
		///  the length of the string matched is also returned.
		///  A performance optimised version of the function is provided for use
		///  with regular expressions.
		/// <param> name="text" The string to search.
		/// </param><param> name="pattern" The pattern to look for.
		/// </param><param> name="index" The starting index into the string.
		/// </param><param> name="options" The options to use.
		/// </param><param> name="matchedlength" The length of the string that was matched
		/// </param></remarks>		<return> The index at which a match was found, or -1 if no match was found.
		///      </return>
		/// 		<short>    Search the given string, and returns whether a match was found.</short>
		public static int Find(string text, string pattern, int index, long options, ref int matchedlength) {
			StackItem[] stack = new StackItem[6];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(text);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(text);
#endif
#if DEBUG
			stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(pattern);
#else
			stack[2].s_class = (IntPtr) GCHandle.Alloc(pattern);
#endif
			stack[3].s_int = index;
			stack[4].s_long = options;
			stack[5].s_int = matchedlength;
			staticInterceptor.Invoke("find$$$$$", "find(const QString&, const QString&, int, long, int*)", stack);
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[1].s_class);
#else
			((GCHandle) stack[1].s_class).Free();
#endif
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
			((GCHandle) stack[2].s_class).Free();
#endif
			matchedlength = stack[5].s_int;
			return stack[0].s_int;
		}
		public static int Find(string text, QRegExp pattern, int index, long options, ref int matchedlength) {
			StackItem[] stack = new StackItem[6];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(text);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(text);
#endif
#if DEBUG
			stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(pattern);
#else
			stack[2].s_class = (IntPtr) GCHandle.Alloc(pattern);
#endif
			stack[3].s_int = index;
			stack[4].s_long = options;
			stack[5].s_int = matchedlength;
			staticInterceptor.Invoke("find$#$$$", "find(const QString&, const QRegExp&, int, long, int*)", stack);
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[1].s_class);
#else
			((GCHandle) stack[1].s_class).Free();
#endif
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
			((GCHandle) stack[2].s_class).Free();
#endif
			matchedlength = stack[5].s_int;
			return stack[0].s_int;
		}
		protected new IKFindSignals Emit {
			get { return (IKFindSignals) Q_EMIT; }
		}
	}

	public interface IKFindSignals : IQObjectSignals {
		/// <remarks>
		///  Connect to this signal to implement highlighting of found text during the find
		///  operation.
		///  If you've set data with setData(id, text), use the signal highlight(id,
		///  matchingIndex, matchedLength)
		///  WARNING: If you're using the FindIncremental option, the text argument
		///  passed by this signal is not necessarily the data last set through
		///  setData(), but can also be an earlier set data block.
		/// </remarks>		<short>    Connect to this signal to implement highlighting of found text during the find  operation.</short>
		/// 		<see> setData</see>
		[Q_SIGNAL("void highlight(const QString&, int, int)")]
		void Highlight(string text, int matchingIndex, int matchedLength);
		/// <remarks>
		///  Connect to this signal to implement highlighting of found text during the find
		///  operation.
		///  Use this signal if you've set your data with setData(id, text), otherwise
		///  use the signal with highlight(text, matchingIndex, matchedLength).
		///  WARNING: If you're using the FindIncremental option, the id argument
		///  passed by this signal is not necessarily the id of the data last set
		///  through setData(), but can also be of an earlier set data block.
		/// </remarks>		<short>    Connect to this signal to implement highlighting of found text during the find  operation.</short>
		/// 		<see> setData</see>
		[Q_SIGNAL("void highlight(int, int, int)")]
		void Highlight(int id, int matchingIndex, int matchedLength);
		[Q_SIGNAL("void findNext()")]
		void FindNext();
		/// <remarks>
		///  Emitted when the options have changed.
		///  This can happen e.g. with "Replace All", or if our 'find next' dialog
		///  gets a "find previous" one day.
		///      </remarks>		<short>    Emitted when the options have changed.</short>
		[Q_SIGNAL("void optionsChanged()")]
		void OptionsChanged();
		/// <remarks>
		///  Emitted when the 'find next' dialog is being closed.
		///  Some apps might want to remove the highlighted text when this happens.
		///  Apps without support for "Find Next" can also do m_find.DeleteLater()
		///  to terminate the find operation.
		///      </remarks>		<short>    Emitted when the 'find next' dialog is being closed.</short>
		[Q_SIGNAL("void dialogClosed()")]
		void DialogClosed();
	}
}
