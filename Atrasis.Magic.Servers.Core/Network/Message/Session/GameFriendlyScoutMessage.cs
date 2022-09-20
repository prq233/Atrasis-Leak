using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Session
{
	// Token: 0x02000034 RID: 52
	public class GameFriendlyScoutMessage : ServerSessionMessage
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600012A RID: 298 RVA: 0x0000516B File Offset: 0x0000336B
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00005173 File Offset: 0x00003373
		public LogicLong AccountId { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600012C RID: 300 RVA: 0x0000517C File Offset: 0x0000337C
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00005184 File Offset: 0x00003384
		public LogicLong StreamId { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000518D File Offset: 0x0000338D
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00005195 File Offset: 0x00003395
		public byte[] HomeJSON { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000519E File Offset: 0x0000339E
		// (set) Token: 0x06000131 RID: 305 RVA: 0x000051A6 File Offset: 0x000033A6
		public int MapId { get; set; }

		// Token: 0x06000132 RID: 306 RVA: 0x000051AF File Offset: 0x000033AF
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.AccountId);
			stream.WriteLong(this.StreamId);
			stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
			stream.WriteVInt(this.MapId);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000051E9 File Offset: 0x000033E9
		public override void Decode(ByteStream stream)
		{
			this.AccountId = stream.ReadLong();
			this.StreamId = stream.ReadLong();
			this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.MapId = stream.ReadVInt();
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005226 File Offset: 0x00003426
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.GAME_FRIENDLY_SCOUT;
		}

		// Token: 0x040000DD RID: 221
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x040000DE RID: 222
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040000DF RID: 223
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040000E0 RID: 224
		[CompilerGenerated]
		private int int_2;
	}
}
