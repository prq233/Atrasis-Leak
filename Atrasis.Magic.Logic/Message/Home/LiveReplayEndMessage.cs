using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000053 RID: 83
	public class LiveReplayEndMessage : PiranhaMessage
	{
		// Token: 0x060003C1 RID: 961 RVA: 0x0000440A File Offset: 0x0000260A
		public LiveReplayEndMessage() : this(0)
		{
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000328E File Offset: 0x0000148E
		public LiveReplayEndMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x00004413 File Offset: 0x00002613
		public override short GetMessageType()
		{
			return 24126;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000174 RID: 372
		public const int MESSAGE_TYPE = 24126;
	}
}
