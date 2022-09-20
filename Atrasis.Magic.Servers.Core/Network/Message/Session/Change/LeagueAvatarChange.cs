using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000065 RID: 101
	public class LeagueAvatarChange : AvatarChange
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00006098 File Offset: 0x00004298
		// (set) Token: 0x060002AD RID: 685 RVA: 0x000060A0 File Offset: 0x000042A0
		public int LeagueType { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000060A9 File Offset: 0x000042A9
		// (set) Token: 0x060002AF RID: 687 RVA: 0x000060B1 File Offset: 0x000042B1
		public LogicLong LeagueInstanceId { get; set; }

		// Token: 0x060002B0 RID: 688 RVA: 0x000060BA File Offset: 0x000042BA
		public override void Decode(ByteStream stream)
		{
			this.LeagueType = stream.ReadVInt();
			if (stream.ReadBoolean())
			{
				this.LeagueInstanceId = stream.ReadLong();
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000060DC File Offset: 0x000042DC
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.LeagueType);
			if (this.LeagueInstanceId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.LeagueInstanceId);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000BD5C File Offset: 0x00009F5C
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetLeagueType(this.LeagueType);
			if (this.LeagueType != 0)
			{
				avatar.SetLeagueInstanceId(this.LeagueInstanceId);
				return;
			}
			avatar.SetLeagueInstanceId(null);
			avatar.SetAttackWinCount(0);
			avatar.SetAttackLoseCount(0);
			avatar.SetDefenseWinCount(0);
			avatar.SetDefenseLoseCount(0);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000610D File Offset: 0x0000430D
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetLeagueType(this.LeagueType);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000611B File Offset: 0x0000431B
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.LEAGUE;
		}

		// Token: 0x04000155 RID: 341
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000156 RID: 342
		[CompilerGenerated]
		private LogicLong logicLong_0;
	}
}
