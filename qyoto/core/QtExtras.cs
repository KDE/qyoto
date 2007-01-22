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
	}
}
