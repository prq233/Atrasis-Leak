using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000EC RID: 236
	public class ChatAccountBanStatusMessage : PiranhaMessage
	{
		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000805E File Offset: 0x0000625E
		public ChatAccountBanStatusMessage() : this(0)
		{
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0000328E File Offset: 0x0000148E
		public ChatAccountBanStatusMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x00003E27 File Offset: 0x00002027
		public override void Decode()
		{
			base.Decode();
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00003E2F File Offset: 0x0000202F
		public override void Encode()
		{
			base.Encode();
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x00008067 File Offset: 0x00006267
		public int GetBanSeconds()
		{
			return this.int_0;
		}

		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000806F File Offset: 0x0000626F
		public void SetBanSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000429 RID: 1065
		private int int_0;
	}
}
