using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000054 RID: 84
	public class AllianceJoinedAvatarChange : AvatarChange
	{
		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00005B0F File Offset: 0x00003D0F
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00005B17 File Offset: 0x00003D17
		public LogicLong AllianceId { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00005B20 File Offset: 0x00003D20
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00005B28 File Offset: 0x00003D28
		public string AllianceName { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000225 RID: 549 RVA: 0x00005B31 File Offset: 0x00003D31
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00005B39 File Offset: 0x00003D39
		public int AllianceBadgeId { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000227 RID: 551 RVA: 0x00005B42 File Offset: 0x00003D42
		// (set) Token: 0x06000228 RID: 552 RVA: 0x00005B4A File Offset: 0x00003D4A
		public int AllianceExpLevel { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000229 RID: 553 RVA: 0x00005B53 File Offset: 0x00003D53
		// (set) Token: 0x0600022A RID: 554 RVA: 0x00005B5B File Offset: 0x00003D5B
		public LogicAvatarAllianceRole AllianceRole { get; set; }

		// Token: 0x0600022B RID: 555 RVA: 0x0000BB9C File Offset: 0x00009D9C
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
			this.AllianceName = stream.ReadString(900000);
			this.AllianceBadgeId = stream.ReadVInt();
			this.AllianceExpLevel = stream.ReadVInt();
			this.AllianceRole = (LogicAvatarAllianceRole)stream.ReadVInt();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00005B64 File Offset: 0x00003D64
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
			stream.WriteString(this.AllianceName);
			stream.WriteVInt(this.AllianceBadgeId);
			stream.WriteVInt(this.AllianceExpLevel);
			stream.WriteVInt((int)this.AllianceRole);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00005BA2 File Offset: 0x00003DA2
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceId(this.AllianceId);
			avatar.SetAllianceName(this.AllianceName);
			avatar.SetAllianceBadgeId(this.AllianceBadgeId);
			avatar.SetAllianceLevel(this.AllianceExpLevel);
			avatar.SetAllianceRole(this.AllianceRole);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00005703 File Offset: 0x00003903
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_JOINED;
		}

		// Token: 0x04000126 RID: 294
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000127 RID: 295
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000128 RID: 296
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04000129 RID: 297
		[CompilerGenerated]
		private int int_1;

		// Token: 0x0400012A RID: 298
		[CompilerGenerated]
		private LogicAvatarAllianceRole logicAvatarAllianceRole_0;
	}
}
