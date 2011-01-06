namespace KHTML {
	using Qyoto;
	using System;
	using System.Runtime.InteropServices;

	public class InitKHTML {
		[DllImport("libkhtml-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_khtml();
		
		public static void InitSmoke() {
			Init_khtml();
		}
	}
}
