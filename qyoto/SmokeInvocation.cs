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
	using System.Collections.Generic;
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
		static extern int FindMethodId(string className, string mungedName, string signature);
			
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int MethodFromMap(int methodId);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void CallSmokeMethod(int methodId, IntPtr target, IntPtr sp, int items);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern int qt_metacall(IntPtr obj, int _c, int _id, IntPtr a);

		// The key is a type name of a class which has overriden one or more
		// virtual methods, and the value is a Hashtable of the smoke type
		// signatures as keys retrieving a suitable MethodInfo to invoke via 
		// reflection.
		static private Dictionary<string, Dictionary<string, MemberInfo>>
			overridenMethods = new Dictionary<string, Dictionary<string, MemberInfo>>();
		static private MethodInfo metacallMethod = typeof(Qyoto).GetMethod("QyotoMetaCall", BindingFlags.Static | BindingFlags.NonPublic);
		static private MethodInfo metaObjectMethod = typeof(QObject).GetMethod("MetaObject", BindingFlags.Instance | BindingFlags.Public);
		
		static void AddOverridenMethods(Type klass) {
			object[] attributes = klass.GetCustomAttributes(typeof(SmokeClass), false);
			if (attributes.Length > 0) {
				return;
			}

			string instanceType = klass.ToString();
			if (overridenMethods.ContainsKey(instanceType))
				return;

			Dictionary<string, MemberInfo> methodsHash = new Dictionary<string, MemberInfo>();
			overridenMethods.Add(instanceType, methodsHash);
			
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
	
					if (signature != null && !methodsHash.ContainsKey(signature)) {
						methodsHash.Add(signature, method);
					}
				}

				klass = klass.BaseType;
				attributes = klass.GetCustomAttributes(typeof(SmokeClass), false);
			} while (attributes.Length == 0);
		}

		public static IntPtr OverridenMethod(IntPtr instance, string method) {
			object temp = ((GCHandle) instance).Target;
			string instanceType = temp.ToString();

			if (method == "metaObject() const")
				return (IntPtr)GCHandle.Alloc(metaObjectMethod);

			Dictionary<string, MemberInfo> methods;
			if (!overridenMethods.TryGetValue(instanceType, out methods)) {
				return (IntPtr) 0;
			}

			MemberInfo methodInfo;
			if (!methods.TryGetValue(method, out methodInfo)) {
				return (IntPtr) 0;
			}

			return (IntPtr) GCHandle.Alloc(methodInfo);
		}

		public static void InvokeMethod(IntPtr instanceHandle, IntPtr methodHandle, IntPtr stack) {
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
			Dictionary<string, Qyoto.CPPMethod> slotTable;
			if (!Qyoto.classes.TryGetValue(className, out slotTable)) {
				slotTable = Qyoto.GetSlotSignatures(qobj.GetType());
			}
			MethodInfo slot;
			try {
				slot = (slotTable[slotname]).mi;
			}
			catch (KeyNotFoundException) {
				// should not happen
				Console.WriteLine("** Could not retrieve slot {0}.{1} info **", className, slotname);
				return;
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
					retval[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
				} else {
					retval[0].s_class = (IntPtr) GCHandle.Alloc(returnValue);
				}
			}
		}

		static SmokeInvocation() {
			SmokeMarshallers.SetUp();
		}
		
		private Type	_classToProxy;
		private Object	_instance;
		private string	_className = "";
		
		public SmokeInvocation(Type classToProxy, Object instance) : base(classToProxy) 
		{
			_classToProxy = classToProxy;
			_instance = instance;
			object[] smokeClass = classToProxy.GetCustomAttributes(typeof(SmokeClass), true);
			if (smokeClass.Length > 0) {
				_className = ((SmokeClass) smokeClass[0]).Signature;
			}

			if (_instance != null) {
				AddOverridenMethods(_instance.GetType());
			}
		}

		public override IMessage Invoke(IMessage message) {
			IMethodCallMessage callMessage = (IMethodCallMessage) message;
#if DEBUG
			Console.WriteLine(	"ENTER Invoke() MethodName: {0} Type: {1} ArgCount: {2}", 
								callMessage.MethodName, 
								callMessage.TypeName, 
								callMessage.ArgCount.ToString() );
#endif

			StackItem[] stack = new StackItem[callMessage.ArgCount+1];
			
			int methodId = -1;
			object[] smokeMethod = ((MethodInfo) callMessage.MethodBase).GetCustomAttributes(typeof(SmokeMethod), false);
			if (smokeMethod.Length > 0) {
				methodId = ((SmokeMethod) smokeMethod[0]).methodId;
				if (methodId == -1) {
					methodId = FindMethodId(	_className,
												((SmokeMethod) smokeMethod[0]).MungedName, 
												((SmokeMethod) smokeMethod[0]).ArgsSignature );
					((SmokeMethod) smokeMethod[0]).methodId = methodId;
				}
			}

//			Console.WriteLine("Invoke() methodId: {0}", methodId);

			IMethodReturnMessage returnMessage = (IMethodReturnMessage) message;

			// Ignore destructors for now until a way of coordinating C# GC
			// with C++ deletions has been implemented
			if (((SmokeMethod) smokeMethod[0]).MungedName.StartsWith("~")) {
				return returnMessage;
			}

			if (methodId == -1) {
				Console.Error.WriteLine("LEAVE Invoke() ** Missing method ** {0}", ((MethodInfo) callMessage.MethodBase).Name);
				return returnMessage;
			}
			
			if (callMessage.MethodSignature != null) {
				Type[] types = (Type[]) callMessage.MethodSignature;
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
					CallSmokeMethod((int) methodId, (IntPtr) instanceHandle, (IntPtr) stackPtr, callMessage.ArgCount);
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
					} else if (returnType.IsEnum) {
						returnValue.ReturnValue = Enum.ToObject(returnType, stack[0].s_int);
					} else if (returnType == typeof(int)) {
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
		static extern bool SignalEmit(string signature, string type, IntPtr target, IntPtr sp, int items);

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
							stack[i + 1].s_class = (IntPtr) 0;
						}
					} else if (types[i] == typeof(bool)) {
						stack[i + 1].s_bool = (bool) callMessage.Args[i];
					} else if (types[i] == typeof(sbyte)) {
						stack[i + 1].s_char = (sbyte) callMessage.Args[i];
					} else if (types[i] == typeof(byte)) {
						stack[i + 1].s_uchar = (byte) callMessage.Args[i];
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
						stack[i + 1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					} else {
						stack[i + 1].s_class = (IntPtr) GCHandle.Alloc(callMessage.Args[i]);
					}
				}
			}

			IMethodReturnMessage returnMessage = (IMethodReturnMessage) message;
			MethodReturnMessageWrapper returnValue = new MethodReturnMessageWrapper((IMethodReturnMessage) returnMessage); 
			GCHandle instanceHandle = GCHandle.Alloc(_instance);
			Dictionary<MethodInfo, Qyoto.CPPMethod> signals = Qyoto.GetSignalSignatures(_instance.GetType());
			
			/// should not happen
			if (signals == null) {
				Console.WriteLine("** FATAL: error while retrieving signal signatures **");
				return null;
			}

			Qyoto.CPPMethod signalEntry = signals[(MethodInfo) callMessage.MethodBase];
#if DEBUG
			Console.WriteLine( "Q_SIGNAL signature: {0}", signalEntry.signature );
			Console.WriteLine( "Q_SIGNAL type: {0}", signalEntry.type );
#endif
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
			return returnMessage;
		}

		public override int GetHashCode() {
			return _instance.GetHashCode();
		}
	}
}

