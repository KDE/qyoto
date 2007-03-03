namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;

	public partial class QAbstractItemModel : QObject {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr AbstractItemModelCreateIndex(IntPtr obj, int row, int column, IntPtr ptr);
		
		protected QModelIndex CreateIndex(int row, int column, object ptr) {
			IntPtr ret = AbstractItemModelCreateIndex((IntPtr) GCHandle.Alloc(this),
									row, column, (IntPtr) GCHandle.Alloc(ptr));
			return (QModelIndex) ((GCHandle) ret).Target;
		}
		
		protected QModelIndex CreateIndex(int row, int column) {
			IntPtr ret = AbstractItemModelCreateIndex((IntPtr) GCHandle.Alloc(this),
									row, column, IntPtr.Zero);
			return (QModelIndex) ((GCHandle) ret).Target;
		}
	}
}