using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A5 RID: 165
	public class AllianceChallengeRequestMessage : ServerAccountMessage
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00007443 File Offset: 0x00005643
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x0000744B File Offset: 0x0000564B
		public LogicLong MemberId { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00007454 File Offset: 0x00005654
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x0000745C File Offset: 0x0000565C
		public string Message { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00007465 File Offset: 0x00005665
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x0000746D File Offset: 0x0000566D
		public byte[] HomeJSON { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00007476 File Offset: 0x00005676
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x0000747E File Offset: 0x0000567E
		public bool WarLayout { get; set; }

		// Token: 0x06000480 RID: 1152 RVA: 0x00007487 File Offset: 0x00005687
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.MemberId);
			stream.WriteString(this.Message);
			stream.WriteBytes(this.HomeJSON, this.HomeJSON.Length);
			stream.WriteBoolean(this.WarLayout);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000C5B8 File Offset: 0x0000A7B8
		public override void Decode(ByteStream stream)
		{
			this.MemberId = stream.ReadLong();
			this.Message = stream.ReadString(900000);
			this.HomeJSON = stream.ReadBytes(stream.ReadBytesLength(), 900000);
			this.WarLayout = stream.ReadBoolean();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000074C1 File Offset: 0x000056C1
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_REQUEST;
		}

		// Token: 0x040001EA RID: 490
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001EB RID: 491
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040001EC RID: 492
		[CompilerGenerated]
		private byte[] byte_0;

		// Token: 0x040001ED RID: 493
		[CompilerGenerated]
		private bool bool_0;
	}
}
