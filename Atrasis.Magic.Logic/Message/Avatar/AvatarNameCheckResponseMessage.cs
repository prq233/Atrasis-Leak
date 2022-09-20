﻿using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Avatar
{
	// Token: 0x02000084 RID: 132
	public class AvatarNameCheckResponseMessage : PiranhaMessage
	{
		// Token: 0x060005A9 RID: 1449 RVA: 0x0000547E File Offset: 0x0000367E
		public AvatarNameCheckResponseMessage() : this(0)
		{
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarNameCheckResponseMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x00005487 File Offset: 0x00003687
		public override void Decode()
		{
			base.Decode();
			this.bool_0 = this.m_stream.ReadBoolean();
			this.errorCode_0 = (AvatarNameCheckResponseMessage.ErrorCode)this.m_stream.ReadInt();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x000054C7 File Offset: 0x000036C7
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteBoolean(this.bool_0);
			this.m_stream.WriteInt((int)this.errorCode_0);
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00005502 File Offset: 0x00003702
		public override short GetMessageType()
		{
			return 20300;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00005509 File Offset: 0x00003709
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00005518 File Offset: 0x00003718
		public string GetName()
		{
			return this.string_0;
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00005520 File Offset: 0x00003720
		public void SetName(string name)
		{
			this.string_0 = name;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00005529 File Offset: 0x00003729
		public bool IsInvalid()
		{
			return this.bool_0;
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00005531 File Offset: 0x00003731
		public void SetInvalid(bool invalid)
		{
			this.bool_0 = invalid;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000553A File Offset: 0x0000373A
		public AvatarNameCheckResponseMessage.ErrorCode GetErrorCode()
		{
			return this.errorCode_0;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00005542 File Offset: 0x00003742
		public void SetErrorCode(AvatarNameCheckResponseMessage.ErrorCode errorCode)
		{
			this.errorCode_0 = errorCode;
		}

		// Token: 0x0400021E RID: 542
		public const int MESSAGE_TYPE = 20300;

		// Token: 0x0400021F RID: 543
		private bool bool_0;

		// Token: 0x04000220 RID: 544
		private AvatarNameCheckResponseMessage.ErrorCode errorCode_0;

		// Token: 0x04000221 RID: 545
		private string string_0;

		// Token: 0x02000085 RID: 133
		public enum ErrorCode
		{
			// Token: 0x04000223 RID: 547
			INVALID_NAME = 1,
			// Token: 0x04000224 RID: 548
			NAME_TOO_SHORT,
			// Token: 0x04000225 RID: 549
			NAME_TOO_LONG,
			// Token: 0x04000226 RID: 550
			NAME_ALREADY_CHANGED,
			// Token: 0x04000227 RID: 551
			NAME_TH_LEVEL_TOO_LOW
		}
	}
}
