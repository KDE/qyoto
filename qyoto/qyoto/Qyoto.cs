// #define DEBUG

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
		public static extern void DeleteQApp();

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void Init_qyoto();
    
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr make_metaObject(IntPtr parent, IntPtr stringdata, int stringdataCount, 
											 IntPtr data, int dataCount);
		
		public struct CPPMethod {
			public string signature;
			public string type;
			public MethodInfo mi;
		}
		
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class name is the key, the slot-hashtable the value.
		public static Hashtable classes = new Hashtable();
    
		/// This hashtable has classe names as keys, and QMetaObjects as values
		static Hashtable metaObjects = new Hashtable();
		
		public static bool IsSmokeClass(Type t) {
			object[] attr = t.GetCustomAttributes(typeof(SmokeClass), false);
			return attr.Length > 0;
		}
		
		public static bool IsSmokeClass(IntPtr obj) {
			object qobj = ((GCHandle) obj).Target;
			return IsSmokeClass(qobj.GetType());
		}
		
		public static string GetPrimitiveString(string type) {
			string ret = type;
			
			switch (type) {
				case "System.Void":
					ret = "void";
					break;
				case "System.Boolean":
					ret = "bool";
					break;
				case "System.Int32":
					ret = "int";
					break;
				case "System.Int64":
					ret = "long";
					break;
				case "System.UInt32":
					ret = "uint";
					break;
				case "System.UInt64":
					ret = "ulong";
					break;
				case "System.Int16":
					ret = "short";
					break;
				case "System.UInt16":
					ret = "ushort";
					break;
				case "System.Byte":
					ret = "byte";
					break;
				case "System.SByte":
					ret = "sbyte";
					break;
				case "System.String":
					ret = "string";
					break;
				case "System.Double":
					ret = "double";
					break;
				case "System.Single":
					ret = "float";
					break;
				case "System.Char":
					ret = "char";
					break;
			}
			
			return ret;
		}
		
		public static string SignatureFromMethodInfo(MethodInfo mi) {
			string name = mi.Name;
			string returnType = GetPrimitiveString(mi.ReturnType.ToString());
			string parameters = "";
			
			ParameterInfo[] ps = mi.GetParameters();
			
			foreach (ParameterInfo pi in ps) {
				parameters += GetPrimitiveString(pi.ParameterType.ToString()) + ",";
			}
			
			/// remove the last comma
			if (parameters.Length != 0) 
				parameters = parameters.Remove(parameters.Length - 1, 1);
			
			return returnType + " " + name + "(" + parameters + ")";
		}
		
		public static void GetCPPMethodInfo(string method, out string signature, out string type) {
				/// we need to get the return type, therfore we search first for the first space before the method name and everything before this is the return type
				//Console.WriteLine(method);
				int ix = method.IndexOf('(');
				int ix_space = method.LastIndexOf(' ', ix);
				
				string return_type = "";
				if (ix_space != -1) 
					return_type = method.Substring(0, ix_space).Trim();
				
				string sig = method.Substring(return_type.Length).Trim();
				//Console.WriteLine("Signature: {0}", sig);
				signature = sig;
				type = return_type;
		}
		
		public static Hashtable GetSlotSignatures(Type t) {
			/// Remove the old object if it already exists
			classes.Remove(t.ToString());
			
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate array with the MethodInfo, signature and return type the value.
			Hashtable slots = new Hashtable();
			
			MethodInfo[] mis = t.GetMethods( BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SLOT), false);
				foreach (Q_SLOT attr in attributes) {
					CPPMethod cppinfo = new CPPMethod();
					
					string sig = attr.Signature;
					if (sig == "")
						sig = SignatureFromMethodInfo(mi);
					
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					
					cppinfo.mi = mi;
					slots.Add(cppinfo.signature, cppinfo);
					break;
				}
			}
			
			classes.Add(t.ToString(), slots);
			return slots;
		}
		
		
		/// returns a Hastable with the MethodInfo as a key and the array with the MethodInfo, signature and return type the value.
		public static Hashtable GetSignalSignatures(Type t) {
			Hashtable signals = new Hashtable();
			if (IsSmokeClass(t)) {
				return null;
			}
			
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
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SIGNAL), false);
				foreach (Q_SIGNAL attr in attributes) {
					CPPMethod cppinfo = new CPPMethod();
					string sig = attr.Signature;
					if (sig == "")
						sig = SignatureFromMethodInfo(mi).Trim();
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					cppinfo.mi = mi;
					signals.Add(cppinfo.mi, cppinfo);
				}
			}
			
			return signals;
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
		
			void AddMethod(ArrayList array, string method, string type, MethodFlags flags) {
				array.Add(handler[method]);                            // signature
				array.Add(handler[Regex.Replace(method, "[^,]", "")]); // parameters
				array.Add(handler[type]);				// type
				array.Add(handler[""]);                                // tag
				array.Add((uint)flags);                                 // flags
			}
		
			public QyotoMetaData(string className, ICollection signals, ICollection slots) {
				handler = new StringTableHandler();
				ArrayList tmp = new ArrayList(new uint[] { 
					1,                                  // revision
					handler[className],                 // classname
					0, 0,                               // classinfo
					(uint)(signals.Count + slots.Count), 10,  // methods
					0, 0,                               // properties
					0, 0
				});
			
				foreach (CPPMethod entry in signals)
					AddMethod(tmp, entry.signature, entry.type, MethodFlags.MethodSignal | MethodFlags.AccessProtected);
				
				foreach (CPPMethod entry in slots)
					AddMethod(tmp, entry.signature, entry.type, MethodFlags.MethodSlot | MethodFlags.AccessPublic);
				
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
				slots = slotTable.Values;
			else {
				// build slot table
				slots = GetSlotSignatures(t).Values;
			}

			Hashtable signals = GetSignalSignatures(t);
			QyotoMetaData metaData = new QyotoMetaData(className, signals.Values, slots);
			
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
#if DEBUG
			Console.WriteLine("ENTER GetMetaObject t => {0}", t);
#endif
			
			QMetaObject res = (QMetaObject)metaObjects[t.ToString()];
			if (res == null) {
				// create QMetaObject
				res = MakeMetaObject(t, o);
				metaObjects[t.ToString()] = res;
			}
	
#if DEBUG
			Console.WriteLine("LEAVE GetMetaObject");
#endif

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
		
		public Q_SIGNAL() {
			this.signature = "";
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
		
		public Q_SLOT() {
			this.signature = "";
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

