using System;
using System.Runtime.InteropServices;
using Qt;

public class MyWidget : QVBox
{
	public MyWidget() : this(null, null) {}

	public MyWidget(QWidget parent, string name) : base(parent, name) {
		QPushButton quit = new QPushButton( "Quit", this, "quit" );
		quit.SetFont( new QFont( "Times", 18, (int) QFont.E_Weight.Bold ) );

		Connect( quit, SIGNAL("clicked()"), qApp, SLOT("quit()") );

		QLCDNumber lcd  = new QLCDNumber( 2, this, "lcd" );

		QSlider slider = new QSlider( (int) Orientation.Horizontal, this, "slider" );
		slider.SetRange( 0, 99 );
		slider.SetValue( 0 );

		Connect( slider, SIGNAL("valueChanged(int)"), lcd, SLOT("display(int)") );
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
