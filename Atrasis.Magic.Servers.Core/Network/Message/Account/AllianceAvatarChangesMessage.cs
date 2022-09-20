using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session.Change;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A2 RID: 162
	public class AllianceAvatarChangesMessage : ServerAccountMessage
	{
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000460 RID: 1120 RVA: 0x0000733B File Offset: 0x0000553B
		// (set) Token: 0x06000461 RID: 1121 RVA: 0x00007343 File Offset: 0x00005543
		public LogicLong MemberId { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x0000734C File Offset: 0x0000554C
		// (set) Token: 0x06000463 RID: 1123 RVA: 0x00007354 File Offset: 0x00005554
		public LogicArrayList<AvatarChange> AvatarChanges { get; set; }

		// Token: 0x06000464 RID: 1124 RVA: 0x0000C51C File Offset: 0x0000A71C
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteVInt(this.AvatarChanges.Size());
			for (int i = 0; i < this.AvatarChanges.Size(); i++)
			{
				AvatarChangeFactory.Encode(stream, this.AvatarChanges[i]);
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000C570 File Offset: 0x0000A770
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.AvatarChanges = new LogicArrayList<AvatarChange>();
			for (int i = stream.ReadVInt(); i > 0; i--)
			{
				this.AvatarChanges.Add(AvatarChangeFactory.Decode(stream));
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000735D File Offset: 0x0000555D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_AVATAR_CHANGES;
		}

		// Token: 0x040001E4 RID: 484
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001E5 RID: 485
		[CompilerGenerated]
		private LogicArrayList<AvatarChange> logicArrayList_0;
	}
}
