//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  Information about I/O (Internet, etc.) protocols supported by KDE.
	///  This class is useful if you want to know which protocols
	///  KDE supports. In addition you can find out lots of information
	///  about a certain protocol. A KProtocolInfo instance represents a
	///  single protocol. Most of the functionality is provided by the static
	///  methods that scan the .protocol files of all installed kioslaves to get
	///  this information.
	///  .protocol files are installed in the "services" resource.
	/// </remarks>		<author> Torben Weis <weis@kde.org>
	///  </author>
	/// 		<short>    Information about I/O (Internet, etc.</short>

	[SmokeClass("KProtocolInfo")]
	public class KProtocolInfo : KSycocaEntry, IDisposable {
 		protected KProtocolInfo(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KProtocolInfo), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KProtocolInfo() {
			staticInterceptor = new SmokeInvocation(typeof(KProtocolInfo), null);
		}
		/// <remarks>
		///  Describes the type of a protocol.
		///    </remarks>		<short>    Describes the type of a protocol.</short>
		public enum TypeOf {
			T_STREAM = 0,
			T_FILESYSTEM = 1,
			T_NONE = 2,
			T_ERROR = 3,
		}
		// KProtocolInfo::ExtraFieldList extraFields(const KUrl& arg1); >>>> NOT CONVERTED
		// KProtocolInfo::FileNameUsedForCopying fileNameUsedForCopying(); >>>> NOT CONVERTED
		/// <remarks>
		///    </remarks>		<short>   </short>
		public KProtocolInfo(QDataStream _str, int offset) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KProtocolInfo#$", "KProtocolInfo(QDataStream&, int)", typeof(void), typeof(QDataStream), _str, typeof(int), offset);
		}
		public bool SupportsListing() {
			return (bool) interceptor.Invoke("supportsListing", "supportsListing() const", typeof(bool));
		}
		public string DefaultMimeType() {
			return (string) interceptor.Invoke("defaultMimeType", "defaultMimeType() const", typeof(string));
		}
		protected bool CanRenameFromFile() {
			return (bool) interceptor.Invoke("canRenameFromFile", "canRenameFromFile() const", typeof(bool));
		}
		protected bool CanRenameToFile() {
			return (bool) interceptor.Invoke("canRenameToFile", "canRenameToFile() const", typeof(bool));
		}
		protected bool CanDeleteRecursive() {
			return (bool) interceptor.Invoke("canDeleteRecursive", "canDeleteRecursive() const", typeof(bool));
		}
		~KProtocolInfo() {
			interceptor.Invoke("~KProtocolInfo", "~KProtocolInfo()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KProtocolInfo", "~KProtocolInfo()", typeof(void));
		}
		/// <remarks>
		///  Returns list of all known protocols.
		/// </remarks>		<return> a list of all known protocols
		///    </return>
		/// 		<short>    Returns list of all known protocols.</short>
		public static List<string> Protocols() {
			return (List<string>) staticInterceptor.Invoke("protocols", "protocols()", typeof(List<string>));
		}
		/// <remarks>
		///  Returns whether a protocol is installed that is able to handle <code>url.</code>
		/// <param> name="url" the url to check
		/// </param></remarks>		<return> true if the protocol is known
		/// </return>
		/// 		<short>    Returns whether a protocol is installed that is able to handle <code>url.</code></short>
		/// 		<see> name</see>
		public static bool IsKnownProtocol(KUrl url) {
			return (bool) staticInterceptor.Invoke("isKnownProtocol#", "isKnownProtocol(const KUrl&)", typeof(bool), typeof(KUrl), url);
		}
		/// <remarks>
		///  Same as above except you can supply just the protocol instead of
		///  the whole URL.
		///    </remarks>		<short>    Same as above except you can supply just the protocol instead of  the whole URL.</short>
		public static bool IsKnownProtocol(string protocol) {
			return (bool) staticInterceptor.Invoke("isKnownProtocol$", "isKnownProtocol(const QString&)", typeof(bool), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the library / executable to open for the protocol <code>protocol</code>
		///  Example : "kio_ftp", meaning either the executable "kio_ftp" or
		///  the library "kio_ftp.la" (recommended), whichever is available.
		///  This corresponds to the "exec=" field in the protocol description file.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the executable of library to open, or string() for
		///          unsupported protocols
		/// </return>
		/// 		<short>    Returns the library / executable to open for the protocol <code>protocol</code>  Example : "kio_ftp", meaning either the executable "kio_ftp" or  the library "kio_ftp.</short>
		/// 		<see> KUrl.Protocol</see>
		public static string Exec(string protocol) {
			return (string) staticInterceptor.Invoke("exec$", "exec(const QString&)", typeof(string), typeof(string), protocol);
		}
		/// <remarks>
		///  Definition of extra fields in the UDS entries, returned by a listDir operation.
		///  This corresponds to the "ExtraNames=" and "ExtraTypes=" fields in the protocol description file.
		///  Those two lists should be separated with ',' in the protocol description file.
		///  See ExtraField for details about names and types
		///    </remarks>		<short>    Definition of extra fields in the UDS entries, returned by a listDir operation.</short>
		/// <remarks>
		///  Returns whether the protocol can act as a helper protocol.
		///  A helper protocol invokes an external application and does not return
		///  a file or stream.
		///  This corresponds to the "helper=" field in the protocol description file.
		///  Valid values for this field are "true" or "false" (default).
		/// <param> name="url" the url to check
		/// </param></remarks>		<return> true if the protocol is a helper protocol (e.g. vnc), false
		///               if not (e.g. http)
		///    </return>
		/// 		<short>    Returns whether the protocol can act as a helper protocol.</short>
		public static bool IsHelperProtocol(KUrl url) {
			return (bool) staticInterceptor.Invoke("isHelperProtocol#", "isHelperProtocol(const KUrl&)", typeof(bool), typeof(KUrl), url);
		}
		/// <remarks>
		///  Same as above except you can supply just the protocol instead of
		///  the whole URL.
		///    </remarks>		<short>    Same as above except you can supply just the protocol instead of  the whole URL.</short>
		public static bool IsHelperProtocol(string protocol) {
			return (bool) staticInterceptor.Invoke("isHelperProtocol$", "isHelperProtocol(const QString&)", typeof(bool), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns whether the protocol can act as a filter protocol.
		///  A filter protocol can operate on data that is passed to it
		///  but does not retrieve/store data itself, like gzip.
		///  A filter protocol is the opposite of a source protocol.
		///  The "source=" field in the protocol description file determines
		///  whether a protocol is a source protocol or a filter protocol.
		///  Valid values for this field are "true" (default) for source protocol or
		///  "false" for filter protocol.
		/// <param> name="url" the url to check
		/// </param></remarks>		<return> true if the protocol is a filter (e.g. gzip), false if the
		///          protocol is a helper or source
		///    </return>
		/// 		<short>    Returns whether the protocol can act as a filter protocol.</short>
		public static bool IsFilterProtocol(KUrl url) {
			return (bool) staticInterceptor.Invoke("isFilterProtocol#", "isFilterProtocol(const KUrl&)", typeof(bool), typeof(KUrl), url);
		}
		/// <remarks>
		///  Same as above except you can supply just the protocol instead of
		///  the whole URL.
		///    </remarks>		<short>    Same as above except you can supply just the protocol instead of  the whole URL.</short>
		public static bool IsFilterProtocol(string protocol) {
			return (bool) staticInterceptor.Invoke("isFilterProtocol$", "isFilterProtocol(const QString&)", typeof(bool), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the name of the icon, associated with the specified protocol.
		///  This corresponds to the "Icon=" field in the protocol description file.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the icon of the protocol, or null if unknown
		///    </return>
		/// 		<short>    Returns the name of the icon, associated with the specified protocol.</short>
		public static string Icon(string protocol) {
			return (string) staticInterceptor.Invoke("icon$", "icon(const QString&)", typeof(string), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the name of the config file associated with the
		///  specified protocol. This is useful if two similar protocols
		///  need to share a single config file, e.g. http and https.
		///  This corresponds to the "config=" field in the protocol description file.
		///  The default is the protocol name, see name()
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the config file, or null if unknown
		///    </return>
		/// 		<short>    Returns the name of the config file associated with the  specified protocol.</short>
		public static string Config(string protocol) {
			return (string) staticInterceptor.Invoke("config$", "config(const QString&)", typeof(string), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the soft limit on the number of slaves for this protocol.
		///  This limits the number of slaves used for a single operation, note
		///  that multiple operations may result in a number of instances that
		///  exceeds this soft limit.
		///  This corresponds to the "maxInstances=" field in the protocol description file.
		///  The default is 1.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the maximum number of slaves, or 1 if unknown
		///    </return>
		/// 		<short>    Returns the soft limit on the number of slaves for this protocol.</short>
		public static int MaxSlaves(string protocol) {
			return (int) staticInterceptor.Invoke("maxSlaves$", "maxSlaves(const QString&)", typeof(int), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns whether mimetypes can be determined based on extension for this
		///  protocol. For some protocols, e.g. http, the filename extension in the URL
		///  can not be trusted to truly reflect the file type.
		///  This corresponds to the "determineMimetypeFromExtension=" field in the protocol description file.
		///  Valid values for this field are "true" (default) or "false".
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> true if the mime types can be determined by extension
		///    </return>
		/// 		<short>    Returns whether mimetypes can be determined based on extension for this  protocol.</short>
		public static bool DetermineMimetypeFromExtension(string protocol) {
			return (bool) staticInterceptor.Invoke("determineMimetypeFromExtension$", "determineMimetypeFromExtension(const QString&)", typeof(bool), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the documentation path for the specified protocol.
		///  This corresponds to the "X-DocPath=" field in the protocol description file.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the docpath of the protocol, or null if unknown
		///    </return>
		/// 		<short>    Returns the documentation path for the specified protocol.</short>
		public static string DocPath(string protocol) {
			return (string) staticInterceptor.Invoke("docPath$", "docPath(const QString&)", typeof(string), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the protocol class for the specified protocol.
		///  This corresponds to the "Class=" field in the protocol description file.
		///  The following classes are defined:
		/// 
		/// <li>
		/// ":internet" for common internet protocols
		/// </li>
		/// 
		/// <li>
		/// ":local" for protocols that access local resources
		/// </li>
		///  Protocol classes always start with a ':' so that they can not be confused with
		///  the protocols themselves.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the class of the protocol, or null if unknown
		///    </return>
		/// 		<short>    Returns the protocol class for the specified protocol.</short>
		public static string ProtocolClass(string protocol) {
			return (string) staticInterceptor.Invoke("protocolClass$", "protocolClass(const QString&)", typeof(string), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns whether file previews should be shown for the specified protocol.
		///  This corresponds to the "ShowPreviews=" field in the protocol description file.
		///  By default previews are shown if protocolClass is :local.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> true if previews should be shown by default, false otherwise
		///    </return>
		/// 		<short>    Returns whether file previews should be shown for the specified protocol.</short>
		public static bool ShowFilePreview(string protocol) {
			return (bool) staticInterceptor.Invoke("showFilePreview$", "showFilePreview(const QString&)", typeof(bool), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the list of capabilities provided by the kioslave implementing
		///  this protocol.
		///  This corresponds to the "Capabilities=" field in the protocol description file.
		///  The capability names are not defined globally, they are up to each
		///  slave implementation. For example when adding support for a new
		///  special command for mounting, one would add the string "Mount" to the
		///  capabilities list, and applications could check for that string
		///  before sending a special() command that would otherwise do nothing
		///  on older kioslave implementations.
		/// <param> name="protocol" the protocol to check
		/// </param></remarks>		<return> the list of capabilities.
		///    </return>
		/// 		<short>    Returns the list of capabilities provided by the kioslave implementing  this protocol.</short>
		public static List<string> Capabilities(string protocol) {
			return (List<string>) staticInterceptor.Invoke("capabilities$", "capabilities(const QString&)", typeof(List<string>), typeof(string), protocol);
		}
		/// <remarks>
		///  Returns the name of the protocol through which the request
		///  will be routed if proxy support is enabled.
		///  A good example of this is the ftp protocol for which proxy
		///  support is commonly handled by the http protocol.
		///  This corresponds to the "ProxiedBy=" in the protocol description file.
		///    </remarks>		<short>    Returns the name of the protocol through which the request  will be routed if proxy support is enabled.</short>
		public static string ProxiedBy(string protocol) {
			return (string) staticInterceptor.Invoke("proxiedBy$", "proxiedBy(const QString&)", typeof(string), typeof(string), protocol);
		}
	}
}
