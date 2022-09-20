using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000030 RID: 48
	public class ForwardLogicRequestMessage : ServerSessionMessage
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000502F File Offset: 0x0000322F
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00005037 File Offset: 0x00003237
		public LogicLong AccountId { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00005040 File Offset: 0x00003240
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00005048 File Offset: 0x00003248
		public short MessageType { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00005051 File Offset: 0x00003251
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00005059 File Offset: 0x00003259
		public short MessageVersion { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00005062 File Offset: 0x00003262
		// (set) Token: 0x0600010F RID: 271 RVA: 0x0000506A File Offset: 0x0000326A
		public int MessageLength { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00005073 File Offset: 0x00003273
		// (set) Token: 0x06000111 RID: 273 RVA: 0x0000507B File Offset: 0x0000327B
		public byte[] MessageBytes { get; set; }

		// Token: 0x06000112 RID: 274 RVA: 0x0000B4E0 File Offset: 0x000096E0
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteShort(this.MessageType);
			stream.WriteShort(this.MessageVersion);
			stream.WriteVInt(this.MessageLength);
			stream.WriteBytesWithoutLength(this.MessageBytes, this.MessageLength);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000B530 File Offset: 0x00009730
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.MessageType = stream.ReadShort();
			this.MessageVersion = stream.ReadShort();
			this.MessageLength = stream.ReadVInt();
			this.MessageBytes = stream.ReadBytes(this.MessageLength, 16777215);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00005084 File Offset: 0x00003284
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.FORWARD_LOGIC_REQUEST_MESSAGE;
		}

		// Token: 0x040000D4 RID: 212
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000D5 RID: 213
		[CompilerGenerated]
		private short short_0;

		// Token: 0x040000D6 RID: 214
		[CompilerGenerated]
		private short short_1;

		// Token: 0x040000D7 RID: 215
		[CompilerGenerated]
		private int int_2;

		// Token: 0x040000D8 RID: 216
		[CompilerGenerated]
		private byte[] byte_0;
	}
}
