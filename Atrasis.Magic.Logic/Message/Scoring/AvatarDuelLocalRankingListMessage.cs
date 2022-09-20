using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000034 RID: 52
	public class AvatarDuelLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000240 RID: 576 RVA: 0x000036E7 File Offset: 0x000018E7
		public AvatarDuelLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarDuelLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0001AC94 File Offset: 0x00018E94
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
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0001ACF0 File Offset: 0x00018EF0
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
				return;
			}
			this.m_stream.WriteInt(-1);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000036F0 File Offset: 0x000018F0
		public override short GetMessageType()
		{
			return 24407;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000036F7 File Offset: 0x000018F7
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00003706 File Offset: 0x00001906
		public LogicArrayList<AvatarDuelRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarDuelRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00003715 File Offset: 0x00001915
		public void SetAvatarRankingList(LogicArrayList<AvatarDuelRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x040000CB RID: 203
		public const int MESSAGE_TYPE = 24407;

		// Token: 0x040000CC RID: 204
		private LogicArrayList<AvatarDuelRankingEntry> logicArrayList_0;
	}
}
