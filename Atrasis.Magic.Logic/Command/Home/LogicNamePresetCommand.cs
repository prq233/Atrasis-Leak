using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001AF RID: 431
	public sealed class LogicNamePresetCommand : LogicCommand
	{
		// Token: 0x06001778 RID: 6008 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicNamePresetCommand()
		{
		}

		// Token: 0x06001779 RID: 6009 RVA: 0x0000F634 File Offset: 0x0000D834
		public LogicNamePresetCommand(int id, string name)
		{
			this.int_1 = id;
			this.string_0 = name;
		}

		// Token: 0x0600177A RID: 6010 RVA: 0x0000F64A File Offset: 0x0000D84A
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.string_0 = stream.ReadString(900000);
			base.Decode(stream);
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x0000F670 File Offset: 0x0000D870
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteString(this.string_0);
			base.Encode(encoder);
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x0000F691 File Offset: 0x0000D891
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.NAME_PRESET;
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x0000F698 File Offset: 0x0000D898
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x0000F6A7 File Offset: 0x0000D8A7
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 <= -1)
			{
				return -1;
			}
			if (this.int_1 > 3)
			{
				return -2;
			}
			if (this.string_0.Length <= 16)
			{
				level.SetArmyName(this.int_1, this.string_0);
				return 0;
			}
			return -4;
		}

		// Token: 0x04000CDE RID: 3294
		private int int_1;

		// Token: 0x04000CDF RID: 3295
		private string string_0;
	}
}
