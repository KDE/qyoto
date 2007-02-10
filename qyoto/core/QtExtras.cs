namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;
	using System.Reflection;

	public partial class Qt : MarshalByRefObject {
		public static QApplication qApp = null;

		public static string SIGNAL(string signal) {
			return "2"+ signal;
		}

		public static string SLOT(string slot) {
			return "1" + slot;
		}

		public static void Q_INIT_RESOURCE(string name) {
			string className = "QInitResources_" + name + "__dest_class__";
			// This unfortunately doesn't work because it only looks in the
			// current assembly. Is it possible to force a search of all
			// assemblies?
			Type klass = Type.GetType(className);
			if (klass == null) {
				Console.Error.WriteLine("Q_INIT_RESOURCE: resource '{0}' is missing", name);
				return;
			}
			MethodInfo initResource = klass.GetMethod("QInitResources_" + name);
			initResource.Invoke(null, null);		
		}

		public static void Q_CLEANUP_RESOURCE(string name) {
			string className = "QInitResources_" + name + "__dest_class__";
			Type klass = Type.GetType(className);
			if (klass == null) {
				Console.Error.WriteLine("Q_CLEANUP_RESOURCE: resource '{0}' is missing", name);
				return;
			}
			MethodInfo cleanupResource = klass.GetMethod("QCleanupResources_" + name);
			cleanupResource.Invoke(null, null);
		}

		// These should really use generic types like the C++ originals, but
		// it doesn't seem to work with C#
		public static int QMin(int a, int b) { if (a < b) return a; return b; }
		public static long QMin(long a, long b) { if (a < b) return a; return b; }
		public static float QMin(float a, float b) { if (a < b) return a; return b; }
		public static double QMin(double a, double b) { if (a < b) return a; return b; }

		public static int QMax(int a, int b) { if (a < b) return b; return a; }
		public static long QMax(long a, long b) { if (a < b) return b; return a; }
		public static float QMax(float a, float b) { if (a < b) return b; return a; }
		public static double QMax(double a, double b) { if (a < b) return b; return a; }
	}
}
