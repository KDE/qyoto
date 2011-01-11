namespace Qyoto {

	using System;

	public partial class QUrl : Object, IDisposable {
		public static implicit operator QUrl(string url) {
			return new QUrl(url);
		}
		
		public static implicit operator string(QUrl url) {
			return url.ToString();
		}
	}
}
