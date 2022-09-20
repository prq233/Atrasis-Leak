using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000156 RID: 342
	public class LogicLeagueData : LogicData
	{
		// Token: 0x060013F9 RID: 5113 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicLeagueData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060013FA RID: 5114 RVA: 0x0005096C File Offset: 0x0004EB6C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.string_0 = base.GetValue("LeagueBannerIcon", 0);
			this.string_1 = base.GetValue("LeagueBannerIconNum", 0);
			this.string_2 = base.GetValue("LeagueBannerIconHUD", 0);
			this.int_0 = base.GetIntegerValue("GoldReward", 0);
			this.int_1 = base.GetIntegerValue("ElixirReward", 0);
			this.int_2 = base.GetIntegerValue("DarkElixirReward", 0);
			this.bool_0 = base.GetBooleanValue("UseStarBonus", 0);
			this.int_3 = base.GetIntegerValue("GoldRewardStarBonus", 0);
			this.int_4 = base.GetIntegerValue("ElixirRewardStarBonus", 0);
			this.int_5 = base.GetIntegerValue("DarkElixirRewardStarBonus", 0);
			this.int_6 = base.GetIntegerValue("PlacementLimitLow", 0);
			this.int_7 = base.GetIntegerValue("PlacementLimitHigh", 0);
			this.int_8 = base.GetIntegerValue("DemoteLimit", 0);
			this.int_9 = base.GetIntegerValue("PromoteLimit", 0);
			this.bool_1 = base.GetBooleanValue("IgnoredByServer", 0);
			this.bool_2 = base.GetBooleanValue("DemoteEnabled", 0);
			this.bool_3 = base.GetBooleanValue("PromoteEnabled", 0);
			this.int_10 = base.GetIntegerValue("AllocateAmount", 0);
			this.int_11 = base.GetIntegerValue("SaverCount", 0);
			this.int_12 = base.GetIntegerValue("VillageGuardInMins", 0);
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.int_13 = new int[biggestArraySize];
			this.int_14 = new int[biggestArraySize];
			this.int_15 = new int[biggestArraySize];
			this.int_16 = new int[biggestArraySize];
			for (int i = 0; i < biggestArraySize; i++)
			{
				this.int_13[i] = base.GetIntegerValue("BucketPlacementRangeLow", i);
				this.int_14[i] = base.GetIntegerValue("BucketPlacementRangeHigh", i);
				this.int_15[i] = base.GetIntegerValue("BucketPlacementSoftLimit", i);
				this.int_16[i] = base.GetIntegerValue("BucketPlacementHardLimit", i);
			}
		}

		// Token: 0x060013FB RID: 5115 RVA: 0x0000D317 File Offset: 0x0000B517
		public int GetBucketPlacementRangeLow(int index)
		{
			return this.int_13[index];
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x0000D321 File Offset: 0x0000B521
		public int GetBucketPlacementRangeHigh(int index)
		{
			return this.int_14[index];
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x0000D32B File Offset: 0x0000B52B
		public int GetBucketPlacementSoftLimit(int index)
		{
			return this.int_15[index];
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x0000D335 File Offset: 0x0000B535
		public int GetBucketPlacementHardLimit(int index)
		{
			return this.int_16[index];
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x0000D33F File Offset: 0x0000B53F
		public string GetLeagueBannerIcon()
		{
			return this.string_0;
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x0000D347 File Offset: 0x0000B547
		public string GetLeagueBannerIconNum()
		{
			return this.string_1;
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x0000D34F File Offset: 0x0000B54F
		public string GetLeagueBannerIconHUD()
		{
			return this.string_2;
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x0000D357 File Offset: 0x0000B557
		public int GetGoldReward()
		{
			return this.int_0;
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0000D35F File Offset: 0x0000B55F
		public int GetElixirReward()
		{
			return this.int_1;
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0000D367 File Offset: 0x0000B567
		public int GetDarkElixirReward()
		{
			return this.int_2;
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x0000D36F File Offset: 0x0000B56F
		public bool GetUseStarBonus()
		{
			return this.bool_0;
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x0000D377 File Offset: 0x0000B577
		public int GetGoldRewardStarBonus()
		{
			return this.int_3;
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x0000D37F File Offset: 0x0000B57F
		public int GetElixirRewardStarBonus()
		{
			return this.int_4;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0000D387 File Offset: 0x0000B587
		public int GetDarkElixirRewardStarBonus()
		{
			return this.int_5;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0000D38F File Offset: 0x0000B58F
		public int GetPlacementLimitLow()
		{
			return this.int_6;
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x0000D397 File Offset: 0x0000B597
		public int GetPlacementLimitHigh()
		{
			return this.int_7;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x0000D39F File Offset: 0x0000B59F
		public int GetDemoteLimit()
		{
			return this.int_8;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x0000D3A7 File Offset: 0x0000B5A7
		public int GetPromoteLimit()
		{
			return this.int_9;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0000D3AF File Offset: 0x0000B5AF
		public bool IsIgnoredByServer()
		{
			return this.bool_1;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0000D3B7 File Offset: 0x0000B5B7
		public bool IsDemoteEnabled()
		{
			return this.bool_2;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0000D3BF File Offset: 0x0000B5BF
		public bool IsPromoteEnabled()
		{
			return this.bool_3;
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0000D3C7 File Offset: 0x0000B5C7
		public int GetAllocateAmount()
		{
			return this.int_10;
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x0000D3CF File Offset: 0x0000B5CF
		public int GetSaverCount()
		{
			return this.int_11;
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x0000D3D7 File Offset: 0x0000B5D7
		public int GetVillageGuardInMins()
		{
			return this.int_12;
		}

		// Token: 0x04000A3C RID: 2620
		private string string_0;

		// Token: 0x04000A3D RID: 2621
		private string string_1;

		// Token: 0x04000A3E RID: 2622
		private string string_2;

		// Token: 0x04000A3F RID: 2623
		private int int_0;

		// Token: 0x04000A40 RID: 2624
		private int int_1;

		// Token: 0x04000A41 RID: 2625
		private int int_2;

		// Token: 0x04000A42 RID: 2626
		private int int_3;

		// Token: 0x04000A43 RID: 2627
		private int int_4;

		// Token: 0x04000A44 RID: 2628
		private int int_5;

		// Token: 0x04000A45 RID: 2629
		private int int_6;

		// Token: 0x04000A46 RID: 2630
		private int int_7;

		// Token: 0x04000A47 RID: 2631
		private int int_8;

		// Token: 0x04000A48 RID: 2632
		private int int_9;

		// Token: 0x04000A49 RID: 2633
		private int int_10;

		// Token: 0x04000A4A RID: 2634
		private int int_11;

		// Token: 0x04000A4B RID: 2635
		private int int_12;

		// Token: 0x04000A4C RID: 2636
		private int[] int_13;

		// Token: 0x04000A4D RID: 2637
		private int[] int_14;

		// Token: 0x04000A4E RID: 2638
		private int[] int_15;

		// Token: 0x04000A4F RID: 2639
		private int[] int_16;

		// Token: 0x04000A50 RID: 2640
		private bool bool_0;

		// Token: 0x04000A51 RID: 2641
		private bool bool_1;

		// Token: 0x04000A52 RID: 2642
		private bool bool_2;

		// Token: 0x04000A53 RID: 2643
		private bool bool_3;
	}
}
