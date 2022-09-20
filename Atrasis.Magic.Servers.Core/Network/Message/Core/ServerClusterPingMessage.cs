using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009C RID: 156
	public class ServerClusterPingMessage : ServerCoreMessage
	{
		// Token: 0x0600043C RID: 1084 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000071E8 File Offset: 0x000053E8
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_CLUSTER_PING;
		}
	}
}
