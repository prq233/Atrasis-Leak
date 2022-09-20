using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F0 RID: 240
	public class KeepAliveServerMessage : PiranhaMessage
	{
		// Token: 0x06000ABF RID: 2751 RVA: 0x000080D3 File Offset: 0x000062D3
		public KeepAliveServerMessage() : this(0)
		{
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000328E File Offset: 0x0000148E
		public KeepAliveServerMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000080DC File Offset: 0x000062DC
		public override short GetMessageType()
		{
			return 20108;
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400042D RID: 1069
		public const int MESSAGE_TYPE = 20108;
	}
}
