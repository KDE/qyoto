//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QTextBlock")]
	public class QTextBlock : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QTextBlock(Type dummy) {}
		interface IQTextBlockProxy {
			bool op_equals(QTextBlock lhs, QTextBlock o);
			bool op_lt(QTextBlock lhs, QTextBlock o);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTextBlock), this);
			_interceptor = (QTextBlock) realProxy.GetTransparentProxy();
		}
		private QTextBlock ProxyQTextBlock() {
			return (QTextBlock) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTextBlock() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTextBlockProxy), null);
			_staticInterceptor = (IQTextBlockProxy) realProxy.GetTransparentProxy();
		}
		private static IQTextBlockProxy StaticQTextBlock() {
			return (IQTextBlockProxy) _staticInterceptor;
		}

		public QTextBlock() : this((Type) null) {
			CreateProxy();
			NewQTextBlock();
		}
		[SmokeMethod("QTextBlock", "()", "")]
		private void NewQTextBlock() {
			ProxyQTextBlock().NewQTextBlock();
		}
		public QTextBlock(QTextBlock o) : this((Type) null) {
			CreateProxy();
			NewQTextBlock(o);
		}
		[SmokeMethod("QTextBlock", "(const QTextBlock&)", "#")]
		private void NewQTextBlock(QTextBlock o) {
			ProxyQTextBlock().NewQTextBlock(o);
		}
		[SmokeMethod("isValid", "() const", "")]
		public bool IsValid() {
			return ProxyQTextBlock().IsValid();
		}
		[SmokeMethod("operator==", "(const QTextBlock&) const", "#")]
		public static bool operator==(QTextBlock lhs, QTextBlock o) {
			return StaticQTextBlock().op_equals(lhs,o);
		}
		public static bool operator!=(QTextBlock lhs, QTextBlock o) {
			return !StaticQTextBlock().op_equals(lhs,o);
		}
		public override bool Equals(object o) {
			if (!(o is QTextBlock)) { return false; }
			return this == (QTextBlock) o;
		}
		public override int GetHashCode() {
			return ProxyQTextBlock().GetHashCode();
		}
		[SmokeMethod("operator<", "(const QTextBlock&) const", "#")]
		public static bool operator<(QTextBlock lhs, QTextBlock o) {
			return StaticQTextBlock().op_lt(lhs,o);
		}
		public static bool operator>(QTextBlock lhs, QTextBlock o) {
			return !StaticQTextBlock().op_lt(lhs,o)
						&& !StaticQTextBlock().op_equals(lhs,o);
		}
		[SmokeMethod("position", "() const", "")]
		public int Position() {
			return ProxyQTextBlock().Position();
		}
		[SmokeMethod("length", "() const", "")]
		public int Length() {
			return ProxyQTextBlock().Length();
		}
		[SmokeMethod("contains", "(int) const", "$")]
		public bool Contains(int position) {
			return ProxyQTextBlock().Contains(position);
		}
		[SmokeMethod("layout", "() const", "")]
		public QLayout Layout() {
			return ProxyQTextBlock().Layout();
		}
		[SmokeMethod("blockFormat", "() const", "")]
		public QTextBlockFormat BlockFormat() {
			return ProxyQTextBlock().BlockFormat();
		}
		[SmokeMethod("blockFormatIndex", "() const", "")]
		public int BlockFormatIndex() {
			return ProxyQTextBlock().BlockFormatIndex();
		}
		[SmokeMethod("charFormat", "() const", "")]
		public QTextCharFormat CharFormat() {
			return ProxyQTextBlock().CharFormat();
		}
		[SmokeMethod("charFormatIndex", "() const", "")]
		public int CharFormatIndex() {
			return ProxyQTextBlock().CharFormatIndex();
		}
		[SmokeMethod("text", "() const", "")]
		public string Text() {
			return ProxyQTextBlock().Text();
		}
		// const QTextDocument* document(); >>>> NOT CONVERTED
		[SmokeMethod("textList", "() const", "")]
		public QTextList TextList() {
			return ProxyQTextBlock().TextList();
		}
		[SmokeMethod("userData", "() const", "")]
		public QTextBlockUserData UserData() {
			return ProxyQTextBlock().UserData();
		}
		[SmokeMethod("setUserData", "(QTextBlockUserData*)", "#")]
		public void SetUserData(QTextBlockUserData data) {
			ProxyQTextBlock().SetUserData(data);
		}
		[SmokeMethod("userState", "() const", "")]
		public int UserState() {
			return ProxyQTextBlock().UserState();
		}
		[SmokeMethod("setUserState", "(int)", "$")]
		public void SetUserState(int state) {
			ProxyQTextBlock().SetUserState(state);
		}
		[SmokeMethod("next", "() const", "")]
		public QTextBlock Next() {
			return ProxyQTextBlock().Next();
		}
		[SmokeMethod("previous", "() const", "")]
		public QTextBlock Previous() {
			return ProxyQTextBlock().Previous();
		}
		// QTextDocumentPrivate* docHandle(); >>>> NOT CONVERTED
		~QTextBlock() {
			DisposeQTextBlock();
		}
		public void Dispose() {
			DisposeQTextBlock();
		}
		[SmokeMethod("~QTextBlock", "()", "")]
		private void DisposeQTextBlock() {
			ProxyQTextBlock().DisposeQTextBlock();
		}
	}
}
