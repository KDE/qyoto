namespace QtWebKit {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtWebKit {
		[DllImport("libqtwebkit-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_qtwebkit();
		
		public static void InitSmoke() {
			Init_qtwebkit();
		}
	}
}
