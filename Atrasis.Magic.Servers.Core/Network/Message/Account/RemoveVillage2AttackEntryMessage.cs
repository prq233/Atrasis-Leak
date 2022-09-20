using System;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BD RID: 189
	public class RemoveVillage2AttackEntryMessage : ServerAccountMessage
	{
		// Token: 0x0600054C RID: 1356 RVA: 0x00004631 File Offset: 0x00002831
		public override void Encode(ByteStream stream)
		{
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00004631 File Offset: 0x00002831
		public override void Decode(ByteStream stream)
		{
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00007C22 File Offset: 0x00005E22
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.REMOVE_VILLAGE2_ATTACK_ENTRY;
		}
	}
}
