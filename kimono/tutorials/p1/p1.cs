using System;
using Qyoto;

public class P1 : Qt
{
    public static int Main(String[] args) {
        QApplication a = new QApplication(args);
        QMainWindow w = new QMainWindow();
        QPushButton hello = new QPushButton("Hello world!", null);
        hello.Resize(100, 30);
        QObject.Connect(hello, SIGNAL("clicked()"), a, SLOT("quit()"));

        hello.Show();
        return QApplication.Exec();
    }
}
