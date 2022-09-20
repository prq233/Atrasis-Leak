using System;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F5 RID: 245
	public class PersonalBreakStartedMessage : PiranhaMessage
	{
		// Token: 0x06000B45 RID: 2885 RVA: 0x000084E7 File Offset: 0x000066E7
		public PersonalBreakStartedMessage() : this(0)
		{
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0000328E File Offset: 0x0000148E
		public PersonalBreakStartedMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x000084F0 File Offset: 0x000066F0
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x00008509 File Offset: 0x00006709
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x00008522 File Offset: 0x00006722
		public override short GetMessageType()
		{
			return 20171;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x00008529 File Offset: 0x00006729
		public int GetSecondsUntilBreak()
		{
			return this.int_0;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00008531 File Offset: 0x00006731
		public void SetSecondsUntilBreak(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000475 RID: 1141
		public const int MESSAGE_TYPE = 20171;

		// Token: 0x04000476 RID: 1142
		private int int_0;
	}
}
