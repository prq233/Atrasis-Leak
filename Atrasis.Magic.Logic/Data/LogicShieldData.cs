using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000163 RID: 355
	public class LogicShieldData : LogicData
	{
		// Token: 0x060014E3 RID: 5347 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicShieldData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x00052374 File Offset: 0x00050574
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("Diamonds", 0);
			this.int_1 = base.GetIntegerValue("CooldownS", 0);
			this.int_2 = base.GetIntegerValue("LockedAboveScore", 0);
			this.int_3 = base.GetIntegerValue("TimeH", 0);
			this.int_4 = base.GetIntegerValue("GuardTimeH", 0);
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0000D9F0 File Offset: 0x0000BBF0
		public int GetDiamondsCost()
		{
			return this.int_0;
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x0000D9F8 File Offset: 0x0000BBF8
		public int GetCooldownSecs()
		{
			return this.int_1;
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0000DA00 File Offset: 0x0000BC00
		public int GetScoreLimit()
		{
			return this.int_2;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0000DA08 File Offset: 0x0000BC08
		public int GetTimeHours()
		{
			return this.int_3;
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0000DA10 File Offset: 0x0000BC10
		public int GetGuardTimeHours()
		{
			return this.int_4;
		}

		// Token: 0x04000B1B RID: 2843
		private int int_0;

		// Token: 0x04000B1C RID: 2844
		private int int_1;

		// Token: 0x04000B1D RID: 2845
		private int int_2;

		// Token: 0x04000B1E RID: 2846
		private int int_3;

		// Token: 0x04000B1F RID: 2847
		private int int_4;
	}
}
