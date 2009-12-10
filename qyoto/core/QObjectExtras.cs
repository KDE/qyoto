namespace Qyoto {

	using System;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;

	public delegate void SlotFunc();
	public delegate void SlotFunc<T>(T arg);
	public delegate void SlotFunc<T1, T2>(T1 arg1, T2 arg2);
	public delegate void SlotFunc<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
	public delegate void SlotFunc<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
	public delegate void SlotFunc<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

	public partial class QObject : Qt, IDisposable {
		private delegate void AddToListFn(IntPtr obj);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		private static extern IntPtr FindQObjectChild(IntPtr parent, string childName);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi)]
		private static extern void FindQObjectChildren(IntPtr parent, IntPtr regexp,
									string childName, AddToListFn addFn);
		
		[DllImport("qyotoshared", CharSet=CharSet.Ansi)]
		private static extern bool ConnectDelegate(IntPtr obj, string signal, Delegate d, IntPtr handle);
		
		[DllImport("qyotoshared", CharSet=CharSet.Ansi)]
		private static extern bool DisconnectDelegate(IntPtr obj, string signal, Delegate d);
		
		public static bool Connect(QObject obj, string signal, SlotFunc d) {
			// allocate a gchandle so the delegate won't be collected
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}
		
		public static bool Connect<T>(QObject obj, string signal, SlotFunc<T> d) {
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}
		
		public static bool Connect<T1, T2>(QObject obj, string signal, SlotFunc<T1, T2> d) {
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}

		public static bool Connect<T1, T2, T3>(QObject obj, string signal, SlotFunc<T1, T2, T3> d) {
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}

		public static bool Connect<T1, T2, T3, T4>(QObject obj, string signal, SlotFunc<T1, T2, T3, T4> d) {
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}

		public static bool Connect<T1, T2, T3, T4, T5>(QObject obj, string signal, SlotFunc<T1, T2, T3, T4, T5> d) {
			IntPtr handle = (IntPtr) GCHandle.Alloc(d);
			return ConnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d, handle);
		}

		public static bool Disconnect(QObject obj, string signal, SlotFunc d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

		public static bool Disconnect<T>(QObject obj, string signal, SlotFunc<T> d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

		public static bool Disconnect<T1, T2>(QObject obj, string signal, SlotFunc<T1, T2> d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

		public static bool Disconnect<T1, T2, T3>(QObject obj, string signal, SlotFunc<T1, T2, T3> d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

		public static bool Disconnect<T1, T2, T3, T4>(QObject obj, string signal, SlotFunc<T1, T2, T3, T4> d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

		public static bool Disconnect<T1, T2, T3, T4, T5>(QObject obj, string signal, SlotFunc<T1, T2, T3, T4, T4> d) {
			return DisconnectDelegate((IntPtr) GCHandle.Alloc(obj), signal, d);
		}

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