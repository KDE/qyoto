namespace Qyoto {

	using System;
	using System.Collections;
	using System.Text;

	public partial class Qt : MarshalByRefObject {
		public static QApplication qApp = null;

		public static string SIGNAL(string signal) {
			return "2"+ signal;
		}

		public static string SLOT(string slot) {
			return "1" + slot;
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
