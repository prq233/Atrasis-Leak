using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Logic.Unit;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001B2 RID: 434
	public sealed class LogicPauseTrainingCommand : LogicCommand
	{
		// Token: 0x0600178C RID: 6028 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicPauseTrainingCommand()
		{
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x0000F7B2 File Offset: 0x0000D9B2
		public LogicPauseTrainingCommand(bool disabled, int index)
		{
			this.bool_0 = disabled;
			this.int_1 = index;
		}

		// Token: 0x0600178E RID: 6030 RVA: 0x0000F7C8 File Offset: 0x0000D9C8
		public override void Decode(ByteStream stream)
		{
			this.bool_0 = stream.ReadBoolean();
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x0000F7E9 File Offset: 0x0000D9E9
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteBoolean(this.bool_0);
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001790 RID: 6032 RVA: 0x0000F80A File Offset: 0x0000DA0A
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.PAUSE_TRAINING;
		}

		// Token: 0x06001791 RID: 6033 RVA: 0x00059CFC File Offset: 0x00057EFC
		public override int Execute(LogicLevel level)
		{
			if (level.GetVillageType() != 0)
			{
				return -32;
			}
			LogicUnitProduction logicUnitProduction = null;
			int num = this.int_1;
			if (num != 1)
			{
				if (num == 2)
				{
					logicUnitProduction = level.GetGameObjectManagerAt(0).GetSpellProduction();
				}
			}
			else
			{
				logicUnitProduction = level.GetGameObjectManagerAt(0).GetUnitProduction();
			}
			if (logicUnitProduction == null)
			{
				return -1;
			}
			logicUnitProduction.SetLocked(this.bool_0);
			return 0;
		}

		// Token: 0x04000CE4 RID: 3300
		private bool bool_0;

		// Token: 0x04000CE5 RID: 3301
		private int int_1;
	}
}
