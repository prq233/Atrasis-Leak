using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EA RID: 234
	public class AppleBillingProcessedByServerMessage : PiranhaMessage
	{
		// Token: 0x06000A89 RID: 2697 RVA: 0x00007F2A File Offset: 0x0000612A
		public AppleBillingProcessedByServerMessage() : this(0)
		{
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x0000328E File Offset: 0x0000148E
		public AppleBillingProcessedByServerMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00007F33 File Offset: 0x00006133
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
			this.string_1 = this.m_stream.ReadString(900000);
			this.m_stream.ReadInt();
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00007F73 File Offset: 0x00006173
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
			this.m_stream.WriteString(this.string_1);
			this.m_stream.WriteInt(0);
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00007FA9 File Offset: 0x000061A9
		public override short GetMessageType()
		{
			return 20151;
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00007FB0 File Offset: 0x000061B0
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
			this.string_1 = null;
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00007FC6 File Offset: 0x000061C6
		public string GetTID()
		{
			return this.string_0;
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00007FCE File Offset: 0x000061CE
		public void SetTID(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00007FD7 File Offset: 0x000061D7
		public string GetProdID()
		{
			return this.string_1;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x00007FDF File Offset: 0x000061DF
		public void SetProdID(string value)
		{
			this.string_1 = value;
		}

		// Token: 0x04000420 RID: 1056
		public const int MESSAGE_TYPE = 20151;

		// Token: 0x04000421 RID: 1057
		private string string_0;

		// Token: 0x04000422 RID: 1058
		private string string_1;
	}
}
