using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000054 RID: 84
	public class LiveReplayFailedMessage : PiranhaMessage
	{
		// Token: 0x060003C6 RID: 966 RVA: 0x0000441A File Offset: 0x0000261A
		public LiveReplayFailedMessage() : this(0)
		{
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000328E File Offset: 0x0000148E
		public LiveReplayFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004423 File Offset: 0x00002623
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (LiveReplayFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000443C File Offset: 0x0000263C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00004455 File Offset: 0x00002655
		public override short GetMessageType()
		{
			return 24117;
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000445C File Offset: 0x0000265C
		public LiveReplayFailedMessage.Reason GetReason()
		{
			return this.reason_0;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00004464 File Offset: 0x00002664
		public void SetReason(LiveReplayFailedMessage.Reason value)
		{
			this.reason_0 = value;
		}

		// Token: 0x04000175 RID: 373
		public const int MESSAGE_TYPE = 24117;

		// Token: 0x04000176 RID: 374
		private LiveReplayFailedMessage.Reason reason_0;

		// Token: 0x02000055 RID: 85
		public enum Reason
		{
			// Token: 0x04000178 RID: 376
			GENERIC,
			// Token: 0x04000179 RID: 377
			NO_DATA_FOUND,
			// Token: 0x0400017A RID: 378
			NO_FREE_SLOTS
		}
	}
}
