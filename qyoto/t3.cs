using System;
using System.Runtime.InteropServices;
using Qt;
namespace Qt {

public class T3 : Qt
{
	public static int Main(String[] args) {
		QApplication a = new QApplication(args);
		
		QVBox box = new QVBox();
		box.Resize( 200, 120 );

		QPushButton quit = new QPushButton( "Quit", box );
		quit.SetFont( new QFont( "Times", 18, (int) QFont.E_Weight.Bold ) );

		QObject.Connect( quit, SIGNAL("clicked()"), a, SLOT("quit()") );
		
		a.SetMainWidget(box);
		box.Show();
		return a.Exec();
	}
}

}
