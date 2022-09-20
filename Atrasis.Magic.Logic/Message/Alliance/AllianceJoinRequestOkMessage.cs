using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000B4 RID: 180
	public class AllianceJoinRequestOkMessage : PiranhaMessage
	{
		// Token: 0x060007AB RID: 1963 RVA: 0x0000667F File Offset: 0x0000487F
		public AllianceJoinRequestOkMessage() : this(0)
		{
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0000328E File Offset: 0x0000148E
		public AllianceJoinRequestOkMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00006688 File Offset: 0x00004888
		public override short GetMessageType()
		{
			return 24319;
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x040002FE RID: 766
		public const int MESSAGE_TYPE = 24319;
	}
}
