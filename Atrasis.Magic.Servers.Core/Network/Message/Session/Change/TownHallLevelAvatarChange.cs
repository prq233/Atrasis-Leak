using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200006A RID: 106
	public class TownHallLevelAvatarChange : AvatarChange
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x000063BB File Offset: 0x000045BB
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x000063C3 File Offset: 0x000045C3
		public int Level { get; set; }

		// Token: 0x060002E6 RID: 742 RVA: 0x000063CC File Offset: 0x000045CC
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000063DA File Offset: 0x000045DA
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x000063E8 File Offset: 0x000045E8
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetTownHallLevel(this.Level);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002EA RID: 746 RVA: 0x000063F6 File Offset: 0x000045F6
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.TOWN_HALL_LEVEL;
		}

		// Token: 0x04000162 RID: 354
		[CompilerGenerated]
		private int int_0;
	}
}
