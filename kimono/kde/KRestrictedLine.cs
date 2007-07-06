//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  The KRestrictedLine widget is a variant of QLineEdit which
	///  accepts only a restricted set of characters as input.
	///  All other characters will be discarded and the signal invalidChar()
	///  will be emitted for each of them.
	///  Valid characters can be passed as a string to the constructor
	///  or set afterwards via setValidChars().
	///  The default key bindings of QLineEdit are still in effect.
	///  This is almost like setting a QRegExpValidator on a KLineEdit;
	///  the difference is that with KRestrictedLine it can all be done in Qt designer.
	///  See <see cref="IKRestrictedLineSignals"></see> for signals emitted by KRestrictedLine
	/// </remarks>		<author> Michael Wiedmann <mw@miwie.in-berlin.de>
	///  </author>
	/// 		<short> A line editor for restricted character sets. </short>

	[SmokeClass("KRestrictedLine")]
	public class KRestrictedLine : KLineEdit, IDisposable {
 		protected KRestrictedLine(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KRestrictedLine), this);
		}
		[Q_PROPERTY("QString", "validChars")]
		public string ValidChars {
			get { return (string) interceptor.Invoke("validChars", "validChars()", typeof(string)); }
			set { interceptor.Invoke("setValidChars$", "setValidChars(QString)", typeof(void), typeof(string), value); }
		}
		/// <remarks>
		///  Constructor: This contructor takes three - optional - arguments.
		///   The first two parameters are simply passed on to QLineEdit.
		/// <param> name="parent" pointer to the parent widget
		///    </param></remarks>		<short>    Constructor: This contructor takes three - optional - arguments.</short>
		public KRestrictedLine(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRestrictedLine#", "KRestrictedLine(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KRestrictedLine() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRestrictedLine", "KRestrictedLine()", typeof(void));
		}
		[SmokeMethod("keyPressEvent(QKeyEvent*)")]
		protected override void KeyPressEvent(QKeyEvent e) {
			interceptor.Invoke("keyPressEvent#", "keyPressEvent(QKeyEvent*)", typeof(void), typeof(QKeyEvent), e);
		}
		~KRestrictedLine() {
			interceptor.Invoke("~KRestrictedLine", "~KRestrictedLine()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KRestrictedLine", "~KRestrictedLine()", typeof(void));
		}
		protected new IKRestrictedLineSignals Emit {
			get { return (IKRestrictedLineSignals) Q_EMIT; }
		}
	}

	public interface IKRestrictedLineSignals : IKLineEditSignals {
		/// <remarks>
		///  Emitted when an invalid character was typed.
		///    </remarks>		<short>    Emitted when an invalid character was typed.</short>
		[Q_SIGNAL("void invalidChar(int)")]
		void InvalidChar(int arg1);
	}
}
