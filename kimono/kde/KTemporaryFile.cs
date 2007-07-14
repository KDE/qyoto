//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  @brief A QTemporaryFile that will save in the KDE temp directory.
	///  This class derives from QTemporaryFile and makes sure that your temporary
	///  files go in the temporary directory defined by KDE. (This is retrieved by
	///  using KStandardDirs to locate the "tmp" resource.) In general, whenever you
	///  would use a QTemporaryFile() use a KTemporaryFile() instead.
	///  By default the filename will start with your application's instance name,
	///  followed by six random characters and an extension of ".tmp". You can use
	///  setPrefix() and setSuffix() to change the beginning and ending of the random
	///  name, as well as change the directory if you wish (read the descriptions of
	///  these functions for more information). For complex specifications, you may
	///  be better off calling QTemporaryFile.SetFileTemplate() directly.
	///  For example, let's make a new temporary file:
	///  @code
	///  KTemporaryFile temp;
	///  @endcode
	///  This temporary file will currently be stored in the default KDE temporary
	///  directory and have an extension of ".tmp". Now, let's change the directory:
	///  @code
	///  temp.setPrefix("/var/lib/foodata/");
	///  @endcode
	///  Now the temporary file will be stored in "/var/lib/foodata" instead of the
	///  default KDE temporary directory, with an extension of ".tmp". It's important
	///  to remember the leading and trailing slashes to properly define the path!
	///  Next, let's change the suffix to a particular extension:
	///  @code
	///  temp.setSuffix(".pdf");
	///  @endcode
	///  Now the temporary file will be stored in "/var/lib/foodata" and have an
	///  extension of ".pdf" instead of ".tmp".
	///  Once you are done determining the name of the file, call open() to
	///  create the file.
	///  @code
	///  if ( !temp.open() ) {
	///      // handle error...
	///  }
	///  @endcode
	///  If open() is unable to create the file it will return false. If the call to
	///  open() returns true you are ready to use your temporary file. If you don't
	///  want the file removed automatically when the KTemporaryFile object is
	///  destroyed, you need to call setAutoRemove(false), but make sure you have a
	///  good reason for leaving your temp files around.
	/// </remarks>		<author> Jaison Lee <lee.jaison@gmail.com>
	///  </author>
	/// 		<short>    @brief A QTemporaryFile that will save in the KDE temp directory.</short>
	/// 		<see> QTemporaryFile</see>

	[SmokeClass("KTemporaryFile")]
	public class KTemporaryFile : QTemporaryFile, IDisposable {
 		protected KTemporaryFile(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KTemporaryFile), this);
		}
		/// <remarks>
		///  Construct a new KTemporaryFile. The file will be stored in the temporary
		///  directory configured in KDE. The default prefix is the value of the
		///  default KDE temporary directory, plus your application's instance name.
		///  The default suffix is ".tmp".
		///  \param componentData The KComponentData to use for the name of the file and to look up the
		///  directory.
		///      </remarks>		<short>    Construct a new KTemporaryFile.</short>
		public KTemporaryFile(KComponentData componentData) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTemporaryFile#", "KTemporaryFile(const KComponentData&)", typeof(void), typeof(KComponentData), componentData);
		}
		public KTemporaryFile() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTemporaryFile", "KTemporaryFile()", typeof(void));
		}
		/// <remarks>
		///  @brief Sets a prefix to use when creating the file.
		///  This function sets a prefix to use when creating the file. The random
		///  part of the filename will come after this prefix. The prefix can also
		///  change or modify the target directory. If <code>prefix</code> is an absolute
		///  path it will override the default temporary directory. If <code>prefix</code> is
		///  a relative directory it will be relative to the default temporary
		///  location. To set a relative directory for the current working directory
		///  you should use QTemporaryFile.SetFileTemplate() directly.
		/// <param> name="prefix" The prefix to use when creating the file. Remember to
		///   end the prefix with a '/' if you are designating a directory.
		///      </param></remarks>		<short>    @brief Sets a prefix to use when creating the file.</short>
		public void SetPrefix(string prefix) {
			interceptor.Invoke("setPrefix$", "setPrefix(const QString&)", typeof(void), typeof(string), prefix);
		}
		/// <remarks>
		///  @brief Sets a suffix to use when creating the file.
		///  Sets a suffix to use when creating the file. The random part of the
		///  filename will come before this suffix.
		/// <param> name="suffix" The suffix to use when creating the file.
		///      </param></remarks>		<short>    @brief Sets a suffix to use when creating the file.</short>
		public void SetSuffix(string suffix) {
			interceptor.Invoke("setSuffix$", "setSuffix(const QString&)", typeof(void), typeof(string), suffix);
		}
		~KTemporaryFile() {
			interceptor.Invoke("~KTemporaryFile", "~KTemporaryFile()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KTemporaryFile", "~KTemporaryFile()", typeof(void));
		}
		protected new IKTemporaryFileSignals Emit {
			get { return (IKTemporaryFileSignals) Q_EMIT; }
		}
	}

	public interface IKTemporaryFileSignals : IQTemporaryFileSignals {
	}
}