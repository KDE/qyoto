using System;
using Qyoto;

public class MyWidget : QWidget
{
	public MyWidget() : this(null) {}

	public MyWidget(QWidget parent) : base(parent) {
		SetFixedSize(200, 120);

		QPushButton quit = new QPushButton( Tr("Quit"), this );
		quit.SetGeometry( 62, 40, 75, 30 );
		quit.Font = new QFont( "Times", 18, (int) QFont.Weight.Bold );

		Connect( quit, SIGNAL("clicked()"), qApp, SLOT("quit()") );
	}

	public static int Main(String[] args) {
		new QApplication(args);

		MyWidget w = new MyWidget();
		w.SetGeometry( 100, 100, 200, 120 );
		w.Show();
		return QApplication.Exec();
	}
}
