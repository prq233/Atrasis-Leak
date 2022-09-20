using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x0200006E RID: 110
	public class AllianceJoinResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00006544 File Offset: 0x00004744
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0000654C File Offset: 0x0000474C
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00006555 File Offset: 0x00004755
		// (set) Token: 0x0600030B RID: 779 RVA: 0x0000655D File Offset: 0x0000475D
		public string AllianceName { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00006566 File Offset: 0x00004766
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0000656E File Offset: 0x0000476E
		public int AllianceLevel { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00006577 File Offset: 0x00004777
		// (set) Token: 0x0600030F RID: 783 RVA: 0x0000657F File Offset: 0x0000477F
		public int AllianceBadgeId { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000310 RID: 784 RVA: 0x00006588 File Offset: 0x00004788
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00006590 File Offset: 0x00004790
		public bool Created { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000312 RID: 786 RVA: 0x00006599 File Offset: 0x00004799
		// (set) Token: 0x06000313 RID: 787 RVA: 0x000065A1 File Offset: 0x000047A1
		public AllianceJoinResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x06000314 RID: 788 RVA: 0x0000BF7C File Offset: 0x0000A17C
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.AllianceId);
				stream.WriteString(this.AllianceName);
				stream.WriteVInt(this.AllianceLevel);
				stream.WriteVInt(this.AllianceBadgeId);
				stream.WriteBoolean(this.Created);
				return;
			}
			stream.WriteVInt((int)this.ErrorReason);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000BFDC File Offset: 0x0000A1DC
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.AllianceId = stream.ReadLong();
				this.AllianceName = stream.ReadString(900000);
				this.AllianceLevel = stream.ReadVInt();
				this.AllianceBadgeId = stream.ReadVInt();
				this.Created = stream.ReadBoolean();
				return;
			}
			this.ErrorReason = (AllianceJoinResponseMessage.Reason)stream.ReadVInt();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x000065AA File Offset: 0x000047AA
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.ALLIANCE_JOIN_RESPONSE;
		}

		// Token: 0x04000169 RID: 361
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x0400016A RID: 362
		[CompilerGenerated]
		private string string_0;

		// Token: 0x0400016B RID: 363
		[CompilerGenerated]
		private int int_2;

		// Token: 0x0400016C RID: 364
		[CompilerGenerated]
		private int int_3;

		// Token: 0x0400016D RID: 365
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x0400016E RID: 366
		[CompilerGenerated]
		private AllianceJoinResponseMessage.Reason reason_0;

		// Token: 0x0200006F RID: 111
		public enum Reason
		{
			// Token: 0x04000170 RID: 368
			GENERIC,
			// Token: 0x04000171 RID: 369
			FULL,
			// Token: 0x04000172 RID: 370
			CLOSED,
			// Token: 0x04000173 RID: 371
			SCORE,
			// Token: 0x04000174 RID: 372
			BANNED
		}
	}
}
