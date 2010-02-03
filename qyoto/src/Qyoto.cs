/***************************************************************************
                          Qyoto.cs  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004-2007 by Richard Dale, Arno Rehn
    email                : richard.j.dale@gmail.com
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

namespace Qyoto
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Reflection;
	using System.Text;
	using System.Runtime.InteropServices;

#if DEBUG
	public enum DebugLevel {
		Off, 
		Minimal, 
		High, 
		Extensive
	}

	public enum QtDebugChannel {
		QTDB_NONE = 0x00,
		QTDB_AMBIGUOUS = 0x01,
		QTDB_TRANSPARENT_PROXY = 0x02,
		QTDB_CALLS = 0x04,
		QTDB_GC = 0x08,
		QTDB_VIRTUAL = 0x10,
		QTDB_VERBOSE = 0x20,
		QTDB_ALL = QTDB_VERBOSE | QTDB_VIRTUAL | QTDB_GC | QTDB_CALLS | QTDB_TRANSPARENT_PROXY | QTDB_AMBIGUOUS
	}

	public class QDebug {
		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		public static extern void SetDebug(QtDebugChannel debugChannel);

		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		public static extern QtDebugChannel DebugChannel();

		public static DebugLevel debugLevel = DebugLevel.Off;

		public static void SetDebugLevel(DebugLevel level) {
			debugLevel = level;
			if (level == DebugLevel.Extensive) {
				SetDebug(QtDebugChannel.QTDB_ALL);
			}
		}
	}

	public class DebugGCHandle {
		public static GCHandle Alloc(object instance) {
			GCHandle handle = GCHandle.Alloc(instance);

			if (	QDebug.debugLevel >= DebugLevel.High
					&& (QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0 ) 
			{
				Console.WriteLine("GCHandle.Alloc 0x{0:x8} -> {1}", (IntPtr) handle, instance);
			}

			return handle;
		}

		public static void Free(GCHandle handle) {
			if (	QDebug.debugLevel >= DebugLevel.High
					&& (QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0 ) 
			{
				Console.WriteLine("GCHandle.Free 0x{0:x8} -> {1}", (IntPtr) handle, handle.Target);
			}

			handle.Free();
		}
	}

#endif

	public unsafe class Pointer<T> : IDisposable
		where T : struct
	{
		private IntPtr m_ptr;
		private bool alloced = false;
		
		public Pointer(IntPtr ptr) {
			m_ptr = ptr;
		}
		
		public Pointer(int length) {
			m_ptr = Marshal.AllocHGlobal(GetPrimitiveSize() * length);
			alloced = true;
		}
		
		public void Dispose() {
			if (alloced) Marshal.FreeHGlobal(m_ptr);
		}
		
		public Pointer(T[] array) {
			m_ptr = Marshal.AllocHGlobal(GetPrimitiveSize() * array.Length);
			alloced = true;
			for(int i = 0; i < array.Length; i++) {
				this[i] = array[i];
			}
		}
		
		public T this[int index] {
			get {
				return (T) GetPointerValue(m_ptr, typeof(T), index);
			}
			set {
				SetPointerValue(m_ptr, typeof(T), index, value);
			}
		}
		
		public T Value {
			get { return this[0]; }
			set { this[0] = value; }
		}
		
		public IntPtr ToIntPtr() {
			return m_ptr;
		}
		
		private int GetPrimitiveSize() {
			if (typeof(T) == typeof(bool)) {
				return sizeof(bool);
			} else if (typeof(T) == typeof(sbyte)) {
				return sizeof(sbyte);
			} else if (typeof(T) == typeof(byte)) {
				return sizeof(byte);
			} else if (typeof(T) == typeof(short)) {
				return sizeof(short);
			} else if (typeof(T) == typeof(ushort)) {
				return sizeof(ushort);
			} else if (typeof(T) == typeof(int)) {
				return sizeof(int);
			} else if (typeof(T) == typeof(uint)) {
				return sizeof(uint);
			} else if (typeof(T) == typeof(long)) {
				return sizeof(long);
			} else if (typeof(T) == typeof(ulong)) {
				return sizeof(ulong);
			} else if (typeof(T) == typeof(float)) {
				return sizeof(float);
			} else if (typeof(T) == typeof(double)) {
				return sizeof(double);
			}
			return 0;
		}
		
		private object GetPointerValue(IntPtr ptr, Type t, int i) {
			if (t == typeof(bool)) {
				return ((bool*) ptr)[i];
			} else if (t == typeof(sbyte)) {
				return ((sbyte*) ptr)[i];
			} else if (t == typeof(byte)) {
				return ((byte*) ptr)[i];
			} else if (t == typeof(short)) {
				return ((short*) ptr)[i];
			} else if (t == typeof(ushort)) {
				return ((ushort*) ptr)[i];
			} else if (t == typeof(int)) {
				return ((int*) ptr)[i];
			} else if (t == typeof(uint)) {
				return ((uint*) ptr)[i];
			} else if (t == typeof(long)) {
				return ((long*) ptr)[i];
			} else if (t == typeof(ulong)) {
				return ((ulong*) ptr)[i];
			} else if (t == typeof(float)) {
				return ((float*) ptr)[i];
			} else if (t == typeof(double)) {
				return ((double*) ptr)[i];
			}
			return null;
		}
		
		private void SetPointerValue(IntPtr ptr, Type t, int i, object value) {
			if (t == typeof(bool)) {
				((bool*) ptr)[i] = (bool) value;
			} else if (t == typeof(sbyte)) {
				((sbyte*) ptr)[i] = (sbyte) value;
			} else if (t == typeof(byte)) {
				((byte*) ptr)[i] = (byte) value;
			} else if (t == typeof(short)) {
				((short*) ptr)[i] = (short) value;
			} else if (t == typeof(ushort)) {
				((ushort*) ptr)[i] = (ushort) value;
			} else if (t == typeof(int)) {
				((int*) ptr)[i] = (int) value;
			} else if (t == typeof(uint)) {
				((uint*) ptr)[i] = (uint) value;
			} else if (t == typeof(long)) {
				((long*) ptr)[i] = (long) value;
			} else if (t == typeof(ulong)) {
				((ulong*) ptr)[i] = (ulong) value;
			} else if (t == typeof(float)) {
				((float*) ptr)[i] = (float) value;
			} else if (t == typeof(double)) {
				((double*) ptr)[i] = (double) value;
			}
		}
		
		public void FromArray(T[] array) {
			for (int i = 0; i < array.Length; i++) {
				this[i] = array[i];
			}
		}
		
		public static implicit operator IntPtr (Pointer<T> rhs) {
			return rhs.ToIntPtr();
		}
		
		public static implicit operator Pointer<T>(IntPtr rhs) {
			return new Pointer<T>(rhs);
		}
		
		public static implicit operator Pointer<T>(T[] rhs) {
			return new Pointer<T>(rhs);
		}
	}

	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	public class AssemblySmokeInitializer : Attribute {
		private Type type;
		
		public AssemblySmokeInitializer(Type t) {
			type = t;
		}
		
		public void CallInitSmoke() {
			type.InvokeMember("InitSmoke", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, null);
		}
		
		public Type InitSmokeType {
			get { return type; }
		}
	}

	public class Qyoto : System.Object
	{
		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		public static extern void Init_qyoto();
    
		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		public static extern void SetApplicationTerminated();

		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		static extern IntPtr qyoto_make_metaObject(	string parentClassName, IntPtr parentMeta,
												IntPtr stringdata, int stringdataCount, 
											 	IntPtr data, int dataCount );
		
		public class CPPMethod {
			public string signature;
			public string type;
			public MethodInfo mi;
			public bool scriptable;
		}
		
		public class CPPProperty {
			public string type;
			public string name;
			public PropertyInfo pi;
			public bool scriptable;
		}
		
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class type is the key, the slot-hashtable the value.
		public static Dictionary<Type, Dictionary<string, CPPMethod>> slotSignatures = 
			new Dictionary<Type, Dictionary<string, CPPMethod>>();

		public static Dictionary<Type, Dictionary<MethodInfo, Qyoto.CPPMethod>> signalSignatures = 
			new Dictionary<Type, Dictionary<MethodInfo, Qyoto.CPPMethod>>();
    
		/// This hashtable has the class types as keys, and QMetaObjects as values
		static Dictionary<Type, QMetaObject> metaObjects = new Dictionary<Type, QMetaObject> ();
		
		public static void Cleanup() {
			SmokeMarshallers.ConvertRefs();
			SetApplicationTerminated();
		}
		
		public static uint GetCPPEnumValue(string c, string value) {
			Type t = Type.GetType("Qyoto." + c, false);
			if (t == null) {
				return 0;
			}
			foreach (Type nt in t.GetNestedTypes()) {
				if (nt.IsEnum) {
					foreach (string name in Enum.GetNames((nt))) {
						if (name == value) {
							return Convert.ToUInt32(Enum.Parse(nt, name));
						}
					}
				}
			}
			return 0;
		}
		
		public static string GetPrimitiveString(Type type) {
			string typeString = type.ToString();
			switch (typeString) {
				case "System.Void":
					return "";
				case "System.Boolean":
					return "bool";
				case "System.Int32":
					return "int";
				case "System.Int64":
					return "long";
				case "System.UInt32":
					return "uint";
				case "System.UInt64":
					return "ulong";
				case "System.Int16":
					return "short";
				case "System.UInt16":
					return "ushort";
				case "System.Byte":
					return "uchar";
				case "System.SByte":
					return "sbyte";
				case "System.String":
					return "QString";
				case "System.Double":
					return "double";
				case "System.Single":
					return "float";
				case "System.Char":
					return "char";
			}

			if (type.IsGenericType) {
				Type[] args = type.GetGenericArguments();
				if (type.FullName.StartsWith("System.Collections.Generic.List`1")) {
					return "QList<" + GetPrimitiveString(args[0]) + ">";
				} else if (type.FullName.StartsWith("System.Collections.Generic.Dictionary`2")) {
					return "QMap<" + GetPrimitiveString(args[0]) + ", " + GetPrimitiveString(args[1]) + ">";
				}
			}

			if (SmokeMarshallers.IsSmokeClass(type)) {
				typeString = SmokeMarshallers.SmokeClassName(type);
			}
			
			// pointer types
			if (   type.IsSubclassOf(typeof(QObject))
			    || typeString == "QListWidgetItem"
			    || typeString == "QTreeWidgetItem"
			    || typeString == "QTableWidgetItem"
			    || typeString == "QStandardItem")
				typeString += "*";
			
			return typeString;
		}
		
		public static string SignatureFromMethodInfo(MethodInfo mi) {
			string name = mi.Name;
			string returnType = GetPrimitiveString(mi.ReturnType);
			string parameters = "";
			
			ParameterInfo[] ps = mi.GetParameters();
			
			foreach (ParameterInfo pi in ps) {
				parameters += GetPrimitiveString(pi.ParameterType) + ",";
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
		
		// Returns declared slots
		public static Dictionary<string, CPPMethod> GetSlotSignatures(Type t) {
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate array with the MethodInfo, signature and return type the value.
			Dictionary<string, CPPMethod> slots;
			if (slotSignatures.TryGetValue(t, out slots)) {
				return slots;
			}

			slots = new Dictionary<string, CPPMethod>();
			slotSignatures[t] = slots;

			// only declared members
			MethodInfo[] mis = t.GetMethods(	BindingFlags.Instance 
												| BindingFlags.Public 
												| BindingFlags.NonPublic
												| BindingFlags.DeclaredOnly);
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SLOT), false);
				foreach (Q_SLOT attr in attributes) {
					CPPMethod cppinfo = new CPPMethod();
					
					string sig = attr.Signature;
					if (sig == "")
						sig = SignatureFromMethodInfo(mi);

					sig = QMetaObject.NormalizedSignature(sig).ConstData();
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					cppinfo.mi = mi;
					
					if (mi.GetCustomAttributes(typeof(Q_SCRIPTABLE), false).Length > 0)
						cppinfo.scriptable = true;
					
					slots.Add(cppinfo.signature, cppinfo);
					break;
				}
			}
			return slots;
		}

		public static MethodInfo GetSlotMethodInfo(Type klass, string slotname) {
			Dictionary<string, CPPMethod> slotTable;
			CPPMethod result;

			do {
				slotTable = GetSlotSignatures(klass);

				if (slotTable.TryGetValue(slotname, out result)) {
					return result.mi;
				}

				klass = klass.BaseType;
			} while (!SmokeMarshallers.IsSmokeClass(klass));

			return null;
		}
		
		// Returns declared signals
		public static Dictionary<MethodInfo, CPPMethod> GetSignalSignatures(Type iface) {
			Dictionary<MethodInfo, CPPMethod> signals;

			if (signalSignatures.TryGetValue(iface, out signals)) {
				return signals;
			}

			signals = new Dictionary<MethodInfo, CPPMethod>();
			signalSignatures[iface] = signals;
			
			// GetMethods() doesn't return inherited methods for interfaces
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
					sig = QMetaObject.NormalizedSignature(sig).ConstData();
					GetCPPMethodInfo(sig, out cppinfo.signature, out cppinfo.type);
					cppinfo.mi = mi;
					
					if (mi.GetCustomAttributes(typeof(Q_SCRIPTABLE), false).Length > 0)
						cppinfo.scriptable = true;

					signals.Add(cppinfo.mi, cppinfo);
				}
			}
			
			return signals;
		}

		public static CPPMethod GetSignalSignature(Type signalsInterface, MethodInfo signalMethod) {
			Dictionary<MethodInfo, CPPMethod> signals = GetSignalSignatures(signalsInterface);
			CPPMethod result;

			if (signals.TryGetValue(signalMethod, out result)) {
				return result;
			}

			Type[] ifaces = signalsInterface.GetInterfaces();
			foreach (Type iface in ifaces) {
				signals = GetSignalSignatures(iface);

				if (signals.TryGetValue(signalMethod, out result)) {
					return result;
				}
			}

			return null;
		}

		private static Dictionary<Type, Type> emitInterfaceCache = new Dictionary<Type, Type>();

		public static Type GetSignalsInterface(Type klass) {
			Type iface;
			if (emitInterfaceCache.TryGetValue(klass, out iface)) {
				return iface;
			}

			PropertyInfo[] pis = klass.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
			PropertyInfo pi = null;
			foreach (PropertyInfo _pi in pis) {
				if (_pi.Name == "Emit") {
					pi = _pi;
					break;
				}
			}
			emitInterfaceCache[klass] = pi.PropertyType;
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
		
		public static Dictionary<PropertyInfo, CPPProperty> GetProperties(Type t) {
			Dictionary<PropertyInfo, CPPProperty> props = new Dictionary<PropertyInfo, CPPProperty>();
			
			foreach (PropertyInfo pi in t.GetProperties()) {
				if (SmokeMarshallers.IsSmokeClass(pi.DeclaringType)) continue;
				object[] attrs = pi.GetCustomAttributes(typeof(Q_PROPERTY), false);
				if (attrs.Length != 0) {
					Q_PROPERTY attr = (Q_PROPERTY) attrs[0];
					CPPProperty prop = new CPPProperty();
					if (attr.Type == "" || attr.Name == "") {
						prop.type = GetPrimitiveString(pi.PropertyType);
						prop.name = pi.Name;
					} else {
						prop.type = attr.Type;
						prop.name = attr.Name;
					}
					prop.pi = pi;
					if (pi.GetCustomAttributes(typeof(Q_SCRIPTABLE), false).Length != 0)
						prop.scriptable = true;
					props.Add(pi, prop);
				}
			}
			
			return props;
		}
		
		public static QMetaObject MakeMetaObject(Type t) {
			if (t == null) return null;

			QMetaObject parentMeta = null;
			string parentClassName = null;
			if (	!SmokeMarshallers.IsSmokeClass(t.BaseType)
					&& !metaObjects.TryGetValue(t.BaseType, out parentMeta) ) 
			{
				// create QMetaObject
				parentMeta = MakeMetaObject(t.BaseType);
			} else {
				parentClassName = SmokeMarshallers.SmokeClassName(t.BaseType);
			}
			
			ICollection<CPPMethod> slots;
			
			// build slot table
			slots = GetSlotSignatures(t).Values;

			PropertyInfo pi = t.GetProperty("Emit", BindingFlags.Instance 
													| BindingFlags.NonPublic
													| BindingFlags.DeclaredOnly);
			ICollection<CPPMethod> signals = null;			
			if (pi == null) {
				signals = new List<CPPMethod>();			
			} else {
				emitInterfaceCache[t] = pi.PropertyType;
				signals = GetSignalSignatures(pi.PropertyType).Values;			
			}

			ICollection<CPPProperty> properties = GetProperties(t).Values;			
			QyotoMetaData metaData = new QyotoMetaData(t.Name, signals, slots, GetClassInfos(t), properties);

			IntPtr metaObject;
			IntPtr parentMetaPtr = (IntPtr) 0;
			
			unsafe {
				fixed (byte* stringdata = metaData.StringData)
				fixed (uint* data = metaData.Data) {
					if (parentMeta != null) {
#if DEBUG
						parentMetaPtr = (IntPtr) DebugGCHandle.Alloc(parentMeta);
#else
						parentMetaPtr = (IntPtr) GCHandle.Alloc(parentMeta);
#endif
					}
					metaObject = qyoto_make_metaObject(	parentClassName,
													parentMetaPtr,
												 	(IntPtr)stringdata, metaData.StringData.Length,
												 	(IntPtr)data, metaData.Data.Length );
				}
			}
      
			QMetaObject res = (QMetaObject)((GCHandle) metaObject).Target;
#if DEBUG
			DebugGCHandle.Free((GCHandle) metaObject);
#else
			((GCHandle) metaObject).Free();
#endif
			metaObjects.Add(t, res);
			return res;
		}
		
		public static QMetaObject GetMetaObject(Type t) {
			QMetaObject res;
			if (!metaObjects.TryGetValue(t, out res)) {
				// create QMetaObject
				res = MakeMetaObject(t);
			}

			return res;
		}

		public static QMetaObject GetMetaObject(QObject o) {
			return GetMetaObject(o.GetType());
		}
	}
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class SmokeClass : Attribute
	{
		public string signature;	
	
		public string Signature {
			get {
				return signature;
			}
		}
	
		public SmokeClass(string signature) {
			this.signature = signature;
		}
	}

	[AttributeUsage(	AttributeTargets.Constructor 
						| AttributeTargets.Method
						| AttributeTargets.Interface )]
	public class SmokeMethod : Attribute
	{
		public string signature;
	
		public string Signature {
			get {
				return signature;
			}
		}
	
		public SmokeMethod(string signature)
		{
			this.signature = signature;
		}
	}
	
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
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

	[AttributeUsage( AttributeTargets.Property )]
	public class Q_PROPERTY : Attribute
	{
		public string Type;
		public string Name;
		
		public Q_PROPERTY(string type, string name)
		{
			Type = type;
			Name = name;
		}
		
		public Q_PROPERTY()
		{
			Type = "";
			Name = "";
		}
	}
}

