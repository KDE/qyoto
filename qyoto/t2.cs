using System;
using System.Runtime.InteropServices;
using Qt;
namespace Qt {

public class T2 : Qt
{
	public static int Main(String[] args) {
		QApplication a = new QApplication(args);
		
		QPushButton quit = new QPushButton( "Quit", null );
		quit.Resize( 75, 30 );
		quit.SetFont( new QFont( "Times", 18, (int) QFont.E_Weight.Bold ) );

		QObject.Connect( quit, SIGNAL("clicked()"), a, SLOT("quit()") );
		
		a.SetMainWidget(quit);
		quit.Show();
		return a.Exec();
	}
}

}
