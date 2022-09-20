using System;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.CSV;
using Atrasis.Magic.Titan.Debug;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Data
{
	// Token: 0x02000143 RID: 323
	public abstract class LogicCombatItemData : LogicGameObjectData
	{
		// Token: 0x06001202 RID: 4610 RVA: 0x0000B477 File Offset: 0x00009677
		protected LogicCombatItemData(CSVRow row, LogicDataTable table) : base(row, table)
		{
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0004D41C File Offset: 0x0004B61C
		public override void CreateReferences()
		{
			base.CreateReferences();
			int num = this.m_upgradeLevelCount = this.m_row.GetBiggestArraySize();
			this.int_5 = new int[num];
			this.int_0 = new int[num];
			this.int_1 = new int[num];
			this.int_2 = new int[num];
			this.int_3 = new int[num];
			this.int_4 = new int[num];
			this.logicResourceData_0 = new LogicResourceData[num];
			for (int i = 0; i < num; i++)
			{
				this.int_5[i] = base.GetClampedIntegerValue("UpgradeLevelByTH", i);
				this.int_0[i] = 3600 * base.GetClampedIntegerValue("UpgradeTimeH", i) + 60 * base.GetClampedIntegerValue("UpgradeTimeM", i);
				this.int_1[i] = base.GetClampedIntegerValue("UpgradeCost", i);
				this.int_2[i] = base.GetClampedIntegerValue("TrainingTime", i);
				this.int_3[i] = base.GetClampedIntegerValue("TrainingCost", i);
				this.int_4[i] = base.GetClampedIntegerValue("LaboratoryLevel", i) - 1;
				this.logicResourceData_0[i] = LogicDataTables.GetResourceByName(base.GetClampedValue("UpgradeResource", i), this);
				if (this.logicResourceData_0[i] == null && this.GetCombatItemType() != LogicCombatItemType.HERO)
				{
					Debugger.Error("UpgradeResource is not defined for " + base.GetName());
				}
			}
			if (base.GetName().Equals("Barbarian2") && this.int_0[0] == 0)
			{
				this.int_0[0] = 30;
			}
			this.logicResourceData_1 = LogicDataTables.GetResourceByName(base.GetValue("TrainingResource", 0), this);
			this.int_6 = base.GetIntegerValue("HousingSpace", 0);
			this.bool_0 = !base.GetBooleanValue("DisableProduction", 0);
			this.bool_1 = base.GetBooleanValue("EnabledByCalendar", 0);
			this.int_7 = base.GetIntegerValue("UnitOfType", 0);
			this.int_8 = base.GetIntegerValue("DonateCost", 0);
			if (this.logicResourceData_1 == null && this.GetCombatItemType() != LogicCombatItemType.HERO)
			{
				Debugger.Error("TrainingResource is not defined for " + base.GetName());
			}
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsDonationDisabled()
		{
			return false;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x0000C0CD File Offset: 0x0000A2CD
		public int GetDonateCost()
		{
			return this.int_8;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x0000C0D5 File Offset: 0x0000A2D5
		public int GetUpgradeLevelCount()
		{
			return this.m_upgradeLevelCount;
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x0000C0DD File Offset: 0x0000A2DD
		public int GetUpgradeTime(int idx)
		{
			return this.int_0[idx];
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x0000C0E7 File Offset: 0x0000A2E7
		public LogicResourceData GetUpgradeResource(int idx)
		{
			return this.logicResourceData_0[idx];
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x0000C0F1 File Offset: 0x0000A2F1
		public int GetUpgradeCost(int idx)
		{
			return this.int_1[idx];
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x0000C0FB File Offset: 0x0000A2FB
		public LogicResourceData GetTrainingResource()
		{
			return this.logicResourceData_1;
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x0000C103 File Offset: 0x0000A303
		public int GetTrainingCost(int idx)
		{
			return this.int_3[idx];
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x0000C10D File Offset: 0x0000A30D
		public int GetUnitOfType()
		{
			return this.int_7;
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x0000C115 File Offset: 0x0000A315
		public int GetRequiredLaboratoryLevel(int idx)
		{
			return this.int_4[idx];
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x00002467 File Offset: 0x00000667
		public virtual int GetRequiredProductionHouseLevel()
		{
			return 0;
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsUnlockedForProductionHouseLevel(int level)
		{
			return false;
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x00002B35 File Offset: 0x00000D35
		public virtual LogicBuildingData GetProductionHouseData()
		{
			return null;
		}

		// Token: 0x06001211 RID: 4625 RVA: 0x00002467 File Offset: 0x00000667
		public virtual bool IsUnderground()
		{
			return false;
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x0000C11F File Offset: 0x0000A31F
		public int GetHousingSpace()
		{
			return this.int_6;
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x0004D640 File Offset: 0x0004B840
		public int GetUpgradeLevelByTownHall(int townHallLevel)
		{
			int num = this.m_upgradeLevelCount;
			if (num >= 2)
			{
				int num2 = 1;
				while (townHallLevel + 1 >= this.int_5[num2])
				{
					if (++num2 >= num)
					{
						return num - 1;
					}
				}
				num = num2;
			}
			return num - 1;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x0000C127 File Offset: 0x0000A327
		public bool UseUpgradeLevelByTownHall()
		{
			return this.int_5[0] > 0;
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x0004D67C File Offset: 0x0004B87C
		public int GetTrainingTime(int index, LogicLevel level, int additionalBarrackCount)
		{
			int num = this.int_2[index];
			if (LogicDataTables.GetGlobals().UseNewTraining() && base.GetVillageType() != 1 && this.GetCombatItemType() == LogicCombatItemType.CHARACTER)
			{
				if (level != null)
				{
					LogicGameObjectManager gameObjectManagerAt = level.GetGameObjectManagerAt(0);
					int num2 = this.int_7;
					if (num2 != 1)
					{
						if (num2 != 2)
						{
							Debugger.Error("invalid type for unit");
						}
						else
						{
							int num3 = gameObjectManagerAt.GetDarkBarrackCount();
							int requiredProductionHouseLevel = this.GetRequiredProductionHouseLevel();
							int num4 = 0;
							for (int i = 0; i < num3; i++)
							{
								LogicBuilding logicBuilding = (LogicBuilding)gameObjectManagerAt.GetDarkBarrack(i);
								if (logicBuilding != null && logicBuilding.GetBuildingData().GetProducesUnitsOfType() == this.GetUnitOfType() && logicBuilding.GetUpgradeLevel() >= requiredProductionHouseLevel && !logicBuilding.IsConstructing())
								{
									num4++;
								}
							}
							if (num4 + additionalBarrackCount <= 0)
							{
								return num;
							}
							int[] darkBarrackReduceTrainingDevisor = LogicDataTables.GetGlobals().GetDarkBarrackReduceTrainingDevisor();
							int num5 = darkBarrackReduceTrainingDevisor[LogicMath.Min(darkBarrackReduceTrainingDevisor.Length - 1, num4 + additionalBarrackCount - 1)];
							if (num5 > 0)
							{
								return num / num5;
							}
							return num;
						}
					}
					else
					{
						int num3 = gameObjectManagerAt.GetBarrackCount();
						int requiredProductionHouseLevel = this.GetRequiredProductionHouseLevel();
						int num4 = 0;
						for (int j = 0; j < num3; j++)
						{
							LogicBuilding logicBuilding2 = (LogicBuilding)gameObjectManagerAt.GetBarrack(j);
							if (logicBuilding2 != null && logicBuilding2.GetBuildingData().GetProducesUnitsOfType() == this.GetUnitOfType() && logicBuilding2.GetUpgradeLevel() >= requiredProductionHouseLevel && !logicBuilding2.IsConstructing())
							{
								num4++;
							}
						}
						if (num4 + additionalBarrackCount <= 0)
						{
							return num;
						}
						int[] barrackReduceTrainingDevisor = LogicDataTables.GetGlobals().GetBarrackReduceTrainingDevisor();
						int num5 = barrackReduceTrainingDevisor[LogicMath.Min(barrackReduceTrainingDevisor.Length - 1, num4 + additionalBarrackCount - 1)];
						if (num5 > 0)
						{
							return num / num5;
						}
						return num;
					}
				}
				else
				{
					Debugger.Error("level was null in getTrainingTime()");
				}
			}
			return num;
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x0000C134 File Offset: 0x0000A334
		public bool IsProductionEnabled()
		{
			return this.bool_0;
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x0000C13C File Offset: 0x0000A33C
		public override bool IsEnableByCalendar()
		{
			return this.bool_1;
		}

		// Token: 0x06001218 RID: 4632
		public abstract LogicCombatItemType GetCombatItemType();

		// Token: 0x0400085C RID: 2140
		private LogicResourceData[] logicResourceData_0;

		// Token: 0x0400085D RID: 2141
		private LogicResourceData logicResourceData_1;

		// Token: 0x0400085E RID: 2142
		protected int m_upgradeLevelCount;

		// Token: 0x0400085F RID: 2143
		private int[] int_0;

		// Token: 0x04000860 RID: 2144
		private int[] int_1;

		// Token: 0x04000861 RID: 2145
		private int[] int_2;

		// Token: 0x04000862 RID: 2146
		private int[] int_3;

		// Token: 0x04000863 RID: 2147
		private int[] int_4;

		// Token: 0x04000864 RID: 2148
		private int[] int_5;

		// Token: 0x04000865 RID: 2149
		private int int_6;

		// Token: 0x04000866 RID: 2150
		private int int_7;

		// Token: 0x04000867 RID: 2151
		private int int_8;

		// Token: 0x04000868 RID: 2152
		private bool bool_0;

		// Token: 0x04000869 RID: 2153
		private bool bool_1;
	}
}
