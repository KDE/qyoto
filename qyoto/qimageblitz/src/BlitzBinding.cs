namespace QImageBlitz {

	using Qyoto;

	using System;
	using System.Runtime.InteropServices;

	public class InitBlitz {
		[DllImport("libqimageblitz-sharp", CharSet=CharSet.Ansi)]
		static extern void Init_blitz();
		
		public static void InitSmoke() {
			Init_blitz();
		}
	}
}
