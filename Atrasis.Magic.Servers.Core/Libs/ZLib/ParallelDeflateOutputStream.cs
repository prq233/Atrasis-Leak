using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D3 RID: 211
	public class ParallelDeflateOutputStream : Stream
	{
		// Token: 0x06000623 RID: 1571 RVA: 0x00008483 File Offset: 0x00006683
		public ParallelDeflateOutputStream(Stream stream) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, false)
		{
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0000848F File Offset: 0x0000668F
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level) : this(stream, level, CompressionStrategy.Default, false)
		{
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0000849B File Offset: 0x0000669B
		public ParallelDeflateOutputStream(Stream stream, bool leaveOpen) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
		{
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000084A7 File Offset: 0x000066A7
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, bool leaveOpen) : this(stream, CompressionLevel.Default, CompressionStrategy.Default, leaveOpen)
		{
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0001305C File Offset: 0x0001125C
		public ParallelDeflateOutputStream(Stream stream, CompressionLevel level, CompressionStrategy strategy, bool leaveOpen)
		{
			this.m_outStream = stream;
			this.m_compressLevel = level;
			this.Strategy = strategy;
			this.m_leaveOpen = leaveOpen;
			this.MaxBufferPairs = 16;
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x000084B3 File Offset: 0x000066B3
		public CompressionStrategy Strategy { get; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x000084BB File Offset: 0x000066BB
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x000084C3 File Offset: 0x000066C3
		public int MaxBufferPairs
		{
			get
			{
				return this.m_maxBufferPairs;
			}
			set
			{
				if (value < 4)
				{
					throw new ArgumentException("MaxBufferPairs", "Value must be 4 or greater.");
				}
				this.m_maxBufferPairs = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x000084E0 File Offset: 0x000066E0
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x000084E8 File Offset: 0x000066E8
		public int BufferSize
		{
			get
			{
				return this.m_bufferSize;
			}
			set
			{
				if (value < 1024)
				{
					throw new ArgumentOutOfRangeException("BufferSize", "BufferSize must be greater than 1024 bytes");
				}
				this.m_bufferSize = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00008509 File Offset: 0x00006709
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x00008511 File Offset: 0x00006711
		public int Crc32 { get; private set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x0000851A File Offset: 0x0000671A
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x00008522 File Offset: 0x00006722
		public long BytesProcessed { get; private set; }

		// Token: 0x06000631 RID: 1585 RVA: 0x000130CC File Offset: 0x000112CC
		private void m_InitializePoolOfWorkItems()
		{
			this.m_toWrite = new Queue<int>();
			this.m_toFill = new Queue<int>();
			this.m_pool = new List<WorkItem>();
			int num = ParallelDeflateOutputStream.BufferPairsPerCore * Environment.ProcessorCount;
			num = Math.Min(num, this.m_maxBufferPairs);
			for (int i = 0; i < num; i++)
			{
				this.m_pool.Add(new WorkItem(this.m_bufferSize, this.m_compressLevel, this.Strategy, i));
				this.m_toFill.Enqueue(i);
			}
			this.m_newlyCompressedBlob = new AutoResetEvent(false);
			this.m_runningCrc = new CRC32();
			this.m_currentlyFilling = -1;
			this.m_lastFilled = -1;
			this.m_lastWritten = -1;
			this.m_latestCompressed = -1;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00013184 File Offset: 0x00011384
		public override void Write(byte[] buffer, int offset, int count)
		{
			bool mustWait = false;
			if (this.m_isClosed)
			{
				throw new InvalidOperationException();
			}
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (count == 0)
			{
				return;
			}
			if (!this.m_firstWriteDone)
			{
				this.m_InitializePoolOfWorkItems();
				this.m_firstWriteDone = true;
			}
			for (;;)
			{
				this.EmitPendingBuffers(false, mustWait);
				mustWait = false;
				int num;
				if (this.m_currentlyFilling >= 0)
				{
					num = this.m_currentlyFilling;
					goto IL_82;
				}
				if (this.m_toFill.Count != 0)
				{
					num = this.m_toFill.Dequeue();
					this.m_lastFilled++;
					goto IL_82;
				}
				mustWait = true;
				IL_120:
				if (count <= 0)
				{
					break;
				}
				continue;
				IL_82:
				WorkItem workItem = this.m_pool[num];
				int num2 = (workItem.buffer.Length - workItem.inputBytesAvailable > count) ? count : (workItem.buffer.Length - workItem.inputBytesAvailable);
				workItem.ordinal = this.m_lastFilled;
				Buffer.BlockCopy(buffer, offset, workItem.buffer, workItem.inputBytesAvailable, num2);
				count -= num2;
				offset += num2;
				workItem.inputBytesAvailable += num2;
				if (workItem.inputBytesAvailable != workItem.buffer.Length)
				{
					this.m_currentlyFilling = num;
					goto IL_120;
				}
				if (ThreadPool.QueueUserWorkItem(new WaitCallback(this.m_DeflateOne), workItem))
				{
					this.m_currentlyFilling = -1;
					goto IL_120;
				}
				goto IL_14C;
			}
			return;
			IL_14C:
			throw new Exception("Cannot enqueue workitem");
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x000132E8 File Offset: 0x000114E8
		private void m_FlushFinish()
		{
			byte[] array = new byte[128];
			ZLibCodec zlibCodec = new ZLibCodec();
			int num = zlibCodec.InitializeDeflate(this.m_compressLevel, false);
			zlibCodec.InputBuffer = null;
			zlibCodec.NextIn = 0;
			zlibCodec.AvailableBytesIn = 0;
			zlibCodec.OutputBuffer = array;
			zlibCodec.NextOut = 0;
			zlibCodec.AvailableBytesOut = array.Length;
			num = zlibCodec.Deflate(FlushType.Finish);
			if (num != 1 && num != 0)
			{
				throw new Exception("deflating: " + zlibCodec.Message);
			}
			if (array.Length - zlibCodec.AvailableBytesOut > 0)
			{
				this.m_outStream.Write(array, 0, array.Length - zlibCodec.AvailableBytesOut);
			}
			zlibCodec.EndDeflate();
			this.Crc32 = this.m_runningCrc.Crc32Result;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x000133A4 File Offset: 0x000115A4
		private void m_Flush(bool lastInput)
		{
			if (this.m_isClosed)
			{
				throw new InvalidOperationException();
			}
			if (this.emitting)
			{
				return;
			}
			if (this.m_currentlyFilling >= 0)
			{
				WorkItem wi = this.m_pool[this.m_currentlyFilling];
				this.m_DeflateOne(wi);
				this.m_currentlyFilling = -1;
			}
			if (lastInput)
			{
				this.EmitPendingBuffers(true, false);
				this.m_FlushFinish();
				return;
			}
			this.EmitPendingBuffers(false, false);
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0000852B File Offset: 0x0000672B
		public override void Flush()
		{
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (this.m_handlingException)
			{
				return;
			}
			this.m_Flush(false);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0001340C File Offset: 0x0001160C
		public override void Close()
		{
			if (this.m_pendingException != null)
			{
				this.m_handlingException = true;
				Exception pendingException = this.m_pendingException;
				this.m_pendingException = null;
				throw pendingException;
			}
			if (this.m_handlingException)
			{
				return;
			}
			if (this.m_isClosed)
			{
				return;
			}
			this.m_Flush(true);
			if (!this.m_leaveOpen)
			{
				this.m_outStream.Close();
			}
			this.m_isClosed = true;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x00008560 File Offset: 0x00006760
		public new void Dispose()
		{
			this.Close();
			this.m_pool = null;
			this.Dispose(true);
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x00008576 File Offset: 0x00006776
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x00013470 File Offset: 0x00011670
		public void Reset(Stream stream)
		{
			if (!this.m_firstWriteDone)
			{
				return;
			}
			this.m_toWrite.Clear();
			this.m_toFill.Clear();
			foreach (WorkItem workItem in this.m_pool)
			{
				this.m_toFill.Enqueue(workItem.index);
				workItem.ordinal = -1;
			}
			this.m_firstWriteDone = false;
			this.BytesProcessed = 0L;
			this.m_runningCrc = new CRC32();
			this.m_isClosed = false;
			this.m_currentlyFilling = -1;
			this.m_lastFilled = -1;
			this.m_lastWritten = -1;
			this.m_latestCompressed = -1;
			this.m_outStream = stream;
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x00013540 File Offset: 0x00011740
		private void EmitPendingBuffers(bool doAll, bool mustWait)
		{
			if (this.emitting)
			{
				return;
			}
			this.emitting = true;
			if (doAll || mustWait)
			{
				this.m_newlyCompressedBlob.WaitOne();
			}
			do
			{
				int num = -1;
				int num2 = doAll ? 200 : (mustWait ? -1 : 0);
				int num3 = -1;
				do
				{
					if (Monitor.TryEnter(this.m_toWrite, num2))
					{
						num3 = -1;
						try
						{
							if (this.m_toWrite.Count > 0)
							{
								num3 = this.m_toWrite.Dequeue();
							}
						}
						finally
						{
							Monitor.Exit(this.m_toWrite);
						}
						if (num3 >= 0)
						{
							WorkItem workItem = this.m_pool[num3];
							if (workItem.ordinal != this.m_lastWritten + 1)
							{
								Queue<int> toWrite = this.m_toWrite;
								lock (toWrite)
								{
									this.m_toWrite.Enqueue(num3);
								}
								if (num == num3)
								{
									this.m_newlyCompressedBlob.WaitOne();
									num = -1;
								}
								else if (num == -1)
								{
									num = num3;
								}
							}
							else
							{
								num = -1;
								this.m_outStream.Write(workItem.compressed, 0, workItem.compressedBytesAvailable);
								this.m_runningCrc.Combine(workItem.crc, workItem.inputBytesAvailable);
								this.BytesProcessed += (long)workItem.inputBytesAvailable;
								workItem.inputBytesAvailable = 0;
								this.m_lastWritten = workItem.ordinal;
								this.m_toFill.Enqueue(workItem.index);
								if (num2 == -1)
								{
									num2 = 0;
								}
							}
						}
					}
					else
					{
						num3 = -1;
					}
				}
				while (num3 >= 0);
				if (!doAll)
				{
					break;
				}
			}
			while (this.m_lastWritten != this.m_latestCompressed);
			this.emitting = false;
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0001370C File Offset: 0x0001190C
		private void m_DeflateOne(object wi)
		{
			WorkItem workItem = (WorkItem)wi;
			try
			{
				CRC32 crc = new CRC32();
				crc.SlurpBlock(workItem.buffer, 0, workItem.inputBytesAvailable);
				this.DeflateOneSegment(workItem);
				workItem.crc = crc.Crc32Result;
				object obj = this.m_latestLock;
				lock (obj)
				{
					if (workItem.ordinal > this.m_latestCompressed)
					{
						this.m_latestCompressed = workItem.ordinal;
					}
				}
				Queue<int> toWrite = this.m_toWrite;
				lock (toWrite)
				{
					this.m_toWrite.Enqueue(workItem.index);
				}
				this.m_newlyCompressedBlob.Set();
			}
			catch (Exception pendingException)
			{
				object obj = this.m_eLock;
				lock (obj)
				{
					if (this.m_pendingException != null)
					{
						this.m_pendingException = pendingException;
					}
				}
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0001382C File Offset: 0x00011A2C
		private bool DeflateOneSegment(WorkItem workitem)
		{
			ZLibCodec compressor = workitem.compressor;
			compressor.ResetDeflate();
			compressor.NextIn = 0;
			compressor.AvailableBytesIn = workitem.inputBytesAvailable;
			compressor.NextOut = 0;
			compressor.AvailableBytesOut = workitem.compressed.Length;
			do
			{
				compressor.Deflate(FlushType.None);
			}
			while (compressor.AvailableBytesIn > 0 || compressor.AvailableBytesOut == 0);
			compressor.Deflate(FlushType.Sync);
			workitem.compressedBytesAvailable = (int)compressor.TotalBytesOut;
			return true;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x000138A4 File Offset: 0x00011AA4
		[Conditional("Trace")]
		private void TraceOutput(ParallelDeflateOutputStream.TraceBits bits, string format, params object[] varParams)
		{
			if ((bits & this.m_DesiredTrace) != ParallelDeflateOutputStream.TraceBits.None)
			{
				object outputLock = this.m_outputLock;
				lock (outputLock)
				{
					int hashCode = Thread.CurrentThread.GetHashCode();
					Console.ForegroundColor = hashCode % 8 + ConsoleColor.DarkGray;
					Console.Write("{0:000} PDOS ", hashCode);
					Console.WriteLine(format, varParams);
					Console.ResetColor();
				}
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000574A File Offset: 0x0000394A
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x0000574A File Offset: 0x0000394A
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000857F File Offset: 0x0000677F
		public override bool CanWrite
		{
			get
			{
				return this.m_outStream.CanWrite;
			}
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000858C File Offset: 0x0000678C
		// (set) Token: 0x06000643 RID: 1603 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Position
		{
			get
			{
				return this.m_outStream.Position;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x00007F27 File Offset: 0x00006127
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x00007F27 File Offset: 0x00006127
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00007F27 File Offset: 0x00006127
		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		// Token: 0x0400030F RID: 783
		private static readonly int IO_BUFFER_SIZE_DEFAULT = 65536;

		// Token: 0x04000310 RID: 784
		private static readonly int BufferPairsPerCore = 4;

		// Token: 0x04000311 RID: 785
		private List<WorkItem> m_pool;

		// Token: 0x04000312 RID: 786
		private readonly bool m_leaveOpen;

		// Token: 0x04000313 RID: 787
		private bool emitting;

		// Token: 0x04000314 RID: 788
		private Stream m_outStream;

		// Token: 0x04000315 RID: 789
		private int m_maxBufferPairs;

		// Token: 0x04000316 RID: 790
		private int m_bufferSize = ParallelDeflateOutputStream.IO_BUFFER_SIZE_DEFAULT;

		// Token: 0x04000317 RID: 791
		private AutoResetEvent m_newlyCompressedBlob;

		// Token: 0x04000318 RID: 792
		private readonly object m_outputLock = new object();

		// Token: 0x04000319 RID: 793
		private bool m_isClosed;

		// Token: 0x0400031A RID: 794
		private bool m_firstWriteDone;

		// Token: 0x0400031B RID: 795
		private int m_currentlyFilling;

		// Token: 0x0400031C RID: 796
		private int m_lastFilled;

		// Token: 0x0400031D RID: 797
		private int m_lastWritten;

		// Token: 0x0400031E RID: 798
		private int m_latestCompressed;

		// Token: 0x0400031F RID: 799
		private CRC32 m_runningCrc;

		// Token: 0x04000320 RID: 800
		private readonly object m_latestLock = new object();

		// Token: 0x04000321 RID: 801
		private Queue<int> m_toWrite;

		// Token: 0x04000322 RID: 802
		private Queue<int> m_toFill;

		// Token: 0x04000323 RID: 803
		private readonly CompressionLevel m_compressLevel;

		// Token: 0x04000324 RID: 804
		private volatile Exception m_pendingException;

		// Token: 0x04000325 RID: 805
		private bool m_handlingException;

		// Token: 0x04000326 RID: 806
		private readonly object m_eLock = new object();

		// Token: 0x04000327 RID: 807
		private readonly ParallelDeflateOutputStream.TraceBits m_DesiredTrace = ParallelDeflateOutputStream.TraceBits.EmitLock | ParallelDeflateOutputStream.TraceBits.EmitEnter | ParallelDeflateOutputStream.TraceBits.EmitBegin | ParallelDeflateOutputStream.TraceBits.EmitDone | ParallelDeflateOutputStream.TraceBits.EmitSkip | ParallelDeflateOutputStream.TraceBits.Session | ParallelDeflateOutputStream.TraceBits.Compress | ParallelDeflateOutputStream.TraceBits.WriteEnter | ParallelDeflateOutputStream.TraceBits.WriteTake;

		// Token: 0x020000D4 RID: 212
		[Flags]
		private enum TraceBits : uint
		{
			// Token: 0x0400032C RID: 812
			None = 0U,
			// Token: 0x0400032D RID: 813
			NotUsed1 = 1U,
			// Token: 0x0400032E RID: 814
			EmitLock = 2U,
			// Token: 0x0400032F RID: 815
			EmitEnter = 4U,
			// Token: 0x04000330 RID: 816
			EmitBegin = 8U,
			// Token: 0x04000331 RID: 817
			EmitDone = 16U,
			// Token: 0x04000332 RID: 818
			EmitSkip = 32U,
			// Token: 0x04000333 RID: 819
			EmitAll = 58U,
			// Token: 0x04000334 RID: 820
			Flush = 64U,
			// Token: 0x04000335 RID: 821
			Lifecycle = 128U,
			// Token: 0x04000336 RID: 822
			Session = 256U,
			// Token: 0x04000337 RID: 823
			Synch = 512U,
			// Token: 0x04000338 RID: 824
			Instance = 1024U,
			// Token: 0x04000339 RID: 825
			Compress = 2048U,
			// Token: 0x0400033A RID: 826
			Write = 4096U,
			// Token: 0x0400033B RID: 827
			WriteEnter = 8192U,
			// Token: 0x0400033C RID: 828
			WriteTake = 16384U,
			// Token: 0x0400033D RID: 829
			All = 4294967295U
		}
	}
}
