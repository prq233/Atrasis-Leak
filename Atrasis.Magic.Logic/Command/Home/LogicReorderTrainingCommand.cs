using System;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B6 RID: 438
	public sealed class LogicReorderTrainingCommand : LogicCommand
	{
		// Token: 0x060017A5 RID: 6053 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicReorderTrainingCommand()
		{
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x0000F94D File Offset: 0x0000DB4D
		public LogicReorderTrainingCommand(bool spellProduction, int slotIdx, int dragIdx)
		{
			this.bool_0 = spellProduction;
			this.int_1 = slotIdx;
			this.int_2 = dragIdx;
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x0000F96A File Offset: 0x0000DB6A
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x0000F997 File Offset: 0x0000DB97
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060017A9 RID: 6057 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.REORDER_TRAINING;
		}

		// Token: 0x060017AA RID: 6058 RVA: 0x0005A3E4 File Offset: 0x000585E4
		public override int Execute(LogicLevel level)
		{
			if (!LogicDataTables.GetGlobals().UseNewTraining())
			{
				return -50;
			}
			if (!LogicDataTables.GetGlobals().UseDragInTraining() && !LogicDataTables.GetGlobals().UseDragInTrainingFix() && !LogicDataTables.GetGlobals().UseDragInTrainingFix2())
			{
				return -51;
			}
			LogicUnitProduction logicUnitProduction = this.bool_0 ? level.GetGameObjectManager().GetSpellProduction() : level.GetGameObjectManager().GetUnitProduction();
			if (logicUnitProduction.GetSlotCount() <= this.int_1)
			{
				return -1;
			}
			if (logicUnitProduction.GetSlotCount() < this.int_2)
			{
				return -2;
			}
			if (this.int_1 < 0)
			{
				return -3;
			}
			if (this.int_2 < 0)
			{
				return -4;
			}
			if (!logicUnitProduction.DragSlot(this.int_1, this.int_2))
			{
				return -5;
			}
			return 0;
		}

		// Token: 0x04000CEF RID: 3311
		private bool bool_0;

		// Token: 0x04000CF0 RID: 3312
		private int int_1;

		// Token: 0x04000CF1 RID: 3313
		private int int_2;
	}
}
