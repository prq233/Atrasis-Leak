using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AB RID: 171
	public class AllianceShareDuelReplayMessage : ServerAccountMessage
	{
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000076C4 File Offset: 0x000058C4
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x000076CC File Offset: 0x000058CC
		public LogicLong MemberId { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x000076D5 File Offset: 0x000058D5
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x000076DD File Offset: 0x000058DD
		public LogicLong ReplayId { get; set; }

		// Token: 0x060004BA RID: 1210 RVA: 0x000076E6 File Offset: 0x000058E6
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.ReplayId);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00007700 File Offset: 0x00005900
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.ReplayId = stream.ReadLong();
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0000771A File Offset: 0x0000591A
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_SHARE_DUEL_REPLAY;
		}

		// Token: 0x040001FD RID: 509
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001FE RID: 510
		[CompilerGenerated]
		private LogicLong logicLong_2;
	}
}
