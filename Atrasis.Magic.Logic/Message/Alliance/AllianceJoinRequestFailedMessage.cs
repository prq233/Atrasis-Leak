using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B2 RID: 178
	public class AllianceJoinRequestFailedMessage : PiranhaMessage
	{
		// Token: 0x060007A2 RID: 1954 RVA: 0x0000662C File Offset: 0x0000482C
		public AllianceJoinRequestFailedMessage() : this(0)
		{
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceJoinRequestFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00006635 File Offset: 0x00004835
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceJoinRequestFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0000664E File Offset: 0x0000484E
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00006667 File Offset: 0x00004867
		public override short GetMessageType()
		{
			return 24320;
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0000666E File Offset: 0x0000486E
		public AllianceJoinRequestFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00006676 File Offset: 0x00004876
		public void SetReason(AllianceJoinRequestFailedMessage.Reason reason)
		{
			this.reason_0 = reason;
		}

		// Token: 0x040002F4 RID: 756
		public const int MESSAGE_TYPE = 24320;

		// Token: 0x040002F5 RID: 757
		private AllianceJoinRequestFailedMessage.Reason reason_0;

		// Token: 0x020000B3 RID: 179
		public enum Reason
		{
			// Token: 0x040002F7 RID: 759
			GENERIC,
			// Token: 0x040002F8 RID: 760
			CLOSED,
			// Token: 0x040002F9 RID: 761
			ALREADY_SENT,
			// Token: 0x040002FA RID: 762
			NO_SCORE,
			// Token: 0x040002FB RID: 763
			BANNED,
			// Token: 0x040002FC RID: 764
			TOO_MANY_PENDING_REQUESTS,
			// Token: 0x040002FD RID: 765
			NO_DUEL_SCORE
		}
	}
}
