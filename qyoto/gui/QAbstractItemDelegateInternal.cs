namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	internal class QAbstractItemDelegateInternal : QAbstractItemDelegate {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void QAbstractItemDelegatePaint(IntPtr obj, IntPtr painter, IntPtr option, IntPtr index);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemDelegateSizeHint(IntPtr obj, IntPtr option, IntPtr index);
		
		protected QAbstractItemDelegateInternal(Type dummy) : base((Type) null) {}
		
		public override void Paint (QPainter painter, QStyleOptionViewItem option, QModelIndex index) {
			QAbstractItemDelegatePaint((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(painter), 
							(IntPtr) GCHandle.Alloc(option), (IntPtr) GCHandle.Alloc(index));
		}
		
		public override QSize SizeHint (QStyleOptionViewItem option, QModelIndex index) {
			GCHandle ret = (GCHandle) QAbstractItemDelegateSizeHint((IntPtr) GCHandle.Alloc(this), 
										(IntPtr) GCHandle.Alloc(option), 
										(IntPtr) GCHandle.Alloc(index));
			QSize s = (QSize) ret.Target;
			ret.Free();
			return s;
		}
	}
}
