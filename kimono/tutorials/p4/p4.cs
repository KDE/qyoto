using System;
using Qyoto;
using Kimono;

public class MainWindow : KMainWindow {

    public QLineEdit location;
    public KHTMLPart browser;

    public MainWindow(string name) : base((QWidget) null) {
        ObjectName = name;
        SetCaption("KDE Tutorial - p4");

        QMenu filemenu = new QMenu(KDE.I18n("&File"), this);
        filemenu.AddAction(KDE.I18n("&Quit"), KApplication.kApplication(), SLOT("quit()"));
        
        string about = KDE.I18n("p4 1.0\n\n" +
                 "(C) 1999-2002 Antonio Larrosa Jimenez\n" +
                 "larrosa@kde.org\t\tantlarr@supercable.es\n" +
                 "Malaga (Spain)\n\n" +
                 "Simple KDE Tutorial\n" +
                 "This tutorial comes with ABSOLUTELY NO WARRANTY\n" +
                 "This is free software, and you are welcome to redistribute it\n" +
                 "under certain conditions\n");
        QMenu helpmenu = HelpMenu(about);
        
        KMenuBar menu = MenuBar();
        menu.AddMenu(filemenu);
        menu.AddSeparator();
        menu.AddMenu(helpmenu);
 
        location = new QLineEdit();
        location.Text = "http://localhost";
 
        browser = new KHTMLPart();
        browser.OpenUrl(new KUrl(location.Text));

        QWidget widget = new QWidget(this);

        QVBoxLayout vbox = new QVBoxLayout(widget);
        vbox.AddWidget(location);
        vbox.AddWidget(browser.Widget());

        Connect( location, SIGNAL("returnPressed()"),
                    this, SLOT("ChangeLocation()") );
 
        Connect( browser.BrowserExtension(),
                 SIGNAL("openUrlRequest(KUrl, KParts::OpenUrlArguments)"),
                 this, SLOT("OpenUrlRequest(KUrl, KParts::OpenUrlArguments)") );

        SetCentralWidget(widget);
    }
 
    [Q_SLOT()]
    public void ChangeLocation() {
        browser.OpenUrl(new KUrl(location.Text));
    }
 
    [Q_SLOT("OpenUrlRequest(KUrl, KParts::OpenUrlArguments)")]
    public void OpenUrlRequest(KUrl url, KParts.OpenUrlArguments part) {
        location.Text = url.Url();
        ChangeLocation();
    }
}

public class P4
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p4", "Tutorial - p4", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KApplication a = new KApplication();
        MainWindow window = new MainWindow("Tutorial - p3");
        window.Resize(300, 200);
        window.Show();

        return KApplication.Exec();
    }
}
