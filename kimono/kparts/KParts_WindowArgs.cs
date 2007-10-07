//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace KParts {

	using System;
	using Qyoto;

	/// <remarks>
	///  The WindowArgs are used to specify arguments to the "create new window"
	///  call (see the createNewWindow variant that uses WindowArgs).
	///  The primary reason for this is the javascript window.open function.
	///  </remarks>		<short>    The WindowArgs are used to specify arguments to the "create new window"  call (see the createNewWindow variant that uses WindowArgs).</short>

	[SmokeClass("KParts::WindowArgs")]
	public class WindowArgs : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected WindowArgs(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(WindowArgs), this);
		}
		public WindowArgs() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("WindowArgs", "WindowArgs()", typeof(void));
		}
		public WindowArgs(KParts.WindowArgs args) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("WindowArgs#", "WindowArgs(const KParts::WindowArgs&)", typeof(void), typeof(KParts.WindowArgs), args);
		}
		public WindowArgs(QRect _geometry, bool _fullscreen, bool _menuBarVisible, bool _toolBarsVisible, bool _statusBarVisible, bool _resizable) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("WindowArgs#$$$$$", "WindowArgs(const QRect&, bool, bool, bool, bool, bool)", typeof(void), typeof(QRect), _geometry, typeof(bool), _fullscreen, typeof(bool), _menuBarVisible, typeof(bool), _toolBarsVisible, typeof(bool), _statusBarVisible, typeof(bool), _resizable);
		}
		public WindowArgs(int _x, int _y, int _width, int _height, bool _fullscreen, bool _menuBarVisible, bool _toolBarsVisible, bool _statusBarVisible, bool _resizable) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("WindowArgs$$$$$$$$$", "WindowArgs(int, int, int, int, bool, bool, bool, bool, bool)", typeof(void), typeof(int), _x, typeof(int), _y, typeof(int), _width, typeof(int), _height, typeof(bool), _fullscreen, typeof(bool), _menuBarVisible, typeof(bool), _toolBarsVisible, typeof(bool), _statusBarVisible, typeof(bool), _resizable);
		}
		public void SetX(int x) {
			interceptor.Invoke("setX$", "setX(int)", typeof(void), typeof(int), x);
		}
		public int X() {
			return (int) interceptor.Invoke("x", "x() const", typeof(int));
		}
		public void SetY(int y) {
			interceptor.Invoke("setY$", "setY(int)", typeof(void), typeof(int), y);
		}
		public int Y() {
			return (int) interceptor.Invoke("y", "y() const", typeof(int));
		}
		public void SetWidth(int w) {
			interceptor.Invoke("setWidth$", "setWidth(int)", typeof(void), typeof(int), w);
		}
		public int Width() {
			return (int) interceptor.Invoke("width", "width() const", typeof(int));
		}
		public void SetHeight(int h) {
			interceptor.Invoke("setHeight$", "setHeight(int)", typeof(void), typeof(int), h);
		}
		public int Height() {
			return (int) interceptor.Invoke("height", "height() const", typeof(int));
		}
		public void SetFullScreen(bool fs) {
			interceptor.Invoke("setFullScreen$", "setFullScreen(bool)", typeof(void), typeof(bool), fs);
		}
		public bool IsFullScreen() {
			return (bool) interceptor.Invoke("isFullScreen", "isFullScreen() const", typeof(bool));
		}
		public void SetMenuBarVisible(bool visible) {
			interceptor.Invoke("setMenuBarVisible$", "setMenuBarVisible(bool)", typeof(void), typeof(bool), visible);
		}
		public bool IsMenuBarVisible() {
			return (bool) interceptor.Invoke("isMenuBarVisible", "isMenuBarVisible() const", typeof(bool));
		}
		public void SetToolBarsVisible(bool visible) {
			interceptor.Invoke("setToolBarsVisible$", "setToolBarsVisible(bool)", typeof(void), typeof(bool), visible);
		}
		public bool ToolBarsVisible() {
			return (bool) interceptor.Invoke("toolBarsVisible", "toolBarsVisible() const", typeof(bool));
		}
		public void SetStatusBarVisible(bool visible) {
			interceptor.Invoke("setStatusBarVisible$", "setStatusBarVisible(bool)", typeof(void), typeof(bool), visible);
		}
		public bool IsStatusBarVisible() {
			return (bool) interceptor.Invoke("isStatusBarVisible", "isStatusBarVisible() const", typeof(bool));
		}
		public void SetResizable(bool resizable) {
			interceptor.Invoke("setResizable$", "setResizable(bool)", typeof(void), typeof(bool), resizable);
		}
		public bool IsResizable() {
			return (bool) interceptor.Invoke("isResizable", "isResizable() const", typeof(bool));
		}
		public void SetLowerWindow(bool lower) {
			interceptor.Invoke("setLowerWindow$", "setLowerWindow(bool)", typeof(void), typeof(bool), lower);
		}
		public bool LowerWindow() {
			return (bool) interceptor.Invoke("lowerWindow", "lowerWindow() const", typeof(bool));
		}
		public void SetScrollBarsVisible(bool visible) {
			interceptor.Invoke("setScrollBarsVisible$", "setScrollBarsVisible(bool)", typeof(void), typeof(bool), visible);
		}
		public bool ScrollBarsVisible() {
			return (bool) interceptor.Invoke("scrollBarsVisible", "scrollBarsVisible() const", typeof(bool));
		}
		~WindowArgs() {
			interceptor.Invoke("~WindowArgs", "~WindowArgs()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~WindowArgs", "~WindowArgs()", typeof(void));
		}
	}
	}
}
