namespace Qyoto {

    using System;
    using System.IO;
    using System.Text;

    public class QIODeviceWrapper : Stream {
        QIODevice m_device;
        
        public QIODeviceWrapper(QIODevice device) {
            m_device = device;
        }
        
        public override void Flush() {}
        
        public override int Read(byte[] buffer, int offset, int count) {
            QByteArray bytes = m_device.Read(count);
            for (int i = 0; i < bytes.Length(); i++) {
                buffer[i + offset] = (byte) bytes.At(i);
            }
            return bytes.Length();
        }
        
        public override long Seek(long offset, SeekOrigin origin) {
            switch (origin) {
            case SeekOrigin.Begin:
            {
                m_device.Seek(offset);
                break;
            }
            
            case SeekOrigin.Current:
            {
                m_device.Seek(Position + offset);
                break;
            }
            
            case SeekOrigin.End:
            {
                // offset will be negative
                m_device.Seek(Length + offset);
                break;
            }
            }
            return m_device.Pos();
        }
        
        public override void SetLength(long value) {
            throw new NotSupportedException();
        }
        
        public override void Write (byte[] buffer, int offset, int count) {
            QByteArray array = new QByteArray();
            for (int i = 0; i < count; i++) {
                array.Append((char) buffer[i + offset]);
            }
            m_device.Write(array);
        }
        
        public override void Close() {
            m_device.Close();
        }
        
        public override bool CanRead {
            get { return m_device.IsReadable(); }
        }
        
        public override bool CanSeek {
            get { return true; }
        }
        
        public override bool CanWrite {
            get { return true; }
        }
        
        public override long Length {
            get { return m_device.Size(); }
        }
        
        public override long Position {
            get { return m_device.Pos(); }
            set { m_device.Seek((int) value); }
        }
    }

}
