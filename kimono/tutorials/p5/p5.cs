using System;
using Qyoto;
using Kimono;

public class MainWindow : KMainWindow {

    public QLineEdit location;
    public KHTMLPart browser;

    public MainWindow(string name) : base((QWidget) null) {
        ObjectName = name;
        SetCaption("KDE Tutorial - p5");

        QMenu filemenu = new QMenu(KDE.I18n("&File"), this);
        filemenu.AddAction(KDE.I18n("&Quit"), KApplication.kApplication(), SLOT("quit()"));
        
        string about = KDE.I18n("p5 1.0\n\n" +
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

        Connect( location , SIGNAL("returnPressed()"),
                    this, SLOT("changeLocation()") );

        QSplitter split = new QSplitter();
        split.OpaqueResize = true;

        QWidget widget = new QWidget(this);

        QVBoxLayout vbox = new QVBoxLayout(widget);
        vbox.AddWidget(location);
        vbox.AddWidget(split);

        QPushButton bookmark = new QPushButton(KDE.I18n("Add to Bookmarks"), split);
 
        Connect(bookmark, SIGNAL("clicked()"), this, SLOT("BookLocation()"));

        browser = new KHTMLPart(split);
        browser.OpenUrl(new KUrl(location.Text));

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

    [Q_SLOT()]
    public void BookLocation() {
        QDBusInterface iface = new QDBusInterface("org.kde.BookMarkList", "/", "", QDBusConnection.SessionBus());
        if (iface.IsValid()) {
            iface.Call("add", location.Text);
        } else {
            Console.Error.WriteLine("Error with DBUS\n");
        }
    }
}

public class P5
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p5", "Tutorial - p5", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KApplication a = new KApplication();

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.Error.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                                     "To start it, run:\n" +
                                     "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        MainWindow window = new MainWindow("Tutorial - p5");
        window.Resize(300, 200);
        window.Show();

        return KApplication.Exec();
    }
}
