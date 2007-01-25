using System;
using Qyoto;

public class MyWidget : QWidget
{
	public MyWidget() : this(null) {}

	public MyWidget(QWidget parent) : base(parent) {
		QPushButton quit = new QPushButton(Tr("Quit"));
		quit.Font = new QFont("Times", 18, (int) QFont.Weight.Bold);

		QLCDNumber lcd = new QLCDNumber(2);
		lcd.segmentStyle = QLCDNumber.SegmentStyle.Filled;

		QSlider slider = new QSlider(Qt.Orientation.Horizontal);
		slider.SetRange(0, 99);
		slider.Value = 0;

		Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
		Connect(slider, SIGNAL("valueChanged(int)"),
            lcd, SLOT("display(int)"));

		QVBoxLayout layout = new QVBoxLayout();
		layout.AddWidget(quit);
		layout.AddWidget(lcd);
		layout.AddWidget(slider);
		SetLayout(layout);
	}

	public static int Main(String[] args) {
		new QApplication(args);

		MyWidget w = new MyWidget();
		w.Show();
		return QApplication.Exec();
	}
}
