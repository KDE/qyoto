//Auto-generated by kalyptus. DO NOT EDIT.
namespace KIO {
    using Kimono;
    using System;
    using Qyoto;
    /// <remarks>
    ///  Computes a directory size (similar to "du", but doesn't give the same results
    ///  since we simply sum up the dir and file sizes, whereas du speaks disk blocks)
    ///  </remarks>        <short>    Computes a directory size (similar to "du", but doesn't give the same results  since we simply sum up the dir and file sizes, whereas du speaks disk blocks)  </short>
    [SmokeClass("KIO::DirectorySizeJob")]
    public class DirectorySizeJob : KIO.Job, IDisposable {
        protected DirectorySizeJob(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(DirectorySizeJob), this);
        }
        // KIO::DirectorySizeJob* DirectorySizeJob(KIO::DirectorySizeJobPrivate& arg1); >>>> NOT CONVERTED
        /// <remarks>
        /// </remarks>        <return> the size we found
        ///      </return>
        ///         <short>   </short>
        public long TotalSize() {
            return (long) interceptor.Invoke("totalSize", "totalSize() const", typeof(long));
        }
        /// <remarks>
        /// </remarks>        <return> the total number of files (counting symlinks to files, sockets
        ///  and character devices as files) in this directory and all sub-directories
        ///      </return>
        ///         <short>   </short>
        public long TotalFiles() {
            return (long) interceptor.Invoke("totalFiles", "totalFiles() const", typeof(long));
        }
        /// <remarks>
        /// </remarks>        <return> the total number of sub-directories found (not including the
        ///  directory the search started from and treating symlinks to directories
        ///  as directories)
        ///      </return>
        ///         <short>   </short>
        public long TotalSubdirs() {
            return (long) interceptor.Invoke("totalSubdirs", "totalSubdirs() const", typeof(long));
        }
        [Q_SLOT("void slotResult(KJob*)")]
        [SmokeMethod("slotResult(KJob*)")]
        protected override void SlotResult(KJob job) {
            interceptor.Invoke("slotResult#", "slotResult(KJob*)", typeof(void), typeof(KJob), job);
        }
        ~DirectorySizeJob() {
            interceptor.Invoke("~DirectorySizeJob", "~DirectorySizeJob()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~DirectorySizeJob", "~DirectorySizeJob()", typeof(void));
        }
        protected new IDirectorySizeJobSignals Emit {
            get { return (IDirectorySizeJobSignals) Q_EMIT; }
        }
    }

    public interface IDirectorySizeJobSignals : KIO.IJobSignals {
    }
}
