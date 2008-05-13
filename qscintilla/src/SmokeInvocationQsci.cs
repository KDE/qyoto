namespace QScintilla {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class SmokeInvocationQsci : SmokeInvocation {
		[DllImport("libqscintilla-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_qscintilla();
		
		static SmokeInvocationQsci() {
			Init_qscintilla();
		}
		
		public SmokeInvocationQsci(Type klass, Object obj) : base(klass, obj) {}
	}
}
