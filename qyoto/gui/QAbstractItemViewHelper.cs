namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	public class QAbstractItemViewHelper : QAbstractItemView {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemViewIndexAt(IntPtr obj, IntPtr point);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void QAbstractItemViewScrollTo(IntPtr obj, IntPtr index, int hint);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemViewVisualRect(IntPtr obj, IntPtr index);
		
		public QAbstractItemViewHelper(Type dummy) : base((Type) dummy) {}
		
		public override QModelIndex IndexAt (QPoint point) {
			GCHandle ret = (GCHandle) QAbstractItemViewIndexAt((IntPtr) GCHandle.Alloc(this), 
										(IntPtr) GCHandle.Alloc(point));
			QModelIndex i = (QModelIndex) ret.Target;
			ret.Free();
			return i;
		}
		
		public override void ScrollTo (QModelIndex index, ScrollHint hint) {
			QAbstractItemViewScrollTo((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(index), (int) hint);
		}
		
		public override QRect VisualRect (QModelIndex index) {
			GCHandle ret = (GCHandle) QAbstractItemViewVisualRect((IntPtr) GCHandle.Alloc(this), 
										(IntPtr) GCHandle.Alloc(index));
			QRect r = (QRect) ret.Target;
			ret.Free();
			return r;
		}
		
		protected override int HorizontalOffset () { return 0; }
		protected override bool IsIndexHidden (QModelIndex index) { return false; }
		protected override QModelIndex MoveCursor (CursorAction cursorAction, int modifiers) {
			return new QModelIndex();
		}
		protected override void SetSelection (QRect rect, int command) {}
		protected override int VerticalOffset () { return 0; }
		protected override QRegion VisualRegionForSelection (QItemSelection selection) { return new QRegion(); }
	}
}
