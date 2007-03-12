namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	public partial class QSqlQueryModel : QAbstractTableModel, IDisposable {

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr QAbstractItemModelParent(IntPtr obj, IntPtr ix);

		public override QModelIndex Parent(QModelIndex index) {
			IntPtr ret = QAbstractItemModelParent((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(index));
			QModelIndex result = (QModelIndex) ((GCHandle) ret).Target;
			((GCHandle) ret).Free();
			return result;
		}
	}
}