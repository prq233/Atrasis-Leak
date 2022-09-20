using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000BF RID: 191
	public class ServerUpdateLiveReplayMessage : ServerAccountMessage
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x00007C64 File Offset: 0x00005E64
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x00007C6C File Offset: 0x00005E6C
		public int Milliseconds { get; set; }

		// Token: 0x06000558 RID: 1368 RVA: 0x00007C75 File Offset: 0x00005E75
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.Milliseconds);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00007C83 File Offset: 0x00005E83
		public override void Decode(ByteStream stream)
		{
			this.Milliseconds = stream.ReadVInt();
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00007C91 File Offset: 0x00005E91
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.SERVER_UPDATE_LIVE_REPLAY;
		}

		// Token: 0x04000225 RID: 549
		[CompilerGenerated]
		private int int_2;
	}
}
