using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000FA RID: 250
	public class ShutdownStartedMessage : PiranhaMessage
	{
		// Token: 0x06000B71 RID: 2929 RVA: 0x00008695 File Offset: 0x00006895
		public ShutdownStartedMessage() : this(0)
		{
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0000328E File Offset: 0x0000148E
		public ShutdownStartedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0000869E File Offset: 0x0000689E
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x000086B7 File Offset: 0x000068B7
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x000086D0 File Offset: 0x000068D0
		public override short GetMessageType()
		{
			return 20161;
		}

		// Token: 0x06000B76 RID: 2934 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x000086D7 File Offset: 0x000068D7
		public int GetSecondsUntilShutdown()
		{
			return this.int_0;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x000086DF File Offset: 0x000068DF
		public void SetSecondsUntilShutdown(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0400047F RID: 1151
		public const int MESSAGE_TYPE = 20161;

		// Token: 0x04000480 RID: 1152
		private int int_0;
	}
}
