using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FE RID: 254
	public class UnlockAccountOkMessage : PiranhaMessage
	{
		// Token: 0x06000B90 RID: 2960 RVA: 0x000087D6 File Offset: 0x000069D6
		public UnlockAccountOkMessage() : this(0)
		{
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0000328E File Offset: 0x0000148E
		public UnlockAccountOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B92 RID: 2962 RVA: 0x000087DF File Offset: 0x000069DF
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000B93 RID: 2963 RVA: 0x0000880E File Offset: 0x00006A0E
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x06000B94 RID: 2964 RVA: 0x00008838 File Offset: 0x00006A38
		public override short GetMessageType()
		{
			return 20132;
		}

		// Token: 0x06000B95 RID: 2965 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B96 RID: 2966 RVA: 0x0000883F File Offset: 0x00006A3F
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
		}

		// Token: 0x06000B97 RID: 2967 RVA: 0x00008855 File Offset: 0x00006A55
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B98 RID: 2968 RVA: 0x0000885D File Offset: 0x00006A5D
		public void SetAccountId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000B99 RID: 2969 RVA: 0x00008866 File Offset: 0x00006A66
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B9A RID: 2970 RVA: 0x0000886E File Offset: 0x00006A6E
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x0400048B RID: 1163
		public const int MESSAGE_TYPE = 20132;

		// Token: 0x0400048C RID: 1164
		private LogicLong logicLong_0;

		// Token: 0x0400048D RID: 1165
		private string string_0;
	}
}
