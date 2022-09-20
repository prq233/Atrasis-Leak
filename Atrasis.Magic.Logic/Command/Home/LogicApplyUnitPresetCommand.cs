using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Calendar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.GameObject;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x0200018B RID: 395
	public sealed class LogicApplyUnitPresetCommand : LogicCommand
	{
		// Token: 0x06001689 RID: 5769 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicApplyUnitPresetCommand()
		{
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0000EB33 File Offset: 0x0000CD33
		public LogicApplyUnitPresetCommand(int id)
		{
			this.int_1 = id;
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0000EB42 File Offset: 0x0000CD42
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x0000EB57 File Offset: 0x0000CD57
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x0000EB6C File Offset: 0x0000CD6C
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.APPLY_UNIT_PRESET;
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x0000EB73 File Offset: 0x0000CD73
		public override void Destruct()
		{
			base.Destruct();
			this.logicLevel_0 = null;
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x000562C4 File Offset: 0x000544C4
		public override int Execute(LogicLevel level)
		{
			this.logicLevel_0 = level;
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			if (!LogicDataTables.GetGlobals().EnablePresets() || level.GetHomeOwnerAvatar().GetTownHallLevel() < LogicDataTables.GetGlobals().GetEnablePresetsTownHallLevel())
			{
				return -3;
			}
			if (this.int_1 <= 3)
			{
				if (this.HasEnoughFreeHousingSpace())
				{
					int resourceCost = this.GetResourceCost(LogicDataTables.GetElixirData());
					int resourceCost2 = this.GetResourceCost(LogicDataTables.GetDarkElixirData());
					if (level.GetPlayerAvatar().HasEnoughResources(LogicDataTables.GetElixirData(), resourceCost, LogicDataTables.GetDarkElixirData(), resourceCost2, true, this, false))
					{
						this.TrainUnits();
						return 0;
					}
				}
				return -1;
			}
			return -2;
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x0005635C File Offset: 0x0005455C
		public int GetResourceCost(LogicResourceData resourceData)
		{
			int num = 0;
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			LogicCalendar calendar = this.logicLevel_0.GetCalendar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(i);
				if (calendar.IsProductionEnabled(logicCharacterData) && !logicCharacterData.IsSecondaryTroop())
				{
					int unitPresetCount = homeOwnerAvatar.GetUnitPresetCount(logicCharacterData, this.int_1);
					if (unitPresetCount > 0 && logicCharacterData.GetTrainingResource() == resourceData)
					{
						num += unitPresetCount * calendar.GetTrainingCost(logicCharacterData, homeOwnerAvatar.GetUnitUpgradeLevel(logicCharacterData));
					}
				}
			}
			table = LogicDataTables.GetTable(LogicDataType.SPELL);
			for (int j = 0; j < table.GetItemCount(); j++)
			{
				LogicSpellData logicSpellData = (LogicSpellData)table.GetItemAt(j);
				if (calendar.IsProductionEnabled(logicSpellData))
				{
					int unitPresetCount2 = homeOwnerAvatar.GetUnitPresetCount(logicSpellData, this.int_1);
					if (unitPresetCount2 > 0 && logicSpellData.GetTrainingResource() == resourceData)
					{
						num += unitPresetCount2 * calendar.GetTrainingCost(logicSpellData, homeOwnerAvatar.GetUnitUpgradeLevel(logicSpellData));
					}
				}
			}
			return num;
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x00056464 File Offset: 0x00054664
		public void TrainUnits()
		{
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.SPELL);
			LogicArrayList<LogicCombatItemData> logicArrayList = new LogicArrayList<LogicCombatItemData>(table.GetItemCount());
			LogicArrayList<LogicCombatItemData> logicArrayList2 = new LogicArrayList<LogicCombatItemData>(table2.GetItemCount());
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(i);
				if (this.logicLevel_0.GetCalendar().IsProductionEnabled(logicCharacterData) && !logicCharacterData.IsSecondaryTroop())
				{
					logicArrayList.Add(logicCharacterData);
				}
			}
			this.method_0(logicArrayList);
			for (int j = 0; j < logicArrayList.Size(); j++)
			{
				int unitPresetCount = homeOwnerAvatar.GetUnitPresetCount(logicArrayList[j], this.int_1);
				if (unitPresetCount > 0)
				{
					this.AddUnitsToQueue(logicArrayList[j], unitPresetCount);
				}
			}
			for (int k = 0; k < table2.GetItemCount(); k++)
			{
				LogicSpellData logicSpellData = (LogicSpellData)table2.GetItemAt(k);
				if (this.logicLevel_0.GetCalendar().IsProductionEnabled(logicSpellData))
				{
					logicArrayList2.Add(logicSpellData);
				}
			}
			this.method_0(logicArrayList2);
			for (int l = 0; l < logicArrayList2.Size(); l++)
			{
				int unitPresetCount2 = homeOwnerAvatar.GetUnitPresetCount(logicArrayList2[l], this.int_1);
				if (unitPresetCount2 > 0)
				{
					this.AddUnitsToQueue(logicArrayList2[l], unitPresetCount2);
				}
			}
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x000565C4 File Offset: 0x000547C4
		public void AddUnitsToQueue(LogicCombatItemData data, int count)
		{
			LogicCalendar calendar = this.logicLevel_0.GetCalendar();
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			LogicClientAvatar playerAvatar = this.logicLevel_0.GetPlayerAvatar();
			LogicGameObjectManager gameObjectManagerAt = this.logicLevel_0.GetGameObjectManagerAt(0);
			LogicUnitProduction logicUnitProduction = gameObjectManagerAt.GetUnitProduction();
			if (data.GetCombatItemType() != LogicCombatItemType.CHARACTER)
			{
				if (data.GetCombatItemType() != LogicCombatItemType.SPELL)
				{
					return;
				}
				logicUnitProduction = gameObjectManagerAt.GetSpellProduction();
			}
			if (logicUnitProduction != null)
			{
				int trainingCost = calendar.GetTrainingCost(data, homeOwnerAvatar.GetUnitUpgradeLevel(data));
				for (int i = 0; i < count; i++)
				{
					if (logicUnitProduction.CanAddUnitToQueue(data, true) && playerAvatar.HasEnoughResources(data.GetTrainingResource(), trainingCost, false, null, false))
					{
						playerAvatar.CommodityCountChangeHelper(0, data.GetTrainingResource(), -trainingCost);
						logicUnitProduction.AddUnitToQueue(data, logicUnitProduction.GetSlotCount(), true);
					}
				}
			}
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x00056688 File Offset: 0x00054888
		public bool HasEnoughFreeHousingSpace()
		{
			LogicCalendar calendar = this.logicLevel_0.GetCalendar();
			LogicAvatar homeOwnerAvatar = this.logicLevel_0.GetHomeOwnerAvatar();
			LogicUnitProduction unitProduction = this.logicLevel_0.GetGameObjectManagerAt(0).GetUnitProduction();
			LogicDataTable table = LogicDataTables.GetTable(LogicDataType.CHARACTER);
			int num = unitProduction.GetMaxTrainCount() - (homeOwnerAvatar.GetUnitsTotalCapacity() - unitProduction.GetTotalCount());
			int num2 = 0;
			for (int i = 0; i < table.GetItemCount(); i++)
			{
				LogicCharacterData logicCharacterData = (LogicCharacterData)table.GetItemAt(i);
				if (calendar.IsProductionEnabled(logicCharacterData) && !logicCharacterData.IsSecondaryTroop())
				{
					int unitPresetCount = homeOwnerAvatar.GetUnitPresetCount(logicCharacterData, this.int_1);
					if (unitPresetCount > 0)
					{
						num2 += logicCharacterData.GetHousingSpace() * unitPresetCount;
					}
				}
			}
			if (num2 <= num)
			{
				LogicUnitProduction spellProduction = this.logicLevel_0.GetGameObjectManagerAt(0).GetSpellProduction();
				LogicDataTable table2 = LogicDataTables.GetTable(LogicDataType.SPELL);
				int num3 = spellProduction.GetMaxTrainCount() - (homeOwnerAvatar.GetSpellsTotalCapacity() - spellProduction.GetTotalCount());
				int num4 = 0;
				for (int j = 0; j < table2.GetItemCount(); j++)
				{
					LogicSpellData logicSpellData = (LogicSpellData)table2.GetItemAt(j);
					if (calendar.IsProductionEnabled(logicSpellData))
					{
						int unitPresetCount2 = homeOwnerAvatar.GetUnitPresetCount(logicSpellData, this.int_1);
						if (unitPresetCount2 > 0)
						{
							num4 += logicSpellData.GetHousingSpace() * unitPresetCount2;
						}
					}
				}
				return num4 <= num3;
			}
			return false;
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x000567DC File Offset: 0x000549DC
		private void method_0(LogicArrayList<LogicCombatItemData> logicArrayList_0)
		{
			for (int i = 0; i < logicArrayList_0.Size(); i++)
			{
				bool flag = false;
				for (int j = 0; j < logicArrayList_0.Size() - 1; j++)
				{
					LogicCombatItemData logicCombatItemData = logicArrayList_0[j];
					LogicCombatItemData logicCombatItemData2 = logicArrayList_0[j + 1];
					int num = (int)(logicCombatItemData.GetRequiredProductionHouseLevel() + 100 * logicCombatItemData.GetUnitOfType() + (LogicCombatItemType)500 * logicCombatItemData.GetCombatItemType());
					int num2 = (int)(logicCombatItemData2.GetRequiredProductionHouseLevel() + 100 * logicCombatItemData2.GetUnitOfType() + (LogicCombatItemType)500 * logicCombatItemData2.GetCombatItemType());
					if (num > num2)
					{
						logicArrayList_0[j] = logicCombatItemData2;
						logicArrayList_0[j + 1] = logicCombatItemData;
						flag = true;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}

		// Token: 0x04000C9B RID: 3227
		private int int_1;

		// Token: 0x04000C9C RID: 3228
		private LogicLevel logicLevel_0;
	}
}
