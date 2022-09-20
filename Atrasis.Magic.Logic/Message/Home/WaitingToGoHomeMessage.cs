using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000061 RID: 97
	public class WaitingToGoHomeMessage : PiranhaMessage
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x00004971 File Offset: 0x00002B71
		public WaitingToGoHomeMessage() : this(0)
		{
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0000328E File Offset: 0x0000148E
		public WaitingToGoHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000497A File Offset: 0x00002B7A
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00004993 File Offset: 0x00002B93
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x000049AC File Offset: 0x00002BAC
		public override short GetMessageType()
		{
			return 24112;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x000049B3 File Offset: 0x00002BB3
		public int GetEstimatedTimeSeconds()
		{
			return this.int_0;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x000049BB File Offset: 0x00002BBB
		public void SetEstimatedTimeSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001AA RID: 426
		public const int MESSAGE_TYPE = 24112;

		// Token: 0x040001AB RID: 427
		private int int_0;
	}
}
