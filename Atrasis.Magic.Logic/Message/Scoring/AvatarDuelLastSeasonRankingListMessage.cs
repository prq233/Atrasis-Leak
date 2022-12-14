using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000033 RID: 51
	public class AvatarDuelLastSeasonRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000233 RID: 563 RVA: 0x0000368E File Offset: 0x0000188E
		public AvatarDuelLastSeasonRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarDuelLastSeasonRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0001AB88 File Offset: 0x00018D88
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<AvatarDuelRankingEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AvatarDuelRankingEntry avatarDuelRankingEntry = new AvatarDuelRankingEntry();
					avatarDuelRankingEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(avatarDuelRankingEntry);
				}
			}
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001AC04 File Offset: 0x00018E04
		public override void Encode()
		{
			base.Encode();
			if (this.logicArrayList_0 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_0.Size());
				for (int i = 0; i < this.logicArrayList_0.Size(); i++)
				{
					this.logicArrayList_0[i].Encode(this.m_stream);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_0);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00003697 File Offset: 0x00001897
		public override short GetMessageType()
		{
			return 24408;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000369E File Offset: 0x0000189E
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000036AD File Offset: 0x000018AD
		public LogicArrayList<AvatarDuelRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarDuelRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000036BC File Offset: 0x000018BC
		public void SetAvatarRankingList(LogicArrayList<AvatarDuelRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000036C5 File Offset: 0x000018C5
		public int GetSeasonYear()
		{
			return this.int_0;
		}

		// Token: 0x0600023D RID: 573 RVA: 0x000036CD File Offset: 0x000018CD
		public void SetSeasonYear(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000036D6 File Offset: 0x000018D6
		public int GetSeasonMonth()
		{
			return this.int_1;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000036DE File Offset: 0x000018DE
		public void SetSeasonMonth(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x040000C7 RID: 199
		public const int MESSAGE_TYPE = 24408;

		// Token: 0x040000C8 RID: 200
		private int int_0;

		// Token: 0x040000C9 RID: 201
		private int int_1;

		// Token: 0x040000CA RID: 202
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_0;
	}
}
