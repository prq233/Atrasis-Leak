using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Util;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x0200013F RID: 319
	public class LogicBuildingData : LogicGameObjectData
	{
		// Token: 0x0600112B RID: 4395 RVA: 0x0000B477 File Offset: 0x00009677
		public LogicBuildingData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x0004B868 File Offset: 0x00049A68
		public override void CreateReferences()
		{
			base.CreateReferences();
			this.int_46 = this.m_row.GetBiggestArraySize();
			this.logicBuildingClassData_0 = LogicDataTables.GetBuildingClassByName(base.GetValue("BuildingClass", 0), this);
			if (this.logicBuildingClassData_0 == null)
			{
				Debugger.Error("Building class is not defined for " + base.GetName());
			}
			this.logicBuildingClassData_1 = LogicDataTables.GetBuildingClassByName(base.GetValue("SecondaryTargetingClass", 0), this);
			this.logicBuildingClassData_2 = LogicDataTables.GetBuildingClassByName(base.GetValue("ShopBuildingClass", 0), this);
			if (this.logicBuildingClassData_2 == null)
			{
				this.logicBuildingClassData_2 = this.logicBuildingClassData_0;
			}
			this.string_0 = base.GetValue("ExportNameNpc", 0);
			this.string_1 = base.GetValue("ExportNameConstruction", 0);
			this.string_2 = base.GetValue("ExportNameLocked", 0);
			this.int_24 = base.GetIntegerValue("Width", 0);
			this.int_25 = base.GetIntegerValue("Height", 0);
			this.bool_0 = base.GetBooleanValue("LootOnDestruction", 0);
			this.bool_1 = base.GetBooleanValue("Bunker", 0);
			this.int_26 = base.GetIntegerValue("Village2Housing", 0);
			this.bool_2 = base.GetBooleanValue("UpgradesUnits", 0);
			this.int_27 = base.GetIntegerValue("ProducesUnitsOfType", 0);
			this.bool_3 = base.GetBooleanValue("FreeBoost", 0);
			this.bool_4 = base.GetBooleanValue("RandomHitPosition", 0);
			this.int_28 = base.GetIntegerValue("ChainAttackDistance", 0);
			this.int_29 = base.GetIntegerValue("BuildingW", 0);
			this.int_30 = base.GetIntegerValue("BuildingH", 0);
			if (this.int_29 == 0)
			{
				this.int_29 = this.int_24;
			}
			if (this.int_30 == 0)
			{
				this.int_30 = this.int_25;
			}
			this.int_31 = base.GetIntegerValue("BaseGfx", 0);
			this.logicEffectData_0 = LogicDataTables.GetEffectByName(base.GetValue("LoadAmmoEffect", 0), this);
			this.logicEffectData_1 = LogicDataTables.GetEffectByName(base.GetValue("NoAmmoEffect", 0), this);
			this.logicEffectData_2 = LogicDataTables.GetEffectByName(base.GetValue("ToggleAttackModeEffect", 0), this);
			this.logicEffectData_3 = LogicDataTables.GetEffectByName(base.GetValue("PickUpEffect", 0), this);
			this.logicEffectData_4 = LogicDataTables.GetEffectByName(base.GetValue("PlacingEffect", 0), this);
			this.bool_5 = base.GetBooleanValue("CanNotSellLast", 0);
			this.bool_6 = base.GetBooleanValue("Locked", 0);
			this.int_32 = base.GetIntegerValue("StartingHomeCount", 0);
			this.bool_7 = base.GetBooleanValue("Hidden", 0);
			this.int_33 = (base.GetIntegerValue("TriggerRadius", 0) << 9) / 100;
			this.logicEffectData_5 = LogicDataTables.GetEffectByName(base.GetValue("AppearEffect", 0), this);
			this.bool_8 = base.GetBooleanValue("ForgesSpells", 0);
			this.bool_9 = base.GetBooleanValue("ForgesMiniSpells", 0);
			this.bool_10 = base.GetBooleanValue("IsHeroBarrack", 0);
			this.int_34 = base.GetIntegerValue("AimRotateStep", 0);
			this.int_35 = base.GetIntegerValue("TurnSpeed", 0);
			if (this.int_35 == 0)
			{
				this.int_35 = 500;
			}
			this.bool_11 = base.GetBooleanValue("NeedsAim", 0);
			this.string_3 = base.GetValue("ExportNameBeamStart", 0);
			this.string_4 = base.GetValue("ExportNameBeamEnd", 0);
			this.bool_12 = base.GetBooleanValue("ShareHeroCombatData", 0);
			this.int_36 = (base.GetIntegerValue("DieDamageRadius", 0) << 9) / 100;
			this.logicEffectData_6 = LogicDataTables.GetEffectByName(base.GetValue("DieDamageEffect", 0), this);
			this.int_37 = base.GetIntegerValue("DieDamageDelay", 0);
			if (this.int_37 > 4000)
			{
				Debugger.Warning("m_dieDamageDelay too big");
				this.int_37 = 4000;
			}
			this.bool_13 = base.GetBooleanValue("IsRed", 0);
			this.int_38 = base.GetIntegerValue("RedMul", 0);
			this.int_39 = base.GetIntegerValue("GreenMul", 0);
			this.int_40 = base.GetIntegerValue("BlueMul", 0);
			this.int_41 = base.GetIntegerValue("RedAdd", 0);
			this.int_42 = base.GetIntegerValue("GreenAdd", 0);
			this.int_43 = base.GetIntegerValue("BlueAdd", 0);
			this.bool_14 = base.GetBooleanValue("SelfAsAoeCenter", 0);
			this.int_44 = base.GetIntegerValue("NewTargetAttackDelay", 0);
			this.int_45 = base.GetIntegerValue("GearUpLevelRequirement", 0);
			this.bool_1 = base.GetBooleanValue("Bunker", 0);
			int biggestArraySize = this.m_row.GetBiggestArraySize();
			this.logicResourceData_0 = new LogicResourceData[biggestArraySize];
			this.logicResourceData_1 = new LogicResourceData[biggestArraySize];
			this.logicArrayList_0 = new LogicArrayList<int>[biggestArraySize];
			this.logicArrayList_1 = new LogicArrayList<int>[biggestArraySize];
			this.logicResourceData_2 = new LogicResourceData[biggestArraySize];
			this.logicArrayList_2 = new LogicArrayList<LogicAttackerItemData>(biggestArraySize);
			this.logicCharacterData_0 = new LogicCharacterData[biggestArraySize];
			this.logicCharacterData_1 = new LogicCharacterData[biggestArraySize];
			this.int_0 = new int[biggestArraySize];
			this.int_9 = new int[biggestArraySize];
			this.int_2 = new int[biggestArraySize];
			this.int_3 = new int[biggestArraySize];
			this.int_1 = new int[biggestArraySize];
			this.int_6 = new int[biggestArraySize];
			this.int_7 = new int[biggestArraySize];
			this.int_8 = new int[biggestArraySize];
			this.int_10 = new int[biggestArraySize];
			this.int_11 = new int[biggestArraySize];
			this.int_12 = new int[biggestArraySize];
			this.int_13 = new int[biggestArraySize];
			this.int_14 = new int[biggestArraySize];
			this.int_15 = new int[biggestArraySize];
			this.int_16 = new int[biggestArraySize];
			this.int_17 = new int[biggestArraySize];
			this.int_18 = new int[biggestArraySize];
			this.int_19 = new int[biggestArraySize];
			this.int_20 = new int[biggestArraySize];
			this.int_22 = new int[biggestArraySize];
			this.int_21 = new int[biggestArraySize];
			this.int_23 = new int[biggestArraySize];
			this.int_4 = new int[0];
			this.int_5 = new int[0];
			for (int i = 0; i < biggestArraySize; i++)
			{
				LogicAttackerItemData logicAttackerItemData = new LogicAttackerItemData();
				logicAttackerItemData.CreateReferences(this.m_row, this, i);
				this.logicArrayList_2.Add(logicAttackerItemData);
				this.int_23[i] = base.GetClampedIntegerValue("DieDamage", i);
				this.int_0[i] = base.GetClampedIntegerValue("BuildCost", i);
				this.int_10[i] = base.GetClampedIntegerValue("HousingSpace", i);
				this.int_11[i] = base.GetClampedIntegerValue("HousingSpaceAlt", i);
				this.int_18[i] = base.GetClampedIntegerValue("UnitProduction", i);
				this.int_7[i] = base.GetClampedIntegerValue("GearUpCost", i);
				this.int_8[i] = base.GetClampedIntegerValue("BoostCost", i);
				this.int_12[i] = base.GetClampedIntegerValue("ResourcePer100Hours", i);
				this.int_13[i] = base.GetClampedIntegerValue("ResourceMax", i);
				this.int_14[i] = base.GetClampedIntegerValue("ResourceIconLimit", i);
				this.int_15[i] = base.GetClampedIntegerValue("Hitpoints", i);
				this.int_16[i] = base.GetClampedIntegerValue("RegenTime", i);
				this.int_17[i] = base.GetClampedIntegerValue("AmountCanBeUpgraded", i);
				this.logicResourceData_0[i] = LogicDataTables.GetResourceByName(base.GetClampedValue("BuildResource", i), this);
				this.logicResourceData_1[i] = LogicDataTables.GetResourceByName(base.GetClampedValue("AltBuildResource", i), this);
				this.int_2[i] = LogicMath.Max(base.GetClampedIntegerValue("TownHallLevel", i) - 1, 0);
				this.int_3[i] = LogicMath.Max(base.GetClampedIntegerValue("TownHallLevel2", i) - 1, 0);
				this.logicArrayList_0[i] = new LogicArrayList<int>();
				this.logicArrayList_1[i] = new LogicArrayList<int>();
				LogicDataTable table = LogicDataTables.GetTable(LogicDataType.RESOURCE);
				for (int j = 0; j < table.GetItemCount(); j++)
				{
					this.logicArrayList_0[i].Add(base.GetClampedIntegerValue("MaxStored" + table.GetItemAt(j).GetName(), i));
					this.logicArrayList_1[i].Add(base.GetClampedIntegerValue("PercentageStored" + table.GetItemAt(j).GetName(), i));
				}
				this.int_6[i] = 60 * base.GetClampedIntegerValue("GearUpTime", i);
				this.int_1[i] = 86400 * base.GetClampedIntegerValue("BuildTimeD", i) + 3600 * base.GetClampedIntegerValue("BuildTimeH", i) + 60 * base.GetClampedIntegerValue("BuildTimeM", i) + base.GetIntegerValue("BuildTimeS", i);
				this.int_20[i] = base.GetClampedIntegerValue("DestructionXP", i);
				this.logicResourceData_2[i] = LogicDataTables.GetResourceByName(base.GetClampedValue("AmmoResource", i), this);
				this.int_9[i] = base.GetClampedIntegerValue("AmmoCost", i);
				this.int_19[i] = base.GetClampedIntegerValue("StrengthWeight", i);
				string clampedValue = base.GetClampedValue("DefenceTroopCharacter", i);
				if (clampedValue.Length > 0)
				{
					this.logicCharacterData_0[i] = LogicDataTables.GetCharacterByName(clampedValue, this);
				}
				string clampedValue2 = base.GetClampedValue("DefenceTroopCharacter2", i);
				if (clampedValue2.Length > 0)
				{
					this.logicCharacterData_1[i] = LogicDataTables.GetCharacterByName(clampedValue2, this);
				}
				this.int_22[i] = base.GetIntegerValue("DefenceTroopCount", i);
				this.int_21[i] = base.GetIntegerValue("DefenceTroopLevel", i);
				if (i > 0 && this.int_10[i] < this.int_10[i - 1])
				{
					Debugger.Error("Building " + base.GetName() + " unit storage space decreases by upgrade level!");
				}
				if ((this.int_7[i] > 0 && this.int_6[i] <= 0) || (this.int_7[i] <= 0 && this.int_6[i] > 0))
				{
					Debugger.Error("invalid gear up settings. gear up time and cost must be set for levels where available");
				}
			}
			this.logicSpellData_0 = LogicDataTables.GetSpellByName(base.GetValue("AOESpell", 0), this);
			this.logicSpellData_1 = LogicDataTables.GetSpellByName(base.GetValue("AOESpellAlternate", 0), this);
			this.logicResourceData_4 = LogicDataTables.GetResourceByName(base.GetValue("ProducesResource", 0), this);
			this.logicResourceData_3 = LogicDataTables.GetResourceByName(base.GetValue("GearUpResource", 0), this);
			string value = base.GetValue("HeroType", 0);
			if (!string.IsNullOrEmpty(value))
			{
				this.logicHeroData_0 = LogicDataTables.GetHeroByName(value, this);
			}
			string value2 = base.GetValue("WallBlockX", 0);
			if (value2.Length > 0)
			{
				this.LoadWallBlock(value2, out this.int_4);
				this.LoadWallBlock(base.GetValue("WallBlockY", 0), out this.int_5);
				if (this.int_4.Length != this.int_5.Length)
				{
					Debugger.Error("LogicBuildingData: Error parsing wall offsets");
				}
				if (this.int_4.Length > 10)
				{
					Debugger.Error("LogicBuildingData: Too many wall blocks");
				}
			}
			string value3 = base.GetValue("GearUpBuilding", 0);
			if (value3.Length > 0)
			{
				this.logicBuildingData_0 = LogicDataTables.GetBuildingByName(value3, this);
			}
			this.bool_15 = base.GetName().Equals("Clock Tower");
			this.bool_16 = base.GetName().Equals("Flamer");
			this.bool_17 = base.GetName().Equals("Barrack2");
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x0004C414 File Offset: 0x0004A614
		public void LoadWallBlock(string value, out int[] wallBlock)
		{
			string[] array = value.Split(',', StringSplitOptions.None);
			wallBlock = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				wallBlock[i] = int.Parse(array[i]);
			}
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x0004C450 File Offset: 0x0004A650
		public int GetWallBlockIndex(int x, int y, int idx)
		{
			int num = this.int_4[idx];
			int num2 = this.int_5[idx];
			for (int i = 0; i < 4; i++)
			{
				if (x == num && num2 == y)
				{
					return i;
				}
				int num3 = x;
				x = -y;
				y = num3;
			}
			return -1;
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x0000B850 File Offset: 0x00009A50
		public LogicBuildingClassData GetBuildingClass()
		{
			return this.logicBuildingClassData_0;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x0000B858 File Offset: 0x00009A58
		public LogicAttackerItemData GetAttackerItemData(int idx)
		{
			return this.logicArrayList_2[idx];
		}

		// Token: 0x06001131 RID: 4401 RVA: 0x0000B866 File Offset: 0x00009A66
		public int GetUpgradeLevelCount()
		{
			return this.int_46;
		}

		// Token: 0x06001132 RID: 4402 RVA: 0x0000B86E File Offset: 0x00009A6E
		public int GetConstructionTime(int upgLevel, LogicLevel level, int ignoreBuildingCnt)
		{
			if (this.GetVillage2Housing() < 1)
			{
				return this.int_1[upgLevel];
			}
			return LogicDataTables.GetGlobals().GetTroopHousingBuildTimeVillage2(level, ignoreBuildingCnt);
		}

		// Token: 0x06001133 RID: 4403 RVA: 0x0000B88E File Offset: 0x00009A8E
		public bool IsTownHall()
		{
			return this.logicBuildingClassData_0.IsTownHall();
		}

		// Token: 0x06001134 RID: 4404 RVA: 0x0000B89B File Offset: 0x00009A9B
		public bool IsTownHallVillage2()
		{
			return this.logicBuildingClassData_0.IsTownHall2();
		}

		// Token: 0x06001135 RID: 4405 RVA: 0x0000B8A8 File Offset: 0x00009AA8
		public bool IsWorkerBuilding()
		{
			return this.logicBuildingClassData_0.IsWorker();
		}

		// Token: 0x06001136 RID: 4406 RVA: 0x0000B8B5 File Offset: 0x00009AB5
		public bool IsWall()
		{
			return this.logicBuildingClassData_0.IsWall();
		}

		// Token: 0x06001137 RID: 4407 RVA: 0x0000B8C2 File Offset: 0x00009AC2
		public bool IsAllianceCastle()
		{
			return this.bool_1;
		}

		// Token: 0x06001138 RID: 4408 RVA: 0x0000B8CA File Offset: 0x00009ACA
		public bool IsLaboratory()
		{
			return this.bool_2;
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0000B8D2 File Offset: 0x00009AD2
		public bool IsLocked()
		{
			return this.bool_6;
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0000B8DA File Offset: 0x00009ADA
		public bool IsClockTower()
		{
			return this.bool_15;
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x0000B8E2 File Offset: 0x00009AE2
		public bool IsFlamer()
		{
			return this.bool_16;
		}

		// Token: 0x0600113C RID: 4412 RVA: 0x0000B8EA File Offset: 0x00009AEA
		public bool IsBarrackVillage2()
		{
			return this.bool_17;
		}

		// Token: 0x0600113D RID: 4413 RVA: 0x0000B8F2 File Offset: 0x00009AF2
		public int GetUnitStorageCapacity(int level)
		{
			return this.int_10[level];
		}

		// Token: 0x0600113E RID: 4414 RVA: 0x0000B8FC File Offset: 0x00009AFC
		public int GetAltUnitStorageCapacity(int level)
		{
			return this.int_11[level];
		}

		// Token: 0x0600113F RID: 4415 RVA: 0x0000B906 File Offset: 0x00009B06
		public LogicResourceData GetGearUpResource()
		{
			return this.logicResourceData_3;
		}

		// Token: 0x06001140 RID: 4416 RVA: 0x0000B90E File Offset: 0x00009B0E
		public LogicResourceData GetBuildResource(int idx)
		{
			return this.logicResourceData_0[idx];
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x0000B918 File Offset: 0x00009B18
		public LogicResourceData GetAltBuildResource(int idx)
		{
			return this.logicResourceData_1[idx];
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x0000B922 File Offset: 0x00009B22
		public LogicResourceData GetProduceResource()
		{
			return this.logicResourceData_4;
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x0000B92A File Offset: 0x00009B2A
		public LogicHeroData GetHeroData()
		{
			return this.logicHeroData_0;
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x0000B932 File Offset: 0x00009B32
		public LogicBuildingData GetGearUpBuildingData()
		{
			return this.logicBuildingData_0;
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x0000B93A File Offset: 0x00009B3A
		public LogicSpellData GetAreaOfEffectSpell()
		{
			return this.logicSpellData_0;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x0000B942 File Offset: 0x00009B42
		public LogicSpellData GetAltAreaOfEffectSpell()
		{
			return this.logicSpellData_1;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x0000B94A File Offset: 0x00009B4A
		public int GetBuildCost(int index, LogicLevel level)
		{
			if (this.GetVillage2Housing() > 0)
			{
				return LogicDataTables.GetGlobals().GetTroopHousingBuildCostVillage2(level);
			}
			if (this.logicBuildingClassData_0.IsWorker())
			{
				return LogicDataTables.GetGlobals().GetWorkerCost(level);
			}
			return this.int_0[index];
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x0004C490 File Offset: 0x0004A690
		public int GetRequiredTownHallLevel(int index)
		{
			if (index == 0 && LogicDataTables.GetTownHallLevelCount() >= 1)
			{
				for (int i = 0; i < LogicDataTables.GetTownHallLevelCount(); i++)
				{
					if (LogicDataTables.GetTownHallLevel(i).GetUnlockedBuildingCount(this) > 0)
					{
						return i;
					}
				}
				return this.int_2[index];
			}
			return this.int_2[index];
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x0000B982 File Offset: 0x00009B82
		public int GetTownHallLevel2(int index)
		{
			return this.int_3[index];
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0000B98C File Offset: 0x00009B8C
		public int GetWidth()
		{
			return this.int_24;
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x0000B994 File Offset: 0x00009B94
		public int GetHeight()
		{
			return this.int_25;
		}

		// Token: 0x0600114C RID: 4428 RVA: 0x0004C4DC File Offset: 0x0004A6DC
		public bool StoresResources()
		{
			LogicArrayList<int> logicArrayList = this.logicArrayList_0[0];
			for (int i = 0; i < logicArrayList.Size(); i++)
			{
				if (logicArrayList[i] > 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600114D RID: 4429 RVA: 0x0000B99C File Offset: 0x00009B9C
		public int GetMaxStoredGold(int upgLevel)
		{
			return this.logicArrayList_0[upgLevel][LogicDataTables.GetGoldData().GetInstanceID()];
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x0000B9B5 File Offset: 0x00009BB5
		public int GetMaxStoredElixir(int upgLevel)
		{
			return this.logicArrayList_0[upgLevel][LogicDataTables.GetElixirData().GetInstanceID()];
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x0000B9CE File Offset: 0x00009BCE
		public int GetMaxStoredDarkElixir(int upgLevel)
		{
			return this.logicArrayList_0[upgLevel][LogicDataTables.GetDarkElixirData().GetInstanceID()];
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x0004C510 File Offset: 0x0004A710
		public int GetMaxUpgradeLevelForTownHallLevel(int townHallLevel)
		{
			int i = this.int_46;
			while (i > 0)
			{
				if (this.GetRequiredTownHallLevel(--i) <= townHallLevel)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001151 RID: 4433 RVA: 0x0004C53C File Offset: 0x0004A73C
		public int GetMinUpgradeLevelForGearUp()
		{
			int num = this.int_46;
			for (int i = 0; i < num; i++)
			{
				if (this.int_7[i] > 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001152 RID: 4434 RVA: 0x0000B9E7 File Offset: 0x00009BE7
		public LogicArrayList<int> GetMaxStoredResourceCounts(int idx)
		{
			return this.logicArrayList_0[idx];
		}

		// Token: 0x06001153 RID: 4435 RVA: 0x0000B9F1 File Offset: 0x00009BF1
		public LogicArrayList<int> GetMaxPercentageStoredResourceCounts(int idx)
		{
			return this.logicArrayList_1[idx];
		}

		// Token: 0x06001154 RID: 4436 RVA: 0x0000B9FB File Offset: 0x00009BFB
		public int GetResourcePer100Hours(int index)
		{
			return this.int_12[index];
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x0000BA05 File Offset: 0x00009C05
		public int GetResourceMax(int index)
		{
			return this.int_13[index];
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x0000BA0F File Offset: 0x00009C0F
		public int GetResourceIconLimit(int index)
		{
			return this.int_14[index];
		}

		// Token: 0x06001157 RID: 4439 RVA: 0x0000BA19 File Offset: 0x00009C19
		public int GetBoostCost(int index)
		{
			return this.int_8[index];
		}

		// Token: 0x06001158 RID: 4440 RVA: 0x0000BA23 File Offset: 0x00009C23
		public int GetHitpoints(int index)
		{
			return this.int_15[index];
		}

		// Token: 0x06001159 RID: 4441 RVA: 0x0000BA2D File Offset: 0x00009C2D
		public int GetRegenerationTime(int index)
		{
			return this.int_16[index];
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0000BA37 File Offset: 0x00009C37
		public int GetAmmoCost(int index, int count)
		{
			if (count < 1)
			{
				return 0;
			}
			return LogicMath.Max(this.int_9[index] * count / this.logicArrayList_2[index].GetAmmoCount(), 1);
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0000BA61 File Offset: 0x00009C61
		public LogicResourceData GetAmmoResourceData(int idx)
		{
			return this.logicResourceData_2[idx];
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0000BA6B File Offset: 0x00009C6B
		public int GetAmountCanBeUpgraded(int index)
		{
			return this.int_17[index];
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0000BA75 File Offset: 0x00009C75
		public int GetGearUpCost(int index)
		{
			return this.int_7[index];
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0000BA7F File Offset: 0x00009C7F
		public int GetGearUpTime(int index)
		{
			return this.int_6[index];
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0000BA89 File Offset: 0x00009C89
		public int GetWallBlockX(int index)
		{
			return this.int_4[index];
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0000BA93 File Offset: 0x00009C93
		public int GetWallBlockY(int index)
		{
			return this.int_5[index];
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0000BA9D File Offset: 0x00009C9D
		public int GetWallBlockCount()
		{
			return this.int_4.Length;
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0000BAA7 File Offset: 0x00009CA7
		public string GetExportNameNpc()
		{
			return this.string_0;
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0000BAAF File Offset: 0x00009CAF
		public string GetExportNameConstruction()
		{
			return this.string_1;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0000BAB7 File Offset: 0x00009CB7
		public string GetExportNameLocked()
		{
			return this.string_2;
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0000BABF File Offset: 0x00009CBF
		public bool IsLootOnDestruction()
		{
			return this.bool_0;
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0000BAC7 File Offset: 0x00009CC7
		public int GetVillage2Housing()
		{
			return this.int_26;
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x0000BACF File Offset: 0x00009CCF
		public bool IsFreeBoost()
		{
			return this.bool_3;
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x0000BAD7 File Offset: 0x00009CD7
		public bool IsRandomHitPosition()
		{
			return this.bool_4;
		}

		// Token: 0x06001169 RID: 4457 RVA: 0x0000BADF File Offset: 0x00009CDF
		public int GetChainAttackDistance()
		{
			return this.int_28;
		}

		// Token: 0x0600116A RID: 4458 RVA: 0x0000BAE7 File Offset: 0x00009CE7
		public int GetBuildingW()
		{
			return this.int_29;
		}

		// Token: 0x0600116B RID: 4459 RVA: 0x0000BAEF File Offset: 0x00009CEF
		public int GetBuildingH()
		{
			return this.int_30;
		}

		// Token: 0x0600116C RID: 4460 RVA: 0x0000BAF7 File Offset: 0x00009CF7
		public int GetBaseGfx()
		{
			return this.int_31;
		}

		// Token: 0x0600116D RID: 4461 RVA: 0x0000BAFF File Offset: 0x00009CFF
		public LogicEffectData GetLoadAmmoEffect()
		{
			return this.logicEffectData_0;
		}

		// Token: 0x0600116E RID: 4462 RVA: 0x0000BB07 File Offset: 0x00009D07
		public LogicEffectData GetNoAmmoEffect()
		{
			return this.logicEffectData_1;
		}

		// Token: 0x0600116F RID: 4463 RVA: 0x0000BB0F File Offset: 0x00009D0F
		public LogicEffectData GetToggleAttackModeEffect()
		{
			return this.logicEffectData_2;
		}

		// Token: 0x06001170 RID: 4464 RVA: 0x0000BB17 File Offset: 0x00009D17
		public LogicEffectData GetPickUpEffect()
		{
			return this.logicEffectData_3;
		}

		// Token: 0x06001171 RID: 4465 RVA: 0x0000BB1F File Offset: 0x00009D1F
		public LogicEffectData GetPlacingEffect()
		{
			return this.logicEffectData_4;
		}

		// Token: 0x06001172 RID: 4466 RVA: 0x0000BB27 File Offset: 0x00009D27
		public bool IsCanNotSellLast()
		{
			return this.bool_5;
		}

		// Token: 0x06001173 RID: 4467 RVA: 0x0000BB2F File Offset: 0x00009D2F
		public int GetStartingHomeCount()
		{
			return this.int_32;
		}

		// Token: 0x06001174 RID: 4468 RVA: 0x0000BB37 File Offset: 0x00009D37
		public bool IsHidden()
		{
			return this.bool_7;
		}

		// Token: 0x06001175 RID: 4469 RVA: 0x0000BB3F File Offset: 0x00009D3F
		public int GetTriggerRadius()
		{
			return this.int_33;
		}

		// Token: 0x06001176 RID: 4470 RVA: 0x0000BB47 File Offset: 0x00009D47
		public LogicEffectData GetAppearEffect()
		{
			return this.logicEffectData_5;
		}

		// Token: 0x06001177 RID: 4471 RVA: 0x0000BB4F File Offset: 0x00009D4F
		public bool IsForgesSpells()
		{
			return this.bool_8;
		}

		// Token: 0x06001178 RID: 4472 RVA: 0x0000BB57 File Offset: 0x00009D57
		public bool IsForgesMiniSpells()
		{
			return this.bool_9;
		}

		// Token: 0x06001179 RID: 4473 RVA: 0x0000BB5F File Offset: 0x00009D5F
		public int GetAimRotateStep()
		{
			return this.int_34;
		}

		// Token: 0x0600117A RID: 4474 RVA: 0x0000BB67 File Offset: 0x00009D67
		public int GetTurnSpeed()
		{
			return this.int_35;
		}

		// Token: 0x0600117B RID: 4475 RVA: 0x0000BB6F File Offset: 0x00009D6F
		public bool IsNeedsAim()
		{
			return this.bool_11;
		}

		// Token: 0x0600117C RID: 4476 RVA: 0x0000BB77 File Offset: 0x00009D77
		public string GetExportNameBeamStart()
		{
			return this.string_3;
		}

		// Token: 0x0600117D RID: 4477 RVA: 0x0000BB7F File Offset: 0x00009D7F
		public string GetExportNameBeamEnd()
		{
			return this.string_4;
		}

		// Token: 0x0600117E RID: 4478 RVA: 0x0000BB87 File Offset: 0x00009D87
		public bool GetShareHeroCombatData()
		{
			return this.bool_12;
		}

		// Token: 0x0600117F RID: 4479 RVA: 0x0000BB8F File Offset: 0x00009D8F
		public int GetDieDamageRadius()
		{
			return this.int_36;
		}

		// Token: 0x06001180 RID: 4480 RVA: 0x0000BB97 File Offset: 0x00009D97
		public LogicEffectData GetDieDamageEffect()
		{
			return this.logicEffectData_6;
		}

		// Token: 0x06001181 RID: 4481 RVA: 0x0000BB9F File Offset: 0x00009D9F
		public int GetDieDamage(int upgLevel)
		{
			return LogicGamePlayUtil.DPSToSingleHit(this.int_23[upgLevel], 1000);
		}

		// Token: 0x06001182 RID: 4482 RVA: 0x0000BBB3 File Offset: 0x00009DB3
		public int GetDieDamageDelay()
		{
			return this.int_37;
		}

		// Token: 0x06001183 RID: 4483 RVA: 0x0000BBBB File Offset: 0x00009DBB
		public int GetRedMul()
		{
			return this.int_38;
		}

		// Token: 0x06001184 RID: 4484 RVA: 0x0000BBC3 File Offset: 0x00009DC3
		public int GetGreenMul()
		{
			return this.int_39;
		}

		// Token: 0x06001185 RID: 4485 RVA: 0x0000BBCB File Offset: 0x00009DCB
		public int GetBlueMul()
		{
			return this.int_40;
		}

		// Token: 0x06001186 RID: 4486 RVA: 0x0000BBD3 File Offset: 0x00009DD3
		public int GetRedAdd()
		{
			return this.int_41;
		}

		// Token: 0x06001187 RID: 4487 RVA: 0x0000BBDB File Offset: 0x00009DDB
		public int GetGreenAdd()
		{
			return this.int_42;
		}

		// Token: 0x06001188 RID: 4488 RVA: 0x0000BBE3 File Offset: 0x00009DE3
		public int GetBlueAdd()
		{
			return this.int_43;
		}

		// Token: 0x06001189 RID: 4489 RVA: 0x0000BBEB File Offset: 0x00009DEB
		public LogicCharacterData GetDefenceTroopCharacter(int upgLevel)
		{
			return this.logicCharacterData_0[upgLevel];
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x0000BBF5 File Offset: 0x00009DF5
		public LogicCharacterData GetDefenceTroopCharacter2(int upgLevel)
		{
			return this.logicCharacterData_1[upgLevel];
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x0000BBFF File Offset: 0x00009DFF
		public int GetDefenceTroopCount(int upgLevel)
		{
			return this.int_22[upgLevel];
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x0000BC09 File Offset: 0x00009E09
		public int GetDefenceTroopLevel(int upgLevel)
		{
			return this.int_21[upgLevel];
		}

		// Token: 0x0600118D RID: 4493 RVA: 0x0000BC13 File Offset: 0x00009E13
		public bool IsSelfAsAoeCenter()
		{
			return this.bool_14;
		}

		// Token: 0x0600118E RID: 4494 RVA: 0x0000BC1B File Offset: 0x00009E1B
		public int GetNewTargetAttackDelay()
		{
			return this.int_44;
		}

		// Token: 0x0600118F RID: 4495 RVA: 0x0000BC23 File Offset: 0x00009E23
		public int GetGearUpLevelRequirement()
		{
			return this.int_45;
		}

		// Token: 0x06001190 RID: 4496 RVA: 0x0000BC2B File Offset: 0x00009E2B
		public int GetProducesUnitsOfType()
		{
			return this.int_27;
		}

		// Token: 0x06001191 RID: 4497 RVA: 0x0000BC33 File Offset: 0x00009E33
		public bool IsHeroBarrack()
		{
			return this.bool_10;
		}

		// Token: 0x06001192 RID: 4498 RVA: 0x0000BC3B File Offset: 0x00009E3B
		public bool IsRed()
		{
			return this.bool_13;
		}

		// Token: 0x06001193 RID: 4499 RVA: 0x0000BC43 File Offset: 0x00009E43
		public int GetUnitProduction(int index)
		{
			return this.int_18[index];
		}

		// Token: 0x06001194 RID: 4500 RVA: 0x0000BC4D File Offset: 0x00009E4D
		public int GetStrengthWeight(int index)
		{
			return this.int_19[index];
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x0000BC57 File Offset: 0x00009E57
		public int GetDestructionXP(int index)
		{
			return this.int_20[index];
		}

		// Token: 0x06001196 RID: 4502 RVA: 0x0000BC61 File Offset: 0x00009E61
		public LogicBuildingClassData GetSecondaryTargetingClass()
		{
			return this.logicBuildingClassData_1;
		}

		// Token: 0x06001197 RID: 4503 RVA: 0x0000BC69 File Offset: 0x00009E69
		public LogicBuildingClassData GetShopBuildingClass()
		{
			return this.logicBuildingClassData_2;
		}

		// Token: 0x04000776 RID: 1910
		private LogicBuildingData logicBuildingData_0;

		// Token: 0x04000777 RID: 1911
		private LogicBuildingClassData logicBuildingClassData_0;

		// Token: 0x04000778 RID: 1912
		private LogicBuildingClassData logicBuildingClassData_1;

		// Token: 0x04000779 RID: 1913
		private LogicBuildingClassData logicBuildingClassData_2;

		// Token: 0x0400077A RID: 1914
		private LogicResourceData[] logicResourceData_0;

		// Token: 0x0400077B RID: 1915
		private LogicResourceData[] logicResourceData_1;

		// Token: 0x0400077C RID: 1916
		private LogicResourceData[] logicResourceData_2;

		// Token: 0x0400077D RID: 1917
		private LogicResourceData logicResourceData_3;

		// Token: 0x0400077E RID: 1918
		private LogicResourceData logicResourceData_4;

		// Token: 0x0400077F RID: 1919
		private LogicHeroData logicHeroData_0;

		// Token: 0x04000780 RID: 1920
		private LogicArrayList<int>[] logicArrayList_0;

		// Token: 0x04000781 RID: 1921
		private LogicArrayList<int>[] logicArrayList_1;

		// Token: 0x04000782 RID: 1922
		private LogicArrayList<LogicAttackerItemData> logicArrayList_2;

		// Token: 0x04000783 RID: 1923
		private LogicSpellData logicSpellData_0;

		// Token: 0x04000784 RID: 1924
		private LogicSpellData logicSpellData_1;

		// Token: 0x04000785 RID: 1925
		private LogicEffectData logicEffectData_0;

		// Token: 0x04000786 RID: 1926
		private LogicEffectData logicEffectData_1;

		// Token: 0x04000787 RID: 1927
		private LogicEffectData logicEffectData_2;

		// Token: 0x04000788 RID: 1928
		private LogicEffectData logicEffectData_3;

		// Token: 0x04000789 RID: 1929
		private LogicEffectData logicEffectData_4;

		// Token: 0x0400078A RID: 1930
		private LogicEffectData logicEffectData_5;

		// Token: 0x0400078B RID: 1931
		private LogicEffectData logicEffectData_6;

		// Token: 0x0400078C RID: 1932
		private LogicCharacterData[] logicCharacterData_0;

		// Token: 0x0400078D RID: 1933
		private LogicCharacterData[] logicCharacterData_1;

		// Token: 0x0400078E RID: 1934
		private int[] int_0;

		// Token: 0x0400078F RID: 1935
		private int[] int_1;

		// Token: 0x04000790 RID: 1936
		private int[] int_2;

		// Token: 0x04000791 RID: 1937
		private int[] int_3;

		// Token: 0x04000792 RID: 1938
		private int[] int_4;

		// Token: 0x04000793 RID: 1939
		private int[] int_5;

		// Token: 0x04000794 RID: 1940
		private int[] int_6;

		// Token: 0x04000795 RID: 1941
		private int[] int_7;

		// Token: 0x04000796 RID: 1942
		private int[] int_8;

		// Token: 0x04000797 RID: 1943
		private int[] int_9;

		// Token: 0x04000798 RID: 1944
		private int[] int_10;

		// Token: 0x04000799 RID: 1945
		private int[] int_11;

		// Token: 0x0400079A RID: 1946
		private int[] int_12;

		// Token: 0x0400079B RID: 1947
		private int[] int_13;

		// Token: 0x0400079C RID: 1948
		private int[] int_14;

		// Token: 0x0400079D RID: 1949
		private int[] int_15;

		// Token: 0x0400079E RID: 1950
		private int[] int_16;

		// Token: 0x0400079F RID: 1951
		private int[] int_17;

		// Token: 0x040007A0 RID: 1952
		private int[] int_18;

		// Token: 0x040007A1 RID: 1953
		private int[] int_19;

		// Token: 0x040007A2 RID: 1954
		private int[] int_20;

		// Token: 0x040007A3 RID: 1955
		private int[] int_21;

		// Token: 0x040007A4 RID: 1956
		private int[] int_22;

		// Token: 0x040007A5 RID: 1957
		private int[] int_23;

		// Token: 0x040007A6 RID: 1958
		private int int_24;

		// Token: 0x040007A7 RID: 1959
		private int int_25;

		// Token: 0x040007A8 RID: 1960
		private int int_26;

		// Token: 0x040007A9 RID: 1961
		private int int_27;

		// Token: 0x040007AA RID: 1962
		private int int_28;

		// Token: 0x040007AB RID: 1963
		private int int_29;

		// Token: 0x040007AC RID: 1964
		private int int_30;

		// Token: 0x040007AD RID: 1965
		private int int_31;

		// Token: 0x040007AE RID: 1966
		private int int_32;

		// Token: 0x040007AF RID: 1967
		private int int_33;

		// Token: 0x040007B0 RID: 1968
		private int int_34;

		// Token: 0x040007B1 RID: 1969
		private int int_35;

		// Token: 0x040007B2 RID: 1970
		private int int_36;

		// Token: 0x040007B3 RID: 1971
		private int int_37;

		// Token: 0x040007B4 RID: 1972
		private int int_38;

		// Token: 0x040007B5 RID: 1973
		private int int_39;

		// Token: 0x040007B6 RID: 1974
		private int int_40;

		// Token: 0x040007B7 RID: 1975
		private int int_41;

		// Token: 0x040007B8 RID: 1976
		private int int_42;

		// Token: 0x040007B9 RID: 1977
		private int int_43;

		// Token: 0x040007BA RID: 1978
		private int int_44;

		// Token: 0x040007BB RID: 1979
		private int int_45;

		// Token: 0x040007BC RID: 1980
		private int int_46;

		// Token: 0x040007BD RID: 1981
		private int int_47;

		// Token: 0x040007BE RID: 1982
		private bool bool_0;

		// Token: 0x040007BF RID: 1983
		private bool bool_1;

		// Token: 0x040007C0 RID: 1984
		private bool bool_2;

		// Token: 0x040007C1 RID: 1985
		private bool bool_3;

		// Token: 0x040007C2 RID: 1986
		private bool bool_4;

		// Token: 0x040007C3 RID: 1987
		private bool bool_5;

		// Token: 0x040007C4 RID: 1988
		private bool bool_6;

		// Token: 0x040007C5 RID: 1989
		private bool bool_7;

		// Token: 0x040007C6 RID: 1990
		private bool bool_8;

		// Token: 0x040007C7 RID: 1991
		private bool bool_9;

		// Token: 0x040007C8 RID: 1992
		private bool bool_10;

		// Token: 0x040007C9 RID: 1993
		private bool bool_11;

		// Token: 0x040007CA RID: 1994
		private bool bool_12;

		// Token: 0x040007CB RID: 1995
		private bool bool_13;

		// Token: 0x040007CC RID: 1996
		private bool bool_14;

		// Token: 0x040007CD RID: 1997
		private bool bool_15;

		// Token: 0x040007CE RID: 1998
		private bool bool_16;

		// Token: 0x040007CF RID: 1999
		private bool bool_17;

		// Token: 0x040007D0 RID: 2000
		private string string_0;

		// Token: 0x040007D1 RID: 2001
		private string string_1;

		// Token: 0x040007D2 RID: 2002
		private string string_2;

		// Token: 0x040007D3 RID: 2003
		private string string_3;

		// Token: 0x040007D4 RID: 2004
		private string string_4;
	}
}
