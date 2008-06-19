using System;
using System.Collections.Generic;
using Qyoto;
using Kimono;

public class Browser : KXmlGuiWindow {

    public QLineEdit location;
    public KHTMLPart browser;
    public List<string> history = new List<string>();
    public KAction addBookmarkAction;
    public KAction backAction;
    public KAction quitAction;

    public Browser(string name) : base((QWidget) null) {
        ObjectName = name;
        SetCaption("KDE Tutorial - p7");

        QMenu filemenu = new QMenu(KDE.I18n("&File"), this);

        KAction setDefaultPageAction = new KAction(this);
        setDefaultPageAction.Text = KDE.I18n("&Set default page");
        ActionCollection().AddAction("set_default_page", setDefaultPageAction);
        Connect(	setDefaultPageAction, SIGNAL("triggered(bool)"), 
                    this, SLOT("FileSetDefaultPage()") );

        addBookmarkAction = KStandardAction.Global.AddBookmark(this, SLOT("BookLocation()"), ActionCollection());
        backAction = KStandardAction.Global.Back(this, SLOT("GotoPreviousPage()"), ActionCollection());
        backAction.Enabled = false;
        quitAction = KStandardAction.Global.Quit(KApplication.kApplication(), SLOT("quit()"), ActionCollection());
        
        string about = KDE.I18n("p7 1.0\n\n" +
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

        ToolBar().AddAction(quitAction);
        ToolBar().AddAction(addBookmarkAction);
        ToolBar().AddAction(backAction);
        StandardToolBarMenuEnabled = true;
 
        location = new QLineEdit();
        location.Text = "http://localhost";

        KConfig config = KApplication.kApplication().SessionConfig();
        location.Text = config.Group("Settings").ReadEntry("defaultPage", "http://localhost");

        Connect( location , SIGNAL("returnPressed()"),
                    this, SLOT("ChangeLocation()") );

        QSplitter split = new QSplitter();
        split.OpaqueResize = true;

        QWidget widget = new QWidget(this);

        QVBoxLayout vbox = new QVBoxLayout(widget);
        vbox.AddWidget(location);
        vbox.AddWidget(split);

        browser = new KHTMLPart(split);
        browser.OpenUrl(new KUrl(location.Text));

        Connect( browser.BrowserExtension(),
                 SIGNAL("openUrlRequest(KUrl, KParts::OpenUrlArguments)"),
                 this, SLOT("OpenUrlRequest(KUrl, KParts::OpenUrlArguments)") );

        SetCentralWidget(widget);
        SetupGUI();
    }

    [Q_SLOT()]
    public void ChangeLocation() {
        history.Add(browser.Url.Url());
        backAction.Enabled = true;
        browser.OpenUrl(new KUrl(location.Text));
    }
 
    [Q_SLOT()]
    public void SetUrl(string url) {
        location.Text = url;
        ChangeLocation();
    }
 
    [Q_SLOT("OpenUrlRequest(KUrl, KParts::OpenUrlArguments)")]
    public void OpenUrlRequest(KUrl url, KParts.OpenUrlArguments part) {
        SetUrl(url.Url());
    }

    [Q_SLOT()]
    public void GotoPreviousPage() {
        location.Text = history[0];
        history.RemoveAt(0);
        if (history.Count == 0) {
            backAction.Enabled = false;
        }
        browser.OpenUrl(new KUrl(location.Text));
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
 
    [Q_SLOT()]
    public void FileSetDefaultPage() {
        KConfig config = KApplication.kApplication().SessionConfig();
        config.Group("Settings").WriteEntry("defaultPage", browser.Url.Url());
    }
}

public class P7
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p7", "Tutorial - p7", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KUniqueApplication a = new KUniqueApplication();

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.Error.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                                     "To start it, run:\n" +
                                     "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        if (!QDBusConnection.SessionBus().RegisterService("org.kde.Browser")) {
	        Console.Error.WriteLine("{0}",  QDBusConnection.SessionBus().LastError().Message());
            return 1;
        }

        Browser window = new Browser("Tutorial - p7");
        window.Resize(300, 200);
        window.Show();

        QDBusConnection.SessionBus().RegisterObject("/", window, (uint) QDBusConnection.RegisterOption.ExportAllSlots);

        return KApplication.Exec();
    }
}
