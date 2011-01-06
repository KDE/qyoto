namespace Nepomuk {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitNepomuk {
		[DllImport("libnepomuk-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_nepomuk();
		
		public static void InitSmoke() {
			Init_nepomuk();
		}
	}
}
