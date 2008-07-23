//Auto-generated by kalyptus. DO NOT EDIT.
namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    using System.Collections.Generic;
    /// <remarks>
    ///  \brief A Document extension interface for handling SmartCursor%s and SmartRange%s.
    ///  \ingroup kte_group_doc_extensions
    ///  Topics:
    ///   - \ref smartiface_intro
    ///   - \ref smartiface_creation
    ///   - \ref smartiface_highlight
    ///   - \ref smartiface_action
    ///   - \ref smartiface_access
    ///  \section smartiface_intro Introduction
    ///  Use this interface to:
    ///  <li>create</li> new SmartCursor%s and SmartRange%s;
    ///  <li>create</li> arbitrary highlighting; and
    ///  <li>associate</li> KAction%s with ranges of text
    ///  \section smartiface_creation Creation of SmartCursors and SmartRanges
    ///  These functions must be used to create SmartCursor%s and SmartRange%s.  This
    ///  means that these objects cannot be derived from by third party applications.
    ///  You then own these objects; upon deletion they de-register themselves from
    ///  the Document with which they were associated.  Alternatively, they are all
    ///  deleted with the deletion of the owning Document.
    ///  \section smartiface_highlight Arbitrary Highlighting
    ///  Arbitrary highlighting of text can be achieved by creating SmartRange%s in a
    ///  tree structure, and assigning appropriate Attributes to these ranges.
    ///  To highlight all views, use addHighlightToDocument(); to highlight one or some
    ///  of the views, use addHighlightToView().  You only need to call this function once
    ///  per tree; just supply the top range you want to have highlighted.  Calling
    ///  this function more than once with ranges from the same tree may give undefined results.
    ///  \section smartiface_action Action Binding
    ///  Action binding can be used to associate KAction%s with specific ranges of text.
    ///  These bound actions are automatically enabled and disabled when the caret enters
    ///  their associated ranges, and context menus are automatically populated with the
    ///  relevant actions.
    ///  As with the arbitrary highlighting interface, to enable bound actions to be active,
    ///  call addActionsToDocument() or addActionsToView() on the top SmartRange of a tree.
    ///  If only small branches of a tree contain actions, it may be more efficient to simply add
    ///  each of these branches instead (but this is unlikely unless the tree is complex).
    ///  Note that actions can be bound either directly to the range via
    ///  SmartRange.AssociateAction(), or indirectly via
    ///  Attribute.AssociateAction(). Using attributes may be more convenient when
    ///  you want all ranges of a specific type to have the same action associated
    ///  with them.
    ///  \todo extend this to provide a signal from the action indicating which range was
    ///        used to activate it (if possible)
    ///  \section smartiface_access Accessing the Interface
    ///  The SmartInterface is supposed to be an extension interface for a Document,
    ///  i.e. the Document inherits the interface \e provided that the
    ///  KTextEditor library in use implements the interface. Use dynamic_cast to access
    ///  the interface:
    ///  <pre>
    ///  // doc is of type KTextEditor.Document
    ///  KTextEditor.SmartInterface iface =
    ///      qobject_cast<KTextEditor.SmartInterface>( doc );
    ///  if( iface ) {
    ///      // the implementation supports the interface
    ///      // do stuff
    ///  }
    ///  </pre>
    ///  \section smartiface_threadsafety Thread safety
    ///  The smart interface is designed to be usable in multithreaded environments.
    ///  If you use the interface from threads other than the main thread, you must
    ///  lock the smartMutex() whenever you are making a non-const call to a smart object.
    ///  This allows the text editor to guarantee that the objects will not change
    ///  when it locks the mutex (for example, when performing layout or rendering).
    ///  \author Hamish Rodda \<rodda@kde.org\>
    ///  </remarks>        <short>    \brief A Document extension interface for handling SmartCursor%s and SmartRange%s.</short>
    [SmokeClass("KTextEditor::SmartInterface")]
    public abstract class SmartInterface : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected SmartInterface(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(SmartInterface), this);
        }
        // QMutex* smartMutex(); >>>> NOT CONVERTED
        public SmartInterface() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("SmartInterface", "SmartInterface()", typeof(void));
        }
        /// <remarks>
        ///  Provides access to the recursive mutex used to protect write access to
        ///  smart interface objects (cursors + ranges and their associated properties).
        ///  If you use this interface  from a thread other than the main thread,
        ///  you must lock this mutex whenever you call a non-const function on a smart object.
        ///      </remarks>        <short>    Provides access to the recursive mutex used to protect write access to  smart interface objects (cursors + ranges and their associated properties).</short>
        /// <remarks>
        ///  Clears or deletes all instances of smart objects, ie:
        ///  <li>deletes</li> all SmartCursor%s
        ///  <li>deletes</li> all SmartRange%s
        ///  <li>clears</li> all arbitrary highlight ranges
        ///  <li>clears</li> all action binding
        ///  Deletion occurs without modification to the underlying text.
        ///      </remarks>        <short>    Clears or deletes all instances of smart objects, ie:  \li deletes all SmartCursor%s  \li deletes all SmartRange%s  \li clears all arbitrary highlight ranges  \li clears all action binding </short>
        [SmokeMethod("clearSmartInterface()")]
        public abstract void ClearSmartInterface();
        /// <remarks>
        ///  Returns whether the smart interface will be cleared on reload of the document.
        ///  Defaults to true.
        ///      </remarks>        <short>    Returns whether the smart interface will be cleared on reload of the document.</short>
        public bool ClearOnDocumentReload() {
            return (bool) interceptor.Invoke("clearOnDocumentReload", "clearOnDocumentReload() const", typeof(bool));
        }
        /// <remarks>
        ///  Specify whether the smart interface should be cleared on reload of the document.
        ///  \param clearOnReload set to true to enable clearing of the smart interface on reload (the default).
        ///      </remarks>        <short>    Specify whether the smart interface should be cleared on reload of the document.</short>
        public void SetClearOnDocumentReload(bool clearOnReload) {
            interceptor.Invoke("setClearOnDocumentReload$", "setClearOnDocumentReload(bool)", typeof(void), typeof(bool), clearOnReload);
        }
        /// <remarks>
        ///  Retrieve a token representing the current version of the document. This can
        ///  be used later to create cursors and ranges as they would have been at this revision.
        ///  Once you have finished with the token, release it with releaseRevision();
        ///      </remarks>        <short>    Retrieve a token representing the current version of the document.</short>
        [SmokeMethod("currentRevision() const")]
        public abstract int CurrentRevision();
        /// <remarks>
        ///  Release a revision token provided by currentRevision().  You will no longer be able to
        ///  create cursors and ranges agaist this revision.
        ///      </remarks>        <short>    Release a revision token provided by currentRevision().</short>
        [SmokeMethod("releaseRevision(int) const")]
        public abstract void ReleaseRevision(int revision);
        /// <remarks>
        ///  Tell the smart interface to work against the given \a revision when creating cursors and
        ///  ranges.
        ///  \param revision the token representing a revision retrieved by currentRevision(), or -1 to
        ///                  clear any previous setting and use the current document revision.
        ///      </remarks>        <short>    Tell the smart interface to work against the given \a revision when creating cursors and  ranges.</short>
        [SmokeMethod("useRevision(int)")]
        public abstract void UseRevision(int revision);
        /// <remarks>
        ///  Clear any previous setting to use a specific revision.
        ///      </remarks>        <short>    Clear any previous setting to use a specific revision.</short>
        public void ClearRevision() {
            interceptor.Invoke("clearRevision", "clearRevision()", typeof(void));
        }
        /// <remarks>
        ///  Translate the given \a cursor against the revision specified through useRevision(),
        ///  using the given \a insertBehavior.
        ///  If no revision is set, simply returns the cursor.
        ///      </remarks>        <short>    Translate the given \a cursor against the revision specified through useRevision(),  using the given \a insertBehavior.</short>
        [SmokeMethod("translateFromRevision(const KTextEditor::Cursor&, KTextEditor::SmartCursor::InsertBehavior) const")]
        public virtual KTextEditor.Cursor TranslateFromRevision(KTextEditor.Cursor cursor, KTextEditor.SmartCursor.InsertBehavior insertBehavior) {
            return (KTextEditor.Cursor) interceptor.Invoke("translateFromRevision#$", "translateFromRevision(const KTextEditor::Cursor&, KTextEditor::SmartCursor::InsertBehavior) const", typeof(KTextEditor.Cursor), typeof(KTextEditor.Cursor), cursor, typeof(KTextEditor.SmartCursor.InsertBehavior), insertBehavior);
        }
        [SmokeMethod("translateFromRevision(const KTextEditor::Cursor&) const")]
        public virtual KTextEditor.Cursor TranslateFromRevision(KTextEditor.Cursor cursor) {
            return (KTextEditor.Cursor) interceptor.Invoke("translateFromRevision#", "translateFromRevision(const KTextEditor::Cursor&) const", typeof(KTextEditor.Cursor), typeof(KTextEditor.Cursor), cursor);
        }
        /// <remarks>
        ///  Translate the given \a range against the revision specified through useRevision(),
        ///  using the given \a insertBehavior.
        ///  If no revision is set, simply returns the range.
        ///      </remarks>        <short>    Translate the given \a range against the revision specified through useRevision(),  using the given \a insertBehavior.</short>
        [SmokeMethod("translateFromRevision(const KTextEditor::Range&, KTextEditor::SmartRange::InsertBehaviors) const")]
        public virtual KTextEditor.Range TranslateFromRevision(KTextEditor.Range range, uint insertBehavior) {
            return (KTextEditor.Range) interceptor.Invoke("translateFromRevision#$", "translateFromRevision(const KTextEditor::Range&, KTextEditor::SmartRange::InsertBehaviors) const", typeof(KTextEditor.Range), typeof(KTextEditor.Range), range, typeof(uint), insertBehavior);
        }
        [SmokeMethod("translateFromRevision(const KTextEditor::Range&) const")]
        public virtual KTextEditor.Range TranslateFromRevision(KTextEditor.Range range) {
            return (KTextEditor.Range) interceptor.Invoke("translateFromRevision#", "translateFromRevision(const KTextEditor::Range&) const", typeof(KTextEditor.Range), typeof(KTextEditor.Range), range);
        }
        /// <remarks>
        ///  Creates a new SmartCursor.
        ///  You own this object, and may delete it when you are finished with it.
        ///  Alternatively, you may call the various clear methods, or wait for the Document
        ///  to be destroyed.
        ///  \param position The initial cursor position assumed by the new cursor.
        ///                  If not specified, it will start at position (0, 0).
        ///  \param insertBehavior Define whether the cursor should move when text is inserted at the cursor position.
        ///      </remarks>        <short>    Creates a new SmartCursor.</short>
        [SmokeMethod("newSmartCursor(const KTextEditor::Cursor&, KTextEditor::SmartCursor::InsertBehavior)")]
        public abstract KTextEditor.SmartCursor NewSmartCursor(KTextEditor.Cursor position, KTextEditor.SmartCursor.InsertBehavior insertBehavior);
        /// <remarks>
        ///  \overload
        ///  \n \n
        ///  Creates a new SmartCursor.
        ///  You own this object, and may delete it when you are finished with it.
        ///  Alternatively, you may call the various clear methods, or wait for the Document
        ///  to be destroyed.
        ///  \param line the line number of the cursor's initial position
        ///  \param column the line number of the cursor's initial position
        ///  \param insertBehavior Define whether the cursor should move when text is inserted at the cursor position.
        ///      </remarks>        <short>    \overload  \n \n  Creates a new SmartCursor.</short>
        public KTextEditor.SmartCursor NewSmartCursor(int line, int column, KTextEditor.SmartCursor.InsertBehavior insertBehavior) {
            return (KTextEditor.SmartCursor) interceptor.Invoke("newSmartCursor$$$", "newSmartCursor(int, int, KTextEditor::SmartCursor::InsertBehavior)", typeof(KTextEditor.SmartCursor), typeof(int), line, typeof(int), column, typeof(KTextEditor.SmartCursor.InsertBehavior), insertBehavior);
        }
        public KTextEditor.SmartCursor NewSmartCursor(int line, int column) {
            return (KTextEditor.SmartCursor) interceptor.Invoke("newSmartCursor$$", "newSmartCursor(int, int)", typeof(KTextEditor.SmartCursor), typeof(int), line, typeof(int), column);
        }
        /// <remarks>
        ///  Delete all SmartCursor%s from this document, with the exception of those
        ///  cursors currently bound to ranges.
        ///      </remarks>        <short>    Delete all SmartCursor%s from this document, with the exception of those  cursors currently bound to ranges.</short>
        [SmokeMethod("deleteCursors()")]
        public abstract void DeleteCursors();
        /// <remarks>
        ///  Creates a new SmartRange.
        ///  \param range The initial text range assumed by the new range.
        ///  \param parent The parent SmartRange, if this is to be the child of an existing range.
        ///  \param insertBehavior Define whether the range should expand when text is inserted adjacent to the range.
        ///      </remarks>        <short>    Creates a new SmartRange.</short>
        [SmokeMethod("newSmartRange(const KTextEditor::Range&, KTextEditor::SmartRange*, KTextEditor::SmartRange::InsertBehaviors)")]
        public abstract KTextEditor.SmartRange NewSmartRange(KTextEditor.Range range, KTextEditor.SmartRange parent, uint insertBehavior);
        /// <remarks>
        ///  \overload
        ///  \n \n
        ///  Creates a new SmartRange.
        ///  \param startPosition The start position assumed by the new range.
        ///  \param endPosition The end position assumed by the new range.
        ///  \param parent The parent SmartRange, if this is to be the child of an existing range.
        ///  \param insertBehavior Define whether the range should expand when text is inserted adjacent to the range.
        ///      </remarks>        <short>    \overload  \n \n  Creates a new SmartRange.</short>
        public KTextEditor.SmartRange NewSmartRange(KTextEditor.Cursor startPosition, KTextEditor.Cursor endPosition, KTextEditor.SmartRange parent, uint insertBehavior) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange###$", "newSmartRange(const KTextEditor::Cursor&, const KTextEditor::Cursor&, KTextEditor::SmartRange*, KTextEditor::SmartRange::InsertBehaviors)", typeof(KTextEditor.SmartRange), typeof(KTextEditor.Cursor), startPosition, typeof(KTextEditor.Cursor), endPosition, typeof(KTextEditor.SmartRange), parent, typeof(uint), insertBehavior);
        }
        public KTextEditor.SmartRange NewSmartRange(KTextEditor.Cursor startPosition, KTextEditor.Cursor endPosition, KTextEditor.SmartRange parent) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange###", "newSmartRange(const KTextEditor::Cursor&, const KTextEditor::Cursor&, KTextEditor::SmartRange*)", typeof(KTextEditor.SmartRange), typeof(KTextEditor.Cursor), startPosition, typeof(KTextEditor.Cursor), endPosition, typeof(KTextEditor.SmartRange), parent);
        }
        public KTextEditor.SmartRange NewSmartRange(KTextEditor.Cursor startPosition, KTextEditor.Cursor endPosition) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange##", "newSmartRange(const KTextEditor::Cursor&, const KTextEditor::Cursor&)", typeof(KTextEditor.SmartRange), typeof(KTextEditor.Cursor), startPosition, typeof(KTextEditor.Cursor), endPosition);
        }
        /// <remarks>
        ///  \overload
        ///  \n \n
        ///  Creates a new SmartRange.
        ///  \param startLine The start line assumed by the new range.
        ///  \param startColumn The start column assumed by the new range.
        ///  \param endLine The end line assumed by the new range.
        ///  \param endColumn The end column assumed by the new range.
        ///  \param parent The parent SmartRange, if this is to be the child of an existing range.
        ///  \param insertBehavior Define whether the range should expand when text is inserted adjacent to the range.
        ///      </remarks>        <short>    \overload  \n \n  Creates a new SmartRange.</short>
        public KTextEditor.SmartRange NewSmartRange(int startLine, int startColumn, int endLine, int endColumn, KTextEditor.SmartRange parent, uint insertBehavior) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange$$$$#$", "newSmartRange(int, int, int, int, KTextEditor::SmartRange*, KTextEditor::SmartRange::InsertBehaviors)", typeof(KTextEditor.SmartRange), typeof(int), startLine, typeof(int), startColumn, typeof(int), endLine, typeof(int), endColumn, typeof(KTextEditor.SmartRange), parent, typeof(uint), insertBehavior);
        }
        public KTextEditor.SmartRange NewSmartRange(int startLine, int startColumn, int endLine, int endColumn, KTextEditor.SmartRange parent) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange$$$$#", "newSmartRange(int, int, int, int, KTextEditor::SmartRange*)", typeof(KTextEditor.SmartRange), typeof(int), startLine, typeof(int), startColumn, typeof(int), endLine, typeof(int), endColumn, typeof(KTextEditor.SmartRange), parent);
        }
        public KTextEditor.SmartRange NewSmartRange(int startLine, int startColumn, int endLine, int endColumn) {
            return (KTextEditor.SmartRange) interceptor.Invoke("newSmartRange$$$$", "newSmartRange(int, int, int, int)", typeof(KTextEditor.SmartRange), typeof(int), startLine, typeof(int), startColumn, typeof(int), endLine, typeof(int), endColumn);
        }
        /// <remarks>
        ///  Creates a new SmartRange from pre-existing SmartCursor%s.  The cursors must not be part of any other range.
        ///  \param start Start SmartCursor
        ///  \param end End SmartCursor
        ///  \param parent The parent SmartRange, if this is to be the child of an existing range.
        ///  \param insertBehavior Define whether the range should expand when text is inserted at ends of the range.
        ///      </remarks>        <short>    Creates a new SmartRange from pre-existing SmartCursor%s.</short>
        [SmokeMethod("newSmartRange(KTextEditor::SmartCursor*, KTextEditor::SmartCursor*, KTextEditor::SmartRange*, KTextEditor::SmartRange::InsertBehaviors)")]
        public abstract KTextEditor.SmartRange NewSmartRange(KTextEditor.SmartCursor start, KTextEditor.SmartCursor end, KTextEditor.SmartRange parent, uint insertBehavior);
        /// <remarks>
        ///  Delete a SmartRange without deleting the SmartCursor%s which make up its start() and end().
        ///  First, extract the cursors yourself using:
        ///  <pre>
        ///  SmartCursor start = &range.SmartStart();
        ///  SmartCursor end = &range.SmartEnd();
        ///  </pre>
        ///  Then, call this function to delete the SmartRange instance.  The underlying text will not be affected.
        ///  \param range the range to dissociate from its smart cursors, and delete
        ///      </remarks>        <short>    Delete a SmartRange without deleting the SmartCursor%s which make up its start() and end().</short>
        [SmokeMethod("unbindSmartRange(KTextEditor::SmartRange*)")]
        public abstract void UnbindSmartRange(KTextEditor.SmartRange range);
        /// <remarks>
        ///  Delete all SmartRange%s from this document. This will also delete all
        ///  cursors currently bound to ranges.
        ///  This will not affect any underlying text.
        ///      </remarks>        <short>    Delete all SmartRange%s from this document.</short>
        [SmokeMethod("deleteRanges()")]
        public abstract void DeleteRanges();
        /// <remarks>
        ///  Register a SmartRange tree as providing arbitrary highlighting information,
        ///  and that it should be rendered on all of the views of a document.
        ///  \param topRange the top range of the tree to add
        ///  \param supportDynamic support dynamic highlighting attributes
        ///      </remarks>        <short>    Register a SmartRange tree as providing arbitrary highlighting information,  and that it should be rendered on all of the views of a document.</short>
        [SmokeMethod("addHighlightToDocument(KTextEditor::SmartRange*, bool)")]
        public abstract void AddHighlightToDocument(KTextEditor.SmartRange topRange, bool supportDynamic);
        /// <remarks>
        ///  Remove a SmartRange tree from providing arbitrary highlighting information
        ///  to all of the views of a document.
        ///  \param topRange the top range of the tree to remove
        ///      </remarks>        <short>    Remove a SmartRange tree from providing arbitrary highlighting information  to all of the views of a document.</short>
        [SmokeMethod("removeHighlightFromDocument(KTextEditor::SmartRange*)")]
        public abstract void RemoveHighlightFromDocument(KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Return a list of SmartRange%s which are currently registered as
        ///  providing arbitrary highlighting information to all of the views of a
        ///  document.
        ///      </remarks>        <short>    Return a list of SmartRange%s which are currently registered as  providing arbitrary highlighting information to all of the views of a  document.</short>
        [SmokeMethod("documentHighlights() const")]
        public abstract List<KTextEditor.SmartRange> DocumentHighlights();
        /// <remarks>
        ///  Clear the highlight ranges from a Document.
        ///      </remarks>        <short>    Clear the highlight ranges from a Document.</short>
        [SmokeMethod("clearDocumentHighlights()")]
        public abstract void ClearDocumentHighlights();
        /// <remarks>
        ///  Register a SmartRange tree as providing arbitrary highlighting information,
        ///  and that it should be rendered on the specified <pre>view</pre>.
        ///  \param view view on which to render the highlight
        ///  \param topRange the top range of the tree to add
        ///  \param supportDynamic support dynamic highlighting attributes
        ///      </remarks>        <short>    Register a SmartRange tree as providing arbitrary highlighting information,  and that it should be rendered on the specified \p view.</short>
        [SmokeMethod("addHighlightToView(KTextEditor::View*, KTextEditor::SmartRange*, bool)")]
        public abstract void AddHighlightToView(KTextEditor.View view, KTextEditor.SmartRange topRange, bool supportDynamic);
        /// <remarks>
        ///  Remove a SmartRange tree from providing arbitrary highlighting information
        ///  to a specific view of a document.
        ///  <b>Note:<> implementations should not take into account document-bound
        ///        highlighting ranges when calling this function; it is intended solely
        ///        to be the counter of addHighlightToView()
        ///  \param view view on which the highlight was previously rendered
        ///  \param topRange the top range of the tree to remove
        ///      </remarks>        <short>    Remove a SmartRange tree from providing arbitrary highlighting information  to a specific view of a document.</short>
        [SmokeMethod("removeHighlightFromView(KTextEditor::View*, KTextEditor::SmartRange*)")]
        public abstract void RemoveHighlightFromView(KTextEditor.View view, KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Return a list of SmartRange%s which are currently registered as
        ///  providing arbitrary highlighting information to a specific view of a
        ///  document.
        ///  <b>Note:<> implementations should not take into account document-bound
        ///        highlighting ranges when returning the list; it is intended solely
        ///        to show highlights added via addHighlightToView()
        ///  \param view view to query for the highlight list
        ///      </remarks>        <short>    Return a list of SmartRange%s which are currently registered as  providing arbitrary highlighting information to a specific view of a  document.</short>
        [SmokeMethod("viewHighlights(KTextEditor::View*) const")]
        public abstract List<KTextEditor.SmartRange> ViewHighlights(KTextEditor.View view);
        /// <remarks>
        ///  Clear the highlight ranges from a View.
        ///  \param view view to clear highlights from
        ///      </remarks>        <short>    Clear the highlight ranges from a View.</short>
        [SmokeMethod("clearViewHighlights(KTextEditor::View*)")]
        public abstract void ClearViewHighlights(KTextEditor.View view);
        /// <remarks>
        ///  Register a SmartRange tree as providing bound actions,
        ///  and that they should interact with all of the views of a document.
        ///  \param topRange the top range of the tree to add
        ///      </remarks>        <short>    Register a SmartRange tree as providing bound actions,  and that they should interact with all of the views of a document.</short>
        [SmokeMethod("addActionsToDocument(KTextEditor::SmartRange*)")]
        public abstract void AddActionsToDocument(KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Remove a SmartRange tree from providing bound actions
        ///  to all of the views of a document.
        ///  \param topRange the top range of the tree to remove
        ///      </remarks>        <short>    Remove a SmartRange tree from providing bound actions  to all of the views of a document.</short>
        [SmokeMethod("removeActionsFromDocument(KTextEditor::SmartRange*)")]
        public abstract void RemoveActionsFromDocument(KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Return a list of SmartRange%s which are currently registered as
        ///  providing bound actions to all of the views of a document.
        ///      </remarks>        <short>    Return a list of SmartRange%s which are currently registered as  providing bound actions to all of the views of a document.</short>
        [SmokeMethod("documentActions() const")]
        public abstract List<KTextEditor.SmartRange> DocumentActions();
        /// <remarks>
        ///  Remove all bound SmartRange%s which provide actions to the document.
        ///      </remarks>        <short>    Remove all bound SmartRange%s which provide actions to the document.</short>
        [SmokeMethod("clearDocumentActions()")]
        public abstract void ClearDocumentActions();
        /// <remarks>
        ///  Register a SmartRange tree as providing bound actions,
        ///  and that they should interact with the specified <pre>view</pre>.
        ///  \param view view on which to use the actions
        ///  \param topRange the top range of the tree to add
        ///      </remarks>        <short>    Register a SmartRange tree as providing bound actions,  and that they should interact with the specified \p view.</short>
        [SmokeMethod("addActionsToView(KTextEditor::View*, KTextEditor::SmartRange*)")]
        public abstract void AddActionsToView(KTextEditor.View view, KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Remove a SmartRange tree from providing bound actions
        ///  to the specified <pre>view</pre>.
        ///  <b>Note:<> implementations should not take into account document-bound
        ///        action ranges when calling this function; it is intended solely
        ///        to be the counter of addActionsToView()
        ///  \param view view on which the actions were previously used
        ///  \param topRange the top range of the tree to remove
        ///      </remarks>        <short>    Remove a SmartRange tree from providing bound actions  to the specified \p view.</short>
        [SmokeMethod("removeActionsFromView(KTextEditor::View*, KTextEditor::SmartRange*)")]
        public abstract void RemoveActionsFromView(KTextEditor.View view, KTextEditor.SmartRange topRange);
        /// <remarks>
        ///  Return a list of SmartRange%s which are currently registered as
        ///  providing bound actions to the specified <pre>view</pre>.
        ///  <b>Note:<> implementations should not take into account document-bound
        ///        action ranges when returning the list; it is intended solely
        ///        to show actions added via addActionsToView()
        ///  \param view view to query for the action list
        ///      </remarks>        <short>    Return a list of SmartRange%s which are currently registered as  providing bound actions to the specified \p view.</short>
        [SmokeMethod("viewActions(KTextEditor::View*) const")]
        public abstract List<KTextEditor.SmartRange> ViewActions(KTextEditor.View view);
        /// <remarks>
        ///  Remove all bound SmartRange%s which provide actions to the specified <pre>view</pre>.
        ///  \param view view from which to remove actions
        ///      </remarks>        <short>    Remove all bound SmartRange%s which provide actions to the specified \p view.</short>
        [SmokeMethod("clearViewActions(KTextEditor::View*)")]
        public abstract void ClearViewActions(KTextEditor.View view);
        /// <remarks>
        ///  \internal
        ///  Used to notify implementations that an Attribute has gained
        ///  a dynamic component and needs to be included in mouse and/or cursor
        ///  tracking.
        ///      </remarks>        <short>    \internal  Used to notify implementations that an Attribute has gained  a dynamic component and needs to be included in mouse and/or cursor  tracking.</short>
        [SmokeMethod("attributeDynamic(KSharedPtr<KTextEditor::Attribute>)")]
        protected abstract void AttributeDynamic(KTextEditor.Attribute a);
        /// <remarks>
        ///  \internal
        ///  Used to notify implementations that an Attribute has lost
        ///  all dynamic components and no longer needs to be included in mouse and cursor
        ///  tracking.
        ///      </remarks>        <short>    \internal  Used to notify implementations that an Attribute has lost  all dynamic components and no longer needs to be included in mouse and cursor  tracking.</short>
        [SmokeMethod("attributeNotDynamic(KSharedPtr<KTextEditor::Attribute>)")]
        protected abstract void AttributeNotDynamic(KTextEditor.Attribute a);
    }
}