using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000199 RID: 409
	public sealed class LogicCancelUnitProductionCommand : LogicCommand
	{
		// Token: 0x060016EB RID: 5867 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicCancelUnitProductionCommand()
		{
		}

		// Token: 0x060016EC RID: 5868 RVA: 0x0000EF7B File Offset: 0x0000D17B
		public LogicCancelUnitProductionCommand(int count, LogicCombatItemData combatItemData, int gameObjectId, int slotId)
		{
			this.int_1 = count;
			this.logicCombatItemData_0 = combatItemData;
			this.int_2 = gameObjectId;
			this.int_3 = slotId;
			this.logicCombatItemType_0 = this.logicCombatItemData_0.GetCombatItemType();
		}

		// Token: 0x060016ED RID: 5869 RVA: 0x00057B5C File Offset: 0x00055D5C
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			this.logicCombatItemType_0 = (LogicCombatItemType)stream.ReadInt();
			this.logicCombatItemData_0 = (LogicCombatItemData)ByteStreamHelper.ReadDataReference(stream, (this.logicCombatItemType_0 != LogicCombatItemType.CHARACTER) ? LogicDataType.SPELL : LogicDataType.CHARACTER);
			this.int_1 = stream.ReadInt();
			this.int_3 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x00057BC0 File Offset: 0x00055DC0
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			encoder.WriteInt((int)this.logicCombatItemType_0);
			ByteStreamHelper.WriteDataReference(encoder, this.logicCombatItemData_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_3);
			base.Encode(encoder);
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x0000EFB1 File Offset: 0x0000D1B1
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CANCEL_UNIT_PRODUCTION;
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x0000EFB8 File Offset: 0x0000D1B8
		public override void Destruct()
		{
			base.Destruct();
			this.int_2 = 0;
			this.logicCombatItemType_0 = LogicCombatItemType.CHARACTER;
			this.int_3 = 0;
			this.int_1 = 0;
			this.logicCombatItemData_0 = null;
		}

		// Token: 0x060016F1 RID: 5873 RVA: 0x0000EFE3 File Offset: 0x0000D1E3
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				throw new NotImplementedException();
			}
			return this.NewTrainingUnit(level);
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x00057C10 File Offset: 0x00055E10
		public int NewTrainingUnit(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -99;
			}
			if (this.logicCombatItemData_0 == null)
			{
				return -1;
			}
			LogicUnitProduction logicUnitProduction = (this.logicCombatItemData_0.GetCombatItemType() == LogicCombatItemType.SPELL) ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			if (logicUnitProduction.IsLocked())
			{
				return -23;
			}
			if (this.int_1 > 0 && this.logicCombatItemData_0.GetDataType() == logicUnitProduction.GetUnitProductionType())
			{
				LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
				LogicResourceData trainingResource = this.logicCombatItemData_0.GetTrainingResource();
				int count = LogicMath.Max(level.GetGameMode().GetCalendar().GetTrainingCost(this.logicCombatItemData_0, playerAvatar.GetUnitUpgradeLevel(this.logicCombatItemData_0)) * ((this.logicCombatItemData_0.GetDataType() != LogicDataType.CHARACTER) ? LogicDataTables.GetGlobals().GetSpellCancelMultiplier() : LogicDataTables.GetGlobals().GetTrainCancelMultiplier()) / 100, 0);
				while (logicUnitProduction.RemoveUnit(this.logicCombatItemData_0, this.int_3))
				{
					playerAvatar.CommodityCountChangeHelper(0, trainingResource, count);
					int num = this.int_1 - 1;
					this.int_1 = num;
					if (num <= 0)
					{
						break;
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CB2 RID: 3250
		private LogicCombatItemData logicCombatItemData_0;

		// Token: 0x04000CB3 RID: 3251
		private LogicCombatItemType logicCombatItemType_0;

		// Token: 0x04000CB4 RID: 3252
		private int int_1;

		// Token: 0x04000CB5 RID: 3253
		private int int_2;

		// Token: 0x04000CB6 RID: 3254
		private int int_3;
	}
}
