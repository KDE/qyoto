using Qyoto;

class LCDRange : QWidget {
	private QSlider slider;

	public LCDRange() : this((QWidget) null) {}

	public LCDRange(QWidget parent) : base(parent) {
		QLCDNumber lcd = new QLCDNumber(2);
		lcd.SetSegmentStyle(QLCDNumber.SegmentStyle.Filled);
		
		slider = new QSlider(Qt.Orientation.Horizontal);
		slider.SetRange(0,99);
		slider.SetValue(0);
		
		Connect(slider, SIGNAL("valueChanged(int)"),
				lcd, SLOT("display(int)"));
		Connect(slider, SIGNAL("valueChanged(int)"),
				this, SIGNAL("valueChanged(int)"));
				
		QVBoxLayout layout = new QVBoxLayout();
		layout.AddWidget(lcd);
		layout.AddWidget(slider);
		
		SetLayout(layout);
		
	}
	public int Value() {
		return slider.Value();
	}
	
	[Q_SLOT("setValue(int)")]
	public void SetValue(int value) {
		slider.SetValue(value);
	}
	
	protected new ILCDRangeSignals Emit() {
		return (ILCDRangeSignals) Q_EMIT;
	}
}

public interface ILCDRangeSignals : IQWidgetSignals {
	[Q_SIGNAL("valueChanged(int)")]
	void ValueChanged(int newValue);
}

class MyWidget : QWidget {
	public MyWidget(QWidget parent) : base(parent) {
		QPushButton quit = new QPushButton("Quit");
		Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
		
		QGridLayout grid = new QGridLayout();
		LCDRange previousRange = null;
		
        for (int row = 0; row < 3; ++row) {
            for (int column = 0; column < 3; ++column) {
                LCDRange lcdRange = new LCDRange();
                grid.AddWidget(lcdRange, row, column);
                if (previousRange != null)
                    Connect(lcdRange, SIGNAL("valueChanged(int)"),
                            previousRange, SLOT("setValue(int)"));
                previousRange = lcdRange;
            }
        }
        
		QVBoxLayout layout = new QVBoxLayout();
        layout.AddWidget(quit);
        layout.AddLayout(grid);
        SetLayout(layout);
	}
	
	public static void Main(string[] args) {
		new QApplication(args);
		MyWidget main = new MyWidget((QWidget)null);
		main.Show();
		QApplication.Exec();
	}
	protected new IMyWidgetSignals Emit() {
		return (IMyWidgetSignals) Q_EMIT;
	}
}

public interface IMyWidgetSignals : IQWidgetSignals {
}
