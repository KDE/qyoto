//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;


	[SmokeClass("KImportedBookmarkMenu")]
	public class KImportedBookmarkMenu : KBookmarkMenu, IDisposable {
 		protected KImportedBookmarkMenu(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KImportedBookmarkMenu), this);
		}
		// KImportedBookmarkMenu* KImportedBookmarkMenu(KBookmarkManager* arg1,KBookmarkOwner* arg2,KMenu* arg3,const QString& arg4,const QString& arg5); >>>> NOT CONVERTED
		// KImportedBookmarkMenu* KImportedBookmarkMenu(KBookmarkManager* arg1,KBookmarkOwner* arg2,KMenu* arg3); >>>> NOT CONVERTED
		[SmokeMethod("clear()")]
		public new virtual void Clear() {
			interceptor.Invoke("clear", "clear()", typeof(void));
		}
		[SmokeMethod("refill()")]
		public new virtual void Refill() {
			interceptor.Invoke("refill", "refill()", typeof(void));
		}
		[Q_SLOT("void slotNSLoad()")]
		protected void SlotNSLoad() {
			interceptor.Invoke("slotNSLoad", "slotNSLoad()", typeof(void));
		}
		~KImportedBookmarkMenu() {
			interceptor.Invoke("~KImportedBookmarkMenu", "~KImportedBookmarkMenu()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KImportedBookmarkMenu", "~KImportedBookmarkMenu()", typeof(void));
		}
		protected new IKImportedBookmarkMenuSignals Emit {
			get { return (IKImportedBookmarkMenuSignals) Q_EMIT; }
		}
	}

	public interface IKImportedBookmarkMenuSignals : IKBookmarkMenuSignals {
	}
}
