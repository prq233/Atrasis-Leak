using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000053 RID: 83
	public class AllianceCastleLevelAvatarChange : AvatarChange
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00005AC8 File Offset: 0x00003CC8
		// (set) Token: 0x0600021A RID: 538 RVA: 0x00005AD0 File Offset: 0x00003CD0
		public int Level { get; set; }

		// Token: 0x0600021B RID: 539 RVA: 0x00005AD9 File Offset: 0x00003CD9
		public override void Decode(ByteStream stream)
		{
			this.Level = stream.ReadVInt();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00005AE7 File Offset: 0x00003CE7
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Level);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00005AF5 File Offset: 0x00003CF5
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAllianceCastleLevel(this.Level);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00005B03 File Offset: 0x00003D03
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ALLIANCE_CASTLE_LEVEL;
		}

		// Token: 0x04000125 RID: 293
		[CompilerGenerated]
		private int int_0;
	}
}
