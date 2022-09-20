using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x02000096 RID: 150
	public class AskForServerStatusMessage : ServerCoreMessage
	{
		// Token: 0x06000416 RID: 1046 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00007067 File Offset: 0x00005267
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ASK_FOR_SERVER_STATUS;
		}
	}
}
