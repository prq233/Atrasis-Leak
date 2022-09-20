using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B1 RID: 177
	public class DuelAttackEventMessage : ServerAccountMessage
	{
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x000078B0 File Offset: 0x00005AB0
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x000078B8 File Offset: 0x00005AB8
		public LogicLong AvatarId { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x000078C1 File Offset: 0x00005AC1
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x000078C9 File Offset: 0x00005AC9
		public int Type { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x000078D2 File Offset: 0x00005AD2
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x000078DA File Offset: 0x00005ADA
		public int Stars { get; set; }

		// Token: 0x060004F2 RID: 1266 RVA: 0x000078E3 File Offset: 0x00005AE3
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AvatarId);
			stream.WriteVInt(this.Type);
			stream.WriteVInt(this.Stars);
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00007909 File Offset: 0x00005B09
		public override void Decode(ByteStream stream)
		{
			this.AvatarId = stream.ReadLong();
			this.Type = stream.ReadVInt();
			this.Stars = stream.ReadVInt();
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0000792F File Offset: 0x00005B2F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_ATTACK_EVENT;
		}

		// Token: 0x0400020C RID: 524
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x0400020D RID: 525
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400020E RID: 526
		[CompilerGenerated]
		private int int_3;
	}
}
