//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace DOM {

	using System;
	using Qyoto;


	[SmokeClass("DOM::HTMLFormCollection")]
	public class HTMLFormCollection : DOM.HTMLCollection, IDisposable {
 		protected HTMLFormCollection(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(HTMLFormCollection), this);
		}
		// DOM::HTMLFormCollection* HTMLFormCollection(DOM::NodeImpl* arg1); >>>> NOT CONVERTED
		~HTMLFormCollection() {
			interceptor.Invoke("~HTMLFormCollection", "~HTMLFormCollection()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~HTMLFormCollection", "~HTMLFormCollection()", typeof(void));
		}
	}
	}
}
