using System;
using Qt;
using System.Runtime.InteropServices;

class MainForm : QDialog
{
        [DllImport("libqyoto", CharSet=CharSet.Ansi)]
        static extern void Init_qyoto();

	    static void Main(String[] args) {
                Init_qyoto();
                Qt.QApplication qa = new Qt.QApplication(args);
                MainForm mf = new MainForm();
                mf.Show();
                qa.SetMainWidget(mf);
                qa.Exec();
        }
        
        public MainForm()
        {
                this.Show();
                QVBoxLayout qgrid = new QVBoxLayout(this);
                qgrid.SetAutoAdd(true);
                QTextEdit te = new QTextEdit(this);
                te.Show();
				SetCaption("My Caption");
                QPushButton button = new QPushButton(this);
                button.SetCaption("Hello World!");
                button.Show();
        }
}
