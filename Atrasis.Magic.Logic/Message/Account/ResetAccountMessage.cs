using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F8 RID: 248
	public class ResetAccountMessage : PiranhaMessage
	{
		// Token: 0x06000B5E RID: 2910 RVA: 0x000085E4 File Offset: 0x000067E4
		public ResetAccountMessage() : this(0)
		{
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0000328E File Offset: 0x0000148E
		public ResetAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x000085ED File Offset: 0x000067ED
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x00008606 File Offset: 0x00006806
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0000861F File Offset: 0x0000681F
		public override short GetMessageType()
		{
			return 10116;
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00008626 File Offset: 0x00006826
		public int GetAccountPreset()
		{
			return this.int_0;
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0000862E File Offset: 0x0000682E
		public void SetAccountPreset(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0400047A RID: 1146
		public const int MESSAGE_TYPE = 10116;

		// Token: 0x0400047B RID: 1147
		private int int_0;
	}
}
