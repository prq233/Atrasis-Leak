using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200004F RID: 79
	public class HomeBattleReplayFailedMessage : PiranhaMessage
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x000042DF File Offset: 0x000024DF
		public HomeBattleReplayFailedMessage() : this(0)
		{
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000328E File Offset: 0x0000148E
		public HomeBattleReplayFailedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x000042E8 File Offset: 0x000024E8
		public override void Decode()
		{
			base.Decode();
			this.reason_0 = (HomeBattleReplayFailedMessage.Reason)this.m_stream.ReadInt();
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00004301 File Offset: 0x00002501
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt((int)this.reason_0);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000431A File Offset: 0x0000251A
		public override short GetMessageType()
		{
			return 24116;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x04000169 RID: 361
		public const int MESSAGE_TYPE = 24116;

		// Token: 0x0400016A RID: 362
		private HomeBattleReplayFailedMessage.Reason reason_0;

		// Token: 0x02000050 RID: 80
		public enum Reason
		{

		}
	}
}
