using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Data;
using Atrasis.Magic.Logic.Helper;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000069 RID: 105
	public class ScoreAvatarChange : AvatarChange
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x000062D5 File Offset: 0x000044D5
		// (set) Token: 0x060002D7 RID: 727 RVA: 0x000062DD File Offset: 0x000044DD
		public int ScoreGain { get; set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x000062E6 File Offset: 0x000044E6
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x000062EE File Offset: 0x000044EE
		public bool Attacker { get; set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002DA RID: 730 RVA: 0x000062F7 File Offset: 0x000044F7
		// (set) Token: 0x060002DB RID: 731 RVA: 0x000062FF File Offset: 0x000044FF
		public LogicLeagueData PrevLeagueData { get; set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002DC RID: 732 RVA: 0x00006308 File Offset: 0x00004508
		// (set) Token: 0x060002DD RID: 733 RVA: 0x00006310 File Offset: 0x00004510
		public LogicLeagueData LeagueData { get; set; }

		// Token: 0x060002DE RID: 734 RVA: 0x00006319 File Offset: 0x00004519
		public override void Decode(ByteStream stream)
		{
			this.ScoreGain = stream.ReadVInt();
			this.Attacker = stream.ReadBoolean();
			this.PrevLeagueData = (LogicLeagueData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.LEAGUE);
			this.LeagueData = (LogicLeagueData)ByteStreamHelper.ReadDataReference(stream, LogicDataType.LEAGUE);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00006359 File Offset: 0x00004559
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ScoreGain);
			stream.WriteBoolean(this.Attacker);
			ByteStreamHelper.WriteDataReference(stream, this.PrevLeagueData);
			ByteStreamHelper.WriteDataReference(stream, this.LeagueData);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetScore(LogicMath.Max(avatar.GetScore() + this.ScoreGain, 0));
			avatar.SetLeagueType(this.LeagueData.GetInstanceID());
			if (this.PrevLeagueData != null)
			{
				if (this.Attacker)
				{
					if (this.ScoreGain < 0)
					{
						avatar.SetAttackLoseCount(avatar.GetAttackLoseCount() + 1);
						return;
					}
					avatar.SetAttackWinCount(avatar.GetAttackWinCount() + 1);
					return;
				}
				else
				{
					if (this.ScoreGain < 0)
					{
						avatar.SetDefenseLoseCount(avatar.GetDefenseLoseCount() + 1);
						return;
					}
					avatar.SetDefenseWinCount(avatar.GetDefenseWinCount() + 1);
				}
			}
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000638B File Offset: 0x0000458B
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetScore(LogicMath.Max(memberEntry.GetScore() + this.ScoreGain, 0));
			memberEntry.SetLeagueType(this.LeagueData.GetInstanceID());
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000063B7 File Offset: 0x000045B7
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.SCORE;
		}

		// Token: 0x0400015E RID: 350
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400015F RID: 351
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04000160 RID: 352
		[CompilerGenerated]
		private LogicLeagueData logicLeagueData_0;

		// Token: 0x04000161 RID: 353
		[CompilerGenerated]
		private LogicLeagueData logicLeagueData_1;
	}
}
