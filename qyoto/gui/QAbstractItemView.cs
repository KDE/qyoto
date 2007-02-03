//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQAbstractItemViewSignals"></see> for signals emitted by QAbstractItemView
	[SmokeClass("QAbstractItemView")]
	public class QAbstractItemView : QAbstractScrollArea {
 		protected QAbstractItemView(Type dummy) : base((Type) null) {}
		interface IQAbstractItemViewProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAbstractItemView), this);
			_interceptor = (QAbstractItemView) realProxy.GetTransparentProxy();
		}
		private QAbstractItemView ProxyQAbstractItemView() {
			return (QAbstractItemView) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAbstractItemView() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAbstractItemViewProxy), null);
			_staticInterceptor = (IQAbstractItemViewProxy) realProxy.GetTransparentProxy();
		}
		private static IQAbstractItemViewProxy StaticQAbstractItemView() {
			return (IQAbstractItemViewProxy) _staticInterceptor;
		}

		public enum SelectionMode {
			NoSelection = 0,
			SingleSelection = 1,
			MultiSelection = 2,
			ExtendedSelection = 3,
			ContiguousSelection = 4,
		}
		public enum SelectionBehavior {
			SelectItems = 0,
			SelectRows = 1,
			SelectColumns = 2,
		}
		public enum ScrollHint {
			EnsureVisible = 0,
			PositionAtTop = 1,
			PositionAtBottom = 2,
			PositionAtCenter = 3,
		}
		public enum EditTrigger {
			NoEditTriggers = 0,
			CurrentChanged = 1,
			DoubleClicked = 2,
			SelectedClicked = 4,
			EditKeyPressed = 8,
			AnyKeyPressed = 16,
			AllEditTriggers = 31,
		}
		public enum ScrollMode {
			ScrollPerItem = 0,
			ScrollPerPixel = 1,
		}
		public enum DragDropMode {
			NoDragDrop = 0,
			DragOnly = 1,
			DropOnly = 2,
			DragDrop = 3,
			InternalMove = 4,
		}
		public enum CursorAction {
			MoveUp = 0,
			MoveDown = 1,
			MoveLeft = 2,
			MoveRight = 3,
			MoveHome = 4,
			MoveEnd = 5,
			MovePageUp = 6,
			MovePageDown = 7,
			MoveNext = 8,
			MovePrevious = 9,
		}
		public enum State {
			NoState = 0,
			DraggingState = 1,
			DragSelectingState = 2,
			EditingState = 3,
			ExpandingState = 4,
			CollapsingState = 5,
			AnimatingState = 6,
		}
		public enum DropIndicatorPosition {
			OnItem = 0,
			AboveItem = 1,
			BelowItem = 2,
			OnViewport = 3,
		}
		[Q_PROPERTY("bool", "autoScroll")]
		public bool AutoScroll {
			get {
				return Property("autoScroll").Value<bool>();
			}
			set {
				SetProperty("autoScroll", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("EditTriggers", "editTriggers")]
		public int EditTriggers {
			get {
				return Property("editTriggers").Value<int>();
			}
			set {
				SetProperty("editTriggers", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("bool", "tabKeyNavigation")]
		public bool TabKeyNavigation {
			get {
				return Property("tabKeyNavigation").Value<bool>();
			}
			set {
				SetProperty("tabKeyNavigation", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "showDropIndicator")]
		public bool ShowDropIndicator {
			get {
				return Property("showDropIndicator").Value<bool>();
			}
			set {
				SetProperty("showDropIndicator", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "dragEnabled")]
		public bool DragEnabled {
			get {
				return Property("dragEnabled").Value<bool>();
			}
			set {
				SetProperty("dragEnabled", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "dragDropOverwriteMode")]
		public bool DragDropOverwriteMode {
			get {
				return Property("dragDropOverwriteMode").Value<bool>();
			}
			set {
				SetProperty("dragDropOverwriteMode", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QAbstractItemView::DragDropMode", "dragDropMode")]
		public QAbstractItemView.DragDropMode dragDropMode {
			get {
				return Property("dragDropMode").Value<QAbstractItemView.DragDropMode>();
			}
			set {
				SetProperty("dragDropMode", QVariant.FromValue<QAbstractItemView.DragDropMode>(value));
			}
		}
		[Q_PROPERTY("bool", "alternatingRowColors")]
		public bool AlternatingRowColors {
			get {
				return Property("alternatingRowColors").Value<bool>();
			}
			set {
				SetProperty("alternatingRowColors", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("QAbstractItemView::SelectionMode", "selectionMode")]
		public QAbstractItemView.SelectionMode selectionMode {
			get {
				return Property("selectionMode").Value<QAbstractItemView.SelectionMode>();
			}
			set {
				SetProperty("selectionMode", QVariant.FromValue<QAbstractItemView.SelectionMode>(value));
			}
		}
		[Q_PROPERTY("QAbstractItemView::SelectionBehavior", "selectionBehavior")]
		public QAbstractItemView.SelectionBehavior selectionBehavior {
			get {
				return Property("selectionBehavior").Value<QAbstractItemView.SelectionBehavior>();
			}
			set {
				SetProperty("selectionBehavior", QVariant.FromValue<QAbstractItemView.SelectionBehavior>(value));
			}
		}
		[Q_PROPERTY("QSize", "iconSize")]
		public QSize IconSize {
			get {
				return Property("iconSize").Value<QSize>();
			}
			set {
				SetProperty("iconSize", QVariant.FromValue<QSize>(value));
			}
		}
		[Q_PROPERTY("Qt::TextElideMode", "textElideMode")]
		public Qt.TextElideMode TextElideMode {
			get {
				return Property("textElideMode").Value<Qt.TextElideMode>();
			}
			set {
				SetProperty("textElideMode", QVariant.FromValue<Qt.TextElideMode>(value));
			}
		}
		[Q_PROPERTY("QAbstractItemView::ScrollMode", "verticalScrollMode")]
		public QAbstractItemView.ScrollMode VerticalScrollMode {
			get {
				return Property("verticalScrollMode").Value<QAbstractItemView.ScrollMode>();
			}
			set {
				SetProperty("verticalScrollMode", QVariant.FromValue<QAbstractItemView.ScrollMode>(value));
			}
		}
		[Q_PROPERTY("QAbstractItemView::ScrollMode", "horizontalScrollMode")]
		public QAbstractItemView.ScrollMode HorizontalScrollMode {
			get {
				return Property("horizontalScrollMode").Value<QAbstractItemView.ScrollMode>();
			}
			set {
				SetProperty("horizontalScrollMode", QVariant.FromValue<QAbstractItemView.ScrollMode>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QAbstractItemView(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQAbstractItemView(parent);
		}
		[SmokeMethod("QAbstractItemView", "(QWidget*)", "#")]
		private void NewQAbstractItemView(QWidget parent) {
			ProxyQAbstractItemView().NewQAbstractItemView(parent);
		}
		public QAbstractItemView() : this((Type) null) {
			CreateProxy();
			NewQAbstractItemView();
		}
		[SmokeMethod("QAbstractItemView", "()", "")]
		private void NewQAbstractItemView() {
			ProxyQAbstractItemView().NewQAbstractItemView();
		}
		[SmokeMethod("setModel", "(QAbstractItemModel*)", "#")]
		public virtual void SetModel(QAbstractItemModel model) {
			ProxyQAbstractItemView().SetModel(model);
		}
		[SmokeMethod("model", "() const", "")]
		public QAbstractItemModel Model() {
			return ProxyQAbstractItemView().Model();
		}
		[SmokeMethod("setSelectionModel", "(QItemSelectionModel*)", "#")]
		public virtual void SetSelectionModel(QItemSelectionModel selectionModel) {
			ProxyQAbstractItemView().SetSelectionModel(selectionModel);
		}
		[SmokeMethod("selectionModel", "() const", "")]
		public QItemSelectionModel SelectionModel() {
			return ProxyQAbstractItemView().SelectionModel();
		}
		[SmokeMethod("setItemDelegate", "(QAbstractItemDelegate*)", "#")]
		public void SetItemDelegate(QAbstractItemDelegate arg1) {
			ProxyQAbstractItemView().SetItemDelegate(arg1);
		}
		[SmokeMethod("itemDelegate", "() const", "")]
		public QAbstractItemDelegate ItemDelegate() {
			return ProxyQAbstractItemView().ItemDelegate();
		}
		[SmokeMethod("currentIndex", "() const", "")]
		public QModelIndex CurrentIndex() {
			return ProxyQAbstractItemView().CurrentIndex();
		}
		[SmokeMethod("rootIndex", "() const", "")]
		public QModelIndex RootIndex() {
			return ProxyQAbstractItemView().RootIndex();
		}
		[SmokeMethod("hasAutoScroll", "() const", "")]
		public bool HasAutoScroll() {
			return ProxyQAbstractItemView().HasAutoScroll();
		}
		[SmokeMethod("setDropIndicatorShown", "(bool)", "$")]
		public void SetDropIndicatorShown(bool enable) {
			ProxyQAbstractItemView().SetDropIndicatorShown(enable);
		}
		[SmokeMethod("keyboardSearch", "(const QString&)", "$")]
		public virtual void KeyboardSearch(string search) {
			ProxyQAbstractItemView().KeyboardSearch(search);
		}
		[SmokeMethod("visualRect", "(const QModelIndex&) const", "#")]
		public virtual QRect VisualRect(QModelIndex index) {
			return ProxyQAbstractItemView().VisualRect(index);
		}
		[SmokeMethod("scrollTo", "(const QModelIndex&, QAbstractItemView::ScrollHint)", "#$")]
		public virtual void ScrollTo(QModelIndex index, QAbstractItemView.ScrollHint hint) {
			ProxyQAbstractItemView().ScrollTo(index,hint);
		}
		[SmokeMethod("scrollTo", "(const QModelIndex&)", "#")]
		public virtual void ScrollTo(QModelIndex index) {
			ProxyQAbstractItemView().ScrollTo(index);
		}
		[SmokeMethod("indexAt", "(const QPoint&) const", "#")]
		public virtual QModelIndex IndexAt(QPoint point) {
			return ProxyQAbstractItemView().IndexAt(point);
		}
		[SmokeMethod("sizeHintForIndex", "(const QModelIndex&) const", "#")]
		public QSize SizeHintForIndex(QModelIndex index) {
			return ProxyQAbstractItemView().SizeHintForIndex(index);
		}
		[SmokeMethod("sizeHintForRow", "(int) const", "$")]
		public virtual int SizeHintForRow(int row) {
			return ProxyQAbstractItemView().SizeHintForRow(row);
		}
		[SmokeMethod("sizeHintForColumn", "(int) const", "$")]
		public virtual int SizeHintForColumn(int column) {
			return ProxyQAbstractItemView().SizeHintForColumn(column);
		}
		[SmokeMethod("openPersistentEditor", "(const QModelIndex&)", "#")]
		public void OpenPersistentEditor(QModelIndex index) {
			ProxyQAbstractItemView().OpenPersistentEditor(index);
		}
		[SmokeMethod("closePersistentEditor", "(const QModelIndex&)", "#")]
		public void ClosePersistentEditor(QModelIndex index) {
			ProxyQAbstractItemView().ClosePersistentEditor(index);
		}
		[SmokeMethod("setIndexWidget", "(const QModelIndex&, QWidget*)", "##")]
		public void SetIndexWidget(QModelIndex index, QWidget widget) {
			ProxyQAbstractItemView().SetIndexWidget(index,widget);
		}
		[SmokeMethod("indexWidget", "(const QModelIndex&) const", "#")]
		public QWidget IndexWidget(QModelIndex index) {
			return ProxyQAbstractItemView().IndexWidget(index);
		}
		[SmokeMethod("setItemDelegateForRow", "(int, QAbstractItemDelegate*)", "$#")]
		public void SetItemDelegateForRow(int row, QAbstractItemDelegate arg2) {
			ProxyQAbstractItemView().SetItemDelegateForRow(row,arg2);
		}
		[SmokeMethod("itemDelegateForRow", "(int) const", "$")]
		public QAbstractItemDelegate ItemDelegateForRow(int row) {
			return ProxyQAbstractItemView().ItemDelegateForRow(row);
		}
		[SmokeMethod("setItemDelegateForColumn", "(int, QAbstractItemDelegate*)", "$#")]
		public void SetItemDelegateForColumn(int column, QAbstractItemDelegate arg2) {
			ProxyQAbstractItemView().SetItemDelegateForColumn(column,arg2);
		}
		[SmokeMethod("itemDelegateForColumn", "(int) const", "$")]
		public QAbstractItemDelegate ItemDelegateForColumn(int column) {
			return ProxyQAbstractItemView().ItemDelegateForColumn(column);
		}
		[SmokeMethod("itemDelegate", "(const QModelIndex&) const", "#")]
		public QAbstractItemDelegate ItemDelegate(QModelIndex index) {
			return ProxyQAbstractItemView().ItemDelegate(index);
		}
		[SmokeMethod("inputMethodQuery", "(Qt::InputMethodQuery) const", "$")]
		public new virtual QVariant InputMethodQuery(Qt.InputMethodQuery query) {
			return ProxyQAbstractItemView().InputMethodQuery(query);
		}
		[Q_SLOT("void reset()")]
		[SmokeMethod("reset", "()", "")]
		public virtual void Reset() {
			ProxyQAbstractItemView().Reset();
		}
		[Q_SLOT("void setRootIndex(const QModelIndex&)")]
		[SmokeMethod("setRootIndex", "(const QModelIndex&)", "#")]
		public virtual void SetRootIndex(QModelIndex index) {
			ProxyQAbstractItemView().SetRootIndex(index);
		}
		[Q_SLOT("void doItemsLayout()")]
		[SmokeMethod("doItemsLayout", "()", "")]
		public virtual void DoItemsLayout() {
			ProxyQAbstractItemView().DoItemsLayout();
		}
		[Q_SLOT("void selectAll()")]
		[SmokeMethod("selectAll", "()", "")]
		public virtual void SelectAll() {
			ProxyQAbstractItemView().SelectAll();
		}
		[Q_SLOT("void edit(const QModelIndex&)")]
		[SmokeMethod("edit", "(const QModelIndex&)", "#")]
		public void Edit(QModelIndex index) {
			ProxyQAbstractItemView().Edit(index);
		}
		[Q_SLOT("void clearSelection()")]
		[SmokeMethod("clearSelection", "()", "")]
		public void ClearSelection() {
			ProxyQAbstractItemView().ClearSelection();
		}
		[Q_SLOT("void setCurrentIndex(const QModelIndex&)")]
		[SmokeMethod("setCurrentIndex", "(const QModelIndex&)", "#")]
		public void SetCurrentIndex(QModelIndex index) {
			ProxyQAbstractItemView().SetCurrentIndex(index);
		}
		[Q_SLOT("void scrollToTop()")]
		[SmokeMethod("scrollToTop", "()", "")]
		public void ScrollToTop() {
			ProxyQAbstractItemView().ScrollToTop();
		}
		[Q_SLOT("void scrollToBottom()")]
		[SmokeMethod("scrollToBottom", "()", "")]
		public void ScrollToBottom() {
			ProxyQAbstractItemView().ScrollToBottom();
		}
		public static new string Tr(string s, string c) {
			return StaticQAbstractItemView().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQAbstractItemView().Tr(s);
		}
		~QAbstractItemView() {
			DisposeQAbstractItemView();
		}
		public new void Dispose() {
			DisposeQAbstractItemView();
		}
		[SmokeMethod("~QAbstractItemView", "()", "")]
		private void DisposeQAbstractItemView() {
			ProxyQAbstractItemView().DisposeQAbstractItemView();
		}
		protected new IQAbstractItemViewSignals Emit {
			get {
				return (IQAbstractItemViewSignals) Q_EMIT;
			}
		}
	}

	public interface IQAbstractItemViewSignals : IQAbstractScrollAreaSignals {
		[Q_SIGNAL("void pressed(const QModelIndex&)")]
		void Pressed(QModelIndex index);
		[Q_SIGNAL("void clicked(const QModelIndex&)")]
		void Clicked(QModelIndex index);
		[Q_SIGNAL("void doubleClicked(const QModelIndex&)")]
		void DoubleClicked(QModelIndex index);
		[Q_SIGNAL("void activated(const QModelIndex&)")]
		void Activated(QModelIndex index);
		[Q_SIGNAL("void entered(const QModelIndex&)")]
		void Entered(QModelIndex index);
		[Q_SIGNAL("void viewportEntered()")]
		void ViewportEntered();
	}
}
