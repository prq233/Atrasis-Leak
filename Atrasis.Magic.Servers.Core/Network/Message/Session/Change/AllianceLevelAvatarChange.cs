using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000056 RID: 86
	public class AllianceLevelAvatarChange : AvatarChange
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000237 RID: 567 RVA: 0x00005C02 File Offset: 0x00003E02
		// (set) Token: 0x06000238 RID: 568 RVA: 0x00005C0A File Offset: 0x00003E0A
		public int Level { get; set; }

		// Token: 0x06000239 RID: 569 RVA: 0x00005C13 File Offset: 0x00003E13
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00005C21 File Offset: 0x00003E21
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00005C2F File Offset: 0x00003E2F
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceLevel(this.Level);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000059D0 File Offset: 0x00003BD0
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_LEVEL;
		}

		// Token: 0x0400012B RID: 299
		[CompilerGenerated]
		private int int_0;
	}
}
