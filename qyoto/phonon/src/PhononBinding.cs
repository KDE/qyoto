namespace Phonon {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitPhonon {
		[DllImport("libphonon-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_phonon();
		
		public static void InitSmoke() {
			Init_phonon();
		}
	}
}
