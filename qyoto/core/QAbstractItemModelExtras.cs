namespace Qyoto {

	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	public partial class QAbstractItemModel : QObject {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr AbstractItemModelCreateIndex(IntPtr obj, int row, int column, IntPtr ptr);
		
		private static Dictionary<WeakReference, GCHandle> handleMap = new Dictionary<WeakReference, GCHandle>();
		
		protected QModelIndex CreateIndex(int row, int column, object ptr) {
			IntPtr ret = AbstractItemModelCreateIndex((IntPtr) GCHandle.Alloc(this),
									row, column, (IntPtr) GetIndexHandle(ptr));
			return (QModelIndex) ((GCHandle) ret).Target;
		}
		
		protected QModelIndex CreateIndex(int row, int column) {
			IntPtr ret = AbstractItemModelCreateIndex((IntPtr) GCHandle.Alloc(this),
									row, column, IntPtr.Zero);
			return (QModelIndex) ((GCHandle) ret).Target;
		}
		
		private GCHandle GetIndexHandle(object o) {
			foreach (WeakReference weakRef in handleMap.Keys) {
				if (weakRef.Target == o) {
					// found
					return handleMap[weakRef];
				}
				
				if (!weakRef.IsAlive) {
					handleMap.Remove(weakRef);
				}
			}
			
			GCHandle handle = GCHandle.Alloc(o);
			handleMap.Add(new WeakReference(o), handle);
			return handle;
		}
	}
}
