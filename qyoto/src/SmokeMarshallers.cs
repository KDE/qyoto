/***************************************************************************
                          SmokeMarshallers.cs  -  description
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

namespace Qyoto {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Reflection;
	using System.Runtime.Remoting.Proxies;
	using System.Runtime.InteropServices;
	using System.Text;

	public class SmokeMarshallers : object {
		
#region C++ functions
		/** Marshalling functions begin **/
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr StringArrayToCharStarStar(int length, string[] strArray);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr StringToQString(string str);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern string StringFromQString(IntPtr ptr);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr StringArrayToQStringList(int length, string[] strArray);
		/** Marshalling functions end **/
		
		/** Other functions **/
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern int SizeOfLong();

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructPointerList();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddObjectToPointerList(IntPtr ptr, IntPtr obj);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQListInt();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddIntToQList(IntPtr ptr, int i);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQListQRgb();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddUIntToQListQRgb(IntPtr ptr, uint i);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQListWizardButton();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddWizardButtonToQList(IntPtr ptr, int i);
		
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQHash(int type);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddIntQVariantToQHash(IntPtr ptr, int i, IntPtr qv);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddQStringQStringToQHash(IntPtr ptr, string str1, string str2);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddQStringQVariantToQHash(IntPtr ptr, string str, IntPtr qv);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQMap(int type);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddIntQVariantToQMap(IntPtr ptr, int i, IntPtr qv);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddQStringQStringToQMap(IntPtr ptr, string str1, string str2);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddQStringQVariantToQMap(IntPtr ptr, string str, IntPtr qv);
		/** Other functions end **/
		
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallFreeGCHandle(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallGetSmokeObject(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallSetSmokeObject(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddGlobalRef(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallRemoveGlobalRef(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallMapPointer(MapPointerFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallUnmapPointer(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallGetInstance(GetInstanceFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallCreateInstance(CreateInstanceFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeCustomSlot(InvokeCustomSlotFn callback);
		
		[DllImport("libqyotoshared", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeDelegate(InvokeDelegateFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern bool InstallGetProperty(OverridenMethodFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern bool InstallSetProperty(SetPropertyFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallIntPtrToCharStarStar(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallIntPtrToCharStar(GetStringFromIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallIntPtrFromCharStar(GetIntPtrFromString callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallIntPtrToQString(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallIntPtrFromQString(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallStringBuilderToQString(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallStringBuilderFromQString(SetIntPtrFromCharStar callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallOverridenMethod(OverridenMethodFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeMethod(InvokeMethodFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallConstructList(CreateListFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallStringListToQStringList(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallListToPointerList(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallListIntToQListInt(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallListUIntToQListQRgb(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallListWizardButtonToQListWizardButton(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntPtrToList(SetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntToListInt(AddInt callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallConstructDictionary(ConstructDict callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddObjectObjectToDictionary(InvokeMethodFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntObjectToDictionary(AddIntObject callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallDictionaryToQHash(DictToHash callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallDictionaryToQMap(DictToMap callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddUIntToListUInt(AddUInt callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallGenericPointerGetIntPtr(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallCreateGenericPointer(CreateInstanceFn callback);

		[DllImport("libqyotoshared", CharSet=CharSet.Ansi)]
		public static extern void InstallTryDispose(FromIntPtr callback);
#endregion
		
#region delegates
		public delegate IntPtr NoArgs();
		public delegate IntPtr GetIntPtr(IntPtr instance);
		public delegate void SetIntPtr(IntPtr instance, IntPtr ptr);
		public delegate void FromIntPtr(IntPtr ptr);
		public delegate void MapPointerFn(IntPtr instance, IntPtr ptr, bool createGlobalReference);
		public delegate IntPtr CreateListFn(string className);
		public delegate IntPtr CreateInstanceFn(string className, IntPtr smokeObjectPtr);
		public delegate IntPtr GetInstanceFn(IntPtr ptr, bool allInstances);
		public delegate void InvokeCustomSlotFn(IntPtr obj, string slot, IntPtr stack, IntPtr ret);
		public delegate IntPtr GetIntPtrFromString(string str);
		public delegate string GetStringFromIntPtr(IntPtr ptr);
		public delegate void SetIntPtrFromCharStar(IntPtr ptr, string str);
		public delegate IntPtr OverridenMethodFn(IntPtr instance, string method);
		public delegate void InvokeMethodFn(IntPtr instance, IntPtr method, IntPtr args);
		public delegate void AddInt(IntPtr obj, int i);
		public delegate void AddUInt(IntPtr obj, uint i);
		public delegate void AddIntObject(IntPtr hash, int key, IntPtr val);
		public delegate IntPtr DictToHash(IntPtr ptr, int type);
		public delegate IntPtr DictToMap(IntPtr ptr, int type);
		public delegate IntPtr ConstructDict(string type1, string type2);
		public delegate void SetPropertyFn(IntPtr obj, string name, IntPtr variant);
		public delegate void InvokeDelegateFn(Delegate d, IntPtr stack);
#endregion
		
#region marshalling functions

		public static int SizeOfNativeLong = SizeOfLong();

		public static void FreeGCHandle(IntPtr handle) {
			if (handle == IntPtr.Zero) {
				Console.WriteLine("In FreeGCHandle(IntPtr): handle == 0 - This should not happen!");
				return;
			}
#if DEBUG
			DebugGCHandle.Free((GCHandle) handle);
#else
			((GCHandle) handle).Free();
#endif
		}
		
		public static IntPtr GetSmokeObject(IntPtr instancePtr) {
			if (instancePtr == IntPtr.Zero) {
				return IntPtr.Zero;
			}

			Object instance = ((GCHandle) instancePtr).Target;
//			Debug.Assert(instance != null);

			SmokeClassData data = GetSmokeClassData(instance.GetType());
			return (IntPtr) data.smokeObjectField.GetValue(instance);
		}
		
		public static void SetSmokeObject(IntPtr instancePtr, IntPtr smokeObjectPtr) {
			Object instance = ((GCHandle) instancePtr).Target;
// 			Debug.Assert(instance != null);

			SmokeClassData data = GetSmokeClassData(instance.GetType());
			data.smokeObjectField.SetValue(instance, smokeObjectPtr);
			return;
		}
		
		public static IntPtr GetProperty(IntPtr obj, string propertyName) {
			object o = ((GCHandle) obj).Target;
			Type t = o.GetType();
			PropertyInfo pi = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic |
									BindingFlags.Instance | BindingFlags.Static);
			
			MethodInfo fromValue = typeof(QVariant).GetMethod("FromValue", BindingFlags.Public | BindingFlags.Static);
			if (fromValue == null) throw new Exception("Couldn't find QVariant.FromValue<T> method");
			fromValue = fromValue.MakeGenericMethod( new Type[]{ pi.PropertyType } );

			if (pi != null) {
				object value = pi.GetValue(o, null);
				object[] args = { value };
				QVariant variant = (QVariant) fromValue.Invoke(null, args);
#if DEBUG
				return (IntPtr) DebugGCHandle.Alloc(variant);
#else
				return (IntPtr) GCHandle.Alloc(variant);
#endif
			}
			
			return (IntPtr) 0;
		}
		
		public static void SetProperty(IntPtr obj, string propertyName, IntPtr variant) {
			object o = ((GCHandle) obj).Target;
			Type t = o.GetType();
			object v = ((GCHandle) variant).Target;
			PropertyInfo pi = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic |
									BindingFlags.Instance | BindingFlags.Static);
									
			MethodInfo value = typeof(QVariant).GetMethod("Value", BindingFlags.Public | BindingFlags.Instance);
			if (value == null) throw new Exception("Couldn't find QVariant.Value<T> method");
			value = value.MakeGenericMethod( new Type[]{ pi.PropertyType } );

			if (pi != null) {
				object ret = value.Invoke(v, null);
				pi.SetValue(o, ret, null);
			}
		}

		// The key is an IntPtr corresponding to the address of the C++ instance,
		// and the value is the C# instance. This is used to prevent garbage
		// collection for instances which are contained inside, and owned by
		// other instances. For instance, a QObject can have a parent which will
		// delete the child when it is deleted. This Dictionary will prevent the
		// child from being GCd even if there are no references to it in the Qyoto
		// application code.
		static private Dictionary<IntPtr, object> globalReferenceMap = new Dictionary<IntPtr, object>();

		// The key is an IntPtr corresponding to the address of the C++ instance,
		// and the value is a WeakReference to the C# instance.
		
		// temporarily use a hashtable since Mono's Dictionary implementation seems buggy. And why do we fix the
		// capacity to 2179?
// 		static private Dictionary<IntPtr, WeakReference> pointerMap = new Dictionary<IntPtr, WeakReference>(2179);
		static private Hashtable pointerMap = new Hashtable();

		public static void AddGlobalRef(IntPtr instancePtr, IntPtr ptr) {
			Object instance = ((GCHandle) instancePtr).Target;
			globalReferenceMap[ptr] = instance;
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
				Console.WriteLine("AddGlobalRef() Creating global reference 0x{0:x8} -> {1}", (int) ptr, instance);
			}
#endif
		}

		public static void RemoveGlobalRef(IntPtr instancePtr, IntPtr ptr) {
			Object instance = ((GCHandle) instancePtr).Target;
			if (globalReferenceMap.ContainsKey(ptr)) {
#if DEBUG
				if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
					object reference;
					if (globalReferenceMap.TryGetValue(ptr, out reference)) {
						Console.WriteLine("RemoveGlobalRef() Removing global reference 0x{0:x8} -> {1}", (int) ptr, reference);
					}
				}
#endif
				globalReferenceMap.Remove(ptr);
			}
		}

		public static void MapPointer(IntPtr ptr, IntPtr instancePtr, bool createGlobalReference) {
			Object instance = ((GCHandle) instancePtr).Target;
			WeakReference weakRef = new WeakReference(instance);
			pointerMap[ptr] = weakRef;
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
				Console.WriteLine("MapPointer() Creating weak reference 0x{0:x8} -> {1}", (int) ptr, instance);
			}
#endif
			if (createGlobalReference) {
				globalReferenceMap[ptr] = instance;
#if DEBUG
				if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
					Console.WriteLine("MapPointer() Creating global reference 0x{0:x8} -> {1}", (int) ptr, instance);
				}
#endif
			}
		}
		
		public static void UnmapPointer(IntPtr ptr) {
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
				Console.WriteLine("UnmapPointer() Removing weak reference 0x{0:x8}", (int) ptr);
			}
#endif
			pointerMap.Remove(ptr);
			if (globalReferenceMap.ContainsKey(ptr)) {
#if DEBUG
				if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
					object reference;
					if (globalReferenceMap.TryGetValue(ptr, out reference)) {
						Console.WriteLine("UnmapPointer() Removing global reference 0x{0:x8} -> {1}", (int) ptr, reference);
					}
				}
#endif
				globalReferenceMap.Remove(ptr);
			}
		}
		
		// If 'allInstances' is false then only return a result if the instance a custom subclass
		// of a Qyoto class and therefore could have custom slots or overriden methods
		public static IntPtr GetInstance(IntPtr ptr, bool allInstances) {
			WeakReference weakRef;
			if (!pointerMap.ContainsKey(ptr)) {
#if DEBUG
				if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0
						&& QDebug.debugLevel >= DebugLevel.Extensive ) 
				{
					Console.WriteLine("GetInstance() pointerMap[0x{0:x8}] == null", (int) ptr);
				}
#endif
				return IntPtr.Zero;
			}

			weakRef = (WeakReference) pointerMap[ptr];

			if (weakRef.IsAlive) {
#if DEBUG
				if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0
						&& QDebug.debugLevel >= DebugLevel.Extensive ) 
				{
					Console.WriteLine("GetInstance() weakRef.IsAlive 0x{0:x8} -> {1}", (int) ptr, weakRef.Target);
				}
#endif
				if (!allInstances && IsSmokeClass(weakRef.Target.GetType())) {
					return IntPtr.Zero;
				} 

#if DEBUG
				GCHandle instanceHandle = DebugGCHandle.Alloc(weakRef.Target);
#else
				GCHandle instanceHandle = GCHandle.Alloc(weakRef.Target);
#endif
				return (IntPtr) instanceHandle;
			} else {
#if DEBUG
				if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0
						&& QDebug.debugLevel >= DebugLevel.Extensive ) 
				{
					Console.WriteLine("GetInstance() weakRef dead ptr: 0x{0:x8}", (int) ptr);
				}
#endif
				pointerMap.Remove(ptr);
				return IntPtr.Zero;
			}
		}

		private class SmokeClassData {
			public string className;
			public ConstructorInfo constructorInfo;
			public object[] constructorParamTypes;
			public MethodInfo proxyCreator;
			public FieldInfo smokeObjectField;
		}

		private static Dictionary<Type, SmokeClassData> smokeClassCache = new Dictionary<Type, SmokeClassData> ();
		
		private static SmokeClassData GetSmokeClassData(Type t) {
			SmokeClassData result = null;

			if (smokeClassCache.TryGetValue(t, out result)) {
				return result;
			}

			string className = null;

			object[] attr = t.GetCustomAttributes(typeof(SmokeClass), false);
			if (attr.Length > 0) {
				className = ((SmokeClass) attr[0]).signature;
			}

			result = new SmokeClassData();
			result.className = className;
			smokeClassCache[t] = result;

			if (t.IsInterface) {
				return result;
			}

			Type[] paramTypes = new Type[1];
			paramTypes[0] = typeof(Type);
			result.constructorParamTypes = new object[] { paramTypes[0] };

			result.constructorInfo = t.GetConstructor(BindingFlags.NonPublic 
				| BindingFlags.Instance, null, new Type[ ] { typeof( Type ) } , null);
//			Debug.Assert(	result.constructorInfo != null,
//							"GetSmokeClassData(\"" + result.className + "\") constructor method missing" );

			Type klass = t;
			do {
				result.proxyCreator = klass.GetMethod("CreateProxy", BindingFlags.NonPublic 
															| BindingFlags.Instance
															| BindingFlags.DeclaredOnly);

				klass = klass.BaseType;
			} while (result.proxyCreator == null && klass != typeof(object));

//			Debug.Assert(	result.proxyCreator != null, 
//							"GetSmokeClassData(\"" + result.className + "\") no CreateProxy() found" );

			result.smokeObjectField = GetPrivateFieldInfo(t, "smokeObject");

			return result;
		}

		public static FieldInfo GetPrivateFieldInfo(Type type, string name) {
			Type t = type;
			FieldInfo fi = null;
			while (t != typeof(object)) {
				fi = t.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
				if (fi != null) return fi;
				t = t.BaseType;
			}
			return null;
		}

		// The class is not a custom subclass of a Qyoto class, and also is not
		// a superclass of a Qyoto class, such as a MarshalByRefObject.
		public static bool IsSmokeClass(Type klass) {
			SmokeClassData data = GetSmokeClassData(klass);
			return data != null && data.className != null;
		}

		// The C++ class name signature of a Smoke class or interface
		public static string SmokeClassName(Type klass) {
			SmokeClassData data = GetSmokeClassData(klass);
			while (data.className == null) {
				klass = klass.BaseType;
				data = GetSmokeClassData(klass);
			}
			
			return data.className;
		}

		// CreateInstance() creates a wrapper instance around a C++ instance which
		// has been created in C++ code, and not via a Qyoto C# constructor call.
		// It takes the class name string and obtains its Type. Then it finds the
		// dummy constructor which takes a Type as an arg, like this for example:
		//
 		//		protected QWidget(Type dummy) : base((Type) null) {}
		//
		// The constructor is run to create the wrapper instance. Then the method 
		// 'CreateProxy()' to create the transparent proxy to forward the method
		// calls to SmokeInvocation.Invoke() is called.
		public static IntPtr CreateInstance(string className, IntPtr smokeObjectPtr) {
			SmokeClassData data = null;
			foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
				Type t = a.GetType(className);
				if (t != null)
					data = GetSmokeClassData(t);
			}

			if (data == null) {
				if (className.Contains(".")) {
					StringBuilder sb = new StringBuilder(className);
					sb[className.LastIndexOf(".")] = '+';
					return CreateInstance(sb.ToString(), smokeObjectPtr);
				}
				Console.Error.WriteLine("CreateInstance() ** Missing class ** {0}", className);
			}

			object result = data.constructorInfo.Invoke(data.constructorParamTypes);
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
				Console.WriteLine("CreateInstance(\"{0}\") constructed {1}", className, result);
			}
#endif
			data.proxyCreator.Invoke(result, null);
			data.smokeObjectField.SetValue(result, smokeObjectPtr);
#if DEBUG
			return (IntPtr) DebugGCHandle.Alloc(result);
#else
			return (IntPtr) GCHandle.Alloc(result);
#endif
		}

		public static IntPtr IntPtrToCharStarStar(IntPtr ptr) {
			string[] temp = (string[]) ((GCHandle) ptr).Target;
			return StringArrayToCharStarStar(temp.Length, temp);
		}

		public static string IntPtrToString(IntPtr ptr) {
			string temp = (string) ((GCHandle) ptr).Target;
			return temp;
		}

		public static IntPtr IntPtrFromString(string str) {
#if DEBUG
			return (IntPtr) DebugGCHandle.Alloc(str);
#else
			return (IntPtr) GCHandle.Alloc(str);
#endif
		}

		public static IntPtr IntPtrToQString(IntPtr ptr) {
			string temp = (string) ((GCHandle) ptr).Target;
			return StringToQString(temp);
		}

		public static IntPtr IntPtrFromQString(IntPtr ptr) {
#if DEBUG
			return (IntPtr) DebugGCHandle.Alloc(StringFromQString(ptr));
#else
			return (IntPtr) GCHandle.Alloc(StringFromQString(ptr));
#endif
		}

		public static IntPtr StringBuilderToQString(IntPtr ptr) {
			object obj = (object) ((GCHandle) ptr).Target;
			if (obj.GetType() == typeof(StringBuilder)) {
				return StringToQString(((StringBuilder) obj).ToString());
			} else {
				return StringToQString((string) obj);
			}
		}

		public static void StringBuilderFromQString(IntPtr ptr, string str) {
			object obj = (object) ((GCHandle) ptr).Target;
			if (obj.GetType() == typeof(StringBuilder)) {
				StringBuilder temp = (StringBuilder) obj;
				temp.Remove(0, temp.Length);
				temp.Append(str);
			}
		}

		public static IntPtr StringListToQStringList(IntPtr ptr) {
			List<string> sl = (List<string>) ((GCHandle) ptr).Target;
			string[] s = (string[]) sl.ToArray();
			return StringArrayToQStringList(s.Length, s);
		}

		public static IntPtr ListIntToQListInt(IntPtr ptr) {
			List<int> il = (List<int>) ((GCHandle) ptr).Target;
			IntPtr QList = ConstructQListInt();
			foreach (int i in il) {
				AddIntToQList(QList, i);
			}
			return QList;
		}

		public static IntPtr ListWizardButtonToQListWizardButton(IntPtr ptr) {
			List<QWizard.WizardButton> list = (List<QWizard.WizardButton>) ((GCHandle) ptr).Target;
			IntPtr QList = ConstructQListWizardButton();
			foreach (QWizard.WizardButton wb in list) {
				AddWizardButtonToQList(QList, (int) wb);
			}
			return QList;
		}
		
		public static IntPtr ListUIntToQListQRgb(IntPtr ptr) {
			List<uint> il = (List<uint>) ((GCHandle) ptr).Target;
			IntPtr QList = ConstructQListQRgb();
			foreach (uint i in il) {
				AddUIntToQListQRgb(QList, i);
			}
			return QList;
		}

		public static void AddUIntToListUInt(IntPtr ptr, uint i) {
			List<uint> il = (List<uint>) ((GCHandle) ptr).Target;
			il.Add(i);
		}

		public static IntPtr ListToPointerList(IntPtr ptr) {
			if (ptr.ToInt64() < 0) {
				Console.WriteLine("The IntPtr is invalid!");
				return IntPtr.Zero;
			}
			object l;
			try {
				l = ((GCHandle) ptr).Target;
			} catch (Exception e) {
				Console.WriteLine("An error occured when retrieving the target: {0}", e);
				return ConstructPointerList();
			}
			// convert the list to an array via reflection. this is probably the easiest way
			object[] oa = (object[]) l.GetType().GetMethod("ToArray").Invoke(l, null);
			
			IntPtr list = ConstructPointerList();
			foreach (object o in oa) {
#if DEBUG
				AddObjectToPointerList(list, (IntPtr) DebugGCHandle.Alloc(o));
#else
				AddObjectToPointerList(list, (IntPtr) GCHandle.Alloc(o));
#endif
			}
			return list;
		}

		public static IntPtr ConstructList(string type) {
			Type basetype = typeof(List<>);
			Type t = null;
			foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
				t = a.GetType(type);
				if (t != null) {
					break;
				}
			}

			// check for multiple inheritance - use the interface if necessary
			string ifacename = "I" + t.Name;
			foreach(Type iface in t.GetInterfaces()) {
				if (iface.Name == ifacename) {
					t = iface;
					break;
				}
			}

			Type[] generic = { t };
			Type merged = basetype.MakeGenericType(generic);
			
			object o = Activator.CreateInstance(merged);
#if DEBUG		
			return (IntPtr) DebugGCHandle.Alloc(o);
#else
			return (IntPtr) GCHandle.Alloc(o);
#endif
		}

		public static void AddIntPtrToList(IntPtr obj, IntPtr ptr) {
			object list = ((GCHandle) obj).Target;
			object o = ((GCHandle) ptr).Target;
			object[] args = { o };
			list.GetType().GetMethod("Add").Invoke(list, args);
		}

		public static void AddIntToListInt(IntPtr obj, int i) {
			List<int> il = (List<int>) ((GCHandle) obj).Target;
			il.Add(i);
		}

		public static IntPtr ConstructDictionary(string type1, string type2) {
			Type basetype = typeof(Dictionary<,>);
			Type[] generic = { Type.GetType(type1), Type.GetType(type2) };
			Type merged = basetype.MakeGenericType(generic);
			
			object o = Activator.CreateInstance(merged);

#if DEBUG
			return (IntPtr) DebugGCHandle.Alloc(o);
#else
			return (IntPtr) GCHandle.Alloc(o);
#endif
		}

		public static void AddObjectObjectToDictionary(IntPtr dic, IntPtr key, IntPtr val) {
			object d = ((GCHandle) dic).Target;
			object k = ((GCHandle) key).Target;
			object v = ((GCHandle) val).Target;
			object[] args = { k, v };
			d.GetType().GetMethod("Add").Invoke(d, args);
		}

		public static void AddIntObjectToDictionary(IntPtr dict, int key, IntPtr val) {
			object d = ((GCHandle) dict).Target;
			object v = ((GCHandle) val).Target;
			object[] args = { key, v };
			d.GetType().GetMethod("Add").Invoke(d, args);
		}

		public static IntPtr DictionaryToQHash(IntPtr dict, int type) {
			object d = ((GCHandle) dict).Target;
			IntPtr hash = ConstructQHash(type);
			
			if (type == 0) {
				Dictionary<int, QVariant> d1 = (Dictionary<int, QVariant>) d;
				foreach (KeyValuePair<int, QVariant> kvp in d1) {
#if DEBUG
					AddIntQVariantToQHash(hash, kvp.Key, (IntPtr) DebugGCHandle.Alloc(kvp.Value));
#else
					AddIntQVariantToQHash(hash, kvp.Key, (IntPtr) GCHandle.Alloc(kvp.Value));
#endif
				}
			} else if (type == 1) {
				Dictionary<string, string> d1 = (Dictionary<string, string>) d;
				foreach (KeyValuePair<string, string> kvp in d1) {
					AddQStringQStringToQHash(hash, kvp.Key, kvp.Value);
				}
			} else if (type == 2) {
				Dictionary<string, QVariant> d1 = (Dictionary<string, QVariant>) d;
				foreach (KeyValuePair<string, QVariant> kvp in d1) {
#if DEBUG
					AddQStringQVariantToQHash(hash, kvp.Key, (IntPtr) DebugGCHandle.Alloc(kvp.Value));
#else
					AddQStringQVariantToQHash(hash, kvp.Key, (IntPtr) GCHandle.Alloc(kvp.Value));
#endif
				}
			}
			return hash;
		}		

		public static IntPtr DictionaryToQMap(IntPtr dict, int type) {
			object d = ((GCHandle) dict).Target;
			IntPtr map = ConstructQMap(type);
			
			if (type == 0) {
				Dictionary<int, QVariant> d1 = (Dictionary<int, QVariant>) d;
				foreach (KeyValuePair<int, QVariant> kvp in d1) {
#if DEBUG
					AddIntQVariantToQMap(map, kvp.Key, (IntPtr) DebugGCHandle.Alloc(kvp.Value));
#else
					AddIntQVariantToQMap(map, kvp.Key, (IntPtr) GCHandle.Alloc(kvp.Value));
#endif
				}
			} else if (type == 1) {
				Dictionary<string, string> d1 = (Dictionary<string, string>) d;
				foreach (KeyValuePair<string, string> kvp in d1) {
					AddQStringQStringToQMap(map, kvp.Key, kvp.Value);
				}
			} else if (type == 2) {
				Dictionary<string, QVariant> d1 = (Dictionary<string, QVariant>) d;
				foreach (KeyValuePair<string, QVariant> kvp in d1) {
#if DEBUG
					AddQStringQVariantToQMap(map, kvp.Key, (IntPtr) DebugGCHandle.Alloc(kvp.Value));
#else
					AddQStringQVariantToQMap(map, kvp.Key, (IntPtr) GCHandle.Alloc(kvp.Value));
#endif
				}
			}
			return map;
		}
		
		public static IntPtr GenericPointerGetIntPtr(IntPtr obj) {
			object o = ((GCHandle) obj).Target;
			return (IntPtr) o.GetType().GetMethod("ToIntPtr").Invoke(o, null);
		}
		
		public static IntPtr CreateGenericPointer(string type, IntPtr ptr) {
			Type t = typeof(Pointer<>);
			t = t.MakeGenericType( new Type[] { Type.GetType(type) } );
			object o = Activator.CreateInstance(t, new object[] { ptr });
			return (IntPtr) GCHandle.Alloc(o);
		}
		
		public static void TryDispose(IntPtr obj) {
			object o = ((GCHandle) obj).Target;
			Type t = o.GetType();
			MethodInfo mi = t.GetMethod("Dispose");
			if (mi == null) return;
			if (IsSmokeClass(mi.DeclaringType)) return;
			((IDisposable) o).Dispose();
		}
#endregion
		
#region Setup
		public static void SetUp() {
			InstallFreeGCHandle(FreeGCHandle);

			InstallGetSmokeObject(GetSmokeObject);
			InstallSetSmokeObject(SetSmokeObject);
			
			InstallAddGlobalRef(AddGlobalRef);
			InstallRemoveGlobalRef(RemoveGlobalRef);
			InstallMapPointer(MapPointer);
			InstallUnmapPointer(UnmapPointer);
			InstallGetInstance(GetInstance);

			InstallIntPtrToCharStarStar(IntPtrToCharStarStar);
			InstallIntPtrToCharStar(IntPtrToString);
			InstallIntPtrFromCharStar(IntPtrFromString);
			InstallIntPtrToQString(IntPtrToQString);
			InstallIntPtrFromQString(IntPtrFromQString);
			InstallStringBuilderToQString(StringBuilderToQString);
			InstallStringBuilderFromQString(StringBuilderFromQString);
			InstallConstructList(ConstructList);
			InstallStringListToQStringList(StringListToQStringList);
			InstallListToPointerList(ListToPointerList);
			InstallListIntToQListInt(ListIntToQListInt);
			InstallListUIntToQListQRgb(ListUIntToQListQRgb);
			InstallListWizardButtonToQListWizardButton(ListWizardButtonToQListWizardButton);
			InstallAddIntPtrToList(AddIntPtrToList);
			InstallAddIntToListInt(AddIntToListInt);
			InstallAddUIntToListUInt(AddUIntToListUInt);

			InstallConstructDictionary(ConstructDictionary);
			InstallAddObjectObjectToDictionary(AddObjectObjectToDictionary);
			InstallAddIntObjectToDictionary(AddIntObjectToDictionary);
			
			InstallDictionaryToQHash(DictionaryToQHash);
			InstallDictionaryToQMap(DictionaryToQMap);

			InstallOverridenMethod(SmokeInvocation.OverridenMethod);
			InstallInvokeMethod(SmokeInvocation.InvokeMethod);

			InstallCreateInstance(CreateInstance);
			InstallInvokeCustomSlot(SmokeInvocation.InvokeCustomSlot);
			InstallInvokeDelegate(SmokeInvocation.InvokeDelegate);
			
			InstallGetProperty(GetProperty);
			InstallSetProperty(SetProperty);
			
			InstallGenericPointerGetIntPtr(GenericPointerGetIntPtr);
			InstallCreateGenericPointer(CreateGenericPointer);
			
			InstallTryDispose(TryDispose);
		}
#endregion

	}
}