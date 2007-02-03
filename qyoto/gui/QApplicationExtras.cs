namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;

	public partial class QApplication : QCoreApplication, IDisposable {

		public QApplication(string[] argv) : this((Type) null) {
			Qyoto.Init_qyoto();
			CreateProxy();
			Qt.qApp = this;
      
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			NewQApplication(args.Length, args);
		}

		[SmokeMethod("QApplication", "(int&, char**)", "$?")]
		private void NewQApplication(int argc, string[] argv) {
			ProxyQApplication().NewQApplication(argc, argv);
		}

		public QApplication(string[] argv, bool GUIenabled) : this((Type) null) {
			Qyoto.Init_qyoto();
			CreateProxy();
			Qt.qApp = this;
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			NewQApplication(args.Length, args, GUIenabled);
		}
		
		[SmokeMethod("QApplication", "(int&, char**, bool)", "$?$")]
		private void NewQApplication(int argc, string[] argv, bool GUIenabled) {
			ProxyQApplication().NewQApplication(argc, argv,GUIenabled);
		}
    
		public QApplication(string[] argv, QApplication.TypeOf arg3) : this((Type) null) {
			Qyoto.Init_qyoto();
			CreateProxy();
			Qt.qApp = this;
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			NewQApplication(args.Length, args, arg3);
		}   
		[SmokeMethod("QApplication", "(int&, char**, QApplication::Type)", "$?$")]
		private void NewQApplication(int argc, string[] argv, QApplication.TypeOf arg3) {
			ProxyQApplication().NewQApplication(argc, argv,arg3);
		}
	}
}
