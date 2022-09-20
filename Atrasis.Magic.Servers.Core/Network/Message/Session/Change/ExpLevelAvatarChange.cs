using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000063 RID: 99
	public class ExpLevelAvatarChange : AvatarChange
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00005FFD File Offset: 0x000041FD
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00006005 File Offset: 0x00004205
		public int Points { get; set; }

		// Token: 0x0600029E RID: 670 RVA: 0x0000600E File Offset: 0x0000420E
		public override void Decode(ByteStream stream)
		{
			this.Points = stream.ReadVInt();
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000601C File Offset: 0x0000421C
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Points);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000602A File Offset: 0x0000422A
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetExpPoints(this.Points);
			avatar.SetExpLevel(avatar.GetExpLevel() + 1);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00006046 File Offset: 0x00004246
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetExpLevel(memberEntry.GetExpLevel() + 1);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x000055F5 File Offset: 0x000037F5
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.EXP_LEVEL;
		}

		// Token: 0x04000153 RID: 339
		[CompilerGenerated]
		private int int_0;
	}
}
