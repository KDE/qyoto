using System;
using Qt;
using System.Runtime.InteropServices;

class MainForm : QDialog
{
	static void Main(String[] args) {
                Qt.QApplication qa = new Qt.QApplication(args);
                MainForm mf = new MainForm();
                mf.Show();
                qa.SetMainWidget(mf);
                qa.Exec();
        }
        
        public MainForm() : base() {
                this.Show();
                QVBoxLayout qgrid = new QVBoxLayout(this);
                //qgrid.SetAutoAdd(true);
                QTextEdit te = new QTextEdit(this);
                te.Show();
                //SetCaption("Qyoto C# bindings test");
                QPushButton button = new QPushButton("Hello World! Are you getting warmer?", this);
                button.Show();
        }
}
