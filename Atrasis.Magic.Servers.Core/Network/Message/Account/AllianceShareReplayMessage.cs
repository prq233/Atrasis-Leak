using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000AC RID: 172
	public class AllianceShareReplayMessage : ServerAccountMessage
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00007721 File Offset: 0x00005921
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00007729 File Offset: 0x00005929
		public LogicLong MemberId { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00007732 File Offset: 0x00005932
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x0000773A File Offset: 0x0000593A
		public LogicLong ReplayId { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00007743 File Offset: 0x00005943
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0000774B File Offset: 0x0000594B
		public string Message { get; set; }

		// Token: 0x060004C4 RID: 1220 RVA: 0x00007754 File Offset: 0x00005954
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteLong(this.ReplayId);
			stream.WriteString(this.Message);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000777A File Offset: 0x0000597A
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.ReplayId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000077A5 File Offset: 0x000059A5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_SHARE_REPLAY;
		}

		// Token: 0x040001FF RID: 511
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x04000200 RID: 512
		[CompilerGenerated]
		private LogicLong logicLong_2;

		// Token: 0x04000201 RID: 513
		[CompilerGenerated]
		private string string_0;
	}
}
