//Auto-generated by kalyptus. DO NOT EDIT.
namespace KIO {
    using Kimono;
    using System;
    using Qyoto;
    /// <remarks>
    ///  A KIO job that retrieves information about a file or directory.
    ///  See <see cref="IStatJobSignals"></see> for signals emitted by StatJob
    /// </remarks>        <short>    A KIO job that retrieves information about a file or directory.</short>
    ///         <see> stat</see>
    [SmokeClass("KIO::StatJob")]
    public class StatJob : KIO.SimpleJob, IDisposable {
        protected StatJob(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(StatJob), this);
        }
        public enum StatSide {
            SourceSide = 0,
            DestinationSide = 1,
        }
        // KIO::StatJob* StatJob(KIO::StatJobPrivate& arg1); >>>> NOT CONVERTED
        /// <remarks>
        ///  A stat() can have two meanings. Either we want to read from this URL,
        ///  or to check if we can write to it. First case is "source", second is "dest".
        ///  It is necessary to know what the StatJob is for, to tune the kioslave's behavior
        ///  (e.g. with FTP).
        /// <param> name="side" SourceSide or DestinationSide
        ///          </param></remarks>        <short>    A stat() can have two meanings.</short>
        public void SetSide(KIO.StatJob.StatSide side) {
            interceptor.Invoke("setSide$", "setSide(KIO::StatJob::StatSide)", typeof(void), typeof(KIO.StatJob.StatSide), side);
        }
        /// <remarks>
        ///  Selects the level of <code>details</code> we want.
        ///  By default this is 2 (all details wanted, including modification time, size, etc.),
        ///  setDetails(1) is used when deleting: we don't need all the information if it takes
        ///  too much time, no need to follow symlinks etc.
        ///  setDetails(0) is used for very simple probing: we'll only get the answer
        ///  "it's a file or a directory, or it doesn't exist". This is used by KRun.
        /// <param> name="details" 2 for all details, 1 for simple, 0 for very simple
        ///          </param></remarks>        <short>    Selects the level of <code>details</code> we want.</short>
        public void SetDetails(short details) {
            interceptor.Invoke("setDetails$", "setDetails(short int)", typeof(void), typeof(short), details);
        }
        /// <remarks>
        ///  Call this in the slot connected to result,
        ///  and only after making sure no error happened.
        /// </remarks>        <return> the result of the stat
        ///          </return>
        ///         <short>    Call this in the slot connected to result,  and only after making sure no error happened.</short>
        public KIO.UDSEntry StatResult() {
            return (KIO.UDSEntry) interceptor.Invoke("statResult", "statResult() const", typeof(KIO.UDSEntry));
        }
        [Q_SLOT("void slotFinished()")]
        [SmokeMethod("slotFinished()")]
        protected override void SlotFinished() {
            interceptor.Invoke("slotFinished", "slotFinished()", typeof(void));
        }
        [Q_SLOT("void slotMetaData(KIO::MetaData)")]
        [SmokeMethod("slotMetaData(const KIO::MetaData&)")]
        protected override void SlotMetaData(KIO.MetaData _metaData) {
            interceptor.Invoke("slotMetaData#", "slotMetaData(const KIO::MetaData&)", typeof(void), typeof(KIO.MetaData), _metaData);
        }
        ~StatJob() {
            interceptor.Invoke("~StatJob", "~StatJob()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~StatJob", "~StatJob()", typeof(void));
        }
        protected new IStatJobSignals Emit {
            get { return (IStatJobSignals) Q_EMIT; }
        }
    }

    public interface IStatJobSignals : KIO.ISimpleJobSignals {
        /// <remarks>
        ///  Signals a redirection.
        ///  Use to update the URL shown to the user.
        ///  The redirection itself is handled internally.
        /// <param> name="job" the job that is redirected
        /// </param><param> name="url" the new url
        ///          </param></remarks>        <short>    Signals a redirection.</short>
        [Q_SIGNAL("void redirection(KIO::Job*, KUrl)")]
        void Redirection(KIO.Job job, KUrl url);
        /// <remarks>
        ///  Signals a permanent redirection.
        ///  The redirection itself is handled internally.
        /// <param> name="job" the job that is redirected
        /// </param><param> name="fromUrl" the original URL
        /// </param><param> name="toUrl" the new URL
        ///          </param></remarks>        <short>    Signals a permanent redirection.</short>
        [Q_SIGNAL("void permanentRedirection(KIO::Job*, KUrl, KUrl)")]
        void PermanentRedirection(KIO.Job job, KUrl fromUrl, KUrl toUrl);
    }
}
