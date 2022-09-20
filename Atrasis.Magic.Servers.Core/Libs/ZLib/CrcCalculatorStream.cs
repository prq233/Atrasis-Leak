using System;
using System.IO;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000C3 RID: 195
	public class CrcCalculatorStream : Stream, IDisposable
	{
		// Token: 0x0600057C RID: 1404 RVA: 0x00007DCB File Offset: 0x00005FCB
		public CrcCalculatorStream(Stream stream) : this(true, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00007DDB File Offset: 0x00005FDB
		public CrcCalculatorStream(Stream stream, bool leaveOpen) : this(leaveOpen, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00007DEB File Offset: 0x00005FEB
		public CrcCalculatorStream(Stream stream, long length) : this(true, length, stream, null)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00007E0E File Offset: 0x0000600E
		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen) : this(leaveOpen, length, stream, null)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00007E31 File Offset: 0x00006031
		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen, CRC32 crc32) : this(leaveOpen, length, stream, crc32)
		{
			if (length < 0L)
			{
				throw new ArgumentException("length");
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00007E55 File Offset: 0x00006055
		private CrcCalculatorStream(bool leaveOpen, long length, Stream stream, CRC32 crc32)
		{
			this.m_innerStream = stream;
			this.m_Crc32 = (crc32 ?? new CRC32());
			this.m_lengthLimit = length;
			this.LeaveOpen = leaveOpen;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x00007E92 File Offset: 0x00006092
		public long TotalBytesSlurped
		{
			get
			{
				return this.m_Crc32.TotalBytesRead;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x00007E9F File Offset: 0x0000609F
		public int Crc
		{
			get
			{
				return this.m_Crc32.Crc32Result;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00007EAC File Offset: 0x000060AC
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x00007EB4 File Offset: 0x000060B4
		public bool LeaveOpen { get; set; }

		// Token: 0x06000586 RID: 1414 RVA: 0x0000CF0C File Offset: 0x0000B10C
		public override int Read(byte[] buffer, int offset, int count)
		{
			int count2 = count;
			if (this.m_lengthLimit != CrcCalculatorStream.UnsetLengthLimit)
			{
				if (this.m_Crc32.TotalBytesRead >= this.m_lengthLimit)
				{
					return 0;
				}
				long num = this.m_lengthLimit - this.m_Crc32.TotalBytesRead;
				if (num < (long)count)
				{
					count2 = (int)num;
				}
			}
			int num2 = this.m_innerStream.Read(buffer, offset, count2);
			if (num2 > 0)
			{
				this.m_Crc32.SlurpBlock(buffer, offset, num2);
			}
			return num2;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00007EBD File Offset: 0x000060BD
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				this.m_Crc32.SlurpBlock(buffer, offset, count);
			}
			this.m_innerStream.Write(buffer, offset, count);
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00007EDF File Offset: 0x000060DF
		public override bool CanRead
		{
			get
			{
				return this.m_innerStream.CanRead;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000574A File Offset: 0x0000394A
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00007EEC File Offset: 0x000060EC
		public override bool CanWrite
		{
			get
			{
				return this.m_innerStream.CanWrite;
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00007EF9 File Offset: 0x000060F9
		public override void Flush()
		{
			this.m_innerStream.Flush();
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00007F06 File Offset: 0x00006106
		public override long Length
		{
			get
			{
				if (this.m_lengthLimit == CrcCalculatorStream.UnsetLengthLimit)
				{
					return this.m_innerStream.Length;
				}
				return this.m_lengthLimit;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x00007E92 File Offset: 0x00006092
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Position
		{
			get
			{
				return this.m_Crc32.TotalBytesRead;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00007F27 File Offset: 0x00006127
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00007F2E File Offset: 0x0000612E
		void IDisposable.Dispose()
		{
			this.Close();
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00007F36 File Offset: 0x00006136
		public override void Close()
		{
			base.Close();
			if (!this.LeaveOpen)
			{
				this.m_innerStream.Close();
			}
		}

		// Token: 0x0400022E RID: 558
		private static readonly long UnsetLengthLimit = -99L;

		// Token: 0x0400022F RID: 559
		internal Stream m_innerStream;

		// Token: 0x04000230 RID: 560
		private readonly CRC32 m_Crc32;

		// Token: 0x04000231 RID: 561
		private readonly long m_lengthLimit = -99L;
	}
}
