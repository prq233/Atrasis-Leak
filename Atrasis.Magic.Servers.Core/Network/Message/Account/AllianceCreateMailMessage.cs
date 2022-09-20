using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A7 RID: 167
	public class AllianceCreateMailMessage : ServerAccountMessage
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x00007525 File Offset: 0x00005725
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x0000752D File Offset: 0x0000572D
		public LogicLong MemberId { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00007536 File Offset: 0x00005736
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x0000753E File Offset: 0x0000573E
		public string Message { get; set; }

		// Token: 0x06000490 RID: 1168 RVA: 0x00007547 File Offset: 0x00005747
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00007561 File Offset: 0x00005761
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00007580 File Offset: 0x00005780
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CREATE_MAIL;
		}

		// Token: 0x040001F0 RID: 496
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001F1 RID: 497
		[CompilerGenerated]
		private string string_0;
	}
}
