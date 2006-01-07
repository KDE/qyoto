//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QPalette : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QPalette(Type dummy) {}
		interface IQPaletteProxy {
			bool op_equals(QPalette lhs, QPalette p);
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

		enum ColorGroup {
			Active = 0,
			Disabled = 1,
			Inactive = 2,
			NColorGroups = 3,
			Current = 4,
			All = 5,
			Normal = Active,
		}
		enum ColorRole {
			Foreground = 0,
			Button = 1,
			Light = 2,
			Midlight = 3,
			Dark = 4,
			Mid = 5,
			Text = 6,
			BrightText = 7,
			ButtonText = 8,
			Base = 9,
			Background = 10,
			Shadow = 11,
			Highlight = 12,
			HighlightedText = 13,
			Link = 14,
			LinkVisited = 15,
			AlternateBase = 16,
			NColorRoles = 17,
			NoRole = NColorRoles,
		}
		public QPalette() : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette();
		}
		private void NewQPalette() {
			ProxyQPalette().NewQPalette();
		}
		public QPalette(QColor button) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(button);
		}
		private void NewQPalette(QColor button) {
			ProxyQPalette().NewQPalette(button);
		}
		public QPalette(int button) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(button);
		}
		private void NewQPalette(int button) {
			ProxyQPalette().NewQPalette(button);
		}
		public QPalette(QColor button, QColor background) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(button,background);
		}
		private void NewQPalette(QColor button, QColor background) {
			ProxyQPalette().NewQPalette(button,background);
		}
		public QPalette(QBrush foreground, QBrush button, QBrush light, QBrush dark, QBrush mid, QBrush text, QBrush bright_text, QBrush arg8, QBrush background) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(foreground,button,light,dark,mid,text,bright_text,arg8,background);
		}
		private void NewQPalette(QBrush foreground, QBrush button, QBrush light, QBrush dark, QBrush mid, QBrush text, QBrush bright_text, QBrush arg8, QBrush background) {
			ProxyQPalette().NewQPalette(foreground,button,light,dark,mid,text,bright_text,arg8,background);
		}
		public QPalette(QColor foreground, QColor background, QColor light, QColor dark, QColor mid, QColor text, QColor arg7) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(foreground,background,light,dark,mid,text,arg7);
		}
		private void NewQPalette(QColor foreground, QColor background, QColor light, QColor dark, QColor mid, QColor text, QColor arg7) {
			ProxyQPalette().NewQPalette(foreground,background,light,dark,mid,text,arg7);
		}
		public QPalette(QPalette palette) : this((Type) null) {
			CreateQPaletteProxy();
			NewQPalette(palette);
		}
		private void NewQPalette(QPalette palette) {
			ProxyQPalette().NewQPalette(palette);
		}
		//  operator QVariant(); >>>> NOT CONVERTED
		public int CurrentColorGroup() {
			return ProxyQPalette().CurrentColorGroup();
		}
		public void SetCurrentColorGroup(int cg) {
			ProxyQPalette().SetCurrentColorGroup(cg);
		}
		public QColor Color(int cg, int cr) {
			return ProxyQPalette().Color(cg,cr);
		}
		public QBrush Brush(int cg, int cr) {
			return ProxyQPalette().Brush(cg,cr);
		}
		public void SetColor(int cg, int cr, QColor color) {
			ProxyQPalette().SetColor(cg,cr,color);
		}
		public void SetColor(int cr, QColor color) {
			ProxyQPalette().SetColor(cr,color);
		}
		public void SetBrush(int cr, QBrush brush) {
			ProxyQPalette().SetBrush(cr,brush);
		}
		public void SetBrush(int cg, int cr, QBrush brush) {
			ProxyQPalette().SetBrush(cg,cr,brush);
		}
		public void SetColorGroup(int cr, QBrush foreground, QBrush button, QBrush light, QBrush dark, QBrush mid, QBrush text, QBrush bright_text, QBrush arg9, QBrush background) {
			ProxyQPalette().SetColorGroup(cr,foreground,button,light,dark,mid,text,bright_text,arg9,background);
		}
		public bool IsEqual(int cr1, int cr2) {
			return ProxyQPalette().IsEqual(cr1,cr2);
		}
		public QColor Color(int cr) {
			return ProxyQPalette().Color(cr);
		}
		public QBrush Brush(int cr) {
			return ProxyQPalette().Brush(cr);
		}
		public QBrush Foreground() {
			return ProxyQPalette().Foreground();
		}
		public QBrush Button() {
			return ProxyQPalette().Button();
		}
		public QBrush Light() {
			return ProxyQPalette().Light();
		}
		public QBrush Dark() {
			return ProxyQPalette().Dark();
		}
		public QBrush Mid() {
			return ProxyQPalette().Mid();
		}
		public QBrush Text() {
			return ProxyQPalette().Text();
		}
		public QBrush Base() {
			return ProxyQPalette().Base();
		}
		public QBrush AlternateBase() {
			return ProxyQPalette().AlternateBase();
		}
		public QBrush Background() {
			return ProxyQPalette().Background();
		}
		public QBrush Midlight() {
			return ProxyQPalette().Midlight();
		}
		public QBrush BrightText() {
			return ProxyQPalette().BrightText();
		}
		public QBrush ButtonText() {
			return ProxyQPalette().ButtonText();
		}
		public QBrush Shadow() {
			return ProxyQPalette().Shadow();
		}
		public QBrush Highlight() {
			return ProxyQPalette().Highlight();
		}
		public QBrush HighlightedText() {
			return ProxyQPalette().HighlightedText();
		}
		public QBrush Link() {
			return ProxyQPalette().Link();
		}
		public QBrush LinkVisited() {
			return ProxyQPalette().LinkVisited();
		}
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
		public bool IsCopyOf(QPalette p) {
			return ProxyQPalette().IsCopyOf(p);
		}
		public int SerialNumber() {
			return ProxyQPalette().SerialNumber();
		}
		public QPalette Resolve(QPalette arg1) {
			return ProxyQPalette().Resolve(arg1);
		}
		public uint Resolve() {
			return ProxyQPalette().Resolve();
		}
		public void Resolve(uint mask) {
			ProxyQPalette().Resolve(mask);
		}
		~QPalette() {
			ProxyQPalette().Dispose();
		}
		public void Dispose() {
			ProxyQPalette().Dispose();
		}
	}
}