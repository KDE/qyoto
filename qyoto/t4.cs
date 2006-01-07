using System;
using System.Runtime.InteropServices;
using Qt;

public class MyWidget : QWidget
{
	public MyWidget() : this(null, null) {}

	public MyWidget(QWidget parent, string name) : base(parent, name) {
		SetMinimumSize( 200, 120 );
		SetMaximumSize( 200, 120 );

		QPushButton quit = new QPushButton( "Quit", this, "quit" );
		quit.SetGeometry( 62, 40, 75, 30 );
		quit.SetFont( new QFont( "Times", 18, (int) QFont.Weight.Bold ) );

		Connect( quit, SIGNAL("clicked()"), qApp, SLOT("quit()") );
	}

	public static int Main(String[] args) {
		QApplication a = new QApplication(args);

		MyWidget w = new MyWidget();
		w.SetGeometry( 100, 100, 200, 120 );
		a.SetMainWidget( w );
		w.Show();
		return a.Exec();
	}
}
