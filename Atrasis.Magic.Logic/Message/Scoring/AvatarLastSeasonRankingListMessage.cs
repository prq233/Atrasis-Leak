using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000037 RID: 55
	public class AvatarLastSeasonRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000275 RID: 629 RVA: 0x00003871 File Offset: 0x00001A71
		public AvatarLastSeasonRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarLastSeasonRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0001B298 File Offset: 0x00019498
		public override void Decode()
		{
			base.Decode();
			int num = this.m_stream.ReadInt();
			if (num > -1)
			{
				this.logicArrayList_0 = new LogicArrayList<AvatarRankingEntry>(num);
				for (int i = 0; i < num; i++)
				{
					AvatarRankingEntry avatarRankingEntry = new AvatarRankingEntry();
					avatarRankingEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(avatarRankingEntry);
				}
			}
			this.int_1 = this.m_stream.ReadInt();
			this.int_0 = this.m_stream.ReadInt();
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0001B314 File Offset: 0x00019514
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

		// Token: 0x06000279 RID: 633 RVA: 0x0000387A File Offset: 0x00001A7A
		public override short GetMessageType()
		{
			return 24405;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00003881 File Offset: 0x00001A81
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00003890 File Offset: 0x00001A90
		public LogicArrayList<AvatarRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000389F File Offset: 0x00001A9F
		public void SetAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000038A8 File Offset: 0x00001AA8
		public int GetSeasonYear()
		{
			return this.int_0;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000038B0 File Offset: 0x00001AB0
		public void SetSeasonYear(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000038B9 File Offset: 0x00001AB9
		public int GetSeasonMonth()
		{
			return this.int_1;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x000038C1 File Offset: 0x00001AC1
		public void SetSeasonMonth(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x040000E6 RID: 230
		public const int MESSAGE_TYPE = 24405;

		// Token: 0x040000E7 RID: 231
		private int int_0;

		// Token: 0x040000E8 RID: 232
		private int int_1;

		// Token: 0x040000E9 RID: 233
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;
	}
}
