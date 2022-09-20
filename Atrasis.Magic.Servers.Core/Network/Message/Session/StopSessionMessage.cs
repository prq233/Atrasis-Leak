using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000050 RID: 80
	public class StopSessionMessage : ServerSessionMessage
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000203 RID: 515 RVA: 0x000059DA File Offset: 0x00003BDA
		// (set) Token: 0x06000204 RID: 516 RVA: 0x000059E2 File Offset: 0x00003BE2
		public int Reason { get; set; }

		// Token: 0x06000205 RID: 517 RVA: 0x000059EB File Offset: 0x00003BEB
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Reason);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000059F9 File Offset: 0x00003BF9
		public override void Decode(ByteStream stream)
		{
			this.Reason = stream.ReadVInt();
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00005A07 File Offset: 0x00003C07
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SESSION;
		}

		// Token: 0x04000120 RID: 288
		[CompilerGenerated]
		private int int_2;
	}
}
