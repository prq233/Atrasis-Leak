using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000088 RID: 136
	public class CreateAvatarStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00006C9A File Offset: 0x00004E9A
		// (set) Token: 0x060003BD RID: 957 RVA: 0x00006CA2 File Offset: 0x00004EA2
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060003BE RID: 958 RVA: 0x00006CAB File Offset: 0x00004EAB
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00006CD2 File Offset: 0x00004ED2
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00006CF9 File Offset: 0x00004EF9
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM_RESPONSE;
		}

		// Token: 0x040001C0 RID: 448
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
