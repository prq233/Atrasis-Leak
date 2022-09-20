using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000060 RID: 96
	public class DefenseVillageGuardCounterAvatarChange : AvatarChange
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00005EC1 File Offset: 0x000040C1
		// (set) Token: 0x06000281 RID: 641 RVA: 0x00005EC9 File Offset: 0x000040C9
		public int Count { get; set; }

		// Token: 0x06000282 RID: 642 RVA: 0x00005ED2 File Offset: 0x000040D2
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00005EE0 File Offset: 0x000040E0
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00005EEE File Offset: 0x000040EE
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetDefenseVillageGuardCounter(this.Count);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00005EFC File Offset: 0x000040FC
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.DEFENSE_VILLAGE_GUARD_COUNTER;
		}

		// Token: 0x0400014E RID: 334
		[CompilerGenerated]
		private int int_0;
	}
}
