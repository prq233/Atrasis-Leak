using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x02000189 RID: 393
	public sealed class LogicAccountBoundCommand : LogicCommand
	{
		// Token: 0x0600167D RID: 5757 RVA: 0x0000EA99 File Offset: 0x0000CC99
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0000EAAE File Offset: 0x0000CCAE
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x0600167F RID: 5759 RVA: 0x0000EAC3 File Offset: 0x0000CCC3
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.ACCOUNT_BOUND;
		}

		// Token: 0x06001680 RID: 5760 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001681 RID: 5761 RVA: 0x0000EAD2 File Offset: 0x0000CCD2
		public override int Execute(LogicLevel level)
		{
			level.GetPlayerAvatar().SetAccountBound();
			level.GetAchievementManager().RefreshStatus();
			return 0;
		}

		// Token: 0x04000C99 RID: 3225
		private int int_1;
	}
}
