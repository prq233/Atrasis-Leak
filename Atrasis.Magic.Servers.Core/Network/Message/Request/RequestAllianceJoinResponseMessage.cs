using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000083 RID: 131
	public class RequestAllianceJoinResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x00006B38 File Offset: 0x00004D38
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00006B40 File Offset: 0x00004D40
		public RequestAllianceJoinResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x060003A2 RID: 930 RVA: 0x00006B49 File Offset: 0x00004D49
		public override void Encode(ByteStream stream)
		{
			if (!base.Success)
			{
				stream.WriteVInt((int)this.ErrorReason);
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00006B5F File Offset: 0x00004D5F
		public override void Decode(ByteStream stream)
		{
			if (!base.Success)
			{
				this.ErrorReason = (RequestAllianceJoinResponseMessage.Reason)stream.ReadVInt();
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00006B75 File Offset: 0x00004D75
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REQUEST_ALLIANCE_JOIN_RESPONSE;
		}

		// Token: 0x040001B2 RID: 434
		[CompilerGenerated]
		private RequestAllianceJoinResponseMessage.Reason reason_0;

		// Token: 0x02000084 RID: 132
		public enum Reason
		{
			// Token: 0x040001B4 RID: 436
			GENERIC,
			// Token: 0x040001B5 RID: 437
			CLOSED,
			// Token: 0x040001B6 RID: 438
			ALREADY_SENT,
			// Token: 0x040001B7 RID: 439
			NO_SCORE,
			// Token: 0x040001B8 RID: 440
			BANNED,
			// Token: 0x040001B9 RID: 441
			TOO_MANY_PENDING_REQUESTS,
			// Token: 0x040001BA RID: 442
			NO_DUEL_SCORE
		}
	}
}
