using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FD RID: 253
	public class UnlockAccountMessage : PiranhaMessage
	{
		// Token: 0x06000B83 RID: 2947 RVA: 0x0000873B File Offset: 0x0000693B
		public UnlockAccountMessage() : this(0)
		{
		}

		// Token: 0x06000B84 RID: 2948 RVA: 0x0000328E File Offset: 0x0000148E
		public UnlockAccountMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B85 RID: 2949 RVA: 0x00025B30 File Offset: 0x00023D30
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000B86 RID: 2950 RVA: 0x00008744 File Offset: 0x00006944
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
		}

		// Token: 0x06000B87 RID: 2951 RVA: 0x0000877F File Offset: 0x0000697F
		public override short GetMessageType()
		{
			return 10121;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00008786 File Offset: 0x00006986
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
			this.string_0 = null;
			this.string_1 = null;
		}

		// Token: 0x06000B8A RID: 2954 RVA: 0x000087A3 File Offset: 0x000069A3
		public LogicLong GetAccountId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x000087AB File Offset: 0x000069AB
		public void SetAccountId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x000087B4 File Offset: 0x000069B4
		public string GetPassToken()
		{
			return this.string_0;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x000087BC File Offset: 0x000069BC
		public void SetPassToken(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x000087C5 File Offset: 0x000069C5
		public string GetUnlockCode()
		{
			return this.string_1;
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x000087CD File Offset: 0x000069CD
		public void SetUnlockCode(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x04000487 RID: 1159
		public const int MESSAGE_TYPE = 10121;

		// Token: 0x04000488 RID: 1160
		private LogicLong logicLong_0;

		// Token: 0x04000489 RID: 1161
		private string string_0;

		// Token: 0x0400048A RID: 1162
		private string string_1;
	}
}
