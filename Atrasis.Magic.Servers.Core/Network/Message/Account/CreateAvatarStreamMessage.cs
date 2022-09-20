using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B0 RID: 176
	public class CreateAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000785A File Offset: 0x00005A5A
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x00007862 File Offset: 0x00005A62
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060004E8 RID: 1256 RVA: 0x0000786B File Offset: 0x00005A6B
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000788A File Offset: 0x00005A8A
		public override void Decode(ByteStream stream)
		{
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x000078A9 File Offset: 0x00005AA9
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM;
		}

		// Token: 0x0400020B RID: 523
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
