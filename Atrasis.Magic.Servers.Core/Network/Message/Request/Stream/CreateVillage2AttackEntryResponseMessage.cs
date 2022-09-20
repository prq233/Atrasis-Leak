using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008C RID: 140
	public class CreateVillage2AttackEntryResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00006DFC File Offset: 0x00004FFC
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x00006E04 File Offset: 0x00005004
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x060003D8 RID: 984 RVA: 0x00006E0D File Offset: 0x0000500D
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt((int)this.Entry.GetAttackEntryType());
				this.Entry.Encode(stream);
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x00006E34 File Offset: 0x00005034
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
				this.Entry.Decode(stream);
			}
		}

		// Token: 0x060003DA RID: 986 RVA: 0x00006E5B File Offset: 0x0000505B
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_RESPONSE;
		}

		// Token: 0x040001C5 RID: 453
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
