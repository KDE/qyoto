//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	public interface IQMimeSource {
			string Format(int n);
			bool Provides(string arg1);
			QByteArray EncodedData(string arg1);
	}

	[SmokeClass("QMimeSource")]
	public abstract class QMimeSource : MarshalByRefObject, IQMimeSource {
		protected Object _interceptor = null;
		private IntPtr _smokeObject;
		protected QMimeSource(Type dummy) {}
		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QMimeSource), this);
			_interceptor = (QMimeSource) realProxy.GetTransparentProxy();
		}
		private QMimeSource ProxyQMimeSource() {
			return (QMimeSource) _interceptor;
		}
		[SmokeMethod("format", "(int) const", "$")]
		public abstract string Format(int n);
		[SmokeMethod("provides", "(const char*) const", "$")]
		public virtual bool Provides(string arg1) {
			return ProxyQMimeSource().Provides(arg1);
		}
		[SmokeMethod("encodedData", "(const char*) const", "$")]
		public abstract QByteArray EncodedData(string arg1);
		public QMimeSource() : this((Type) null) {
			CreateProxy();
			NewQMimeSource();
		}
		[SmokeMethod("QMimeSource", "()", "")]
		private void NewQMimeSource() {
			ProxyQMimeSource().NewQMimeSource();
		}
	}
}
