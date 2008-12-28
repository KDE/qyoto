namespace Kimono {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Qyoto;
	
	public partial class KUrl : QUrl, IDisposable {
		public static implicit operator KUrl(string other) {
			return new KUrl(other);
		}
		
		public class List : List<KUrl> {
			delegate bool GetNextDictionaryEntryFn(ref IntPtr key, ref IntPtr value);
			
			[DllImport("kimono", CharSet=CharSet.Ansi)]
			static extern void KUrlListPopulateMimeData(SmokeMarshallers.NoArgs getNextItem, IntPtr mimeData, GetNextDictionaryEntryFn getNextDictionaryEntry, uint flags);
			[DllImport("kimono", CharSet=CharSet.Ansi)]
			static extern void KUrlListMimeDataTypes(SmokeMarshallers.FromIntPtr fn);
			[DllImport("kimono", CharSet=CharSet.Ansi)]
			static extern bool KUrlListCanDecode(IntPtr mimeData);
			[DllImport("kimono", CharSet=CharSet.Ansi)]
			static extern void KUrlListFromMimeData(SmokeMarshallers.FromIntPtr addfn, IntPtr mimeData, GetNextDictionaryEntryFn getNextDictionaryEntry);
			
			public List() {}
			
			public List(KUrl url) {
				Add(url);
			}
			
			public List(List<string> list) {
				foreach (string str in list) {
					Add(new KUrl(str));
				}
			}
			
			public List(List<KUrl> list) {
				foreach (KUrl url in list) {
					Add(url);
				}
			}
			
			public void PopulateMimeData(QMimeData mimeData, Dictionary<string, string> metaData, KUrl.MimeDataFlags flags) {
				int i = 0;
				SmokeMarshallers.NoArgs listfn = delegate() {
					if (i >= Count) return IntPtr.Zero;
					return (IntPtr) GCHandle.Alloc(this[i++]);
				};
				IDictionaryEnumerator e = metaData.GetEnumerator();
				GetNextDictionaryEntryFn dictfn = delegate(ref IntPtr key, ref IntPtr value) {
					if (!e.MoveNext()) return false;
					key = (IntPtr) GCHandle.Alloc(e.Key);
					value = (IntPtr) GCHandle.Alloc(e.Value);
					return true;
				};
				KUrlListPopulateMimeData(listfn, (IntPtr) GCHandle.Alloc(mimeData), dictfn, (uint) flags);
			}
			
			public void PopulateMimeData(QMimeData mimeData, Dictionary<string, string> metaData) {
				PopulateMimeData(mimeData, metaData, KUrl.MimeDataFlags.DefaultMimeDataFlags);
			}
			
			public void PopulateMimeData(QMimeData mimeData) {
				PopulateMimeData(mimeData, new Dictionary<string, string>(), KUrl.MimeDataFlags.DefaultMimeDataFlags);
			}
			
			public List<string> ToStringList() {
				List<string> list = new List<string>();
				foreach (KUrl url in this)
					list.Add(url.Url());
				return list;
			}
			
			public static List<string> MimeDataTypes() {
				List<string> ret = new List<string>();
				SmokeMarshallers.FromIntPtr fn = delegate(IntPtr ptr) {
					GCHandle handle = (GCHandle) ptr;
					ret.Add((string) handle.Target);
					handle.Free();
				};
				KUrlListMimeDataTypes(fn);
				return ret;
			}
			
			public static bool CanDecode(QMimeData mimeData) {
				return KUrlListCanDecode((IntPtr) GCHandle.Alloc(mimeData));
			}
			
			public static KUrl.List FromMimeData(QMimeData mimeData, Dictionary<string, string> metaData) {
				KUrl.List list = new KUrl.List();
				SmokeMarshallers.FromIntPtr addfn = delegate(IntPtr ptr) {
					GCHandle handle = (GCHandle) ptr;
					list.Add((KUrl) handle.Target);
					handle.Free();
				};
				IDictionaryEnumerator e = null;
				if (metaData != null) e = metaData.GetEnumerator();
				GetNextDictionaryEntryFn dictfn = delegate(ref IntPtr key, ref IntPtr value) {
					if (metaData == null) return false;
					if (!e.MoveNext()) return false;
					key = (IntPtr) GCHandle.Alloc(e.Key);
					value = (IntPtr) GCHandle.Alloc(e.Value);
					return true;
				};
				KUrlListFromMimeData(addfn, (IntPtr) GCHandle.Alloc(mimeData), dictfn);
				return list;
			}
			
			public static KUrl.List FromMimeData(QMimeData mimeData) {
				return FromMimeData(mimeData, null);
			}
		}
	}
}
