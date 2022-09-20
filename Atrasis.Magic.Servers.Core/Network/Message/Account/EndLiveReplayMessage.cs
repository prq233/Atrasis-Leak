using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B5 RID: 181
	public class EndLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x06000512 RID: 1298 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00007A23 File Offset: 0x00005C23
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.END_LIVE_REPLAY;
		}
	}
}
