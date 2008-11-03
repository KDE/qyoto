namespace QtTest {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitQtTest {
		[DllImport("libqttest-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_QtTest();
		
		public static void InitSmoke() {
			Init_QtTest();
		}
	}
}
