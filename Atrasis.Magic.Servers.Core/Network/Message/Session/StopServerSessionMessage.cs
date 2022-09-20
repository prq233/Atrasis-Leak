using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200004F RID: 79
	public class StopServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x060001FF RID: 511 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000059D3 File Offset: 0x00003BD3
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SERVER_SESSION;
		}
	}
}
