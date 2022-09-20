using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C0 RID: 192
	public class UpdateAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600055C RID: 1372 RVA: 0x00007C98 File Offset: 0x00005E98
		// (set) Token: 0x0600055D RID: 1373 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x0600055E RID: 1374 RVA: 0x00007CA9 File Offset: 0x00005EA9
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00007CC8 File Offset: 0x00005EC8
		public override void Decode(ByteStream stream)
		{
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00007CE7 File Offset: 0x00005EE7
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_AVATAR_STREAM;
		}

		// Token: 0x04000226 RID: 550
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
