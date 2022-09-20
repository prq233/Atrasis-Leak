using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Home
{
	// Token: 0x0200005C RID: 92
	public class StartFriendlyChallengeSpectateMessage : PiranhaMessage
	{
		// Token: 0x06000427 RID: 1063 RVA: 0x0000474D File Offset: 0x0000294D
		public StartFriendlyChallengeSpectateMessage() : this(0)
		{
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000328E File Offset: 0x0000148E
		public StartFriendlyChallengeSpectateMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0001CA24 File Offset: 0x0001AC24
		public override void Decode()
		{
			base.Decode();
			this.m_stream.ReadInt();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_1 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0001CA80 File Offset: 0x0001AC80
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(0);
			this.m_stream.WriteBoolean(this.logicLong_0 != null);
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteLong(this.logicLong_0);
			}
			this.m_stream.WriteBoolean(this.logicLong_1 != null);
			if (this.logicLong_1 != null)
			{
				this.m_stream.WriteLong(this.logicLong_1);
			}
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00004756 File Offset: 0x00002956
		public override short GetMessageType()
		{
			return 14110;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000046E2 File Offset: 0x000028E2
		public override int GetServiceNodeType()
		{
			return 11;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00003420 File Offset: 0x00001620
		public override void Destruct()
		{
			base.Destruct();
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000475D File Offset: 0x0000295D
		public LogicLong GetStreamId()
		{
			return this.logicLong_0;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00004765 File Offset: 0x00002965
		public void SetStreamId(LogicLong value)
		{
			this.logicLong_0 = value;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000476E File Offset: 0x0000296E
		public LogicLong GetAttackerId()
		{
			return this.logicLong_1;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00004776 File Offset: 0x00002976
		public void SetAttackerId(LogicLong value)
		{
			this.logicLong_1 = value;
		}

		// Token: 0x04000199 RID: 409
		public const int MESSAGE_TYPE = 14110;

		// Token: 0x0400019A RID: 410
		private LogicLong logicLong_0;

		// Token: 0x0400019B RID: 411
		private LogicLong logicLong_1;
	}
}
