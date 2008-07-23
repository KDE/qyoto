namespace KTextEditor {
	using Qyoto;
	using System;
	using System.Runtime.InteropServices;

	public class InitKTextEditor {
		[DllImport("libktexteditor-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_ktexteditor();
		
		public static void InitSmoke() {
			Init_ktexteditor();
		}
	}
}
