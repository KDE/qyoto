//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QHoverEvent : QEvent, IDisposable {
 		protected QHoverEvent(Type dummy) : base((Type) null) {}
		interface IQHoverEventProxy {
		}

		protected void CreateQHoverEventProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QHoverEvent), this);
			_interceptor = (QHoverEvent) realProxy.GetTransparentProxy();
		}
		private QHoverEvent ProxyQHoverEvent() {
			return (QHoverEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QHoverEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQHoverEventProxy), null);
			_staticInterceptor = (IQHoverEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQHoverEventProxy StaticQHoverEvent() {
			return (IQHoverEventProxy) _staticInterceptor;
		}

		public QHoverEvent(int type, QPoint pos, QPoint oldPos) : this((Type) null) {
			CreateQHoverEventProxy();
			NewQHoverEvent(type,pos,oldPos);
		}
		private void NewQHoverEvent(int type, QPoint pos, QPoint oldPos) {
			ProxyQHoverEvent().NewQHoverEvent(type,pos,oldPos);
		}
		public QPoint Pos() {
			return ProxyQHoverEvent().Pos();
		}
		public QPoint OldPos() {
			return ProxyQHoverEvent().OldPos();
		}
		~QHoverEvent() {
			ProxyQHoverEvent().Dispose();
		}
		public new void Dispose() {
			ProxyQHoverEvent().Dispose();
		}
	}
}