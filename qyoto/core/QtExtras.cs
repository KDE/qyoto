namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;
	using System.Reflection;

	public partial class Qt : Object {
		public static QApplication qApp = null;

		public static string SIGNAL(string signal) {
			return "2"+ signal;
		}

		public static string SLOT(string slot) {
			return "1" + slot;
		}

		private static Type findResourceClass(string name) {
			string className = "QInitResources_" + name + "__dest_class__";
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Type klass = null;

			foreach (Assembly assembly in assemblies) {
				klass = assembly.GetType(className);
				if (klass != null) {
					break;
				}
			}

			return klass;
		}

		public static void Q_INIT_RESOURCE(string name) {
			Type klass = findResourceClass(name);
			if (klass == null) {
				Console.Error.WriteLine("Q_INIT_RESOURCE: resource '{0}' is missing", name);
				return;
			}

			MethodInfo initResource = klass.GetMethod("QInitResources_" + name);
			initResource.Invoke(null, null);		
		}

		public static void Q_CLEANUP_RESOURCE(string name) {
			Type klass = findResourceClass(name);
			if (klass == null) {
				Console.Error.WriteLine("Q_CLEANUP_RESOURCE: resource '{0}' is missing", name);
				return;
			}

			MethodInfo cleanupResource = klass.GetMethod("QCleanupResources_" + name);
			cleanupResource.Invoke(null, null);
		}

		public static string QT_TR_NOOP(string text) {
			return text;
		}

		public static string QT_TRANSLATE_NOOP(string klass, string text) {
			return text;
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
