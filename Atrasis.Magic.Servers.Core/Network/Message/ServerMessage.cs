using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message
{
	// Token: 0x02000027 RID: 39
	public abstract class ServerMessage
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00004E45 File Offset: 0x00003045
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00004E4D File Offset: 0x0000304D
		public int SenderType { get; internal set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00004E56 File Offset: 0x00003056
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00004E5E File Offset: 0x0000305E
		public int SenderId { get; internal set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00004E67 File Offset: 0x00003067
		public ServerSocket Sender
		{
			get
			{
				return ServerManager.GetSocket(this.SenderType, this.SenderId);
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004E7A File Offset: 0x0000307A
		public virtual void EncodeHeader(ByteStream stream)
		{
			stream.WriteVInt(this.SenderType);
			stream.WriteVInt(this.SenderId);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00004E94 File Offset: 0x00003094
		public virtual void DecodeHeader(ByteStream stream)
		{
			this.SenderType = stream.ReadVInt();
			this.SenderId = stream.ReadVInt();
		}

		// Token: 0x060000E0 RID: 224
		public abstract void Encode(ByteStream stream);

		// Token: 0x060000E1 RID: 225
		public abstract void Decode(ByteStream stream);

		// Token: 0x060000E2 RID: 226
		public abstract ServerMessageCategory GetMessageCategory();

		// Token: 0x060000E3 RID: 227
		public abstract ServerMessageType GetMessageType();

		// Token: 0x0400005C RID: 92
		[CompilerGenerated]
		private int int_0;

		// Token: 0x0400005D RID: 93
		[CompilerGenerated]
		private int int_1;
	}
}
