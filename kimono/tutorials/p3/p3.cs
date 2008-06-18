using System;
using Qyoto;
using Kimono;

public class MainWindow : KMainWindow {
 
    public MainWindow(string name) : base((QWidget) null) {
        ObjectName = name;
        SetCaption("KDE Tutorial - p3");

        QMenu filemenu = new QMenu(KDE.I18n("&File"), this);
        filemenu.AddAction(KDE.I18n("&Open"), this, SLOT("FileOpen()"));
        filemenu.AddAction(KDE.I18n("&Save"), this, SLOT("FileSave()"));
        filemenu.AddAction(KDE.I18n("&Quit"), KApplication.kApplication(), SLOT("quit()"));
        
        string about = KDE.I18n("p3 1.0\n\n" +
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
 
        QTextEdit hello = new QTextEdit(
        KDE.I18n("<H2>Hello World !</H2><BR>This is a simple" +
            " window with <I><font size=5><B>R<font color=red" +
            " size=5>ich </font><font color=blue size=5>Text" +
            "</font></B></I> capabilities<BR>Try to resize" +
            " this window, all this is automatic !"), this);
        SetCentralWidget(hello);
    }
 
    [Q_SLOT()]
    public void FileOpen() {
        KUrl filename = KFileDialog.GetOpenUrl(new KUrl(), "*", this);
        string msg = KDE.I18n("Now this app should open the url " + filename.Url());
        KMessageBox.Information(null, msg, KDE.I18n( "Information"), 
                                    "fileOpenInformationDialog" );
    }
 
    [Q_SLOT()]
    public void FileSave() {
        string filename = KFileDialog.GetSaveUrl(new KUrl(), "*", this);
    }
}

public class P3 
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p3", "Tutorial - p3", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KApplication a = new KApplication();
        MainWindow window = new MainWindow("Tutorial - p3");
        window.Resize(400, 300);
        window.Show();

        return KApplication.Exec();
    }
}
