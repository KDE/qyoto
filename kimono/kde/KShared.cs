namespace Kimono {

	using System;
	using Qyoto;

	public class KShared : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KShared(Type dummy) {}
	}
}
