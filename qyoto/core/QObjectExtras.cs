namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;

	public partial class QObject : Qt, IDisposable {
		private delegate void AddToListFn(IntPtr obj);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		private static extern IntPtr FindQObjectChild(IntPtr parent, string childName);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		private static extern void FindQObjectChildren(IntPtr parent, IntPtr regexp,
									string childName, AddToListFn addFn);
		
		public T FindChild<T>(string name) {
			IntPtr child = FindQObjectChild((IntPtr) GCHandle.Alloc(this), name);
			if (child != IntPtr.Zero) {
				try {
					return (T) ((GCHandle) child).Target;
				} catch (Exception e) {
					Console.WriteLine("Found child, but an error has occurred: {0}", e.Message);
					return default(T);
				}
			} else {
				return default(T);
			}
		}

		public T FindChild<T>() {
			return FindChild<T>("");
		}

		public List<T> FindChildren<T>(string name) {
			List<T> list = new List<T>();
			AddToListFn addFn = delegate(IntPtr obj) {
				T o = (T) ((System.Runtime.InteropServices.GCHandle) obj).Target;
				list.Add(o);
			};
			FindQObjectChildren((IntPtr) GCHandle.Alloc(this), IntPtr.Zero, name, addFn);
			return list;
		}

		public List<T> FindChildren<T>() {
			return FindChildren<T>("");
		}

		public List<T> FindChildren<T>(QRegExp regExp) {
			List<T> list = new List<T>();
			AddToListFn addFn = delegate(IntPtr obj) {
				T o = (T) ((System.Runtime.InteropServices.GCHandle) obj).Target;
				list.Add(o);
			};
			FindQObjectChildren((IntPtr) GCHandle.Alloc(this), (IntPtr) GCHandle.Alloc(regExp), "", addFn);
			return list;
		}
	}
}