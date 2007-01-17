namespace Qyoto {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Runtime.Remoting.Proxies;
	using System.Runtime.InteropServices;

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
		public static extern void InstallMapPointer(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallUnmapPointer(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallGetPointerObject(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallCreateInstance(CreateInstanceFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeCustomSlot(InvokeCustomSlotFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern bool InstallIsSmokeClass(IsSmokeClassFn callback);
		
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
		public static extern void InstallOverridenMethod(OverridenMethodFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallInvokeMethod(InvokeMethodFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallConstructArrayList(NoArgs callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallArrayListToQStringList(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallArrayListToPointerList(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallArrayListToQListInt(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntPtrToArrayList(SetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntToArrayList(AddInt callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern IntPtr InstallConstructHashtable(NoArgs callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddObjectObjectToHashtable(InvokeMethodFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallAddIntObjectToHashtable(AddIntObject callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void InstallHashtableToQMap(HashToMap callback);
#endregion
		
#region delegates
		public delegate IntPtr NoArgs();
		public delegate IntPtr GetIntPtr(IntPtr instance);
		public delegate void SetIntPtr(IntPtr instance, IntPtr ptr);
		public delegate void FromIntPtr(IntPtr ptr);
		public delegate IntPtr CreateInstanceFn(string className);
		public delegate void InvokeCustomSlotFn(IntPtr obj, string slot, IntPtr stack, IntPtr ret);
		public delegate bool IsSmokeClassFn(IntPtr obj);
		public delegate IntPtr GetIntPtrFromString(string str);
		public delegate string GetStringFromIntPtr(IntPtr ptr);
		public delegate IntPtr OverridenMethodFn(IntPtr instance, string method);
		public delegate void InvokeMethodFn(IntPtr instance, IntPtr method, IntPtr args);
		public delegate void AddInt(IntPtr obj, int i);
		public delegate void AddIntObject(IntPtr hash, int key, IntPtr val);
		public delegate IntPtr HashToMap(IntPtr ptr, int type);
#endregion
		
#region marshallung functions
		public static void FreeGCHandle(IntPtr handle) {
			((GCHandle) handle).Free();
		}
		
		public static IntPtr GetSmokeObject(object instance) {
			if (instance == null) {
				return (IntPtr) 0;
			}
			FieldInfo fieldInfo = instance.GetType().GetField(	"_smokeObject", 
															BindingFlags.NonPublic 
															| BindingFlags.GetField
															| BindingFlags.Instance );
			return (IntPtr) fieldInfo.GetValue(instance);
		}
		
		public static IntPtr GetSmokeObject(IntPtr instancePtr) {
			if (((int) instancePtr) == 0)
				return (IntPtr) 0;
			
			Object instance = ((GCHandle) instancePtr).Target;
			return GetSmokeObject(instance);
		}
		
		public static void SetSmokeObject(object instance, IntPtr smokeObjectPtr) {
			FieldInfo fieldInfo = instance.GetType().GetField(	"_smokeObject", 
															BindingFlags.NonPublic 
															| BindingFlags.GetField
															| BindingFlags.Instance );
			fieldInfo.SetValue(instance, smokeObjectPtr);
			return;
		}
		
		public static void SetSmokeObject(IntPtr instancePtr, IntPtr smokeObjectPtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			if (instance == null) {
				return;
			}
			SetSmokeObject(instance, smokeObjectPtr);
			return;
		}

		// The key is an IntPtr corresponding to the address of the C++ instance,
		// and the value is a WeakReference to the C# instance.
		static private Dictionary<IntPtr, WeakReference> pointerMap = new Dictionary<IntPtr, WeakReference>();

		public static void MapPointer(IntPtr ptr, IntPtr instancePtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			WeakReference weakRef = new WeakReference(instance);
			pointerMap[ptr] = weakRef;
		}
		
		public static void UnmapPointer(IntPtr ptr) {
			pointerMap.Remove(ptr);
		}
		
		public static IntPtr GetPointerObject(IntPtr ptr) {
//			Console.WriteLine("ENTER GetPointerObject() ptr: {0}", ptr);
			WeakReference weakRef;
			if (!pointerMap.TryGetValue(ptr, out weakRef)) {
//				Console.WriteLine("GetPointerObject() pointerMap[ptr] == null");
				return (IntPtr) 0;
			}

			if (weakRef == null) {
//				Console.WriteLine("GetPointerObject() weakRef zero");
				return (IntPtr) 0;
			} else if (weakRef.IsAlive) {
//				Console.WriteLine("GetPointerObject() weakRef.IsAlive");
				GCHandle instanceHandle = GCHandle.Alloc(weakRef.Target);
				return (IntPtr) instanceHandle;
			} else {
//				Console.WriteLine("GetPointerObject() weakRef dead");
				return (IntPtr) 0;
			}
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
		public static IntPtr CreateInstance(string className) {
			Type klass = Type.GetType(className);
#if DEBUG
			Console.WriteLine("ENTER CreateInstance className => {0}, {1}", className, klass);
#endif

			Type[] constructorParamTypes = new Type[1];
			constructorParamTypes[0] = typeof(Type);
			ConstructorInfo constructorInfo = klass.GetConstructor(BindingFlags.NonPublic 
					| BindingFlags.Instance, null, new Type[ ] { typeof( Type ) } , null);
			if (constructorInfo == null) {
				Console.WriteLine("CreateInstance(\"{0}\") constructor method missing {1}", className, constructorParamTypes[0]);
				return (IntPtr) 0;
			}
			object result = constructorInfo.Invoke(new object [] { constructorParamTypes[0] });
#if DEBUG
			Console.WriteLine("CreateInstance(\"{0}\") constructed {1}", className, result);
#endif
			Type[] paramTypes = new Type[0];
			MethodInfo proxyCreator = klass.GetMethod("CreateProxy", BindingFlags.NonPublic 
																	| BindingFlags.Instance
																	| BindingFlags.DeclaredOnly);
			if (proxyCreator == null) {
				Console.WriteLine("CreateInstance() proxyCreator method missing");
				return (IntPtr) 0;
			}
			proxyCreator.Invoke(result, null);
			return (IntPtr) GCHandle.Alloc(result);
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
			return (IntPtr) GCHandle.Alloc(str);
		}

		public static IntPtr IntPtrToQString(IntPtr ptr) {
			string temp = (string) ((GCHandle) ptr).Target;
			return StringToQString(temp);
		}

		public static IntPtr IntPtrFromQString(IntPtr ptr) {
			return (IntPtr) GCHandle.Alloc(StringFromQString(ptr));
		}

		public static IntPtr ArrayListToQStringList(IntPtr ptr) {
			ArrayList al = (ArrayList) ((GCHandle) ptr).Target;
			string[] s = (string[]) al.ToArray();
			return StringArrayToQStringList(s.Length, s);
		}

		public static IntPtr ArrayListToQListInt(IntPtr ptr) {
			ArrayList al = (ArrayList) ((GCHandle) ptr).Target;
			IntPtr QList = ConstructQListInt();
			foreach (int i in al) {
				AddIntToQList(QList, i);
			}
			return QList;
		}

		public static IntPtr ArrayListToPointerList(IntPtr ptr) {
			ArrayList al = (ArrayList) ((GCHandle) ptr).Target;
			IntPtr list = ConstructPointerList();
			foreach (object o in al) {
				AddObjectToPointerList(list, (IntPtr) GCHandle.Alloc(o));
			}
			return list;
		}

		public static IntPtr ConstructArrayList() {
			ArrayList al = new ArrayList();
			return (IntPtr) GCHandle.Alloc(al);
		}

		public static void AddIntPtrToArrayList(IntPtr obj, IntPtr ptr) {
			object o = ((GCHandle) ptr).Target;
			ArrayList al = (ArrayList) ((GCHandle) obj).Target;
			al.Add(o);
		}

		public static void AddIntToArrayList(IntPtr obj, int i) {
			ArrayList al = (ArrayList) ((GCHandle) obj).Target;
			al.Add(i);
		}

		public static IntPtr ConstructHashtable() {
			Hashtable hash = new Hashtable();
			return (IntPtr) GCHandle.Alloc(hash);
		}

		public static void AddObjectObjectToHashtable(IntPtr hash, IntPtr key, IntPtr val) {
			Hashtable h = (Hashtable) ((GCHandle) hash).Target;
			object k = ((GCHandle) key).Target;
			object v = ((GCHandle) val).Target;
			h.Add(k, v);
		}

		public static void AddIntObjectToHashtable(IntPtr hash, int key, IntPtr val) {
			Hashtable h = (Hashtable) ((GCHandle) hash).Target;
			object v = ((GCHandle) val).Target;
			h.Add(key, v);
		}

		public static IntPtr HashtableToQMap(IntPtr hash, int type) {
			Hashtable h = (Hashtable) ((GCHandle) hash).Target;
			IntPtr map = ConstructQMap(type);
			
			if (type == 0) {
				foreach (DictionaryEntry de in h) {
					AddIntQVariantToQMap(map, (int) de.Key, (IntPtr) GCHandle.Alloc(de.Value));
				}
			} else if (type == 1) {
				foreach (DictionaryEntry de in h) {
					AddQStringQStringToQMap(map, (string) de.Key, (string) de.Value);
				}
			} else if (type == 2) {
				foreach (DictionaryEntry de in h) {
					AddQStringQVariantToQMap(map, (string) de.Key, (IntPtr) GCHandle.Alloc(de.Value));
				}
			}
			return map;
		}
#endregion
		
#region Setup
		static private FromIntPtr freeGCHandle = new FromIntPtr(FreeGCHandle);

		static private GetIntPtr getSmokeObject = new GetIntPtr(GetSmokeObject);
		static private SetIntPtr setSmokeObject = new SetIntPtr(SetSmokeObject);
		
		static private SetIntPtr mapPointer = new SetIntPtr(MapPointer);
		static private FromIntPtr unmapPointer = new FromIntPtr(UnmapPointer);
		static private GetIntPtr getPointerObject = new GetIntPtr(GetPointerObject);
		
		static private GetIntPtr intPtrToCharStarStar = new GetIntPtr(IntPtrToCharStarStar);
		static private GetStringFromIntPtr intPtrToString = new GetStringFromIntPtr(IntPtrToString);
		static private GetIntPtrFromString intPtrFromString = new GetIntPtrFromString(IntPtrFromString);
		static private GetIntPtr intPtrToQString = new GetIntPtr(IntPtrToQString);
		static private GetIntPtr intPtrFromQString = new GetIntPtr(IntPtrFromQString);
		
		static private GetIntPtr arrayListToQStringList = new GetIntPtr(ArrayListToQStringList);
		static private GetIntPtr arrayListToPointerList = new GetIntPtr(ArrayListToPointerList);
		static private GetIntPtr arrayListToQListInt = new GetIntPtr(ArrayListToQListInt);
		static private HashToMap hashtableToQMap = new HashToMap(HashtableToQMap);
		
		static private NoArgs constructArrayList = new NoArgs(ConstructArrayList);
		static private SetIntPtr addIntPtrToArrayList = new SetIntPtr(AddIntPtrToArrayList);
		static private AddInt addIntToArrayList = new AddInt(AddIntToArrayList);
		
		static private NoArgs constructHashtable = new NoArgs(ConstructHashtable);
		static private InvokeMethodFn addObjectObjectToHashtable = new InvokeMethodFn(AddObjectObjectToHashtable);
		static private AddIntObject addIntObjectToHashtable = new AddIntObject(AddIntObjectToHashtable);
		
		static private OverridenMethodFn overridenMethod = new OverridenMethodFn(SmokeInvocation.OverridenMethod);
		static private InvokeMethodFn invokeMethod = new InvokeMethodFn(SmokeInvocation.InvokeMethod);

		static private CreateInstanceFn createInstance = new CreateInstanceFn(CreateInstance);
		static private InvokeCustomSlotFn invokeCustomSlot = new InvokeCustomSlotFn(SmokeInvocation.InvokeCustomSlot);
		static private IsSmokeClassFn isSmokeClass = new IsSmokeClassFn(Qyoto.IsSmokeClass);
		
		public static void SetUp() {
			InstallFreeGCHandle(freeGCHandle);

			InstallGetSmokeObject(getSmokeObject);
			InstallSetSmokeObject(setSmokeObject);
			
			InstallMapPointer(mapPointer);
			InstallUnmapPointer(unmapPointer);
			InstallGetPointerObject(getPointerObject);

			InstallIntPtrToCharStarStar(intPtrToCharStarStar);
			InstallIntPtrToCharStar(intPtrToString);
			InstallIntPtrFromCharStar(intPtrFromString);
			InstallIntPtrToQString(intPtrToQString);
			InstallIntPtrFromQString(intPtrFromQString);
			InstallConstructArrayList(constructArrayList);
			InstallArrayListToQStringList(arrayListToQStringList);
			InstallArrayListToPointerList(arrayListToPointerList);
			InstallArrayListToQListInt(arrayListToQListInt);
			InstallAddIntPtrToArrayList(addIntPtrToArrayList);
			InstallAddIntToArrayList(addIntToArrayList);

			InstallConstructHashtable(constructHashtable);
			InstallAddObjectObjectToHashtable(addObjectObjectToHashtable);
			InstallAddIntObjectToHashtable(addIntObjectToHashtable);
			InstallHashtableToQMap(hashtableToQMap);

			InstallOverridenMethod(overridenMethod);
			InstallInvokeMethod(invokeMethod);

			InstallCreateInstance(createInstance);
			InstallInvokeCustomSlot(invokeCustomSlot);
			InstallIsSmokeClass(isSmokeClass);
		}
#endregion

	}
}