/***************************************************************************
                          SmokeInvocation.cs  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale
    email                : Richard_Dale@tipitina.demon.co.uk
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

// #define DEBUG

namespace Qyoto {

	using Qyoto;
	
	using System;
	using System.Collections;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Reflection;
	using System.Runtime.Remoting.Proxies;
	using System.Runtime.Remoting.Messaging;
	using System.Runtime.Remoting;
	using System.Runtime.InteropServices;

	[StructLayout(LayoutKind.Explicit)]
	unsafe public struct StackItem {
		[FieldOffset(0)] public void * s_voidp;
		[FieldOffset(0)] public bool s_bool;
		[FieldOffset(0)] public sbyte s_char;
		[FieldOffset(0)] public byte s_uchar;
		[FieldOffset(0)] public short s_short;
		[FieldOffset(0)] public ushort s_ushort;
		[FieldOffset(0)] public int s_int;
		[FieldOffset(0)] public uint s_uint;
		[FieldOffset(0)] public long s_long;
		[FieldOffset(0)] public ulong s_ulong;
		[FieldOffset(0)] public float s_float;
		[FieldOffset(0)] public double s_double;
        [FieldOffset(0)] public long s_enum;
		[FieldOffset(0)] public IntPtr s_class;
	}
	
	public class SmokeInvocation : RealProxy {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int FindMethodId(string className, string methodName);
			
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int MethodFromMap(int methodId);
			
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int FindAmbiguousMethodId(int ambigousId);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void CallSmokeMethod(int methodId, IntPtr target, IntPtr sp, int items);
		
		delegate IntPtr GetIntPtr(IntPtr instance);
		delegate void SetIntPtr(IntPtr instance, IntPtr ptr);
		delegate void FromIntPtr(IntPtr ptr);
		delegate IntPtr CreateInstanceFn(string className);
		delegate void InvokeCustomSlotFn(IntPtr obj, string slot, IntPtr stack, IntPtr ret);
		delegate bool IsSmokeClassFn(IntPtr obj);
		delegate IntPtr GetIntPtrFromString(string str);
		delegate string GetStringFromIntPtr(IntPtr ptr);
		delegate IntPtr OverridenMethodFn(IntPtr instance, string method);
		delegate void InvokeMethodFn(IntPtr instance, IntPtr method, IntPtr args);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr StringArrayToCharStarStar(int length, string[] strArray);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr StringToQString(string str);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern string StringFromQString(IntPtr ptr);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddFreeGCHandle(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddGetSmokeObject(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddSetSmokeObject(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddMapPointer(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddUnmapPointer(FromIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddGetPointerObject(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddCreateInstance(CreateInstanceFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddInvokeCustomSlot(InvokeCustomSlotFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern bool AddIsSmokeClass(IsSmokeClassFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddIntPtrToCharStarStar(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddIntPtrToCharStar(GetStringFromIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddIntPtrFromCharStar(GetIntPtrFromString callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddIntPtrToQString(GetIntPtr callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddIntPtrFromQString(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddOverridenMethod(OverridenMethodFn callback);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddInvokeMethod(InvokeMethodFn callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int qt_metacall(IntPtr obj, int _c, int _id, IntPtr a);
		
		static void FreeGCHandle(IntPtr handle) {
			((GCHandle) handle).Free();
		}

		static IntPtr GetSmokeObject(IntPtr instancePtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			if (instance == null) {
				return (IntPtr) 0;
			}
			FieldInfo fieldInfo = instance.GetType().GetField(	"_smokeObject", 
															BindingFlags.NonPublic 
															| BindingFlags.GetField
															| BindingFlags.Instance );
			return (IntPtr) fieldInfo.GetValue(instance);
		}
		
		static void SetSmokeObject(IntPtr instancePtr, IntPtr smokeObjectPtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			if (instance == null) {
				return;
			}
			FieldInfo fieldInfo = instance.GetType().GetField(	"_smokeObject", 
															BindingFlags.NonPublic 
															| BindingFlags.GetField
															| BindingFlags.Instance );
			fieldInfo.SetValue(instance, smokeObjectPtr);
			return;
		}

		// The key is an IntPtr corresponding to the address of the C++ instance,
		// and the value is a WeakReference to the C# instance.
		static private Hashtable pointerMap = new Hashtable();

		static void MapPointer(IntPtr ptr, IntPtr instancePtr) {
			Object instance = ((GCHandle) instancePtr).Target;
			WeakReference weakRef = new WeakReference(instance);
			pointerMap[ptr] = weakRef;
		}
		
		static void UnmapPointer(IntPtr ptr) {
			pointerMap.Remove(ptr);
		}
		
		static IntPtr GetPointerObject(IntPtr ptr) {
//			Console.WriteLine("ENTER GetPointerObject() ptr: {0}", ptr);
			if (pointerMap[ptr] == null) {
//				Console.WriteLine("GetPointerObject() pointerMap[ptr] == null");
				return (IntPtr) 0;
			}

			WeakReference weakRef = (WeakReference) pointerMap[ptr];
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
		static IntPtr CreateInstance(string className) {
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

		static IntPtr IntPtrToCharStarStar(IntPtr ptr) {
			string[] temp = (string[]) ((GCHandle) ptr).Target;
			return StringArrayToCharStarStar(temp.Length, temp);
		}

		static string IntPtrToString(IntPtr ptr) {
			string temp = (string) ((GCHandle) ptr).Target;
			return temp;
		}

		static IntPtr IntPtrFromString(string str) {
			return (IntPtr) GCHandle.Alloc(str);
		}

		static IntPtr IntPtrToQString(IntPtr ptr) {
			string temp = (string) ((GCHandle) ptr).Target;
			return StringToQString(temp);
		}

		static IntPtr IntPtrFromQString(IntPtr ptr) {
			return (IntPtr) GCHandle.Alloc(StringFromQString(ptr));
		}

		// The key is a type name of a class which has overriden one or more
		// virtual methods, and the value is a Hashtable of the smoke type
		// signatures as keys retrieving a suitable MethodInfo to invoke via 
		// reflection.
		static private Hashtable overridenMethods = new Hashtable();
		static private MethodInfo metacallMethod = typeof(Qyoto).GetMethod("QyotoMetaCall", BindingFlags.Static | BindingFlags.NonPublic);
		static private MethodInfo metaObjectMethod = typeof(QObject).GetMethod("MetaObject", BindingFlags.Instance | BindingFlags.Public);
		
		static void AddOverridenMethods(Type klass) {
			object[] attributes = klass.GetCustomAttributes(typeof(SmokeClass), false);
			if (attributes.Length > 0) {
				return;
			}

			string instanceType = klass.ToString();
			Hashtable methodsHash = (Hashtable) overridenMethods[instanceType];
			if (methodsHash != null) {
				return;
			}

			methodsHash = new Hashtable();
			overridenMethods[instanceType] = methodsHash;
			
			do {
				MemberInfo[] methods = klass.FindMembers(	MemberTypes.Method,
															BindingFlags.Public 
															| BindingFlags.NonPublic 
															| BindingFlags.Instance
															| BindingFlags.DeclaredOnly,
															Type.FilterName,
															"*" );
				foreach (MemberInfo method in methods) {
					Type parent = klass.BaseType;
					string signature = null;
					while (signature == null && parent != null && parent != typeof(Qt)) {
						MemberInfo[] parentMethods = parent.FindMembers(	MemberTypes.Method,
																			BindingFlags.Public 
																			| BindingFlags.NonPublic 
																			| BindingFlags.Instance
																			| BindingFlags.DeclaredOnly,
																			Type.FilterName,
																			method.Name );
						foreach (MemberInfo parentMethod in parentMethods) {
							if (method.ToString() == parentMethod.ToString()) {
//								Console.WriteLine("found a parent {0} {1}", parent, parentMethod);
								object[] smokeMethod = parentMethod.GetCustomAttributes(typeof(SmokeMethod), false);
								if (smokeMethod.Length > 0) {
									signature = ((SmokeMethod) smokeMethod[0]).Signature;
								}
								
							}
						}
	
						parent = parent.BaseType;
					}
	
					if (signature != null && methodsHash[signature] == null) {
						methodsHash[signature] = method;
					}
				}

				klass = klass.BaseType;
				attributes = klass.GetCustomAttributes(typeof(SmokeClass), false);
			} while (attributes.Length == 0);
		}

		static IntPtr OverridenMethod(IntPtr instance, string method) {
			object temp = ((GCHandle) instance).Target;
			string instanceType = temp.ToString();

			if (method == "metaObject() const")
				return (IntPtr)GCHandle.Alloc(metaObjectMethod);

			Hashtable methods = (Hashtable) overridenMethods[instanceType];
			if (methods == null) {
				return (IntPtr) 0;
			}

			MethodInfo methodInfo = (MethodInfo) methods[method];
			if (methodInfo == null) {
				return (IntPtr) 0;
			}

			return (IntPtr) GCHandle.Alloc(methodInfo);
		}

		static void InvokeMethod(IntPtr instanceHandle, IntPtr methodHandle, IntPtr stack) {
#if DEBUG
			Console.WriteLine("ENTER: InvokeMethod");
#endif
			object instance = ((GCHandle) instanceHandle).Target;
			MethodInfo method = (MethodInfo) ((GCHandle) methodHandle).Target;
//			Console.WriteLine("InvokeMethod() {0}.{1}", instance, method.Name);

			unsafe {
				StackItem * stackPtr = (StackItem *) stack;
				ParameterInfo[] parameters = method.GetParameters();
				object[] args = new object[parameters.Length];

				for (int i = 0; i < args.Length; i++) {
					if (parameters[i].ParameterType == typeof(bool)) {
						args[i] = stackPtr[i].s_bool;
					} else if (parameters[i].ParameterType == typeof(sbyte)) {
						args[i] = stackPtr[i].s_char;
					} else if (parameters[i].ParameterType == typeof(byte)) {
						args[i] = stackPtr[i].s_uchar;
					} else if (parameters[i].ParameterType == typeof(short)) {
						args[i] = stackPtr[i].s_short;
					} else if (parameters[i].ParameterType == typeof(ushort)) {
						args[i] = stackPtr[i].s_ushort;
					} else if (	parameters[i].ParameterType == typeof(int) 
								|| parameters[i].ParameterType.IsEnum ) 
					{
						args[i] = stackPtr[i].s_int;
					} else if (parameters[i].ParameterType == typeof(uint)) {
						args[i] = stackPtr[i].s_uint;
					} else if (parameters[i].ParameterType == typeof(long)) {
						args[i] = stackPtr[i].s_long;
					} else if (parameters[i].ParameterType == typeof(ulong)) {
						args[i] = stackPtr[i].s_ulong;
					} else if (parameters[i].ParameterType == typeof(float)) {
						args[i] = stackPtr[i].s_float;
					} else if (parameters[i].ParameterType == typeof(double)) {
						args[i] = stackPtr[i].s_double;
					} else if (parameters[i].ParameterType == typeof(string)) {
						args[i] = (string) ((GCHandle) stackPtr[i].s_class).Target;
					} else {
						args[i] = ((GCHandle) stackPtr[i].s_class).Target;
					}
				}

				object returnValue = method.Invoke(instance, args);
				Type returnType = method.ReturnType;

				if (returnType == typeof(void)) {
					;
				} else if (returnType == typeof(bool)) {
					stackPtr[0].s_bool = (bool) returnValue;
				} else if (returnType == typeof(sbyte)) {
					stackPtr[0].s_char = (sbyte) returnValue;
				} else if (returnType == typeof(byte)) {
					stackPtr[0].s_uchar = (byte) returnValue;
				} else if (returnType == typeof(short)) {
					stackPtr[0].s_short = (short) returnValue;
				} else if (returnType == typeof(ushort)) {
					stackPtr[0].s_ushort = (ushort) returnValue;
				} else if (returnType == typeof(int) || returnType.IsEnum) {
					stackPtr[0].s_int = (int) returnValue;
				} else if (returnType == typeof(uint)) {
					stackPtr[0].s_uint = (uint) returnValue;
				} else if (returnType == typeof(long)) {
					stackPtr[0].s_long = (long) returnValue;
				} else if (returnType == typeof(ulong)) {
					stackPtr[0].s_ulong = (ulong) returnValue;
				} else if (returnType == typeof(float)) {
					stackPtr[0].s_float = (float) returnValue;
				} else if (returnType == typeof(double)) {
					stackPtr[0].s_double = (double) returnValue;
				} else if (returnType == typeof(string)) {
					stackPtr[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
				} else {
					stackPtr[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
				}
			}

			return;
		}

		static public void InvokeCustomSlot(IntPtr obj, string slotname, IntPtr stack, IntPtr ret) {
			QObject qobj = (QObject) ((GCHandle)obj).Target;
			string className = qobj.GetType().ToString();
#if DEBUG
			Console.WriteLine("handling slot {0} for class {1}", slotname, qobj.GetType());
#endif
			Hashtable slotTable = (Hashtable)Qyoto.classes[className];
			if (slotTable == null) {
				slotTable = Qyoto.GetSlotSignatures(qobj.GetType());
			}
			MethodInfo slot = ((Qyoto.CPPMethod)slotTable[slotname]).mi;
			if (slot == null) {
				// should not happen
				Console.WriteLine("** Could not retrieve slot {0}::{1} info **", className, slotname);
			}
		
			ParameterInfo[] parameters = slot.GetParameters();
			object[] args = new object[parameters.Length];
			unsafe {
				StackItem* stackPtr = (StackItem*) stack;
				for (int i = 0; i < args.Length; i++) {
					if (parameters[i].ParameterType == typeof(bool)) {
						args[i] = stackPtr[i].s_bool;
					} else if (parameters[i].ParameterType == typeof(sbyte)) {
						args[i] = stackPtr[i].s_char;
					} else if (parameters[i].ParameterType == typeof(byte)) {
						args[i] = stackPtr[i].s_uchar;
					} else if (parameters[i].ParameterType == typeof(short)) {
						args[i] = stackPtr[i].s_short;
					} else if (parameters[i].ParameterType == typeof(ushort)) {
						args[i] = stackPtr[i].s_ushort;
					} else if (	parameters[i].ParameterType == typeof(int) 
								|| parameters[i].ParameterType.IsEnum ) 
					{
						args[i] = stackPtr[i].s_int;
					} else if (parameters[i].ParameterType == typeof(uint)) {
						args[i] = stackPtr[i].s_uint;
					} else if (parameters[i].ParameterType == typeof(long)) {
						args[i] = stackPtr[i].s_long;
					} else if (parameters[i].ParameterType == typeof(ulong)) {
						args[i] = stackPtr[i].s_ulong;
					} else if (parameters[i].ParameterType == typeof(float)) {
						args[i] = stackPtr[i].s_float;
					} else if (parameters[i].ParameterType == typeof(double)) {
						args[i] = stackPtr[i].s_double;
					} else if (parameters[i].ParameterType == typeof(string)) {
						args[i] = (string) ((GCHandle) stackPtr[i].s_class).Target;
					} else {
						args[i] = ((GCHandle) stackPtr[i].s_class).Target;
					}
				}
			}
			
			object returnValue = slot.Invoke(qobj, args);
			Type returnType = slot.ReturnType;
			
			unsafe {
				StackItem* retval = (StackItem*) ret;
				if (returnType == typeof(void)) {
					;
				} else if (returnType == typeof(bool)) {
					retval->s_bool = (bool) returnValue;
				} else if (returnType == typeof(sbyte)) {
					retval->s_char = (sbyte) returnValue;
				} else if (returnType == typeof(byte)) {
					retval->s_uchar = (byte) returnValue;
				} else if (returnType == typeof(short)) {
					retval->s_short = (short) returnValue;
				} else if (returnType == typeof(ushort)) {
					retval->s_ushort = (ushort) returnValue;
				} else if (returnType == typeof(int) || returnType.IsEnum) {
					retval->s_int = (int) returnValue;
				} else if (returnType == typeof(uint)) {
					retval->s_uint = (uint) returnValue;
				} else if (returnType == typeof(long)) {
					retval->s_long = (long) returnValue;
				} else if (returnType == typeof(ulong)) {
					retval->s_ulong = (ulong) returnValue;
				} else if (returnType == typeof(float)) {
					retval->s_float = (float) returnValue;
				} else if (returnType == typeof(double)) {
					retval->s_double = (double) returnValue;
				} else if (returnType == typeof(string)) {
					retval->s_class = (IntPtr) GCHandle.Alloc(returnValue);
				} else {
					retval->s_class = (IntPtr) GCHandle.Alloc(returnValue);
				}
			}
		}

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
		
		static private OverridenMethodFn overridenMethod = new OverridenMethodFn(OverridenMethod);
		static private InvokeMethodFn invokeMethod = new InvokeMethodFn(InvokeMethod);

		static private CreateInstanceFn createInstance = new CreateInstanceFn(CreateInstance);
		static private InvokeCustomSlotFn invokeCustomSlot = new InvokeCustomSlotFn(InvokeCustomSlot);
		static private IsSmokeClassFn isSmokeClass = new IsSmokeClassFn(Qyoto.IsSmokeClass);
		
		static SmokeInvocation() {
			AddFreeGCHandle(freeGCHandle);

			AddGetSmokeObject(getSmokeObject);
			AddSetSmokeObject(setSmokeObject);
			
			AddMapPointer(mapPointer);
			AddUnmapPointer(unmapPointer);
			AddGetPointerObject(getPointerObject);

			AddIntPtrToCharStarStar(intPtrToCharStarStar);
			AddIntPtrToCharStar(intPtrToString);
			AddIntPtrFromCharStar(intPtrFromString);
			AddIntPtrToQString(intPtrToQString);
			AddIntPtrFromQString(intPtrFromQString);

			AddOverridenMethod(overridenMethod);
			AddInvokeMethod(invokeMethod);

			AddCreateInstance(createInstance);
			AddInvokeCustomSlot(invokeCustomSlot);
			AddIsSmokeClass(isSmokeClass);
		}
		
		private Type	_classToProxy;
		private Object	_instance;
		private string	_className;
		
		public SmokeInvocation(Type classToProxy, Object instance) : base(classToProxy) 
		{
			_classToProxy = classToProxy;
			_instance = instance;
			_className = Regex.Replace(_classToProxy.ToString(), @"^[^\.]*.([^+]*).*", "$1");
			if (_instance != null) {
				AddOverridenMethods(_instance.GetType());
			}
		}

		public ArrayList FindMethod(string name) {
			ArrayList result = new ArrayList();
			
//			Console.WriteLine("FindMethod() className: {0} MethodName: {1}", _className, name);
			int meth = FindMethodId(_className, name);
			if (meth == 0) {
				meth = FindMethodId("QGlobalSpace", name);
			}
			
			if (meth == 0) {
				return result;
			} else if (meth > 0) {
				int i = MethodFromMap(meth);
//				Console.WriteLine("FindMethod() MethodName: {0} result: {1}", name, i);
				if (i == 0) {		// shouldn't happen
					;
				} else if (i > 0) {	// single match
					result.Add(i);
//					Console.WriteLine("FindMethod() single match {0}", i);
				} else {		// multiple match
					i = -i;		// turn into ambiguousMethodList index
					int	methodId;
					while ((methodId = FindAmbiguousMethodId(i)) != 0) {
						if (methodId > 0) {
							result.Add(methodId);
						}
						i++;
					}
//					Console.WriteLine("FindMethod() multiple match {0}", result[0]);
				}
			}
			return result;
		}
		
		public override IMessage Invoke(IMessage message) {
			ArrayList	methods = null;
			
			IMethodCallMessage callMessage = (IMethodCallMessage) message;
#if DEBUG
			Console.WriteLine(	"ENTER Invoke() MethodName: {0} Type: {1} ArgCount: {2}", 
								callMessage.MethodName, 
								callMessage.TypeName, 
								callMessage.ArgCount.ToString() );
#endif

			StackItem[] stack = new StackItem[callMessage.ArgCount+1];
			
			string mungedName = callMessage.MethodName;
			mungedName = char.ToLower(mungedName[0]) + mungedName.Substring(1, mungedName.Length-1);
			mungedName = Regex.Replace(mungedName, @"^new", "");
			IMethodReturnMessage returnMessage = (IMethodReturnMessage) message;

			if (callMessage.MethodSignature != null) {
				Type[] types = (Type[]) callMessage.MethodSignature;
				for (int i = 0; i < callMessage.ArgCount; i++) {
					if (	types[i].IsArray
							|| types[i] == typeof(System.Collections.ArrayList) ) 
					{
						mungedName += "?";
					} else if (	types[i].IsPrimitive 
								|| types[i].IsEnum
								|| types[i] == typeof(System.String) 
								|| types[i] == typeof(System.Text.StringBuilder) ) 
					{
						mungedName += "$";
					} else {
						mungedName += "#";
					}
				}

				methods = FindMethod(mungedName);
				if (methods.Count == 0) {
#if DEBUG
					Console.WriteLine("LEAVE Invoke() ** Missing method ** {0}", mungedName);
#endif
					return returnMessage;
				}

				for (int i = 0; i < callMessage.ArgCount; i++) {
					if (callMessage.Args[i] == null) {
						unsafe {
							stack[i+1].s_class = (IntPtr) 0;
						}
					} else if (types[i] == typeof(bool)) {
						stack[i+1].s_bool = (bool) callMessage.Args[i];
					} else if (types[i] == typeof(sbyte)) {
						stack[i+1].s_char = (sbyte) callMessage.Args[i];
					} else if (types[i] == typeof(byte)) {
						stack[i+1].s_uchar = (byte) callMessage.Args[i];
					} else if (types[i] == typeof(short)) {
						stack[i+1].s_short = (short) callMessage.Args[i];
					} else if (types[i] == typeof(ushort)) {
						stack[i+1].s_ushort = (ushort) callMessage.Args[i];
					} else if (types[i] == typeof(int) || types[i].IsEnum) {
						stack[i+1].s_int = (int) callMessage.Args[i];
					} else if (types[i] == typeof(uint)) {
						stack[i+1].s_uint = (uint) callMessage.Args[i];
					} else if (types[i] == typeof(long)) {
						stack[i+1].s_long = (long) callMessage.Args[i];
					} else if (types[i] == typeof(ulong)) {
						stack[i+1].s_ulong = (ulong) callMessage.Args[i];
					} else if (types[i] == typeof(float)) {
						stack[i+1].s_float = (float) callMessage.Args[i];
					} else if (types[i] == typeof(double)) {
						stack[i+1].s_double = (double) callMessage.Args[i];
					} else if (types[i] == typeof(string)) {
						stack[i+1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					} else {
						stack[i+1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					}
				}
			}
			
			GCHandle instanceHandle = GCHandle.Alloc(_instance);
			MethodReturnMessageWrapper returnValue = new MethodReturnMessageWrapper((IMethodReturnMessage) returnMessage); 
			
			unsafe {
				fixed(StackItem * stackPtr = stack) {
					CallSmokeMethod((int) methods[0], (IntPtr) instanceHandle, (IntPtr) stackPtr, callMessage.ArgCount);
					Type returnType = ((MethodInfo) returnMessage.MethodBase).ReturnType;
					
					if (returnType == typeof(void)) {
						;
					} else if (returnType == typeof(bool)) {
						returnValue.ReturnValue = stack[0].s_bool;
					} else if (returnType == typeof(sbyte)) {
						returnValue.ReturnValue = stack[0].s_char;
					} else if (returnType == typeof(byte)) {
						returnValue.ReturnValue = stack[0].s_uchar;
					} else if (returnType == typeof(short)) {
						returnValue.ReturnValue = stack[0].s_short;
					} else if (returnType == typeof(ushort)) {
						returnValue.ReturnValue = stack[0].s_ushort;
					} else if (returnType == typeof(int) || returnType.IsEnum) {
						returnValue.ReturnValue = stack[0].s_int;
					} else if (returnType == typeof(uint)) {
						returnValue.ReturnValue = stack[0].s_uint;
					} else if (returnType == typeof(long)) {
						returnValue.ReturnValue = stack[0].s_long;
					} else if (returnType == typeof(ulong)) {
						returnValue.ReturnValue = stack[0].s_ulong;
					} else if (returnType == typeof(float)) {
						returnValue.ReturnValue = stack[0].s_float;
					} else if (returnType == typeof(double)) {
						returnValue.ReturnValue = stack[0].s_double;
					} else if (returnType == typeof(string)) {
						returnValue.ReturnValue = ((GCHandle) stack[0].s_class).Target;
					} else {
						returnValue.ReturnValue = ((GCHandle) stack[0].s_class).Target;
					}
				}
			}
						
			returnMessage = returnValue;

#if DEBUG
			Console.WriteLine("LEAVE Invoke()");
#endif
			return returnMessage;
		}
		
		public override int GetHashCode() {
			return _instance.GetHashCode();
		}
	}

	public class SignalInvocation : RealProxy {
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void SignalEmit(string signature, IntPtr target, IntPtr sp, int items);

		private Type	_classToProxy;
		private Object	_instance;
		private string	_className;

		public SignalInvocation(Type classToProxy, Object instance) : base(classToProxy) 
		{
			_classToProxy = classToProxy;
			_instance = instance;
			_className = Regex.Replace(_classToProxy.ToString(), @"^.*I(.*)Signals$", "$1");
		}

		public override IMessage Invoke(IMessage message) {
			IMethodCallMessage callMessage = (IMethodCallMessage) message;
			StackItem[] stack = new StackItem[callMessage.ArgCount+1];

			if (callMessage.MethodSignature != null) {
				Type[] types = (Type[]) callMessage.MethodSignature;

				for (int i = 0; i < callMessage.ArgCount; i++) {
					if (callMessage.Args[i] == null) {
						unsafe {
							stack[i].s_class = (IntPtr) 0;
						}
					} else if (types[i] == typeof(bool)) {
						stack[i].s_bool = (bool) callMessage.Args[i];
					} else if (types[i] == typeof(sbyte)) {
						stack[i].s_char = (sbyte) callMessage.Args[i];
					} else if (types[i] == typeof(byte)) {
						stack[i].s_uchar = (byte) callMessage.Args[i];
					} else if (types[i] == typeof(short)) {
						stack[i].s_short = (short) callMessage.Args[i];
					} else if (types[i] == typeof(ushort)) {
						stack[i].s_ushort = (ushort) callMessage.Args[i];
					} else if (types[i] == typeof(int) || types[i].IsEnum) {
						stack[i].s_int = (int) callMessage.Args[i];
					} else if (types[i] == typeof(uint)) {
						stack[i].s_uint = (uint) callMessage.Args[i];
					} else if (types[i] == typeof(long)) {
						stack[i].s_long = (long) callMessage.Args[i];
					} else if (types[i] == typeof(ulong)) {
						stack[i].s_ulong = (ulong) callMessage.Args[i];
					} else if (types[i] == typeof(float)) {
						stack[i].s_float = (float) callMessage.Args[i];
					} else if (types[i] == typeof(double)) {
						stack[i].s_double = (double) callMessage.Args[i];
					} else if (types[i] == typeof(string)) {
						stack[i].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					} else {
						stack[i].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					}
				}
			}

			IMethodReturnMessage returnMessage = (IMethodReturnMessage) message;
			GCHandle instanceHandle = GCHandle.Alloc(_instance);

			string signature = "";
			object[] attributes = ((MethodInfo) callMessage.MethodBase).GetCustomAttributes(typeof(Q_SIGNAL), false);
			if (attributes.Length > 0) {
				signature = ((Q_SIGNAL) attributes[0]).Signature;
#if DEBUG
				Console.WriteLine( "Q_SIGNAL signature: {0}", signature );
#endif
			}

			unsafe {
				fixed(StackItem * stackPtr = stack) {
					SignalEmit(signature, (IntPtr) instanceHandle, (IntPtr) stackPtr, callMessage.ArgCount);
				}
			}

			return returnMessage;
		}

		public override int GetHashCode() {
			return _instance.GetHashCode();
		}
	}
}

