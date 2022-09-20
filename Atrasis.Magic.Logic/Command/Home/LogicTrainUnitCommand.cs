using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Debug;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001D9 RID: 473
	public sealed class LogicTrainUnitCommand : LogicCommand
	{
		// Token: 0x0600188F RID: 6287 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicTrainUnitCommand()
		{
		}

		// Token: 0x06001890 RID: 6288 RVA: 0x00010474 File Offset: 0x0000E674
		public LogicTrainUnitCommand(int count, LogicCombatItemData combatItemData, int gameObjectId, int slotId)
		{
			this.int_2 = count;
			this.logicCombatItemData_0 = combatItemData;
			this.int_3 = gameObjectId;
			this.int_4 = slotId;
			this.int_1 = ((this.logicCombatItemData_0.GetDataType() == LogicDataType.SPELL) ? 1 : 0);
		}

		// Token: 0x06001891 RID: 6289 RVA: 0x0005C344 File Offset: 0x0005A544
		public override void Decode(ByteStream stream)
		{
			this.int_3 = stream.ReadInt();
			this.int_1 = stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.int_1 != 0) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_2 = stream.ReadInt();
			this.int_4 = stream.ReadInt();
			LogicGlobals globals = LogicDataTables.GetGlobals();
			if (!globals.UseDragInTraining() && !globals.UseDragInTrainingFix() && !globals.UseDragInTrainingFix2())
			{
				this.int_4 = -1;
			}
			base.Decode(stream);
		}

		// Token: 0x06001892 RID: 6290 RVA: 0x0005C3CC File Offset: 0x0005A5CC
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_3);
			encoder.WriteInt(this.int_1);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_2);
			encoder.WriteInt(this.int_4);
			base.Encode(encoder);
		}

		// Token: 0x06001893 RID: 6291 RVA: 0x000104B2 File Offset: 0x0000E6B2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.TRAIN_UNIT;
		}

		// Token: 0x06001894 RID: 6292 RVA: 0x000104B9 File Offset: 0x0000E6B9
		public override void Destruct()
		{
			base.Destruct();
			this.int_3 = 0;
			this.int_1 = 0;
			this.int_4 = 0;
			this.int_2 = 0;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x06001895 RID: 6293 RVA: 0x000104E4 File Offset: 0x0000E6E4
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() == 0)
			{
				if (LogicDataTables.GetGlobals().UseNewTraining())
				{
					return this.NewTrainingUnit(level);
				}
				if (this.int_3 == 0)
				{
					return -1;
				}
			}
			return -32;
		}

		// Token: 0x06001896 RID: 6294 RVA: 0x0005C41C File Offset: 0x0005A61C
		public int NewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (this.int_2 > 100)
			{
				Debugger.Error("LogicTraingUnitCommand - Count is too high");
				return -20;
			}
			LogicUnitProduction logicUnitProduction = (this.int_1 == 1) ? level.GetGameObjectManagerAt(0).GetSpellProduction() : level.GetGameObjectManagerAt(0).GetUnitProduction();
			if (this.int_2 > 0 && this.logicCombatItemData_0 != null)
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				bool flag = false;
				int trainingCost = level.GetGameMode().GetCalendar().GetTrainingCost(this.logicCombatItemData_0, playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0));
				int i = 0;
				while (i < this.int_2)
				{
					if (logicUnitProduction.CanAddUnitToQueue(this.logicCombatItemData_0, false))
					{
						if (playerAvatar.HasEnoughResources(this.logicCombatItemData_0.GetTrainingResource(), trainingCost, true, this, false))
						{
							playerAvatar.CommodityCountChangeHelper(0, this.logicCombatItemData_0.GetTrainingResource(), -trainingCost);
							if (this.int_4 == -1)
							{
								this.int_4 = logicUnitProduction.GetSlotCount();
							}
							logicUnitProduction.AddUnitToQueue(this.logicCombatItemData_0, this.int_4, false);
							flag = true;
							i++;
							continue;
						}
						if (!flag)
						{
							return -30;
						}
					}
					else if (!flag)
					{
						return -40;
					}
					return 0;
				}
				return 0;
			}
			return -50;
		}

		// Token: 0x04000D2D RID: 3373
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000D2E RID: 3374
		private int int_1;

		// Token: 0x04000D2F RID: 3375
		private int int_2;

		// Token: 0x04000D30 RID: 3376
		private int int_3;

		// Token: 0x04000D31 RID: 3377
		private int int_4;
	}
}
