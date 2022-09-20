using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A2 RID: 418
	public sealed class LogicEventSeenCommand : LogicCommand
	{
		// Token: 0x06001727 RID: 5927 RVA: 0x0000F1ED File Offset: 0x0000D3ED
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0000F202 File Offset: 0x0000D402
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			base.Encode(encoder);
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x0000F217 File Offset: 0x0000D417
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.EVENT_SEEN;
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x0000F21E File Offset: 0x0000D41E
		public override int Execute(LogicLevel level)
		{
			level.GetGameMode().GetCalendar().SetEventSeenTime(this.int_1);
			return 0;
		}

		// Token: 0x04000CC5 RID: 3269
		private int int_1;
	}
}
