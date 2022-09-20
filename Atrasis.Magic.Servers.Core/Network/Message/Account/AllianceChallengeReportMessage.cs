using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A4 RID: 164
	public class AllianceChallengeReportMessage : ServerAccountMessage
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x00007398 File Offset: 0x00005598
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x000073A0 File Offset: 0x000055A0
		public LogicLong StreamId { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x000073A9 File Offset: 0x000055A9
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x000073B1 File Offset: 0x000055B1
		public LogicLong ReplayId { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x000073BA File Offset: 0x000055BA
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x000073C2 File Offset: 0x000055C2
		public string BattleLog { get; set; }

		// Token: 0x06000474 RID: 1140 RVA: 0x000073CB File Offset: 0x000055CB
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.StreamId);
			if (this.ReplayId != null)
			{
				stream.WriteBoolean(true);
				stream.WriteLong(this.ReplayId);
			}
			else
			{
				stream.WriteBoolean(false);
			}
			stream.WriteString(this.BattleLog);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00007409 File Offset: 0x00005609
		public override void Decode(ByteStream stream)
		{
			this.StreamId = stream.ReadLong();
			if (stream.ReadBoolean())
			{
				this.ReplayId = stream.ReadLong();
			}
			this.BattleLog = stream.ReadString(900000);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000743C File Offset: 0x0000563C
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_REPORT;
		}

		// Token: 0x040001E7 RID: 487
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001E8 RID: 488
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x040001E9 RID: 489
		[CompilerGenerated]
		private string string_0;
	}
}
