using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B0 RID: 176
	public class AllianceJoinFailedMessage : PiranhaMessage
	{
		// Token: 0x06000799 RID: 1945 RVA: 0x000065D9 File Offset: 0x000047D9
		public AllianceJoinFailedMessage() : this(0)
		{
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceJoinFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000065E2 File Offset: 0x000047E2
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceJoinFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000065FB File Offset: 0x000047FB
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00006614 File Offset: 0x00004814
		public override short GetMessageType()
		{
			return 24302;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0000661B File Offset: 0x0000481B
		public AllianceJoinFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00006623 File Offset: 0x00004823
		public void SetReason(AllianceJoinFailedMessage.Reason reason)
		{
			this.reason_0 = reason;
		}

		// Token: 0x040002EB RID: 747
		public const int MESSAGE_TYPE = 24302;

		// Token: 0x040002EC RID: 748
		private AllianceJoinFailedMessage.Reason reason_0;

		// Token: 0x020000B1 RID: 177
		public enum Reason
		{
			// Token: 0x040002EE RID: 750
			GENERIC,
			// Token: 0x040002EF RID: 751
			FULL,
			// Token: 0x040002F0 RID: 752
			CLOSED,
			// Token: 0x040002F1 RID: 753
			ALREADY_IN_ALLIANCE,
			// Token: 0x040002F2 RID: 754
			SCORE,
			// Token: 0x040002F3 RID: 755
			BANNED
		}
	}
}
