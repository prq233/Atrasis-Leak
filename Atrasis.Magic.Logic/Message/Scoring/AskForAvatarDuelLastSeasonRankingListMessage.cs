using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200002F RID: 47
	public class AskForAvatarDuelLastSeasonRankingListMessage : PiranhaMessage
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00003462 File Offset: 0x00001662
		public AskForAvatarDuelLastSeasonRankingListMessage() : this(0)
		{
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAvatarDuelLastSeasonRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000346B File Offset: 0x0000166B
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00003491 File Offset: 0x00001691
		public override void Encode()
		{
			base.Encode();
			if (this.logicLong_0 != null)
			{
				this.m_stream.WriteBoolean(true);
				this.m_stream.WriteLong(this.logicLong_0);
				return;
			}
			this.m_stream.WriteBoolean(false);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x000034CB File Offset: 0x000016CB
		public override short GetMessageType()
		{
			return 14408;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000034D2 File Offset: 0x000016D2
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000034E1 File Offset: 0x000016E1
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000034F0 File Offset: 0x000016F0
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x040000BD RID: 189
		public const int MESSAGE_TYPE = 14408;

		// Token: 0x040000BE RID: 190
		private LogicLong logicLong_0;
	}
}
