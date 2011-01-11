using System;
using Qyoto;

public class LCDRange : QWidget
{
	public LCDRange() : this(null) {}

	public LCDRange(QWidget parent) : base(parent) {
		QLCDNumber lcd  = new QLCDNumber( 2, this );
		lcd.segmentStyle = QLCDNumber.SegmentStyle.Filled;

		QSlider slider = new QSlider( Orientation.Horizontal, this );
		slider.SetRange( 0, 99 );
		slider.Value = 0;
		Connect( slider, SIGNAL("valueChanged(int)"), lcd, SLOT("display(int)") );

		QVBoxLayout layout = new QVBoxLayout();
		layout.AddWidget(lcd);
		layout.AddWidget(slider);
		SetLayout(layout);
	}
}

public class MyWidget : QWidget
{
	public MyWidget() : this(null) {}

	public MyWidget(QWidget parent) : base(parent) {
		QPushButton quit = new QPushButton( "Quit", this );
		quit.Font = new QFont( "Times", 18, (int) QFont.Weight.Bold );

		Connect( quit, SIGNAL("clicked()"), qApp, SLOT("quit()") );

		QGridLayout grid = new QGridLayout();

		for ( int row = 0; row < 3; row++ ) {
			for ( int column = 0; column < 3; column++ ) {
				LCDRange lcdRange = new LCDRange();
				grid.AddWidget(lcdRange, row, column);
			}
		}

		QVBoxLayout layout = new QVBoxLayout();
		layout.AddWidget(quit);
		layout.AddLayout(grid);
		SetLayout(layout);
	}

	public static int Main(String[] args) {
		new QApplication(args);

		MyWidget w = new MyWidget();
		w.Show();
		return QApplication.Exec();
	}
}
