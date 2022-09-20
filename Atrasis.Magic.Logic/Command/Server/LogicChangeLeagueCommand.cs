using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Level;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Logic.Command.Server
{
	// Token: 0x02000175 RID: 373
	public class LogicChangeLeagueCommand : LogicServerCommand
	{
		// Token: 0x060015F5 RID: 5621 RVA: 0x0000E271 File Offset: 0x0000C471
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0000E4EB File Offset: 0x0000C6EB
		public override void Decode(ByteStream stream)
		{
			if (stream.ReadBoolean())
			{
				this.logicLong_0 = stream.ReadLong();
			}
			this.int_2 = stream.ReadInt();
			base.Decode(stream);
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0000E514 File Offset: 0x0000C714
		public override void Encode(ChecksumEncoder encoder)
		{
			if (this.logicLong_0 != null)
			{
				encoder.WriteBoolean(true);
				encoder.WriteLong(this.logicLong_0);
			}
			else
			{
				encoder.WriteBoolean(false);
			}
			encoder.WriteInt(this.int_2);
			base.Encode(encoder);
		}

		// Token: 0x060015F8 RID: 5624 RVA: 0x00054B84 File Offset: 0x00052D84
		public override int Execute(LogicLevel level)
		{
			LogicClientAvatar playerAvatar = level.GetPlayerAvatar();
			if (playerAvatar != null)
			{
				playerAvatar.SetLeagueType(this.int_2);
				if (this.int_2 != 0)
				{
					playerAvatar.SetLeagueInstanceId(this.logicLong_0.Clone());
				}
				else
				{
					playerAvatar.SetLeagueInstanceId(null);
					playerAvatar.SetAttackWinCount(0);
					playerAvatar.SetAttackLoseCount(0);
					playerAvatar.SetDefenseWinCount(0);
					playerAvatar.SetDefenseLoseCount(0);
				}
				playerAvatar.GetChangeListener().LeagueChanged(this.int_2, this.logicLong_0);
				return 0;
			}
			return -1;
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x000046E2 File Offset: 0x000028E2
		public override LogicCommandType GetCommandType()
		{
			return LogicCommandType.CHANGE_LEAGUE;
		}

		// Token: 0x060015FA RID: 5626 RVA: 0x0000E54D File Offset: 0x0000C74D
		public void SetDatas(LogicLong id, int leagueType)
		{
			this.logicLong_0 = id;
			this.int_2 = leagueType;
		}

		// Token: 0x04000C6A RID: 3178
		private LogicLong logicLong_0;

		// Token: 0x04000C6B RID: 3179
		private int int_2;
	}
}
