using System;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000165 RID: 357
	public class LogicTownhallLevelData : LogicData
	{
		// Token: 0x06001532 RID: 5426 RVA: 0x0000DCD9 File Offset: 0x0000BED9
		public LogicTownhallLevelData(CSVRow row, LogicDataTable table) : base(row, table)
		{
			this.int_2 = -1;
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x00052C3C File Offset: 0x00050E3C
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.logicArrayList_0 = new LogicArrayList<int>();
			this.logicArrayList_1 = new LogicArrayList<int>();
			this.logicArrayList_2 = new LogicArrayList<int>();
			this.logicArrayList_3 = new LogicArrayList<int>();
			LogicTownhallLevelData logicTownhallLevelData = null;
			if (base.GetInstanceID() > 0)
			{
				logicTownhallLevelData = (LogicTownhallLevelData)this.m_table.GetItemAt(base.GetInstanceID() - 1);
			}
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicData itemAt = table.GetItemAt(i);
				int num = base.GetIntegerValue(itemAt.GetName(), 0);
				int num2 = base.GetIntegerValue(itemAt.GetName() + "_gearup", 0);
				if (logicTownhallLevelData != null)
				{
					if (num == 0)
					{
						num = logicTownhallLevelData.logicArrayList_0[i];
					}
					if (num2 == 0)
					{
						num2 = logicTownhallLevelData.logicArrayList_1[i];
					}
				}
				this.logicArrayList_0.Add(num);
				this.logicArrayList_1.Add(num2);
			}
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.TRAP);
			for (int j = 0; j < table2.GetItemCount(); j++)
			{
				int num3 = base.GetIntegerValue(table2.GetItemAt(j).GetName(), 0);
				if (logicTownhallLevelData != null && num3 == 0)
				{
					num3 = logicTownhallLevelData.logicArrayList_2[j];
				}
				this.logicArrayList_2.Add(num3);
			}
			LogicDataTable table3 = LogicDataTables.GetTable(LogicDataType.RESOURCE);
			for (int k = 0; k < table3.GetItemCount(); k++)
			{
				this.logicArrayList_3.Add(base.GetIntegerValue("Treasury" + table3.GetItemAt(k).GetName(), 0));
			}
			this.int_0 = base.GetIntegerValue("AttackCost", 0);
			this.int_1 = base.GetIntegerValue("AttackCostVillage2", 0);
			this.int_4 = base.GetIntegerValue("ResourceStorageLootPercentage", 0);
			this.int_5 = base.GetIntegerValue("DarkElixirStorageLootPercentage", 0);
			this.int_6 = base.GetIntegerValue("ResourceStorageLootCap", 0);
			this.int_7 = base.GetIntegerValue("DarkElixirStorageLootCap", 0);
			this.int_8 = base.GetIntegerValue("WarPrizeResourceCap", 0);
			this.int_9 = base.GetIntegerValue("WarPrizeDarkElixirCap", 0);
			this.int_10 = base.GetIntegerValue("WarPrizeAllianceExpCap", 0);
			this.int_11 = base.GetIntegerValue("CartLootCapResource", 0);
			this.int_12 = base.GetIntegerValue("CartLootReengagementResource", 0);
			this.int_13 = base.GetIntegerValue("CartLootCapDarkElixir", 0);
			this.int_14 = base.GetIntegerValue("CartLootReengagementDarkElixir", 0);
			this.int_15 = base.GetIntegerValue("StrengthMaxTroopTypes", 0);
			this.int_16 = base.GetIntegerValue("StrengthMaxSpellTypes", 0);
			this.int_3 = base.GetIntegerValue("FriendlyCost", 0);
			this.int_17 = base.GetIntegerValue("PackElixir", 0);
			this.int_18 = base.GetIntegerValue("PackGold", 0);
			this.int_19 = base.GetIntegerValue("PackDarkElixir", 0);
			this.int_20 = base.GetIntegerValue("PackGold2", 0);
			this.int_21 = base.GetIntegerValue("PackElixir2", 0);
			this.int_22 = base.GetIntegerValue("DuelPrizeResourceCap", 0);
			this.int_23 = base.GetIntegerValue("ChangeTroopCost", 0);
			if (this.int_5 > 100 || this.int_5 > 100)
			{
				Debugger.Error("townhall_levels.csv: Invalid loot percentage!");
			}
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0000DCEA File Offset: 0x0000BEEA
		public int GetStorageLootPercentage(LogicResourceData data)
		{
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.int_5;
			}
			return this.int_4;
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0000DD01 File Offset: 0x0000BF01
		public int GetAttackCost()
		{
			return this.int_0;
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0000DD09 File Offset: 0x0000BF09
		public int GetAttackCostVillage2()
		{
			return this.int_1;
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0000DD11 File Offset: 0x0000BF11
		public int GetFriendlyCost()
		{
			return this.int_3;
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0000DD19 File Offset: 0x0000BF19
		public int GetStorageLootCap(LogicResourceData data)
		{
			if (data == null || data.IsPremiumCurrency())
			{
				return 0;
			}
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.int_7;
			}
			return this.int_6;
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0000DD3D File Offset: 0x0000BF3D
		public int GetCartLootCap(LogicResourceData data)
		{
			if (data == null || data.IsPremiumCurrency())
			{
				return 0;
			}
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.int_13;
			}
			return this.int_11;
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0000DD61 File Offset: 0x0000BF61
		public int GetCartLootReengagement(LogicResourceData data)
		{
			if (data == null || data.IsPremiumCurrency() || data.GetWarResourceReferenceData() != null || data.GetVillageType() == 1)
			{
				return 0;
			}
			if (LogicDataTables.GetDarkElixirData() == data)
			{
				return this.int_14;
			}
			return this.int_12;
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0000DD96 File Offset: 0x0000BF96
		public int GetMaxHousingSpace()
		{
			if (this.int_2 == -1)
			{
				this.CalculateHousingSpaceCap();
			}
			return this.int_2;
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x00052F8C File Offset: 0x0005118C
		public void CalculateHousingSpaceCap()
		{
			this.int_2 = 0;
			if (base.GetInstanceID() > 0)
			{
				this.m_table.GetItemAt(base.GetInstanceID() - 1);
			}
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.BUILDING);
			int itemCount = this.m_table.GetItemCount();
			if (itemCount > 0)
			{
				int unitHousingCostMultiplierForTotal = LogicDataTables.GetGlobals().GetUnitHousingCostMultiplierForTotal();
				int spellHousingCostMultiplierForTotal = LogicDataTables.GetGlobals().GetSpellHousingCostMultiplierForTotal();
				int heroHousingCostMultiplierForTotal = LogicDataTables.GetGlobals().GetHeroHousingCostMultiplierForTotal();
				int allianceUnitHousingCostMultiplierForTotal = LogicDataTables.GetGlobals().GetAllianceUnitHousingCostMultiplierForTotal();
				int num = 0;
				do
				{
					LogicBuildingData logicBuildingData = (LogicBuildingData)table.GetItemAt(num);
					int num2 = this.logicArrayList_0[num];
					if (num2 > 0)
					{
						int num3 = unitHousingCostMultiplierForTotal;
						int maxUpgradeLevelForTownHallLevel = logicBuildingData.GetMaxUpgradeLevelForTownHallLevel(base.GetInstanceID());
						if (maxUpgradeLevelForTownHallLevel >= 0)
						{
							int num4 = logicBuildingData.GetUnitStorageCapacity(maxUpgradeLevelForTownHallLevel);
							if (!logicBuildingData.IsAllianceCastle())
							{
								if (!logicBuildingData.IsForgesMiniSpells() && !logicBuildingData.IsForgesSpells())
								{
									if (logicBuildingData.IsHeroBarrack())
									{
										num4 = logicBuildingData.GetHeroData().GetHousingSpace();
										num3 = heroHousingCostMultiplierForTotal;
									}
								}
								else
								{
									num3 = spellHousingCostMultiplierForTotal;
								}
							}
							else
							{
								num3 = allianceUnitHousingCostMultiplierForTotal;
							}
							if (num4 > 0)
							{
								this.int_2 += num3 * num2 * num4 / 100;
							}
						}
					}
				}
				while (++num != itemCount);
			}
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0000DDAD File Offset: 0x0000BFAD
		public int GetUnlockedBuildingCount(LogicBuildingData data)
		{
			return this.logicArrayList_0[data.GetInstanceID()];
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0000DDC0 File Offset: 0x0000BFC0
		public int GetUnlockedBuildingGearupCount(LogicBuildingData data)
		{
			return this.logicArrayList_1[data.GetInstanceID()];
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0000DDD3 File Offset: 0x0000BFD3
		public int GetUnlockedTrapCount(LogicTrapData data)
		{
			return this.logicArrayList_2[data.GetInstanceID()];
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0000DDE6 File Offset: 0x0000BFE6
		public LogicArrayList<int> GetTreasuryCaps()
		{
			return this.logicArrayList_3;
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0000DDEE File Offset: 0x0000BFEE
		public int GetStrengthMaxTroopTypes()
		{
			return this.int_15;
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0000DDF6 File Offset: 0x0000BFF6
		public int GetStrengthMaxSpellTypes()
		{
			return this.int_16;
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0000DDFE File Offset: 0x0000BFFE
		public int GetPackElixir()
		{
			return this.int_17;
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x0000DE06 File Offset: 0x0000C006
		public int GetPackGold()
		{
			return this.int_18;
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0000DE0E File Offset: 0x0000C00E
		public int GetPackDarkElixir()
		{
			return this.int_19;
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0000DE16 File Offset: 0x0000C016
		public int GetPackGold2()
		{
			return this.int_20;
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0000DE1E File Offset: 0x0000C01E
		public int GetPackElixir2()
		{
			return this.int_21;
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0000DE26 File Offset: 0x0000C026
		public int GetDuelPrizeResourceCap()
		{
			return this.int_22;
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0000DE2E File Offset: 0x0000C02E
		public int GetChangeTroopCost()
		{
			return this.int_23;
		}

		// Token: 0x04000B60 RID: 2912
		private LogicArrayList<int> logicArrayList_0;

		// Token: 0x04000B61 RID: 2913
		private LogicArrayList<int> logicArrayList_1;

		// Token: 0x04000B62 RID: 2914
		private LogicArrayList<int> logicArrayList_2;

		// Token: 0x04000B63 RID: 2915
		private LogicArrayList<int> logicArrayList_3;

		// Token: 0x04000B64 RID: 2916
		private int int_0;

		// Token: 0x04000B65 RID: 2917
		private int int_1;

		// Token: 0x04000B66 RID: 2918
		private int int_2;

		// Token: 0x04000B67 RID: 2919
		private int int_3;

		// Token: 0x04000B68 RID: 2920
		private int int_4;

		// Token: 0x04000B69 RID: 2921
		private int int_5;

		// Token: 0x04000B6A RID: 2922
		private int int_6;

		// Token: 0x04000B6B RID: 2923
		private int int_7;

		// Token: 0x04000B6C RID: 2924
		private int int_8;

		// Token: 0x04000B6D RID: 2925
		private int int_9;

		// Token: 0x04000B6E RID: 2926
		private int int_10;

		// Token: 0x04000B6F RID: 2927
		private int int_11;

		// Token: 0x04000B70 RID: 2928
		private int int_12;

		// Token: 0x04000B71 RID: 2929
		private int int_13;

		// Token: 0x04000B72 RID: 2930
		private int int_14;

		// Token: 0x04000B73 RID: 2931
		private int int_15;

		// Token: 0x04000B74 RID: 2932
		private int int_16;

		// Token: 0x04000B75 RID: 2933
		private int int_17;

		// Token: 0x04000B76 RID: 2934
		private int int_18;

		// Token: 0x04000B77 RID: 2935
		private int int_19;

		// Token: 0x04000B78 RID: 2936
		private int int_20;

		// Token: 0x04000B79 RID: 2937
		private int int_21;

		// Token: 0x04000B7A RID: 2938
		private int int_22;

		// Token: 0x04000B7B RID: 2939
		private int int_23;
	}
}
