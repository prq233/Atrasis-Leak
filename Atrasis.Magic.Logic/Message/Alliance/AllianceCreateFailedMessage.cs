using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000A6 RID: 166
	public class AllianceCreateFailedMessage : PiranhaMessage
	{
		// Token: 0x0600073F RID: 1855 RVA: 0x00006311 File Offset: 0x00004511
		public AllianceCreateFailedMessage() : this(0)
		{
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceCreateFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0000631A File Offset: 0x0000451A
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceCreateFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00006333 File Offset: 0x00004533
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0000634C File Offset: 0x0000454C
		public override short GetMessageType()
		{
			return 24332;
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00006353 File Offset: 0x00004553
		public AllianceCreateFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x0000635B File Offset: 0x0000455B
		public void SetReason(AllianceCreateFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x040002B6 RID: 694
		public const int MESSAGE_TYPE = 24332;

		// Token: 0x040002B7 RID: 695
		private AllianceCreateFailedMessage.Reason reason_0;

		// Token: 0x020000A7 RID: 167
		public enum Reason
		{
			// Token: 0x040002B9 RID: 697
			GENERIC,
			// Token: 0x040002BA RID: 698
			INVALID_NAME,
			// Token: 0x040002BB RID: 699
			INVALID_DESCRIPTION,
			// Token: 0x040002BC RID: 700
			NAME_TOO_SHORT,
			// Token: 0x040002BD RID: 701
			NAME_TOO_LONG
		}
	}
}
