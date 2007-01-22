namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;

	public partial class QCoreApplication : QObject, IDisposable {
		public QCoreApplication(string[] argv) : this((Type) null) {
			Qyoto.Init_qyoto();
			CreateProxy();
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			NewQCoreApplication(args.Length, args);
		}
		[SmokeMethod("QCoreApplication(int&, char**)")]
		private void NewQCoreApplication(int argc, string[] argv) {
			ProxyQCoreApplication().NewQCoreApplication(argc, argv);
		}
	}
}
