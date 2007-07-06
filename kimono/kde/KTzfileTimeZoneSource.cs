//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  A class to read and parse tzfile time zone definition files.
	///  tzfile is the format used by zoneinfo files in the system time zone database.
	///  The format is documented in the tzfile(5) manpage.
	/// </remarks>		<author> David Jarvie <software@astrojar.org.uk>.
	///  </author>
	/// 		<short> Reads and parses tzfile(5) time zone definition files.</short>
	/// 		<see> KTzfileTimeZone</see>
	/// 		<see> KTzfileTimeZoneData</see>
	/// 		<see> @ingroup</see>
	/// 		<see> timezones</see>

	[SmokeClass("KTzfileTimeZoneSource")]
	public class KTzfileTimeZoneSource : KTimeZoneSource, IDisposable {
 		protected KTzfileTimeZoneSource(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KTzfileTimeZoneSource), this);
		}
		/// <remarks>
		///  Constructs a time zone source.
		/// <param> name="location" the local directory containing the time zone definition files
		///      </param></remarks>		<short>    Constructs a time zone source.</short>
		public KTzfileTimeZoneSource(string location) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KTzfileTimeZoneSource$", "KTzfileTimeZoneSource(const QString&)", typeof(void), typeof(string), location);
		}
		/// <remarks>
		///  Returns the local directory containing the time zone definition files.
		/// </remarks>		<return> path to time zone definition files
		///      </return>
		/// 		<short>    Returns the local directory containing the time zone definition files.</short>
		public string Location() {
			return (string) interceptor.Invoke("location", "location()", typeof(string));
		}
		/// <remarks>
		///  Parses a tzfile file to extract detailed information for one time zone.
		/// <param> name="zone" the time zone for which data is to be extracted
		/// </param></remarks>		<return> a KTzfileTimeZoneData instance containing the parsed data.
		///          The caller is responsible for deleting the KTimeZoneData instance.
		///          Null is returned on error.
		///      </return>
		/// 		<short>    Parses a tzfile file to extract detailed information for one time zone.</short>
		[SmokeMethod("parse(const KTimeZone*) const")]
		public override KTimeZoneData Parse(KTimeZone zone) {
			return (KTimeZoneData) interceptor.Invoke("parse#", "parse(const KTimeZone*) const", typeof(KTimeZoneData), typeof(KTimeZone), zone);
		}
		~KTzfileTimeZoneSource() {
			interceptor.Invoke("~KTzfileTimeZoneSource", "~KTzfileTimeZoneSource()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KTzfileTimeZoneSource", "~KTzfileTimeZoneSource()", typeof(void));
		}
	}
}
