using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008D RID: 141
	public class LoadAvatarStreamOfTypeRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00006E62 File Offset: 0x00005062
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00006E6A File Offset: 0x0000506A
		public LogicArrayList<LogicLong> StreamIds { get; set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00006E73 File Offset: 0x00005073
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00006E7B File Offset: 0x0000507B
		public LogicLong SenderAvatarId { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00006E84 File Offset: 0x00005084
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00006E8C File Offset: 0x0000508C
		public AvatarStreamEntryType Type { get; set; }

		// Token: 0x060003E2 RID: 994 RVA: 0x0000C2F4 File Offset: 0x0000A4F4
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.StreamIds.Size());
			for (int i = 0; i < this.StreamIds.Size(); i++)
			{
				stream.WriteLong(this.StreamIds[i]);
			}
			if (this.SenderAvatarId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.SenderAvatarId);
			}
			stream.WriteVInt((int)this.Type);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000C364 File Offset: 0x0000A564
		public override void Decode(ByteStream stream)
		{
			this.StreamIds = new LogicArrayList<LogicLong>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.StreamIds.Add(stream.ReadLong());
			}
			if (stream.ReadBoolean())
			{
				this.SenderAvatarId = stream.ReadLong();
			}
			this.Type = (AvatarStreamEntryType)stream.ReadVInt();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00006E95 File Offset: 0x00005095
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_REQUEST;
		}

		// Token: 0x040001C6 RID: 454
		[CompilerGenerated]
		private LogicArrayList<LogicLong> logicArrayList_0;

		// Token: 0x040001C7 RID: 455
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001C8 RID: 456
		[CompilerGenerated]
		private AvatarStreamEntryType avatarStreamEntryType_0;
	}
}
