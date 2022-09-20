using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000091 RID: 145
	public class LoadAvatarStreamResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00006EE8 File Offset: 0x000050E8
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x00006EF0 File Offset: 0x000050F0
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060003F4 RID: 1012 RVA: 0x00006EF9 File Offset: 0x000050F9
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00006F20 File Offset: 0x00005120
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00006F47 File Offset: 0x00005147
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_RESPONSE;
		}

		// Token: 0x040001CE RID: 462
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
