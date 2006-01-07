//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QContextMenuEvent : QInputEvent, IDisposable {
 		protected QContextMenuEvent(Type dummy) : base((Type) null) {}
		interface IQContextMenuEventProxy {
		}

		protected void CreateQContextMenuEventProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QContextMenuEvent), this);
			_interceptor = (QContextMenuEvent) realProxy.GetTransparentProxy();
		}
		private QContextMenuEvent ProxyQContextMenuEvent() {
			return (QContextMenuEvent) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QContextMenuEvent() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQContextMenuEventProxy), null);
			_staticInterceptor = (IQContextMenuEventProxy) realProxy.GetTransparentProxy();
		}
		private static IQContextMenuEventProxy StaticQContextMenuEvent() {
			return (IQContextMenuEventProxy) _staticInterceptor;
		}

		enum E_Reason {
			Mouse = 0,
			Keyboard = 1,
			Other = 2,
		}
		public QContextMenuEvent(int reason, QPoint pos, QPoint globalPos) : this((Type) null) {
			CreateQContextMenuEventProxy();
			NewQContextMenuEvent(reason,pos,globalPos);
		}
		private void NewQContextMenuEvent(int reason, QPoint pos, QPoint globalPos) {
			ProxyQContextMenuEvent().NewQContextMenuEvent(reason,pos,globalPos);
		}
		public QContextMenuEvent(int reason, QPoint pos) : this((Type) null) {
			CreateQContextMenuEventProxy();
			NewQContextMenuEvent(reason,pos);
		}
		private void NewQContextMenuEvent(int reason, QPoint pos) {
			ProxyQContextMenuEvent().NewQContextMenuEvent(reason,pos);
		}
		public int X() {
			return ProxyQContextMenuEvent().X();
		}
		public int Y() {
			return ProxyQContextMenuEvent().Y();
		}
		public int GlobalX() {
			return ProxyQContextMenuEvent().GlobalX();
		}
		public int GlobalY() {
			return ProxyQContextMenuEvent().GlobalY();
		}
		public QPoint Pos() {
			return ProxyQContextMenuEvent().Pos();
		}
		public QPoint GlobalPos() {
			return ProxyQContextMenuEvent().GlobalPos();
		}
		public int Reason() {
			return ProxyQContextMenuEvent().Reason();
		}
		~QContextMenuEvent() {
			ProxyQContextMenuEvent().Dispose();
		}
		public new void Dispose() {
			ProxyQContextMenuEvent().Dispose();
		}
	}
}