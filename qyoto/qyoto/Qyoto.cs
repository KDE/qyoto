namespace Qyoto
{
	using System;
	using System.Collections;
	using System.Reflection;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Runtime.InteropServices;
	
	public class Qyoto : System.Object
	{
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void Init_qyoto();
    
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr make_metaObject(IntPtr parent, IntPtr stringdata, int stringdataCount, 
											 IntPtr data, int dataCount);
      
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class name is the key, the slot-hashtable the value.
		public static Hashtable classes = new Hashtable();
    
		/// This hashtable has classe names as keys, and QMetaObjects as values
		static Hashtable metaObjects = new Hashtable();
		
		public static Hashtable GetSlotSignatures(Type t) {
			Console.WriteLine("creating slots for {0}", t);
			/// Remove the old object if it already exists
			classes.Remove(t.ToString());
			
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate C# MethodInfo the value.
			Hashtable slots = new Hashtable();
			
			MethodInfo[] mis = t.GetMethods( BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SLOT), false);
				foreach (Q_SLOT attr in attributes) {
					slots.Add(attr.Signature, mi);
					break;
				}
			}
			
			classes.Add(t.ToString(), slots);
			return slots;
		}
		
		public static string[] GetSignalSignatures(Type t) {
			Type iface;
			try {
				iface = GetSignalsInterface(t);
			}
			catch {
				return null;
			}
			MethodInfo[] mis = iface.GetMethods();
			
			/// the interface has no signals...
			if (mis.Length == 0)
				return null;
				
			string[] signatures = new string[mis.Length];
			int i = 0;
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SIGNAL), false);
				foreach (Q_SIGNAL attr in attributes) {
					signatures[i] = attr.Signature;
				}
				i++;
			}
			
			return signatures;
		}
		
		public static Type GetSignalsInterface(Type t) {
			MethodInfo mi = t.GetMethod("Emit", BindingFlags.Instance | BindingFlags.NonPublic);
			return mi.ReturnType;
		}
    
		class QyotoMetaData {
			// Keeps a hash of strings against their corresponding offsets
			// within the qt_meta_stringdata sequence of null terminated
			// strings.
			class StringTableHandler {
				Hashtable hash;
				uint offset;
				ArrayList data;
			
				public StringTableHandler() {
					hash = new Hashtable();
					offset = 0;
					data = new ArrayList();
				}
	
				public uint this[string str] {
					get {
						if (!hash.ContainsKey(str)) {
#if DEBUG
							Console.WriteLine("adding {0} in hash at offset {1}", str, offset);
#endif
							hash[str] = offset;
							data.Add(str);
							offset += (uint)str.Length + 1;
						}
						return (uint)hash[str];
					}
				}
			
				public byte[] GetStringData() {
					ArrayList result = new ArrayList();
					foreach(string x in data) {
						result.AddRange(Encoding.ASCII.GetBytes(x));
						result.Add((byte)0);
					}
					byte[] res = new byte[result.Count];
					result.CopyTo(res);
					return res;
				}
			}
		
			byte[] stringdata;
			uint[] data;
			StringTableHandler handler;
		
			// from qt-copy/src/tools/moc/generator.cpp
			enum MethodFlags {
				AccessPrivate = 0x00,
				AccessProtected = 0x01,
				AccessPublic = 0x02,
				MethodMethod = 0x00,
				MethodSignal = 0x04,
				MethodSlot = 0x08,
				MethodCompatibility = 0x10,
				MethodCloned = 0x20,
				MethodScriptable = 0x40
			}
		
			void AddMethod(ArrayList array, string method, MethodFlags flags) {
				array.Add(handler[method]);                            // signature
				array.Add(handler[Regex.Replace(method, "[^,]", "")]); // parameters
				array.Add(handler[""]);                                // type
				array.Add(handler[""]);                                // tag
				array.Add((uint)flags);                                 // flags
			}
		
			public QyotoMetaData(string className, ICollection signals, ICollection slots) {
				handler = new StringTableHandler();
				Console.WriteLine("methodCount should be {0}", signals.Count + slots.Count);
				ArrayList tmp = new ArrayList(new uint[] { 
					1,                                  // revision
					handler[className],                 // classname
					0, 0,                               // classinfo
					(uint)(signals.Count + slots.Count), 10,  // methods
					0, 0,                               // properties
					0, 0
				});
			
				foreach (string entry in signals)
					AddMethod(tmp, entry, MethodFlags.MethodSignal | MethodFlags.AccessProtected);
				
				foreach (string entry in slots)
					AddMethod(tmp, entry, MethodFlags.MethodSlot | MethodFlags.AccessPublic);
				
				tmp.Add((uint)0);
				
				stringdata = handler.GetStringData();
				data = new uint[tmp.Count];
				tmp.CopyTo(data);
/*				for (int i = 0; i < tmp.Count; i++) {
					Console.WriteLine("copying {0} => {1}", i, tmp[i]);
					data[i] = (uint)tmp[i];
				}*/
			}
		
			public byte[] StringData {
				get { return stringdata; }
			}
			
			public uint[] Data {
				get { return data; }
			}
		}
    
		public static QMetaObject MakeMetaObject(Type t, QObject o) {
			if (t == null) return null;
		
			string className = t.ToString();
			Hashtable slotTable = (Hashtable)classes[className];
			
		
			ICollection slots;
			if (slotTable != null)
				slots = slotTable.Keys;
			else {
				// build slot table
				slots = GetSlotSignatures(t).Keys;
			}

			string[] signals = GetSignalSignatures(t);
			QyotoMetaData metaData = new QyotoMetaData(className, signals, slots);
			
			GCHandle objHandle = GCHandle.Alloc(o);
			IntPtr metaObject;
			
			unsafe {
				fixed (byte* stringdata = metaData.StringData)
				fixed (uint* data = metaData.Data) {
					metaObject = make_metaObject((IntPtr)objHandle, 
												 (IntPtr)stringdata, metaData.StringData.Length,
												 (IntPtr)data, metaData.Data.Length);
				}
			}
      
			QMetaObject res = (QMetaObject)((GCHandle) metaObject).Target;
			return res;
		}
    
		public static QMetaObject GetMetaObject(QObject o) {
			Type t = o.GetType();
			object[] attr = t.GetCustomAttributes(typeof(SmokeClass), false);
			if (attr.Length > 0) {
				// qt class: simply call the MetaObject method
				MethodInfo metaObjectMethod = t.GetMethod("MetaObject", BindingFlags.Public | BindingFlags.Instance);
				if (metaObjectMethod == null) {
					// this should never happen
					Console.WriteLine("** Cannot find MetaObject method **");
					return null;
				}
				else {
					return (QMetaObject)metaObjectMethod.Invoke(o, new object[] {});
				}
			}
			else {
				// user defined class: retrieve QMetaObject from the hashtable
				QMetaObject res = (QMetaObject)metaObjects[t.ToString()];
				if (res == null) {
					// create QMetaObject
					res = MakeMetaObject(t, o);
					metaObjects[t.ToString()] = res;
				}
				return res;
			}
		}
	}
	
	[AttributeUsage( AttributeTargets.Class )]
	class SmokeClass : Attribute
	{
		public string signature;
	
		public string Signature
		{
			get
			{
				return signature;
			}
		}
	
		public SmokeClass(string signature)
		{
			this.signature = signature;
		}
	}

	[AttributeUsage( AttributeTargets.Method )]
	class SmokeMethod : Attribute
	{
		public string signature;
	
		public string Signature
		{
			get
			{
				return signature;
			}
		}
	
		public SmokeMethod(string signature)
		{
			this.signature = signature;
		}
	}
	
	[AttributeUsage( AttributeTargets.Class )]
	class Q_CLASSINFO : Attribute
	{
		public string name;
	
		public string Name
		{
			get
			{
				return name;
			}
		}

		public string value;
	
		public string Value
		{
			get
			{
				return value;
			}
		}
	
		public Q_CLASSINFO(string name, string value)
		{
			this.name = name;
			this.value = value;
		}
	}

	[AttributeUsage( AttributeTargets.Method )]
	public class Q_SIGNAL : Attribute
	{
		public string signature;
	
		public string Signature
		{
			get
			{
				return signature;
			}
		}
	
		public Q_SIGNAL(string signature)
		{
			this.signature = signature;
		}
	}

	[AttributeUsage( AttributeTargets.Method )]
	public class Q_SLOT : Attribute
	{
		public string signature;
	
		public string Signature
		{
			get
			{
				return signature;
			}
		}
	
		public Q_SLOT(string signature)
		{
			this.signature = signature;
		}
	}

	[AttributeUsage( AttributeTargets.Method )]
	public class Q_SCRIPTABLE : Attribute
	{
		public Q_SCRIPTABLE()
		{
		}
	}
}

