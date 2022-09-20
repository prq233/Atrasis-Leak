using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000C1 RID: 193
	public class UpdateVillage2AttackEntryMessage : ServerAccountMessage
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x00007CEE File Offset: 0x00005EEE
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x00007CF6 File Offset: 0x00005EF6
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x06000564 RID: 1380 RVA: 0x00007CFF File Offset: 0x00005EFF
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Entry.GetAttackEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00007D1E File Offset: 0x00005F1E
		public override void Decode(ByteStream stream)
		{
			this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00007D3D File Offset: 0x00005F3D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_VILLAGE2_ATTACK_ENTRY;
		}

		// Token: 0x04000227 RID: 551
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
