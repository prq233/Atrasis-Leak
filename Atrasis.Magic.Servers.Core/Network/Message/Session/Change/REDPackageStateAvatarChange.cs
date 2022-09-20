using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000068 RID: 104
	public class REDPackageStateAvatarChange : AvatarChange
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002CE RID: 718 RVA: 0x00006296 File Offset: 0x00004496
		// (set) Token: 0x060002CF RID: 719 RVA: 0x0000629E File Offset: 0x0000449E
		public int State { get; set; }

		// Token: 0x060002D0 RID: 720 RVA: 0x000062A7 File Offset: 0x000044A7
		public override void Decode(ByteStream stream)
		{
			this.State = stream.ReadVInt();
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000062B5 File Offset: 0x000044B5
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.State);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000062C3 File Offset: 0x000044C3
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetRedPackageState(this.State);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00004631 File Offset: 0x00002831
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000062D1 File Offset: 0x000044D1
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.RED_PACKAGE_STATE_CHANGED;
		}

		// Token: 0x0400015D RID: 349
		[CompilerGenerated]
		private int int_0;
	}
}
