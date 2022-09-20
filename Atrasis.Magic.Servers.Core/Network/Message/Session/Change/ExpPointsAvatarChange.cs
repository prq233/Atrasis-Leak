using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000064 RID: 100
	public class ExpPointsAvatarChange : AvatarChange
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00006056 File Offset: 0x00004256
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x0000605E File Offset: 0x0000425E
		public int Points { get; set; }

		// Token: 0x060002A6 RID: 678 RVA: 0x00006067 File Offset: 0x00004267
		public override void Decode(ByteStream stream)
		{
			this.Points = stream.ReadVInt();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00006075 File Offset: 0x00004275
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Points);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00006083 File Offset: 0x00004283
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetExpPoints(avatar.GetExpPoints() + this.Points);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000053FE File Offset: 0x000035FE
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.EXP_POINTS;
		}

		// Token: 0x04000154 RID: 340
		[CompilerGenerated]
		private int int_0;
	}
}
