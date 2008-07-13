namespace QtScript {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtScript {
		[DllImport("libqtscript-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_QtScript();
		
		public static void InitSmoke() {
			Init_QtScript();
		}
	}
}
