namespace Qyoto {

	using System;
	using System.Collections.Generic;

	public partial class QObject : Qt, IDisposable {
		T FindChild<T>(string name) {
			return (T) (object) default(T);
		}

		T FindChild<T>() {
			return FindChild<T>("");
		}

		List<T> FindChildren<T>(string name) {
			return new List<T>();
		}

		List<T> FindChildren<T>() {
			return new List<T>();
		}

		List<T> FindChildren<T>(QRegExp regExp) {
			return new List<T>();
		}
	}
}