using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EF RID: 239
	public class KeepAliveMessage : PiranhaMessage
	{
		// Token: 0x06000AB8 RID: 2744 RVA: 0x000080C3 File Offset: 0x000062C3
		public KeepAliveMessage() : this(0)
		{
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0000328E File Offset: 0x0000148E
		public KeepAliveMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x000080CC File Offset: 0x000062CC
		public override short GetMessageType()
		{
			return 10108;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400042C RID: 1068
		public const int MESSAGE_TYPE = 10108;
	}
}
