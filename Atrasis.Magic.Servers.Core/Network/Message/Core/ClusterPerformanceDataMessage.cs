using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x02000097 RID: 151
	public class ClusterPerformanceDataMessage : ServerCoreMessage
	{
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x00007076 File Offset: 0x00005276
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000707E File Offset: 0x0000527E
		public int Id { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00007087 File Offset: 0x00005287
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x0000708F File Offset: 0x0000528F
		public int SessionCount { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600041E RID: 1054 RVA: 0x00007098 File Offset: 0x00005298
		// (set) Token: 0x0600041F RID: 1055 RVA: 0x000070A0 File Offset: 0x000052A0
		public int Ping { get; set; }

		// Token: 0x06000420 RID: 1056 RVA: 0x000070A9 File Offset: 0x000052A9
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Id);
			stream.WriteVInt(this.SessionCount);
			stream.WriteVInt(this.Ping);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000070CF File Offset: 0x000052CF
		public override void Decode(ByteStream stream)
		{
			this.Id = stream.ReadVInt();
			this.SessionCount = stream.ReadVInt();
			this.Ping = stream.ReadVInt();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000070F5 File Offset: 0x000052F5
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CLUSTER_PERFORMANCE_DATA;
		}

		// Token: 0x040001D6 RID: 470
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001D7 RID: 471
		[CompilerGenerated]
		private int int_3;

		// Token: 0x040001D8 RID: 472
		[CompilerGenerated]
		private int int_4;
	}
}
