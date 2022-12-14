using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A3 RID: 419
	public sealed class LogicFreeWorkerCommand : LogicCommand
	{
		// Token: 0x0600172D RID: 5933 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicFreeWorkerCommand()
		{
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x0000F237 File Offset: 0x0000D437
		public LogicFreeWorkerCommand(LogicCommand resourceCommand, int villageType)
		{
			this.logicCommand_0 = resourceCommand;
			this.int_1 = villageType;
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x0000F24D File Offset: 0x0000D44D
		public override void Decode(ByteStream stream)
		{
			base.Decode(stream);
			this.int_1 = stream.ReadInt();
			if (stream.ReadBoolean())
			{
				this.logicCommand_0 = LogicCommandManager.DecodeCommand(stream);
			}
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x0000F276 File Offset: 0x0000D476
		public override void Encode(ChecksumEncoder encoder)
		{
			base.Encode(encoder);
			encoder.WriteInt(this.int_1);
			if (this.logicCommand_0 != null)
			{
				encoder.WriteBoolean(true);
				LogicCommandManager.EncodeCommand(encoder, this.logicCommand_0);
				return;
			}
			encoder.WriteBoolean(false);
		}

		// Token: 0x06001731 RID: 5937 RVA: 0x0000F2AE File Offset: 0x0000D4AE
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.FREE_WORKER;
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x0000F2B5 File Offset: 0x0000D4B5
		public override void Destruct()
		{
			base.Destruct();
			if (this.logicCommand_0 != null)
			{
				this.logicCommand_0.Destruct();
				this.logicCommand_0 = null;
			}
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x00058858 File Offset: 0x00056A58
		public override int Execute(LogicLevel level)
		{
			int index = (this.int_1 != -1) ? this.int_1 : level.GetVillageType();
			if (level.GetWorkerManagerAt(index).GetFreeWorkers() == 0 && level.GetWorkerManagerAt(index).FinishTaskOfOneWorker())
			{
				if (this.logicCommand_0 != null)
				{
					int commandType = (int)this.logicCommand_0.GetCommandType();
					if (commandType < 1000 && commandType >= 500 && commandType < 700)
					{
						this.logicCommand_0.Execute(level);
					}
				}
				return 0;
			}
			return -1;
		}

		// Token: 0x04000CC6 RID: 3270
		private int int_1;

		// Token: 0x04000CC7 RID: 3271
		private LogicCommand logicCommand_0;
	}
}
