using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000062 RID: 98
	public class DuelScoreAvatarChange : AvatarChange
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00005F65 File Offset: 0x00004165
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00005F6D File Offset: 0x0000416D
		public int DuelScoreGain { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00005F76 File Offset: 0x00004176
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00005F7E File Offset: 0x0000417E
		public int ResultType { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00005F87 File Offset: 0x00004187
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00005F8F File Offset: 0x0000418F
		public bool Attacker { get; set; }

		// Token: 0x06000296 RID: 662 RVA: 0x00005F98 File Offset: 0x00004198
		public override void Decode(ByteStream stream)
		{
			this.DuelScoreGain = stream.ReadVInt();
			this.ResultType = stream.ReadVInt();
			this.Attacker = stream.ReadBoolean();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00005FBE File Offset: 0x000041BE
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.DuelScoreGain);
			stream.WriteVInt(this.ResultType);
			stream.WriteBoolean(this.Attacker);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000BCF4 File Offset: 0x00009EF4
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDuelScore(avatar.GetDuelScore() + this.DuelScoreGain);
			switch (this.ResultType)
			{
			case 0:
				avatar.SetDuelLoseCount(avatar.GetDuelLoseCount() + 1);
				return;
			case 1:
				avatar.SetDuelWinCount(avatar.GetDuelWinCount() + 1);
				return;
			case 2:
				avatar.SetDuelDrawCount(avatar.GetDuelDrawCount() + 1);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00005FE4 File Offset: 0x000041E4
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetDuelScore(memberEntry.GetDuelScore() + this.DuelScoreGain);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00005FF9 File Offset: 0x000041F9
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DUEL_SCORE;
		}

		// Token: 0x04000150 RID: 336
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000151 RID: 337
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04000152 RID: 338
		[CompilerGenerated]
		private bool bool_0;
	}
}
