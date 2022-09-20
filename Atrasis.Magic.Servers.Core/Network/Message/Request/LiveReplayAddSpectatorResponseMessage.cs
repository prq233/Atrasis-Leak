using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000080 RID: 128
	public class LiveReplayAddSpectatorResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00006A5E File Offset: 0x00004C5E
		// (set) Token: 0x06000391 RID: 913 RVA: 0x00006A66 File Offset: 0x00004C66
		public LiveReplayAddSpectatorResponseMessage.Reason ErrorCode { get; set; }

		// Token: 0x06000392 RID: 914 RVA: 0x00006A6F File Offset: 0x00004C6F
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorCode);
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00006A85 File Offset: 0x00004C85
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorCode = (LiveReplayAddSpectatorResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00006A9B File Offset: 0x00004C9B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LIVE_REPLAY_ADD_SPECTATOR_RESPONSE;
		}

		// Token: 0x040001AB RID: 427
		[CompilerGenerated]
		private LiveReplayAddSpectatorResponseMessage.Reason reason_0;

		// Token: 0x02000081 RID: 129
		public enum Reason
		{
			// Token: 0x040001AD RID: 429
			NOT_EXISTS,
			// Token: 0x040001AE RID: 430
			FULL
		}
	}
}
