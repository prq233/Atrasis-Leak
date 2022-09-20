using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000AD RID: 173
	public class AllianceInvitationSendFailedMessage : PiranhaMessage
	{
		// Token: 0x06000789 RID: 1929 RVA: 0x00006576 File Offset: 0x00004776
		public AllianceInvitationSendFailedMessage() : this(0)
		{
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceInvitationSendFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0000657F File Offset: 0x0000477F
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (AllianceInvitationSendFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x00006598 File Offset: 0x00004798
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000065B1 File Offset: 0x000047B1
		public override short GetMessageType()
		{
			return 24321;
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x000065B8 File Offset: 0x000047B8
		public AllianceInvitationSendFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000065C0 File Offset: 0x000047C0
		public void SetReason(AllianceInvitationSendFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x040002E0 RID: 736
		public const int MESSAGE_TYPE = 24321;

		// Token: 0x040002E1 RID: 737
		private AllianceInvitationSendFailedMessage.Reason reason_0;

		// Token: 0x020000AE RID: 174
		public enum Reason
		{
			// Token: 0x040002E3 RID: 739
			GENERIC = 1,
			// Token: 0x040002E4 RID: 740
			NO_RIGHTS,
			// Token: 0x040002E5 RID: 741
			NO_CASTLE,
			// Token: 0x040002E6 RID: 742
			ALREADY_IN_ALLIANCE,
			// Token: 0x040002E7 RID: 743
			ALREADY_HAS_AN_INVITE,
			// Token: 0x040002E8 RID: 744
			HAS_TOO_MANY_INVITES,
			// Token: 0x040002E9 RID: 745
			USER_BANNED
		}
	}
}
