//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	[SmokeClass("QPalette")]
	public class QPalette : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QPalette(Type dummy) {}
		interface IQPaletteProxy {
			bool op_equals(QPalette lhs, QPalette p);
			QColorGroup.ColorRole ForegroundRoleFromMode(Qt.BackgroundMode mode);
			QColorGroup.ColorRole BackgroundRoleFromMode(Qt.BackgroundMode mode);
		}

		protected void CreateQPaletteProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QPalette), this);
			_interceptor = (QPalette) realProxy.GetTransparentProxy();
		}
		private QPalette ProxyQPalette() {
			return (QPalette) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QPalette() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQPaletteProxy), null);
			_staticInterceptor = (IQPaletteProxy) realProxy.GetTransparentProxy();
		}
		private static IQPaletteProxy StaticQPalette() {
			return (IQPaletteProxy) _staticInterceptor;
		}

		public enum ColorGroup {
			Disabled = 0,
			Active = 1,
			Inactive = 2,
			NColorGroups = 3,
			Normal = Active,
		}
		public QPalette() : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette();
		}
		[SmokeMethod("QPalette()")]
		private void NewQPalette() {
			ProxyQPalette().NewQPalette();
		}
		public QPalette(QColor button) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(button);
		}
		[SmokeMethod("QPalette(const QColor&)")]
		private void NewQPalette(QColor button) {
			ProxyQPalette().NewQPalette(button);
		}
		public QPalette(QColor button, QColor background) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(button,background);
		}
		[SmokeMethod("QPalette(const QColor&, const QColor&)")]
		private void NewQPalette(QColor button, QColor background) {
			ProxyQPalette().NewQPalette(button,background);
		}
		public QPalette(QColorGroup active, QColorGroup disabled, QColorGroup inactive) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(active,disabled,inactive);
		}
		[SmokeMethod("QPalette(const QColorGroup&, const QColorGroup&, const QColorGroup&)")]
		private void NewQPalette(QColorGroup active, QColorGroup disabled, QColorGroup inactive) {
			ProxyQPalette().NewQPalette(active,disabled,inactive);
		}
		public QPalette(QPalette arg1) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(arg1);
		}
		[SmokeMethod("QPalette(const QPalette&)")]
		private void NewQPalette(QPalette arg1) {
			ProxyQPalette().NewQPalette(arg1);
		}
		[SmokeMethod("color(QPalette::ColorGroup, QColorGroup::ColorRole) const")]
		public QColor Color(QPalette.ColorGroup arg1, QColorGroup.ColorRole arg2) {
			return ProxyQPalette().Color(arg1,arg2);
		}
		[SmokeMethod("brush(QPalette::ColorGroup, QColorGroup::ColorRole) const")]
		public QBrush Brush(QPalette.ColorGroup arg1, QColorGroup.ColorRole arg2) {
			return ProxyQPalette().Brush(arg1,arg2);
		}
		[SmokeMethod("setColor(QPalette::ColorGroup, QColorGroup::ColorRole, const QColor&)")]
		public void SetColor(QPalette.ColorGroup arg1, QColorGroup.ColorRole arg2, QColor arg3) {
			ProxyQPalette().SetColor(arg1,arg2,arg3);
		}
		[SmokeMethod("setBrush(QPalette::ColorGroup, QColorGroup::ColorRole, const QBrush&)")]
		public void SetBrush(QPalette.ColorGroup arg1, QColorGroup.ColorRole arg2, QBrush arg3) {
			ProxyQPalette().SetBrush(arg1,arg2,arg3);
		}
		[SmokeMethod("setColor(QColorGroup::ColorRole, const QColor&)")]
		public void SetColor(QColorGroup.ColorRole arg1, QColor arg2) {
			ProxyQPalette().SetColor(arg1,arg2);
		}
		[SmokeMethod("setBrush(QColorGroup::ColorRole, const QBrush&)")]
		public void SetBrush(QColorGroup.ColorRole arg1, QBrush arg2) {
			ProxyQPalette().SetBrush(arg1,arg2);
		}
		[SmokeMethod("copy() const")]
		public QPalette Copy() {
			return ProxyQPalette().Copy();
		}
		[SmokeMethod("active() const")]
		public QColorGroup Active() {
			return ProxyQPalette().Active();
		}
		[SmokeMethod("disabled() const")]
		public QColorGroup Disabled() {
			return ProxyQPalette().Disabled();
		}
		[SmokeMethod("inactive() const")]
		public QColorGroup Inactive() {
			return ProxyQPalette().Inactive();
		}
		[SmokeMethod("normal() const")]
		public QColorGroup Normal() {
			return ProxyQPalette().Normal();
		}
		[SmokeMethod("setActive(const QColorGroup&)")]
		public void SetActive(QColorGroup arg1) {
			ProxyQPalette().SetActive(arg1);
		}
		[SmokeMethod("setDisabled(const QColorGroup&)")]
		public void SetDisabled(QColorGroup arg1) {
			ProxyQPalette().SetDisabled(arg1);
		}
		[SmokeMethod("setInactive(const QColorGroup&)")]
		public void SetInactive(QColorGroup arg1) {
			ProxyQPalette().SetInactive(arg1);
		}
		[SmokeMethod("setNormal(const QColorGroup&)")]
		public void SetNormal(QColorGroup cg) {
			ProxyQPalette().SetNormal(cg);
		}
		[SmokeMethod("operator==(const QPalette&) const")]
		public static bool operator==(QPalette lhs, QPalette p) {
			return StaticQPalette().op_equals(lhs,p);
		}
		public static bool operator!=(QPalette lhs, QPalette p) {
			return !StaticQPalette().op_equals(lhs,p);
		}
		public override bool Equals(object o) {
			if (!(o is QPalette)) { return false; }
			return this == (QPalette) o;
		}
		public override int GetHashCode() {
			return ProxyQPalette().GetHashCode();
		}
		[SmokeMethod("isCopyOf(const QPalette&)")]
		public bool IsCopyOf(QPalette arg1) {
			return ProxyQPalette().IsCopyOf(arg1);
		}
		[SmokeMethod("serialNumber() const")]
		public int SerialNumber() {
			return ProxyQPalette().SerialNumber();
		}
		[SmokeMethod("foregroundRoleFromMode(Qt::BackgroundMode)")]
		public static QColorGroup.ColorRole ForegroundRoleFromMode(Qt.BackgroundMode mode) {
			return StaticQPalette().ForegroundRoleFromMode(mode);
		}
		[SmokeMethod("backgroundRoleFromMode(Qt::BackgroundMode)")]
		public static QColorGroup.ColorRole BackgroundRoleFromMode(Qt.BackgroundMode mode) {
			return StaticQPalette().BackgroundRoleFromMode(mode);
		}
		~QPalette() {
			DisposeQPalette();
		}
		public void Dispose() {
			DisposeQPalette();
		}
		private void DisposeQPalette() {
			ProxyQPalette().DisposeQPalette();
		}
	}
}