namespace Qyoto {

	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	public abstract partial class QAbstractItemModel : QObject {
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr AbstractItemModelCreateIndex(IntPtr obj, int row, int column, IntPtr ptr);
		
		private struct HandleRef {
			public int refCount;
			public GCHandle handle;
		}

		private static Dictionary<object, HandleRef> handleMap = new Dictionary<object, HandleRef>();
		
		protected QModelIndex CreateIndex(int row, int column, object ptr) {
			IntPtr ret = AbstractItemModelCreateIndex((IntPtr) GCHandle.Alloc(this),
									row, column, (IntPtr) GetIndexHandle(ptr));
			QModelIndex result = (QModelIndex) ((GCHandle) ret).Target;
			((GCHandle) ret).Free();
			return result;
		}
		
		private GCHandle GetIndexHandle(object o) {
			HandleRef reference;
			if (!handleMap.TryGetValue(o, out reference)) {
				reference = new HandleRef();
				reference.refCount = 0;
				reference.handle = GCHandle.Alloc(o);
				handleMap.Add(o, reference);
			}

			reference.refCount += 1;
			return reference.handle;
		}
		
		static public void DerefIndexHandle(object o) {
			HandleRef reference;
			if( o == null)
				return;
			if (handleMap.TryGetValue(o, out reference)) {
				reference.refCount -= 1;

				if (reference.refCount == 0) {
					reference.handle.Free();
					handleMap.Remove(o);
				}
			}

			return ;
		}
	}
}
