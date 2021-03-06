//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    /// <remarks> See <see cref="IQIODeviceSignals"></see> for signals emitted by QIODevice
    /// </remarks>
    [SmokeClass("QIODevice")]
    public abstract partial class QIODevice : QObject {
        protected QIODevice(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QIODevice), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QIODevice() {
            staticInterceptor = new SmokeInvocation(typeof(QIODevice), null);
        }
        public enum OpenModeFlag {
            NotOpen = 0x0000,
            ReadOnly = 0x0001,
            WriteOnly = 0x0002,
            ReadWrite = ReadOnly|WriteOnly,
            Append = 0x0004,
            Truncate = 0x0008,
            Text = 0x0010,
            Unbuffered = 0x0020,
        }
        // QIODevice* QIODevice(QIODevicePrivate& arg1,QObject* arg2); >>>> NOT CONVERTED
        // QIODevice* QIODevice(QIODevicePrivate& arg1); >>>> NOT CONVERTED
        public QIODevice() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QIODevice", "QIODevice()", typeof(void));
        }
        public QIODevice(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QIODevice#", "QIODevice(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public uint OpenMode() {
            return (uint) interceptor.Invoke("openMode", "openMode() const", typeof(uint));
        }
        public void SetTextModeEnabled(bool enabled) {
            interceptor.Invoke("setTextModeEnabled$", "setTextModeEnabled(bool)", typeof(void), typeof(bool), enabled);
        }
        public bool IsTextModeEnabled() {
            return (bool) interceptor.Invoke("isTextModeEnabled", "isTextModeEnabled() const", typeof(bool));
        }
        public bool IsOpen() {
            return (bool) interceptor.Invoke("isOpen", "isOpen() const", typeof(bool));
        }
        public bool IsReadable() {
            return (bool) interceptor.Invoke("isReadable", "isReadable() const", typeof(bool));
        }
        public bool IsWritable() {
            return (bool) interceptor.Invoke("isWritable", "isWritable() const", typeof(bool));
        }
        [SmokeMethod("isSequential() const")]
        public virtual bool IsSequential() {
            return (bool) interceptor.Invoke("isSequential", "isSequential() const", typeof(bool));
        }
        [SmokeMethod("open(QIODevice::OpenMode)")]
        public virtual bool Open(uint mode) {
            return (bool) interceptor.Invoke("open$", "open(QIODevice::OpenMode)", typeof(bool), typeof(uint), mode);
        }
        [SmokeMethod("close()")]
        public virtual void Close() {
            interceptor.Invoke("close", "close()", typeof(void));
        }
        [SmokeMethod("pos() const")]
        public virtual long Pos() {
            return (long) interceptor.Invoke("pos", "pos() const", typeof(long));
        }
        [SmokeMethod("size() const")]
        public virtual long Size() {
            return (long) interceptor.Invoke("size", "size() const", typeof(long));
        }
        [SmokeMethod("seek(qint64)")]
        public virtual bool Seek(long pos) {
            return (bool) interceptor.Invoke("seek$", "seek(qint64)", typeof(bool), typeof(long), pos);
        }
        [SmokeMethod("atEnd() const")]
        public virtual bool AtEnd() {
            return (bool) interceptor.Invoke("atEnd", "atEnd() const", typeof(bool));
        }
        [SmokeMethod("reset()")]
        public virtual bool Reset() {
            return (bool) interceptor.Invoke("reset", "reset()", typeof(bool));
        }
        [SmokeMethod("bytesAvailable() const")]
        public virtual long BytesAvailable() {
            return (long) interceptor.Invoke("bytesAvailable", "bytesAvailable() const", typeof(long));
        }
        [SmokeMethod("bytesToWrite() const")]
        public virtual long BytesToWrite() {
            return (long) interceptor.Invoke("bytesToWrite", "bytesToWrite() const", typeof(long));
        }
        public long Read(Pointer<sbyte> data, long maxlen) {
            return (long) interceptor.Invoke("read$$", "read(char*, qint64)", typeof(long), typeof(Pointer<sbyte>), data, typeof(long), maxlen);
        }
        public QByteArray Read(long maxlen) {
            return (QByteArray) interceptor.Invoke("read$", "read(qint64)", typeof(QByteArray), typeof(long), maxlen);
        }
        public QByteArray ReadAll() {
            return (QByteArray) interceptor.Invoke("readAll", "readAll()", typeof(QByteArray));
        }
        public long ReadLine(Pointer<sbyte> data, long maxlen) {
            return (long) interceptor.Invoke("readLine$$", "readLine(char*, qint64)", typeof(long), typeof(Pointer<sbyte>), data, typeof(long), maxlen);
        }
        public QByteArray ReadLine(long maxlen) {
            return (QByteArray) interceptor.Invoke("readLine$", "readLine(qint64)", typeof(QByteArray), typeof(long), maxlen);
        }
        public QByteArray ReadLine() {
            return (QByteArray) interceptor.Invoke("readLine", "readLine()", typeof(QByteArray));
        }
        [SmokeMethod("canReadLine() const")]
        public virtual bool CanReadLine() {
            return (bool) interceptor.Invoke("canReadLine", "canReadLine() const", typeof(bool));
        }
        public long Write(string data, long len) {
            return (long) interceptor.Invoke("write$$", "write(const char*, qint64)", typeof(long), typeof(string), data, typeof(long), len);
        }
        public long Write(string data) {
            return (long) interceptor.Invoke("write$", "write(const char*)", typeof(long), typeof(string), data);
        }
        public long Write(QByteArray data) {
            return (long) interceptor.Invoke("write#", "write(const QByteArray&)", typeof(long), typeof(QByteArray), data);
        }
        public long Peek(Pointer<sbyte> data, long maxlen) {
            return (long) interceptor.Invoke("peek$$", "peek(char*, qint64)", typeof(long), typeof(Pointer<sbyte>), data, typeof(long), maxlen);
        }
        public QByteArray Peek(long maxlen) {
            return (QByteArray) interceptor.Invoke("peek$", "peek(qint64)", typeof(QByteArray), typeof(long), maxlen);
        }
        [SmokeMethod("waitForReadyRead(int)")]
        public virtual bool WaitForReadyRead(int msecs) {
            return (bool) interceptor.Invoke("waitForReadyRead$", "waitForReadyRead(int)", typeof(bool), typeof(int), msecs);
        }
        [SmokeMethod("waitForBytesWritten(int)")]
        public virtual bool WaitForBytesWritten(int msecs) {
            return (bool) interceptor.Invoke("waitForBytesWritten$", "waitForBytesWritten(int)", typeof(bool), typeof(int), msecs);
        }
        public void UngetChar(char c) {
            interceptor.Invoke("ungetChar$", "ungetChar(char)", typeof(void), typeof(char), c);
        }
        public bool PutChar(char c) {
            return (bool) interceptor.Invoke("putChar$", "putChar(char)", typeof(bool), typeof(char), c);
        }
        public bool GetChar(Pointer<sbyte> c) {
            return (bool) interceptor.Invoke("getChar$", "getChar(char*)", typeof(bool), typeof(Pointer<sbyte>), c);
        }
        public string ErrorString() {
            return (string) interceptor.Invoke("errorString", "errorString() const", typeof(string));
        }
        [SmokeMethod("readData(char*, qint64)")]
        protected abstract long ReadData(Pointer<sbyte> data, long maxlen);
        [SmokeMethod("readLineData(char*, qint64)")]
        protected virtual long ReadLineData(Pointer<sbyte> data, long maxlen) {
            return (long) interceptor.Invoke("readLineData$$", "readLineData(char*, qint64)", typeof(long), typeof(Pointer<sbyte>), data, typeof(long), maxlen);
        }
        [SmokeMethod("writeData(const char*, qint64)")]
        protected abstract long WriteData(string data, long len);
        protected void SetOpenMode(uint openMode) {
            interceptor.Invoke("setOpenMode$", "setOpenMode(QIODevice::OpenMode)", typeof(void), typeof(uint), openMode);
        }
        protected void SetErrorString(string errorString) {
            interceptor.Invoke("setErrorString$", "setErrorString(const QString&)", typeof(void), typeof(string), errorString);
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQIODeviceSignals Emit {
            get { return (IQIODeviceSignals) Q_EMIT; }
        }
    }

    public interface IQIODeviceSignals : IQObjectSignals {
        [Q_SIGNAL("void readyRead()")]
        void ReadyRead();
        [Q_SIGNAL("void bytesWritten(qint64)")]
        void BytesWritten(long bytes);
        [Q_SIGNAL("void aboutToClose()")]
        void AboutToClose();
        [Q_SIGNAL("void readChannelFinished()")]
        void ReadChannelFinished();
    }
}
