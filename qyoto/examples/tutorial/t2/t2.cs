using System;
using Qyoto;

public class T2 : Qt
{
	public static int Main(String[] args) {
		QApplication app = new QApplication(args);
		
		QPushButton quit = new QPushButton( "Quit" );
		quit.Resize( 75, 30 );
		quit.Font = new QFont( "Times", 18, (int) QFont.Weight.Bold );

		QObject.Connect( quit, SIGNAL("clicked()"), app, SLOT("quit()") );
		
		quit.Show();
		return QApplication.Exec();
	}
}
