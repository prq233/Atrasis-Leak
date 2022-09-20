using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000032 RID: 50
	public class AskForAvatarRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000228 RID: 552 RVA: 0x0000360F File Offset: 0x0000180F
		public AskForAvatarRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAvatarRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003618 File Offset: 0x00001818
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0001AB30 File Offset: 0x00018D30
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
			}
			else
			{
				this.m_stream.WriteBoolean(false);
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000364F File Offset: 0x0000184F
		public override short GetMessageType()
		{
			return 14403;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00003656 File Offset: 0x00001856
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003665 File Offset: 0x00001865
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00003674 File Offset: 0x00001874
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000367D File Offset: 0x0000187D
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00003685 File Offset: 0x00001885
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000C4 RID: 196
		public const int MESSAGE_TYPE = 14403;

		// Token: 0x040000C5 RID: 197
		private LogicLong logicLong_0;

		// Token: 0x040000C6 RID: 198
		private int int_0;
	}
}
