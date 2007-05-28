using System;
using Qyoto;

public class T1 
{
    public static int Main(String[] args) {
        QApplication app = new QApplication(args);
        QPushButton hello = new QPushButton("Hello world!");
        hello.Resize(100, 30);
        hello.Show();
        return QApplication.Exec();
    }
}
