using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A9 RID: 169
	public class AllianceLeavedMessage : ServerAccountMessage
	{
		// Token: 0x17000113 RID: 275
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x00007612 File Offset: 0x00005812
		// (set) Token: 0x0600049F RID: 1183 RVA: 0x0000761A File Offset: 0x0000581A
		public LogicLong AllianceId { get; set; }

		// Token: 0x060004A0 RID: 1184 RVA: 0x00007623 File Offset: 0x00005823
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AllianceId);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00007631 File Offset: 0x00005831
		public override void Decode(ByteStream stream)
		{
			this.AllianceId = stream.ReadLong();
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0000763F File Offset: 0x0000583F
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_LEAVED;
		}

		// Token: 0x040001F5 RID: 501
		[CompilerGenerated]
		private LogicLong logicLong_1;
	}
}
