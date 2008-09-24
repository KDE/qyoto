using System;
using Qyoto;
using Kimono;

public class Editor
{
    public static int Main(String[] args) {
        KAboutData about = new KAboutData("editor", "Text Editor Example", KDE.Ki18n(""), "0.1");
        KCmdLineArgs.Init(args, about);
        KApplication a = new KApplication();

        KParts.MainWindow w = new KParts.MainWindow(null, 0);

        KTextEditor.Editor editor = KTextEditor.Global.Editor("katepart");

//      other possibility
//      KTextEditor.Editor editor = KTextEditor.EditorChooser.Editor();
        editor.SetSimpleMode(true);
        KTextEditor.Document doc = editor.CreateDocument(w);
        KTextEditor.View view = doc.CreateView(w);
        w.SetCentralWidget(view);
        doc.SetText("Here is some text..");
        w.Show();

        return KApplication.Exec();
    }
}
