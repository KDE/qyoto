//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;

	/// <remarks>
	///  To open files with their associated applications in KDE, use KRun.
	///  It can execute any desktop entry, as well as any file, using
	///  the default application or another application "bound" to the file type
	///  (or URL protocol).
	///  In that example, the mimetype of the file is not known by the application,
	///  so a KRun instance must be created. It will determine the mimetype by itself.
	///  If the mimetype is known, or if you even know the service (application) to
	///  use for this file, use one of the static methods.
	///  By default KRun uses auto deletion. It causes the KRun instance to delete
	///  itself when the it finished its task. If you allocate the KRun
	///  object on the stack you must disable auto deletion, otherwise it will crash.
	///  See <see cref="IKRunSignals"></see> for signals emitted by KRun
	/// </remarks>		<short> Opens files with their associated applications in KDE.</short>

	[SmokeClass("KRun")]
	public class KRun : QObject, IDisposable {
 		protected KRun(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KRun), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KRun() {
			staticInterceptor = new SmokeInvocation(typeof(KRun), null);
		}
		/// <remarks>
		/// <param> name="url" the URL of the file or directory to 'run'
		/// </param><param> name="window"         The top-level widget of the app that invoked this object.
		///         It is used to make sure private information like passwords
		///         are properly handled per application.
		/// </param><param> name="mode" The <code>st_mode</code> field of <tt>struct stat</tt>. If
		///         you don't know this set it to 0.
		/// </param><param> name="isLocalFile"         If this parameter is set to <code>false</code> then <code>url</code> is
		///         examined to find out whether it is a local URL or
		///         not. This flag is just used to improve speed, since the
		///         function KUrl.IsLocalFile is a bit slow.
		/// </param><param> name="showProgressInfo"         Whether to show progress information when determining the
		///         type of the file (i.e. when using KIO.Stat and KIO.Mimetype)
		///         Before you set this to false to avoid a dialog box, think about
		///         a very slow FTP server...
		///         It is always better to provide progress info in such cases.
		/// </param><param> name="asn"         Application startup notification id, if available (otherwise "").
		///    </param></remarks>		<short>   </short>
		public KRun(KUrl url, QWidget window, long mode, bool isLocalFile, bool showProgressInfo, QByteArray asn) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRun##$$$#", "KRun(const KUrl&, QWidget*, mode_t, bool, bool, const QByteArray&)", typeof(void), typeof(KUrl), url, typeof(QWidget), window, typeof(long), mode, typeof(bool), isLocalFile, typeof(bool), showProgressInfo, typeof(QByteArray), asn);
		}
		public KRun(KUrl url, QWidget window, long mode, bool isLocalFile, bool showProgressInfo) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRun##$$$", "KRun(const KUrl&, QWidget*, mode_t, bool, bool)", typeof(void), typeof(KUrl), url, typeof(QWidget), window, typeof(long), mode, typeof(bool), isLocalFile, typeof(bool), showProgressInfo);
		}
		public KRun(KUrl url, QWidget window, long mode, bool isLocalFile) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRun##$$", "KRun(const KUrl&, QWidget*, mode_t, bool)", typeof(void), typeof(KUrl), url, typeof(QWidget), window, typeof(long), mode, typeof(bool), isLocalFile);
		}
		public KRun(KUrl url, QWidget window, long mode) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRun##$", "KRun(const KUrl&, QWidget*, mode_t)", typeof(void), typeof(KUrl), url, typeof(QWidget), window, typeof(long), mode);
		}
		public KRun(KUrl url, QWidget window) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KRun##", "KRun(const KUrl&, QWidget*)", typeof(void), typeof(KUrl), url, typeof(QWidget), window);
		}
		/// <remarks>
		///  Abort this KRun. This kills any jobs launched by it,
		///  and leads to deletion if auto-deletion is on.
		///  This is much safer than deleting the KRun (in case it's
		///  currently showing an error dialog box, for instance)
		///    </remarks>		<short>    Abort this KRun.</short>
		public void Abort() {
			interceptor.Invoke("abort", "abort()", typeof(void));
		}
		/// <remarks>
		///  Returns true if the KRun instance has an error.
		/// </remarks>		<return> true when an error occurred
		/// </return>
		/// 		<short>    Returns true if the KRun instance has an error.</short>
		/// 		<see> error</see>
		public bool HasError() {
			return (bool) interceptor.Invoke("hasError", "hasError() const", typeof(bool));
		}
		/// <remarks>
		///  Returns true if the KRun instance has finished.
		/// </remarks>		<return> true if the KRun instance has finished
		/// </return>
		/// 		<short>    Returns true if the KRun instance has finished.</short>
		/// 		<see> finished</see>
		public bool HasFinished() {
			return (bool) interceptor.Invoke("hasFinished", "hasFinished() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether auto delete is activated.
		///  Auto-deletion causes the KRun instance to delete itself
		///  when it finished its task.
		///  By default auto deletion is on.
		/// </remarks>		<return> true if auto deletion is on, false otherwise
		///    </return>
		/// 		<short>    Checks whether auto delete is activated.</short>
		public bool AutoDelete() {
			return (bool) interceptor.Invoke("autoDelete", "autoDelete() const", typeof(bool));
		}
		/// <remarks>
		///  Enables or disabled auto deletion.
		///  Auto deletion causes the KRun instance to delete itself
		///  when it finished its task. If you allocate the KRun
		///  object on the stack you must disable auto deletion.
		///  By default auto deletion is on.
		/// <param> name="b" true to enable auto deletion, false to disable
		///    </param></remarks>		<short>    Enables or disabled auto deletion.</short>
		public void SetAutoDelete(bool b) {
			interceptor.Invoke("setAutoDelete$", "setAutoDelete(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		///  Set the preferred service for opening this URL, after
		///  its mimetype will have been found by KRun. IMPORTANT: the service is
		///  only used if its configuration says it can handle this mimetype.
		///  This is used for instance for the X-KDE-LastOpenedWith key, for
		///  the recent documents list.
		/// <param> name="desktopEntryName" the desktopEntryName of the service, e.g. "kate".
		///    </param></remarks>		<short>    Set the preferred service for opening this URL, after  its mimetype will have been found by KRun.</short>
		public void SetPreferredService(string desktopEntryName) {
			interceptor.Invoke("setPreferredService$", "setPreferredService(const QString&)", typeof(void), typeof(string), desktopEntryName);
		}
		/// <remarks>
		///  Sets whether executables, .desktop files or shell scripts should
		///  be run by KRun. This is enabled by default.
		/// <param> name="b" whether to run executable files or not.
		/// </param></remarks>		<short>    Sets whether executables, .</short>
		/// 		<see> isExecutable</see>
		public void SetRunExecutables(bool b) {
			interceptor.Invoke("setRunExecutables$", "setRunExecutables(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		///  Sets whether the external webbrowser setting should be honoured.
		///  This is enabled by default.
		///  This should only be disabled in webbrowser applications.
		/// <param> name="b" whether to enable the external browser or not.
		///    </param></remarks>		<short>    Sets whether the external webbrowser setting should be honoured.</short>
		public void SetEnableExternalBrowser(bool b) {
			interceptor.Invoke("setEnableExternalBrowser$", "setEnableExternalBrowser(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		///  Sets the file name to use in the case of downloading the file to a tempfile
		///  in order to give to a non-url-aware application. Some apps rely on the extension
		///  to determine the mimetype of the file. Usually the file name comes from the URL,
		///  but in the case of the HTTP Content-Disposition header, we need to override the
		///  file name.
		///    </remarks>		<short>    Sets the file name to use in the case of downloading the file to a tempfile  in order to give to a non-url-aware application.</short>
		public void SetSuggestedFileName(string fileName) {
			interceptor.Invoke("setSuggestedFileName$", "setSuggestedFileName(const QString&)", typeof(void), typeof(string), fileName);
		}
		/// <remarks>
		///  Suggested file name given by the server (e.g. HTTP content-disposition)
		///    </remarks>		<short>    Suggested file name given by the server (e.</short>
		public string SuggestedFileName() {
			return (string) interceptor.Invoke("suggestedFileName", "suggestedFileName() const", typeof(string));
		}
		[SmokeMethod("init()")]
		protected virtual void Init() {
			interceptor.Invoke("init", "init()", typeof(void));
		}
		[SmokeMethod("scanFile()")]
		protected virtual void ScanFile() {
			interceptor.Invoke("scanFile", "scanFile()", typeof(void));
		}
		/// <remarks>
		///  Called if the mimetype has been detected. The function checks
		///  whether the document <XXX - what?> and appends the gzip protocol to the
		///  URL. Otherwise runUrl is called to finish the job.
		///    </remarks>		<short>    Called if the mimetype has been detected.</short>
		[SmokeMethod("foundMimeType(const QString&)")]
		protected virtual void FoundMimeType(string type) {
			interceptor.Invoke("foundMimeType$", "foundMimeType(const QString&)", typeof(void), typeof(string), type);
		}
		[SmokeMethod("killJob()")]
		protected virtual void KillJob() {
			interceptor.Invoke("killJob", "killJob()", typeof(void));
		}
		[Q_SLOT("void slotTimeout()")]
		protected void SlotTimeout() {
			interceptor.Invoke("slotTimeout", "slotTimeout()", typeof(void));
		}
		[Q_SLOT("void slotScanFinished(KJob*)")]
		protected void SlotScanFinished(KJob arg1) {
			interceptor.Invoke("slotScanFinished#", "slotScanFinished(KJob*)", typeof(void), typeof(KJob), arg1);
		}
		[Q_SLOT("void slotScanMimeType(KIO::Job*, const QString&)")]
		protected void SlotScanMimeType(KIO.Job arg1, string type) {
			interceptor.Invoke("slotScanMimeType#$", "slotScanMimeType(KIO::Job*, const QString&)", typeof(void), typeof(KIO.Job), arg1, typeof(string), type);
		}
		[Q_SLOT("void slotStatResult(KJob*)")]
		[SmokeMethod("slotStatResult(KJob*)")]
		protected virtual void SlotStatResult(KJob arg1) {
			interceptor.Invoke("slotStatResult#", "slotStatResult(KJob*)", typeof(void), typeof(KJob), arg1);
		}
		~KRun() {
			interceptor.Invoke("~KRun", "~KRun()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KRun", "~KRun()", typeof(void));
		}
		/// <remarks>
		///  Open a list of URLs with a certain service (application).
		/// <param> name="service" the service to run
		/// </param><param> name="urls" the list of URLs, can be empty (app launched
		///         without argument)
		/// </param><param> name="window" The top-level widget of the app that invoked this object.
		/// </param><param> name="tempFiles" if true and urls are local files, they will be deleted
		///         when the application exits.
		/// </param><param> name="suggestedFileName" see setSuggestedFileName
		/// </param><param> name="asn" Application startup notification id, if any (otherwise "").
		/// </param></remarks>		<return> @c true on success, @c false on error
		///    </return>
		/// 		<short>    Open a list of URLs with a certain service (application).</short>
		public static bool Run(KService service, List<KUrl> urls, QWidget window, bool tempFiles, string suggestedFileName, QByteArray asn) {
			return (bool) staticInterceptor.Invoke("run#?#$$#", "run(const KService&, const KUrl::List&, QWidget*, bool, const QString&, const QByteArray&)", typeof(bool), typeof(KService), service, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(bool), tempFiles, typeof(string), suggestedFileName, typeof(QByteArray), asn);
		}
		public static bool Run(KService service, List<KUrl> urls, QWidget window, bool tempFiles, string suggestedFileName) {
			return (bool) staticInterceptor.Invoke("run#?#$$", "run(const KService&, const KUrl::List&, QWidget*, bool, const QString&)", typeof(bool), typeof(KService), service, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(bool), tempFiles, typeof(string), suggestedFileName);
		}
		public static bool Run(KService service, List<KUrl> urls, QWidget window, bool tempFiles) {
			return (bool) staticInterceptor.Invoke("run#?#$", "run(const KService&, const KUrl::List&, QWidget*, bool)", typeof(bool), typeof(KService), service, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(bool), tempFiles);
		}
		public static bool Run(KService service, List<KUrl> urls, QWidget window) {
			return (bool) staticInterceptor.Invoke("run#?#", "run(const KService&, const KUrl::List&, QWidget*)", typeof(bool), typeof(KService), service, typeof(List<KUrl>), urls, typeof(QWidget), window);
		}
		/// <remarks>
		///  Open a list of URLs with.
		/// <param> name="exec" the name of the executable, for example
		///         "/usr/bin/netscape".
		/// </param><param> name="urls" the list of URLs to open, can be empty (app launched without argument)
		/// </param><param> name="window" The top-level widget of the app that invoked this object.
		/// </param><param> name="name" the logical name of the application, for example
		///         "Netscape 4.06".
		/// </param><param> name="icon" the icon which should be used by the application.
		/// </param><param> name="asn" Application startup notification id, if any (otherwise "").
		/// </param></remarks>		<return> @c true on success, @c false on error
		///    </return>
		/// 		<short>    Open a list of URLs with.</short>
		public static bool Run(string exec, List<KUrl> urls, QWidget window, string name, string icon, QByteArray asn) {
			return (bool) staticInterceptor.Invoke("run$?#$$#", "run(const QString&, const KUrl::List&, QWidget*, const QString&, const QString&, const QByteArray&)", typeof(bool), typeof(string), exec, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(string), name, typeof(string), icon, typeof(QByteArray), asn);
		}
		public static bool Run(string exec, List<KUrl> urls, QWidget window, string name, string icon) {
			return (bool) staticInterceptor.Invoke("run$?#$$", "run(const QString&, const KUrl::List&, QWidget*, const QString&, const QString&)", typeof(bool), typeof(string), exec, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(string), name, typeof(string), icon);
		}
		public static bool Run(string exec, List<KUrl> urls, QWidget window, string name) {
			return (bool) staticInterceptor.Invoke("run$?#$", "run(const QString&, const KUrl::List&, QWidget*, const QString&)", typeof(bool), typeof(string), exec, typeof(List<KUrl>), urls, typeof(QWidget), window, typeof(string), name);
		}
		public static bool Run(string exec, List<KUrl> urls, QWidget window) {
			return (bool) staticInterceptor.Invoke("run$?#", "run(const QString&, const KUrl::List&, QWidget*)", typeof(bool), typeof(string), exec, typeof(List<KUrl>), urls, typeof(QWidget), window);
		}
		/// <remarks>
		///  Open the given URL.
		///  This function is used after the mime type
		///  is found out. It will search for all services which can handle
		///  the mime type and call run() afterwards.
		/// <param> name="url" the URL to open
		/// </param><param> name="mimetype" the mime type of the resource
		/// </param><param> name="window" The top-level widget of the app that invoked this object.
		/// </param><param> name="tempFile" if true and url is a local file, it will be deleted
		///         when the launched application exits.
		/// </param><param> name="runExecutables" if false then local .desktop files,
		///         executables and shell scripts will not be run.
		///         See also isExecutable().
		/// </param><param> name="suggestedFileName" see setSuggestedFileName
		/// </param><param> name="asn" Application startup notification id, if any (otherwise "").
		/// </param></remarks>		<return> @c true on success, @c false on error
		///    </return>
		/// 		<short>    Open the given URL.</short>
		public static bool RunUrl(KUrl url, string mimetype, QWidget window, bool tempFile, bool runExecutables, string suggestedFileName, QByteArray asn) {
			return (bool) staticInterceptor.Invoke("runUrl#$#$$$#", "runUrl(const KUrl&, const QString&, QWidget*, bool, bool, const QString&, const QByteArray&)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype, typeof(QWidget), window, typeof(bool), tempFile, typeof(bool), runExecutables, typeof(string), suggestedFileName, typeof(QByteArray), asn);
		}
		public static bool RunUrl(KUrl url, string mimetype, QWidget window, bool tempFile, bool runExecutables, string suggestedFileName) {
			return (bool) staticInterceptor.Invoke("runUrl#$#$$$", "runUrl(const KUrl&, const QString&, QWidget*, bool, bool, const QString&)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype, typeof(QWidget), window, typeof(bool), tempFile, typeof(bool), runExecutables, typeof(string), suggestedFileName);
		}
		public static bool RunUrl(KUrl url, string mimetype, QWidget window, bool tempFile, bool runExecutables) {
			return (bool) staticInterceptor.Invoke("runUrl#$#$$", "runUrl(const KUrl&, const QString&, QWidget*, bool, bool)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype, typeof(QWidget), window, typeof(bool), tempFile, typeof(bool), runExecutables);
		}
		public static bool RunUrl(KUrl url, string mimetype, QWidget window, bool tempFile) {
			return (bool) staticInterceptor.Invoke("runUrl#$#$", "runUrl(const KUrl&, const QString&, QWidget*, bool)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype, typeof(QWidget), window, typeof(bool), tempFile);
		}
		public static bool RunUrl(KUrl url, string mimetype, QWidget window) {
			return (bool) staticInterceptor.Invoke("runUrl#$#", "runUrl(const KUrl&, const QString&, QWidget*)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype, typeof(QWidget), window);
		}
		/// <remarks>
		///  Run the given shell command and notifies kicker of the starting
		///  of the application. If the program to be called doesn't exist,
		///  an error box will be displayed.
		///  Use only when you know the full command line. Otherwise use the other
		///  static methods, or KRun's constructor.
		///  <code>cmd</code> must be a shell command. You must not append "&"
		///  to it, since the function will do that for you.
		/// <param> name="window" The top-level widget of the app that invoked this object.
		/// </param></remarks>		<return> @c true on success, @c false on error
		///    </return>
		/// 		<short>    Run the given shell command and notifies kicker of the starting  of the application.</short>
		public static bool RunCommand(string cmd, QWidget window) {
			return (bool) staticInterceptor.Invoke("runCommand$#", "runCommand(const QString&, QWidget*)", typeof(bool), typeof(string), cmd, typeof(QWidget), window);
		}
		/// <remarks>
		///  Same as the other runCommand(), but it also takes the name of the
		///  binary, to display an error message in case it couldn't find it.
		/// <param> name="cmd" must be a shell command. You must not append "&"
		///  to it, since the function will do that for you.
		/// </param><param> name="execName" the name of the executable
		/// </param><param> name="icon" icon for app starting notification
		/// </param><param> name="window" The top-level widget of the app that invoked this object.
		/// </param><param> name="asn" Application startup notification id, if any (otherwise "").
		/// </param></remarks>		<return> @c true on success, @c false on error
		///    </return>
		/// 		<short>    Same as the other runCommand(), but it also takes the name of the  binary, to display an error message in case it couldn't find it.</short>
		public static bool RunCommand(string cmd, string execName, string icon, QWidget window, QByteArray asn) {
			return (bool) staticInterceptor.Invoke("runCommand$$$##", "runCommand(const QString&, const QString&, const QString&, QWidget*, const QByteArray&)", typeof(bool), typeof(string), cmd, typeof(string), execName, typeof(string), icon, typeof(QWidget), window, typeof(QByteArray), asn);
		}
		public static bool RunCommand(string cmd, string execName, string icon, QWidget window) {
			return (bool) staticInterceptor.Invoke("runCommand$$$#", "runCommand(const QString&, const QString&, const QString&, QWidget*)", typeof(bool), typeof(string), cmd, typeof(string), execName, typeof(string), icon, typeof(QWidget), window);
		}
		/// <remarks>
		///  Display the Open-With dialog for those URLs, and run the chosen application.
		/// <param> name="lst" the list of applications to run
		/// </param><param> name="window" The top-level widget of the app that invoked this object.
		/// </param><param> name="tempFiles" if true and lst are local files, they will be deleted
		///         when the application exits.
		/// </param><param> name="suggestedFileName" see setSuggestedFileName
		/// </param><param> name="asn" Application startup notification id, if any (otherwise "").
		/// </param></remarks>		<return> false if the dialog was canceled
		///    </return>
		/// 		<short>    Display the Open-With dialog for those URLs, and run the chosen application.</short>
		public static bool DisplayOpenWithDialog(List<KUrl> lst, QWidget window, bool tempFiles, string suggestedFileName, QByteArray asn) {
			return (bool) staticInterceptor.Invoke("displayOpenWithDialog?#$$#", "displayOpenWithDialog(const KUrl::List&, QWidget*, bool, const QString&, const QByteArray&)", typeof(bool), typeof(List<KUrl>), lst, typeof(QWidget), window, typeof(bool), tempFiles, typeof(string), suggestedFileName, typeof(QByteArray), asn);
		}
		public static bool DisplayOpenWithDialog(List<KUrl> lst, QWidget window, bool tempFiles, string suggestedFileName) {
			return (bool) staticInterceptor.Invoke("displayOpenWithDialog?#$$", "displayOpenWithDialog(const KUrl::List&, QWidget*, bool, const QString&)", typeof(bool), typeof(List<KUrl>), lst, typeof(QWidget), window, typeof(bool), tempFiles, typeof(string), suggestedFileName);
		}
		public static bool DisplayOpenWithDialog(List<KUrl> lst, QWidget window, bool tempFiles) {
			return (bool) staticInterceptor.Invoke("displayOpenWithDialog?#$", "displayOpenWithDialog(const KUrl::List&, QWidget*, bool)", typeof(bool), typeof(List<KUrl>), lst, typeof(QWidget), window, typeof(bool), tempFiles);
		}
		public static bool DisplayOpenWithDialog(List<KUrl> lst, QWidget window) {
			return (bool) staticInterceptor.Invoke("displayOpenWithDialog?#", "displayOpenWithDialog(const KUrl::List&, QWidget*)", typeof(bool), typeof(List<KUrl>), lst, typeof(QWidget), window);
		}
		/// <remarks>
		///  Processes a Exec= line as found in .desktop files.
		/// <param> name="_service" the service to extract information from.
		/// </param><param> name="_urls" The urls the service should open.
		/// </param><param> name="tempFiles" if true and urls are local files, they will be deleted
		///         when the application exits.
		/// </param><param> name="suggestedFileName" see setSuggestedFileName
		/// </param></remarks>		<return> a list of arguments suitable for KProcess.SetProgram().
		///    </return>
		/// 		<short>    Processes a Exec= line as found in .</short>
		public static List<string> ProcessDesktopExec(KService _service, List<KUrl> _urls, bool tempFiles, string suggestedFileName) {
			return (List<string>) staticInterceptor.Invoke("processDesktopExec#?$$", "processDesktopExec(const KService&, const KUrl::List&, bool, const QString&)", typeof(List<string>), typeof(KService), _service, typeof(List<KUrl>), _urls, typeof(bool), tempFiles, typeof(string), suggestedFileName);
		}
		public static List<string> ProcessDesktopExec(KService _service, List<KUrl> _urls, bool tempFiles) {
			return (List<string>) staticInterceptor.Invoke("processDesktopExec#?$", "processDesktopExec(const KService&, const KUrl::List&, bool)", typeof(List<string>), typeof(KService), _service, typeof(List<KUrl>), _urls, typeof(bool), tempFiles);
		}
		public static List<string> ProcessDesktopExec(KService _service, List<KUrl> _urls) {
			return (List<string>) staticInterceptor.Invoke("processDesktopExec#?", "processDesktopExec(const KService&, const KUrl::List&)", typeof(List<string>), typeof(KService), _service, typeof(List<KUrl>), _urls);
		}
		/// <remarks>
		///  Given a full command line (e.g. the Exec= line from a .desktop file),
		///  extract the name of the binary being run.
		/// <param> name="execLine" the full command line
		/// </param><param> name="removePath" if true, remove a (relative or absolute) path. E.g. /usr/bin/ls becomes ls.
		/// </param></remarks>		<return> the name of the binary to run
		///    </return>
		/// 		<short>    Given a full command line (e.</short>
		public static string BinaryName(string execLine, bool removePath) {
			return (string) staticInterceptor.Invoke("binaryName$$", "binaryName(const QString&, bool)", typeof(string), typeof(string), execLine, typeof(bool), removePath);
		}
		/// <remarks>
		///  Returns whether <code>serviceType</code> refers to an executable program instead
		///  of a data file.
		///    </remarks>		<short>    Returns whether <code>serviceType</code> refers to an executable program instead  of a data file.</short>
		public static bool IsExecutable(string serviceType) {
			return (bool) staticInterceptor.Invoke("isExecutable$", "isExecutable(const QString&)", typeof(bool), typeof(string), serviceType);
		}
		/// <remarks>
		///  Returns whether the <code>url</code> of <code>mimetype</code> is executable.
		///  To be executable the file must pass the following rules:
		///  -# Must reside on the local filesystem.
		///  -# Must be marked as executable for the user by the filesystem.
		///  -# The mime type must inherit application/x-executable or application/x-executable-script.
		///  To allow a script to run when the above rules are satisfied add the entry
		///  @code
		///  X-KDE-IsAlso=application/x-executable-script
		///  @endcode
		///  to the mimetype's desktop file.
		///    </remarks>		<short>    Returns whether the <code>url</code> of <code>mimetype</code> is executable.</short>
		public static bool IsExecutableFile(KUrl url, string mimetype) {
			return (bool) staticInterceptor.Invoke("isExecutableFile#$", "isExecutableFile(const KUrl&, const QString&)", typeof(bool), typeof(KUrl), url, typeof(string), mimetype);
		}
		/// <remarks>
		///     </remarks>		<short>   </short>
		public static bool CheckStartupNotify(string binName, KService service, ref bool silent_arg, QByteArray wmclass_arg) {
			StackItem[] stack = new StackItem[5];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(binName);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(binName);
#endif
#if DEBUG
			stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(service);
#else
			stack[2].s_class = (IntPtr) GCHandle.Alloc(service);
#endif
			stack[3].s_bool = silent_arg;
#if DEBUG
			stack[4].s_class = (IntPtr) DebugGCHandle.Alloc(wmclass_arg);
#else
			stack[4].s_class = (IntPtr) GCHandle.Alloc(wmclass_arg);
#endif
			staticInterceptor.Invoke("checkStartupNotify$#$#", "checkStartupNotify(const QString&, const KService*, bool*, QByteArray*)", stack);
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
			silent_arg = stack[3].s_bool;
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[4].s_class);
#else
			((GCHandle) stack[4].s_class).Free();
#endif
			return stack[0].s_bool;
		}
		protected new IKRunSignals Emit {
			get { return (IKRunSignals) Q_EMIT; }
		}
	}

	public interface IKRunSignals : IQObjectSignals {
		/// <remarks>
		///  Emitted when the operation finished.
		/// </remarks>		<short>    Emitted when the operation finished.</short>
		/// 		<see> hasFinished</see>
		[Q_SIGNAL("void finished()")]
		void Finished();
		/// <remarks>
		///  Emitted when the operation had an error.
		/// </remarks>		<short>    Emitted when the operation had an error.</short>
		/// 		<see> hasError</see>
		[Q_SIGNAL("void error()")]
		void Error();
	}
}
