//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  Watch directories and files for changes.
    ///  The watched directories or files don't have to exist yet.
    ///  When a watched directory is changed, i.e. when files therein are
    ///  created or deleted, KDirWatch will emit the signal dirty().
    ///  When a watched, but previously not existing directory gets created,
    ///  KDirWatch will emit the signal created().
    ///  When a watched directory gets deleted, KDirWatch will emit the
    ///  signal deleted(). The directory is still watched for new
    ///  creation.
    ///  When a watched file is changed, i.e. attributes changed or written
    ///  to, KDirWatch will emit the signal dirty().
    ///  Scanning of particular directories or files can be stopped temporarily
    ///  and restarted. The whole class can be stopped and restarted.
    ///  Directories and files can be added/removed from the list in any state.
    ///  The implementation uses the FAM service when available;
    ///  if FAM is not available, the INOTIFY functionality is used on LINUX.
    ///  As a last resort, a regular polling for change of modification times
    ///  is done; the polling interval is a global config option:
    ///  DirWatch/PollInterval and DirWatch/NFSPollInterval for NFS mounted
    ///  directories.
    ///  See <see cref="IKDirWatchSignals"></see> for signals emitted by KDirWatch
    /// </remarks>        <author> Sven Radej <sven@lisa.exp.univie.ac.at>
    ///   </author>
    ///         <short> Class for watching directory and file changes. </short>
    ///         <see> self</see>
    [SmokeClass("KDirWatch")]
    public class KDirWatch : QObject, IDisposable {
        protected KDirWatch(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KDirWatch), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static KDirWatch() {
            staticInterceptor = new SmokeInvocation(typeof(KDirWatch), null);
        }
        /// <remarks>
        ///  Available watch modes for directory monitoring
        /// </remarks>        <short>    Available watch modes for directory monitoring </short>
        public enum WatchMode {
            WatchDirOnly = 0,
            WatchFiles = 0x01,
            WatchSubDirs = 0x02,
        }
        public enum Method {
            FAM = 0,
            INotify = 1,
            DNotify = 2,
            Stat = 3,
        }
        /// <remarks>
        ///  Constructor.
        ///  Scanning begins immediately when a dir/file watch
        ///  is added.
        /// <param> name="parent" the parent of the QObject (or 0 for parent-less KDataTools)
        ///     </param></remarks>        <short>    Constructor.</short>
        public KDirWatch(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KDirWatch#", "KDirWatch(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public KDirWatch() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KDirWatch", "KDirWatch()", typeof(void));
        }
        /// <remarks>
        ///  Adds a directory to be watched.
        ///  The directory does not have to exist. When <code>watchModes</code> is set to
        ///  WatchDirOnly (the default), the signals dirty(), created(), deleted()
        ///  can be emitted, all for the watched directory.
        ///  When <code>watchModes</code> is set to WatchFiles, all files in the watched
        ///  directory are watched for changes, too. Thus, the signals dirty(),
        ///  created(), deleted() can be emitted.
        ///  When <code>watchModes</code> is set to WatchSubDirs, all subdirs are watched using
        ///  the same flags specified in <code>watchModes</code> .
        /// <param> name="path" the path to watch
        /// </param><param> name="watchModes" watch modes
        /// </param> @sa  KDirWatch.WatchMode
        ///     </remarks>        <short>    Adds a directory to be watched.</short>
        public void AddDir(string path, uint watchModes) {
            interceptor.Invoke("addDir$$", "addDir(const QString&, KDirWatch::WatchModes)", typeof(void), typeof(string), path, typeof(uint), watchModes);
        }
        public void AddDir(string path) {
            interceptor.Invoke("addDir$", "addDir(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Adds a file to be watched.
        /// <param> name="file" the file to watch
        ///     </param></remarks>        <short>    Adds a file to be watched.</short>
        public void AddFile(string file) {
            interceptor.Invoke("addFile$", "addFile(const QString&)", typeof(void), typeof(string), file);
        }
        /// <remarks>
        ///  Returns the time the directory/file was last changed.
        /// <param> name="path" the file to check
        /// </param></remarks>        <return> the date of the last modification
        ///     </return>
        ///         <short>    Returns the time the directory/file was last changed.</short>
        public QDateTime Ctime(string path) {
            return (QDateTime) interceptor.Invoke("ctime$", "ctime(const QString&) const", typeof(QDateTime), typeof(string), path);
        }
        /// <remarks>
        ///  Removes a directory from the list of scanned directories.
        ///  If specified path is not in the list this does nothing.
        /// <param> name="path" the path of the dir to be removed from the list
        ///     </param></remarks>        <short>    Removes a directory from the list of scanned directories.</short>
        public void RemoveDir(string path) {
            interceptor.Invoke("removeDir$", "removeDir(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Removes a file from the list of watched files.
        ///  If specified path is not in the list this does nothing.
        /// <param> name="file" the file to be removed from the list
        ///     </param></remarks>        <short>    Removes a file from the list of watched files.</short>
        public void RemoveFile(string file) {
            interceptor.Invoke("removeFile$", "removeFile(const QString&)", typeof(void), typeof(string), file);
        }
        /// <remarks>
        ///  Stops scanning the specified path.
        ///  The <code>path</code> is not deleted from the interal just, it is just skipped.
        ///  Call this function when you perform an huge operation
        ///  on this directory (copy/move big files or many files). When finished,
        ///  call restartDirScan(path).
        /// <param> name="path" the path to skip
        /// </param></remarks>        <return> true if the <code>path</code> is being watched, otherwise false
        /// </return>
        ///         <short>    Stops scanning the specified path.</short>
        ///         <see> restartDirScanning</see>
        public bool StopDirScan(string path) {
            return (bool) interceptor.Invoke("stopDirScan$", "stopDirScan(const QString&)", typeof(bool), typeof(string), path);
        }
        /// <remarks>
        ///  Restarts scanning for specified path.
        ///  Resets ctime. It doesn't notify
        ///  the change (by emitted a signal), since the ctime value is reset.
        ///  Call it when you are finished with big operations on that path,
        ///  <b>and</b> when <b>you</b> have refreshed that path.
        /// <param> name="path" the path to restart scanning
        /// </param></remarks>        <return> true if the <code>path</code> is being watched, otherwise false
        /// </return>
        ///         <short>    Restarts scanning for specified path.</short>
        ///         <see> stopDirScanning</see>
        public bool RestartDirScan(string path) {
            return (bool) interceptor.Invoke("restartDirScan$", "restartDirScan(const QString&)", typeof(bool), typeof(string), path);
        }
        /// <remarks>
        ///  Starts scanning of all dirs in list.
        /// <param> name="notify" If true, all changed directories (since
        ///  stopScan() call) will be notified for refresh. If notify is
        ///  false, all ctimes will be reset (except those who are stopped,
        ///  but only if <code>skippedToo</code> is false) and changed dirs won't be
        ///  notified. You can start scanning even if the list is
        ///  empty. First call should be called with <code>false</code> or else all
        ///  directories
        ///  in list will be notified.
        /// </param><param> name="skippedToo" if true, the skipped directoris (scanning of which was
        ///  stopped with stopDirScan() ) will be reset and notified
        ///  for change. Otherwise, stopped directories will continue to be
        ///  unnotified.
        ///     </param></remarks>        <short>    Starts scanning of all dirs in list.</short>
        public void StartScan(bool notify, bool skippedToo) {
            interceptor.Invoke("startScan$$", "startScan(bool, bool)", typeof(void), typeof(bool), notify, typeof(bool), skippedToo);
        }
        public void StartScan(bool notify) {
            interceptor.Invoke("startScan$", "startScan(bool)", typeof(void), typeof(bool), notify);
        }
        public void StartScan() {
            interceptor.Invoke("startScan", "startScan()", typeof(void));
        }
        /// <remarks>
        ///  Stops scanning of all directories in internal list.
        ///  The timer is stopped, but the list is not cleared.
        ///     </remarks>        <short>    Stops scanning of all directories in internal list.</short>
        public void StopScan() {
            interceptor.Invoke("stopScan", "stopScan()", typeof(void));
        }
        /// <remarks>
        ///  Is scanning stopped?
        ///  After creation of a KDirWatch instance, this is false.
        /// </remarks>        <return> true when scanning stopped
        ///     </return>
        ///         <short>    Is scanning stopped?  After creation of a KDirWatch instance, this is false.</short>
        public bool IsStopped() {
            return (bool) interceptor.Invoke("isStopped", "isStopped()", typeof(bool));
        }
        /// <remarks>
        ///  Check if a directory is being watched by this KDirWatch instance
        /// <param> name="path" the directory to check
        /// </param></remarks>        <return> true if the directory is being watched
        ///     </return>
        ///         <short>    Check if a directory is being watched by this KDirWatch instance </short>
        public bool Contains(string path) {
            return (bool) interceptor.Invoke("contains$", "contains(const QString&) const", typeof(bool), typeof(string), path);
        }
        /// <remarks>
        ///  Emits created().
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emits created().</short>
        public void SetCreated(string path) {
            interceptor.Invoke("setCreated$", "setCreated(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Emits dirty().
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emits dirty().</short>
        public void SetDirty(string path) {
            interceptor.Invoke("setDirty$", "setDirty(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Emits deleted().
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emits deleted().</short>
        public void SetDeleted(string path) {
            interceptor.Invoke("setDeleted$", "setDeleted(const QString&)", typeof(void), typeof(string), path);
        }
        /// <remarks>
        ///  Returns the preferred internal method to
        ///  watch for changes.
        ///     </remarks>        <short>    Returns the preferred internal method to  watch for changes.</short>
        public KDirWatch.Method InternalMethod() {
            return (KDirWatch.Method) interceptor.Invoke("internalMethod", "internalMethod()", typeof(KDirWatch.Method));
        }
        ~KDirWatch() {
            interceptor.Invoke("~KDirWatch", "~KDirWatch()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KDirWatch", "~KDirWatch()", typeof(void));
        }
        /// <remarks>
        ///  Dump statistic information about all KDirWatch instances.
        ///  This checks for consistency, too.
        ///     </remarks>        <short>    Dump statistic information about all KDirWatch instances.</short>
        public static void Statistics() {
            staticInterceptor.Invoke("statistics", "statistics()", typeof(void));
        }
        /// <remarks>
        ///  The KDirWatch instance usually globally used in an application.
        ///  It is automatically deleted when the application exits.
        ///  However, you can create an arbitrary number of KDirWatch instances
        ///  aside from this one - for those you have to take care of memory management.
        ///  This function returns an instance of KDirWatch. If there is none, it
        ///  will be created.
        /// </remarks>        <return> a KDirWatch instance
        ///     </return>
        ///         <short>    The KDirWatch instance usually globally used in an application.</short>
        public static KDirWatch Self() {
            return (KDirWatch) staticInterceptor.Invoke("self", "self()", typeof(KDirWatch));
        }
        /// <remarks>
        ///  Returns true if there is an instance of KDirWatch.
        /// </remarks>        <return> true if there is an instance of KDirWatch.
        /// </return>
        ///         <short>    Returns true if there is an instance of KDirWatch.</short>
        ///         <see> KDirWatch.Self</see>
        public static bool Exists() {
            return (bool) staticInterceptor.Invoke("exists", "exists()", typeof(bool));
        }
        protected new IKDirWatchSignals Emit {
            get { return (IKDirWatchSignals) Q_EMIT; }
        }
    }

    public interface IKDirWatchSignals : IQObjectSignals {
        /// <remarks>
        ///  Emitted when a watched object is changed.
        ///  For a directory this signal is emitted when files
        ///  therein are created or deleted.
        ///  For a file this signal is emitted when its size or attributes change.
        ///  When you watch a directory, changes in the size or attributes of
        ///  contained files may or may not trigger this signal to be emitted
        ///  depending on which backend is used by KDirWatch.
        ///  The new ctime is set before the signal is emitted.
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emitted when a watched object is changed.</short>
        [Q_SIGNAL("void dirty(QString)")]
        void Dirty(string path);
        /// <remarks>
        ///  Emitted when a file or directory is created.
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emitted when a file or directory is created.</short>
        [Q_SIGNAL("void created(QString)")]
        void Created(string path);
        /// <remarks>
        ///  Emitted when a file or directory is deleted.
        ///  The object is still watched for new creation.
        /// <param> name="path" the path of the file or directory
        ///     </param></remarks>        <short>    Emitted when a file or directory is deleted.</short>
        [Q_SIGNAL("void deleted(QString)")]
        void Deleted(string path);
    }
}
