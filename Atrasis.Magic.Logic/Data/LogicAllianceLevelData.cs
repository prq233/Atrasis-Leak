using System;
using Atrasis.Magic.Titan.CSV;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000137 RID: 311
	public class LogicAllianceLevelData : LogicData
	{
		// Token: 0x060010AC RID: 4268 RVA: 0x0000B345 File Offset: 0x00009545
		public LogicAllianceLevelData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0004A990 File Offset: 0x00048B90
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.bool_0 = base.GetBooleanValue("IsVisible", 0);
			this.int_0 = base.GetIntegerValue("ExpPoints", 0);
			LogicAllianceLevelData logicAllianceLevelData = null;
			if (base.GetInstanceID() > 0)
			{
				logicAllianceLevelData = (LogicAllianceLevelData)this.m_table.GetItemAt(base.GetInstanceID() - 1);
			}
			this.int_1 = base.GetIntegerValue("TroopRequestCooldown", 0);
			if (logicAllianceLevelData != null && this.int_1 == 0)
			{
				this.int_1 = logicAllianceLevelData.int_1;
			}
			this.int_2 = base.GetIntegerValue("TroopDonationLimit", 0);
			if (logicAllianceLevelData != null && this.int_2 == 0)
			{
				this.int_2 = logicAllianceLevelData.int_2;
			}
			this.int_3 = base.GetIntegerValue("TroopDonationRefund", 0);
			if (logicAllianceLevelData != null && this.int_3 == 0)
			{
				this.int_3 = logicAllianceLevelData.int_3;
			}
			this.int_4 = base.GetIntegerValue("TroopDonationUpgrade", 0);
			if (logicAllianceLevelData != null && this.int_4 == 0)
			{
				this.int_4 = logicAllianceLevelData.int_4;
			}
			this.int_5 = base.GetIntegerValue("WarLootCapacityPercent", 0);
			if (logicAllianceLevelData != null && this.int_5 == 0)
			{
				this.int_5 = logicAllianceLevelData.int_5;
			}
			this.int_6 = base.GetIntegerValue("WarLootMultiplierPercent", 0);
			if (logicAllianceLevelData != null && this.int_6 == 0)
			{
				this.int_6 = logicAllianceLevelData.int_6;
			}
			this.int_7 = base.GetIntegerValue("BadgeLevel", 0);
			if (logicAllianceLevelData != null && this.int_7 == 0)
			{
				this.int_7 = logicAllianceLevelData.int_7;
			}
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0000B42F File Offset: 0x0000962F
		public bool IsVisible()
		{
			return this.bool_0;
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0000B437 File Offset: 0x00009637
		public int GetExpPoints()
		{
			return this.int_0;
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0000B43F File Offset: 0x0000963F
		public int GetTroopRequestCooldown()
		{
			return this.int_1;
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0000B447 File Offset: 0x00009647
		public int GetTroopDonationLimit()
		{
			return this.int_2;
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x0000B44F File Offset: 0x0000964F
		public int GetTroopDonationRefund()
		{
			return this.int_3;
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0000B457 File Offset: 0x00009657
		public int GetTroopDonationUpgrade()
		{
			return this.int_4;
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x0000B45F File Offset: 0x0000965F
		public int GetWarLootCapacityPercent()
		{
			return this.int_5;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x0000B467 File Offset: 0x00009667
		public int GetWarLootMultiplierPercent()
		{
			return this.int_6;
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0000B46F File Offset: 0x0000966F
		public int GetBadgeLevel()
		{
			return this.int_7;
		}

		// Token: 0x040006F2 RID: 1778
		private int int_0;

		// Token: 0x040006F3 RID: 1779
		private bool bool_0;

		// Token: 0x040006F4 RID: 1780
		private int int_1;

		// Token: 0x040006F5 RID: 1781
		private int int_2;

		// Token: 0x040006F6 RID: 1782
		private int int_3;

		// Token: 0x040006F7 RID: 1783
		private int int_4;

		// Token: 0x040006F8 RID: 1784
		private int int_5;

		// Token: 0x040006F9 RID: 1785
		private int int_6;

		// Token: 0x040006FA RID: 1786
		private int int_7;
	}
}
