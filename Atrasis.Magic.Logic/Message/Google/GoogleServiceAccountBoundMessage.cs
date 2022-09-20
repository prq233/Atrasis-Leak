using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Google
{
	// Token: 0x02000064 RID: 100
	public class GoogleServiceAccountBoundMessage : PiranhaMessage
	{
		// Token: 0x06000485 RID: 1157 RVA: 0x00004AE2 File Offset: 0x00002CE2
		public GoogleServiceAccountBoundMessage() : this(0)
		{
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000328E File Offset: 0x0000148E
		public GoogleServiceAccountBoundMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00004AEB File Offset: 0x00002CEB
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00004B04 File Offset: 0x00002D04
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00004B1D File Offset: 0x00002D1D
		public override short GetMessageType()
		{
			return 24261;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00004B24 File Offset: 0x00002D24
		public int GetResultCode()
		{
			return this.int_0;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00004B2C File Offset: 0x00002D2C
		public void SetResultCode(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001B5 RID: 437
		public const int MESSAGE_TYPE = 20261;

		// Token: 0x040001B6 RID: 438
		private int int_0;
	}
}
