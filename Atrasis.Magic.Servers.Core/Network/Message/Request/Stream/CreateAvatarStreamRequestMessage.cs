using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000087 RID: 135
	public class CreateAvatarStreamRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00006C1B File Offset: 0x00004E1B
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x00006C23 File Offset: 0x00004E23
		public LogicLong OwnerId { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00006C2C File Offset: 0x00004E2C
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00006C34 File Offset: 0x00004E34
		public AvatarStreamEntry Entry { get; set; }

		// Token: 0x060003B8 RID: 952 RVA: 0x00006C3D File Offset: 0x00004E3D
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.OwnerId);
			stream.WriteVInt((int)this.Entry.GetAvatarStreamEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00006C68 File Offset: 0x00004E68
		public override void Decode(ByteStream stream)
		{
			this.OwnerId = stream.ReadLong();
			this.Entry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00006C93 File Offset: 0x00004E93
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_AVATAR_STREAM_REQUEST;
		}

		// Token: 0x040001BE RID: 446
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001BF RID: 447
		[CompilerGenerated]
		private AvatarStreamEntry avatarStreamEntry_0;
	}
}
