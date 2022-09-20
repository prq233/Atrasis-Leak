using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Scoring
{
	// Token: 0x02000038 RID: 56
	public class AvatarLocalRankingListMessage : PiranhaMessage
	{
		// Token: 0x06000282 RID: 642 RVA: 0x000038CA File Offset: 0x00001ACA
		public AvatarLocalRankingListMessage() : this(0)
		{
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000328E File Offset: 0x0000148E
		public AvatarLocalRankingListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0001B3A4 File Offset: 0x000195A4
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
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001B400 File Offset: 0x00019600
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

		// Token: 0x06000286 RID: 646 RVA: 0x000038D3 File Offset: 0x00001AD3
		public override short GetMessageType()
		{
			return 24404;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000329E File Offset: 0x0000149E
		public override int GetServiceNodeType()
		{
			return 28;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000038DA File Offset: 0x00001ADA
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000038E9 File Offset: 0x00001AE9
		public LogicArrayList<AvatarRankingEntry> RemoveAvatarRankingList()
		{
			LogicArrayList<AvatarRankingEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000038F8 File Offset: 0x00001AF8
		public void SetAvatarRankingList(LogicArrayList<AvatarRankingEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x040000EA RID: 234
		public const int MESSAGE_TYPE = 24404;

		// Token: 0x040000EB RID: 235
		private LogicArrayList<AvatarRankingEntry> logicArrayList_0;
	}
}
