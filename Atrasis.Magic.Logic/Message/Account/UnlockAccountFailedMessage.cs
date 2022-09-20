using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FB RID: 251
	public class UnlockAccountFailedMessage : PiranhaMessage
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x000086E8 File Offset: 0x000068E8
		public UnlockAccountFailedMessage() : this(0)
		{
		}

		// Token: 0x06000B7B RID: 2939 RVA: 0x0000328E File Offset: 0x0000148E
		public UnlockAccountFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B7C RID: 2940 RVA: 0x000086F1 File Offset: 0x000068F1
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (UnlockAccountFailedMessage.ErrorCode)this.m_stream.ReadInt();
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0000870A File Offset: 0x0000690A
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x00008723 File Offset: 0x00006923
		public override short GetMessageType()
		{
			return 20133;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B80 RID: 2944 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B81 RID: 2945 RVA: 0x0000872A File Offset: 0x0000692A
		public UnlockAccountFailedMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x06000B82 RID: 2946 RVA: 0x00008732 File Offset: 0x00006932
		public void SetErrorCode(UnlockAccountFailedMessage.ErrorCode errorCode)
		{
			this.errorCode_0 = errorCode;
		}

		// Token: 0x04000481 RID: 1153
		public const int MESSAGE_TYPE = 20133;

		// Token: 0x04000482 RID: 1154
		private UnlockAccountFailedMessage.ErrorCode errorCode_0;

		// Token: 0x020000FC RID: 252
		public enum ErrorCode
		{
			// Token: 0x04000484 RID: 1156
			UNLOCK_FAILED = 4,
			// Token: 0x04000485 RID: 1157
			UNLOCK_UNAVAILABLE,
			// Token: 0x04000486 RID: 1158
			SERVER_MAINTENANCE = 10
		}
	}
}
