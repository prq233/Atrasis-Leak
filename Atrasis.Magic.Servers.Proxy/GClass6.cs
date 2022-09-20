using System;

namespace ns0
{
	// Token: 0x0200000C RID: 12
	public class GClass6
	{
		// Token: 0x0600004E RID: 78 RVA: 0x0000231D File Offset: 0x0000051D
		public GClass6(int int_1)
		{
			this.byte_0 = new byte[int_1];
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002331 File Offset: 0x00000531
		public void method_0()
		{
			this.byte_0 = null;
			this.int_0 = 0;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003324 File Offset: 0x00001524
		public void method_1(byte[] byte_1, int int_1)
		{
			if (this.byte_0.Length < this.int_0 + int_1)
			{
				byte[] dst = new byte[this.int_0 + int_1];
				Buffer.BlockCopy(this.byte_0, 0, dst, 0, this.int_0);
				this.byte_0 = dst;
			}
			Buffer.BlockCopy(byte_1, 0, this.byte_0, this.int_0, int_1);
			this.int_0 += int_1;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003390 File Offset: 0x00001590
		public void method_2(int int_1)
		{
			Buffer.BlockCopy(this.byte_0, int_1, this.byte_0, 0, this.int_0 -= int_1);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002341 File Offset: 0x00000541
		public int method_3()
		{
			return this.int_0;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002349 File Offset: 0x00000549
		public byte[] method_4()
		{
			return this.byte_0;
		}

		// Token: 0x04000035 RID: 53
		private byte[] byte_0;

		// Token: 0x04000036 RID: 54
		private int int_0;
	}
}
