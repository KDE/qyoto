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
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

namespace Qyoto
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Text;
	using System.Text.RegularExpressions;
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
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void SetDebug(QtDebugChannel debugChannel);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern QtDebugChannel DebugChannel();

		public static DebugLevel debugLevel = DebugLevel.Off;

		public static void SetDebugLevel(DebugLevel level) {
			debugLevel = level;
			if (level == DebugLevel.Extensive) {
				SetDebug(QtDebugChannel.QTDB_ALL);
			}
		}
	}
#endif

	public class Qyoto : System.Object
	{
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void Init_qyoto();
    
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void SetApplicationTerminated();

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr make_metaObject(	IntPtr obj, IntPtr parentMeta,
												IntPtr stringdata, int stringdataCount, 
											 	IntPtr data, int dataCount );
		
		public struct CPPMethod {
			public string signature;
			public string type;
			public MethodInfo mi;
			public bool scriptable;
		}
		
		public struct CPPProperty {
			public string type;
			public string name;
			public PropertyInfo pi;
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
				return 0;
			}
			foreach (Type nt in t.GetNestedTypes()) {
				if (nt.IsEnum) {
					foreach (int i in Enum.GetValues(nt)) {
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
		
		public static string GetPrimitiveString(Type type) {
			string typeString = type.ToString();
			string ret = type.ToString();

			if (type.IsGenericType) {
				return "Generic";
			}

			if (typeString.StartsWith("Qyoto.")) {
				return typeString.Replace("Qyoto.", "");
			}

			switch (type.ToString()) {
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
					ret = "uchar";
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
		
		// this method is only used when we build up our meta object.
		// it only returns declared slots
		public static Dictionary<string, CPPMethod> GetSlotSignatures(Type t) {
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate array with the MethodInfo, signature and return type the value.
			Dictionary<string, CPPMethod> slots = new Dictionary<string, CPPMethod>();
			
			// only declared members
			MethodInfo[] mis = t.GetMethods(	BindingFlags.Instance 
												| BindingFlags.Static 
												| BindingFlags.Public 
												| BindingFlags.NonPublic
												| BindingFlags.DeclaredOnly);
			
			foreach (MethodInfo mi in mis) {
				if (IsSmokeClass(mi.DeclaringType)) continue;
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
			return slots;
		}
		
		// this method is used to get _all_ the slots of a class
		// this is needed by SmokeInvocation.InvokeCustomSlot()
		public static Dictionary<string, CPPMethod> GetAllSlotSignatures(Type t) {
			/// Remove the old object if it already exists
			classes.Remove(t.ToString());
			
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate array with the MethodInfo, signature and return type the value.
			Dictionary<string, CPPMethod> slots = new Dictionary<string, CPPMethod>();
			
			// also include inherited members
			MethodInfo[] mis = t.GetMethods(	BindingFlags.Instance 
												| BindingFlags.Static 
												| BindingFlags.Public 
												| BindingFlags.NonPublic);
			
			foreach (MethodInfo mi in mis) {
				if (IsSmokeClass(mi.DeclaringType)) continue;
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
		
		// this method is again only used when we build up our meta object.
		// it only returns declared signals
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
			
			// don't get inherited methods
			MethodInfo[] mis = iface.GetMethods(BindingFlags.Instance
								| BindingFlags.Static
								| BindingFlags.DeclaredOnly
								| BindingFlags.Public
								| BindingFlags.NonPublic);
			
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
		
		// this method returns _all_ the signals of a class, including inherited ones
		// used by SignalInvocation.Invoke()
		public static Dictionary<MethodInfo, CPPMethod> GetAllSignalSignatures(Type t) {
			Dictionary<MethodInfo, CPPMethod> signals = new Dictionary<MethodInfo, CPPMethod>();
			if (IsSmokeClass(t))
				return signals;
			
			Type currentType = t;
			while (!IsSmokeClass(currentType)) {
				PropertyInfo propertyInfo = currentType.GetProperty(	"Emit", 
													BindingFlags.Instance 
													| BindingFlags.NonPublic
													| BindingFlags.DeclaredOnly );
				if (propertyInfo == null) {
					currentType = currentType.BaseType;
					continue;
				}
				
				Type iface = propertyInfo.PropertyType;
				MethodInfo[] mis = iface.GetMethods();
				
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
				
				currentType = currentType.BaseType;
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
		
		public static Dictionary<PropertyInfo, CPPProperty> GetProperties(Type t) {
			Dictionary<PropertyInfo, CPPProperty> props = new Dictionary<PropertyInfo, CPPProperty>();
			
			foreach (PropertyInfo pi in t.GetProperties()) {
				if (IsSmokeClass(pi.DeclaringType)) continue;
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
		
		public static QMetaObject MakeMetaObject(Type t, QObject o) {
			if (t == null) return null;

			QMetaObject parentMeta = null;
			if (	!IsSmokeClass(t.BaseType)
					&& !metaObjects.TryGetValue(t.BaseType.Name, out parentMeta) ) 
			{
				// create QMetaObject
				parentMeta = MakeMetaObject(t.BaseType, o);
			}
			
			string className = t.Name;
			Dictionary<string, CPPMethod> slotTable;
			ICollection<CPPMethod> slots;
			
			if (classes.TryGetValue(className, out slotTable))
				slots = slotTable.Values;
			else {
				// build slot table
				slots = GetSlotSignatures(t).Values;
			}

			ICollection<CPPMethod> signals = GetSignalSignatures(t).Values;
			
			ICollection<CPPProperty> properties = GetProperties(t).Values;
			
			QyotoMetaData metaData = new QyotoMetaData(className, signals, slots, GetClassInfos(t), properties);
			GCHandle objHandle = GCHandle.Alloc(o);

			IntPtr metaObject;
			
			unsafe {
				fixed (byte* stringdata = metaData.StringData)
				fixed (uint* data = metaData.Data) {
					metaObject = make_metaObject(	(IntPtr)objHandle, 
													parentMeta == null ? (IntPtr) 0 : (IntPtr) GCHandle.Alloc(parentMeta),
												 	(IntPtr)stringdata, metaData.StringData.Length,
												 	(IntPtr)data, metaData.Data.Length );
				}
			}
      
			QMetaObject res = (QMetaObject)((GCHandle) metaObject).Target;
			((GCHandle) metaObject).Free();
			metaObjects.Add(t.Name, res);
			return res;
		}
		
		public static QMetaObject GetMetaObject(QObject o) {
			Type t = o.GetType();
			
			QMetaObject res;
			if (!metaObjects.TryGetValue(t.ToString(), out res)) {
				// create QMetaObject
				res = MakeMetaObject(t, o);
			}

			return res;
		}	
	}
	
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	class SmokeClass : Attribute
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
	class SmokeMethod : Attribute
	{
		public string name;
		public string argsSignature;
		public string mungedSignature;
		public int methodId = -1;

		public string Name {
			get {
				return name;
			}
		}
	
		public string ArgsSignature {
			get {
				return argsSignature;
			}
		}
	
		public string Signature {
			get {
				return name + argsSignature;
			}
		}

		public string MungedName {
			get {
				return name + mungedSignature;
			}
		}
	
		public SmokeMethod(string name, string argsSignature, string mungedSignature)
		{
			this.name = name;
			this.argsSignature = argsSignature;
			this.mungedSignature = mungedSignature;
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

