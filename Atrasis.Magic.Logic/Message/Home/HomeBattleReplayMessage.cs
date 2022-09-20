using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x02000051 RID: 81
	public class HomeBattleReplayMessage : PiranhaMessage
	{
		// Token: 0x060003A7 RID: 935 RVA: 0x00004321 File Offset: 0x00002521
		public HomeBattleReplayMessage() : this(0)
		{
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000328E File Offset: 0x0000148E
		public HomeBattleReplayMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000432A File Offset: 0x0000252A
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			this.logicLong_0 = this.m_stream.ReadLong();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00004354 File Offset: 0x00002554
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteLong(this.logicLong_0);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000437E File Offset: 0x0000257E
		public int GetReplayShardId()
		{
			return this.int_0;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00004386 File Offset: 0x00002586
		public void SetReplayShardId(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000438F File Offset: 0x0000258F
		public LogicLong GetReplayId()
		{
			return this.logicLong_0;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00004397 File Offset: 0x00002597
		public void SetReplayId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x000043A0 File Offset: 0x000025A0
		public override short GetMessageType()
		{
			return 14114;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00003F0B File Offset: 0x0000210B
		public override int GetServiceNodeType()
		{
			return 9;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0400016C RID: 364
		public const int MESSAGE_TYPE = 14114;

		// Token: 0x0400016D RID: 365
		private int int_0;

		// Token: 0x0400016E RID: 366
		private LogicLong logicLong_0;
	}
}
