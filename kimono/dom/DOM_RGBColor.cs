//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;

	/// <remarks>
	///  The <code>RGBColor</code> interface is used to represent any <a
	///  href="http://www.w3.org/TR/REC-CSS2/syndata.html#value-def-color">
	///  RGB color </a> value. This interface reflects the values in the
	///  underlying style property. Hence, modifications made through this
	///  interface modify the style property.
	///  </remarks>		<short>    The <code>RGBColor</code> interface is used to represent any <a  href="http://www.</short>

	[SmokeClass("DOM::RGBColor")]
	public class RGBColor : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected RGBColor(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(RGBColor), this);
		}
		public RGBColor() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("RGBColor", "RGBColor()", typeof(void));
		}
		public RGBColor(uint color) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("RGBColor$", "RGBColor(QRgb)", typeof(void), typeof(uint), color);
		}
		public RGBColor(DOM.RGBColor other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("RGBColor#", "RGBColor(const DOM::RGBColor&)", typeof(void), typeof(DOM.RGBColor), other);
		}
		/// <remarks>
		///  This attribute is used for the red value of the RGB color.
		///      </remarks>		<short>    This attribute is used for the red value of the RGB color.</short>
		public DOM.CSSPrimitiveValue Red() {
			return (DOM.CSSPrimitiveValue) interceptor.Invoke("red", "red() const", typeof(DOM.CSSPrimitiveValue));
		}
		/// <remarks>
		///  This attribute is used for the green value of the RGB color.
		///      </remarks>		<short>    This attribute is used for the green value of the RGB color.</short>
		public DOM.CSSPrimitiveValue Green() {
			return (DOM.CSSPrimitiveValue) interceptor.Invoke("green", "green() const", typeof(DOM.CSSPrimitiveValue));
		}
		/// <remarks>
		///  This attribute is used for the blue value of the RGB color.
		///      </remarks>		<short>    This attribute is used for the blue value of the RGB color.</short>
		public DOM.CSSPrimitiveValue Blue() {
			return (DOM.CSSPrimitiveValue) interceptor.Invoke("blue", "blue() const", typeof(DOM.CSSPrimitiveValue));
		}
		/// <remarks>
		///      </remarks>		<short>   </short>
		public uint Color() {
			return (uint) interceptor.Invoke("color", "color() const", typeof(uint));
		}
		~RGBColor() {
			interceptor.Invoke("~RGBColor", "~RGBColor()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~RGBColor", "~RGBColor()", typeof(void));
		}
	}
	}
}
