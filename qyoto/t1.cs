using System;
using System.Runtime.InteropServices;
using Qt;

public class T1 
{
	public static int Main(String[] args) {
		QApplication a = new QApplication(args);
		
		QPushButton hello = new QPushButton("Hello world!", null);
		hello.Resize(100, 30);
		
		hello.Show();
		return QApplication.Exec();
	}
}
