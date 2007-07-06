//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Text;
	using System.Collections.Generic;

	/// <remarks>
	///  Base class for all Sycoca entries.
	///  You can't create an instance of KSycocaEntry, but it provides
	///  the common functionality for servicetypes and services.
	/// </remarks>		<short>    Base class for all Sycoca entries.</short>
	/// 		<see> http://techbase.kde.org/Development/Architecture/KDE3/System_Configuration_Cache</see>

	[SmokeClass("KSycocaEntry")]
	public abstract class KSycocaEntry : KShared {
 		protected KSycocaEntry(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KSycocaEntry), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KSycocaEntry() {
			staticInterceptor = new SmokeInvocation(typeof(KSycocaEntry), null);
		}
		[SmokeMethod("isType(KSycocaType) const")]
		public virtual bool IsType(int t) {
			return (bool) interceptor.Invoke("isType?", "isType(KSycocaType) const", typeof(bool), typeof(int), t);
		}
		[SmokeMethod("sycocaType() const")]
		public virtual int SycocaType() {
			return (int) interceptor.Invoke("sycocaType", "sycocaType() const", typeof(int));
		}
		/// <remarks>
		///  Default constructor
		///     </remarks>		<short>    Default constructor     </short>
		public KSycocaEntry(string path) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KSycocaEntry$", "KSycocaEntry(const QString&)", typeof(void), typeof(string), path);
		}
		/// <remarks>
		///  Restores itself from a stream.
		///     </remarks>		<short>   </short>
		public KSycocaEntry(QDataStream _str, int iOffset) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KSycocaEntry#$", "KSycocaEntry(QDataStream&, int)", typeof(void), typeof(QDataStream), _str, typeof(int), iOffset);
		}
		/// <remarks>
		/// </remarks>		<return> the name of this entry
		///     </return>
		/// 		<short>   </short>
		[SmokeMethod("name() const")]
		public abstract string Name();
		/// <remarks>
		/// </remarks>		<return> the path of this entry
		///  The path can be absolute or relative.
		///  The corresponding factory should know relative to what.
		///     </return>
		/// 		<short>   </short>
		public string EntryPath() {
			return (string) interceptor.Invoke("entryPath", "entryPath() const", typeof(string));
		}
		/// <remarks>
		/// </remarks>		<return> true if valid
		///     </return>
		/// 		<short>   </short>
		[SmokeMethod("isValid() const")]
		public abstract bool IsValid();
		/// <remarks>
		/// </remarks>		<return> true if deleted
		///     </return>
		/// 		<short>   </short>
		public bool IsDeleted() {
			return (bool) interceptor.Invoke("isDeleted", "isDeleted() const", typeof(bool));
		}
		/// <remarks>
		///  Sets whether or not this service is deleted
		///     </remarks>		<short>    Sets whether or not this service is deleted     </short>
		public void SetDeleted(bool deleted) {
			interceptor.Invoke("setDeleted$", "setDeleted(bool)", typeof(void), typeof(bool), deleted);
		}
		/// <remarks>
		/// </remarks>		<return> the position of the entry in the sycoca file
		///     </return>
		/// 		<short>   </short>
		public int Offset() {
			return (int) interceptor.Invoke("offset", "offset() const", typeof(int));
		}
		/// <remarks>
		///  Save ourselves to the database. Don't forget to call the parent class
		///  first if you override this function.
		///     </remarks>		<short>   </short>
		[SmokeMethod("save(QDataStream&)")]
		public virtual void Save(QDataStream s) {
			interceptor.Invoke("save#", "save(QDataStream&)", typeof(void), typeof(QDataStream), s);
		}
		/// <remarks>
		///  Load ourselves from the database. Don't call the parent class!
		///     </remarks>		<short>   </short>
		[SmokeMethod("load(QDataStream&)")]
		public abstract void Load(QDataStream arg1);
		/// <remarks>
		///  Safe demarshalling functions.
		///     </remarks>		<short>    Safe demarshalling functions.</short>
		public static void Read(QDataStream s, StringBuilder str) {
			staticInterceptor.Invoke("read#$", "read(QDataStream&, QString&)", typeof(void), typeof(QDataStream), s, typeof(StringBuilder), str);
		}
		public static void Read(QDataStream s, List<string> list) {
			staticInterceptor.Invoke("read#?", "read(QDataStream&, QStringList&)", typeof(void), typeof(QDataStream), s, typeof(List<string>), list);
		}
	}
}
