using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001C3 RID: 451
	public sealed class LogicSetItemSeenCommand : LogicCommand
	{
		// Token: 0x060017FD RID: 6141 RVA: 0x0000EAEB File Offset: 0x0000CCEB
		public LogicSetItemSeenCommand()
		{
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x0000FD50 File Offset: 0x0000DF50
		public LogicSetItemSeenCommand(int villageType)
		{
			this.int_1 = villageType;
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x0000FD5F File Offset: 0x0000DF5F
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0000FD74 File Offset: 0x0000DF74
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x0000FD89 File Offset: 0x0000DF89
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.SET_ITEM_SEEN;
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x0000FD90 File Offset: 0x0000DF90
		public override int Execute(LogicLevel level)
		{
			if (this.int_1 == 0)
			{
				level.GetPlayerAvatar().SetVariableByName("SeenBuilderMenu", 1);
				return 0;
			}
			return -1;
		}

		// Token: 0x04000D08 RID: 3336
		private int int_1;
	}
}
