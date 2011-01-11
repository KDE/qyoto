namespace Qyoto {
	using System;
	
	[SmokeClass("QLayout")]
	internal class QLayoutInternal : QLayout {
		protected QLayoutInternal(Type dummy) : base((Type) null) {}
		
		public override void AddItem (IQLayoutItem arg1) {
			interceptor.Invoke("addItem#", "addItem(QLayoutItem*)", typeof(void), typeof(IQLayoutItem), arg1);
		}
		
		public override int Count () {
			return (int) interceptor.Invoke("count", "count()", typeof(int));
		}
		
		public override IQLayoutItem ItemAt (int index) {
			return (IQLayoutItem) interceptor.Invoke("itemAt$", "itemAt(int)", typeof(IQLayoutItem), typeof(int), index);
		}
		
		public override QSize SizeHint () {
			return (QSize) interceptor.Invoke("sizeHint", "sizeHint()", typeof(QSize));
		}
		
		public override IQLayoutItem TakeAt (int index) {
			return (IQLayoutItem) interceptor.Invoke("takeAt$", "takeAt(int)", typeof(IQLayoutItem), typeof(int), index);
		}
	}
}
