using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000035 RID: 53
	public class GameMatchmakingMessage : ServerSessionMessage
	{
		// Token: 0x06000136 RID: 310 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000522D File Offset: 0x0000342D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_MATCHMAKING;
		}
	}
}
