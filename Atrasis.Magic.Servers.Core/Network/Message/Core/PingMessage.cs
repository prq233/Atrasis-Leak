using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x02000099 RID: 153
	public class PingMessage : ServerCoreMessage
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000715E File Offset: 0x0000535E
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.PING;
		}
	}
}
