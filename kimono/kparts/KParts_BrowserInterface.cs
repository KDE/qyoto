//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	namespace KParts {

	using System;
	using Qyoto;

	/// <remarks>
	///  The purpose of this interface is to allow a direct communication between
	///  a KPart and the hosting browser shell (for example Konqueror) . A
	///  shell implementing this interface can propagate it to embedded kpart
	///  components by using the setBrowserInterface call of the part's
	///  KParts.BrowserExtension object.
	///  This interface looks not very rich, but the main functionality is
	///  implemented using the callMethod method for part.Shell
	///  communication and using Qt properties for allowing a part to
	///  to explicitly query information from the shell.
	///  Konqueror in particular, as 'reference' implementation, provides
	///  the following functionality through this interface:
	///  Qt properties:
	///    Q_PROPERTY( uint historyLength READ historyLength );
	///  Callable methods:
	///        void goHistory( int );
	///  </remarks>		<short>    The purpose of this interface is to allow a direct communication between  a KPart and the hosting browser shell (for example Konqueror) .</short>

	[SmokeClass("KParts::BrowserInterface")]
	public class BrowserInterface : QObject, IDisposable {
 		protected BrowserInterface(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(BrowserInterface), this);
		}
		public BrowserInterface(QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("BrowserInterface#", "BrowserInterface(QObject*)", typeof(void), typeof(QObject), parent);
		}
		/// <remarks>
		///  Perform a dynamic invocation of a method in the BrowserInterface
		///  implementation. Methods are to be implemented as simple Qt slots.
		///      </remarks>		<short>    Perform a dynamic invocation of a method in the BrowserInterface  implementation.</short>
		public void CallMethod(string name, QVariant argument) {
			interceptor.Invoke("callMethod$#", "callMethod(const char*, const QVariant&)", typeof(void), typeof(string), name, typeof(QVariant), argument);
		}
		~BrowserInterface() {
			interceptor.Invoke("~BrowserInterface", "~BrowserInterface()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~BrowserInterface", "~BrowserInterface()", typeof(void));
		}
		protected new IBrowserInterfaceSignals Emit {
			get { return (IBrowserInterfaceSignals) Q_EMIT; }
		}
	}

	public interface IBrowserInterfaceSignals : IQObjectSignals {
	}
	}
}
