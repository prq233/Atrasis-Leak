using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000036 RID: 54
	public class AvatarDuelRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000260 RID: 608 RVA: 0x000037C6 File Offset: 0x000019C6
		public AvatarDuelRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarDuelRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0001B080 File Offset: 0x00019280
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
			int num2 = this.m_stream.ReadInt();
			if (num2 > -1)
			{
				this.logicArrayList_1 = new LogicArrayList<AvatarDuelRankingEntry>(num2);
				for (int j = 0; j < num2; j++)
				{
					AvatarDuelRankingEntry avatarDuelRankingEntry2 = new AvatarDuelRankingEntry();
					avatarDuelRankingEntry2.Decode(this.m_stream);
					this.logicArrayList_1.Add(avatarDuelRankingEntry2);
				}
			}
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0001B17C File Offset: 0x0001937C
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
			if (this.logicArrayList_1 != null)
			{
				this.m_stream.WriteInt(this.logicArrayList_1.Size());
				for (int j = 0; j < this.logicArrayList_1.Size(); j++)
				{
					this.logicArrayList_1[j].Encode(this.m_stream);
				}
			}
			else
			{
				this.m_stream.WriteInt(-1);
			}
			this.m_stream.WriteInt(this.int_0);
			this.m_stream.WriteInt(this.int_1);
			this.m_stream.WriteInt(this.int_2);
			this.m_stream.WriteInt(this.int_3);
			this.m_stream.WriteInt(this.int_4);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000037CF File Offset: 0x000019CF
		public override short GetMessageType()
		{
			return 24409;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000037D6 File Offset: 0x000019D6
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000037EC File Offset: 0x000019EC
		public LogicArrayList<AvatarDuelRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarDuelRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000037FB File Offset: 0x000019FB
		public LogicArrayList<AvatarDuelRankingEntry> RemoveLastSeasonAvatarRankingList()
		{
			LogicArrayList<AvatarDuelRankingEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000380A File Offset: 0x00001A0A
		public void SetAvatarRankingList(LogicArrayList<AvatarDuelRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00003813 File Offset: 0x00001A13
		public void SetLastSeasonAvatarRankingList(LogicArrayList<AvatarDuelRankingEntry> list)
		{
			this.logicArrayList_1 = list;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000381C File Offset: 0x00001A1C
		public int GetNextEndTimeSeconds()
		{
			return this.int_0;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00003824 File Offset: 0x00001A24
		public void SetNextEndTimeSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000382D File Offset: 0x00001A2D
		public int GetSeasonYear()
		{
			return this.int_1;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00003835 File Offset: 0x00001A35
		public void SetSeasonYear(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000383E File Offset: 0x00001A3E
		public int GetSeasonMonth()
		{
			return this.int_2;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00003846 File Offset: 0x00001A46
		public void SetSeasonMonth(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000384F File Offset: 0x00001A4F
		public int GetLastSeasonYear()
		{
			return this.int_3;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00003857 File Offset: 0x00001A57
		public void SetLastSeasonYear(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00003860 File Offset: 0x00001A60
		public int GetLastSeasonMonth()
		{
			return this.int_4;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00003868 File Offset: 0x00001A68
		public void SetLastSeasonMonth(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x040000DE RID: 222
		public const int MESSAGE_TYPE = 24409;

		// Token: 0x040000DF RID: 223
		private int int_0;

		// Token: 0x040000E0 RID: 224
		private int int_1;

		// Token: 0x040000E1 RID: 225
		private int int_2;

		// Token: 0x040000E2 RID: 226
		private int int_3;

		// Token: 0x040000E3 RID: 227
		private int int_4;

		// Token: 0x040000E4 RID: 228
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_0;

		// Token: 0x040000E5 RID: 229
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_1;
	}
}
