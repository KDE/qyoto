namespace Qyoto {
	using System;
	using System.IO;
	
	public class StreamWrapper : QIODevice {
		private Stream m_stream;

		public StreamWrapper(Stream stream, bool open) : base() {
			m_stream = stream;
			if (!open) return;
			if (stream.CanRead && stream.CanWrite)
				Open((uint) OpenModeFlag.ReadWrite);
			else if (stream.CanRead)
				Open((uint) OpenModeFlag.ReadOnly);
			else if (stream.CanWrite)
				Open((uint) OpenModeFlag.WriteOnly);
		}

		public StreamWrapper(Stream stream) : this(stream, true) {}

		protected override unsafe long ReadData(Pointer<sbyte> data, long maxsize) {
			int max = (maxsize > int.MaxValue)? int.MaxValue : (int) maxsize;
			byte[] buffer = new byte[max];
			int read = m_stream.Read(buffer, 0, max);
			for (int i = 0; i < max; i++) {
				data[i] = (sbyte) buffer[i];
			}
			return read;
		}

		protected override long WriteData(string data, long maxsize) {
			int max = (maxsize > int.MaxValue)? int.MaxValue : (int) maxsize;
			int i = 0;
			for (; i < max; i++)
				m_stream.WriteByte((byte) data[i]);
			return i;
		}
		
		public override bool Seek(long pos) {
			base.Seek(pos);
			try {
				m_stream.Seek(pos, SeekOrigin.Begin);
				return true;
			} catch {
				return false;
			}
		}
		
		public override long Size() {
			if (!m_stream.CanSeek) return base.Size();
			return m_stream.Length;
		}
		
		public override void Close() {
			m_stream.Close();
		}
	}
}
