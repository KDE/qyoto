//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  Don't use this class directly; this class is used as a base class for
	///  the KStaticDeleter template to allow polymorphism.
	/// </remarks>		<short> Base class for KStaticDeleter.</short>
	/// 		<see> KStaticDeleter</see>
	/// 		<see> KStaticDeleterHelpers.RegisterStaticDeleter</see>
	/// 		<see> KStaticDeleterHelpers.UnregisterStaticDeleter</see>
	/// 		<see> KStaticDeleterHelpers.DeleteStaticDeleters</see>

	[SmokeClass("KStaticDeleterBase")]
	public class KStaticDeleterBase : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KStaticDeleterBase(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KStaticDeleterBase), this);
		}
		/// <remarks>
		///  Should destruct the resources managed by this KStaticDeleterBase.
		///  Usually you also want to call it in your destructor.
		/// </remarks>		<short>    Should destruct the resources managed by this KStaticDeleterBase.</short>
		/// 		<see> KStaticDeleterHelpers.DeleteStaticDeleters</see>
		[SmokeMethod("destructObject()")]
		public virtual void DestructObject() {
			interceptor.Invoke("destructObject", "destructObject()", typeof(void));
		}
		public KStaticDeleterBase() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KStaticDeleterBase", "KStaticDeleterBase()", typeof(void));
		}
		~KStaticDeleterBase() {
			interceptor.Invoke("~KStaticDeleterBase", "~KStaticDeleterBase()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KStaticDeleterBase", "~KStaticDeleterBase()", typeof(void));
		}
	}
}
