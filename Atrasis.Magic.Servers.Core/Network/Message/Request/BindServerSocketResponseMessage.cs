using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000073 RID: 115
	public class BindServerSocketResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00006687 File Offset: 0x00004887
		// (set) Token: 0x06000331 RID: 817 RVA: 0x0000668F File Offset: 0x0000488F
		public int ServerType { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00006698 File Offset: 0x00004898
		// (set) Token: 0x06000333 RID: 819 RVA: 0x000066A0 File Offset: 0x000048A0
		public int ServerId { get; set; }

		// Token: 0x06000334 RID: 820 RVA: 0x000066A9 File Offset: 0x000048A9
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteVInt(this.ServerType);
				stream.WriteVInt(this.ServerId);
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x000066CB File Offset: 0x000048CB
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.ServerType = stream.ReadVInt();
				this.ServerId = stream.ReadVInt();
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000066ED File Offset: 0x000048ED
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.BIND_SERVER_SOCKET_RESPONSE;
		}

		// Token: 0x0400017B RID: 379
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400017C RID: 380
		[CompilerGenerated]
		private int int_3;
	}
}
