using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A3 RID: 163
	public class AllianceChallengeLiveReplayIdMessage : ServerAccountMessage
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x00007364 File Offset: 0x00005564
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x0000736C File Offset: 0x0000556C
		public LogicLong LiveReplayId { get; set; }

		// Token: 0x0600046A RID: 1130 RVA: 0x00007375 File Offset: 0x00005575
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.LiveReplayId);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00007383 File Offset: 0x00005583
		public override void Decode(ByteStream stream)
		{
			this.LiveReplayId = stream.ReadLong();
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00007391 File Offset: 0x00005591
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_LIVE_REPLAY_ID;
		}

		// Token: 0x040001E6 RID: 486
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
