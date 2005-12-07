namespace Qt
{
	using System;
	using System.Runtime.InteropServices;
	
	public class Qyoto : System.Object
	{
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void Init_qyoto();
	}
}

