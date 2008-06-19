using System;
using System.Collections.Generic;
using Qyoto;
using Kimono;

public class BookMarkList : QTableWidget {
    public BookMarkList(string name) : base(0, 1) {
        ObjectName = "Bookmarks";
        List<string> headers = new List<string>();
        headers.Add(KDE.I18n("My Bookmarks"));
        SetHorizontalHeaderLabels(headers);
        HorizontalHeader().ResizeSection(0, 250);
    }
 
    [Q_SLOT()]
    public void Add(string s) {
        RowCount = RowCount + 1;
        SetItem(RowCount - 1, 0, new QTableWidgetItem(s));
    }
}

public class P6
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("p6", "Tutorial - p6", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KUniqueApplication a = new KUniqueApplication();

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.Error.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                                     "To start it, run:\n" +
                                     "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        if (!QDBusConnection.SessionBus().RegisterService("org.kde.BookMarkList")) {
	        Console.Error.WriteLine("{0}", QDBusConnection.SessionBus().LastError().Message());
	        return 1;
        }

        BookMarkList mylist = new BookMarkList("Tutorial - p6");
        mylist.Resize(300, 200);
        a.SetTopWidget(mylist);
        mylist.Show();

        QDBusConnection.SessionBus().RegisterObject("/", mylist, (uint) QDBusConnection.RegisterOption.ExportAllSlots);

        return KApplication.Exec();
    }
}
