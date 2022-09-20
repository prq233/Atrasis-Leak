using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000047 RID: 71
	public class ChallengeFailedMessage : PiranhaMessage
	{
		// Token: 0x06000340 RID: 832 RVA: 0x00003FAA File Offset: 0x000021AA
		public ChallengeFailedMessage() : this(0)
		{
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000328E File Offset: 0x0000148E
		public ChallengeFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00003FB3 File Offset: 0x000021B3
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (ChallengeFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00003FCC File Offset: 0x000021CC
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00003FE5 File Offset: 0x000021E5
		public override short GetMessageType()
		{
			return 24121;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00003FEC File Offset: 0x000021EC
		public ChallengeFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00003FF4 File Offset: 0x000021F4
		public void SetReason(ChallengeFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x04000144 RID: 324
		public const int MESSAGE_TYPE = 24121;

		// Token: 0x04000145 RID: 325
		private ChallengeFailedMessage.Reason reason_0;

		// Token: 0x02000048 RID: 72
		public enum Reason
		{
			// Token: 0x04000147 RID: 327
			GENERIC,
			// Token: 0x04000148 RID: 328
			ALREADY_CLOSED = 3,
			// Token: 0x04000149 RID: 329
			PERSONAL_BREAK_ATTACK_DISABLED = 5
		}
	}
}
