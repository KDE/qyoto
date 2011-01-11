using System;
using Qyoto;

public class T3 : Qt
{
	public static int Main(String[] args) {
		QApplication app = new QApplication(args);
		
		QWidget window = new QWidget();
		window.Resize(200, 120);

		QPushButton quit = new QPushButton( "Quit", window );
		quit.Font = new QFont( "Times", 18, (int) QFont.Weight.Bold );
		quit.SetGeometry(10, 40, 180, 40);

		QObject.Connect( quit, SIGNAL("clicked()"), app, SLOT("quit()") );
		
		window.Show();
		return QApplication.Exec();
	}
}

