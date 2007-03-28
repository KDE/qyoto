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
		public static extern IntPtr ConstructPointerList();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddObjectToPointerList(IntPtr ptr, IntPtr obj);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr ConstructQListInt();
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void AddIntToQList(IntPtr ptr, int i);
		
		
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
		public static extern void InstallMapPointer(MapPointerFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallUnmapPointer(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallGetInstance(GetInstanceFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallCreateInstance(CreateInstanceFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeCustomSlot(InvokeCustomSlotFn callback);
		
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
		public static extern void InstallDictionaryToQMap(DictToMap callback);
#endregion
		
#region delegates
		public delegate IntPtr NoArgs();
		public delegate IntPtr GetIntPtr(IntPtr instance);
		public delegate void SetIntPtr(IntPtr instance, IntPtr ptr);
		public delegate void FromIntPtr(IntPtr ptr);
		public delegate void MapPointerFn(IntPtr instance, IntPtr ptr, bool createStrongReference);
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
		public delegate void AddIntObject(IntPtr hash, int key, IntPtr val);
		public delegate IntPtr DictToMap(IntPtr ptr, int type);
		public delegate IntPtr ConstructDict(string type1, string type2);
		public delegate void SetPropertyFn(IntPtr obj, string name, IntPtr variant);
#endregion
		
#region marshalling functions

		public static void FreeGCHandle(IntPtr handle) {
#if DEBUG
			DebugGCHandle.Free((GCHandle) handle);
#else
			((GCHandle) handle).Free();
#endif
		}
		
		public static IntPtr GetSmokeObject(IntPtr instancePtr) {
			if (((int) instancePtr) == 0) {
				return (IntPtr) 0;
			}

			Object instance = ((GCHandle) instancePtr).Target;
			Debug.Assert(instance != null);

			SmokeClassData data = GetSmokeClassData(instance.GetType());
			return (IntPtr) data.smokeObjectField.GetValue(instance);
		}
		
		public static void SetSmokeObject(IntPtr instancePtr, IntPtr smokeObjectPtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			Debug.Assert(instance != null);

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
		static private Dictionary<IntPtr, object> strongReferenceMap = new Dictionary<IntPtr, object>();

		// The key is an IntPtr corresponding to the address of the C++ instance,
		// and the value is a WeakReference to the C# instance.
		static private Dictionary<IntPtr, WeakReference> pointerMap = new Dictionary<IntPtr, WeakReference>();

		public static void MapPointer(IntPtr ptr, IntPtr instancePtr, bool createStrongReference) {
			Object instance = ((GCHandle) instancePtr).Target;
			WeakReference weakRef = new WeakReference(instance);
			pointerMap[ptr] = weakRef;
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
				Console.WriteLine("MapPointer() Creating weak reference 0x{0:x8} -> {1}", (int) ptr, instance);
			}
#endif
			if (createStrongReference) {
				strongReferenceMap[ptr] = instance;
#if DEBUG
				if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
					Console.WriteLine("MapPointer() Creating strong reference 0x{0:x8} -> {1}", (int) ptr, instance);
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
			if (strongReferenceMap.ContainsKey(ptr)) {
#if DEBUG
				if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0) {
					object reference;
					if (strongReferenceMap.TryGetValue(ptr, out reference)) {
						Console.WriteLine("UnmapPointer() Removing strong reference 0x{0:x8} -> {1}", (int) ptr, reference);
					}
				}
#endif
				strongReferenceMap.Remove(ptr);
			}
		}
		
		// If 'allInstances' is false then only return a result if the instance a custom subclass
		// of a Qyoto class and therefore could have custom slots or overriden methods
		public static IntPtr GetInstance(IntPtr ptr, bool allInstances) {
			WeakReference weakRef;
			if (!pointerMap.TryGetValue(ptr, out weakRef)) {
#if DEBUG
				if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0
						&& QDebug.debugLevel >= DebugLevel.Extensive ) 
				{
					Console.WriteLine("GetInstance() pointerMap[0x{0:x8}] == null", (int) ptr);
				}
#endif
				return (IntPtr) 0;
			}

			if (weakRef.IsAlive) {
#if DEBUG
				if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_GC) != 0
						&& QDebug.debugLevel >= DebugLevel.Extensive ) 
				{
					Console.WriteLine("GetInstance() weakRef.IsAlive 0x{0:x8} -> {1}", (int) ptr, weakRef.Target);
				}
#endif
				if (!allInstances && IsSmokeClass(weakRef.Target.GetType())) {
					return (IntPtr) 0;
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
				return (IntPtr) 0;
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
			Debug.Assert(	result.constructorInfo != null,
							"GetSmokeClassData(\"" + result.className + "\") constructor method missing" );

			Type klass = t;
			do {
				result.proxyCreator = klass.GetMethod("CreateProxy", BindingFlags.NonPublic 
															| BindingFlags.Instance
															| BindingFlags.DeclaredOnly);

				klass = klass.BaseType;
			} while (result.proxyCreator == null && klass != typeof(object));

			Debug.Assert(	result.proxyCreator != null, 
							"GetSmokeClassData(\"" + result.className + "\") no CreateProxy() found" );

			result.smokeObjectField = t.GetField(	"smokeObject", 
													BindingFlags.NonPublic 
													| BindingFlags.GetField
													| BindingFlags.Instance );

			return result;
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
			SmokeClassData data = GetSmokeClassData(Type.GetType(className));
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

		public static IntPtr ListToPointerList(IntPtr ptr) {
			object l = ((GCHandle) ptr).Target;
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
			Type[] generic = { Type.GetType(type) };
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
#endregion
		
#region Setup
		static private FromIntPtr freeGCHandle = new FromIntPtr(FreeGCHandle);

		static private GetIntPtr getSmokeObject = new GetIntPtr(GetSmokeObject);
		static private SetIntPtr setSmokeObject = new SetIntPtr(SetSmokeObject);
		
		static private MapPointerFn mapPointer = new MapPointerFn(MapPointer);
		static private FromIntPtr unmapPointer = new FromIntPtr(UnmapPointer);
		static private GetInstanceFn getInstance = new GetInstanceFn(GetInstance);
		
		static private GetIntPtr intPtrToCharStarStar = new GetIntPtr(IntPtrToCharStarStar);
		static private GetStringFromIntPtr intPtrToString = new GetStringFromIntPtr(IntPtrToString);
		static private GetIntPtrFromString intPtrFromString = new GetIntPtrFromString(IntPtrFromString);
		static private GetIntPtr intPtrToQString = new GetIntPtr(IntPtrToQString);
		static private GetIntPtr intPtrFromQString = new GetIntPtr(IntPtrFromQString);
		static private GetIntPtr stringBuilderToQString = new GetIntPtr(StringBuilderToQString);
		static private SetIntPtrFromCharStar stringBuilderFromQString = new SetIntPtrFromCharStar(StringBuilderFromQString);
		
		static private GetIntPtr stringListToQStringList = new GetIntPtr(StringListToQStringList);
		static private GetIntPtr listToPointerList = new GetIntPtr(ListToPointerList);
		static private GetIntPtr listIntToQListInt = new GetIntPtr(ListIntToQListInt);
		
		static private DictToMap dictionaryToQMap = new DictToMap(DictionaryToQMap);
		
		static private CreateListFn constructList = new CreateListFn(ConstructList);
		static private SetIntPtr addIntPtrToList = new SetIntPtr(AddIntPtrToList);
		static private AddInt addIntToListInt = new AddInt(AddIntToListInt);
		
		static private ConstructDict constructDictionary = new ConstructDict(ConstructDictionary);
		static private InvokeMethodFn addObjectObjectToDictionary = new InvokeMethodFn(AddObjectObjectToDictionary);
		static private AddIntObject addIntObjectToDictionary = new AddIntObject(AddIntObjectToDictionary);
		
		static private OverridenMethodFn overridenMethod = new OverridenMethodFn(SmokeInvocation.OverridenMethod);
		static private InvokeMethodFn invokeMethod = new InvokeMethodFn(SmokeInvocation.InvokeMethod);

		static private CreateInstanceFn createInstance = new CreateInstanceFn(CreateInstance);
		static private InvokeCustomSlotFn invokeCustomSlot = new InvokeCustomSlotFn(SmokeInvocation.InvokeCustomSlot);
		
		static private OverridenMethodFn getProperty = new OverridenMethodFn(GetProperty);
		static private SetPropertyFn setProperty = new SetPropertyFn(SetProperty);
		
		public static void SetUp() {
			InstallFreeGCHandle(freeGCHandle);

			InstallGetSmokeObject(getSmokeObject);
			InstallSetSmokeObject(setSmokeObject);
			
			InstallMapPointer(mapPointer);
			InstallUnmapPointer(unmapPointer);
			InstallGetInstance(getInstance);

			InstallIntPtrToCharStarStar(intPtrToCharStarStar);
			InstallIntPtrToCharStar(intPtrToString);
			InstallIntPtrFromCharStar(intPtrFromString);
			InstallIntPtrToQString(intPtrToQString);
			InstallIntPtrFromQString(intPtrFromQString);
			InstallStringBuilderToQString(stringBuilderToQString);
			InstallStringBuilderFromQString(stringBuilderFromQString);
			InstallConstructList(constructList);
			InstallStringListToQStringList(stringListToQStringList);
			InstallListToPointerList(listToPointerList);
			InstallListIntToQListInt(listIntToQListInt);
			InstallAddIntPtrToList(addIntPtrToList);
			InstallAddIntToListInt(addIntToListInt);

			InstallConstructDictionary(constructDictionary);
			InstallAddObjectObjectToDictionary(addObjectObjectToDictionary);
			InstallAddIntObjectToDictionary(addIntObjectToDictionary);
			
			InstallDictionaryToQMap(dictionaryToQMap);

			InstallOverridenMethod(overridenMethod);
			InstallInvokeMethod(invokeMethod);

			InstallCreateInstance(createInstance);
			InstallInvokeCustomSlot(invokeCustomSlot);
			
			InstallGetProperty(getProperty);
			InstallSetProperty(setProperty);
		}
#endregion

	}
}