using System;
using Qyoto;

public class T2 : Qt
{
	public static int Main(String[] args) {
		QApplication a = new QApplication(args);
		
		QPushButton quit = new QPushButton( "Quit", null );
		quit.Resize( 75, 30 );
		quit.Font = new QFont( "Times", 18, (int) QFont.Weight.Bold );

		QObject.Connect( quit, SIGNAL("clicked()"), a, SLOT("quit()") );
		
		quit.Show();
		return QApplication.Exec();
	}
}
