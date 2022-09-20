using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x02000095 RID: 149
	public class LoadVillage2AttackEntryResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x00007001 File Offset: 0x00005201
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x00007009 File Offset: 0x00005209
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x06000412 RID: 1042 RVA: 0x00007012 File Offset: 0x00005212
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAttackEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00007039 File Offset: 0x00005239
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00007060 File Offset: 0x00005260
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.LOAD_VILLAGE2_ATTACK_ENTRY_RESPONSE;
		}

		// Token: 0x040001D5 RID: 469
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
