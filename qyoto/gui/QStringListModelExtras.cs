namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	public partial class QStringListModel : QAbstractListModel, IDisposable {

		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr QAbstractItemModelParent(IntPtr obj, IntPtr ix);

		public override QModelIndex Parent(QModelIndex index) {
			IntPtr ret = QAbstractItemModelParent((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(index));
			QModelIndex result = (QModelIndex) ((GCHandle) ret).Target;
			((GCHandle) ret).SynchronizedFree();
			return result;
		}

		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		public static extern int QAbstractItemModelColumnCount(IntPtr obj, IntPtr ix);

		public override int ColumnCount(QModelIndex index) {
			return QAbstractItemModelColumnCount((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(index));
		}
	}
}