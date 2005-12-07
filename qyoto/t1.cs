using System;
using System.Runtime.InteropServices;
using Qt;

public class T1 
{
	[DllImport("libqyoto", CharSet=CharSet.Ansi)]
	static extern void Init_qyoto();

	public static int Main(String[] args) {
		Init_qyoto();
		QApplication a = new QApplication(args);
		
		QPushButton hello = new QPushButton("Hello world!", null);
		hello.Resize(100, 30);
		
		a.SetMainWidget(hello);
		hello.Show();
		return a.Exec();
	}
}
