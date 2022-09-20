using System;
using System.Runtime.CompilerServices;
using Atrasis.Magic.Titan.DataStream;
using Atrasis.Magic.Titan.Math;

namespace Atrasis.Magic.Servers.Core.Network.Message.Request
{
	// Token: 0x02000075 RID: 117
	public class CreateAllianceResponseMessage : ServerResponseMessage
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000350 RID: 848 RVA: 0x000067A5 File Offset: 0x000049A5
		// (set) Token: 0x06000351 RID: 849 RVA: 0x000067AD File Offset: 0x000049AD
		public LogicLong AllianceId { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000352 RID: 850 RVA: 0x000067B6 File Offset: 0x000049B6
		// (set) Token: 0x06000353 RID: 851 RVA: 0x000067BE File Offset: 0x000049BE
		public CreateAllianceResponseMessage.Reason ErrorReason { get; set; }

		// Token: 0x06000354 RID: 852 RVA: 0x000067C7 File Offset: 0x000049C7
		public override void Encode(ByteStream stream)
		{
			if (base.Success)
			{
				stream.WriteLong(this.AllianceId);
				return;
			}
			stream.WriteVInt((int)this.ErrorReason);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000067EA File Offset: 0x000049EA
		public override void Decode(ByteStream stream)
		{
			if (base.Success)
			{
				this.AllianceId = stream.ReadLong();
				return;
			}
			this.ErrorReason = (CreateAllianceResponseMessage.Reason)stream.ReadVInt();
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000680D File Offset: 0x00004A0D
		public override ServerMessageType GetMessageType()
		{
			return ServerMessageType.CREATE_ALLIANCE_RESPONSE;
		}

		// Token: 0x04000187 RID: 391
		[CompilerGenerated]
		private LogicLong logicLong_0;

		// Token: 0x04000188 RID: 392
		[CompilerGenerated]
		private CreateAllianceResponseMessage.Reason reason_0;

		// Token: 0x02000076 RID: 118
		public enum Reason
		{
			// Token: 0x0400018A RID: 394
			GENERIC,
			// Token: 0x0400018B RID: 395
			INVALID_NAME,
			// Token: 0x0400018C RID: 396
			INVALID_DESCRIPTION,
			// Token: 0x0400018D RID: 397
			NAME_TOO_SHORT,
			// Token: 0x0400018E RID: 398
			NAME_TOO_LONG
		}
	}
}
