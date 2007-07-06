//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  KServiceTypeProfile represents the user's preferences for services
	///  of a service type.
	///  It consists of a list of services (service offers) for the service type
	///  that is sorted by the user's preference.
	///  KServiceTypeTrader uses KServiceTypeProfile to get results sorted according
	///  to the user's profile.
	/// </remarks>		<short> Represents the user's preferences for services of a service type.</short>
	/// 		<see> KService</see>
	/// 		<see> KServiceType</see>
	/// 		<see> KServiceTypeTrader</see>

	[SmokeClass("KServiceTypeProfile")]
	public class KServiceTypeProfile : Object {
		protected SmokeInvocation interceptor = null;
		private static SmokeInvocation staticInterceptor = null;
		static KServiceTypeProfile() {
			staticInterceptor = new SmokeInvocation(typeof(KServiceTypeProfile), null);
		}
		// void writeServiceTypeProfile(const QString& arg1,const KService::List& arg2,const KService::List& arg3); >>>> NOT CONVERTED
		// void writeServiceTypeProfile(const QString& arg1,const KService::List& arg2); >>>> NOT CONVERTED
		/// <remarks>
		///  Write the complete profile for a given servicetype.
		///  Do not use this for mimetypes.
		/// <param> name="serviceType" The name of the servicetype.
		/// </param><param> name="services" Ordered list of services, from the preferred one to the least preferred one.
		/// </param><param> name="disabledServices" List of services which are normally associated with this serviceType,
		///  but which should be disabled, i.e. trader queries will not return them.
		///      </param></remarks>		<short>    Write the complete profile for a given servicetype.</short>
		/// <remarks>
		///  Delete the complete profile for a given servicetype, reverting to the default
		///  preference order (the one specified by InitialPreference in the .desktop files).
		///  Do not use this for mimetypes.
		/// <param> name="serviceType" The name of the servicetype.
		///      </param></remarks>		<short>    Delete the complete profile for a given servicetype, reverting to the default  preference order (the one specified by InitialPreference in the .</short>
		public static void DeleteServiceTypeProfile(string serviceType) {
			staticInterceptor.Invoke("deleteServiceTypeProfile$", "deleteServiceTypeProfile(const QString&)", typeof(void), typeof(string), serviceType);
		}
		/// <remarks>
		///  This method activates a special mode of KServiceTypeProfile, in which all/all
		///  and all/allfiles are excluded from the results of the queries.
		///  It is meant for the configuration module _only_.
		///      </remarks>		<short>    This method activates a special mode of KServiceTypeProfile, in which all/all  and all/allfiles are excluded from the results of the queries.</short>
		public static void SetConfigurationMode() {
			staticInterceptor.Invoke("setConfigurationMode", "setConfigurationMode()", typeof(void));
		}
		/// <remarks>
		///      </remarks>		<short>   </short>
		public static bool ConfigurationMode() {
			return (bool) staticInterceptor.Invoke("configurationMode", "configurationMode()", typeof(bool));
		}
		/// <remarks>
		///      </remarks>		<short>   </short>
		public static bool HasProfile(string serviceType) {
			return (bool) staticInterceptor.Invoke("hasProfile$", "hasProfile(const QString&)", typeof(bool), typeof(string), serviceType);
		}
		/// <remarks>
		///  Clear all cached information
		///      </remarks>		<short>    Clear all cached information </short>
		public static void ClearCache() {
			staticInterceptor.Invoke("clearCache", "clearCache()", typeof(void));
		}
	}
}
