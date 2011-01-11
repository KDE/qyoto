namespace QScintilla {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQScintilla {
		[DllImport("libqscintilla-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_qscintilla();
		
		public static void InitSmoke() {
			Init_qscintilla();
		}
	}
}
