namespace Kimono {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class SmokeInvocationKDE : SmokeInvocation {
		[DllImport("libkimono", CharSet=CharSet.Ansi)]
		public static extern void Init_kimono();
		
		static SmokeInvocationKDE() {
			Init_kimono();
		}
		
		public SmokeInvocationKDE(Type klass, Object obj) : base(klass, obj) {}
	}
}
