using Qyoto;
using System;

class LCDRange : QWidget {
	private QSlider slider;

	public LCDRange() : this((QWidget) null) {}
	public LCDRange(QWidget parent) : base(parent) {
		QLCDNumber lcd = new QLCDNumber(2);
		lcd.segmentStyle = QLCDNumber.SegmentStyle.Filled;
		
		slider = new QSlider(Qt.Orientation.Horizontal);
		slider.SetRange(0,99);
		slider.Value = 0;
		
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
		return slider.Value;
	}
	
	[Q_SLOT("setValue(int)")]
	public void SetValue(int value) {
		slider.Value = value;
	}
	
	[Q_SLOT("setRange(int,int)")]
	public void SetRange(int minValue, int maxValue) {
        if (minValue < 0 || maxValue > 99 || minValue > maxValue) {
            Console.WriteLine("LCDRange::setRange({0}, {1})\n" +
                     "\tRange must be 0..99\n" +
                     "\tand minValue must not be greater than maxValue",
                     minValue, maxValue);
            return;
        }
        slider.SetRange(minValue, maxValue);
	}
	
	protected new ILCDRangeSignals Emit {
		get {
			return (ILCDRangeSignals) Q_EMIT;
		}
	}
}

public interface ILCDRangeSignals : IQWidgetSignals {
	[Q_SIGNAL("valueChanged(int)")]
	void ValueChanged(int newValue);
}

class CannonField : QWidget {
	private int currentAngle;
	
	public int Angle {
		get { return currentAngle; }
	}
	
	[Q_SLOT("setAngle(int)")]
	public void SetAngle(int angle) {
        if (angle < 5)
            angle = 5;
        if (angle > 70)
            angle = 70;
        if (currentAngle == angle)
            return;
        currentAngle = angle;
        Update();
        Emit.AngleChanged(currentAngle);
	}
	
	public CannonField() : this ((QWidget) null) { }
	public CannonField(QWidget parent) : base(parent) {
		currentAngle = 45;
        Palette = new QPalette(new QColor(250, 250, 200));
        AutoFillBackground = true;
	}
	
	protected override void PaintEvent(QPaintEvent ev) {
        using (QPainter painter = new QPainter(this)) {
        	painter.SetPen(Qt.PenStyle.NoPen);
        	painter.SetBrush(new QBrush(new QColor(0,0,255)));
        	painter.Translate(0, Rect.Height());
			painter.DrawPie(new QRect(-35, -35, 70, 70), 0, 90 * 16);
			painter.Rotate(-currentAngle);
			painter.DrawRect(30, -5, 20, 10);
        	painter.End();
		}
	}
	
	protected new ICannonFieldSignals Emit {
		get {
			return (ICannonFieldSignals) Q_EMIT;
		}
	}
}

public interface ICannonFieldSignals : IQWidgetSignals {
	[Q_SIGNAL("angleChanged(int)")]
	void AngleChanged(int angle);
}


class MyWidget : QWidget {
	public MyWidget() : this ((QWidget) null) { }
	public MyWidget(QWidget parent) : base(parent) {
        QPushButton quit = new QPushButton("Quit");

        Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
	
		LCDRange angle = new LCDRange();
		angle.SetRange(5,70);
		CannonField field = new CannonField();
		Connect(angle, SIGNAL("valueChanged(int)"), field, SLOT("setAngle(int)"));
		Connect(field, SIGNAL("angleChanged(int)"), angle, SLOT("setValue(int)"));
		
        QGridLayout gridLayout = new QGridLayout();
        gridLayout.AddWidget(quit, 0, 0);
        gridLayout.AddWidget(angle, 1, 0);
        gridLayout.AddWidget(field, 1, 1, 2, 1);
        gridLayout.SetColumnStretch(1, 10);
        SetLayout(gridLayout);

        angle.SetValue(60);
        angle.SetFocus();
	}
	
	public static void Main(string[] args) {
		new QApplication(args);
		MyWidget main = new MyWidget((QWidget)null);
		main.SetGeometry(100, 100, 500, 355);
		main.Show();
		QApplication.Exec();
	}
	
	protected new IMyWidgetSignals Emit {
		get {
			return (IMyWidgetSignals) Q_EMIT;
		}
	}
}

public interface IMyWidgetSignals : IQWidgetSignals {
}
