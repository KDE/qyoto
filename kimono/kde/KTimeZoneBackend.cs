//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;

	/// <remarks>
	///  Base backend class for KTimeZone classes.
	///  KTimeZone and each class inherited from it must have a corresponding
	///  backend class to implement its constructors and its methods,
	///  and to provide a clone() method. This allows KTimeZone methods
	///  to work together with reference counting of private data.
	///  @note Classes derived from KTimeZoneBackend should not normally implement their
	///  own copy constructor or assignment operator, and must have a non-const d-pointer.
	/// </remarks>		<author> David Jarvie <software@astrojar.org.uk>.
	///  </author>
	/// 		<short> Base backend class for KTimeZone classes.</short>
	/// 		<see> KTimeZone</see>
	/// 		<see> @ingroup</see>
	/// 		<see> timezones</see>

	[SmokeClass("KTimeZoneBackend")]
	public class KTimeZoneBackend : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KTimeZoneBackend(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KTimeZoneBackend), this);
		}
		/// <remarks> Implements KTimeZone.KTimeZone(). </remarks>		<short>   Implements KTimeZone.KTimeZone().</short>
		public KTimeZoneBackend() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend", "KTimeZoneBackend()", typeof(void));
		}
		/// <remarks> Implements KTimeZone.KTimeZone(string). </remarks>		<short>   Implements KTimeZone.KTimeZone(string).</short>
		public KTimeZoneBackend(string name) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend$", "KTimeZoneBackend(const QString&)", typeof(void), typeof(string), name);
		}
		public KTimeZoneBackend(KTimeZoneBackend other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#", "KTimeZoneBackend(const KTimeZoneBackend&)", typeof(void), typeof(KTimeZoneBackend), other);
		}
		/// <remarks>
		///  Creates a copy of this instance.
		///  @note Every inherited class must reimplement clone().
		/// </remarks>		<return> new copy
		///      </return>
		/// 		<short>    Creates a copy of this instance.</short>
		[SmokeMethod("clone() const")]
		public virtual KTimeZoneBackend Clone() {
			return (KTimeZoneBackend) interceptor.Invoke("clone", "clone() const", typeof(KTimeZoneBackend));
		}
		/// <remarks>
		///  Returns the class name of the data represented by this instance.
		///  @note Every inherited class must reimplement type().
		/// </remarks>		<return> "KTimeZone" for this base class.
		///      </return>
		/// 		<short>    Returns the class name of the data represented by this instance.</short>
		[SmokeMethod("type() const")]
		public virtual QByteArray type() {
			return (QByteArray) interceptor.Invoke("type", "type() const", typeof(QByteArray));
		}
		/// <remarks>
		///  Implements KTimeZone.OffsetAtZoneTime().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.OffsetAtZoneTime().</short>
		[SmokeMethod("offsetAtZoneTime(const KTimeZone*, const QDateTime&, int*) const")]
		public virtual int OffsetAtZoneTime(KTimeZone caller, QDateTime zoneDateTime, ref int secondOffset) {
			StackItem[] stack = new StackItem[4];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(caller);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(caller);
#endif
#if DEBUG
			stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(zoneDateTime);
#else
			stack[2].s_class = (IntPtr) GCHandle.Alloc(zoneDateTime);
#endif
			stack[3].s_int = secondOffset;
			interceptor.Invoke("offsetAtZoneTime##$", "offsetAtZoneTime(const KTimeZone*, const QDateTime&, int*) const", stack);
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[1].s_class);
#else
			((GCHandle) stack[1].s_class).Free();
#endif
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
			((GCHandle) stack[2].s_class).Free();
#endif
			secondOffset = stack[3].s_int;
			return stack[0].s_int;
		}
		/// <remarks>
		///  Implements KTimeZone.OffsetAtUtc().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.OffsetAtUtc().</short>
		[SmokeMethod("offsetAtUtc(const KTimeZone*, const QDateTime&) const")]
		public virtual int OffsetAtUtc(KTimeZone caller, QDateTime utcDateTime) {
			return (int) interceptor.Invoke("offsetAtUtc##", "offsetAtUtc(const KTimeZone*, const QDateTime&) const", typeof(int), typeof(KTimeZone), caller, typeof(QDateTime), utcDateTime);
		}
		/// <remarks>
		///  Implements KTimeZone.Offset().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.Offset().</short>
		[SmokeMethod("offset(const KTimeZone*, time_t) const")]
		public virtual int Offset(KTimeZone caller, int t) {
			return (int) interceptor.Invoke("offset#$", "offset(const KTimeZone*, time_t) const", typeof(int), typeof(KTimeZone), caller, typeof(int), t);
		}
		/// <remarks>
		///  Implements KTimeZone.IsDstAtUtc().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.IsDstAtUtc().</short>
		[SmokeMethod("isDstAtUtc(const KTimeZone*, const QDateTime&) const")]
		public virtual bool IsDstAtUtc(KTimeZone caller, QDateTime utcDateTime) {
			return (bool) interceptor.Invoke("isDstAtUtc##", "isDstAtUtc(const KTimeZone*, const QDateTime&) const", typeof(bool), typeof(KTimeZone), caller, typeof(QDateTime), utcDateTime);
		}
		/// <remarks>
		///  Implements KTimeZone.IsDst().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.IsDst().</short>
		[SmokeMethod("isDst(const KTimeZone*, time_t) const")]
		public virtual bool IsDst(KTimeZone caller, int t) {
			return (bool) interceptor.Invoke("isDst#$", "isDst(const KTimeZone*, time_t) const", typeof(bool), typeof(KTimeZone), caller, typeof(int), t);
		}
		/// <remarks>
		///  Implements KTimeZone.HasTransitions().
		/// <param> name="caller" calling KTimeZone object
		///      </param></remarks>		<short>    Implements KTimeZone.HasTransitions().</short>
		[SmokeMethod("hasTransitions(const KTimeZone*) const")]
		public virtual bool HasTransitions(KTimeZone caller) {
			return (bool) interceptor.Invoke("hasTransitions#", "hasTransitions(const KTimeZone*) const", typeof(bool), typeof(KTimeZone), caller);
		}
		/// <remarks>
		///  Constructs a time zone.
		/// <param> name="source" reader/parser for the database containing this time zone. This will
		///                     be an instance of a class derived from KTimeZoneSource.
		/// </param><param> name="name" in system-dependent format. The name must be unique within any
		///                     KTimeZones instance which contains this KTimeZone.
		/// </param><param> name="countryCode" ISO 3166 2-character country code, empty if unknown
		/// </param><param> name="latitude" in degrees (between -90 and +90), UNKNOWN if not known
		/// </param><param> name="longitude" in degrees (between -180 and +180), UNKNOWN if not known
		/// </param><param> name="comment" description of the time zone, if any
		///      </param></remarks>		<short>    Constructs a time zone.</short>
		public KTimeZoneBackend(KTimeZoneSource source, string name, string countryCode, float latitude, float longitude, string comment) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#$$$$$", "KTimeZoneBackend(KTimeZoneSource*, const QString&, const QString&, float, float, const QString&)", typeof(void), typeof(KTimeZoneSource), source, typeof(string), name, typeof(string), countryCode, typeof(float), latitude, typeof(float), longitude, typeof(string), comment);
		}
		public KTimeZoneBackend(KTimeZoneSource source, string name, string countryCode, float latitude, float longitude) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#$$$$", "KTimeZoneBackend(KTimeZoneSource*, const QString&, const QString&, float, float)", typeof(void), typeof(KTimeZoneSource), source, typeof(string), name, typeof(string), countryCode, typeof(float), latitude, typeof(float), longitude);
		}
		public KTimeZoneBackend(KTimeZoneSource source, string name, string countryCode, float latitude) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#$$$", "KTimeZoneBackend(KTimeZoneSource*, const QString&, const QString&, float)", typeof(void), typeof(KTimeZoneSource), source, typeof(string), name, typeof(string), countryCode, typeof(float), latitude);
		}
		public KTimeZoneBackend(KTimeZoneSource source, string name, string countryCode) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#$$", "KTimeZoneBackend(KTimeZoneSource*, const QString&, const QString&)", typeof(void), typeof(KTimeZoneSource), source, typeof(string), name, typeof(string), countryCode);
		}
		public KTimeZoneBackend(KTimeZoneSource source, string name) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTimeZoneBackend#$", "KTimeZoneBackend(KTimeZoneSource*, const QString&)", typeof(void), typeof(KTimeZoneSource), source, typeof(string), name);
		}
		~KTimeZoneBackend() {
			interceptor.Invoke("~KTimeZoneBackend", "~KTimeZoneBackend()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KTimeZoneBackend", "~KTimeZoneBackend()", typeof(void));
		}
	}
}
