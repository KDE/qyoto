//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QHelpEvent")]
	public class QHelpEvent : QEvent, IDisposable {
 		protected QHelpEvent(Type dummy) : base((Type) null) {}
		interface IQHelpEventProxy {
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHelpEvent), this);
			_interceptor = (QHelpEvent) realProxy.GetTransparentProxy();
		}
		private QHelpEvent ProxyQHelpEvent() {
			return (QHelpEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHelpEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHelpEventProxy), null);
			_staticInterceptor = (IQHelpEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQHelpEventProxy StaticQHelpEvent() {
			return (IQHelpEventProxy) _staticInterceptor;
		}

		public QHelpEvent(QEvent.TypeOf type, QPoint pos, QPoint globalPos) : this((Type) null) {
			CreateProxy();
			NewQHelpEvent(type,pos,globalPos);
		}
		[SmokeMethod("QHelpEvent", "(QEvent::Type, const QPoint&, const QPoint&)", "$##")]
		private void NewQHelpEvent(QEvent.TypeOf type, QPoint pos, QPoint globalPos) {
			ProxyQHelpEvent().NewQHelpEvent(type,pos,globalPos);
		}
		[SmokeMethod("x", "() const", "")]
		public int X() {
			return ProxyQHelpEvent().X();
		}
		[SmokeMethod("y", "() const", "")]
		public int Y() {
			return ProxyQHelpEvent().Y();
		}
		[SmokeMethod("globalX", "() const", "")]
		public int GlobalX() {
			return ProxyQHelpEvent().GlobalX();
		}
		[SmokeMethod("globalY", "() const", "")]
		public int GlobalY() {
			return ProxyQHelpEvent().GlobalY();
		}
		[SmokeMethod("pos", "() const", "")]
		public QPoint Pos() {
			return ProxyQHelpEvent().Pos();
		}
		[SmokeMethod("globalPos", "() const", "")]
		public QPoint GlobalPos() {
			return ProxyQHelpEvent().GlobalPos();
		}
		~QHelpEvent() {
			DisposeQHelpEvent();
		}
		public new void Dispose() {
			DisposeQHelpEvent();
		}
		[SmokeMethod("~QHelpEvent", "()", "")]
		private void DisposeQHelpEvent() {
			ProxyQHelpEvent().DisposeQHelpEvent();
		}
	}
}
