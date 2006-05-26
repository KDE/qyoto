namespace Qt
{
	using System;
	using System.Collections;
	using System.Reflection;
	using System.Runtime.InteropServices;
	
	public class Qyoto : System.Object
	{
		[DllImport("libqyoto", CharSet=CharSet.Ansi)]
		public static extern void Init_qyoto();
		
		/// This Hashtable contains a list of classes with their Hashtables for slots. The class name is the key, the slot-hashtable the value.
		public static Hashtable classes = new Hashtable();
		
		public static void GetSlotSignatures(Type t) {
			
			/// Remove the old object if it already exists
			classes.Remove(t.Name);
			
			/// This Hashtable contains the slots of a class. The C++ type signature is the key, the appropriate C# MethodInfo the value.
			Hashtable slots = new Hashtable();
			
			MethodInfo[] mis = t.GetMethods( BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic );
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SLOT), false);
				foreach (Q_SLOT attr in attributes) {
					slots.Add(attr.Signature, mi);
					break;
				}
			}
			
			classes.Add(t.Name, slots);
		}
		
		public static string[] GetSignalSignatures(QObject o) {
			Type iface;
			try {
				iface = GetSignalsInterface(o);
			}
			catch {
				return null;
			}
			MethodInfo[] mis = iface.GetMethods();
			
			/// the interface has no signals...
			if (mis.Length == 0)
				return null;
				
			string[] signatures = new string[mis.Length];
			int i = 0;
			
			foreach (MethodInfo mi in mis) {
				object[] attributes = mi.GetCustomAttributes(typeof(Q_SIGNAL), false);
				foreach (Q_SIGNAL attr in attributes) {
					signatures[i] = attr.Signature;
				}
				i++;
			}
			
			return signatures;
		}
		
		public static Type GetSignalsInterface(QObject o) {
			Type t = o.GetType();
			MethodInfo mi = t.GetMethod("Emit", BindingFlags.Instance | BindingFlags.NonPublic);
			return mi.ReturnType;
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

	[AttributeUsage( AttributeTargets.Method )]
	class Q_SIGNAL : Attribute
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
	}

	[AttributeUsage( AttributeTargets.Method )]
	class Q_SLOT : Attribute
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
	}
}

