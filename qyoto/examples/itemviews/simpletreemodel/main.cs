using System;
using System.IO;
using Qyoto;

class MainClass : Qt {
	public static int Main(string[] args) {
 		Q_INIT_RESOURCE("simpletreemodel");
		
		new QApplication(args);
		
		QFile file = new QFile(":/default.txt");
		file.Open((int) QIODevice.OpenModeFlag.ReadOnly);
		TreeModel model = new TreeModel(file.ReadAll().Data());
		file.Close();
		
		QTreeView view = new QTreeView();
		view.SetModel(model);
		view.WindowTitle = "Simple Tree Model";
		view.Show();
		return QApplication.Exec();
	}
}
