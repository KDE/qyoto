//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  Draws a button which shows an arrow pointing into a certain direction. The
	///  arrow's alignment on the button depends on the direction it's pointing to,
	///  e.g. a left arrow is aligned at the left border, a upwards arrow at the top
	///  border. This class honors the currently configured KStyle when drawing
	///  the arrow.
	/// </remarks>		<author> Frerich Raabe
	///  </author>
	/// 		<short> Draws a button with an arrow. </short>

	[SmokeClass("KArrowButton")]
	public class KArrowButton : QPushButton, IDisposable {
 		protected KArrowButton(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KArrowButton), this);
		}
		[Q_PROPERTY("int", "arrowType")]
		public new int ArrowType {
			get { return (int) interceptor.Invoke("arrowTp", "arrowTp()", typeof(int)); }
			set { interceptor.Invoke("setArrowTp$", "setArrowTp(int)", typeof(void), typeof(int), value); }
		}
		/// <remarks>
		///  Constructs an arrow button.
		/// <param> name="parent" This button's parent
		/// </param><param> name="arrow" The direction the arrrow should be pointing in
		/// 		 </param></remarks>		<short>    Constructs an arrow button.</short>
		public KArrowButton(QWidget parent, Qt.ArrowType arrow) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KArrowButton#$", "KArrowButton(QWidget*, Qt::ArrowType)", typeof(void), typeof(QWidget), parent, typeof(Qt.ArrowType), arrow);
		}
		public KArrowButton(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KArrowButton#", "KArrowButton(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KArrowButton() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KArrowButton", "KArrowButton()", typeof(void));
		}
		/// <remarks>
		///  Reimplemented from QPushButton.
		/// 		 </remarks>		<short>    Reimplemented from QPushButton.</short>
		[SmokeMethod("sizeHint() const")]
		public override QSize SizeHint() {
			return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
		}
		/// <remarks>
		///  Defines in what direction the arrow is pointing to. Will repaint the
		///  button if necessary.
		/// <param> name="a" The direction this arrow should be pointing in
		/// 		 </param></remarks>		<short>    Defines in what direction the arrow is pointing to.</short>
		[Q_SLOT("void setArrowType(Qt::ArrowType)")]
		public void SetArrowType(Qt.ArrowType a) {
			interceptor.Invoke("setArrowType$", "setArrowType(Qt::ArrowType)", typeof(void), typeof(Qt.ArrowType), a);
		}
		/// <remarks>
		///  Reimplemented from QPushButton.
		/// 		 </remarks>		<short>    Reimplemented from QPushButton.</short>
		[SmokeMethod("paintEvent(QPaintEvent*)")]
		protected override void PaintEvent(QPaintEvent arg1) {
			interceptor.Invoke("paintEvent#", "paintEvent(QPaintEvent*)", typeof(void), typeof(QPaintEvent), arg1);
		}
		~KArrowButton() {
			interceptor.Invoke("~KArrowButton", "~KArrowButton()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KArrowButton", "~KArrowButton()", typeof(void));
		}
		protected new IKArrowButtonSignals Emit {
			get { return (IKArrowButtonSignals) Q_EMIT; }
		}
	}

	public interface IKArrowButtonSignals : IQPushButtonSignals {
	}
}
