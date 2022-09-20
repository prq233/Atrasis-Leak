using System;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009D RID: 157
	public abstract class ServerCoreMessage : ServerMessage
	{
		// Token: 0x06000440 RID: 1088 RVA: 0x000055F5 File Offset: 0x000037F5
		public sealed override ServerMessageCategory GetMessageCategory()
		{
			return ServerMessageCategory.CORE;
		}
	}
}
