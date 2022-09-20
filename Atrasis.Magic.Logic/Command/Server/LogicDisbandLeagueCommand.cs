using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000179 RID: 377
	public class LogicDisbandLeagueCommand : LogicServerCommand
	{
		// Token: 0x06001610 RID: 5648 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x0000E625 File Offset: 0x0000C825
		public override void Decode(ByteStream stream)
		{
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x0000E63A File Offset: 0x0000C83A
		public override void Encode(ChecksumEncoder encoder)
		{
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x00054F04 File Offset: 0x00053104
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetLeagueType(0);
				playerAvatar.SetLeagueInstanceId(null);
				playerAvatar.SetAttackWinCount(0);
				playerAvatar.SetAttackLoseCount(0);
				playerAvatar.SetDefenseWinCount(0);
				playerAvatar.SetDefenseLoseCount(0);
				level.SetLastLeagueShuffle(true);
				playerAvatar.GetChangeListener().LeagueChanged(0, null);
				return 0;
			}
			return -1;
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x000077D8 File Offset: 0x000059D8
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.DISBAND_LEAGUE;
		}

		// Token: 0x04000C77 RID: 3191
		private int int_2;
	}
}
