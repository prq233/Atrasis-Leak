using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000B2 RID: 178
	public class DuelProgressMessage : ServerAccountMessage
	{
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00007936 File Offset: 0x00005B36
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x0000793E File Offset: 0x00005B3E
		public LogicLong AvatarId { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00007947 File Offset: 0x00005B47
		// (set) Token: 0x060004F9 RID: 1273 RVA: 0x0000794F File Offset: 0x00005B4F
		public int RemainingSeconds { get; set; }

		// Token: 0x060004FA RID: 1274 RVA: 0x00007958 File Offset: 0x00005B58
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AvatarId);
			stream.WriteVInt(this.RemainingSeconds);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00007972 File Offset: 0x00005B72
		public override void Decode(ByteStream stream)
		{
			this.AvatarId = stream.ReadLong();
			this.RemainingSeconds = stream.ReadVInt();
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0000798C File Offset: 0x00005B8C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.DUEL_PROGRESS;
		}

		// Token: 0x0400020F RID: 527
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000210 RID: 528
		[CompilerGenerated]
		private int int_2;
	}
}
