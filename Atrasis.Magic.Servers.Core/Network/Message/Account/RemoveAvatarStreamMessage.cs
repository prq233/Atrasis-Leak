using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BC RID: 188
	public class RemoveAvatarStreamMessage : ServerAccountMessage
	{
		// Token: 0x06000548 RID: 1352 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00007C1B File Offset: 0x00005E1B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REMOVE_AVATAR_STREAM;
		}
	}
}
