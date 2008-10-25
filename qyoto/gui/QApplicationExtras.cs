namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;

	public partial class QApplication : QCoreApplication, IDisposable {

		public QApplication(string[] argv) : this((Type) null) {
			CreateProxy();
			Qt.qApp = this;
      
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			interceptor.Invoke(	"QApplication$?", 
								"QApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args );
			SetupEventReceiver();
		}

		public QApplication(string[] argv, bool GUIenabled) : this((Type) null) {
			CreateProxy();
			Qt.qApp = this;
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			interceptor.Invoke(	"QApplication$?", 
								"QApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args, typeof(bool), GUIenabled );
			SetupEventReceiver();
		}
    
		public QApplication(string[] argv, QApplication.TypeOf arg3) : this((Type) null) {
			CreateProxy();
			Qt.qApp = this;
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			interceptor.Invoke(	"QApplication$?", 
								"QApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args, typeof(QApplication.TypeOf), arg3 );
			SetupEventReceiver();
		}   
	}
}
