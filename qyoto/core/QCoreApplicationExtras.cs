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

			interceptor.Invoke(	"QCoreApplication$?", 
								"QCoreApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args );
		}
	}
}
