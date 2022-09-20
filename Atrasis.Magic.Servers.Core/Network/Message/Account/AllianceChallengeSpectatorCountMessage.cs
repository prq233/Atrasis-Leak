using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Account
{
	// Token: 0x020000A6 RID: 166
	public class AllianceChallengeSpectatorCountMessage : ServerAccountMessage
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x000074C8 File Offset: 0x000056C8
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x000074D0 File Offset: 0x000056D0
		public LogicLong StreamId { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x000074D9 File Offset: 0x000056D9
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x000074E1 File Offset: 0x000056E1
		public int Count { get; set; }

		// Token: 0x06000488 RID: 1160 RVA: 0x000074EA File Offset: 0x000056EA
		public override void Encode(ByteStream stream)
		{
			stream.WriteLong(this.StreamId);
			stream.WriteVInt(this.Count);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00007504 File Offset: 0x00005704
		public override void Decode(ByteStream stream)
		{
			this.StreamId = stream.ReadLong();
			this.Count = stream.ReadVInt();
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000751E File Offset: 0x0000571E
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_CHALLENGE_SPECTATOR_COUNT;
		}

		// Token: 0x040001EE RID: 494
		[CompilerGenerated]
		private LogicLong logicLong_1;

		// Token: 0x040001EF RID: 495
		[CompilerGenerated]
		private int int_2;
	}
}
