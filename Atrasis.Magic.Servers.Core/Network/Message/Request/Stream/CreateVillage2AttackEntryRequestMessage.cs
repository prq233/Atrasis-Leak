using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Logic.Message.Avatar.Attack;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request.Stream
{
	// Token: 0x0200008B RID: 139
	public class CreateVillage2AttackEntryRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00006D7D File Offset: 0x00004F7D
		// (set) Token: 0x060003CF RID: 975 RVA: 0x00006D85 File Offset: 0x00004F85
		public LogicLong OwnerId { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00006D8E File Offset: 0x00004F8E
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x00006D96 File Offset: 0x00004F96
		public Village2AttackEntry Entry { get; set; }

		// Token: 0x060003D2 RID: 978 RVA: 0x00006D9F File Offset: 0x00004F9F
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.OwnerId);
			stream.WriteVInt((int)this.Entry.GetAttackEntryType());
			this.Entry.Encode(stream);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00006DCA File Offset: 0x00004FCA
		public override void Decode(ByteStream stream)
		{
			this.OwnerId = stream.ReadLong();
			this.Entry = Village2AttackEntryFactory.CreateAttackEntryByType((Village2AttackEntryType)stream.ReadVInt());
			this.Entry.Decode(stream);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00006DF5 File Offset: 0x00004FF5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_VILLAGE2_ATTACK_ENTRY_REQUEST;
		}

		// Token: 0x040001C3 RID: 451
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040001C4 RID: 452
		[CompilerGenerated]
		private Village2AttackEntry village2AttackEntry_0;
	}
}
