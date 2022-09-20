using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x0200003A RID: 58
	public class AvatarRankingListMessage : PiranhaMessage
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x000039CB File Offset: 0x00001BCB
		public AvatarRankingListMessage() : this(0)
		{
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0001B818 File Offset: 0x00019A18
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
			int num2 = this.m_stream.ReadInt();
			if (num2 > -1)
			{
				this.logicArrayList_1 = new LogicArrayList<AvatarRankingEntry>(num2);
				for (int j = 0; j < num2; j++)
				{
					AvatarRankingEntry avatarRankingEntry2 = new AvatarRankingEntry();
					avatarRankingEntry2.Decode(this.m_stream);
					this.logicArrayList_1.Add(avatarRankingEntry2);
				}
			}
			this.int_0 = this.m_stream.ReadInt();
			this.int_1 = this.m_stream.ReadInt();
			this.int_2 = this.m_stream.ReadInt();
			this.int_3 = this.m_stream.ReadInt();
			this.int_4 = this.m_stream.ReadInt();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0001B914 File Offset: 0x00019B14
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

		// Token: 0x060002AA RID: 682 RVA: 0x000039D4 File Offset: 0x00001BD4
		public override short GetMessageType()
		{
			return 24403;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000039DB File Offset: 0x00001BDB
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
			this.logicArrayList_1 = null;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000039F1 File Offset: 0x00001BF1
		public LogicArrayList<AvatarRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00003A00 File Offset: 0x00001C00
		public LogicArrayList<AvatarRankingEntry> RemoveLastSeasonAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_1;
			this.logicArrayList_1 = null;
			return result;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00003A0F File Offset: 0x00001C0F
		public void SetAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00003A18 File Offset: 0x00001C18
		public void SetLastSeasonAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_1 = list;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00003A21 File Offset: 0x00001C21
		public int GetNextEndTimeSeconds()
		{
			return this.int_0;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00003A29 File Offset: 0x00001C29
		public void SetNextEndTimeSeconds(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00003A32 File Offset: 0x00001C32
		public int GetSeasonYear()
		{
			return this.int_1;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00003A3A File Offset: 0x00001C3A
		public void SetSeasonYear(int value)
		{
			this.int_1 = value;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00003A43 File Offset: 0x00001C43
		public int GetSeasonMonth()
		{
			return this.int_2;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00003A4B File Offset: 0x00001C4B
		public void SetSeasonMonth(int value)
		{
			this.int_2 = value;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00003A54 File Offset: 0x00001C54
		public int GetLastSeasonYear()
		{
			return this.int_3;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00003A5C File Offset: 0x00001C5C
		public void SetLastSeasonYear(int value)
		{
			this.int_3 = value;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00003A65 File Offset: 0x00001C65
		public int GetLastSeasonMonth()
		{
			return this.int_4;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003A6D File Offset: 0x00001C6D
		public void SetLastSeasonMonth(int value)
		{
			this.int_4 = value;
		}

		// Token: 0x04000101 RID: 257
		public const int MESSAGE_TYPE = 24403;

		// Token: 0x04000102 RID: 258
		private int int_0;

		// Token: 0x04000103 RID: 259
		private int int_1;

		// Token: 0x04000104 RID: 260
		private int int_2;

		// Token: 0x04000105 RID: 261
		private int int_3;

		// Token: 0x04000106 RID: 262
		private int int_4;

		// Token: 0x04000107 RID: 263
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;

		// Token: 0x04000108 RID: 264
		private LogicArrayList<AvatarRankingEntry> logicArrayList_1;
	}
}
