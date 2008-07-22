//Auto-generated by kalyptus. DO NOT EDIT.
namespace KIO {
    using Kimono;
    using System;
    using Qyoto;
    /// <remarks>
    ///  The MultiGetJob is a TransferJob that allows you to get
    ///  several files from a single server. Don't create directly,
    ///  but use KIO.Multi_get() instead.
    ///  See <see cref="IMultiGetJobSignals"></see> for signals emitted by MultiGetJob
    /// </remarks>        <short>    The MultiGetJob is a TransferJob that allows you to get  several files from a single server.</short>
    ///         <see> multi_get</see>
    [SmokeClass("KIO::MultiGetJob")]
    public class MultiGetJob : KIO.TransferJob, IDisposable {
        protected MultiGetJob(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(MultiGetJob), this);
        }
        // KIO::MultiGetJob* MultiGetJob(KIO::MultiGetJobPrivate& arg1); >>>> NOT CONVERTED
        /// <remarks>
        ///  Get an additional file.
        /// <param> name="id" the id of the file
        /// </param><param> name="url" the url of the file to get
        /// </param><param> name="metaData" the meta data for this request
        ///          </param></remarks>        <short>    Get an additional file.</short>
        public void Get(long id, KUrl url, KIO.MetaData metaData) {
            interceptor.Invoke("get$##", "get(long, const KUrl&, const KIO::MetaData&)", typeof(void), typeof(long), id, typeof(KUrl), url, typeof(KIO.MetaData), metaData);
        }
        [Q_SLOT("void slotRedirection(KUrl)")]
        [SmokeMethod("slotRedirection(const KUrl&)")]
        protected override void SlotRedirection(KUrl url) {
            interceptor.Invoke("slotRedirection#", "slotRedirection(const KUrl&)", typeof(void), typeof(KUrl), url);
        }
        [Q_SLOT("void slotFinished()")]
        [SmokeMethod("slotFinished()")]
        protected override void SlotFinished() {
            interceptor.Invoke("slotFinished", "slotFinished()", typeof(void));
        }
        [Q_SLOT("void slotData(QByteArray)")]
        [SmokeMethod("slotData(const QByteArray&)")]
        protected override void SlotData(QByteArray data) {
            interceptor.Invoke("slotData#", "slotData(const QByteArray&)", typeof(void), typeof(QByteArray), data);
        }
        [Q_SLOT("void slotMimetype(QString)")]
        [SmokeMethod("slotMimetype(const QString&)")]
        protected override void SlotMimetype(string mimetype) {
            interceptor.Invoke("slotMimetype$", "slotMimetype(const QString&)", typeof(void), typeof(string), mimetype);
        }
        ~MultiGetJob() {
            interceptor.Invoke("~MultiGetJob", "~MultiGetJob()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~MultiGetJob", "~MultiGetJob()", typeof(void));
        }
        protected new IMultiGetJobSignals Emit {
            get { return (IMultiGetJobSignals) Q_EMIT; }
        }
    }

    public interface IMultiGetJobSignals : KIO.ITransferJobSignals {
        /// <remarks>
        ///  Data from the slave has arrived.
        /// <param> name="id" the id of the request
        /// </param><param> name="data" data received from the slave.
        ///  End of data (EOD) has been reached if data.size() == 0
        ///          </param></remarks>        <short>    Data from the slave has arrived.</short>
        [Q_SIGNAL("void data(long, QByteArray)")]
        void Data(long id, QByteArray data);
        /// <remarks>
        ///  Mimetype determined
        /// <param> name="id" the id of the request
        /// </param><param> name="type" the mime type
        ///          </param></remarks>        <short>    Mimetype determined </short>
        [Q_SIGNAL("void mimetype(long, QString)")]
        void Mimetype(long id, string type);
        /// <remarks>
        ///  File transfer completed.
        ///  When all files have been processed, result(KJob ) gets
        ///  emitted.
        /// <param> name="id" the id of the request
        ///          </param></remarks>        <short>    File transfer completed.</short>
        [Q_SIGNAL("void result(long)")]
        void Result(long id);
    }
}
