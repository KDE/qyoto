namespace Soprano {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitSoprano {
		[DllImport("libsoprano-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_soprano();
		
		public static void InitSmoke() {
			Init_soprano();
		}
	}
}
