using System;
using Atrasis.Magic.Titan.Message;
using Atrasis.Magic.Titan.Util;

namespace Atrasis.Magic.Logic.Message.Friend
{
	// Token: 0x0200006E RID: 110
	public class FriendListMessage : PiranhaMessage
	{
		// Token: 0x060004E1 RID: 1249 RVA: 0x00004DFD File Offset: 0x00002FFD
		public FriendListMessage() : this(0)
		{
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0000328E File Offset: 0x0000148E
		public FriendListMessage(short messageVersion) : base(messageVersion)
		{
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x0001CFE4 File Offset: 0x0001B1E4
		public override void Decode()
		{
			base.Decode();
			this.int_0 = this.m_stream.ReadInt();
			int num = this.m_stream.ReadInt();
			if (num != -1)
			{
				this.logicArrayList_0 = new LogicArrayList<FriendEntry>(num);
				for (int i = 0; i < num; i++)
				{
					FriendEntry friendEntry = new FriendEntry();
					friendEntry.Decode(this.m_stream);
					this.logicArrayList_0.Add(friendEntry);
				}
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x0001D050 File Offset: 0x0001B250
		public override void Encode()
		{
			base.Encode();
			this.m_stream.WriteInt(this.int_0);
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

		// Token: 0x060004E5 RID: 1253 RVA: 0x00004E06 File Offset: 0x00003006
		public override short GetMessageType()
		{
			return 20105;
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00002C4F File Offset: 0x00000E4F
		public override int GetServiceNodeType()
		{
			return 3;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00004E0D File Offset: 0x0000300D
		public override void Destruct()
		{
			base.Destruct();
			this.logicArrayList_0 = null;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x00004E1C File Offset: 0x0000301C
		public LogicArrayList<FriendEntry> RemoveFriendEntries()
		{
			LogicArrayList<FriendEntry> result = this.logicArrayList_0;
			this.logicArrayList_0 = null;
			return result;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00004E2B File Offset: 0x0000302B
		public void SetFriendEntries(LogicArrayList<FriendEntry> list)
		{
			this.logicArrayList_0 = list;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00004E34 File Offset: 0x00003034
		public int GetListType()
		{
			return this.int_0;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00004E3C File Offset: 0x0000303C
		public void SetListType(int value)
		{
			this.int_0 = value;
		}

		// Token: 0x040001DD RID: 477
		public const int MESSAGE_TYPE = 20105;

		// Token: 0x040001DE RID: 478
		private int int_0;

		// Token: 0x040001DF RID: 479
		private LogicArrayList<FriendEntry> logicArrayList_0;
	}
}
