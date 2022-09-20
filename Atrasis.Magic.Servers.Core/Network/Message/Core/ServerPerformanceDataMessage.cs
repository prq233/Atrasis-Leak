using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x0200009F RID: 159
	public class ServerPerformanceDataMessage : ServerCoreMessage
	{
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600044A RID: 1098 RVA: 0x00007251 File Offset: 0x00005451
		// (set) Token: 0x0600044B RID: 1099 RVA: 0x00007259 File Offset: 0x00005459
		public int SessionCount { get; set; }

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00007262 File Offset: 0x00005462
		// (set) Token: 0x0600044D RID: 1101 RVA: 0x0000726A File Offset: 0x0000546A
		public int ClusterCount { get; set; }

		// Token: 0x0600044E RID: 1102 RVA: 0x00007273 File Offset: 0x00005473
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.ClusterCount);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0000728D File Offset: 0x0000548D
		public override void Decode(ByteStream stream)
		{
			this.SessionCount = stream.ReadVInt();
			this.ClusterCount = stream.ReadVInt();
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x000072A7 File Offset: 0x000054A7
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_PERFORMANCE_DATA;
		}

		// Token: 0x040001DF RID: 479
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001E0 RID: 480
		[CompilerGenerated]
		private int int_3;
	}
}
