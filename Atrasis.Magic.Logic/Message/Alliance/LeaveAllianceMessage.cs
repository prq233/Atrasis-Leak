using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Alliance
{
	// Token: 0x020000C4 RID: 196
	public class LeaveAllianceMessage : PiranhaMessage
	{
		// Token: 0x0600087D RID: 2173 RVA: 0x00006DB0 File Offset: 0x00004FB0
		public LeaveAllianceMessage() : this(0)
		{
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x0000328E File Offset: 0x0000148E
		public LeaveAllianceMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00006DB9 File Offset: 0x00004FB9
		public override short GetMessageType()
		{
			return 14308;
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000342 RID: 834
		public const int MESSAGE_TYPE = 14308;
	}
}
