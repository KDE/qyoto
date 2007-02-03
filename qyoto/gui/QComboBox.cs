//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;
	using System.Collections.Generic;

	/// See <see cref="IQComboBoxSignals"></see> for signals emitted by QComboBox
	[SmokeClass("QComboBox")]
	public class QComboBox : QWidget, IDisposable {
 		protected QComboBox(Type dummy) : base((Type) null) {}
		interface IQComboBoxProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QComboBox), this);
			_interceptor = (QComboBox) realProxy.GetTransparentProxy();
		}
		private QComboBox ProxyQComboBox() {
			return (QComboBox) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QComboBox() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQComboBoxProxy), null);
			_staticInterceptor = (IQComboBoxProxy) realProxy.GetTransparentProxy();
		}
		private static IQComboBoxProxy StaticQComboBox() {
			return (IQComboBoxProxy) _staticInterceptor;
		}

		public enum InsertPolicy {
			NoInsert = 0,
			InsertAtTop = 1,
			InsertAtCurrent = 2,
			InsertAtBottom = 3,
			InsertAfterCurrent = 4,
			InsertBeforeCurrent = 5,
			InsertAlphabetically = 6,
		}
		public enum SizeAdjustPolicy {
			AdjustToContents = 0,
			AdjustToContentsOnFirstShow = 1,
			AdjustToMinimumContentsLength = 2,
		}
		[Q_PROPERTY("bool", "editable")]
		public bool Editable {
			get {
				return Property("editable").Value<bool>();
			}
			set {
				SetProperty("editable", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("int", "count")]
		public int Count {
			get {
				return Property("count").Value<int>();
			}
		}
		[Q_PROPERTY("QString", "currentText")]
		public string CurrentText {
			get {
				return Property("currentText").Value<string>();
			}
		}
		[Q_PROPERTY("int", "currentIndex")]
		public int CurrentIndex {
			get {
				return Property("currentIndex").Value<int>();
			}
			set {
				SetProperty("currentIndex", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "maxVisibleItems")]
		public int MaxVisibleItems {
			get {
				return Property("maxVisibleItems").Value<int>();
			}
			set {
				SetProperty("maxVisibleItems", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("int", "maxCount")]
		public int MaxCount {
			get {
				return Property("maxCount").Value<int>();
			}
			set {
				SetProperty("maxCount", QVariant.FromValue<int>(value));
			}
		}
		[Q_PROPERTY("QComboBox::InsertPolicy", "insertPolicy")]
		public QComboBox.InsertPolicy insertPolicy {
			get {
				return Property("insertPolicy").Value<QComboBox.InsertPolicy>();
			}
			set {
				SetProperty("insertPolicy", QVariant.FromValue<QComboBox.InsertPolicy>(value));
			}
		}
		[Q_PROPERTY("QComboBox::SizeAdjustPolicy", "sizeAdjustPolicy")]
		public QComboBox.SizeAdjustPolicy sizeAdjustPolicy {
			get {
				return Property("sizeAdjustPolicy").Value<QComboBox.SizeAdjustPolicy>();
			}
			set {
				SetProperty("sizeAdjustPolicy", QVariant.FromValue<QComboBox.SizeAdjustPolicy>(value));
			}
		}
		[Q_PROPERTY("int", "minimumContentsLength")]
		public int MinimumContentsLength {
			get {
				return Property("minimumContentsLength").Value<int>();
			}
			set {
				SetProperty("minimumContentsLength", QVariant.FromValue<int>(value));
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
		[Q_PROPERTY("bool", "autoCompletion")]
		public bool AutoCompletion {
			get {
				return Property("autoCompletion").Value<bool>();
			}
			set {
				SetProperty("autoCompletion", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("Qt::CaseSensitivity", "autoCompletionCaseSensitivity")]
		public Qt.CaseSensitivity AutoCompletionCaseSensitivity {
			get {
				return Property("autoCompletionCaseSensitivity").Value<Qt.CaseSensitivity>();
			}
			set {
				SetProperty("autoCompletionCaseSensitivity", QVariant.FromValue<Qt.CaseSensitivity>(value));
			}
		}
		[Q_PROPERTY("bool", "duplicatesEnabled")]
		public bool DuplicatesEnabled {
			get {
				return Property("duplicatesEnabled").Value<bool>();
			}
			set {
				SetProperty("duplicatesEnabled", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("bool", "frame")]
		public bool Frame {
			get {
				return Property("frame").Value<bool>();
			}
			set {
				SetProperty("frame", QVariant.FromValue<bool>(value));
			}
		}
		[Q_PROPERTY("int", "modelColumn")]
		public int ModelColumn {
			get {
				return Property("modelColumn").Value<int>();
			}
			set {
				SetProperty("modelColumn", QVariant.FromValue<int>(value));
			}
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QComboBox(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQComboBox(parent);
		}
		[SmokeMethod("QComboBox", "(QWidget*)", "#")]
		private void NewQComboBox(QWidget parent) {
			ProxyQComboBox().NewQComboBox(parent);
		}
		public QComboBox() : this((Type) null) {
			CreateProxy();
			NewQComboBox();
		}
		[SmokeMethod("QComboBox", "()", "")]
		private void NewQComboBox() {
			ProxyQComboBox().NewQComboBox();
		}
		[SmokeMethod("hasFrame", "() const", "")]
		public bool HasFrame() {
			return ProxyQComboBox().HasFrame();
		}
		[SmokeMethod("findText", "(const QString&, Qt::MatchFlags) const", "$$")]
		public int FindText(string text, int flags) {
			return ProxyQComboBox().FindText(text,flags);
		}
		[SmokeMethod("findText", "(const QString&) const", "$")]
		public int FindText(string text) {
			return ProxyQComboBox().FindText(text);
		}
		[SmokeMethod("findData", "(const QVariant&, int, Qt::MatchFlags) const", "#$$")]
		public int FindData(QVariant data, int role, int flags) {
			return ProxyQComboBox().FindData(data,role,flags);
		}
		[SmokeMethod("findData", "(const QVariant&, int) const", "#$")]
		public int FindData(QVariant data, int role) {
			return ProxyQComboBox().FindData(data,role);
		}
		[SmokeMethod("findData", "(const QVariant&) const", "#")]
		public int FindData(QVariant data) {
			return ProxyQComboBox().FindData(data);
		}
		[SmokeMethod("isEditable", "() const", "")]
		public bool IsEditable() {
			return ProxyQComboBox().IsEditable();
		}
		[SmokeMethod("setLineEdit", "(QLineEdit*)", "#")]
		public void SetLineEdit(QLineEdit edit) {
			ProxyQComboBox().SetLineEdit(edit);
		}
		[SmokeMethod("lineEdit", "() const", "")]
		public QLineEdit LineEdit() {
			return ProxyQComboBox().LineEdit();
		}
		[SmokeMethod("setValidator", "(const QValidator*)", "#")]
		public void SetValidator(QValidator v) {
			ProxyQComboBox().SetValidator(v);
		}
		[SmokeMethod("validator", "() const", "")]
		public QValidator Validator() {
			return ProxyQComboBox().Validator();
		}
		[SmokeMethod("setCompleter", "(QCompleter*)", "#")]
		public void SetCompleter(QCompleter c) {
			ProxyQComboBox().SetCompleter(c);
		}
		[SmokeMethod("completer", "() const", "")]
		public QCompleter Completer() {
			return ProxyQComboBox().Completer();
		}
		[SmokeMethod("itemDelegate", "() const", "")]
		public QAbstractItemDelegate ItemDelegate() {
			return ProxyQComboBox().ItemDelegate();
		}
		[SmokeMethod("setItemDelegate", "(QAbstractItemDelegate*)", "#")]
		public void SetItemDelegate(QAbstractItemDelegate arg1) {
			ProxyQComboBox().SetItemDelegate(arg1);
		}
		[SmokeMethod("model", "() const", "")]
		public QAbstractItemModel Model() {
			return ProxyQComboBox().Model();
		}
		[SmokeMethod("setModel", "(QAbstractItemModel*)", "#")]
		public void SetModel(QAbstractItemModel model) {
			ProxyQComboBox().SetModel(model);
		}
		[SmokeMethod("rootModelIndex", "() const", "")]
		public QModelIndex RootModelIndex() {
			return ProxyQComboBox().RootModelIndex();
		}
		[SmokeMethod("setRootModelIndex", "(const QModelIndex&)", "#")]
		public void SetRootModelIndex(QModelIndex index) {
			ProxyQComboBox().SetRootModelIndex(index);
		}
		[SmokeMethod("itemText", "(int) const", "$")]
		public string ItemText(int index) {
			return ProxyQComboBox().ItemText(index);
		}
		[SmokeMethod("itemIcon", "(int) const", "$")]
		public QIcon ItemIcon(int index) {
			return ProxyQComboBox().ItemIcon(index);
		}
		[SmokeMethod("itemData", "(int, int) const", "$$")]
		public QVariant ItemData(int index, int role) {
			return ProxyQComboBox().ItemData(index,role);
		}
		[SmokeMethod("itemData", "(int) const", "$")]
		public QVariant ItemData(int index) {
			return ProxyQComboBox().ItemData(index);
		}
		[SmokeMethod("addItem", "(const QString&, const QVariant&)", "$#")]
		public void AddItem(string text, QVariant userData) {
			ProxyQComboBox().AddItem(text,userData);
		}
		[SmokeMethod("addItem", "(const QString&)", "$")]
		public void AddItem(string text) {
			ProxyQComboBox().AddItem(text);
		}
		[SmokeMethod("addItem", "(const QIcon&, const QString&, const QVariant&)", "#$#")]
		public void AddItem(QIcon icon, string text, QVariant userData) {
			ProxyQComboBox().AddItem(icon,text,userData);
		}
		[SmokeMethod("addItem", "(const QIcon&, const QString&)", "#$")]
		public void AddItem(QIcon icon, string text) {
			ProxyQComboBox().AddItem(icon,text);
		}
		[SmokeMethod("addItems", "(const QStringList&)", "?")]
		public void AddItems(List<string> texts) {
			ProxyQComboBox().AddItems(texts);
		}
		[SmokeMethod("insertItem", "(int, const QString&, const QVariant&)", "$$#")]
		public void InsertItem(int index, string text, QVariant userData) {
			ProxyQComboBox().InsertItem(index,text,userData);
		}
		[SmokeMethod("insertItem", "(int, const QString&)", "$$")]
		public void InsertItem(int index, string text) {
			ProxyQComboBox().InsertItem(index,text);
		}
		[SmokeMethod("insertItem", "(int, const QIcon&, const QString&, const QVariant&)", "$#$#")]
		public void InsertItem(int index, QIcon icon, string text, QVariant userData) {
			ProxyQComboBox().InsertItem(index,icon,text,userData);
		}
		[SmokeMethod("insertItem", "(int, const QIcon&, const QString&)", "$#$")]
		public void InsertItem(int index, QIcon icon, string text) {
			ProxyQComboBox().InsertItem(index,icon,text);
		}
		[SmokeMethod("insertItems", "(int, const QStringList&)", "$?")]
		public void InsertItems(int index, List<string> texts) {
			ProxyQComboBox().InsertItems(index,texts);
		}
		[SmokeMethod("removeItem", "(int)", "$")]
		public void RemoveItem(int index) {
			ProxyQComboBox().RemoveItem(index);
		}
		[SmokeMethod("setItemText", "(int, const QString&)", "$$")]
		public void SetItemText(int index, string text) {
			ProxyQComboBox().SetItemText(index,text);
		}
		[SmokeMethod("setItemIcon", "(int, const QIcon&)", "$#")]
		public void SetItemIcon(int index, QIcon icon) {
			ProxyQComboBox().SetItemIcon(index,icon);
		}
		[SmokeMethod("setItemData", "(int, const QVariant&, int)", "$#$")]
		public void SetItemData(int index, QVariant value, int role) {
			ProxyQComboBox().SetItemData(index,value,role);
		}
		[SmokeMethod("setItemData", "(int, const QVariant&)", "$#")]
		public void SetItemData(int index, QVariant value) {
			ProxyQComboBox().SetItemData(index,value);
		}
		[SmokeMethod("view", "() const", "")]
		public QAbstractItemView View() {
			return ProxyQComboBox().View();
		}
		[SmokeMethod("setView", "(QAbstractItemView*)", "#")]
		public void SetView(QAbstractItemView itemView) {
			ProxyQComboBox().SetView(itemView);
		}
		[SmokeMethod("sizeHint", "() const", "")]
		public new QSize SizeHint() {
			return ProxyQComboBox().SizeHint();
		}
		[SmokeMethod("minimumSizeHint", "() const", "")]
		public new QSize MinimumSizeHint() {
			return ProxyQComboBox().MinimumSizeHint();
		}
		[SmokeMethod("showPopup", "()", "")]
		public virtual void ShowPopup() {
			ProxyQComboBox().ShowPopup();
		}
		[SmokeMethod("hidePopup", "()", "")]
		public virtual void HidePopup() {
			ProxyQComboBox().HidePopup();
		}
		[SmokeMethod("event", "(QEvent*)", "#")]
		public new bool Event(QEvent arg1) {
			return ProxyQComboBox().Event(arg1);
		}
		[Q_SLOT("void clear()")]
		[SmokeMethod("clear", "()", "")]
		public void Clear() {
			ProxyQComboBox().Clear();
		}
		[Q_SLOT("void clearEditText()")]
		[SmokeMethod("clearEditText", "()", "")]
		public void ClearEditText() {
			ProxyQComboBox().ClearEditText();
		}
		[Q_SLOT("void setEditText(const QString&)")]
		[SmokeMethod("setEditText", "(const QString&)", "$")]
		public void SetEditText(string text) {
			ProxyQComboBox().SetEditText(text);
		}
		public static new string Tr(string s, string c) {
			return StaticQComboBox().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQComboBox().Tr(s);
		}
		[SmokeMethod("focusInEvent", "(QFocusEvent*)", "#")]
		protected new void FocusInEvent(QFocusEvent e) {
			ProxyQComboBox().FocusInEvent(e);
		}
		[SmokeMethod("focusOutEvent", "(QFocusEvent*)", "#")]
		protected new void FocusOutEvent(QFocusEvent e) {
			ProxyQComboBox().FocusOutEvent(e);
		}
		[SmokeMethod("changeEvent", "(QEvent*)", "#")]
		protected new void ChangeEvent(QEvent e) {
			ProxyQComboBox().ChangeEvent(e);
		}
		[SmokeMethod("resizeEvent", "(QResizeEvent*)", "#")]
		protected new void ResizeEvent(QResizeEvent e) {
			ProxyQComboBox().ResizeEvent(e);
		}
		[SmokeMethod("paintEvent", "(QPaintEvent*)", "#")]
		protected new void PaintEvent(QPaintEvent e) {
			ProxyQComboBox().PaintEvent(e);
		}
		[SmokeMethod("showEvent", "(QShowEvent*)", "#")]
		public new void ShowEvent(QShowEvent e) {
			ProxyQComboBox().ShowEvent(e);
		}
		[SmokeMethod("hideEvent", "(QHideEvent*)", "#")]
		protected new void HideEvent(QHideEvent e) {
			ProxyQComboBox().HideEvent(e);
		}
		[SmokeMethod("mousePressEvent", "(QMouseEvent*)", "#")]
		protected new void MousePressEvent(QMouseEvent e) {
			ProxyQComboBox().MousePressEvent(e);
		}
		[SmokeMethod("mouseReleaseEvent", "(QMouseEvent*)", "#")]
		protected new void MouseReleaseEvent(QMouseEvent e) {
			ProxyQComboBox().MouseReleaseEvent(e);
		}
		[SmokeMethod("keyPressEvent", "(QKeyEvent*)", "#")]
		protected new void KeyPressEvent(QKeyEvent e) {
			ProxyQComboBox().KeyPressEvent(e);
		}
		[SmokeMethod("keyReleaseEvent", "(QKeyEvent*)", "#")]
		protected new void KeyReleaseEvent(QKeyEvent e) {
			ProxyQComboBox().KeyReleaseEvent(e);
		}
		[SmokeMethod("wheelEvent", "(QWheelEvent*)", "#")]
		protected new void WheelEvent(QWheelEvent e) {
			ProxyQComboBox().WheelEvent(e);
		}
		[SmokeMethod("contextMenuEvent", "(QContextMenuEvent*)", "#")]
		protected new void ContextMenuEvent(QContextMenuEvent e) {
			ProxyQComboBox().ContextMenuEvent(e);
		}
		[SmokeMethod("inputMethodEvent", "(QInputMethodEvent*)", "#")]
		protected new void InputMethodEvent(QInputMethodEvent arg1) {
			ProxyQComboBox().InputMethodEvent(arg1);
		}
		[SmokeMethod("inputMethodQuery", "(Qt::InputMethodQuery) const", "$")]
		protected new QVariant InputMethodQuery(Qt.InputMethodQuery arg1) {
			return ProxyQComboBox().InputMethodQuery(arg1);
		}
		~QComboBox() {
			DisposeQComboBox();
		}
		public new void Dispose() {
			DisposeQComboBox();
		}
		[SmokeMethod("~QComboBox", "()", "")]
		private void DisposeQComboBox() {
			ProxyQComboBox().DisposeQComboBox();
		}
		protected new IQComboBoxSignals Emit {
			get {
				return (IQComboBoxSignals) Q_EMIT;
			}
		}
	}

	public interface IQComboBoxSignals : IQWidgetSignals {
		[Q_SIGNAL("void editTextChanged(const QString&)")]
		void EditTextChanged(string arg1);
		[Q_SIGNAL("void activated(int)")]
		void Activated(int index);
		[Q_SIGNAL("void activated(const QString&)")]
		void Activated(string arg1);
		[Q_SIGNAL("void highlighted(int)")]
		void Highlighted(int index);
		[Q_SIGNAL("void highlighted(const QString&)")]
		void Highlighted(string arg1);
		[Q_SIGNAL("void currentIndexChanged(int)")]
		void CurrentIndexChanged(int index);
		[Q_SIGNAL("void currentIndexChanged(const QString&)")]
		void CurrentIndexChanged(string arg1);
	}
}
