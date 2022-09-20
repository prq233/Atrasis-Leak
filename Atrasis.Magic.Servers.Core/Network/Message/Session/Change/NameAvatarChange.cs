using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Avatar;
using Atrasis.Magic.Logic.Message.Alliance;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session.Change
{
	// Token: 0x02000067 RID: 103
	public class NameAvatarChange : AvatarChange
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x00006208 File Offset: 0x00004408
		// (set) Token: 0x060002C5 RID: 709 RVA: 0x00006210 File Offset: 0x00004410
		public string Name { get; set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00006219 File Offset: 0x00004419
		// (set) Token: 0x060002C7 RID: 711 RVA: 0x00006221 File Offset: 0x00004421
		public int NameChangeState { get; set; }

		// Token: 0x060002C8 RID: 712 RVA: 0x0000622A File Offset: 0x0000442A
		public override void Decode(ByteStream stream)
		{
			this.Name = stream.ReadString(900000);
			this.NameChangeState = stream.ReadVInt();
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00006249 File Offset: 0x00004449
		public override void Encode(ByteStream stream)
		{
			stream.WriteString(this.Name);
			stream.WriteVInt(this.NameChangeState);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00006263 File Offset: 0x00004463
		public override void ApplyAvatarChange(LogicClientAvatar avatar)
		{
			avatar.SetName(this.Name);
			avatar.SetNameSetByUser(true);
			avatar.SetNameChangeState(this.NameChangeState);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00006284 File Offset: 0x00004484
		public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
		{
			memberEntry.SetName(this.Name);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00006292 File Offset: 0x00004492
		public override AvatarChangeType GetAvatarChangeType()
		{
			return AvatarChangeType.NAME;
		}

		// Token: 0x0400015B RID: 347
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400015C RID: 348
		[CompilerGenerated]
		private int int_0;
	}
}
