namespace Qt
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
		static extern IntPtr make_metaObject(IntPtr parent, IntPtr stringdata, IntPtr data);
      
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class name is the key, the slot-hashtable the value.
		public static Hashtable classes = new Hashtable();
    
		/// This hashtable has classe names as keys, and QMetaObjects as values
		static Hashtable metaObjects = new Hashtable();
		
		public static void GetSlotSignatures(Type t) {
			
			/// Remove the old object if it already exists
			classes.Remove(t.Name);
			
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
			
			classes.Add(t.Name, slots);
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
				int offset;
				ArrayList data;
			
				public StringTableHandler() {
					hash = new Hashtable();
					offset = 0;
					data = new ArrayList();
				}
	
				public int this[string str] {
					get {
						if (!hash.ContainsKey(str)) {
#if DEBUG
							Console.WriteLine("adding {0} in hash at offset {1}", str, offset);
#endif
							hash[str] = offset;
							data.Add(str);
							offset += str.Length + 1;
						}
						return (int)hash[str];
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
			int[] data;
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
				array.Add((int)flags);                                 // flags
			}
		
			public QyotoMetaData(string className, ICollection signals, ICollection slots) {
				handler = new StringTableHandler();
				ArrayList tmp = new ArrayList(new int[] { 
					1,                                  // revision
					handler[className],                 // classname
					0, 0,                               // classinfo
					signals.Count + slots.Count, 10,  // methods
					0, 0,                               // properties
					0, 0
				});
			
				foreach (string entry in signals)
					AddMethod(tmp, entry, MethodFlags.MethodSignal | MethodFlags.AccessProtected);
				
				foreach (string entry in signals)
					AddMethod(tmp, entry, MethodFlags.MethodSlot | MethodFlags.AccessPublic);
				
				tmp.Add(0);
				
				stringdata = handler.GetStringData();
				data = new int[tmp.Count];
				tmp.CopyTo(data);
			}
		
			public byte[] StringData {
				get { return stringdata; }
			}
			
			public int[] Data {
				get { return data; }
			}
		}
    
		public static QMetaObject MakeMetaObject(Type t) {
#if DEBUG
			Console.WriteLine("ENTER: MakeMetaObject.  t => {0}", t);
#endif
		
			if (t == null || typeof(QObject).IsAssignableFrom(t)) return null;
		
			string className = t.ToString();
			Hashtable slotTable = (Hashtable)classes[className];
		
			ICollection slots;
			if (slotTable != null)
				slots = slotTable.Values;
			else {
				// build slot table
				GetSlotSignatures(t);
				slotTable = (Hashtable)classes[className];
				slots = slotTable.Values;
			}
		
			string[] signals = GetSignalSignatures(t);
			QyotoMetaData metaData = new QyotoMetaData(className, signals, slots);
			GCHandle parentMetaObject = GCHandle.Alloc(GetMetaObject(t.BaseType));
			IntPtr metaSmokeObject;
		
			unsafe {
				fixed (byte* stringdata = metaData.StringData)
				fixed (int* data = metaData.Data) {
					metaSmokeObject = make_metaObject((IntPtr)parentMetaObject, (IntPtr)stringdata, (IntPtr)data);
				}
			}
      
			// create a new C# QMetaObject and replace its
			// inner _smokeObject with that returned from make_metaObject
			QMetaObject res = new QMetaObject();
			FieldInfo fieldInfo = typeof(QMetaObject).GetField(  "_smokeObject", 
																BindingFlags.NonPublic 
																| BindingFlags.GetField
																| BindingFlags.Instance );
			((GCHandle)fieldInfo.GetValue(res)).Free();
			fieldInfo.SetValue(res, metaSmokeObject);
		
#if DEBUG
			Console.WriteLine("LEAVE MakeMetaObject");
#endif
			return res;
		}
    
		public static QMetaObject GetMetaObject(Type t) {
			QMetaObject res = (QMetaObject)metaObjects[t.ToString()];
			if (res == null) {
				res = MakeMetaObject(t);
				metaObjects[t.ToString()] = res;
			}
			return res;
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
}

