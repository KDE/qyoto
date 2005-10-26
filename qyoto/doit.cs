using Qt;
using System;
using System.Runtime.InteropServices;

public class Doit {
	[DllImport("libqyoto", CharSet=CharSet.Ansi)]
	static extern void Init_qyoto();
	
	static void Main(String[] args) {
		Init_qyoto();
		
		QFont myFont = new QFont();
		QFont yourFont = new QFont(myFont);
		myFont.SetPointSize(18);
		int pointSize = myFont.PointSize();
		Console.WriteLine("PointSize: {0}", pointSize);
		QFont.RemoveSubstitution("Times Roman");
		QFont.InsertSubstitutions("Times Roman", new string[] { "foo", "bar"});
	}
}
