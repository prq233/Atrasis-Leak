using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000BC RID: 188
	public class CancelChallengeMessage : PiranhaMessage
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x00006A28 File Offset: 0x00004C28
		public CancelChallengeMessage() : this(0)
		{
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0000328E File Offset: 0x0000148E
		public CancelChallengeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00006A31 File Offset: 0x00004C31
		public override short GetMessageType()
		{
			return 14125;
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400031E RID: 798
		public const int MESSAGE_TYPE = 14125;
	}
}
