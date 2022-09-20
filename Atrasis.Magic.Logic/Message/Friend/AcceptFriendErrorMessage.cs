﻿using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x02000065 RID: 101
	public class AcceptFriendErrorMessage : PiranhaMessage
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x00004B35 File Offset: 0x00002D35
		public AcceptFriendErrorMessage() : this(0)
		{
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000328E File Offset: 0x0000148E
		public AcceptFriendErrorMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00004B3E File Offset: 0x00002D3E
		public override void Decode()
		{
			base.Decode();
			this.errorCode_0 = (AcceptFriendErrorMessage.ErrorCode)this.m_stream.ReadInt();
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00004B57 File Offset: 0x00002D57
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.errorCode_0);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00004B70 File Offset: 0x00002D70
		public override short GetMessageType()
		{
			return 20501;
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00004B77 File Offset: 0x00002D77
		public AcceptFriendErrorMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00004B7F File Offset: 0x00002D7F
		public void SetErrorCode(AcceptFriendErrorMessage.ErrorCode value)
		{
			this.errorCode_0 = value;
		}

		// Token: 0x040001B7 RID: 439
		public const int MESSAGE_TYPE = 20501;

		// Token: 0x040001B8 RID: 440
		private AcceptFriendErrorMessage.ErrorCode errorCode_0;

		// Token: 0x02000066 RID: 102
		public enum ErrorCode
		{
			// Token: 0x040001BA RID: 442
			GENERIC,
			// Token: 0x040001BB RID: 443
			BANNED,
			// Token: 0x040001BC RID: 444
			TOO_MANY_FRIENDS
		}
	}
}
