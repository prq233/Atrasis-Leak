using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F7 RID: 247
	public class ReportUserStatusMessage : PiranhaMessage
	{
		// Token: 0x06000B57 RID: 2903 RVA: 0x00008594 File Offset: 0x00006794
		public ReportUserStatusMessage() : this(0)
		{
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0000328E File Offset: 0x0000148E
		public ReportUserStatusMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0000859D File Offset: 0x0000679D
		public override void Decode()
		{
			base.Decode();
			this.m_stream.ReadInt();
			this.m_stream.ReadInt();
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x000085BD File Offset: 0x000067BD
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(0);
			this.m_stream.WriteInt(0);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x000085DD File Offset: 0x000067DD
		public override short GetMessageType()
		{
			return 20117;
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000479 RID: 1145
		public const int MESSAGE_TYPE = 20117;
	}
}
