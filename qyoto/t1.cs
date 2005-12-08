using System;
using System.Runtime.InteropServices;
using Qt;

public class T1 
{
	public static int Main(String[] args) {
string[] myargs = System.Environment.GetCommandLineArgs();
Console.WriteLine("myargs[0]: {0}", myargs[0]);
Console.WriteLine("GetExecutionAssembly: {0}", System.Reflection.Assembly.GetExecutingAssembly().Location);

		QApplication a = new QApplication(args);
		
		QPushButton hello = new QPushButton("Hello world!", null);
		hello.Resize(100, 30);
		
		a.SetMainWidget(hello);
		hello.Show();
		return a.Exec();
	}
}
