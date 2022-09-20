using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009A RID: 154
	public class PongMessage : ServerCoreMessage
	{
		// Token: 0x06000430 RID: 1072 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00007165 File Offset: 0x00005365
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.PONG;
		}
	}
}
