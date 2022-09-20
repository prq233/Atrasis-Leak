using System;
using System.IO;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E4 RID: 228
	public class ZLibStream : Stream
	{
		// Token: 0x0600068C RID: 1676 RVA: 0x000088FA File Offset: 0x00006AFA
		public ZLibStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00008906 File Offset: 0x00006B06
		public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00008912 File Offset: 0x00006B12
		public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0000891E File Offset: 0x00006B1E
		public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this.m_baseStream = new ZLibBaseStream(stream, mode, level, ZlibStreamFlavor.ZLIB, leaveOpen);
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0000893B File Offset: 0x00006B3B
		// (set) Token: 0x06000691 RID: 1681 RVA: 0x00008948 File Offset: 0x00006B48
		public virtual FlushType FlushMode
		{
			get
			{
				return this.m_baseStream.m_flushMode;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				this.m_baseStream.m_flushMode = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00008969 File Offset: 0x00006B69
		// (set) Token: 0x06000693 RID: 1683 RVA: 0x00015074 File Offset: 0x00013274
		public int BufferSize
		{
			get
			{
				return this.m_baseStream.m_bufferSize;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				if (this.m_baseStream.m_workingBuffer != null)
				{
					throw new ZLibException("The working buffer is already set.");
				}
				if (value < 1024)
				{
					throw new ZLibException(string.Format("Don't be silly. {0} bytes?? Use a bigger buffer, at least {1}.", value, 1024));
				}
				this.m_baseStream.m_bufferSize = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000694 RID: 1684 RVA: 0x00008976 File Offset: 0x00006B76
		public virtual long TotalIn
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesIn;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x00008988 File Offset: 0x00006B88
		public virtual long TotalOut
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesOut;
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x000150E0 File Offset: 0x000132E0
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (!this.m_disposed)
				{
					if (disposing && this.m_baseStream != null)
					{
						this.m_baseStream.Close();
					}
					this.m_disposed = true;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0000899A File Offset: 0x00006B9A
		public override bool CanRead
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				return this.m_baseStream.m_stream.CanRead;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000698 RID: 1688 RVA: 0x0000574A File Offset: 0x0000394A
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x000089BF File Offset: 0x00006BBF
		public override bool CanWrite
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("ZLibStream");
				}
				return this.m_baseStream.m_stream.CanWrite;
			}
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x000089E4 File Offset: 0x00006BE4
		public override void Flush()
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			this.m_baseStream.Flush();
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0001512C File Offset: 0x0001332C
		// (set) Token: 0x0600069D RID: 1693 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Position
		{
			get
			{
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Writer)
				{
					return this.m_baseStream.m_z.TotalBytesOut;
				}
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Reader)
				{
					return this.m_baseStream.m_z.TotalBytesIn;
				}
				return 0L;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00008A04 File Offset: 0x00006C04
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			return this.m_baseStream.Read(buffer, offset, count);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00007F27 File Offset: 0x00006127
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00008A27 File Offset: 0x00006C27
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("ZLibStream");
			}
			this.m_baseStream.Write(buffer, offset, count);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00015180 File Offset: 0x00013380
		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new ZLibStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x000151C8 File Offset: 0x000133C8
		public static byte[] CompressBuffer(byte[] b, CompressionLevel level)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new ZLibStream(memoryStream, CompressionMode.Compress, level);
				ZLibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00015210 File Offset: 0x00013410
		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new ZLibStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00015254 File Offset: 0x00013454
		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new ZLibStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x040003B0 RID: 944
		internal ZLibBaseStream m_baseStream;

		// Token: 0x040003B1 RID: 945
		private bool m_disposed;
	}
}
