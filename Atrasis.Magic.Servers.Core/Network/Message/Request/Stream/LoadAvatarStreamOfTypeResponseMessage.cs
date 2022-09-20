using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Stream;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008E RID: 142
	public class LoadAvatarStreamOfTypeResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00006E9C File Offset: 0x0000509C
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00006EA4 File Offset: 0x000050A4
		public LogicArrayList<AvatarStreamEntry> StreamList { get; set; }

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000C3C0 File Offset: 0x0000A5C0
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt(this.StreamList.Size());
				for (int i = 0; i < this.StreamList.Size(); i++)
				{
					stream.WriteVInt((int)this.StreamList[i].GetAvatarStreamEntryType());
					this.StreamList[i].Encode(stream);
				}
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000C428 File Offset: 0x0000A628
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.StreamList = new LogicArrayList<AvatarStreamEntry>();
				for (int i = stream.ReadVInt() - 1; i >= 0; i--)
				{
					AvatarStreamEntry avatarStreamEntry = AvatarStreamEntryFactory.CreateStreamEntryByType((AvatarStreamEntryType)stream.ReadVInt());
					avatarStreamEntry.Decode(stream);
					this.StreamList.Add(avatarStreamEntry);
				}
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00006EAD File Offset: 0x000050AD
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_AVATAR_STREAM_OF_TYPE_RESPONSE;
		}

		// Token: 0x040001C9 RID: 457
		[CompilerGenerated]
		private LogicArrayList<AvatarStreamEntry> logicArrayList_0;

		// Token: 0x0200008F RID: 143
		public enum Reason
		{
			// Token: 0x040001CB RID: 459
			GENERIC,
			// Token: 0x040001CC RID: 460
			ALREADY_SENT
		}
	}
}
