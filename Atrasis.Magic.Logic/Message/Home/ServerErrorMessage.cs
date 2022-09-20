using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005B RID: 91
	public class ServerErrorMessage : PiranhaMessage
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x000046E6 File Offset: 0x000028E6
		public ServerErrorMessage() : this(0)
		{
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000328E File Offset: 0x0000148E
		public ServerErrorMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000046EF File Offset: 0x000028EF
		public override void Decode()
		{
			base.Decode();
			this.string_0 = this.m_stream.ReadString(900000);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000470D File Offset: 0x0000290D
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteString(this.string_0);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00004726 File Offset: 0x00002926
		public override short GetMessageType()
		{
			return 24115;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000472D File Offset: 0x0000292D
		public override void Destruct()
		{
			base.Destruct();
			this.string_0 = null;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000473C File Offset: 0x0000293C
		public string GetErrorMessage()
		{
			return this.string_0;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00004744 File Offset: 0x00002944
		public void SetErrorMessage(string value)
		{
			this.string_0 = value;
		}

		// Token: 0x04000197 RID: 407
		public const int MESSAGE_TYPE = 24115;

		// Token: 0x04000198 RID: 408
		private string string_0;
	}
}
