//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	[SmokeClass("QAbstractFileEngine")]
	public abstract class QAbstractFileEngine : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected QAbstractFileEngine(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QAbstractFileEngine), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QAbstractFileEngine() {
			staticInterceptor = new SmokeInvocation(typeof(QAbstractFileEngine), null);
		}
		public enum FileFlag {
			ReadOwnerPerm = 0x4000,
			WriteOwnerPerm = 0x2000,
			ExeOwnerPerm = 0x1000,
			ReadUserPerm = 0x0400,
			WriteUserPerm = 0x0200,
			ExeUserPerm = 0x0100,
			ReadGroupPerm = 0x0040,
			WriteGroupPerm = 0x0020,
			ExeGroupPerm = 0x0010,
			ReadOtherPerm = 0x0004,
			WriteOtherPerm = 0x0002,
			ExeOtherPerm = 0x0001,
			LinkType = 0x10000,
			FileType = 0x20000,
			DirectoryType = 0x40000,
			BundleType = 0x80000,
			HiddenFlag = 0x0100000,
			LocalDiskFlag = 0x0200000,
			ExistsFlag = 0x0400000,
			RootFlag = 0x0800000,
			Refresh = 0x1000000,
			PermsMask = 0x0000FFFF,
			TypesMask = 0x000F0000,
			FlagsMask = 0x0FF00000,
			FileInfoAll = FlagsMask|PermsMask|TypesMask,
		}
		public enum FileName {
			DefaultName = 0,
			BaseName = 1,
			PathName = 2,
			AbsoluteName = 3,
			AbsolutePathName = 4,
			LinkName = 5,
			CanonicalName = 6,
			CanonicalPathName = 7,
			BundleName = 8,
		}
		public enum FileOwner {
			OwnerUser = 0,
			OwnerGroup = 1,
		}
		public enum FileTime {
			CreationTime = 0,
			ModificationTime = 1,
			AccessTime = 2,
		}
		public enum Extension {
			AtEndExtension = 0,
			FastReadLineExtension = 1,
		}
		// QAbstractFileEngine::Iterator* beginEntryList(QDir::Filters arg1,const QStringList& arg2); >>>> NOT CONVERTED
		// QAbstractFileEngine::Iterator* endEntryList(); >>>> NOT CONVERTED
		// bool extension(QAbstractFileEngine::Extension arg1,const QAbstractFileEngine::ExtensionOption* arg2,QAbstractFileEngine::ExtensionReturn* arg3); >>>> NOT CONVERTED
		// bool extension(QAbstractFileEngine::Extension arg1,const QAbstractFileEngine::ExtensionOption* arg2); >>>> NOT CONVERTED
		// QAbstractFileEngine* QAbstractFileEngine(QAbstractFileEnginePrivate& arg1); >>>> NOT CONVERTED
		[SmokeMethod("open(QIODevice::OpenMode)")]
		public virtual bool Open(uint openMode) {
			return (bool) interceptor.Invoke("open$", "open(QIODevice::OpenMode)", typeof(bool), typeof(uint), openMode);
		}
		[SmokeMethod("close()")]
		public virtual bool Close() {
			return (bool) interceptor.Invoke("close", "close()", typeof(bool));
		}
		[SmokeMethod("flush()")]
		public virtual bool Flush() {
			return (bool) interceptor.Invoke("flush", "flush()", typeof(bool));
		}
		[SmokeMethod("size() const")]
		public virtual long Size() {
			return (long) interceptor.Invoke("size", "size() const", typeof(long));
		}
		[SmokeMethod("pos() const")]
		public virtual long Pos() {
			return (long) interceptor.Invoke("pos", "pos() const", typeof(long));
		}
		[SmokeMethod("seek(qint64)")]
		public virtual bool Seek(long pos) {
			return (bool) interceptor.Invoke("seek$", "seek(qint64)", typeof(bool), typeof(long), pos);
		}
		[SmokeMethod("isSequential() const")]
		public virtual bool IsSequential() {
			return (bool) interceptor.Invoke("isSequential", "isSequential() const", typeof(bool));
		}
		[SmokeMethod("remove()")]
		public virtual bool Remove() {
			return (bool) interceptor.Invoke("remove", "remove()", typeof(bool));
		}
		[SmokeMethod("copy(const QString&)")]
		public virtual bool Copy(string newName) {
			return (bool) interceptor.Invoke("copy$", "copy(const QString&)", typeof(bool), typeof(string), newName);
		}
		[SmokeMethod("rename(const QString&)")]
		public virtual bool Rename(string newName) {
			return (bool) interceptor.Invoke("rename$", "rename(const QString&)", typeof(bool), typeof(string), newName);
		}
		[SmokeMethod("link(const QString&)")]
		public virtual bool Link(string newName) {
			return (bool) interceptor.Invoke("link$", "link(const QString&)", typeof(bool), typeof(string), newName);
		}
		[SmokeMethod("mkdir(const QString&, bool) const")]
		public virtual bool Mkdir(string dirName, bool createParentDirectories) {
			return (bool) interceptor.Invoke("mkdir$$", "mkdir(const QString&, bool) const", typeof(bool), typeof(string), dirName, typeof(bool), createParentDirectories);
		}
		[SmokeMethod("rmdir(const QString&, bool) const")]
		public virtual bool Rmdir(string dirName, bool recurseParentDirectories) {
			return (bool) interceptor.Invoke("rmdir$$", "rmdir(const QString&, bool) const", typeof(bool), typeof(string), dirName, typeof(bool), recurseParentDirectories);
		}
		[SmokeMethod("setSize(qint64)")]
		public virtual bool SetSize(long size) {
			return (bool) interceptor.Invoke("setSize$", "setSize(qint64)", typeof(bool), typeof(long), size);
		}
		[SmokeMethod("caseSensitive() const")]
		public virtual bool CaseSensitive() {
			return (bool) interceptor.Invoke("caseSensitive", "caseSensitive() const", typeof(bool));
		}
		[SmokeMethod("isRelativePath() const")]
		public virtual bool IsRelativePath() {
			return (bool) interceptor.Invoke("isRelativePath", "isRelativePath() const", typeof(bool));
		}
		[SmokeMethod("entryList(QDir::Filters, const QStringList&) const")]
		public virtual List<string> EntryList(uint filters, List<string> filterNames) {
			return (List<string>) interceptor.Invoke("entryList$?", "entryList(QDir::Filters, const QStringList&) const", typeof(List<string>), typeof(uint), filters, typeof(List<string>), filterNames);
		}
		[SmokeMethod("fileFlags(QAbstractFileEngine::FileFlags) const")]
		public virtual uint FileFlags(uint type) {
			return (uint) interceptor.Invoke("fileFlags$", "fileFlags(QAbstractFileEngine::FileFlags) const", typeof(uint), typeof(uint), type);
		}
		[SmokeMethod("fileFlags() const")]
		public virtual uint FileFlags() {
			return (uint) interceptor.Invoke("fileFlags", "fileFlags() const", typeof(uint));
		}
		[SmokeMethod("setPermissions(uint)")]
		public virtual bool SetPermissions(uint perms) {
			return (bool) interceptor.Invoke("setPermissions$", "setPermissions(uint)", typeof(bool), typeof(uint), perms);
		}
		[SmokeMethod("fileName(QAbstractFileEngine::FileName) const")]
		public virtual string fileName(QAbstractFileEngine.FileName file) {
			return (string) interceptor.Invoke("fileName$", "fileName(QAbstractFileEngine::FileName) const", typeof(string), typeof(QAbstractFileEngine.FileName), file);
		}
		[SmokeMethod("fileName() const")]
		public virtual string fileName() {
			return (string) interceptor.Invoke("fileName", "fileName() const", typeof(string));
		}
		[SmokeMethod("ownerId(QAbstractFileEngine::FileOwner) const")]
		public virtual uint OwnerId(QAbstractFileEngine.FileOwner arg1) {
			return (uint) interceptor.Invoke("ownerId$", "ownerId(QAbstractFileEngine::FileOwner) const", typeof(uint), typeof(QAbstractFileEngine.FileOwner), arg1);
		}
		[SmokeMethod("owner(QAbstractFileEngine::FileOwner) const")]
		public virtual string Owner(QAbstractFileEngine.FileOwner arg1) {
			return (string) interceptor.Invoke("owner$", "owner(QAbstractFileEngine::FileOwner) const", typeof(string), typeof(QAbstractFileEngine.FileOwner), arg1);
		}
		[SmokeMethod("fileTime(QAbstractFileEngine::FileTime) const")]
		public virtual QDateTime fileTime(QAbstractFileEngine.FileTime time) {
			return (QDateTime) interceptor.Invoke("fileTime$", "fileTime(QAbstractFileEngine::FileTime) const", typeof(QDateTime), typeof(QAbstractFileEngine.FileTime), time);
		}
		[SmokeMethod("setFileName(const QString&)")]
		public virtual void SetFileName(string file) {
			interceptor.Invoke("setFileName$", "setFileName(const QString&)", typeof(void), typeof(string), file);
		}
		public bool AtEnd() {
			return (bool) interceptor.Invoke("atEnd", "atEnd() const", typeof(bool));
		}
		[SmokeMethod("read(char*, qint64)")]
		public virtual long Read(string data, long maxlen) {
			return (long) interceptor.Invoke("read$$", "read(char*, qint64)", typeof(long), typeof(string), data, typeof(long), maxlen);
		}
		[SmokeMethod("readLine(char*, qint64)")]
		public virtual long ReadLine(string data, long maxlen) {
			return (long) interceptor.Invoke("readLine$$", "readLine(char*, qint64)", typeof(long), typeof(string), data, typeof(long), maxlen);
		}
		[SmokeMethod("write(const char*, qint64)")]
		public virtual long Write(string data, long len) {
			return (long) interceptor.Invoke("write$$", "write(const char*, qint64)", typeof(long), typeof(string), data, typeof(long), len);
		}
		public QFile.FileError Error() {
			return (QFile.FileError) interceptor.Invoke("error", "error() const", typeof(QFile.FileError));
		}
		public string ErrorString() {
			return (string) interceptor.Invoke("errorString", "errorString() const", typeof(string));
		}
		[SmokeMethod("extension(QAbstractFileEngine::Extension)")]
		public virtual bool extension(QAbstractFileEngine.Extension extension) {
			return (bool) interceptor.Invoke("extension$", "extension(QAbstractFileEngine::Extension)", typeof(bool), typeof(QAbstractFileEngine.Extension), extension);
		}
		[SmokeMethod("supportsExtension(QAbstractFileEngine::Extension) const")]
		public virtual bool SupportsExtension(QAbstractFileEngine.Extension extension) {
			return (bool) interceptor.Invoke("supportsExtension$", "supportsExtension(QAbstractFileEngine::Extension) const", typeof(bool), typeof(QAbstractFileEngine.Extension), extension);
		}
		protected void SetError(QFile.FileError error, string str) {
			interceptor.Invoke("setError$$", "setError(QFile::FileError, const QString&)", typeof(void), typeof(QFile.FileError), error, typeof(string), str);
		}
		public QAbstractFileEngine() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QAbstractFileEngine", "QAbstractFileEngine()", typeof(void));
		}
		public static QAbstractFileEngine Create(string fileName) {
			return (QAbstractFileEngine) staticInterceptor.Invoke("create$", "create(const QString&)", typeof(QAbstractFileEngine), typeof(string), fileName);
		}
	}
}
