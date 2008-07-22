namespace Akonadi {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitAkonadi {
		[DllImport("libakonadi-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_Akonadi();
		
		public static void InitSmoke() {
			Init_Akonadi();
		}
	}
}
