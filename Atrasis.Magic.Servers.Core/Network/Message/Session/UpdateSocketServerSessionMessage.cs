using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000052 RID: 82
	public class UpdateSocketServerSessionMessage : ServerSessionMessage
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000211 RID: 529 RVA: 0x00005A6B File Offset: 0x00003C6B
		// (set) Token: 0x06000212 RID: 530 RVA: 0x00005A73 File Offset: 0x00003C73
		public int ServerType { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00005A7C File Offset: 0x00003C7C
		// (set) Token: 0x06000214 RID: 532 RVA: 0x00005A84 File Offset: 0x00003C84
		public int ServerId { get; set; }

		// Token: 0x06000215 RID: 533 RVA: 0x00005A8D File Offset: 0x00003C8D
		public override void Encode(ByteStream stream)
		{
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00005AA7 File Offset: 0x00003CA7
		public override void Decode(ByteStream stream)
		{
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00005AC1 File Offset: 0x00003CC1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.UPDATE_SOCKET_SERVER_SESSION;
		}

		// Token: 0x04000123 RID: 291
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000124 RID: 292
		[CompilerGenerated]
		private int int_3;
	}
}
