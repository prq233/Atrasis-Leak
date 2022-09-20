using System;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000055 RID: 85
	public class AllianceLeftAvatarChange : AvatarChange
	{
		// Token: 0x06000231 RID: 561 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00005BE0 File Offset: 0x00003DE0
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceId(null);
			avatar.SetAllianceName(string.Empty);
			avatar.SetAllianceBadgeId(-1);
			avatar.SetAllianceLevel(-1);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00005691 File Offset: 0x00003891
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_LEFT;
		}
	}
}
