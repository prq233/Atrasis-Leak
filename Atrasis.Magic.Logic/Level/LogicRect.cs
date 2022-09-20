using System;

namespace Atrasis.Magic.Logic.Level
{
	// Token: 0x02000100 RID: 256
	public sealed class LogicRect
	{
		// Token: 0x06000C36 RID: 3126 RVA: 0x00008D7A File Offset: 0x00006F7A
		public LogicRect(int startX, int startY, int endX, int endY)
		{
			this.int_0 = startX;
			this.int_1 = startY;
			this.int_2 = endX;
			this.int_3 = endY;
		}

		// Token: 0x06000C37 RID: 3127 RVA: 0x00002465 File Offset: 0x00000665
		public void Destruct()
		{
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x00008D9F File Offset: 0x00006F9F
		public int GetStartX()
		{
			return this.int_0;
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x00008DA7 File Offset: 0x00006FA7
		public int GetStartY()
		{
			return this.int_1;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x00008DAF File Offset: 0x00006FAF
		public int GetEndX()
		{
			return this.int_2;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x00008DB7 File Offset: 0x00006FB7
		public int GetEndY()
		{
			return this.int_3;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x00008DBF File Offset: 0x00006FBF
		public bool IsInside(int x, int y)
		{
			return this.int_0 <= x && this.int_1 <= y && this.int_2 >= x && this.int_3 >= y;
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x00008DEC File Offset: 0x00006FEC
		public bool IsInside(LogicRect rect)
		{
			return this.int_0 <= rect.int_0 && this.int_1 <= rect.int_1 && this.int_2 > rect.int_2 && this.int_3 > rect.int_3;
		}

		// Token: 0x040004DF RID: 1247
		private readonly int int_0;

		// Token: 0x040004E0 RID: 1248
		private readonly int int_1;

		// Token: 0x040004E1 RID: 1249
		private readonly int int_2;

		// Token: 0x040004E2 RID: 1250
		private readonly int int_3;
	}
}
