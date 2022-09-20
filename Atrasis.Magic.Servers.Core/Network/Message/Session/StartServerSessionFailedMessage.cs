using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200003E RID: 62
	public class StartServerSessionFailedMessage : ServerSessionMessage
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00005409 File Offset: 0x00003609
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00005411 File Offset: 0x00003611
		public new long SessionId
		{
			get
			{
				return base.SessionId;
			}
			set
			{
				base.SessionId = value;
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000541A File Offset: 0x0000361A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.START_SERVER_SESSION_FAILED;
		}
	}
}
