//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  A QTabBar with extended features.
	///   See <see cref="IKTabBarSignals"></see> for signals emitted by KTabBar
	/// </remarks>		<short>    A QTabBar with extended features.</short>

	[SmokeClass("KTabBar")]
	public class KTabBar : QTabBar, IDisposable {
 		protected KTabBar(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KTabBar), this);
		}
		/// <remarks>
		///  Creates a new tab bar.
		/// <param> name="parent" The parent widget.
		///      </param></remarks>		<short>    Creates a new tab bar.</short>
		public KTabBar(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTabBar#", "KTabBar(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KTabBar() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTabBar", "KTabBar()", typeof(void));
		}
		/// <remarks>
		///  Sets the tab reordering enabled or disabled. If enabled,
		///  the user can reorder the tabs by drag and drop the tab
		///  headers.
		///      </remarks>		<short>    Sets the tab reordering enabled or disabled.</short>
		public void SetTabReorderingEnabled(bool enable) {
			interceptor.Invoke("setTabReorderingEnabled$", "setTabReorderingEnabled(bool)", typeof(void), typeof(bool), enable);
		}
		/// <remarks>
		///  Returns whether tab reordering is enabled.
		///      </remarks>		<short>    Returns whether tab reordering is enabled.</short>
		public bool IsTabReorderingEnabled() {
			return (bool) interceptor.Invoke("isTabReorderingEnabled", "isTabReorderingEnabled() const", typeof(bool));
		}
		public void SetHoverCloseButton(bool arg1) {
			interceptor.Invoke("setHoverCloseButton$", "setHoverCloseButton(bool)", typeof(void), typeof(bool), arg1);
		}
		public bool HoverCloseButton() {
			return (bool) interceptor.Invoke("hoverCloseButton", "hoverCloseButton() const", typeof(bool));
		}
		public void SetHoverCloseButtonDelayed(bool arg1) {
			interceptor.Invoke("setHoverCloseButtonDelayed$", "setHoverCloseButtonDelayed(bool)", typeof(void), typeof(bool), arg1);
		}
		public bool HoverCloseButtonDelayed() {
			return (bool) interceptor.Invoke("hoverCloseButtonDelayed", "hoverCloseButtonDelayed() const", typeof(bool));
		}
		/// <remarks>
		///  Sets the 'activate previous tab on close' feature enabled
		///  or disabled. If enabled, as soon as you close a tab, the
		///  previously selected tab is activated again.
		///      </remarks>		<short>    Sets the 'activate previous tab on close' feature enabled  or disabled.</short>
		public void SetTabCloseActivatePrevious(bool arg1) {
			interceptor.Invoke("setTabCloseActivatePrevious$", "setTabCloseActivatePrevious(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  Returns whether the 'activate previous tab on close' feature
		///  is enabled.
		///      </remarks>		<short>    Returns whether the 'activate previous tab on close' feature  is enabled.</short>
		public bool TabCloseActivatePrevious() {
			return (bool) interceptor.Invoke("tabCloseActivatePrevious", "tabCloseActivatePrevious() const", typeof(bool));
		}
		/// <remarks>
		///  Selects the tab which has a tab header at
		///  given @param position.
		/// <param> name="position" the coordinates of the tab
		///      </param></remarks>		<short>    Selects the tab which has a tab header at  given @param position.</short>
		public int SelectTab(QPoint position) {
			return (int) interceptor.Invoke("selectTab#", "selectTab(const QPoint&) const", typeof(int), typeof(QPoint), position);
		}
		[SmokeMethod("mouseDoubleClickEvent(QMouseEvent*)")]
		protected override void MouseDoubleClickEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseDoubleClickEvent#", "mouseDoubleClickEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mousePressEvent(QMouseEvent*)")]
		protected override void MousePressEvent(QMouseEvent arg1) {
			interceptor.Invoke("mousePressEvent#", "mousePressEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseMoveEvent(QMouseEvent*)")]
		protected override void MouseMoveEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseMoveEvent#", "mouseMoveEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("mouseReleaseEvent(QMouseEvent*)")]
		protected override void MouseReleaseEvent(QMouseEvent arg1) {
			interceptor.Invoke("mouseReleaseEvent#", "mouseReleaseEvent(QMouseEvent*)", typeof(void), typeof(QMouseEvent), arg1);
		}
		[SmokeMethod("wheelEvent(QWheelEvent*)")]
		protected override void WheelEvent(QWheelEvent arg1) {
			interceptor.Invoke("wheelEvent#", "wheelEvent(QWheelEvent*)", typeof(void), typeof(QWheelEvent), arg1);
		}
		[SmokeMethod("dragEnterEvent(QDragEnterEvent*)")]
		protected override void DragEnterEvent(QDragEnterEvent arg1) {
			interceptor.Invoke("dragEnterEvent#", "dragEnterEvent(QDragEnterEvent*)", typeof(void), typeof(QDragEnterEvent), arg1);
		}
		[SmokeMethod("dragMoveEvent(QDragMoveEvent*)")]
		protected override void DragMoveEvent(QDragMoveEvent arg1) {
			interceptor.Invoke("dragMoveEvent#", "dragMoveEvent(QDragMoveEvent*)", typeof(void), typeof(QDragMoveEvent), arg1);
		}
		[SmokeMethod("dropEvent(QDropEvent*)")]
		protected override void DropEvent(QDropEvent arg1) {
			interceptor.Invoke("dropEvent#", "dropEvent(QDropEvent*)", typeof(void), typeof(QDropEvent), arg1);
		}
		[SmokeMethod("tabLayoutChange()")]
		protected override void TabLayoutChange() {
			interceptor.Invoke("tabLayoutChange", "tabLayoutChange()", typeof(void));
		}
		[Q_SLOT("void activateDragSwitchTab()")]
		[SmokeMethod("activateDragSwitchTab()")]
		protected virtual void ActivateDragSwitchTab() {
			interceptor.Invoke("activateDragSwitchTab", "activateDragSwitchTab()", typeof(void));
		}
		~KTabBar() {
			interceptor.Invoke("~KTabBar", "~KTabBar()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KTabBar", "~KTabBar()", typeof(void));
		}
		protected new IKTabBarSignals Emit {
			get { return (IKTabBarSignals) Q_EMIT; }
		}
	}

	public interface IKTabBarSignals : IQTabBarSignals {
		[Q_SIGNAL("void contextMenu(int, const QPoint&)")]
		void ContextMenu(int arg1, QPoint arg2);
		[Q_SIGNAL("void mouseDoubleClick(int)")]
		void MouseDoubleClick(int arg1);
		[Q_SIGNAL("void mouseMiddleClick(int)")]
		void MouseMiddleClick(int arg1);
		[Q_SIGNAL("void initiateDrag(int)")]
		void InitiateDrag(int arg1);
		[Q_SIGNAL("void testCanDecode(const QDragMoveEvent*, bool&)")]
		void TestCanDecode(QDragMoveEvent arg1, bool arg2);
		[Q_SIGNAL("void receivedDropEvent(int, QDropEvent*)")]
		void ReceivedDropEvent(int arg1, QDropEvent arg2);
		[Q_SIGNAL("void moveTab(int, int)")]
		void MoveTab(int arg1, int arg2);
		[Q_SIGNAL("void closeRequest(int)")]
		void CloseRequest(int arg1);
		[Q_SIGNAL("void wheelDelta(int)")]
		void WheelDelta(int arg1);
	}
}
