//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  A tiny abstract class with just one method:
	///  pixmapFor()
	///  It will be called whenever an icon is searched for <code>text.</code>
	///  Used e.g. by KHistoryCombo
	/// </remarks>		<author> Carsten Pfeiffer <pfeiffer@kde.org>
	/// </author>
	/// 		<short> an abstract interface for looking up icons.</short>

	[SmokeClass("KPixmapProvider")]
	public abstract class KPixmapProvider : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KPixmapProvider(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KPixmapProvider), this);
		}
		/// <remarks>
		///  You may subclass this and return a pixmap of size <code>size</code> for <code>text.</code>
		/// <param> name="text" the text that is associated with the pixmap
		/// </param><param> name="size" the size of the icon in pixels, 0 for defaylt size.
		///              See K3Icon.StdSize.
		/// </param></remarks>		<return> the pixmap for the arguments, or null if there is none
		///      </return>
		/// 		<short>    You may subclass this and return a pixmap of size <code>size</code> for <code>text.</code></short>
		[SmokeMethod("pixmapFor(const QString&, int)")]
		public abstract QPixmap PixmapFor(string text, int size);
		public KPixmapProvider() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPixmapProvider", "KPixmapProvider()", typeof(void));
		}
	}
}
