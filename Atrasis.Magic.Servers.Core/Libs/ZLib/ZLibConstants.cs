using System;

namespace Atrasis.Magic.Servers.Core.Libs.ZLib
{
	// Token: 0x020000E3 RID: 227
	public static class ZLibConstants
	{
		// Token: 0x040003A6 RID: 934
		public const int WindowBitsMax = 15;

		// Token: 0x040003A7 RID: 935
		public const int WindowBitsDefault = 15;

		// Token: 0x040003A8 RID: 936
		public const int Z_OK = 0;

		// Token: 0x040003A9 RID: 937
		public const int Z_STREAM_END = 1;

		// Token: 0x040003AA RID: 938
		public const int Z_NEED_DICT = 2;

		// Token: 0x040003AB RID: 939
		public const int Z_STREAM_ERROR = -2;

		// Token: 0x040003AC RID: 940
		public const int Z_DATA_ERROR = -3;

		// Token: 0x040003AD RID: 941
		public const int Z_BUF_ERROR = -5;

		// Token: 0x040003AE RID: 942
		public const int WorkingBufferSizeDefault = 16384;

		// Token: 0x040003AF RID: 943
		public const int WorkingBufferSizeMin = 1024;
	}
}
