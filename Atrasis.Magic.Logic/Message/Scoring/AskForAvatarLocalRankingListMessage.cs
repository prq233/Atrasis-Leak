using System;
using Atrasis.Magic.Titan.Math;
using Atrasis.Magic.Titan.Message;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000031 RID: 49
	public class AskForAvatarLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x0600021D RID: 541 RVA: 0x00003590 File Offset: 0x00001790
		public AskForAvatarLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000328E File Offset: 0x0000148E
		public AskForAvatarLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003599 File Offset: 0x00001799
		public override void Decode()
		{
			base.Decode();
			if (this.m_stream.ReadBoolean())
			{
				this.logicLong_0 = this.m_stream.ReadLong();
			}
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0001AAD8 File Offset: 0x00018CD8
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

		// Token: 0x06000221 RID: 545 RVA: 0x000035D0 File Offset: 0x000017D0
		public override short GetMessageType()
		{
			return 14404;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000035D7 File Offset: 0x000017D7
		public override void Destruct()
		{
			base.Destruct();
			this.logicLong_0 = null;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000035E6 File Offset: 0x000017E6
		public LogicLong RemoveAvatarId()
		{
			LogicLong result = this.logicLong_0;
			this.logicLong_0 = null;
			return result;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000035F5 File Offset: 0x000017F5
		public void SetAvatarId(LogicLong id)
		{
			this.logicLong_0 = id;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000035FE File Offset: 0x000017FE
		public int GetVillageType()
		{
			return this.int_0;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003606 File Offset: 0x00001806
		public void SetVillageType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040000C1 RID: 193
		public const int MESSAGE_TYPE = 14404;

		// Token: 0x040000C2 RID: 194
		private LogicLong logicLong_0;

		// Token: 0x040000C3 RID: 195
		private int int_0;
	}
}
