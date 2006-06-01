using Qt;
using System;

class Test : Qt.Qt {
	class MyWidget : QWidget {
		public MyWidget() : base((QWidget)null) {
			QPushButton quit = new QPushButton("quit", this);
			Connect(quit, SIGNAL("clicked()"), qApp, SLOT("quit()"));
			
			QPushButton test = new QPushButton("test", this);
			Connect(test, SIGNAL("clicked()"), this, SLOT("test()"));
			
			QVBoxLayout layout = new QVBoxLayout();
			layout.AddWidget(quit);
			layout.AddWidget(test);
			SetLayout(layout);
		}
		
		public override QMetaObject MetaObject() {
			return Qyoto.GetMetaObject(this);
		}
		
		[Q_SLOT("test()")]
		public void test() {
			Console.WriteLine("************ IT WORKS **************");
		}

	}

	public static void Main(string[] args) {
		QApplication app = new QApplication(args);
		MyWidget main = new MyWidget();
		main.Show();
		QApplication.Exec();
	}
}
