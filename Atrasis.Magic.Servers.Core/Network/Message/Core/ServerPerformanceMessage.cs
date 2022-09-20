using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A0 RID: 160
	public class ServerPerformanceMessage : ServerCoreMessage
	{
		// Token: 0x06000452 RID: 1106 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x000072AE File Offset: 0x000054AE
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_PERFORMANCE;
		}
	}
}
