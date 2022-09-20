using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000061 RID: 97
	public class DiamondAvatarChange : AvatarChange
	{
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000288 RID: 648 RVA: 0x00005F00 File Offset: 0x00004100
		// (set) Token: 0x06000289 RID: 649 RVA: 0x00005F08 File Offset: 0x00004108
		public int Count { get; set; }

		// Token: 0x0600028A RID: 650 RVA: 0x00005F11 File Offset: 0x00004111
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00005F1F File Offset: 0x0000411F
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00005F2D File Offset: 0x0000412D
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDiamonds(avatar.GetDiamonds() + this.Count);
			avatar.SetFreeDiamonds(avatar.GetFreeDiamonds() + this.Count);
			if (avatar.GetFreeDiamonds() < 0)
			{
				avatar.SetFreeDiamonds(0);
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000574A File Offset: 0x0000394A
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DIAMOND;
		}

		// Token: 0x0400014F RID: 335
		[CompilerGenerated]
		private int int_0;
	}
}
