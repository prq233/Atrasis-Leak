using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006B RID: 107
	public class TownHallV2LevelAvatarChange : AvatarChange
	{
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002EC RID: 748 RVA: 0x000063FA File Offset: 0x000045FA
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00006402 File Offset: 0x00004602
		public int Level { get; set; }

		// Token: 0x060002EE RID: 750 RVA: 0x0000640B File Offset: 0x0000460B
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00006419 File Offset: 0x00004619
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00006427 File Offset: 0x00004627
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetVillage2TownHallLevel(this.Level);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00006435 File Offset: 0x00004635
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.TOWN_HALL_V2_LEVEL;
		}

		// Token: 0x04000163 RID: 355
		[CompilerGenerated]
		private int int_0;
	}
}
