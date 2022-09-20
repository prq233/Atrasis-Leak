using System;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Home
{
	// Token: 0x020001A7 RID: 423
	public sealed class LogicLeagueNotificationSeenCommand : LogicCommand
	{
		// Token: 0x06001745 RID: 5957 RVA: 0x0000F33D File Offset: 0x0000D53D
		public override void Decode(ByteStream stream)
		{
			this.int_1 = stream.ReadInt();
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x0000F35E File Offset: 0x0000D55E
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_1);
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x0000F37F File Offset: 0x0000D57F
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.LEAGUE_NOTIFICATION_SEEN;
		}

		// Token: 0x06001748 RID: 5960 RVA: 0x0000EACA File Offset: 0x0000CCCA
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x0000F386 File Offset: 0x0000D586
		public override int Execute(LogicLevel level)
		{
			level.SetLastLeagueRank(this.int_1);
			level.SetLastLeagueShuffle(false);
			level.SetLastSeasonSeen(this.int_2);
			return 0;
		}

		// Token: 0x04000CC9 RID: 3273
		private int int_1;

		// Token: 0x04000CCA RID: 3274
		private int int_2;
	}
}
