//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  Allows encoding and decoding properly remote filenames into Unicode.
	///  Certain protocols do not specify an appropriate encoding for decoding
	///  their 8-bit data into proper Unicode forms. Therefore, ioslaves should
	///  use this class in order to convert those forms into strings before
	///  creating the respective KIO.UDSEntry. The same is true for decoding
	///  URLs to its components.
	///  Each KIO.SlaveBase has one object of this kind, even if it is not necessary.
	///  It can be accessed through KIO.SlaveBase.RemoteEncoding.
	/// </remarks>		<author> Thiago Macieira <thiago.macieira@kdemail.net>
	///  </author>
	/// 		<short> A class for handling remote filenames.</short>

	[SmokeClass("KRemoteEncoding")]
	public class KRemoteEncoding : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KRemoteEncoding(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KRemoteEncoding), this);
		}
		/// <remarks>
		///  Constructor.
		///  Constructs this object to use the given encoding name.
		///  If <code>name</code> is a null pointer, the standard encoding will be used.
		///    </remarks>		<short>    Constructor.</short>
		public KRemoteEncoding(string name) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRemoteEncoding$", "KRemoteEncoding(const char*)", typeof(void), typeof(string), name);
		}
		public KRemoteEncoding() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRemoteEncoding", "KRemoteEncoding()", typeof(void));
		}
		/// <remarks>
		///  Converts the given full pathname or filename to Unicode.
		///  This function is supposed to work for dirnames, filenames
		///  or a full pathname.
		///    </remarks>		<short>    Converts the given full pathname or filename to Unicode.</short>
		public string Decode(QByteArray name) {
			return (string) interceptor.Invoke("decode#", "decode(const QByteArray&) const", typeof(string), typeof(QByteArray), name);
		}
		/// <remarks>
		///  Converts the given name from Unicode.
		///  This function is supposed to work for dirnames, filenames
		///  or a full pathname.
		///    </remarks>		<short>    Converts the given name from Unicode.</short>
		public QByteArray Encode(string name) {
			return (QByteArray) interceptor.Invoke("encode$", "encode(const QString&) const", typeof(QByteArray), typeof(string), name);
		}
		/// <remarks>
		///  Converts the given URL into its 8-bit components
		///    </remarks>		<short>    Converts the given URL into its 8-bit components    </short>
		public QByteArray Encode(KUrl url) {
			return (QByteArray) interceptor.Invoke("encode#", "encode(const KUrl&) const", typeof(QByteArray), typeof(KUrl), url);
		}
		/// <remarks>
		///  Converts the given URL into 8-bit form and separate the
		///  dirname from the filename. This is useful for slave functions
		///  like stat or get.
		///  The dirname is returned with the final slash always stripped
		///    </remarks>		<short>    Converts the given URL into 8-bit form and separate the  dirname from the filename.</short>
		public QByteArray Directory(KUrl url, bool ignore_trailing_slash) {
			return (QByteArray) interceptor.Invoke("directory#$", "directory(const KUrl&, bool) const", typeof(QByteArray), typeof(KUrl), url, typeof(bool), ignore_trailing_slash);
		}
		public QByteArray Directory(KUrl url) {
			return (QByteArray) interceptor.Invoke("directory#", "directory(const KUrl&) const", typeof(QByteArray), typeof(KUrl), url);
		}
		/// <remarks>
		///  Converts the given URL into 8-bit form and retrieve the filename.
		///    </remarks>		<short>    Converts the given URL into 8-bit form and retrieve the filename.</short>
		public QByteArray FileName(KUrl url) {
			return (QByteArray) interceptor.Invoke("fileName#", "fileName(const KUrl&) const", typeof(QByteArray), typeof(KUrl), url);
		}
		/// <remarks>
		///  Returns the encoding being used.
		///    </remarks>		<short>    Returns the encoding being used.</short>
		public string Encoding() {
			return (string) interceptor.Invoke("encoding", "encoding() const", typeof(string));
		}
		/// <remarks>
		///  Returns the MIB for the codec being used.
		///    </remarks>		<short>    Returns the MIB for the codec being used.</short>
		public int EncodingMib() {
			return (int) interceptor.Invoke("encodingMib", "encodingMib() const", typeof(int));
		}
		/// <remarks>
		///  Sets the encoding being used.
		///  This function does not change the global configuration.
		///  Pass a null pointer in <code>name</code> to revert to the standard
		///  encoding.
		///    </remarks>		<short>    Sets the encoding being used.</short>
		public void SetEncoding(string name) {
			interceptor.Invoke("setEncoding$", "setEncoding(const char*)", typeof(void), typeof(string), name);
		}
		~KRemoteEncoding() {
			interceptor.Invoke("~KRemoteEncoding", "~KRemoteEncoding()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KRemoteEncoding", "~KRemoteEncoding()", typeof(void));
		}
	}
}