// #define DEBUG

namespace Qyoto
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
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
			public bool scriptable;
		}
		
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class name is the key, the slot-hashtable the value.
		public static Dictionary<string, Dictionary<string, CPPMethod>> classes = 
			new Dictionary<string, Dictionary<string, CPPMethod>>();
    
		/// This hashtable has class names as keys, and QMetaObjects as values
		static Dictionary<string, QMetaObject> metaObjects = new Dictionary<string, QMetaObject> ();
		
		public static int GetCPPEnumValue(string c, string value) {
			Type t = Type.GetType("Qyoto." + c, false);
			if (t == null) {
#if DEBUG
				Console.WriteLine("NULL");
#endif
				return 0;
			}
			foreach (Type nt in t.GetNestedTypes()) {
				if (nt.IsEnum) {
#if DEBUG
					Console.WriteLine("ENUM: {0}", nt.ToString());
#endif
					foreach (int i in Enum.GetValues(nt)) {
#if DEBUG
						Console.WriteLine("MEMBER: {0}", Enum.Format(nt, i, "f"));
#endif
						if (Enum.Format(nt, i, "f") == value) {
							return i;
						}
					}
				}
			}
			return 0;
		}
		
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
					ret = "";
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
					ret = "QString";
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
		
		public static Dictionary<string, CPPMethod> GetSlotSignatures(Type t) {
			/// Remove the old object if it already exists
			classes.Remove(t.ToString());
			
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate array with the MethodInfo, signature and return type the value.
			Dictionary<string, CPPMethod> slots = new Dictionary<string, CPPMethod>();
			
			MethodInfo[] mis = t.GetMethods(	BindingFlags.Instance 
												| BindingFlags.Static 
												| BindingFlags.Public 
												| BindingFlags.NonPublic
												| BindingFlags.DeclaredOnly );
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SLOT), false);
				foreach (Q_SLOT attr in attributes) {
					CPPMethod cppinfo = new CPPMethod();
					
					string sig = attr.Signature;
					if (sig == "")
						sig = SignatureFromMethodInfo(mi);
					
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					
					cppinfo.mi = mi;
					
					if (mi.GetCustomAttributes(typeof(Q_SCRIPTABLE), false).Length > 0)
						cppinfo.scriptable = true;
					
					slots.Add(cppinfo.signature, cppinfo);
					break;
				}
			}
			
			classes.Add(t.ToString(), slots);
			return slots;
		}
		
		
		/// returns a Hastable with the MethodInfo as a key and the array with the MethodInfo, signature and return type the value.
		public static Dictionary<MethodInfo, CPPMethod> GetSignalSignatures(Type t) {
			Dictionary<MethodInfo, CPPMethod> signals = new Dictionary<MethodInfo, CPPMethod>();
			if (IsSmokeClass(t)) {
				return signals;
			}
			
			PropertyInfo propertyInfo = t.GetProperty(	"Emit", 
													BindingFlags.Instance 
													| BindingFlags.NonPublic 
													| BindingFlags.DeclaredOnly );
			if (propertyInfo == null) {
				return signals;
			}

			Type iface = propertyInfo.PropertyType;
			MethodInfo[] mis = iface.GetMethods();
			
			/// the interface has no signals...
			if (mis.Length == 0)
				return signals;
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SIGNAL), false);
				foreach (Q_SIGNAL attr in attributes) {
					CPPMethod cppinfo = new CPPMethod();
					string sig = attr.Signature;
					if (sig == "")
						sig = SignatureFromMethodInfo(mi).Trim();
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					cppinfo.mi = mi;
					
					if (mi.GetCustomAttributes(typeof(Q_SCRIPTABLE), false).Length > 0)
						cppinfo.scriptable = true;

					signals.Add(cppinfo.mi, cppinfo);
				}
			}
			
			return signals;
		}
		
		public static Type GetSignalsInterface(Type t) {
			PropertyInfo pi = t.GetProperty("Emit", BindingFlags.Instance | BindingFlags.NonPublic);
			return pi.PropertyType;
		}
		
		public static Dictionary<string, string> GetClassInfos(Type t) {
			Dictionary<string, string> classinfos = new Dictionary<string, string>();
			object[] attributes = t.GetCustomAttributes(typeof(Q_CLASSINFO), false);
			foreach (Q_CLASSINFO attr in attributes) {
				classinfos.Add(attr.Name, attr.Value);
			}
			return classinfos;
		}
		
		class QyotoMetaData {
			byte[] stringdata;
			uint[] data;
			private delegate uint Handler(string str);
			Handler handler;
		
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
			
			void AddClassInfo(List<uint> array, string key, string value) {
				array.Add(handler(key));
				array.Add(handler(value));
			}
			
			void AddMethod(List<uint> array, string method, string type, MethodFlags flags) {
				array.Add(handler(method));                            // signature
				array.Add(handler(Regex.Replace(method, "[^,]", ""))); // parameters
				array.Add(handler(type));				// type
				array.Add(handler(""));                                // tag
				array.Add((uint)flags);                                 // flags
			}
			
			byte[] ComputeStringData(List<string> array) {
				List<byte> result = new List<byte>();
				foreach(string x in array) {
					result.AddRange(Encoding.ASCII.GetBytes(x));
					result.Add(0);
				}
				return result.ToArray();
			}
		
			public QyotoMetaData(string className, ICollection<CPPMethod> signals, 
								ICollection<CPPMethod> slots, Dictionary<string, string> classinfos) {
				Dictionary<string, uint> hash = new Dictionary<string, uint>();
				uint offset = 0;
				List<string> stringdata_tmp = new List<string>();

				handler = delegate(string str) {
						uint res;
						if (!hash.TryGetValue(str, out res)) {
#if DEBUG
							Console.WriteLine("adding {0} in hash at offset {1}", str, offset);
#endif
							hash.Add(str, offset);
							stringdata_tmp.Add(str);
							res = offset;
							offset += (uint)str.Length + 1;
						}
						return res;
				};
				
				List<uint> tmp = new List<uint>(new uint[] {
					1,                                  // revision
					handler(className),                 // classname
					(uint)classinfos.Count, classinfos.Count > 0 ? (uint)10 : (uint)0,  // classinfo
					(uint)(signals.Count + slots.Count),
					(uint)(10 + (2 * classinfos.Count)),        // methods
					0, 0,                               // properties
					0, 0
				});
				
				foreach (KeyValuePair<string, string> p in classinfos)
					AddClassInfo(tmp, p.Key, p.Value);
				
				foreach (CPPMethod entry in signals) {
					MethodFlags flags = MethodFlags.MethodSignal | MethodFlags.AccessProtected;
					
					if (entry.scriptable)
						flags = MethodFlags.MethodScriptable | MethodFlags.MethodSignal | MethodFlags.AccessPublic;
					
					AddMethod(tmp,
						entry.signature,						// signature
						entry.type,							// return type, "" for void
						flags);
				}
				
				foreach (CPPMethod entry in slots) {
					MethodFlags flags = MethodFlags.MethodSlot | MethodFlags.AccessPublic;
					
					if (entry.scriptable)
						flags = MethodFlags.MethodScriptable | MethodFlags.MethodSlot | MethodFlags.AccessPublic;
					
					AddMethod(tmp,
						entry.signature,						// signature
						entry.type,							// return type, "" for void
						MethodFlags.MethodSlot | MethodFlags.AccessPublic);
				}
				
				tmp.Add(0);
				
				stringdata = ComputeStringData(stringdata_tmp);
				data = tmp.ToArray();
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
			Dictionary<string, CPPMethod> slotTable;
			ICollection<CPPMethod> slots;
			
			if (classes.TryGetValue(className, out slotTable))
				slots = slotTable.Values;
			else {
				// build slot table
				slots = GetSlotSignatures(t).Values;
			}

			Dictionary<MethodInfo, CPPMethod> signals = GetSignalSignatures(t);
			QyotoMetaData metaData = new QyotoMetaData(className, signals.Values, slots, GetClassInfos(t));
			
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
			
			QMetaObject res;
			if (!metaObjects.TryGetValue(t.ToString(), out res)) {
				// create QMetaObject
				res = MakeMetaObject(t, o);
				metaObjects.Add(t.ToString(), res);
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
	public class Q_CLASSINFO : Attribute
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

