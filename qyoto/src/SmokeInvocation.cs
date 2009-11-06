/***************************************************************************
                          SmokeInvocation.cs  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale
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

namespace Qyoto {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Text;
	using System.Reflection;
	using System.Runtime.Remoting.Proxies;
	using System.Runtime.Remoting.Messaging;
	using System.Runtime.Remoting;
	using System.Runtime.InteropServices;

	public struct ModuleIndex {
		public IntPtr smoke;
		public short index;
	}

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
	
	public class SmokeInvocation {
		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		static extern ModuleIndex FindMethodId(string className, string mungedName, string signature);
		
		[DllImport("qyoto", CharSet=CharSet.Ansi, EntryPoint="CallSmokeMethod", CallingConvention=CallingConvention.Cdecl)]
		static extern void CallSmokeMethod(IntPtr smoke, int methodId, IntPtr target, IntPtr sp, int items);

		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		static extern int QyotoHash(IntPtr obj);

		// The key is a type name of a class which has overriden one or more
		// virtual methods, and the value is a Hashtable of the smoke type
		// signatures as keys retrieving a suitable MethodInfo to invoke via 
		// reflection.
		static private Dictionary<Type, Dictionary<string, MemberInfo>> overridenMethods = 
			new Dictionary<Type, Dictionary<string, MemberInfo>>();

		static private MethodInfo metaObjectMethod = typeof(QObject).GetMethod("MetaObject", BindingFlags.Instance | BindingFlags.Public);
		
		static void AddOverridenMethods(Type klass) {
			if (SmokeMarshallers.IsSmokeClass(klass)) {
				return;
			}

			if (overridenMethods.ContainsKey(klass))
				return;

			Dictionary<string, MemberInfo> methodsHash = new Dictionary<string, MemberInfo>();
			overridenMethods.Add(klass, methodsHash);
			
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
								object[] smokeMethod = parentMethod.GetCustomAttributes(typeof(SmokeMethod), false);
								if (smokeMethod.Length > 0) {
									signature = ((SmokeMethod) smokeMethod[0]).Signature;
								}
								
							}
						}
	
						parent = parent.BaseType;
					}
	
					if (signature != null && !methodsHash.ContainsKey(signature)) {
						methodsHash.Add(signature, method);
					}
				}

				klass = klass.BaseType;
			} while (!SmokeMarshallers.IsSmokeClass(klass));
		}

		public static IntPtr OverridenMethod(IntPtr instance, string method) {
			Type klass = ((GCHandle) instance).Target.GetType();

			if (method == "metaObject() const") {
#if DEBUG
				return (IntPtr) DebugGCHandle.Alloc(metaObjectMethod);
#else
				return (IntPtr) GCHandle.Alloc(metaObjectMethod);
#endif
			}

			Dictionary<string, MemberInfo> methods;
			if (!overridenMethods.TryGetValue(klass, out methods)) {
				return (IntPtr) 0;
			}

			MemberInfo methodInfo;
			if (!methods.TryGetValue(method, out methodInfo)) {
				return (IntPtr) 0;
			}

#if DEBUG
			return (IntPtr) DebugGCHandle.Alloc(methodInfo);
#else
			return (IntPtr) GCHandle.Alloc(methodInfo);
#endif
		}

		public static void InvokeMethod(IntPtr instanceHandle, IntPtr methodHandle, IntPtr stack) {
			object instance = ((GCHandle) instanceHandle).Target;
			MethodInfo method = (MethodInfo) ((GCHandle) methodHandle).Target;
#if DEBUG
			if (	(QDebug.DebugChannel() & QtDebugChannel.QTDB_TRANSPARENT_PROXY) != 0
					&& (QDebug.DebugChannel() & QtDebugChannel.QTDB_VIRTUAL) != 0 )
			{
				Console.WriteLine(	"ENTER InvokeMethod() {0}.{1}", 
									instance,
									method.Name );
			}
#endif

			unsafe {
				StackItem * stackPtr = (StackItem *) stack;
				ParameterInfo[] parameters = method.GetParameters();
				object[] args = new object[parameters.Length];

				for (int i = 0; i < args.Length; i++) {
					if (parameters[i].ParameterType == typeof(bool)) {
						args[i] = stackPtr[i+1].s_bool;
					} else if (parameters[i].ParameterType == typeof(sbyte)) {
						args[i] = stackPtr[i+1].s_char;
					} else if (parameters[i].ParameterType == typeof(byte)) {
						args[i] = stackPtr[i+1].s_uchar;
					} else if (parameters[i].ParameterType == typeof(char)) {
						args[i] = (char) stackPtr[i+1].s_uchar;
					} else if (parameters[i].ParameterType == typeof(short)) {
						args[i] = stackPtr[i+1].s_short;
					} else if (parameters[i].ParameterType == typeof(ushort)) {
						args[i] = stackPtr[i+1].s_ushort;
					} else if (parameters[i].ParameterType == typeof(int)) {
						args[i] = stackPtr[i+1].s_int;
					} else if (parameters[i].ParameterType.IsEnum) {
						args[i] = Enum.ToObject(parameters[i].ParameterType, stackPtr[i+1].s_int);
					} else if (parameters[i].ParameterType == typeof(uint)) {
						args[i] = stackPtr[i+1].s_uint;
					} else if (parameters[i].ParameterType == typeof(long)) {
						// s_long will contain the wrong value on 32 bit platforms
						// (i.e. where a native C++ 'long' isn't at least 64 bit)
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_int : stackPtr[i+1].s_long;
					} else if (parameters[i].ParameterType == typeof(ulong)) {
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_uint : stackPtr[i+1].s_ulong;
					} else if (parameters[i].ParameterType == typeof(float)) {
						args[i] = stackPtr[i+1].s_float;
					} else if (parameters[i].ParameterType == typeof(double)) {
						args[i] = stackPtr[i+1].s_double;
					} else if (parameters[i].ParameterType == typeof(string)) {
						if (stackPtr[i+1].s_class != IntPtr.Zero) {
							args[i] = (string) ((GCHandle) stackPtr[i+1].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stackPtr[i+1].s_class);
#else
							((GCHandle) stackPtr[i+1].s_class).Free();
#endif
						}
					} else {
						if (stackPtr[i+1].s_class != IntPtr.Zero) {
							args[i] = ((GCHandle) stackPtr[i+1].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stackPtr[i+1].s_class);
#else
							((GCHandle) stackPtr[i+1].s_class).Free();
#endif						
						}
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
				} else if (returnType == typeof(char)) {
					stackPtr[0].s_uchar = (byte) (char) returnValue;
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
#if DEBUG
					stackPtr[0].s_class = (IntPtr) DebugGCHandle.Alloc(returnValue);
#else
					stackPtr[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
#endif
				} else if (returnValue == null) {
					stackPtr[0].s_class = IntPtr.Zero;
				} else {
#if DEBUG
					stackPtr[0].s_class = (IntPtr) DebugGCHandle.Alloc(returnValue);
#else
					stackPtr[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
#endif
				}
			}

			return;
		}

		static public void InvokeCustomSlot(IntPtr obj, string slotname, IntPtr stack, IntPtr ret) {
			QObject qobj = (QObject) ((GCHandle)obj).Target;
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_TRANSPARENT_PROXY) != 0) {
				Console.WriteLine(	"ENTER InvokeCustomSlot() {0}.{1}", 
									qobj,
									slotname );
			}
#endif
		
			MethodInfo slot = Qyoto.GetSlotMethodInfo(qobj.GetType(), slotname);
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
					} else if (parameters[i].ParameterType == typeof(char)) {
						args[i] = (char) stackPtr[i].s_uchar;
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
						// s_long will contain the wrong value on 32 bit platforms
						// (i.e. where a native C++ 'long' isn't at least 64 bit)
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_int : stackPtr[i+1].s_long;
					} else if (parameters[i].ParameterType == typeof(ulong)) {
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_uint : stackPtr[i+1].s_ulong;
					} else if (parameters[i].ParameterType == typeof(float)) {
						args[i] = stackPtr[i].s_float;
					} else if (parameters[i].ParameterType == typeof(double)) {
						args[i] = stackPtr[i].s_double;
					} else if (parameters[i].ParameterType == typeof(string)) {
						if (stackPtr[i].s_class != IntPtr.Zero) {
							args[i] = (string) ((GCHandle) stackPtr[i].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stackPtr[i].s_class);
#else
							((GCHandle) stackPtr[i].s_class).Free();
#endif
						}
					} else {
						if (stackPtr[i].s_class != IntPtr.Zero) {
							args[i] = ((GCHandle) stackPtr[i].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stackPtr[i].s_class);
#else
							((GCHandle) stackPtr[i].s_class).Free();
#endif
						}
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
					retval[0].s_bool = (bool) returnValue;
				} else if (returnType == typeof(sbyte)) {
					retval[0].s_char = (sbyte) returnValue;
				} else if (returnType == typeof(byte)) {
					retval[0].s_uchar = (byte) returnValue;
				} else if (returnType == typeof(short)) {
					retval[0].s_short = (short) returnValue;
				} else if (returnType == typeof(ushort)) {
					retval[0].s_ushort = (ushort) returnValue;
				} else if (returnType == typeof(int) || returnType.IsEnum) {
					retval[0].s_int = (int) returnValue;
				} else if (returnType == typeof(uint)) {
					retval[0].s_uint = (uint) returnValue;
				} else if (returnType == typeof(long)) {
					retval[0].s_long = (long) returnValue;
				} else if (returnType == typeof(ulong)) {
					retval[0].s_ulong = (ulong) returnValue;
				} else if (returnType == typeof(float)) {
					retval[0].s_float = (float) returnValue;
				} else if (returnType == typeof(double)) {
					retval[0].s_double = (double) returnValue;
				} else if (returnType == typeof(string)) {
#if DEBUG	
					retval[0].s_class = (IntPtr) DebugGCHandle.Alloc(returnValue);
#else
					retval[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
#endif
				} else if (returnValue == null) {
					retval[0].s_class = IntPtr.Zero;
				} else {
#if DEBUG	
					retval[0].s_class = (IntPtr) DebugGCHandle.Alloc(returnValue);
#else
					retval[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
#endif
				}
			}
		}

		static public void InvokeDelegate(Delegate d, IntPtr stack) {
			unsafe {
				MethodInfo mi = d.Method;
				ParameterInfo[] parameters = mi.GetParameters();
				object[] args = new object[parameters.Length];
				StackItem* stackPtr = (StackItem*) stack;
				for (int i = 0; i < args.Length; i++) {
					if (parameters[i].ParameterType == typeof(bool)) {
						args[i] = stackPtr[i].s_bool;
					} else if (parameters[i].ParameterType == typeof(sbyte)) {
						args[i] = stackPtr[i].s_char;
					} else if (parameters[i].ParameterType == typeof(byte)) {
						args[i] = stackPtr[i].s_uchar;
					} else if (parameters[i].ParameterType == typeof(char)) {
						args[i] = (char) stackPtr[i].s_uchar;
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
						// s_long will contain the wrong value on 32 bit platforms
						// (i.e. where a native C++ 'long' isn't at least 64 bit)
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_int : stackPtr[i+1].s_long;
					} else if (parameters[i].ParameterType == typeof(ulong)) {
						args[i] = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stackPtr[i+1].s_uint : stackPtr[i+1].s_ulong;
					} else if (parameters[i].ParameterType == typeof(float)) {
						args[i] = stackPtr[i].s_float;
					} else if (parameters[i].ParameterType == typeof(double)) {
						args[i] = stackPtr[i].s_double;
					} else {
						if (stackPtr[i].s_class != IntPtr.Zero) {
							args[i] = ((GCHandle) stackPtr[i].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stackPtr[i].s_class);
#else
							((GCHandle) stackPtr[i].s_class).Free();
#endif
						}
					}
				}
				d.DynamicInvoke(args);
			}
		}

		// list of assemblies on which CallInitSmoke() has already been called.
		public static List<Assembly> InitializedAssemblies = new List<Assembly>();
		// whether the qyoto (core) runtime has been initialized
		static bool runtimeInitialized = false;

		public static void InitRuntime() {
			if (runtimeInitialized)
				return;
			Qyoto.Init_qyoto();
			SmokeMarshallers.SetUp();
			// not set when mono is embedded
			if (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile == null) {
				PropertyInfo pi = typeof(AppDomain).GetProperty("SetupInformationNoCopy", BindingFlags.NonPublic | BindingFlags.Instance);
				AppDomainSetup setup = (AppDomainSetup) pi.GetValue(AppDomain.CurrentDomain, null);
				setup.ConfigurationFile = Assembly.GetExecutingAssembly().Location + ".config";
			}
			runtimeInitialized = true;
		}

		public static void TryInitialize(Assembly assembly) {
			if (InitializedAssemblies.Contains(assembly))
				return;
			AssemblySmokeInitializer attr = 
				(AssemblySmokeInitializer) Attribute.GetCustomAttribute(assembly, typeof(AssemblySmokeInitializer));
			if (attr != null) attr.CallInitSmoke();
			InitializedAssemblies.Add(assembly);
		}

		static SmokeInvocation() {
			InitRuntime();
		}
		
		private Type	classToProxy;
		private Object	instance;
		private string	className = "";
		private Dictionary<string, ModuleIndex> methodIdCache;

		private static Dictionary<Type, Dictionary<string, ModuleIndex>> globalMethodIdCache = new Dictionary<Type, Dictionary<string, ModuleIndex>>();
		
		public SmokeInvocation(Type klass, Object obj) 
		{
			classToProxy = klass;
			instance = obj;
			className = SmokeMarshallers.SmokeClassName(klass);

			TryInitialize(klass.Assembly);

			if (!globalMethodIdCache.TryGetValue(classToProxy, out methodIdCache)) {
				methodIdCache = new Dictionary<string, ModuleIndex>();
				globalMethodIdCache[classToProxy] = methodIdCache;
			}

			if (instance != null) {
				AddOverridenMethods(instance.GetType());
			}
		}

		// A variant of Invoke() for use in method calls with 'ref' argument types.
		// The caller is responsible for setting up the stack, and copying items
		// back from the stack to the arguments after Invoke() has been called.
		public void Invoke(string mungedName, string signature, StackItem[] stack) {
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_TRANSPARENT_PROXY) != 0) {
				Console.WriteLine(	"ENTER SmokeInvocation.Invoke1() MethodName: {0}.{1}", 
									className,
									signature );
			}
#endif
			
			ModuleIndex methodId;
			methodId.smoke = IntPtr.Zero;
			methodId.index = -1;
			if (!methodIdCache.TryGetValue(signature, out methodId)) {
				methodId = FindMethodId(className, mungedName, signature);

				if (methodId.index == -1) {
					Console.Error.WriteLine(	"LEAVE Invoke() ** Missing method ** {0}.{1}", 
												className,
												signature );
					return;
				}

				methodIdCache[signature] = methodId;
			}

			unsafe {
				fixed(StackItem * stackPtr = stack) {
					if (instance == null) {
						CallSmokeMethod(methodId.smoke, (int) methodId.index, (IntPtr) 0, (IntPtr) stackPtr, stack.Length);
					} else {
#if DEBUG
						GCHandle instanceHandle = DebugGCHandle.Alloc(instance);
#else
						GCHandle instanceHandle = GCHandle.Alloc(instance);
#endif
						CallSmokeMethod(methodId.smoke, methodId.index, (IntPtr) instanceHandle, (IntPtr) stackPtr, stack.Length);
#if DEBUG
						DebugGCHandle.Free(instanceHandle);
#else
						instanceHandle.Free();
#endif
					}
				}
			}

			return;
		}

		public object Invoke(string mungedName, string signature, Type returnType, params object[] args) {
#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_TRANSPARENT_PROXY) != 0) {
				Console.WriteLine(	"ENTER SmokeInvocation.Invoke() MethodName: {0}.{1} Type: {2} ArgCount: {3}", 
									className,
									signature, 
									returnType, 
									args.Length / 2 );
			}
#endif

			if (signature.StartsWith("operator==")) {
				if (args[1] == null && args[3] == null)
					return true;
				else if (args[1] == null || args[3] == null)
					return false;
			}
			ModuleIndex methodId;
			methodId.smoke = IntPtr.Zero;
			methodId.index = -1;
			if (!methodIdCache.TryGetValue(signature, out methodId)) {
				methodId = FindMethodId(className, mungedName, signature);

				if (methodId.index == -1) {
					Console.Error.WriteLine(	"LEAVE Invoke() ** Missing method ** {0}.{1}", 
												className,
												signature );
					return null;
				}

				methodIdCache[signature] = methodId;
			}
			
			StackItem[] stack = new StackItem[(args.Length / 2) + 1];

			for (int i = 0, k = 1; i < args.Length; i += 2, k++) {
				if (args[i+1] == null) {
					unsafe {
						stack[k].s_class = IntPtr.Zero;
					}
				} else if (args[i] == typeof(int) || ((Type) args[i]).IsEnum) {
					stack[k].s_int = (int) args[i+1];
				} else if (args[i] == typeof(bool)) {
					stack[k].s_bool = (bool) args[i+1];
				} else if (args[i] == typeof(short)) {
					stack[k].s_short = (short) args[i+1];
				} else if (args[i] == typeof(float)) {
					stack[k].s_float = (float) args[i+1];
				} else if (args[i] == typeof(double)) {
					stack[k].s_double = (double) args[i+1];
				} else if (args[i] == typeof(long)) {
					stack[k].s_long = (long) args[i+1];
				} else if (args[i] == typeof(ushort)) {
					stack[k].s_ushort = (ushort) args[i+1];
				} else if (args[i] == typeof(uint)) {
					stack[k].s_uint = (uint) args[i+1];
				} else if (args[i] == typeof(ulong)) {
					stack[k].s_ulong = (ulong) args[i+1];
				} else if (args[i] == typeof(sbyte)) {
					stack[k].s_char = (sbyte) args[i+1];
				} else if (args[i] == typeof(byte)) {
					stack[k].s_uchar = (byte) args[i+1];
				} else if (args[i] == typeof(char)) {
					stack[k].s_uchar = (byte) (char) args[i+1];
				} else {
#if DEBUG
					stack[k].s_class = (IntPtr) DebugGCHandle.Alloc(args[i+1]);
#else
					stack[k].s_class = (IntPtr) GCHandle.Alloc(args[i+1]);
#endif
				}
			}

			object returnValue = null;

			unsafe {
				fixed(StackItem * stackPtr = stack) {
					if (instance == null) {
						CallSmokeMethod(methodId.smoke, (int) methodId.index, (IntPtr) 0, (IntPtr) stackPtr, args.Length / 2);
					} else {
#if DEBUG
						GCHandle instanceHandle = DebugGCHandle.Alloc(instance);
#else
						GCHandle instanceHandle = GCHandle.Alloc(instance);
#endif
						CallSmokeMethod(methodId.smoke, methodId.index, (IntPtr) instanceHandle, (IntPtr) stackPtr, args.Length / 2);
#if DEBUG
						DebugGCHandle.Free(instanceHandle);
#else
						instanceHandle.Free();
#endif
					}
					
					if (returnType == typeof(void)) {
						;
					} else if (returnType == typeof(int)) {
						returnValue = stack[0].s_int;
					} else if (returnType == typeof(bool)) {
						returnValue = stack[0].s_bool;
					} else if (returnType == typeof(short)) {
						returnValue = stack[0].s_short;
					} else if (returnType == typeof(float)) {
						returnValue = stack[0].s_float;
					} else if (returnType == typeof(double)) {
						returnValue = stack[0].s_double;
					} else if (returnType == typeof(long)) {
						// s_long will contain the wrong value on 32 bit platforms
						// (i.e. where a native C++ 'long' isn't at least 64 bit)
						returnValue = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stack[0].s_int : stack[0].s_long;
					} else if (returnType == typeof(ushort)) {
						returnValue = stack[0].s_ushort;
					} else if (returnType == typeof(uint)) {
						returnValue = stack[0].s_uint;
					} else if (returnType.IsEnum) {
						returnValue = Enum.ToObject(returnType, stack[0].s_int);
					} else if (returnType == typeof(ulong)) {
						returnValue = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stack[0].s_uint : stack[0].s_ulong;
					} else if (returnType == typeof(sbyte)) {
						returnValue = stack[0].s_char;
					} else if (returnType == typeof(byte)) {
						returnValue = stack[0].s_uchar;
					} else if (returnType == typeof(char)) {
						returnValue = (char) stack[0].s_char;
					} else {
						if (((IntPtr) stack[0].s_class) == IntPtr.Zero) {
							returnValue = null;
						} else {
							returnValue = ((GCHandle) stack[0].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stack[0].s_class);
#else
							((GCHandle) stack[0].s_class).Free();
#endif
						}
					}
				}
			}

			return returnValue;
		}
		
		public override int GetHashCode() {
#if DEBUG
			return QyotoHash((IntPtr) DebugGCHandle.Alloc(instance));
#else
			return QyotoHash((IntPtr) GCHandle.Alloc(instance));
#endif
		}
	}

	public class SignalInvocation : RealProxy {
		[DllImport("qyoto", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.Cdecl)]
		static extern bool SignalEmit(string signature, string type, IntPtr target, IntPtr sp, int items);

		private Type	signalsInterface;
		private Object	instance;

		public SignalInvocation(Type iface, Object obj) : base(iface) 
		{
			signalsInterface = iface;
			instance = obj;
		}

		public override IMessage Invoke(IMessage message) {
			IMethodCallMessage callMessage = (IMethodCallMessage) message;
			StackItem[] stack = new StackItem[callMessage.ArgCount+1];

#if DEBUG
			if ((QDebug.DebugChannel() & QtDebugChannel.QTDB_TRANSPARENT_PROXY) != 0) {
				Console.WriteLine(	"ENTER SignalInvocation.Invoke() MethodName: {0}.{1} Type: {2} ArgCount: {3}", 
									instance,
									callMessage.MethodName, 
									callMessage.TypeName, 
									callMessage.ArgCount.ToString() );
			}
#endif

			if (callMessage.MethodSignature != null) {
				Type[] types = (Type[]) callMessage.MethodSignature;

				for (int i = 0; i < callMessage.ArgCount; i++) {
					if (callMessage.Args[i] == null) {
						unsafe {
							stack[i + 1].s_class = (IntPtr) 0;
						}
					} else if (types[i] == typeof(bool)) {
						stack[i + 1].s_bool = (bool) callMessage.Args[i];
					} else if (types[i] == typeof(sbyte)) {
						stack[i + 1].s_char = (sbyte) callMessage.Args[i];
					} else if (types[i] == typeof(byte)) {
						stack[i + 1].s_uchar = (byte) callMessage.Args[i];
					} else if (types[i] == typeof(char)) {
						stack[i + 1].s_uchar = (byte) (char) callMessage.Args[i];
					} else if (types[i] == typeof(short)) {
						stack[i + 1].s_short = (short) callMessage.Args[i];
					} else if (types[i] == typeof(ushort)) {
						stack[i + 1].s_ushort = (ushort) callMessage.Args[i];
					} else if (types[i] == typeof(int) || types[i].IsEnum) {
						stack[i + 1].s_int = (int) callMessage.Args[i];
					} else if (types[i] == typeof(uint)) {
						stack[i + 1].s_uint = (uint) callMessage.Args[i];
					} else if (types[i] == typeof(long)) {
						stack[i + 1].s_long = (long) callMessage.Args[i];
					} else if (types[i] == typeof(ulong)) {
						stack[i + 1].s_ulong = (ulong) callMessage.Args[i];
					} else if (types[i] == typeof(float)) {
						stack[i + 1].s_float = (float) callMessage.Args[i];
					} else if (types[i] == typeof(double)) {
						stack[i + 1].s_double = (double) callMessage.Args[i];
					} else if (types[i] == typeof(string)) {
#if DEBUG
						stack[i + 1].s_class = (IntPtr) DebugGCHandle.Alloc(callMessage.Args[i]);
#else
						stack[i + 1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
#endif
					} else {
#if DEBUG
						stack[i + 1].s_class = (IntPtr) DebugGCHandle.Alloc(callMessage.Args[i]);
#else
						stack[i + 1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
#endif
					}
				}
			}

			IMethodReturnMessage returnMessage = new ReturnMessage(null, callMessage); /*(IMethodReturnMessage) message;*/
			MethodReturnMessageWrapper returnValue = new MethodReturnMessageWrapper((IMethodReturnMessage) returnMessage);

#if DEBUG
			GCHandle instanceHandle = DebugGCHandle.Alloc(instance);
#else
			GCHandle instanceHandle = GCHandle.Alloc(instance);
#endif

			Qyoto.CPPMethod signalEntry = Qyoto.GetSignalSignature(signalsInterface, (MethodInfo) callMessage.MethodBase);

			unsafe {
				fixed(StackItem * stackPtr = stack) {
					Type returnType = ((MethodInfo) returnMessage.MethodBase).ReturnType;
					SignalEmit(signalEntry.signature, signalEntry.type, (IntPtr) instanceHandle, (IntPtr) stackPtr, callMessage.ArgCount);

					if (returnType == typeof(void)) {
						;
					} else if (returnType == typeof(bool)) {
						returnValue.ReturnValue = stack[0].s_bool;
					} else if (returnType == typeof(sbyte)) {
						returnValue.ReturnValue = stack[0].s_char;
					} else if (returnType == typeof(byte)) {
						returnValue.ReturnValue = stack[0].s_uchar;
					} else if (returnType == typeof(char)) {
						returnValue.ReturnValue = (char) stack[0].s_uchar;
					} else if (returnType == typeof(short)) {
						returnValue.ReturnValue = stack[0].s_short;
					} else if (returnType == typeof(ushort)) {
						returnValue.ReturnValue = stack[0].s_ushort;
					} else if (returnType.IsEnum) {
						returnValue.ReturnValue = Enum.ToObject(returnType, stack[0].s_int);
					} else if (returnType == typeof(int)) {
						returnValue.ReturnValue = stack[0].s_int;
					} else if (returnType == typeof(uint)) {
						returnValue.ReturnValue = stack[0].s_uint;
					} else if (returnType == typeof(long)) {
						// s_long will contain the wrong value on 32 bit platforms
						// (i.e. where a native C++ 'long' isn't at least 64 bit)
						returnValue.ReturnValue = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stack[0].s_int : stack[0].s_long;
					} else if (returnType == typeof(ulong)) {
						returnValue.ReturnValue = (SmokeMarshallers.SizeOfNativeLong < sizeof(long))? stack[0].s_uint : stack[0].s_ulong;
					} else if (returnType == typeof(float)) {
						returnValue.ReturnValue = stack[0].s_float;
					} else if (returnType == typeof(double)) {
						returnValue.ReturnValue = stack[0].s_double;
					} else if (returnType == typeof(string)) {
						if (stack[0].s_class != IntPtr.Zero) {
							returnValue.ReturnValue = ((GCHandle) stack[0].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stack[0].s_class);
#else
							((GCHandle) stack[0].s_class).Free();
#endif

						}
					} else {
						if (stack[0].s_class != IntPtr.Zero) {
							returnValue.ReturnValue = ((GCHandle) stack[0].s_class).Target;
#if DEBUG
							DebugGCHandle.Free((GCHandle) stack[0].s_class);
#else
							((GCHandle) stack[0].s_class).Free();
#endif
						}
					}
				}
			}

			returnMessage = returnValue;
			return returnMessage;
		}

		public override int GetHashCode() {
			return instance.GetHashCode();
		}
	}
}

