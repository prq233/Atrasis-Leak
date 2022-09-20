using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BB RID: 187
	public class AskForJoinableAlliancesListMessage : PiranhaMessage
	{
		// Token: 0x0600080D RID: 2061 RVA: 0x00006A14 File Offset: 0x00004C14
		public AskForJoinableAlliancesListMessage() : this(0)
		{
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForJoinableAlliancesListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00006A1D File Offset: 0x00004C1D
		public override short GetMessageType()
		{
			return 14303;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00006A24 File Offset: 0x00004C24
		public override int GetServiceNodeType()
		{
			return 29;
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400031D RID: 797
		public const int MESSAGE_TYPE = 14303;
	}
}
