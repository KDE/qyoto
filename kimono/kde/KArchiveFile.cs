//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  Represents a file entry in a KArchive.
    /// </remarks>        <short> A file in an archive. </short>
    ///         <see> KArchive</see>
    ///         <see> KArchiveDirectory</see>
    [SmokeClass("KArchiveFile")]
    public class KArchiveFile : KArchiveEntry, IDisposable {
        protected KArchiveFile(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KArchiveFile), this);
        }
        /// <remarks>
        ///  Creates a new file entry. Do not call this, KArchive takes care of it.
        /// <param> name="archive" the entries archive
        /// </param><param> name="name" the name of the entry
        /// </param><param> name="access" the permissions in unix format
        /// </param><param> name="date" the date (in seconds since 1970)
        /// </param><param> name="user" the user that owns the entry
        /// </param><param> name="group" the group that owns the entry
        /// </param><param> name="symlink" the symlink, or string()
        /// </param><param> name="pos" the position of the file in the directory
        /// </param><param> name="size" the size of the file
        ///      </param></remarks>        <short>    Creates a new file entry.</short>
        public KArchiveFile(KArchive archive, string name, int access, int date, string user, string group, string symlink, long pos, long size) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KArchiveFile#$$$$$$$$", "KArchiveFile(KArchive*, const QString&, int, int, const QString&, const QString&, const QString&, qint64, qint64)", typeof(void), typeof(KArchive), archive, typeof(string), name, typeof(int), access, typeof(int), date, typeof(string), user, typeof(string), group, typeof(string), symlink, typeof(long), pos, typeof(long), size);
        }
        /// <remarks>
        ///  Position of the data in the [uncompressed] archive.
        /// </remarks>        <return> the position of the file
        ///      </return>
        ///         <short>    Position of the data in the [uncompressed] archive.</short>
        public long Position() {
            return (long) interceptor.Invoke("position", "position() const", typeof(long));
        }
        /// <remarks>
        ///  Size of the data.
        /// </remarks>        <return> the size of the file
        ///      </return>
        ///         <short>    Size of the data.</short>
        public long Size() {
            return (long) interceptor.Invoke("size", "size() const", typeof(long));
        }
        /// <remarks>
        ///  Set size of data, usually after writing the file.
        /// <param> name="s" the new size of the file
        ///      </param></remarks>        <short>    Set size of data, usually after writing the file.</short>
        public void SetSize(long s) {
            interceptor.Invoke("setSize$", "setSize(qint64)", typeof(void), typeof(long), s);
        }
        /// <remarks>
        ///  Returns the data of the file.
        ///  Call data() with care (only once per file), this data isn't cached.
        /// </remarks>        <return> the content of this file.
        ///      </return>
        ///         <short>    Returns the data of the file.</short>
        [SmokeMethod("data() const")]
        public virtual QByteArray Data() {
            return (QByteArray) interceptor.Invoke("data", "data() const", typeof(QByteArray));
        }
        /// <remarks>
        ///  This method returns QIODevice (internal class: KLimitedIODevice)
        ///  on top of the underlying QIODevice. This is obviously for reading only.
        ///  WARNING: Note that the ownership of the device is being transferred to the caller,
        ///  who will have to delete it.
        ///  The returned device auto-opens (in readonly mode), no need to open it.
        /// </remarks>        <return> the QIODevice of the file
        ///      </return>
        ///         <short>    This method returns QIODevice (internal class: KLimitedIODevice)  on top of the underlying QIODevice.</short>
        [SmokeMethod("createDevice() const")]
        public virtual QIODevice CreateDevice() {
            return (QIODevice) interceptor.Invoke("createDevice", "createDevice() const", typeof(QIODevice));
        }
        /// <remarks>
        ///  Checks whether this entry is a file.
        /// </remarks>        <return> true, since this entry is a file
        ///      </return>
        ///         <short>    Checks whether this entry is a file.</short>
        [SmokeMethod("isFile() const")]
        public override bool IsFile() {
            return (bool) interceptor.Invoke("isFile", "isFile() const", typeof(bool));
        }
        /// <remarks>
        ///  Extracts the file to the directory <code>dest</code>
        /// <param> name="dest" the directory to extract to
        ///      </param></remarks>        <short>    Extracts the file to the directory <code>dest</code> </short>
        public void CopyTo(string dest) {
            interceptor.Invoke("copyTo$", "copyTo(const QString&) const", typeof(void), typeof(string), dest);
        }
        ~KArchiveFile() {
            interceptor.Invoke("~KArchiveFile", "~KArchiveFile()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KArchiveFile", "~KArchiveFile()", typeof(void));
        }
    }
}
