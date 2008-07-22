namespace QtUiTools {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtUiTools {
		[DllImport("libqtuitools-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_QtUiTools();
		
		public static void InitSmoke() {
			Init_QtUiTools();
		}
	}
}
