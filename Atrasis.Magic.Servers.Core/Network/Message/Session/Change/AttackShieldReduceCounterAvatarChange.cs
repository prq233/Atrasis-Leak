using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x0200005A RID: 90
	public class AttackShieldReduceCounterAvatarChange : AvatarChange
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00005DC0 File Offset: 0x00003FC0
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00005DC8 File Offset: 0x00003FC8
		public int Count { get; set; }

		// Token: 0x06000261 RID: 609 RVA: 0x00005DD1 File Offset: 0x00003FD1
		public override void Decode(ByteStream stream)
		{
			this.Count = stream.ReadVInt();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00005DDF File Offset: 0x00003FDF
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Count);
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00005DED File Offset: 0x00003FED
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetAttackShieldReduceCounter(this.Count);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00005DFB File Offset: 0x00003FFB
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.ATTACK_SHIELD_REDUCE_COUNTER;
		}

		// Token: 0x04000133 RID: 307
		[CompilerGenerated]
		private int int_0;
	}
}
