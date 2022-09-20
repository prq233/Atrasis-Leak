using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AE RID: 174
	public class AvatarStreamSeenMessage : ServerAccountMessage
	{
		// Token: 0x060004DA RID: 1242 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0000782A File Offset: 0x00005A2A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.AVATAR_STREAM_SEEN;
		}
	}
}
