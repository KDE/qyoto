namespace Qyoto {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;
	using System.Text;

	class EventReceiver : QObject {
		public EventReceiver(QObject parent) : base(parent) {}
		
		public override bool Event(QEvent e) {
			if (e != null && e.type() == QEvent.TypeOf.User) {
				ThreadEvent my = e as ThreadEvent;
				if (e != null) {
					my.dele();
					my.handle.Free();  // free the handle so the event can be collected
					return true;
				}
			}
			return false;
		}
	}

	class ThreadEvent : QEvent {
		public NoArgDelegate dele;
		public GCHandle handle;
		
		public ThreadEvent(NoArgDelegate d) : base(QEvent.TypeOf.User) {
			dele = d;
		}
	}

	public partial class QCoreApplication : QObject, IDisposable {
		private EventReceiver receiver;
		protected void SetupEventReceiver() { receiver = new EventReceiver(this); }

		public static void Invoke(NoArgDelegate dele) {
			ThreadEvent e = new ThreadEvent(dele);
			e.handle = GCHandle.Alloc(e);  // we don't want the GC to collect the event too early
			PostEvent(qApp.receiver, e);
		}

		public QCoreApplication(string[] argv) : this((Type) null) {
			CreateProxy();
			
			string[] args = new string[argv.Length + 1];
			args[0] = System.Reflection.Assembly.GetExecutingAssembly().Location;
			argv.CopyTo(args, 1);

			interceptor.Invoke(	"QCoreApplication$?", 
								"QCoreApplication(int&, char**)", 
								typeof(void), typeof(int), args.Length, typeof(string[]), args );
			SetupEventReceiver();
		}
	}
}
