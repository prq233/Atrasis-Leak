using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000157 RID: 343
	public class LogicLeagueVillage2Data : LogicData
	{
		// Token: 0x06001413 RID: 5139 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicLeagueVillage2Data(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x00050B80 File Offset: 0x0004ED80
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_0 = base.GetIntegerValue("TrophyLimitLow", 0);
			this.int_1 = base.GetIntegerValue("TrophyLimitHigh", 0);
			this.int_2 = base.GetIntegerValue("GoldReward", 0);
			this.int_3 = base.GetIntegerValue("ElixirReward", 0);
			this.int_4 = base.GetIntegerValue("BonusGold", 0);
			this.int_5 = base.GetIntegerValue("BonusElixir", 0);
			this.int_6 = base.GetIntegerValue("SeasonTrophyReset", 0);
			this.int_7 = base.GetIntegerValue("MaxDiamondCost", 0);
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x0000D3DF File Offset: 0x0000B5DF
		public int GetTrophyLimitLow()
		{
			return this.int_0;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x0000D3E7 File Offset: 0x0000B5E7
		public int GetTrophyLimitHigh()
		{
			return this.int_1;
		}

		// Token: 0x06001417 RID: 5143 RVA: 0x0000D3EF File Offset: 0x0000B5EF
		public int GetGoldReward()
		{
			return this.int_2;
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
		public int GetElixirReward()
		{
			return this.int_3;
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x0000D3FF File Offset: 0x0000B5FF
		public int GetBonusGold()
		{
			return this.int_4;
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0000D407 File Offset: 0x0000B607
		public int GetBonusElixir()
		{
			return this.int_5;
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0000D40F File Offset: 0x0000B60F
		public int GetSeasonTrophyReset()
		{
			return this.int_6;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x0000D417 File Offset: 0x0000B617
		public int GetMaxDiamondCost()
		{
			return this.int_7;
		}

		// Token: 0x04000A54 RID: 2644
		private int int_0;

		// Token: 0x04000A55 RID: 2645
		private int int_1;

		// Token: 0x04000A56 RID: 2646
		private int int_2;

		// Token: 0x04000A57 RID: 2647
		private int int_3;

		// Token: 0x04000A58 RID: 2648
		private int int_4;

		// Token: 0x04000A59 RID: 2649
		private int int_5;

		// Token: 0x04000A5A RID: 2650
		private int int_6;

		// Token: 0x04000A5B RID: 2651
		private int int_7;
	}
}
