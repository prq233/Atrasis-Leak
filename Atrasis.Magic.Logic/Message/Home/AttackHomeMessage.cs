using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000041 RID: 65
	public class AttackHomeMessage : PiranhaMessage
	{
		// Token: 0x06000308 RID: 776 RVA: 0x00003D65 File Offset: 0x00001F65
		public AttackHomeMessage() : this(0)
		{
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000328E File Offset: 0x0000148E
		public AttackHomeMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00003D6E File Offset: 0x00001F6E
		public override void Decode()
		{
			base.Decode();
			this.logicLong_0 = this.m_stream.ReadLong();
			this.int_0 = this.m_stream.ReadInt();
			this.logicLong_1 = this.m_stream.ReadLong();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00003DA9 File Offset: 0x00001FA9
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteLong(this.logicLong_0);
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteLong(this.logicLong_1);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00003DE4 File Offset: 0x00001FE4
		public override short GetMessageType()
		{
			return 14106;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00003D3F File Offset: 0x00001F3F
		public override int GetServiceNodeType()
		{
			return 10;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00003DEB File Offset: 0x00001FEB
		public LogicLong GetHomeId()
		{
			return this.logicLong_0;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00003DF3 File Offset: 0x00001FF3
		public void SetHomeId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00003DFC File Offset: 0x00001FFC
		public LogicLong GetAvatarStreamId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00003E04 File Offset: 0x00002004
		public void SetAvatarStreamId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00003E0D File Offset: 0x0000200D
		public int GetAttackSource()
		{
			return this.int_0;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00003E15 File Offset: 0x00002015
		public void SetAttackSource(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x04000137 RID: 311
		public const int MESSAGE_TYPE = 14106;

		// Token: 0x04000138 RID: 312
		private LogicLong logicLong_0;

		// Token: 0x04000139 RID: 313
		private LogicLong logicLong_1;

		// Token: 0x0400013A RID: 314
		private int int_0;
	}
}
