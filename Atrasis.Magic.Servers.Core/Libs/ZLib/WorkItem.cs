using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000D2 RID: 210
	internal class WorkItem
	{
		// Token: 0x06000622 RID: 1570 RVA: 0x00012FDC File Offset: 0x000111DC
		public WorkItem(int size, CompressionLevel compressLevel, CompressionStrategy strategy, int ix)
		{
			this.buffer = new byte[size];
			int num = size + (size / 32768 + 1) * 5 * 2;
			this.compressed = new byte[num];
			this.compressor = new ZLibCodec();
			this.compressor.InitializeDeflate(compressLevel, false);
			this.compressor.OutputBuffer = this.compressed;
			this.compressor.InputBuffer = this.buffer;
			this.index = ix;
		}

		// Token: 0x04000307 RID: 775
		public byte[] buffer;

		// Token: 0x04000308 RID: 776
		public byte[] compressed;

		// Token: 0x04000309 RID: 777
		public int crc;

		// Token: 0x0400030A RID: 778
		public int index;

		// Token: 0x0400030B RID: 779
		public int ordinal;

		// Token: 0x0400030C RID: 780
		public int inputBytesAvailable;

		// Token: 0x0400030D RID: 781
		public int compressedBytesAvailable;

		// Token: 0x0400030E RID: 782
		public ZLibCodec compressor;
	}
}
