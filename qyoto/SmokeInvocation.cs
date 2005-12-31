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

namespace Qt {

	using Qt;
	
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
		static extern void CallMethod(int methodId, IntPtr target, IntPtr sp, int items);
		
		delegate IntPtr GetIntPtr(IntPtr instance);
		delegate void SetIntPtr(IntPtr instance, IntPtr ptr);
		delegate void RemoveIntPtr(IntPtr ptr);
		delegate IntPtr GetIntPtrFromString(string str);
		delegate string GetStringFromIntPtr(IntPtr ptr);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr StringArrayToCharStarStar(int length, string[] strArray);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern IntPtr StringToQString(string str);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern string StringFromQString(IntPtr ptr);

		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddGetSmokeObject(GetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddSetSmokeObject(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddMapPointer(SetIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddUnmapPointer(RemoveIntPtr callback);
		
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		static extern void AddGetPointerObject(GetIntPtr callback);

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

		static private Hashtable pointerMap = new Hashtable();
		static private GetIntPtr getSmokeObject = new GetIntPtr(GetSmokeObject);
		static private SetIntPtr setSmokeObject = new SetIntPtr(SetSmokeObject);
		
		static private SetIntPtr mapPointer = new SetIntPtr(MapPointer);
		static private RemoveIntPtr unmapPointer = new RemoveIntPtr(UnmapPointer);
		static private GetIntPtr getPointerObject = new GetIntPtr(GetPointerObject);
		
		static private GetIntPtr intPtrToCharStarStar = new GetIntPtr(IntPtrToCharStarStar);
		static private GetStringFromIntPtr intPtrToString = new GetStringFromIntPtr(IntPtrToString);
		static private GetIntPtrFromString intPtrFromString = new GetIntPtrFromString(IntPtrFromString);
		static private GetIntPtr intPtrToQString = new GetIntPtr(IntPtrToQString);
		static private GetIntPtr intPtrFromQString = new GetIntPtr(IntPtrFromQString);
		
		static SmokeInvocation() {
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
		}
		
		private Type	_classToProxy;
		private Object	_instance;
		private string	_className;
		
		public SmokeInvocation(Type classToProxy, Object instance) : base(classToProxy) 
		{
			_classToProxy = classToProxy;
			_instance = instance;
			_className = Regex.Replace(_classToProxy.ToString(), @"^[^\.]*.([^+]*).*", "$1");
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
//			Console.WriteLine(	"ENTER Invoke() MethodName: {0} Type: {1} ArgCount: {2}", 
//								callMessage.MethodName, 
//								callMessage.TypeName, 
//								callMessage.ArgCount.ToString() );

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
//					Console.WriteLine("LEAVE Invoke() ** Missing method **");
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
					} else if (types[i] == typeof(int)) {
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
					CallMethod((int) methods[0], (IntPtr) instanceHandle, (IntPtr) stackPtr, callMessage.ArgCount);
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
						((GCHandle) stack[0].s_class).Free();
					} else {
						returnValue.ReturnValue = ((GCHandle) stack[0].s_class).Target;
					}
				}
			}
						
			instanceHandle.Free();
			returnMessage = returnValue;

//			Console.WriteLine("LEAVE Invoke()");
			return returnMessage;
		}
		
		public override int GetHashCode() {
			return _instance.GetHashCode();
		}
	}

	public class SignalInvocation : RealProxy {
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
			return null;
		}

		public override int GetHashCode() {
			return _instance.GetHashCode();
		}
	}
}

