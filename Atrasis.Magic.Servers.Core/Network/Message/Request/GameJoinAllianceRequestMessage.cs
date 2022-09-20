using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200007C RID: 124
	public class GameJoinAllianceRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000372 RID: 882 RVA: 0x00006938 File Offset: 0x00004B38
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00006940 File Offset: 0x00004B40
		public LogicLong AccountId { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00006949 File Offset: 0x00004B49
		// (set) Token: 0x06000375 RID: 885 RVA: 0x00006951 File Offset: 0x00004B51
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000695A File Offset: 0x00004B5A
		// (set) Token: 0x06000377 RID: 887 RVA: 0x00006962 File Offset: 0x00004B62
		public LogicLong AvatarStreamId { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000696B File Offset: 0x00004B6B
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00006973 File Offset: 0x00004B73
		public bool Created { get; set; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0000697C File Offset: 0x00004B7C
		// (set) Token: 0x0600037B RID: 891 RVA: 0x00006984 File Offset: 0x00004B84
		public bool Invited { get; set; }

		// Token: 0x0600037C RID: 892 RVA: 0x0000C240 File Offset: 0x0000A440
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteLong(this.AllianceId);
			stream.WriteBoolean(this.Created);
			stream.WriteBoolean(this.Invited);
			stream.WriteBoolean(this.AvatarStreamId != null);
			if (this.AvatarStreamId != null)
			{
				stream.WriteLong(this.AvatarStreamId);
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.AllianceId = stream.ReadLong();
			this.Created = stream.ReadBoolean();
			this.Invited = stream.ReadBoolean();
			if (stream.ReadBoolean())
			{
				this.AvatarStreamId = stream.ReadLong();
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000698D File Offset: 0x00004B8D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_JOIN_ALLIANCE_REQUEST;
		}

		// Token: 0x0400019A RID: 410
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x0400019B RID: 411
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400019C RID: 412
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x0400019D RID: 413
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x0400019E RID: 414
		[CompilerGenerated]
		private bool bool_1;
	}
}
