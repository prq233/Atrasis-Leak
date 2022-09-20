using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200004D RID: 77
	public class GameStateNullDataMessage : ServerSessionMessage
	{
		// Token: 0x060001F3 RID: 499 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0000595A File Offset: 0x00003B5A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_STATE_NULL_DATA;
		}
	}
}
