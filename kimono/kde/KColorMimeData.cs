//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  Drag-and-drop and clipboard mimedata manipulation for QColor objects. The according MIME type
	///  is set to application/x-color.
	///  See the Qt drag'n'drop documentation.
	///  </remarks>		<short>    Drag-and-drop and clipboard mimedata manipulation for QColor objects.</short>

	[SmokeClass("KColorMimeData")]
	public class KColorMimeData : Object {
		protected SmokeInvocation interceptor = null;
		private static SmokeInvocation staticInterceptor = null;
		static KColorMimeData() {
			staticInterceptor = new SmokeInvocation(typeof(KColorMimeData), null);
		}
		/// <remarks>
		///  Sets the color and text representation fields for the specified color in the mimedata object:
		///  application/x-color and text/plain types are set
		///      </remarks>		<short>    Sets the color and text representation fields for the specified color in the mimedata object:  application/x-color and text/plain types are set      </short>
		public static void PopulateMimeData(QMimeData mimeData, QColor color) {
			staticInterceptor.Invoke("populateMimeData##", "populateMimeData(QMimeData*, const QColor&)", typeof(void), typeof(QMimeData), mimeData, typeof(QColor), color);
		}
		/// <remarks>
		///  Returns true if the MIME data <code>mimeData</code> contains a color object.
		///  First checks for application/x-color and if that failes for a text/plain entry, which
		///  represents a color in the format \#hexnumbers
		///      </remarks>		<short>    Returns true if the MIME data <code>mimeData</code> contains a color object.</short>
		public static bool CanDecode(QMimeData mimeData) {
			return (bool) staticInterceptor.Invoke("canDecode#", "canDecode(const QMimeData*)", typeof(bool), typeof(QMimeData), mimeData);
		}
		/// <remarks>
		///  Decodes the MIME data <code>mimeData</code> and returns the resulting color.
		///  First tries application/x-color and if that fails a text/plain entry, which
		///  represents a color in the format \#hexnumbers. If this fails too,
		///  an invalid QColor object is returned, use QColor.IsValid() to test it.
		///      </remarks>		<short>    Decodes the MIME data <code>mimeData</code> and returns the resulting color.</short>
		public static QColor FromMimeData(QMimeData mimeData) {
			return (QColor) staticInterceptor.Invoke("fromMimeData#", "fromMimeData(const QMimeData*)", typeof(QColor), typeof(QMimeData), mimeData);
		}
		/// <remarks>
		///  Creates a color drag object. Either you have to start this drag or delete it
		///  The drag object's mime data has the application/x-color and text/plain type set and a pixmap
		///  filled with the specified color, which is going to be displayed next to the mouse cursor
		///      </remarks>		<short>    Creates a color drag object.</short>
		public static QDrag CreateDrag(QColor color, QWidget dragsource) {
			return (QDrag) staticInterceptor.Invoke("createDrag##", "createDrag(const QColor&, QWidget*)", typeof(QDrag), typeof(QColor), color, typeof(QWidget), dragsource);
		}
	}
}
