namespace QtScript {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtScript {
		[DllImport("libqtscript-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_qtscript();
		
		public static void InitSmoke() {
			Init_qtscript();
		}
	}
}
