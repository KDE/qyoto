//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  %KDE Desktop File Management.
	///  This class implements %KDE's support for the freedesktop.org
	///  <em>Desktop Entry Spec</em>.
	/// </remarks>		<author> Pietro Iglio <iglio@kde.org>
	/// </author>
	/// 		<short>    %KDE Desktop File Management.</short>
	/// 		<see> KConfigBase</see>
	/// 		<see> KConfig</see>
	/// 		<see> <a</see>
	/// 		<see> href="http://standards.freedesktop.org/desktop-entry-spec/latest/">Desktop</see>
	/// 		<see> Entry</see>
	/// 		<see> Spec</a></see>

	[SmokeClass("KDesktopFile")]
	public class KDesktopFile : KConfig, IDisposable {
 		protected KDesktopFile(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KDesktopFile), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KDesktopFile() {
			staticInterceptor = new SmokeInvocation(typeof(KDesktopFile), null);
		}
		/// <remarks>
		///  Constructs a KDesktopFile object
		/// <param> name="fileName" The name or path of the desktop file. If it
		///                   is not absolute, it will be located
		///                   using the resource type <code>resType.</code>
		/// </param><param> name="resType" Allows you to change what sort of resource
		///                   to search for if <code>fileName</code> is not absolute.  For
		///                   instance, you might want to specify "config".
		///    </param></remarks>		<short>    Constructs a KDesktopFile object </short>
		public KDesktopFile(string resType, string fileName) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDesktopFile$$", "KDesktopFile(const char*, const QString&)", typeof(void), typeof(string), resType, typeof(string), fileName);
		}
		public KDesktopFile(string fileName) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KDesktopFile$", "KDesktopFile(const QString&)", typeof(void), typeof(string), fileName);
		}
		/// <remarks>
		///  Returns the value of the "Type=" entry.
		/// </remarks>		<return> the type or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Type=" entry.</short>
		public string ReadType() {
			return (string) interceptor.Invoke("readType", "readType() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "Icon=" entry.
		/// </remarks>		<return> the icon or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Icon=" entry.</short>
		public string ReadIcon() {
			return (string) interceptor.Invoke("readIcon", "readIcon() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "Name=" entry.
		/// </remarks>		<return> the name or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Name=" entry.</short>
		public string ReadName() {
			return (string) interceptor.Invoke("readName", "readName() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "Comment=" entry.
		/// </remarks>		<return> the comment or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Comment=" entry.</short>
		public string ReadComment() {
			return (string) interceptor.Invoke("readComment", "readComment() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "GenericName=" entry.
		/// </remarks>		<return> the generic name or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "GenericName=" entry.</short>
		public string ReadGenericName() {
			return (string) interceptor.Invoke("readGenericName", "readGenericName() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "Path=" entry.
		/// </remarks>		<return> the path or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Path=" entry.</short>
		public string ReadPath() {
			return (string) interceptor.Invoke("readPath", "readPath() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "Dev=" entry.
		/// </remarks>		<return> the device or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "Dev=" entry.</short>
		public string ReadDevice() {
			return (string) interceptor.Invoke("readDevice", "readDevice() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "URL=" entry.
		/// </remarks>		<return> the URL or string() if not specified
		///    </return>
		/// 		<short>    Returns the value of the "URL=" entry.</short>
		public string ReadUrl() {
			return (string) interceptor.Invoke("readUrl", "readUrl() const", typeof(string));
		}
		/// <remarks>
		///  Returns a list of the "Actions=" entries.
		/// </remarks>		<return> the list of actions
		///    </return>
		/// 		<short>    Returns a list of the "Actions=" entries.</short>
		public List<string> ReadActions() {
			return (List<string>) interceptor.Invoke("readActions", "readActions() const", typeof(List<string>));
		}
		/// <remarks>
		///  Returns the action group with the given name
		///    </remarks>		<short>    Returns the action group with the given name    </short>
		public KConfigGroup ActionGroup(string group) {
			return (KConfigGroup) interceptor.Invoke("actionGroup$", "actionGroup(const QString&) const", typeof(KConfigGroup), typeof(string), group);
		}
		/// <remarks>
		///  Returns true if the action group exists, false otherwise
		/// <param> name="group" the action group to test
		/// </param></remarks>		<return> true if the action group exists
		///    </return>
		/// 		<short>    Returns true if the action group exists, false otherwise </short>
		public bool HasActionGroup(string group) {
			return (bool) interceptor.Invoke("hasActionGroup$", "hasActionGroup(const QString&) const", typeof(bool), typeof(string), group);
		}
		/// <remarks>
		///  Checks whether there is a "Type=Link" entry.
		///  The link points to the "URL=" entry.
		/// </remarks>		<return> true if there is a "Type=Link" entry
		///    </return>
		/// 		<short>    Checks whether there is a "Type=Link" entry.</short>
		public bool HasLinkType() {
			return (bool) interceptor.Invoke("hasLinkType", "hasLinkType() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether there is an entry "Type=Application".
		/// </remarks>		<return> true if there is a "Type=Application" entry
		///    </return>
		/// 		<short>    Checks whether there is an entry "Type=Application".</short>
		public bool HasApplicationType() {
			return (bool) interceptor.Invoke("hasApplicationType", "hasApplicationType() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether there is an entry "Type=MimeType".
		/// </remarks>		<return> true if there is a "Type=MimeType" entry
		///    </return>
		/// 		<short>    Checks whether there is an entry "Type=MimeType".</short>
		public bool HasMimeTypeType() {
			return (bool) interceptor.Invoke("hasMimeTypeType", "hasMimeTypeType() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether there is an entry "Type=FSDevice".
		/// </remarks>		<return> true if there is a "Type=FSDevice" entry
		///    </return>
		/// 		<short>    Checks whether there is an entry "Type=FSDevice".</short>
		public bool HasDeviceType() {
			return (bool) interceptor.Invoke("hasDeviceType", "hasDeviceType() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether the TryExec field contains a binary
		///  which is found on the local system.
		/// </remarks>		<return> true if TryExec contains an existing binary
		///    </return>
		/// 		<short>    Checks whether the TryExec field contains a binary  which is found on the local system.</short>
		public bool TryExec() {
			return (bool) interceptor.Invoke("tryExec", "tryExec() const", typeof(bool));
		}
		/// <remarks>
		///  Returns the file name.
		/// </remarks>		<return> The filename as passed to the constructor.
		///    </return>
		/// 		<short>    Returns the file name.</short>
		public string FileName() {
			return (string) interceptor.Invoke("fileName", "fileName() const", typeof(string));
		}
		/// <remarks>
		///  Returns the resource.
		/// </remarks>		<return> The resource type as passed to the constructor.
		///    </return>
		/// 		<short>    Returns the resource.</short>
		public string Resource() {
			return (string) interceptor.Invoke("resource", "resource() const", typeof(string));
		}
		/// <remarks>
		///  Returns the value of the "X-DocPath=" Or "DocPath=" entry.
		///  X-DocPath should be used and DocPath is depreciated and will
		///  one day be not supported.
		/// </remarks>		<return> The value of the "X-DocPath=" Or "DocPath=" entry.
		///    </return>
		/// 		<short>    Returns the value of the "X-DocPath=" Or "DocPath=" entry.</short>
		public string ReadDocPath() {
			return (string) interceptor.Invoke("readDocPath", "readDocPath() const", typeof(string));
		}
		/// <remarks>
		///  Returns the entry of the "SortOrder=" entry.
		/// </remarks>		<return> the value of the "SortOrder=" entry.
		///    </return>
		/// 		<short>    Returns the entry of the "SortOrder=" entry.</short>
		public List<string> SortOrder() {
			return (List<string>) interceptor.Invoke("sortOrder", "sortOrder() const", typeof(List<string>));
		}
		/// <remarks>
		///  Copies all entries from this config object to a new
		///  KDesktopFile object that will save itself to <code>file.</code>
		///  Actual saving to <code>file</code> happens when the returned object is
		///  destructed or when sync() is called upon it.
		/// <param> name="file" the new KDesktopFile object it will save itself to.
		///    </param></remarks>		<short>    Copies all entries from this config object to a new  KDesktopFile object that will save itself to <code>file.</code></short>
		public new KDesktopFile CopyTo(string file) {
			return (KDesktopFile) interceptor.Invoke("copyTo$", "copyTo(const QString&) const", typeof(KDesktopFile), typeof(string), file);
		}
		/// <remarks>
		///  Returns the raw data for direct access
		///    </remarks>		<short>    Returns the raw data for direct access    </short>
		public KConfigGroup DesktopGroup() {
			return (KConfigGroup) interceptor.Invoke("desktopGroup", "desktopGroup()", typeof(KConfigGroup));
		}
		~KDesktopFile() {
			interceptor.Invoke("~KDesktopFile", "~KDesktopFile()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KDesktopFile", "~KDesktopFile()", typeof(void));
		}
		/// <remarks>
		///  Checks whether this is really a desktop file.
		///  The check is performed looking at the file extension (the file is not
		///  opened).
		///  Currently, the only valid extension is ".desktop".
		/// <param> name="path" the path of the file to check
		/// </param></remarks>		<return> true if the file appears to be a desktop file.
		///    </return>
		/// 		<short>    Checks whether this is really a desktop file.</short>
		public static bool IsDesktopFile(string path) {
			return (bool) staticInterceptor.Invoke("isDesktopFile$", "isDesktopFile(const QString&)", typeof(bool), typeof(string), path);
		}
		/// <remarks>
		///  Checks whether the user is authorized to run this desktop file.
		///  By default users are authorized to run all desktop files but
		///  the KIOSK framework can be used to activate certain restrictions.
		///  See README.kiosk for more information.
		/// <param> name="path" the file to check
		/// </param></remarks>		<return> true if the user is authorized to run the file
		///    </return>
		/// 		<short>    Checks whether the user is authorized to run this desktop file.</short>
		public static bool IsAuthorizedDesktopFile(string path) {
			return (bool) staticInterceptor.Invoke("isAuthorizedDesktopFile$", "isAuthorizedDesktopFile(const QString&)", typeof(bool), typeof(string), path);
		}
		/// <remarks>
		///  Returns the location where changes for the .desktop file <code>path</code>
		///  should be written to.
		///    </remarks>		<short>    Returns the location where changes for the .</short>
		public static string LocateLocal(string path) {
			return (string) staticInterceptor.Invoke("locateLocal$", "locateLocal(const QString&)", typeof(string), typeof(string), path);
		}
	}
}
