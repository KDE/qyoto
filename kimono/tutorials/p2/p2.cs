using System;
using Qyoto;
using Kimono;

public class P2 
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p2", "Hello World", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KApplication a = new KApplication();
        QPushButton hello = new QPushButton(KDE.I18n("Hello World !"), null);

        a.SetTopWidget(hello);
        hello.Show();

        KApplication.Exec();
        return 0;
    }
}
