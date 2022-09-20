using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Core
{
	// Token: 0x020000A1 RID: 161
	public class ServerStatusMessage : ServerCoreMessage
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000072B5 File Offset: 0x000054B5
		// (set) Token: 0x06000457 RID: 1111 RVA: 0x000072BD File Offset: 0x000054BD
		public ServerStatusType Type { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x000072C6 File Offset: 0x000054C6
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x000072CE File Offset: 0x000054CE
		public int Time { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x000072D7 File Offset: 0x000054D7
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x000072DF File Offset: 0x000054DF
		public int NextTime { get; set; }

		// Token: 0x0600045C RID: 1116 RVA: 0x000072E8 File Offset: 0x000054E8
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt((int)this.Type);
			stream.WriteVInt(this.Time);
			stream.WriteVInt(this.NextTime);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000730E File Offset: 0x0000550E
		public override void Decode(ByteStream stream)
		{
			this.Type = (ServerStatusType)stream.ReadVInt();
			this.Time = stream.ReadVInt();
			this.NextTime = stream.ReadVInt();
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00007334 File Offset: 0x00005534
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_STATUS;
		}

		// Token: 0x040001E1 RID: 481
		[CompilerGenerated]
		private ServerStatusType serverStatusType_0;

		// Token: 0x040001E2 RID: 482
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040001E3 RID: 483
		[CompilerGenerated]
		private int int_3;
	}
}
