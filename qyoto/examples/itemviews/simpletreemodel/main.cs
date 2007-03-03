using System;
using System.IO;
using Qyoto;

class MainClass {
	public static int Main(string[] args) {
// 		Q_INIT_RESOURCE("simpletreemodel");
		
		new QApplication(args);
		
		StreamReader file = new StreamReader("default.txt");
// 		Debug.SetDebug(QtDebugChannel.QTDB_TRANSPARENT_PROXY | QtDebugChannel.QTDB_VIRTUAL);
		TreeModel model = new TreeModel(file.ReadToEnd());
		file.Close();
		
		QTreeView view = new QTreeView();
		view.SetModel(model);
		view.WindowTitle = "Simple Tree Model";
		view.Show();
		return QApplication.Exec();
	}
}
