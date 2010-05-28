namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	[SmokeClass("QAbstractItemModel")]
	internal class QItemModel : QAbstractItemModel {
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		static extern int QAbstractItemModelColumnCount(IntPtr obj, IntPtr modelIndex);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		static extern int QAbstractItemModelRowCount(IntPtr obj, IntPtr modelIndex);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemModelParent(IntPtr obj, IntPtr modelIndex);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemModelData(IntPtr obj, IntPtr modelIndex, int role);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr QAbstractItemModelIndex(IntPtr obj, int row, int column, IntPtr modelIndex);
		
		protected QItemModel(Type dummy) : base((Type) null) {}
		
		public override int ColumnCount(QModelIndex parent) {
			return QAbstractItemModelColumnCount((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(parent));
		}
		
		public override int RowCount(QModelIndex parent) {
			return QAbstractItemModelRowCount((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(parent));
		}
		
		public override QModelIndex Parent(QModelIndex child) {
			GCHandle ret = (GCHandle) QAbstractItemModelParent((IntPtr) GCHandle.Alloc(this), 
										(IntPtr) GCHandle.Alloc(child));
			QModelIndex ix = (QModelIndex) ret.Target;
			ret.SynchronizedFree();
			return ix;
		}
		
		public override QVariant Data(QModelIndex index, int role) {
			GCHandle ret = (GCHandle) QAbstractItemModelData((IntPtr) GCHandle.Alloc(this), 
										(IntPtr) GCHandle.Alloc(index), role);
			QVariant v = (QVariant) ret.Target;
			ret.SynchronizedFree();
			return v;
		}
		
		public override QModelIndex Index(int row, int column, QModelIndex parent) {
			GCHandle ret = (GCHandle) QAbstractItemModelIndex((IntPtr) GCHandle.Alloc(this), row, column, 
								(IntPtr) GCHandle.Alloc(parent));
			QModelIndex ix = (QModelIndex) ret.Target;
			ret.SynchronizedFree();
			return ix;
		}
	}
}
