using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Account
{
	// Token: 0x020000F6 RID: 246
	public class ReportUserMessage : PiranhaMessage
	{
		// Token: 0x06000B4E RID: 2894 RVA: 0x0000853A File Offset: 0x0000673A
		public ReportUserMessage() : this(0)
		{
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0000328E File Offset: 0x0000148E
		public ReportUserMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00008543 File Offset: 0x00006743
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0000855C File Offset: 0x0000675C
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x00008575 File Offset: 0x00006775
		public override short GetMessageType()
		{
			return 10117;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00002B38 File Offset: 0x00000D38
		public override int GetServiceNodeType()
		{
			return 1;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0000857C File Offset: 0x0000677C
		public LogicLong RemoveReportedAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0000858B File Offset: 0x0000678B
		public void SetReportedAvatarId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x04000477 RID: 1143
		public const int MESSAGE_TYPE = 10117;

		// Token: 0x04000478 RID: 1144
		private LogicLong logicLong_0;
	}
}
