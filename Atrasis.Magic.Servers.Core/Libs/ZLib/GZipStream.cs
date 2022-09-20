using System;
using System.IO;
using System.Text;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000CA RID: 202
	public class GZipStream : Stream
	{
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x000081E7 File Offset: 0x000063E7
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x000081EF File Offset: 0x000063EF
		public string Comment
		{
			get
			{
				return this.m_Comment;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_Comment = value;
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0000820B File Offset: 0x0000640B
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x0000F6A8 File Offset: 0x0000D8A8
		public string FileName
		{
			get
			{
				return this.m_FileName;
			}
			set
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_FileName = value;
				if (this.m_FileName == null)
				{
					return;
				}
				if (this.m_FileName.IndexOf("/") != -1)
				{
					this.m_FileName = this.m_FileName.Replace("/", "\\");
				}
				if (this.m_FileName.EndsWith("\\"))
				{
					throw new Exception("Illegal filename");
				}
				if (this.m_FileName.IndexOf("\\") != -1)
				{
					this.m_FileName = Path.GetFileName(this.m_FileName);
				}
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00008213 File Offset: 0x00006413
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x0000821B File Offset: 0x0000641B
		public int Crc32 { get; private set; }

		// Token: 0x060005E6 RID: 1510 RVA: 0x00008224 File Offset: 0x00006424
		public GZipStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00008230 File Offset: 0x00006430
		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000823C File Offset: 0x0000643C
		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00008248 File Offset: 0x00006448
		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this.m_baseStream = new ZLibBaseStream(stream, mode, level, ZlibStreamFlavor.GZIP, leaveOpen);
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00008265 File Offset: 0x00006465
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x00008272 File Offset: 0x00006472
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
					throw new ObjectDisposedException("GZipStream");
				}
				this.m_baseStream.m_flushMode = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00008293 File Offset: 0x00006493
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x0000F748 File Offset: 0x0000D948
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
					throw new ObjectDisposedException("GZipStream");
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

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x000082A0 File Offset: 0x000064A0
		public virtual long TotalIn
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesIn;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x000082B2 File Offset: 0x000064B2
		public virtual long TotalOut
		{
			get
			{
				return this.m_baseStream.m_z.TotalBytesOut;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0000F7B4 File Offset: 0x0000D9B4
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (!this.m_disposed)
				{
					if (disposing && this.m_baseStream != null)
					{
						this.m_baseStream.Close();
						this.Crc32 = this.m_baseStream.Crc32;
					}
					this.m_disposed = true;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x000082C4 File Offset: 0x000064C4
		public override bool CanRead
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this.m_baseStream.m_stream.CanRead;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0000574A File Offset: 0x0000394A
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x000082E9 File Offset: 0x000064E9
		public override bool CanWrite
		{
			get
			{
				if (this.m_disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this.m_baseStream.m_stream.CanWrite;
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0000830E File Offset: 0x0000650E
		public override void Flush()
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			this.m_baseStream.Flush();
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000819A File Offset: 0x0000639A
		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0000F814 File Offset: 0x0000DA14
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x0000819A File Offset: 0x0000639A
		public override long Position
		{
			get
			{
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Writer)
				{
					return this.m_baseStream.m_z.TotalBytesOut + (long)this.m_headerByteCount;
				}
				if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Reader)
				{
					return this.m_baseStream.m_z.TotalBytesIn + (long)this.m_baseStream.m_gzipHeaderByteCount;
				}
				return 0L;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000F87C File Offset: 0x0000DA7C
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			int result = this.m_baseStream.Read(buffer, offset, count);
			if (!this.m_firstReadDone)
			{
				this.m_firstReadDone = true;
				this.FileName = this.m_baseStream.m_GzipFileName;
				this.Comment = this.m_baseStream.m_GzipComment;
			}
			return result;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000819A File Offset: 0x0000639A
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000819A File Offset: 0x0000639A
		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0000F8DC File Offset: 0x0000DADC
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.m_disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			if (this.m_baseStream.m_streamMode == ZLibBaseStream.StreamMode.Undefined)
			{
				if (!this.m_baseStream.m_wantCompress)
				{
					throw new InvalidOperationException();
				}
				this.m_headerByteCount = this.EmitHeader();
			}
			this.m_baseStream.Write(buffer, offset, count);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0000F93C File Offset: 0x0000DB3C
		private int EmitHeader()
		{
			byte[] array = (this.Comment == null) ? null : GZipStream.iso8859dash1.GetBytes(this.Comment);
			byte[] array2 = (this.FileName == null) ? null : GZipStream.iso8859dash1.GetBytes(this.FileName);
			int num = (this.Comment == null) ? 0 : (array.Length + 1);
			int num2 = (this.FileName == null) ? 0 : (array2.Length + 1);
			byte[] array3 = new byte[10 + num + num2];
			array3[0] = 31;
			array3[1] = 139;
			byte[] array4 = array3;
			int num3 = 2;
			int num4 = 3;
			array4[num3] = 8;
			byte b = 0;
			if (this.Comment != null)
			{
				b ^= 16;
			}
			if (this.FileName != null)
			{
				b ^= 8;
			}
			array3[num4++] = b;
			if (this.LastModified == null)
			{
				this.LastModified = new DateTime?(DateTime.Now);
			}
			Array.Copy(BitConverter.GetBytes((int)(this.LastModified.Value - GZipStream.m_unixEpoch).TotalSeconds), 0, array3, num4, 4);
			num4 += 4;
			array3[num4++] = 0;
			array3[num4++] = byte.MaxValue;
			if (num2 != 0)
			{
				Array.Copy(array2, 0, array3, num4, num2 - 1);
				num4 += num2 - 1;
				array3[num4++] = 0;
			}
			if (num != 0)
			{
				Array.Copy(array, 0, array3, num4, num - 1);
				num4 += num - 1;
				array3[num4++] = 0;
			}
			this.m_baseStream.m_stream.Write(array3, 0, array3.Length);
			return array3.Length;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0000FAD0 File Offset: 0x0000DCD0
		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0000FB18 File Offset: 0x0000DD18
		public static byte[] CompressBuffer(byte[] b)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZLibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000FB60 File Offset: 0x0000DD60
		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0000FBA4 File Offset: 0x0000DDA4
		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZLibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		// Token: 0x0400028F RID: 655
		public DateTime? LastModified;

		// Token: 0x04000291 RID: 657
		private int m_headerByteCount;

		// Token: 0x04000292 RID: 658
		internal ZLibBaseStream m_baseStream;

		// Token: 0x04000293 RID: 659
		private bool m_disposed;

		// Token: 0x04000294 RID: 660
		private bool m_firstReadDone;

		// Token: 0x04000295 RID: 661
		private string m_FileName;

		// Token: 0x04000296 RID: 662
		private string m_Comment;

		// Token: 0x04000297 RID: 663
		internal static readonly DateTime m_unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x04000298 RID: 664
		internal static readonly Encoding iso8859dash1 = Encoding.GetEncoding("iso-8859-1");
	}
}
