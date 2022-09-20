using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000051 RID: 81
	public class StopSpecifiedServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00005A0E File Offset: 0x00003C0E
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00005A16 File Offset: 0x00003C16
		public int ServerType { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00005A1F File Offset: 0x00003C1F
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00005A27 File Offset: 0x00003C27
		public int ServerId { get; set; }

		// Token: 0x0600020D RID: 525 RVA: 0x00005A30 File Offset: 0x00003C30
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00005A4A File Offset: 0x00003C4A
		public override void Decode(ByteStream stream)
		{
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00005A64 File Offset: 0x00003C64
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.STOP_SPECIFIED_SERVER_SESSION;
		}

		// Token: 0x04000121 RID: 289
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000122 RID: 290
		[CompilerGenerated]
		private int int_3;
	}
}
