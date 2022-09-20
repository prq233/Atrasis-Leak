using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Servers.Core.Network.Message.Session;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000072 RID: 114
	public class BindServerSocketRequestMessage : ServerRequestMessage
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000663C File Offset: 0x0000483C
		// (set) Token: 0x06000325 RID: 805 RVA: 0x00006644 File Offset: 0x00004844
		public long SessionId { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000664D File Offset: 0x0000484D
		// (set) Token: 0x06000327 RID: 807 RVA: 0x00006655 File Offset: 0x00004855
		public int ServerType { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000665E File Offset: 0x0000485E
		// (set) Token: 0x06000329 RID: 809 RVA: 0x00006666 File Offset: 0x00004866
		public int ServerId { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000666F File Offset: 0x0000486F
		// (set) Token: 0x0600032B RID: 811 RVA: 0x00006677 File Offset: 0x00004877
		public ServerSessionMessage InitSessionMessage { get; set; }

		// Token: 0x0600032C RID: 812 RVA: 0x0000C040 File Offset: 0x0000A240
		public override void Encode(ByteStream stream)
		{
			stream.WriteLongLong(this.SessionId);
			stream.WriteVInt(this.ServerType);
			stream.WriteVInt(this.ServerId);
			stream.WriteBoolean(this.InitSessionMessage != null);
			if (this.InitSessionMessage != null)
			{
				stream.WriteBoolean(true);
				stream.WriteShort((short)this.InitSessionMessage.GetMessageType());
				this.InitSessionMessage.EncodeHeader(stream);
				this.InitSessionMessage.Encode(stream);
				return;
			}
			stream.WriteBoolean(false);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000C0C0 File Offset: 0x0000A2C0
		public override void Decode(ByteStream stream)
		{
			this.SessionId = stream.ReadLongLong();
			this.ServerType = stream.ReadVInt();
			this.ServerId = stream.ReadVInt();
			if (stream.ReadBoolean())
			{
				this.InitSessionMessage = (ServerSessionMessage)ServerMessageFactory.CreateMessageByType((ServerMessageType)stream.ReadShort());
				this.InitSessionMessage.DecodeHeader(stream);
				this.InitSessionMessage.Decode(stream);
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00006680 File Offset: 0x00004880
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.BIND_SERVER_SOCKET_REQUEST;
		}

		// Token: 0x04000177 RID: 375
		[CompilerGenerated]
		private long long_1;

		// Token: 0x04000178 RID: 376
		[CompilerGenerated]
		private int int_2;

		// Token: 0x04000179 RID: 377
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400017A RID: 378
		[CompilerGenerated]
		private ServerSessionMessage serverSessionMessage_0;
	}
}
