using Qyoto;
using System;

class Test {
	class MyWidget : QWidget {
		public MyWidget() : base((QWidget)null) {
			QPushButton quit = new QPushButton("quit", this);
			Connect(quit, Qt.SIGNAL("clicked()"), Qt.qApp, Qt.SLOT("quit()"));
			
			QPushButton mytest = new QPushButton("test", this);
			Connect(mytest, Qt.SIGNAL("clicked()"), this, Qt.SLOT("test()"));
			
			QVBoxLayout layout = new QVBoxLayout();
			layout.AddWidget(quit);
			layout.AddWidget(mytest);
			SetLayout(layout);
		}
		
		[Q_SLOT("test()")]
		public void test() {
			Console.WriteLine("************ IT WORKS **************");
		}
	}

	public static void Main(string[] args) {
		new QApplication(args);
		MyWidget main = new MyWidget();
		main.Show();
		QApplication.Exec();
	}
}
