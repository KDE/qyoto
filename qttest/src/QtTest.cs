namespace QtTest {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtTest {
		[DllImport("libqttest-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_qttest();
		
		public static void InitSmoke() {
			Init_qttest();
		}
	}
}
