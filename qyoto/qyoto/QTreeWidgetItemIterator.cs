//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QTreeWidgetItemIterator")]
	public class QTreeWidgetItemIterator : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
		protected QTreeWidgetItemIterator(Type dummy) {}
		interface IQTreeWidgetItemIteratorProxy {
			QTreeWidgetItemIterator op_incr(QTreeWidgetItemIterator lhs);
			QTreeWidgetItemIterator op_decr(QTreeWidgetItemIterator lhs);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTreeWidgetItemIterator), this);
			_interceptor = (QTreeWidgetItemIterator) realProxy.GetTransparentProxy();
		}
		private QTreeWidgetItemIterator ProxyQTreeWidgetItemIterator() {
			return (QTreeWidgetItemIterator) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTreeWidgetItemIterator() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTreeWidgetItemIteratorProxy), null);
			_staticInterceptor = (IQTreeWidgetItemIteratorProxy) realProxy.GetTransparentProxy();
		}
		private static IQTreeWidgetItemIteratorProxy StaticQTreeWidgetItemIterator() {
			return (IQTreeWidgetItemIteratorProxy) _staticInterceptor;
		}

		public enum IteratorFlag {
			All = 0x00000000,
			Hidden = 0x00000001,
			NotHidden = 0x00000002,
			Selected = 0x00000004,
			Unselected = 0x00000008,
			Selectable = 0x00000010,
			NotSelectable = 0x00000020,
			DragEnabled = 0x00000040,
			DragDisabled = 0x00000080,
			DropEnabled = 0x00000100,
			DropDisabled = 0x00000200,
			HasChildren = 0x00000400,
			NoChildren = 0x00000800,
			Checked = 0x00001000,
			NotChecked = 0x00002000,
			Enabled = 0x00004000,
			Disabled = 0x00008000,
			Editable = 0x00010000,
			NotEditable = 0x00020000,
			UserFlag = 0x01000000,
		}
		public QTreeWidgetItemIterator(QTreeWidgetItemIterator it) : this((Type) null) {
			CreateProxy();
			NewQTreeWidgetItemIterator(it);
		}
		[SmokeMethod("QTreeWidgetItemIterator(const QTreeWidgetItemIterator&)")]
		private void NewQTreeWidgetItemIterator(QTreeWidgetItemIterator it) {
			ProxyQTreeWidgetItemIterator().NewQTreeWidgetItemIterator(it);
		}
		// QTreeWidgetItemIterator* QTreeWidgetItemIterator(QTreeWidget* arg1,IteratorFlags arg2); >>>> NOT CONVERTED
		public QTreeWidgetItemIterator(QTreeWidget widget) : this((Type) null) {
			CreateProxy();
			NewQTreeWidgetItemIterator(widget);
		}
		[SmokeMethod("QTreeWidgetItemIterator(QTreeWidget*)")]
		private void NewQTreeWidgetItemIterator(QTreeWidget widget) {
			ProxyQTreeWidgetItemIterator().NewQTreeWidgetItemIterator(widget);
		}
		// QTreeWidgetItemIterator* QTreeWidgetItemIterator(QTreeWidgetItem* arg1,IteratorFlags arg2); >>>> NOT CONVERTED
		public QTreeWidgetItemIterator(QTreeWidgetItem item) : this((Type) null) {
			CreateProxy();
			NewQTreeWidgetItemIterator(item);
		}
		[SmokeMethod("QTreeWidgetItemIterator(QTreeWidgetItem*)")]
		private void NewQTreeWidgetItemIterator(QTreeWidgetItem item) {
			ProxyQTreeWidgetItemIterator().NewQTreeWidgetItemIterator(item);
		}
		[SmokeMethod("operator++()")]
		public static QTreeWidgetItemIterator operator++(QTreeWidgetItemIterator lhs) {
			return StaticQTreeWidgetItemIterator().op_incr(lhs);
		}
		[SmokeMethod("operator--()")]
		public static QTreeWidgetItemIterator operator--(QTreeWidgetItemIterator lhs) {
			return StaticQTreeWidgetItemIterator().op_decr(lhs);
		}
		~QTreeWidgetItemIterator() {
			DisposeQTreeWidgetItemIterator();
		}
		public void Dispose() {
			DisposeQTreeWidgetItemIterator();
		}
		private void DisposeQTreeWidgetItemIterator() {
			ProxyQTreeWidgetItemIterator().DisposeQTreeWidgetItemIterator();
		}
	}
}
