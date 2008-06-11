namespace Kimono {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitKimono {
		[DllImport("libkimono", CharSet=CharSet.Ansi)]
		static extern void Init_kimono();
		
		public static void InitSmoke() {
			Init_kimono();
		}
	}
}
