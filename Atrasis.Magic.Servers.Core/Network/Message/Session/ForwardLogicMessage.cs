using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x0200002F RID: 47
	public class ForwardLogicMessage : ServerSessionMessage
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00004F67 File Offset: 0x00003167
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00004F6F File Offset: 0x0000316F
		public short MessageType { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00004F78 File Offset: 0x00003178
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00004F80 File Offset: 0x00003180
		public short MessageVersion { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00004F89 File Offset: 0x00003189
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00004F91 File Offset: 0x00003191
		public int MessageLength { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00004F9A File Offset: 0x0000319A
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00004FA2 File Offset: 0x000031A2
		public byte[] MessageBytes { get; set; }

		// Token: 0x06000104 RID: 260 RVA: 0x00004FAB File Offset: 0x000031AB
		public override void Encode(ByteStream stream)
		{
			stream.WriteShort(this.MessageType);
			stream.WriteShort(this.MessageVersion);
			stream.WriteVInt(this.MessageLength);
			stream.WriteBytesWithoutLength(this.MessageBytes, this.MessageLength);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004FE3 File Offset: 0x000031E3
		public override void Decode(ByteStream stream)
		{
			this.MessageType = stream.ReadShort();
			this.MessageVersion = stream.ReadShort();
			this.MessageLength = stream.ReadVInt();
			this.MessageBytes = stream.ReadBytes(this.MessageLength, 16777215);
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005020 File Offset: 0x00003220
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.FORWARD_LOGIC_MESSAGE;
		}

		// Token: 0x040000D0 RID: 208
		[CompilerGenerated]
		private short short_0;

		// Token: 0x040000D1 RID: 209
		[CompilerGenerated]
		private short short_1;

		// Token: 0x040000D2 RID: 210
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000D3 RID: 211
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
