using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000081 RID: 129
	public class AvatarNameChangeFailedMessage : PiranhaMessage
	{
		// Token: 0x06000597 RID: 1431 RVA: 0x000053C4 File Offset: 0x000035C4
		public AvatarNameChangeFailedMessage() : this(0)
		{
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarNameChangeFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x000053CD File Offset: 0x000035CD
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (AvatarNameChangeFailedMessage.ErrorCode)this.m_stream.ReadInt();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x000053E6 File Offset: 0x000035E6
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x000053FF File Offset: 0x000035FF
		public override short GetMessageType()
		{
			return 20205;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00005406 File Offset: 0x00003606
		public AvatarNameChangeFailedMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x0000540E File Offset: 0x0000360E
		public void SetErrorCode(AvatarNameChangeFailedMessage.ErrorCode errorCode)
		{
			this.errorCode_0 = errorCode;
		}

		// Token: 0x04000214 RID: 532
		public const int MESSAGE_TYPE = 20205;

		// Token: 0x04000215 RID: 533
		private AvatarNameChangeFailedMessage.ErrorCode errorCode_0;

		// Token: 0x02000082 RID: 130
		public enum ErrorCode
		{
			// Token: 0x04000217 RID: 535
			TOO_LONG = 1,
			// Token: 0x04000218 RID: 536
			TOO_SHORT,
			// Token: 0x04000219 RID: 537
			BAD_WORD,
			// Token: 0x0400021A RID: 538
			ALREADY_CHANGED,
			// Token: 0x0400021B RID: 539
			TH_LEVEL_TOO_LOW
		}
	}
}
