namespace Qyoto {

	using System;
	using System.Reflection;
	using System.Collections;
	using System.Runtime.InteropServices;
	using System.Text;

	public delegate void EventFunc();

	class EventReceiver : QObject {
		public EventReceiver(QObject parent) : base(parent) {}
		
		public override bool Event(QEvent e) {
			if (e != null && e.type() == QEvent.TypeOf.User) {
				ThreadEvent my = e as ThreadEvent;
				if (e != null) {
					my.dele();
					my.handle.SynchronizedFree();  // free the handle so the event can be collected
					return true;
				}
			}
			return false;
		}
	}

	class ThreadEvent : QEvent {
		public EventFunc dele;
		public GCHandle handle;
		
		public ThreadEvent(EventFunc d) : base(QEvent.TypeOf.User) {
			dele = d;
		}
	}

	public partial class QCoreApplication : QObject, IDisposable {
		private EventReceiver receiver;
		protected void SetupEventReceiver() { receiver = new EventReceiver(this); }

		public static void Invoke(EventFunc dele) {
			ThreadEvent e = new ThreadEvent(dele);
			e.handle = GCHandle.Alloc(e);  // we don't want the GC to collect the event too early
			PostEvent(qApp.receiver, e);
		}

		string[] GenerateArgs(string[] argv)
		{
			string[] args = new string[argv.Length + 1];
			Assembly a = System.Reflection.Assembly.GetEntryAssembly();

			if(a == null)
				a = System.Reflection.Assembly.GetExecutingAssembly();

			object[] attrs = a.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			if (attrs.Length > 0) {
				args[0] = ((AssemblyTitleAttribute) attrs[0]).Title;
			} else {
				QFileInfo info = new QFileInfo(a.Location);
				args[0] = info.BaseName();
			}
			argv.CopyTo(args, 1);

			return args;
		}

		public QCoreApplication(string[] argv) : this((Type) null) {
			CreateProxy();
			
			string[] args = GenerateArgs(argv);
			
			interceptor.Invoke(	"QCoreApplication$?", 
								"QCoreApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args );
			SetupEventReceiver();
		}
	}
}
