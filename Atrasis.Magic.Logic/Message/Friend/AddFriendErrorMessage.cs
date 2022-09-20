using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000068 RID: 104
	public class AddFriendErrorMessage : PiranhaMessage
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x00004BB9 File Offset: 0x00002DB9
		public AddFriendErrorMessage() : this(0)
		{
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0000328E File Offset: 0x0000148E
		public AddFriendErrorMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00004BC2 File Offset: 0x00002DC2
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (AddFriendErrorMessage.ErrorCode)this.m_stream.ReadInt();
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00004BDB File Offset: 0x00002DDB
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public override short GetMessageType()
		{
			return 20112;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00004BFB File Offset: 0x00002DFB
		public AddFriendErrorMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00004C03 File Offset: 0x00002E03
		public void SetErrorCode(AddFriendErrorMessage.ErrorCode value)
		{
			this.errorCode_0 = value;
		}

		// Token: 0x040001BE RID: 446
		public const int MESSAGE_TYPE = 20112;

		// Token: 0x040001BF RID: 447
		private AddFriendErrorMessage.ErrorCode errorCode_0;

		// Token: 0x02000069 RID: 105
		public enum ErrorCode
		{
			// Token: 0x040001C1 RID: 449
			GENERIC,
			// Token: 0x040001C2 RID: 450
			TOO_MANY_REQUESTS_YOU,
			// Token: 0x040001C3 RID: 451
			TOO_MANY_REQUESTS_OTHER,
			// Token: 0x040001C4 RID: 452
			OWN_AVATAR = 4,
			// Token: 0x040001C5 RID: 453
			DOES_NOT_EXIST,
			// Token: 0x040001C6 RID: 454
			TOO_MANY_FRIENDS_YOU = 7,
			// Token: 0x040001C7 RID: 455
			TOO_MANY_FRIENDS_OTHERS
		}
	}
}
